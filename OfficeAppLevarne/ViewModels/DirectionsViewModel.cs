using CommunityToolkit.Mvvm.ComponentModel;
using OfficeAppLevarne.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAppLevarne.ViewModels
{
    public partial class DirectionsViewModel : BaseViewModel
    {
        MapService mapService;

        [ObservableProperty]
        double distanceToHQ;


        public Command StartNavigationCommand { get; }
        public Command GetDistanceCommand { get; }
        public Command RefreshDistanceCommand { get; }

        public DirectionsViewModel(MapService mapService)
        {
            Title = "Directions";
            this.mapService = mapService;
            StartNavigationCommand = new Command(async () => await OpenMaps());
            GetDistanceCommand = new Command(async () => await GetDistance());
            RefreshDistanceCommand = new Command(async () => await RefreshDistance());
            GetDistanceCommand.Execute(this);
        }


        async Task RefreshDistance()
        {

            try
            {
                distanceToHQ = await mapService.RefreshDistanceToOffice();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to retrieve distance to HQ: {ex.Message}");
                Vibration.Default.Vibrate(3);

                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        async Task OpenMaps()
        {
            try
            {
                await mapService.NavigateToOffice();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to open map: {ex.Message}");
                Vibration.Default.Vibrate(3);

                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }

        }

        async Task GetDistance()
        {

            try
            {
                distanceToHQ = await mapService.GetDistanceToOffice();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to retrieve distance to HQ: {ex.Message}");
                Vibration.Default.Vibrate(3);

                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

    }


}
