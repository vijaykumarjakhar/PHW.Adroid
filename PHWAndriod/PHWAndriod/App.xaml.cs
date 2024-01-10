using PHWAndriod.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod
{
    public partial class App : Application
    {
        public static int ScanCount { get; set; }

        public static string LastBarcode { get; set; }

        public static List<string> BarcodeList = new List<string>();

        public App()
        {
            InitializeComponent();
            ScanCount = 0;
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
