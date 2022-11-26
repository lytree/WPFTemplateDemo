using System.Linq;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using WPFTemplate.Data.Model;
using WPFTemplate.Service.Data;

namespace WPFTemplate.ViewModel.Controls;

public class StepBarDemoViewModel : ViewModelBase<StepBarDemoModel>
{
    public StepBarDemoViewModel(DataService dataService) => DataList = dataService.GetStepBarDemoDataList();

    private int _stepIndex;

    public int StepIndex
    {
        get => _stepIndex;

        set => SetProperty(ref _stepIndex, value);

    }

    /// <summary>
    ///     下一步
    /// </summary>
    public RelayCommand<Panel> NextCmd => new(Next);

    /// <summary>
    ///     上一步
    /// </summary>
    public RelayCommand<Panel> PrevCmd => new(Prev);

    private void Next(Panel panel)
    {
        foreach (var stepBar in panel.Children.OfType<StepBar>())
        {
            stepBar.Next();
        }
    }

    private void Prev(Panel panel)
    {
        foreach (var stepBar in panel.Children.OfType<StepBar>())
        {
            stepBar.Prev();
        }
    }
}
