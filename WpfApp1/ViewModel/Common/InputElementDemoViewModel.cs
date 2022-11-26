using System.Collections.Generic;
using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using WPFTemplate.Tools.Converter;

namespace WPFTemplate.ViewModel.Common;

public class InputElementDemoViewModel : ObservableRecipient
{
    private string _email1;
    private string _email2;
    private double _doubleValue1;
    private double _doubleValue2;
    private IList<string> _dataList;

    public string Email1
    {
        get => _email1;
        set => SetProperty(ref _email1, value);

    }

    public string Email2
    {
        get => _email2;

        set => SetProperty(ref _email2, value);
    }

    public double DoubleValue1
    {
        get => _doubleValue1;

        set => SetProperty(ref _doubleValue1, value);
    }

    public double DoubleValue2
    {
        get => _doubleValue2;

        set => SetProperty(ref _doubleValue2, value);

    }

    public IList<string> DataList
    {
        get => _dataList;

        set => SetProperty(ref _dataList, value);
    }

    public RelayCommand<string> SearchCmd => new(Search!);

    public InputElementDemoViewModel()
    {
        DataList = GetComboBoxDemoDataList();
    }

    private static void Search(string key)
    {
        Growl.Info(key);
    }

    private List<string> GetComboBoxDemoDataList()
    {
        var converter = new StringRepeatConverter();
        var list = new List<string>();
        for (var i = 1; i <= 9; i++)
        {
            list.Add($"{converter.Convert("正文", null, i, CultureInfo.CurrentCulture)}{i}");
        }

        return list;
    }
}
