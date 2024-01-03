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
    public partial class MasterChildMappingView : ContentPage
    {
        public MasterChildMappingView()
        {
            InitializeComponent();
            this.BindingContext = new MasterChildMappingViewModel();
        }
    }
}