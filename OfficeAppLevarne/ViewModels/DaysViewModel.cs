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
    [QueryProperty(nameof(Days), "Days")]
    public partial class DaysViewModel : BaseViewModel
    {
        public DaysViewModel()
        {
            Title = "Days overview";
        }

        [ObservableProperty]
        List<Day> days;


    }
}
