using PHWAndriod.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialBookingView : ContentPage
    {
        public MaterialBookingView()
        {
            InitializeComponent();
            this.BindingContext = new MaterialBookingViewModel();
        }

        private void BarcodeEntry_Completed(object sender, EventArgs e)
        {
            BarcodeEntry.Focus();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new MaterialBookingViewModel();
        }
    }
}