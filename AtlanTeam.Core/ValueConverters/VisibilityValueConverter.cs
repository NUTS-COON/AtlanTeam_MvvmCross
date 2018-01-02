using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Visibility;
using System.Globalization;


namespace AtlanTeam.Core.ValueConverters
{
    public class VisibilityValueConverter : MvxBaseVisibilityValueConverter<bool>
    {
        protected override MvxVisibility Convert(bool value, object parameter, CultureInfo culture)
        {
            return (value == true) ? MvxVisibility.Visible : MvxVisibility.Collapsed;
        }
    }
}
