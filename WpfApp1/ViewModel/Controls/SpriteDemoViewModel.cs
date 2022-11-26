using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using WPFTemplate.UserControl.Main;

namespace WPFTemplate.ViewModel.Controls;

public class SpriteDemoViewModel
{
    public RelayCommand OpenCmd => new(() => Sprite.Show(new AppSprite()));
}
