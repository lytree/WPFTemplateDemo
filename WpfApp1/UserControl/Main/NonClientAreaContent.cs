using System.Globalization;
using System.Windows;
using System.Windows.Controls;
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

    private void ButtonLangs_OnClick(object sender, RoutedEventArgs e)
    {
        if (e.OriginalSource is Button { Tag: string langName })
        {
            PopupConfig.IsOpen = false;
            // Messenger.Default.Send<object>(null, MessageToken.LangUpdated);

            GlobalData.Config.Lang = langName;
            GlobalData.Save();
        }
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
            // ((App) Application.Current).UpdateSkin(tag);
            // Messengers.Default.Send(tag, MessageToken.SkinUpdated);
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
