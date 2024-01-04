using PHWAndriod.ViewModels;
using PHWAndriod.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PHWAndriod
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = false;
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
