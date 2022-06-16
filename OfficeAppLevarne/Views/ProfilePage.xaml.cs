using OfficeAppLevarne.Models;
using OfficeAppLevarne.Repository;
using OfficeAppLevarne.Services;
using OfficeAppLevarne.ViewModels;

namespace OfficeAppLevarne.Views;

public partial class ProfilePage : ContentPage
{

	public ProfilePage(ProfileViewModel profileViewModel)
	{
		InitializeComponent();
		BindingContext = profileViewModel;
	}
}
