using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;

namespace WPFTemplate.ViewModel.Controls;

public class CoverViewModel : ViewModelBase<CoverViewDemoModel>
{
    public CoverViewModel(DataService dataService) => DataList = dataService.GetCoverViewDemoDataList();
}
