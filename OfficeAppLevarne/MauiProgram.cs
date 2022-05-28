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
		builder.Services.AddTransient<WeeksViewModel>();
		builder.Services.AddTransient<DaysViewModel>();
		builder.Services.AddTransient<DaysPage>();

		return builder.Build();
	}
}
