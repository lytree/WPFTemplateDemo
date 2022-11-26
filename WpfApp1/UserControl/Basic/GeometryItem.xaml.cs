using System.Windows;
using WPFTemplate.Data.Model;

namespace WPFTemplate.UserControl.Basic;

public partial class GeometryItem
{
    public GeometryItem() => InitializeComponent();

    public static readonly DependencyProperty InfoProperty = DependencyProperty.Register(
        nameof(Info), typeof(GeometryItemModel), typeof(GeometryItem), new PropertyMetadata(default(GeometryItemModel)));

    public GeometryItemModel Info
    {
        get => (GeometryItemModel) GetValue(InfoProperty);
        set => SetValue(InfoProperty, value);
    }
}
