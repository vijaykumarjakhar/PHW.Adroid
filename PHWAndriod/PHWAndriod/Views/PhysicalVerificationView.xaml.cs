using PHWAndriod.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhysicalVerificationView : ContentPage
    {
        public PhysicalVerificationView()
        {
            InitializeComponent();
            this.BindingContext = new PhysicalVerificationViewModel();

            MessagingCenter.Subscribe<StockInViewModel>(this, "PhysicalVerificationFocusBarcodeEntry", (sender) =>
            {
                BarcodeEntry.Focus();
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new PhysicalVerificationViewModel();
        }
    }
}