using System;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;

namespace WPFTemplate.ViewModel.Controls;

public class ImageBrowserDemoViewModel
{
    public RelayCommand OpenImgCmd => new(() =>
        new ImageBrowser(new Uri("pack://application:,,,/Resources/Img/1.jpg")).Show());
}
