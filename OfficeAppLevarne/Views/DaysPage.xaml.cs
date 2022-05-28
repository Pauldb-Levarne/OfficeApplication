using OfficeAppLevarne.ViewModels;

namespace OfficeAppLevarne;

public partial class DaysPage : ContentPage
{
	public DaysPage(DaysViewModel daysViewModel)
	{
		InitializeComponent();

		BindingContext = daysViewModel;
	}
}