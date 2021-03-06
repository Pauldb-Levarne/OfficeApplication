using CommunityToolkit.Mvvm.ComponentModel;
using OfficeAppLevarne.Models;
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
    public partial class WeeksViewModel : BaseViewModel
    {
        public ObservableCollection<Week> Weeks { get; } = new();
        public Command GetWeeksCommand { get;}
        public Command RefreshCommand { get; }

        [ObservableProperty]
        bool isRefreshing;


        WeeksService weeksService;

        public WeeksViewModel(WeeksService weeksService)
        {
            Title = "Weeks Overview";
            this.weeksService = weeksService;
            GetWeeksCommand = new Command(async () => await GetWeeksAsync());
            GetWeeksCommand.Execute(this);
            RefreshCommand = new Command(async () =>
            {
                IsRefreshing = true;
                await GetWeeksAsync();
                IsRefreshing = false;
            });
        }

        async Task GetWeeksAsync()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                var weeks = await weeksService.GetWeeks();

                if(Weeks.Count != 0)
                {
                    Weeks.Clear();
                }
                foreach (var week in weeks)
                    Weeks.Add(week);
            }
            catch(Exception ex) {
                Debug.WriteLine($"Unable to retrieve weeks: {ex.Message}");
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
