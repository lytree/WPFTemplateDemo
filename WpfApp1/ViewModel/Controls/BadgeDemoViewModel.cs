using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WPFTemplate.ViewModel.Controls;

public class BadgeDemoViewModel : ObservableRecipient
{
    private int _count = 1;

    public int Count
    {
        get => _count;

        set => SetProperty(ref _count, value);

    }

    public RelayCommand CountCmd => new(() => Count++);
}
