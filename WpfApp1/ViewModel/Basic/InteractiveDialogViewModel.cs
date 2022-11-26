using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Tools.Extension;

namespace WPFTemplate.ViewModel.Basic;

public class InteractiveDialogViewModel : ObservableRecipient, IDialogResultable<string>
{
    public Action CloseAction { get; set; }

    private string _result;

    public string Result
    {
        get => _result;

        set => SetProperty(ref _result, value);

    }

    private string _message;

    public string Message
    {
        get => _message;
#if NET40
        set => Set(nameof(Message), ref _message, value);
#else
        set => SetProperty(ref _message, value);
#endif
    }

    public RelayCommand CloseCmd => new(() => CloseAction?.Invoke());
}
