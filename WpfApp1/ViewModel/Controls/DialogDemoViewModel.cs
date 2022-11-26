using System.Threading.Tasks;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Tools.Extension;
using WPFTemplate.Data;
using WPFTemplate.UserControl.Basic;
using WPFTemplate.ViewModel.Basic;
using WPFTemplate.Window;

namespace WPFTemplate.ViewModel.Controls;

public class DialogDemoViewModel : ObservableRecipient
{
    private string _dialogResult;

    public string DialogResult
    {
        get => _dialogResult;

        set => SetProperty(ref _dialogResult, value);

    }

    public RelayCommand<FrameworkElement> ShowTextCmd => new(ShowText);

    private void ShowText(FrameworkElement element)
    {
        if (element == null)
        {
            Dialog.Show(new TextDialog());
        }
        else
        {
            Dialog.Show(new TextDialog(), MessageToken.DialogContainer);
        }
    }

    public RelayCommand<bool> ShowInteractiveDialogCmd => new(async withTimer => await ShowInteractiveDialog(withTimer));

    private async Task ShowInteractiveDialog(bool withTimer)
    {
        if (!withTimer)
        {
            DialogResult = await Dialog.Show<InteractiveDialog>()
                .Initialize<InteractiveDialogViewModel>(vm => vm.Message = DialogResult)
                .GetResultAsync<string>();
        }
        else
        {
            await Dialog.Show<TextDialogWithTimer>(MessageToken.MainWindow).GetResultAsync<string>();
        }
    }

    public RelayCommand NewWindowCmd => new(() => new DialogDemoWindow
    {
        Owner = Application.Current.MainWindow
    }.Show());

    public RelayCommand<string> ShowWithTokenCmd => new(token => Dialog.Show(new TextDialog(), token));
}
