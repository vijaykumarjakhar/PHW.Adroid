using PHWAndriod.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PHWAndriod.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterChildMappingView : ContentPage
    {
        public MasterChildMappingView()
        {
            InitializeComponent();
            this.BindingContext = new MasterChildMappingViewModel();

            MessagingCenter.Subscribe<StockInViewModel>(this, "MasterChildFocusBarcodeEntry", (sender) =>
            {
                ChildBarcodeEntry.Focus();
            });
        }

        //private void ChildBarcodeEntry_Completed(object sender, EventArgs e)
        //{
        //    ChildBarcodeEntry.Focus();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.BindingContext = new MasterChildMappingViewModel();
        }
    }
}