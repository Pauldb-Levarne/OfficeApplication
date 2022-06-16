using OfficeAppLevarne.Models;
using OfficeAppLevarne.Repository;
using OfficeAppLevarne.Services;
using OfficeAppLevarne.ViewModels;

namespace OfficeAppLevarne.Views;

public partial class DirectionsPage : ContentPage
{

	public DirectionsPage(DirectionsViewModel directionsViewModel)
	{
		InitializeComponent();
		BindingContext = directionsViewModel;
	}
}
