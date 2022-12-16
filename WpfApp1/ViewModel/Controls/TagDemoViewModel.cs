using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Properties.Langs;
using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;

namespace WPFTemplate.ViewModel.Controls;

public class TagDemoViewModel : ObservableRecipient
{
    public TagDemoViewModel(DataService dataService)
    {
        DataList = new ObservableCollection<ViewsDataModel>(dataService.GetDemoDataList(10));
    }

    public ObservableCollection<ViewsDataModel> DataList { get; set; }

    private string _tagName;

    public string TagName
    {
        get => _tagName;

        set => SetProperty(ref _tagName, value);
    }

    public RelayCommand AddItemCmd => new(() =>
    {
        if (string.IsNullOrEmpty(TagName))
        {
            Growl.Warning("请输入内容");
            return;
        }

        DataList.Insert(0, new ViewsDataModel
        {
            IsSelected = DataList.Count % 2 == 0,
            Name = TagName
        });
        TagName = string.Empty;
    });
}
