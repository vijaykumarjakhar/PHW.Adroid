﻿using PHWAndriod.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialDispatchView : ContentPage
    {
        public MaterialDispatchView()
        {
            InitializeComponent();
            this.BindingContext = new MaterialDispatchViewModel();

            MessagingCenter.Subscribe<StockInViewModel>(this, "MaterialDispatchFocusBarcodeEntry", (sender) =>
            {
                BarcodeEntry.Focus();
            });
        }

        //private void BarcodeEntry_Completed(object sender, EventArgs e)
        //{
        //    BarcodeEntry.Focus();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new MaterialDispatchViewModel();
        }
    }
}