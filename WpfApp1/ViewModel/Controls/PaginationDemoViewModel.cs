using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Data;
using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;

namespace WPFTemplate.ViewModel.Controls;

public class PaginationDemoViewModel : ViewModelBase<ViewsDataModel>
{
    /// <summary>
    ///     所有数据
    /// </summary>
    private readonly List<ViewsDataModel> _totalDataList;

    /// <summary>
    ///     页码
    /// </summary>
    private int _pageIndex = 1;

    /// <summary>
    ///     页码
    /// </summary>
    public int PageIndex
    {
        get => _pageIndex;

        set => SetProperty(ref _pageIndex, value);
    }

    public PaginationDemoViewModel(DataService dataService)
    {
        _totalDataList = dataService.GetDemoDataList(100);
        DataList = _totalDataList.Take(10).ToList();
    }

    /// <summary>
    ///     页码改变命令
    /// </summary>
    public RelayCommand<FunctionEventArgs<int>> PageUpdatedCmd => new(PageUpdated);

    /// <summary>
    ///     页码改变
    /// </summary>
    private void PageUpdated(FunctionEventArgs<int> info)
    {
        DataList = _totalDataList.Skip((info.Info - 1) * 10).Take(10).ToList();
    }
}
