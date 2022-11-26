using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using WPFTemplate.Data;
using WPFTemplate.Tools.Helper;

namespace WPFTemplate.ViewModel.Main;

public class NonClientAreaViewModel : ObservableRecipient
{
    public NonClientAreaViewModel()
    {
        VersionInfo = VersionHelper.GetVersion();
    }

    public RelayCommand<string> OpenViewCmd => new(OpenView);

    private void OpenView(string viewName)
    {
        // Messenger.Send<string>(null, MessageToken.ClearLeftSelected);
        // Messenger.Send(true, MessageToken.FullSwitch);
        Messenger.Send(AssemblyHelper.CreateInternalInstance($"UserControl.{viewName}"), MessageToken.LoadShowContent);
    }

    private string _versionInfo;

    public string VersionInfo
    {
        get => _versionInfo;

        set => SetProperty(ref _versionInfo, value);
    }
}
