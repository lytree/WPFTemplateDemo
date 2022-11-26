using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using HandyControl.Collections;
using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;

namespace WPFTemplate.ViewModel.Controls;

public class AutoCompleteTextBoxDemoViewModel : ObservableRecipient
{
    private string _searchText;

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            FilterItems(value);
        }
    }

    public ManualObservableCollection<DemoDataModel> Items { get; set; } = new();

    private readonly List<DemoDataModel> _dataList;

    public AutoCompleteTextBoxDemoViewModel(DataService dataService)
    {
        _dataList = dataService.GetDemoDataList(10);
    }

    private void FilterItems(string key)
    {
        Items.CanNotify = false;

        Items.Clear();

        foreach (var data in _dataList)
        {
            if (data.Name.ToLower().Contains(key.ToLower()))
            {
                Items.Add(data);
            }
        }

        Items.CanNotify = true;
    }
}
