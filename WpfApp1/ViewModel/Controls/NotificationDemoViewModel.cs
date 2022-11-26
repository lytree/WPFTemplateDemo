using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;
using WPFTemplate.UserControl.Main;

namespace WPFTemplate.ViewModel.Controls;

public class NotificationDemoViewModel : ObservableRecipient
{
    public RelayCommand OpenCmd => new(() => Notification.Show(new AppNotification(), ShowAnimation, StaysOpen));

    private ShowAnimation _showAnimation;

    public ShowAnimation ShowAnimation
    {
        get => _showAnimation;

        set => SetProperty(ref _showAnimation, value);

    }

    private bool _staysOpen = true;

    public bool StaysOpen
    {
        get => _staysOpen;

        set => SetProperty(ref _staysOpen, value);

    }
}
