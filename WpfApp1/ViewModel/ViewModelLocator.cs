using System;
using System.Windows;
using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WPFTemplate.Service.Data;
using WPFTemplate.ViewModel.Basic;
using WPFTemplate.ViewModel.Common;
using WPFTemplate.ViewModel.Controls;
using WPFTemplate.ViewModel.Main;

namespace WPFTemplate.ViewModel;

public class ViewModelLocator
{
    public ViewModelLocator()
    {
        Ioc.Default.ConfigureServices(new ServiceCollection()
            .AddSingleton<DataService>()
            .AddSingleton<MainViewModel>()
            .AddTransient<DialogDemoViewModel>()
            .AddTransient<GrowlDemoViewModel>()
            .AddTransient<ItemsDisplayViewModel>()
            .AddTransient<WindowDemoViewModel>()
            .AddTransient<StepBarDemoViewModel>()
            .AddTransient<PaginationDemoViewModel>()
            .AddTransient<ChatBoxViewModel>()
            .AddTransient<CoverViewModel>()
            .AddTransient<NotifyIconDemoViewModel>()
            .AddTransient<InteractiveDialogViewModel>()
            .AddTransient<BadgeDemoViewModel>()
            .AddTransient<SideMenuDemoViewModel>()
            .AddTransient<TabControlDemoViewModel>()
            .AddTransient<NonClientAreaViewModel>()
            .AddTransient<CardDemoViewModel>()
            .AddTransient<SpriteDemoViewModel>()
            .AddTransient<NotificationDemoViewModel>()
            .AddTransient<SplitButtonDemoViewModel>()
            .AddTransient<TagDemoViewModel>()
            .AddTransient<AutoCompleteTextBoxDemoViewModel>()
            .AddTransient<InputElementDemoViewModel>()
            .AddTransient<ImageBrowserDemoViewModel>()
            .BuildServiceProvider());
    }

    public static ViewModelLocator Instance = new Lazy<ViewModelLocator>(() =>
        Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;

    #region Vm
    public MainViewModel Main => Ioc.Default.GetRequiredService<MainViewModel>();

    public NonClientAreaViewModel NoUser => Ioc.Default.GetRequiredService<NonClientAreaViewModel>();
    #endregion
}
