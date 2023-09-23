using System;

namespace Eavesdrop
{
    [Flags]
    public enum Interceptors
    {
        None = 0,
        HTTP = 1,
        HTTPS = 2,

        Default = (HTTP | HTTPS)
    }
}