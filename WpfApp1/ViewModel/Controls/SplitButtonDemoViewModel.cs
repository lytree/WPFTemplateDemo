using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;

namespace WPFTemplate.ViewModel.Controls;

public class SplitButtonDemoViewModel : ObservableRecipient
{
    public RelayCommand<string> SelectCmd => new(str => Growl.Info(str));
}
