﻿using System.Windows;
using WPFTemplate.Tools.Helper;

namespace WPFTemplate.Window;

public partial class AboutWindow
{
    public AboutWindow()
    {
        InitializeComponent();

        DataContext = this;
        CopyRight = VersionHelper.GetCopyright();
        Version = VersionHelper.GetVersion();
    }

    public static readonly DependencyProperty CopyRightProperty = DependencyProperty.Register(
        nameof(CopyRight), typeof(string), typeof(AboutWindow), new PropertyMetadata(default(string)));

    public string CopyRight
    {
        get => (string) GetValue(CopyRightProperty);
        set => SetValue(CopyRightProperty, value);
    }

    public static readonly DependencyProperty VersionProperty = DependencyProperty.Register(
        nameof(Version), typeof(string), typeof(AboutWindow), new PropertyMetadata(default(string)));

    public string Version
    {
        get => (string) GetValue(VersionProperty);
        set => SetValue(VersionProperty, value);
    }
}
