using CommunityToolkit.Mvvm.Input;
using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;

namespace WPFTemplate.ViewModel.Controls;

public class CardDemoViewModel : ViewModelBase<CardModel>
{
    private readonly DataService _dataService;

    public CardDemoViewModel(DataService dataService)
    {
        _dataService = dataService;
        DataList = dataService.GetCardDataList();
    }

    public RelayCommand AddItemCmd => new(() => DataList.Insert(0, _dataService.GetCardData()));

    public RelayCommand RemoveItemCmd => new(() =>
    {
        if (DataList.Count > 0)
        {
            DataList.RemoveAt(0);
        }
    });
}
