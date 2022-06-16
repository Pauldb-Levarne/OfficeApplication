using OfficeAppLevarne.Models;
using OfficeAppLevarne.ViewModels;

namespace OfficeAppLevarne;

public partial class DaysDetailsPage : ContentPage
{
	public DaysDetailsPage(DaysDetailsViewModel daysDetailsViewModel)
	{
		InitializeComponent();
		BindingContext = daysDetailsViewModel;
	}
}