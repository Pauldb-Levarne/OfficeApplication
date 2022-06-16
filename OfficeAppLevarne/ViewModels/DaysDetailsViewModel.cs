using CommunityToolkit.Mvvm.ComponentModel;
using OfficeAppLevarne.Models;
using OfficeAppLevarne.Repository;
using OfficeAppLevarne.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAppLevarne.ViewModels
{
    [QueryProperty(nameof(Day), "Day")]
    // [QueryProperty(nameof(canCheckOut), "canCheckout")]
    // [QueryProperty(nameof(canCheckIn), "canCheckIn")]

    public partial class DaysDetailsViewModel : BaseViewModel
    {
        Database db = new();
        public Command UpdateDayPersonCommand { get; }
        public Command RemovePersonsCommand { get;  }
        DaysService daysService;
        WeeksService weeksService;
        public DaysDetailsViewModel(DaysService daysService, WeeksService weeksService)
        {
            Title = "Days overview";
            this.daysService = daysService;
            this.weeksService = weeksService;
            UpdateDayPersonCommand = new Command(async () => await UpdateDayPersonAsync());
            RemovePersonsCommand = new Command(async () => await RemovePersonAsync());
        }
        [ObservableProperty]
        Day day;


        [ObservableProperty]
        bool canCheckOut = true;

        [ObservableProperty]
        bool canCheckIn = true;

         
        async Task UpdateDayPersonAsync()
        {
            if (IsBusy)
                return;
            try
            {
                Person person = db.getPerson();

                day.persons.Add(person);
                IsBusy = true;
                await daysService.UpdateDay(day.weekId, day);
                await weeksService.GetWeeks();
                    
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to update day: {ex.Message}");
                Vibration.Default.Vibrate(3);
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

        async Task RemovePersonAsync()
        {
            if (IsBusy)
                return;
            try
            {
                Person person = db.getPerson();

                day.persons.RemoveAll(p => p.name.Equals(person.name));
                IsBusy = true;

                await daysService.UpdateDay(day.weekId, day);
                await weeksService.GetWeeks();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to update day: {ex.Message}");
                Vibration.Default.Vibrate(3);
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");

            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
