using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Themes;
using HandyControl.Tools;
using HandyControl.Tools.Extension;
using ICSharpCode.AvalonEdit;
using WPFTemplate.Data;
using WPFTemplate.Tools;
using WPFTemplate.Tools.Helper;
using WPFTemplate.ViewModel;

namespace WPFTemplate.UserControl.Main;

/// <summary>
///     主内容
/// </summary>
public partial class MainContent
{
    private bool _isFull;

    private string _currentDemoKey;

    private bool _drawerCodeUsed;

    private Dictionary<string, TextEditor> _textEditor;

    public MainContent()
    {
        InitializeComponent();
        //
        WeakReferenceMessenger.Default.Register<MainContent, MessageToken.FullSwitch, string>(this, nameof(MessageToken.FullSwitch), (r, m) => this.FullSwitch(m.IsFull));
    }

    private void FullSwitch(bool isFull)
    {
        if (_isFull == isFull)
        {
            return;
        }

        _isFull = isFull;

        if (_isFull)
        {
            BorderRootEffect.Show();
            BorderEffect.Collapse();
            BorderTitle.Collapse();
            GridMain.HorizontalAlignment = HorizontalAlignment.Stretch;
            GridMain.VerticalAlignment = VerticalAlignment.Stretch;
            PresenterMain.Margin = new Thickness();
            BorderRoot.CornerRadius = new CornerRadius(10);
            BorderRoot.Style = ResourceHelper.GetResource<Style>("BorderClip");
        }
        else
        {
            BorderRootEffect.Collapse();
            BorderEffect.Show();
            BorderTitle.Show();
            GridMain.HorizontalAlignment = HorizontalAlignment.Center;
            GridMain.VerticalAlignment = VerticalAlignment.Center;
            PresenterMain.Margin = new Thickness(0, 0, 0, 10);
            BorderRoot.CornerRadius = new CornerRadius();
            BorderRoot.Style = null;
        }
    }
}
