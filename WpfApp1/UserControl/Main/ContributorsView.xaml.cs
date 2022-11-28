
using CommunityToolkit.Mvvm.DependencyInjection;
using WPFTemplate.Service.Data;
using WPFTemplate.ViewModel;
using WPFTemplate.ViewModel.Main;

namespace WPFTemplate.UserControl;

public partial class ContributorsView
{
    public ContributorsView()
    {
        InitializeComponent();

        this.DataContext = new ItemsDisplayViewModel(Ioc.Default.GetService<DataService>().GetContributorDataList);
    }
}
