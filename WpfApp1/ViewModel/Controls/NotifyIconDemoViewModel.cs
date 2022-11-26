using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;
using WPFTemplate.Data;

namespace WPFTemplate.ViewModel.Controls;

public class NotifyIconDemoViewModel : ObservableRecipient
{
    private bool _isCleanup;

    private bool _reversed;

    private string _content = "Hello~~~";

    public string Content
    {
        get => _content;

        set => SetProperty(ref _content, value);

    }

    private bool _contextMenuIsShow;

    public bool ContextMenuIsShow
    {
        get => _contextMenuIsShow;
        set
        {

            SetProperty(ref _contextMenuIsShow, value);

            GlobalData.NotifyIconIsShow = ContextMenuIsShow || ContextContentIsShow;
            if (!_isCleanup && !_reversed)
            {
                _reversed = true;
                ContextContentIsShow = !value;
                _reversed = false;
            }
        }
    }

    private bool _contextMenuIsBlink;

    public bool ContextMenuIsBlink
    {
        get => _contextMenuIsBlink;

        set => SetProperty(ref _contextMenuIsBlink, value);

    }

    private bool _contextContentIsShow;

    public bool ContextContentIsShow
    {
        get => _contextContentIsShow;
        set
        {

            SetProperty(ref _contextContentIsShow, value);

            GlobalData.NotifyIconIsShow = ContextMenuIsShow || ContextContentIsShow;
            if (!_isCleanup && !_reversed)
            {
                _reversed = true;
                ContextMenuIsShow = !value;
                _reversed = false;
            }
        }
    }

    private bool _contextContentIsBlink;

    public bool ContextContentIsBlink
    {
        get => _contextContentIsBlink;

        set => SetProperty(ref _contextContentIsBlink, value);

    }

    public RelayCommand<object> MouseCmd => new(str => Growl.Info(str.ToString()));

    public RelayCommand SendNotificationCmd => new(SendNotification);

    private void SendNotification()
    {
        NotifyIcon.ShowBalloonTip("HandyControl", Content, NotifyIconInfoType.None, ContextMenuIsShow ? MessageToken.NotifyIconDemo : MessageToken.NotifyIconContextDemo);
    }

    protected override void OnDeactivated()
    {
        base.OnDeactivated(); ;

        _isCleanup = true;
        ContextMenuIsShow = false;
        ContextMenuIsBlink = false;
        ContextContentIsShow = false;
        ContextContentIsBlink = false;
        GlobalData.NotifyIconIsShow = false;
        _isCleanup = false;
    }
}
