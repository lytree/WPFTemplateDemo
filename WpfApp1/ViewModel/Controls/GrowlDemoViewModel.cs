using System.Windows;
using CommunityToolkit.Mvvm.Input;
using HandyControl.Controls;
using HandyControl.Data;
using WPFTemplate.Window;

namespace WPFTemplate.ViewModel.Controls;

public class GrowlDemoViewModel
{
    private readonly string _token;

    public GrowlDemoViewModel()
    {
        _token = "";
    }

    public GrowlDemoViewModel(string token)
    {
        _token = token;
    }

    #region Window

    public RelayCommand InfoCmd => new(() => Growl.Info("今天的天气不错~~~", _token));

    public RelayCommand SuccessCmd => new(() => Growl.Success("文件保存成功！", _token));

    public RelayCommand WarningCmd => new(() => Growl.Warning(new GrowlInfo
    {
        Message = "磁盘空间快要满了！",
        CancelStr = "忽略",
        ActionBeforeClose = isConfirmed =>
        {
            Growl.Info(isConfirmed.ToString());
            return true;
        },
        Token = _token
    }));

    public RelayCommand ErrorCmd => new(() => Growl.Error("连接失败，请检查网络！", _token));

    public RelayCommand AskCmd => new(() => Growl.Ask("检测到有新版本！是否更新？", isConfirmed =>
    {
        Growl.Info(isConfirmed.ToString());
        return true;
    }, _token));

    public RelayCommand FatalCmd => new(() => Growl.Fatal(new GrowlInfo
    {
        Message = "程序已崩溃~~~",
        ShowDateTime = false,
        Token = _token
    }));

    public RelayCommand ClearCmd => new(() => Growl.Clear(_token));

    #endregion

    #region Desktop

    public RelayCommand InfoGlobalCmd => new(() => Growl.InfoGlobal("今天的天气不错~~~"));

    public RelayCommand SuccessGlobalCmd => new(() => Growl.SuccessGlobal("文件保存成功！"));

    public RelayCommand WarningGlobalCmd => new(() => Growl.WarningGlobal(new GrowlInfo
    {
        Message = "磁盘空间快要满了！",
        CancelStr = "忽略",
        ActionBeforeClose = isConfirmed =>
        {
            Growl.InfoGlobal(isConfirmed.ToString());
            return true;
        }
    }));

    public RelayCommand ErrorGlobalCmd => new(() => Growl.ErrorGlobal("连接失败，请检查网络！"));

    public RelayCommand AskGlobalCmd => new(() => Growl.AskGlobal("检测到有新版本！是否更新？", isConfirmed =>
    {
        Growl.InfoGlobal(isConfirmed.ToString());
        return true;
    }));

    public RelayCommand FatalGlobalCmd => new(() => Growl.FatalGlobal(new GrowlInfo
    {
        Message = "程序已崩溃~~~",
        ShowDateTime = false
    }));

    public RelayCommand ClearGlobalCmd => new(Growl.ClearGlobal);

    #endregion

    public RelayCommand NewWindowCmd => new(() => new GrowlDemoWindow
    {
        Owner = Application.Current.MainWindow
    }.Show());
}
