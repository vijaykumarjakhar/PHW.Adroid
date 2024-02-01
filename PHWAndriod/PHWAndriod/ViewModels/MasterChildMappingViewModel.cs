using PHWAndriod.Models;
using PHWAndriod.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace PHWAndriod.ViewModels
{
    public class MasterChildMappingViewModel : BaseViewModel
    {
        #region Properties
        AppLogic logic = new AppLogic();

        private string product;
        public string Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }

        private MasterBarcodeDetailModel masterDetail;
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

        private string childBarcodeEntry;
        public string ChildBarcodeEntry
        {
            get { return childBarcodeEntry; }
            set
            {
                childBarcodeEntry = value;
                OnPropertyChanged(nameof(ChildBarcodeEntry));
            }
        }
        private ObservableCollection<Barcode> barcodes;
        public ObservableCollection<Barcode> Barcodes
        {
            get { return barcodes; }
            set
            {
                barcodes = value;
                OnPropertyChanged(nameof(Barcodes));
            }
        }
        private bool isMasterBarcodeLayoutVisible;
        public bool IsMasterBarcodeLayoutVisible
        {
            get { return isMasterBarcodeLayoutVisible; }
            set
            {
                isMasterBarcodeLayoutVisible = value;
                OnPropertyChanged(nameof(IsMasterBarcodeLayoutVisible));
            }
        }

        private bool isChildBarcodeLayoutVisible;
        public bool IsChildBarcodeLayoutVisible
        {
            get { return isChildBarcodeLayoutVisible; }
            set
            {
                isChildBarcodeLayoutVisible = value;
                OnPropertyChanged(nameof(IsChildBarcodeLayoutVisible));
            }
        }

        public Command ClearCommand { get; }
        public Command GetMasterBarcodeDetailCommand { get; }
        public Command GetChildBarcodeDetailCommand { get; }
        public Command MapBarcodeCommand { get; }

        #endregion
        public MasterChildMappingViewModel()
        {
            Title = "Master Child Mapping";
            IsMasterBarcodeLayoutVisible = false;
            IsChildBarcodeLayoutVisible = false;
            ScanCount = 0;
            Barcodes = new ObservableCollection<Barcode>();
            GetMasterBarcodeDetailCommand = new Command(GetMasterBarcodeInfo);
            GetChildBarcodeDetailCommand = new Command(GetChildBarcodeInfo);
            ClearCommand = new Command(ExecuteClearCommand);
            MapBarcodeCommand = new Command(MapBarcodes);
        }

        private async void MapBarcodes()
        {
            try
            {
                if (Barcodes != null && Barcodes.Count > 0)
                {
                    foreach (Barcode childBarcode in Barcodes)
                    {
                        MasterChildMappingFinalDetailModel data = new MasterChildMappingFinalDetailModel(masterDetail, childBarcode.Number);
                        var result = await logic.AddOperationMasterChildMapping(data);
                        if (!result)
                        {
                            await App.Current.MainPage.DisplayAlert("PHW", "Something went wrong. Please try again later.", "Ok");
                        }
                    }
                    await App.Current.MainPage.DisplayAlert("PHW", "Mapping Completed Sucessfully", "Ok");
                    IsMasterBarcodeLayoutVisible = false;
                    IsChildBarcodeLayoutVisible = false;
                    ScanCount = 0;
                    Barcodes = new ObservableCollection<Barcode>();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MasterChildMappingViewModel - MapBarcodes");
            }
        }

        private async void GetMasterBarcodeInfo()
        {
            try
            {
                if (!string.IsNullOrEmpty(BarcodeEntry))
                {
                    var result = await logic.GetScanMasterBarcodeDetail(BarcodeEntry);
                    if (result != null)
                    {
                        Material = result[0].MaterialType;
                        Product = result[0].ItemName;
                        masterDetail = result[0];
                        IsMasterBarcodeLayoutVisible = true;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("PHW", "Invalid Barcode", "Ok");
                    }
                    BarcodeEntry = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MasterChildMappingViewModel - GetMasterBarcodeInfo");
            }
        }

        private void ExecuteClearCommand()
        {
            try
            {
                IsMasterBarcodeLayoutVisible = false;
                IsChildBarcodeLayoutVisible = false;
                ScanCount = 0;
                Barcodes = new ObservableCollection<Barcode>();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MasterChildMappingViewModel - ExecuteClearCommand");
            }
        }

        private async void GetChildBarcodeInfo()
        {
            try
            {
                if (!string.IsNullOrEmpty(ChildBarcodeEntry))
                {
                    if (Barcodes.Any(s => s.Number == ChildBarcodeEntry))
                    {
                        await App.Current.MainPage.DisplayAlert("PHW", "Barcode already scanned", "Ok");
                    }
                    else
                    {
                        var result = await logic.GetScanChildBarcodeDetail(Material, Product, ChildBarcodeEntry);
                        if (result != null)
                        {
                            IsChildBarcodeLayoutVisible = true;
                            ScanCount += 1;
                            Barcodes.Add(new Barcode() { Number = ChildBarcodeEntry });
                        }
                        else
                        {
                            await App.Current.MainPage.DisplayAlert("PHW", "Invalid Barcode", "Ok");
                        }
                    }
                    ChildBarcodeEntry = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MasterChildMappingViewModel - GetChildBarcodeInfo");
            }
        }
    }

    public class Barcode
    {
        public string Number { get; set; }
    }
}
