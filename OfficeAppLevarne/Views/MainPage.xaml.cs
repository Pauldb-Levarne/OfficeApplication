using OfficeAppLevarne.Models;
using OfficeAppLevarne.ViewModels;

namespace OfficeAppLevarne.Views;

public partial class MainPage : ContentPage
{
	public MainPage(WeeksViewModel weeksViewModel)
	{
		InitializeComponent();
		BindingContext = weeksViewModel;
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
		var week = ((VisualElement)sender).BindingContext as Week;

		if (week == null)
			return;


		await Shell.Current.GoToAsync(nameof(DaysPage), true, new Dictionary<string, object>
		{
			{"Week", week }
		});

    }

}

