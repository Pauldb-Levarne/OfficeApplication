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
    [QueryProperty(nameof(Week), "Week")]
    public partial class DaysViewModel : BaseViewModel
    {
        public DaysViewModel()
        {
            Title = "Days overview";
        }

        [ObservableProperty]
        Week week;


    }
}
