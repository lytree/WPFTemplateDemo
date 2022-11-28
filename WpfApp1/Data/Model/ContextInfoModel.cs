using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace WPFTemplate.Data.Model;

public class ContextInfoModel : ObservableRecipient
{
    public string? Key { get; set; }

    private string? _title;

    public string? Title
    {
        get => _title;

        set => SetProperty(ref _title, value);

    }

    private int _selectedIndex;

    public int SelectedIndex
    {
        get => _selectedIndex;

        set => SetProperty(ref _selectedIndex, value);
  
    }

    public bool IsGroupEnabled { get; set; }

    public IList<ContentItemModel>? ContextItemList { get; set; }
}
