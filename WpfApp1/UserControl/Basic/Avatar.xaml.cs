﻿using System.Windows;
using System.Windows.Media.Imaging;

namespace WPFTemplate.UserControl.Basic;

public partial class Avatar
{
    public Avatar()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty SourceProperty = DependencyProperty.Register(
        nameof(Source), typeof(BitmapFrame), typeof(Avatar), new PropertyMetadata(default(BitmapFrame)));

    public BitmapFrame Source
    {
        get => (BitmapFrame) GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public static readonly DependencyProperty UserNameProperty = DependencyProperty.Register(
        nameof(DisplayName), typeof(string), typeof(Avatar), new PropertyMetadata(default(string)));

    public string DisplayName
    {
        get => (string) GetValue(UserNameProperty);
        set => SetValue(UserNameProperty, value);
    }

    public static readonly DependencyProperty LinkProperty = DependencyProperty.Register(
        nameof(Link), typeof(string), typeof(Avatar), new PropertyMetadata(default(string)));

    public string Link
    {
        get => (string) GetValue(LinkProperty);
        set => SetValue(LinkProperty, value);
    }
}