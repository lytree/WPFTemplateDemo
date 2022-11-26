using System.Windows;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;
using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;

namespace WPFTemplate.ViewModel.Controls;

public class TabControlDemoViewModel : ViewModelBase<TabControlDemoModel>
{
    public TabControlDemoViewModel(DataService dataService) => DataList = dataService.GetTabControlDemoDataList();

    public RelayCommand<CancelRoutedEventArgs> ClosingCmd => new(Closing);

    private void Closing(CancelRoutedEventArgs args)
    {
        Growl.Info($"{(args.OriginalSource as TabItem)?.Header} Closing");
    }

    public RelayCommand<RoutedEventArgs> ClosedCmd => new(Closed);

    private void Closed(RoutedEventArgs args)
    {
        Growl.Info($"{(args.OriginalSource as TabItem)?.Header} Closed");
    }
}
