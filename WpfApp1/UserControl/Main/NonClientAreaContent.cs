using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Themes;
using HandyControl.Tools;
using WPFTemplate.Data;
using WPFTemplate.Window;

namespace WPFTemplate.UserControl.Main;

public partial class NonClientAreaContent
{
    public NonClientAreaContent()
    {
        InitializeComponent();
    }

    private void ButtonConfig_OnClick(object sender, RoutedEventArgs e) => PopupConfig.IsOpen = true;

    private void ButtonSkins_OnClick(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource is Button button && button.Tag is ApplicationTheme tag)
        {
            PopupConfig.IsOpen = false;
            if (tag.Equals(GlobalData.Config.Theme)) return;
            GlobalData.Config.Theme = tag;
            GlobalData.Save();
            ((App)Application.Current).UpdateSkin(tag);
            WeakReferenceMessenger.Default.Send(new MessageToken.SkinUpdated(tag), nameof(MessageToken.SkinUpdated));
        }
    }

    private void MenuAbout_OnClick(object sender, RoutedEventArgs e)
    {
        new AboutWindow
        {
            Owner = Application.Current.MainWindow
        }.ShowDialog();
    }
}
