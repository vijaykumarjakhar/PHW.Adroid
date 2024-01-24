using PHWAndriod.Services;
using System;
using Xamarin.Forms;

namespace PHWAndriod.ViewModels
{
    public class CancelBookingViewModel : BaseViewModel
    {
        private string barcodeEntry;
        public string BarcodeEntry
        {
            get { return barcodeEntry; }
            set
            {
                barcodeEntry = value;
                OnPropertyChanged(nameof(BarcodeEntry));
            }
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }

        private int scanCount;
        public int ScanCount
        {
            get { return scanCount; }
            set
            {
                scanCount = value;
                OnPropertyChanged(nameof(ScanCount));
            }
        }

        private string material;
        public string Material
        {
            get { return material; }
            set
            {
                material = value;
                OnPropertyChanged(nameof(Material));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private string lastScan;
        public string LastScan
        {
            get { return lastScan; }
            set
            {
                lastScan = value;
                OnPropertyChanged(nameof(LastScan));
            }
        }

        private bool isBarcodeLayoutVisible;
        public bool IsBarcodeLayoutVisible
        {
            get { return isBarcodeLayoutVisible; }
            set
            {
                isBarcodeLayoutVisible = value;
                OnPropertyChanged(nameof(IsBarcodeLayoutVisible));
            }
        }

        public Command GetBarcodeDetailCommand { get; }
        public Command ClearCommand { get; }

        AppLogic logic = new AppLogic();
        public CancelBookingViewModel()
        {
            Title = "Cancel Booking";
            ClearCommand = new Command(ExecuteClearCommand);
            GetBarcodeDetailCommand = new Command(GetBarcodeDetails);
        }

        private void GetBarcodeDetails(object obj)
        {
            try
            {
                IsBusy = true;
                //var result = logic.GetPhysicalList();
                //TODO: populate data
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetItemTypeMasterList");
            }
            IsBusy = false;

        }

        private async void ExecuteClearCommand(object obj)
        {
            try
            {
                IsBarcodeLayoutVisible = false;
                BarcodeEntry = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetItemTypeMasterList");
            }
        }
    }
}
