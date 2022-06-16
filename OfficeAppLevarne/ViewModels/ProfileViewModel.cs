using CommunityToolkit.Mvvm.ComponentModel;
using OfficeAppLevarne.Models;
using OfficeAppLevarne.Repository;
using OfficeAppLevarne.Services;
using OfficeAppLevarne.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeAppLevarne.ViewModels
{
    public partial class ProfileViewModel : BaseViewModel
    {
        Database db = new();
        public Command GetPersonCommand { get; }
        public Command UpdatePersonCommand { get; }

        public string NewName { get; set; }



        public ProfileViewModel()
        {
            Title = "Profile";
            GetPersonCommand = new Command(async () => await RecievePerson());
            UpdatePersonCommand = new Command(async () => await UpdatePerson());
            GetPersonCommand.Execute(this);
        }

        [ObservableProperty]
        Person person;



        async Task RecievePerson()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                person = db.getPerson();


            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to retrieve person: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }


        async Task UpdatePerson()
        {
            if (IsBusy)
                return;
            try
            {
                IsBusy = true;
                Person payload = new()
                {
                    Id = 1,
                    name = NewName
                };

                if(person == null)
                {
                    db.CreatePerson(payload);
                }else
                {
                    db.UpdatePerson(payload);
                }


            }

            catch (Exception ex)
            {
                Debug.WriteLine($"Unable to update person: {ex.Message}");
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }

        }

    }

}

