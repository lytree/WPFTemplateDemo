using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Controls;
using HandyControl.Tools;
using WPFTemplate.Data;
using WPFTemplate.Tools.Helper;
using WPFTemplate.UserControl.Main;
using WPFTemplate.ViewModel;
using WPFTemplate.ViewModel.Main;

namespace WPFTemplate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);

            DataContext = ViewModelLocator.Instance.Main;
            NonClientAreaContent = new NonClientAreaContent();
            ControlMain.Content = new MainWindowContent();

            GlobalShortcut.Init(new List<KeyBinding>
            {
                new(ViewModel.GlobalShortcutInfoCmd, Key.I, ModifierKeys.Control | ModifierKeys.Alt),
                new(ViewModel.GlobalShortcutWarningCmd, Key.E, ModifierKeys.Control | ModifierKeys.Alt),
            });

            Dialog.SetToken(this, MessageToken.MainWindow);
            WindowAttach.SetIgnoreAltF4(this, true);

            WeakReferenceMessenger.Default.Send(new MessageToken.FullSwitch(true), nameof(MessageToken.FullSwitch));
            WeakReferenceMessenger.Default.Send(new MessageToken.LoadShowContent(AssemblyHelper.CreateInternalInstance($"UserControl.{MessageToken.PracticalDemo}")), nameof(MessageToken.LoadShowContent));
        }
        public MainViewModel ViewModel => (MainViewModel)DataContext;

        protected override void OnClosing(CancelEventArgs e)
        {
            if (GlobalData.NotifyIconIsShow)
            {
                Hide();
                e.Cancel = true;
            }
            else
            {
                base.OnClosing(e);
            }
        }
    }
}
