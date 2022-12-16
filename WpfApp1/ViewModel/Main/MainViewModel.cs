using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Controls;
using HandyControl.Interactivity;
using HandyControl.Properties.Langs;
using WPFTemplate.Data;
using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;
using WPFTemplate.Tools.Helper;
using WPFTemplate.UserControl.Basic;
using static WPFTemplate.Data.MessageToken;

namespace WPFTemplate.ViewModel.Main;

public class MainViewModel : ViewModelBase<ViewsDataModel>
{
    private object _contentTitle;
    private object _subContent;

    private readonly DataService _dataService;

    public MainViewModel(DataService dataService)
    {
        _dataService = dataService;
        UpdateMainContent();
        UpdateLeftContent();
    }

    public ContentItemModel ContentItemCurrent { get; private set; }

    public ContextInfoModel ContextInfoCurrent { get; set; }

    public object SubContent
    {
        get => _subContent;

        set => SetProperty(ref _subContent, value);

    }

    public object ContentTitle
    {
        get => _contentTitle;

        set => SetProperty(ref _contentTitle, value);

    }

    public ObservableCollection<ContextInfoModel> DemoInfoCollection { get; set; }

    public RelayCommand<SelectionChangedEventArgs> SwitchDemoCmd => new(SwitchContent);

    public RelayCommand OpenPracticalDemoCmd => new(OpenPracticalDemo);

    public RelayCommand GlobalShortcutInfoCmd => new(() => Growl.Info("Global Shortcut Info"));

    public RelayCommand GlobalShortcutWarningCmd => new(() => Growl.Warning("Global Shortcut Warning"));

    private void UpdateMainContent()
    {
        Messenger.Register<MainViewModel, LoadShowContent, string>(this, nameof(LoadShowContent), (r, obj) =>
        {
            if (SubContent is IDisposable disposable)
            {
                disposable.Dispose();
            }
            SubContent = obj.Obj;
        });
    }

    private void UpdateLeftContent()
    {
        //clear status
        Messenger.Register<MainViewModel, LoadShowContent, string>(this, nameof(ClearLeftSelected), (r, obj) =>
        {
            ContentItemCurrent = null;
            foreach (var item in DemoInfoCollection)
            {
                item.SelectedIndex = 0;
            }
        });

        //load items
        DemoInfoCollection = new ObservableCollection<ContextInfoModel>();
        Task.Run(() =>
        {
            DataList = _dataService.GetDemoDataList();

            foreach (var item in _dataService.GetDemoInfo())
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    DemoInfoCollection.Add(item);
                }), DispatcherPriority.ApplicationIdle);
            }
        });
    }

    private void SwitchContent(SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 0) return;
        if (e.AddedItems[0] is ContentItemModel item)
        {
            if (Equals(ContentItemCurrent, item)) return;
            SwitchContent(item);
        }
    }

    private void SwitchContent(ContentItemModel item)
    {
        ContentItemCurrent = item;
        ContentTitle = item.Name;
        var obj = AssemblyHelper.ResolveByKey(item.TargetCtlName);
        var ctl = obj ?? AssemblyHelper.CreateInternalInstance($"UserControl.{item.TargetCtlName}");
        Messenger.Send(new MessageToken.FullSwitch(true), nameof(MessageToken.FullSwitch));
        Messenger.Send(new MessageToken.LoadShowContent(obj), nameof(MessageToken.LoadShowContent));
    }

    private void OpenPracticalDemo()
    {
        Messenger.Send(new MessageToken.ClearLeftSelected(null), nameof(MessageToken.ClearLeftSelected));
        Messenger.Send(new MessageToken.FullSwitch(true), nameof(MessageToken.FullSwitch));
        object obj = AssemblyHelper.CreateInternalInstance($"UserControl.{MessageToken.PracticalDemo}");
        Messenger.Send(new MessageToken.LoadShowContent(obj), nameof(MessageToken.LoadShowContent));
    }
}
