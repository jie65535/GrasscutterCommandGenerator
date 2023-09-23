#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Eavesdrop;

public sealed class Certifier : IDisposable
{
    private readonly X509Store _rootStore, _myStore;
    private readonly IDictionary<string, X509Certificate2> _certificateCache;

    public string Issuer { get; }
    public string CertificateAuthorityName { get; }

    public DateTime NotAfter { get; set; }
    public DateTime NotBefore { get; set; }
    public int KeyLength { get; set; } = 1024;
    public bool IsCachingSignedCertificates { get; set; }

    public X509Certificate2? Authority { get; private set; }

    public Certifier()
        : this("Eavesdrop")
    { }
    public Certifier(string issuer)
        : this(issuer, $"{issuer} Root Certificate Authority", StoreLocation.CurrentUser)
    { }
    public Certifier(string issuer, string certificateAuthorityName)
        : this(issuer, certificateAuthorityName, StoreLocation.CurrentUser)
    { }
    public Certifier(string issuer, string certificateAuthorityName, StoreLocation location)
    {
        _myStore = new X509Store(StoreName.My, location);
        _rootStore = new X509Store(StoreName.Root, location);
        _certificateCache = new Dictionary<string, X509Certificate2>();

        NotBefore = DateTime.Now;
        NotAfter = NotBefore.AddMonths(1);

        Issuer = issuer;
        CertificateAuthorityName = certificateAuthorityName;
    }

    public bool CreateTrustedRootCertificate()
    {
        return (Authority = InstallCertificate(_rootStore, CertificateAuthorityName)) != null;
    }
    public bool DestroyTrustedRootCertificate()
    {
        return DestroyCertificates(_rootStore);
    }
    public bool ExportTrustedRootCertificate(string path)
    {
        X509Certificate2? rootCertificate = InstallCertificate(_rootStore, CertificateAuthorityName);

        path = Path.GetFullPath(path);
        if (rootCertificate != null)
        {
            byte[] data = rootCertificate.Export(X509ContentType.Cert);
            File.WriteAllBytes(path, data);
        }
        return File.Exists(path);
    }

    public X509Certificate2? GenerateCertificate(string certificateName)
    {
        return InstallCertificate(_myStore, certificateName);
    }
    public X509Certificate2 CreateCertificate(string subjectName, string alternateName)
    {
        using var rsa = RSA.Create(KeyLength);
        var certificateRequest = new CertificateRequest(subjectName, rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        if (Authority == null)
        {
            certificateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(true, false, 0, true));
            certificateRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(certificateRequest.PublicKey, false));

            using X509Certificate2 certificate = certificateRequest.CreateSelfSigned(NotBefore.ToUniversalTime(), NotAfter.ToUniversalTime());

            certificate.FriendlyName = alternateName;
            return new X509Certificate2(certificate.Export(X509ContentType.Pfx, string.Empty), string.Empty, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
        }
        else
        {
            var sanBuilder = new SubjectAlternativeNameBuilder();
            sanBuilder.AddDnsName(alternateName);

            certificateRequest.CertificateExtensions.Add(sanBuilder.Build());
            certificateRequest.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
            certificateRequest.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(certificateRequest.PublicKey, false));

            using X509Certificate2 certificate = certificateRequest.Create(Authority, Authority.NotBefore, Authority.NotAfter, Guid.NewGuid().ToByteArray());
            using X509Certificate2 certificateWithPrivateKey = certificate.CopyWithPrivateKey(rsa);

            certificateWithPrivateKey.FriendlyName = alternateName;
            return new X509Certificate2(certificateWithPrivateKey.Export(X509ContentType.Pfx, string.Empty), string.Empty, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet);
        }
    }
    private X509Certificate2? InstallCertificate(X509Store store, string certificateName)
    {
        if (_certificateCache.TryGetValue(certificateName, out X509Certificate2? certificate))
        {
            if (DateTime.Now >= certificate.NotAfter)
            {
                _certificateCache.Remove(certificateName);
            }
            else return certificate;
        }
        lock (store)
        {
            try
            {
                store.Open(OpenFlags.ReadWrite);
                string subjectName = $"CN={certificateName}, O={Issuer}";

                certificate = FindCertificates(store, subjectName)?[0];
                if (certificate != null && DateTime.Now >= certificate.NotAfter)
                {
                    if (Authority == null)
                    {
                        DestroyCertificates();
                        store.Open(OpenFlags.ReadWrite);
                    }
                    else
                    {
                        store.Remove(certificate);
                    }
                    certificate = null;
                }

                if (certificate == null)
                {
                    certificate = CreateCertificate(subjectName, certificateName);
                    if (certificate != null)
                    {
                        if (store == _rootStore || IsCachingSignedCertificates)
                        {
                            store.Add(certificate);
                        }
                    }
                }

                return certificate;
            }
            catch { return certificate = null; }
            finally
            {
                store.Close();
                if (certificate != null && !_certificateCache.ContainsKey(certificateName))
                {
                    _certificateCache.Add(certificateName, certificate);
                }
            }
        }
    }

    public bool DestroyCertificates(X509Store store)
    {
        lock (store)
        {
            try
            {
                store.Open(OpenFlags.ReadWrite);
                X509Certificate2Collection certificates = store.Certificates.Find(X509FindType.FindByIssuerName, Issuer, false);

                store.RemoveRange(certificates);
                IEnumerable<string> subjectNames = certificates.Cast<X509Certificate2>().Select(c => c.GetNameInfo(X509NameType.SimpleName, false));

                foreach (string subjectName in subjectNames)
                {
                    if (!_certificateCache.ContainsKey(subjectName)) continue;
                    _certificateCache.Remove(subjectName);
                }
                return true;
            }
            catch { return false; }
            finally { store.Close(); }
        }
    }
    public bool DestroyCertificates() => DestroyCertificates(_myStore) && DestroyCertificates(_rootStore);

    private static X509Certificate2Collection? FindCertificates(X509Store store, string subjectName)
    {
        X509Certificate2Collection certificates = store.Certificates
            .Find(X509FindType.FindBySubjectDistinguishedName, subjectName, false);

        return certificates.Count > 0 ? certificates : null;
    }

    public void Dispose()
    {
        _myStore.Close();
        _rootStore.Close();

        _myStore.Dispose();
        _rootStore.Dispose();
    }
}