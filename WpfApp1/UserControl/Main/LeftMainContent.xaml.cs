using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Data;
using HandyControl.Tools;
using WPFTemplate.Data.Model;
using WPFTemplate.ViewModel;

namespace WPFTemplate.UserControl.Main;

/// <summary>
///     左侧主内容
/// </summary>
public partial class LeftMainContent
{
    private string _searchKey;

    public LeftMainContent()
    {
        InitializeComponent();
    }

    private void TabControl_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 0) return;
        if (e.AddedItems[0] is ContextInfoModel demoInfo)
        {
            ViewModelLocator.Instance.Main.ContextInfoCurrent = demoInfo;
            var selectedIndex = demoInfo.SelectedIndex;
            demoInfo.SelectedIndex = -1;
            demoInfo.SelectedIndex = selectedIndex;

            FilterItems();
            GroupItems(sender as TabControl, demoInfo);
        }
    }
    private void FilterItems()
    {
        if (string.IsNullOrEmpty(_searchKey))
        {
            foreach (var item in ViewModelLocator.Instance.Main.ContextInfoCurrent.ContextItemList)
            {
                item.IsVisible = true;
                item.QueriesText = string.Empty;
            }
        }
        else
        {
            var key = _searchKey.ToLower();
            foreach (var item in ViewModelLocator.Instance.Main.ContextInfoCurrent.ContextItemList)
            {
                if (item.Name != null && item.Name.ToLower().Contains(key))
                {
                    item.IsVisible = true;
                    item.QueriesText = _searchKey;
                }
                else if (item.TargetCtlName != null && item.TargetCtlName.Replace("DemoCtl", "").ToLower().Contains(key))
                {
                    item.IsVisible = true;
                    item.QueriesText = _searchKey;
                }
                else
                {
                    item.IsVisible = true;
                    item.QueriesText = _searchKey;
                }
            }
        }
    }

    private void GroupItems(TabControl tabControl, ContextInfoModel contextInfo)
    {
        var listBox = VisualHelper.GetChild<ListBox>(tabControl);
        if (listBox == null) return;
        listBox.Items.GroupDescriptions?.Clear();

        if (contextInfo.IsGroupEnabled)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                listBox.Items.GroupDescriptions?.Add(new PropertyGroupDescription("GroupName"));
            }), DispatcherPriority.Background);
        }
    }
}
