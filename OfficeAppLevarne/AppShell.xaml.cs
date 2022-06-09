﻿namespace OfficeAppLevarne;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(DaysPage), typeof(DaysPage));
        Routing.RegisterRoute(nameof(DaysDetailsPage), typeof(DaysDetailsPage));
    }
}
