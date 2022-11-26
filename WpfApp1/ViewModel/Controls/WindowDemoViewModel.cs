using System.Windows;
using CommunityToolkit.Mvvm.Input;
using WPFTemplate.Tools.Helper;

namespace WPFTemplate.ViewModel.Controls;

public class WindowDemoViewModel
{
    public RelayCommand<string> OpenWindowCmd => new(execute: OpenWindow);

    private void OpenWindow(string windowTag)
    {
        if (AssemblyHelper.CreateInternalInstance($"Window.{windowTag}") is System.Windows.Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }
    }
}
