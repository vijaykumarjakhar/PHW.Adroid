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

        }

        private void BarcodeEntry_Completed(object sender, System.EventArgs e)
        {
            BarcodeEntry.Focus();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new StockInViewModel();
        }
    }
}