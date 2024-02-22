using PHWAndriod.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StockinView : ContentPage
    {
        public StockinView()
        {
            InitializeComponent();
            this.BindingContext = new StockInViewModel();

            MessagingCenter.Subscribe<StockInViewModel>(this, "StockInFocusBarcodeEntry", (sender) =>
            {
                ItemListPicker.Unfocus();
                BarcodeEntry.Focus();
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new StockInViewModel();
        }
    }
}