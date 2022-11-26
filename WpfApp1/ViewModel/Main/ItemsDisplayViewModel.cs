using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPFTemplate.Data.Model;

namespace WPFTemplate.ViewModel.Main;

public class ItemsDisplayViewModel : ViewModelBase<AvatarModel>
{
    public ItemsDisplayViewModel(Func<List<AvatarModel>> getDataAction)
    {

        Task.Run(() => DataList = getDataAction.Invoke()).ContinueWith(obj => DataGot = true);

    }

    private bool _dataGot;

    public bool DataGot
    {
        get => _dataGot;

        set => SetProperty(ref _dataGot, value);

    }
}
