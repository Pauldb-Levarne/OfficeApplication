using OfficeAppLevarne;
using OfficeAppLevarne.Models;
using OfficeAppLevarne.Repository;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OfficeAppLevarne.Services
{


    public class MapService
    {

        public async Task NavigateToOffice()
        {
            var options = new MapLaunchOptions { Name = "Levarne HQ", NavigationMode = NavigationMode.Driving };
            var placemark = new Placemark()
            {
                CountryName = "The Netherlands",
                PostalCode = "3723BJ",
                Thoroughfare = "Levarne HQ"
            };

            try
            {
                await placemark.OpenMapsAsync(options);
            }
            catch (Exception ex)
            {
                // No map application available to open
                Debug.WriteLine($"Unable to open maps: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
        }

        public async Task<double> GetDistanceToOffice()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            var targetLocation = new Location(52.12909463657944, 5.198938455775212);
            if (location == null)
            {
                location = await Geolocation.GetLocationAsync();
            };

            return location.CalculateDistance(targetLocation, DistanceUnits.Kilometers);



        }

        public async Task<double> RefreshDistanceToOffice()
        {
            var targetLocation = new Location(52.12909463657944, 5.198938455775212);
            var location = await Geolocation.GetLocationAsync();

            return location.CalculateDistance(targetLocation, DistanceUnits.Kilometers);



        }
    }
}
