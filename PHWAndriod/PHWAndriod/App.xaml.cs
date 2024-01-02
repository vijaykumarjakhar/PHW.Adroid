using PHWAndriod.Services;
using PHWAndriod.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
