using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;

namespace WPFTemplate.ViewModel.Controls;

public class SideMenuDemoViewModel : ObservableRecipient
{
    public RelayCommand<FunctionEventArgs<object>> SwitchItemCmd => new(SwitchItem!);

    private void SwitchItem(FunctionEventArgs<object> info) => Growl.Info((info.Info as SideMenuItem)?.Header.ToString());

    public RelayCommand<string> SelectCmd => new(Select!);

    private void Select(string header) => Growl.Success(header);
}
