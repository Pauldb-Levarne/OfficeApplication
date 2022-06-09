using OfficeAppLevarne.Models;
using OfficeAppLevarne.ViewModels;

namespace OfficeAppLevarne;

public partial class DaysPage : ContentPage
{
    public DaysPage(DaysViewModel daysViewModel)
    {
        InitializeComponent();

        BindingContext = daysViewModel;
    }
    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var day = ((VisualElement)sender).BindingContext as Day;


        if (day == null)
            return;


        await Shell.Current.GoToAsync(nameof(DaysDetailsPage), true, new Dictionary<string, object>
        {
            {"Day", day },
        });

    }
}
