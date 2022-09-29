﻿using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

using Microsoft.Win32;

namespace GrasscutterTools.Pages
{
    /// <summary>
    /// PageHome.xaml 的交互逻辑
    /// </summary>
    public partial class PageTools : Page
    {
        public PageTools()
        {
            InitializeComponent();
        }

        private void BtnIdMergeTool_Click(object sender, RoutedEventArgs e)
        {
            var src = new OpenFileDialog
            {
                Title = "请选择原文件",
                Multiselect = false,
            };
            var dest = new OpenFileDialog
            {
                Title = "请选择目标文件",
                Multiselect = false,
            };

            if (src.ShowDialog() == true && dest.ShowDialog() == true)
            {
                var srcLines = File.ReadAllLines(src.FileName);
                var srcDic = new Dictionary<string, string>(srcLines.Length);
                foreach (var line in srcLines)
                {
                    var sp = line.IndexOf(':');
                    if (sp > 0)
                    {
                        var value = line.Substring(sp + 1).Trim();
                        if (!value.StartsWith("[N/A]"))
                            srcDic[line.Substring(0, sp).Trim()] = line.Substring(sp+1).Trim();
                    }
                }

                var destLines = File.ReadAllLines(dest.FileName);
                using (var outStream = File.Create(dest.FileName))
                using (var outTxtStream = new StreamWriter(outStream))
                {
                    foreach (var line in destLines)
                    {
                        var sp = line.IndexOf(':');
                        if (sp == -1)
                        {
                            outTxtStream.WriteLine(line);
                        }
                        else
                        {
                            var key = line.Substring(0, sp).Trim();
                            if (!srcDic.TryGetValue(key, out var value))
                                value = line.Substring(sp + 1).Trim();
                            outTxtStream.WriteLine($"{key}:{value}");
                        }
                    }
                }
            }
        }
    }
}
