using CommunityToolkit.Mvvm.ComponentModel;

namespace WPFTemplate.Data.Model;

public class ContentItemModel : ObservableRecipient
{
    private bool _isVisible = true;
    private string _queriesText = string.Empty;

    public string? Name { get; set; }

    public string? GroupName { get; set; }

    public string? TargetCtlName { get; set; }

    public string? ImageName { get; set; }

    public bool IsNew { get; set; }

    public string QueriesText
    {
        get => _queriesText;

        set => SetProperty(ref _queriesText, value);

    }

    public bool IsVisible
    {
        get => _isVisible;

        set => SetProperty(ref _isVisible, value);

    }
}
