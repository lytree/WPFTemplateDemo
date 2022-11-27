using System;
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

    public RelayCommand<string> OpenViewCmd => new(execute: OpenView);

    private void OpenView(string? viewName)
    {
        Console.WriteLine(viewName);
        Messenger.Send(new MessageToken.ClearLeftSelected(null), nameof(MessageToken.ClearLeftSelected));
        Messenger.Send(new MessageToken.FullSwitch(true), nameof(MessageToken.FullSwitch));
       object obj =  AssemblyHelper.CreateInternalInstance($"UserControl.{viewName}");
        Messenger.Send(new MessageToken.LoadShowContent(obj), nameof(MessageToken.LoadShowContent));
    }

    private string _versionInfo;

    public string VersionInfo
    {
        get => _versionInfo;

        set => SetProperty(ref _versionInfo, value);
    }
}
