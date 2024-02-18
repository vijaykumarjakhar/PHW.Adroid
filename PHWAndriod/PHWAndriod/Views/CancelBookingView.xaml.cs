using PHWAndriod.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CancelBookingView : ContentPage
    {
        public CancelBookingView()
        {
            InitializeComponent();
            this.BindingContext = new CancelBookingViewModel();

            MessagingCenter.Subscribe<StockInViewModel>(this, "CancelBookingFocusBarcodeEntry", (sender) =>
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
            this.BindingContext = new CancelBookingViewModel();
        }
    }
}