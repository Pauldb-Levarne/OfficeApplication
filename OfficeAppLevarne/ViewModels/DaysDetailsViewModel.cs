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
    public partial class DaysDetailsViewModel : BaseViewModel
    {
        Database db = new();
        public Command UpdateDayPersonCommand { get; }
        DaysService daysService;
        WeeksService weeksService;
        public DaysDetailsViewModel(DaysService daysService, WeeksService weeksService)
        {
            Title = "Days overview";
            this.daysService = daysService;
            this.weeksService = weeksService;
            UpdateDayPersonCommand = new Command(async () => await UpdateDayPersonAsync());
            canCheckIn = !CheckIfAtOffice() && day.available;
            canCheckOut = CheckIfAtOffice();
        }
        [ObservableProperty]
        Day day;

        [ObservableProperty]
        bool canCheckOut;

        [ObservableProperty]
        bool canCheckIn;
        public bool CheckIfAtOffice()
        {
            Person person = db.getPerson();
            if (person == null) return false;
            return day.persons.FindIndex(p => p.name.Equals(person.name)) == -1;
        }

        async Task UpdateDayPersonAsync()
        {
            if (IsBusy)
                return;
            try
            {
                Person person = db.getPerson();

                day.persons.Add(person);
                IsBusy = true;
                
                var newDay = await daysService.UpdateDay(day.weekId, day);
                if(newDay != null)
                {
                    await weeksService.GetWeeks();
                    
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to retrieve weeks: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}
