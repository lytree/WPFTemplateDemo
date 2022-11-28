using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFTemplate.ViewModel;

public class ViewModelBase<T> : ObservableRecipient
{
    /// <summary>
    ///     数据列表
    /// </summary>
    private IList<T>? _dataList;

    /// <summary>
    ///     数据列表
    /// </summary>
    public IList<T> DataList
    {
        get => _dataList;

        set => SetProperty(ref _dataList, value);

    }
}
