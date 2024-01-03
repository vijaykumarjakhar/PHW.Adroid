using PHWAndriod.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}