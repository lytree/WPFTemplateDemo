using System;
using System.Windows;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Mvvm.DependencyInjection;
using WPFTemplate.Data;
using WPFTemplate.Service.Data;
using WPFTemplate.ViewModel.Basic;
using WPFTemplate.ViewModel.Common;
using WPFTemplate.ViewModel.Controls;
using WPFTemplate.ViewModel.Main;

namespace WPFTemplate.ViewModel;

public class ViewModelLocator
{
    private readonly IContainer _icContainer;
    public ViewModelLocator()
    {
        // Create your builder.
        var builder = new ContainerBuilder();
        builder.RegisterType<MainViewModel>().SingleInstance(); ;
        builder.RegisterType<DataService>();
        builder.Register((c) => new GrowlDemoViewModel()).Named<GrowlDemoViewModel>("GrowlDemo").SingleInstance();
        builder.Register((c) => new GrowlDemoViewModel(MessageToken.GrowlDemoPanel)).Named<GrowlDemoViewModel>("GrowlDemoWithToken").SingleInstance();
        builder.Register((c) => new ItemsDisplayViewModel(c.Resolve<DataService>().GetBlogDataList)).Named<ItemsDisplayViewModel>("Blogs").SingleInstance();
        builder.Register((c) => new ItemsDisplayViewModel(c.Resolve<DataService>().GetProjectDataList)).Named<ItemsDisplayViewModel>("Projects").SingleInstance();
        builder.Register((c) => new ItemsDisplayViewModel(c.Resolve<DataService>().GetWebsiteDataList)).Named<ItemsDisplayViewModel>("Websites").SingleInstance();
        builder.RegisterType<StepBarDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<PaginationDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<ChatBoxViewModel>().SingleInstance(); ;
        builder.RegisterType<CoverViewModel>().SingleInstance(); ;
        builder.RegisterType<DialogDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<NotifyIconDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<InteractiveDialogViewModel>().SingleInstance(); ;
        builder.RegisterType<BadgeDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<SideMenuDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<TabControlDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<NonClientAreaViewModel>().SingleInstance(); ;
        builder.RegisterType<CardDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<SpriteDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<NotificationDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<SplitButtonDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<TagDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<AutoCompleteTextBoxDemoViewModel>().SingleInstance(); ;
        builder.RegisterType<InputElementDemoViewModel>().SingleInstance(); ;
        _icContainer = builder.Build();
    }

    public static ViewModelLocator Instance = new Lazy<ViewModelLocator>(() =>
        Application.Current.TryFindResource("Locator") as ViewModelLocator).Value;

    #region Vm
    public MainViewModel Main => _icContainer.Resolve<MainViewModel>();

    public NonClientAreaViewModel NoUser => _icContainer.Resolve<NonClientAreaViewModel>();
    public ItemsDisplayViewModel ContributorsView => new(_icContainer.Resolve<DataService>().GetContributorDataList);

    public ItemsDisplayViewModel BlogsView => _icContainer.ResolveNamed<ItemsDisplayViewModel>("Blogs");

    public ItemsDisplayViewModel ProjectsView => _icContainer.ResolveNamed<ItemsDisplayViewModel>("Projects");

    public ItemsDisplayViewModel WebsitesView => _icContainer.ResolveNamed<ItemsDisplayViewModel>("Websites");


    public GrowlDemoViewModel GrowlDemo => _icContainer.ResolveNamed<GrowlDemoViewModel>("GrowlDemo");

    public GrowlDemoViewModel GrowlDemoWithToken => _icContainer.ResolveNamed<GrowlDemoViewModel>("GrowlDemoWithToken");

    public ImageBrowserDemoViewModel ImageBrowserDemo => _icContainer.Resolve<ImageBrowserDemoViewModel>();

    public WindowDemoViewModel WindowDemo => _icContainer.Resolve<WindowDemoViewModel>();

    public StepBarDemoViewModel StepBarDemo => _icContainer.Resolve<StepBarDemoViewModel>();

    public PaginationDemoViewModel PaginationDemo => _icContainer.Resolve<PaginationDemoViewModel>();

    public ChatBoxViewModel ChatBox => new();

    public CoverViewModel CoverView => _icContainer.Resolve<CoverViewModel>();

    public DialogDemoViewModel DialogDemo => _icContainer.Resolve<DialogDemoViewModel>();

    public NotifyIconDemoViewModel NotifyIconDemo => _icContainer.Resolve<NotifyIconDemoViewModel>();

    public InteractiveDialogViewModel InteractiveDialog => _icContainer.Resolve<InteractiveDialogViewModel>();

    public BadgeDemoViewModel BadgeDemo => _icContainer.Resolve<BadgeDemoViewModel>();

    public SideMenuDemoViewModel SideMenuDemo => _icContainer.Resolve<SideMenuDemoViewModel>();

    public TabControlDemoViewModel TabControlDemo => new(_icContainer.Resolve<DataService>());

    public CardDemoViewModel CardDemo => new(_icContainer.Resolve<DataService>());

    public SpriteDemoViewModel SpriteDemo => _icContainer.Resolve<SpriteDemoViewModel>();

    public NotificationDemoViewModel NotificationDemo => _icContainer.Resolve<NotificationDemoViewModel>();

    public SplitButtonDemoViewModel SplitButtonDemo => _icContainer.Resolve<SplitButtonDemoViewModel>();

    public TagDemoViewModel TagDemo => new(_icContainer.Resolve<DataService>());

    public AutoCompleteTextBoxDemoViewModel AutoCompleteTextBoxDemo => new(_icContainer.Resolve<DataService>());

    public InputElementDemoViewModel InputElementDemo => new();
    #endregion
}
