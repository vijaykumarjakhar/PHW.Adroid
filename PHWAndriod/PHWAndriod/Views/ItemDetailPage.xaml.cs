using PHWAndriod.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PHWAndriod.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}