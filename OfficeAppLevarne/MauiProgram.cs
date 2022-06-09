using Microsoft.Maui.LifecycleEvents;
using OfficeAppLevarne.Repository;
using OfficeAppLevarne.Services;
using OfficeAppLevarne.ViewModels;
using OfficeAppLevarne.Views;

namespace OfficeAppLevarne;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
		builder.Services.AddTransient<MainPage>();
		builder.Services.AddSingleton<WeeksService>();
		builder.Services.AddSingleton<DaysService>();
		builder.Services.AddTransient<WeeksViewModel>();
		builder.Services.AddTransient<DaysViewModel>();
		builder.Services.AddTransient<DaysPage>();
		builder.Services.AddTransient<DaysDetailsPage>();
		builder.Services.AddTransient<DaysDetailsViewModel>();
		builder.Services.AddTransient<ProfilePage>();
		builder.Services.AddTransient<ProfileViewModel>();
		builder.Services.AddSingleton<Database>();

		return builder.Build();
	}
}
