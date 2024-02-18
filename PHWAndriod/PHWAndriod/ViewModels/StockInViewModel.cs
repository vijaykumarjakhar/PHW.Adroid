using PHWAndriod.Models;
using PHWAndriod.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PHWAndriod.ViewModels
{
    public class StockInViewModel : BaseViewModel
    {
        #region Properties

        private List<ItemTypeModel> itemList;
        public List<ItemTypeModel> ItemList
        {
            get { return itemList; }
            set
            {
                itemList = value;
                OnPropertyChanged(nameof(ItemList));
            }
        }

        private string barcodeNumber;
        public string BarcodeNumber
        {
            get { return barcodeNumber; }
            set
            {
                barcodeNumber = value;
                OnPropertyChanged(nameof(BarcodeNumber));
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

        private string spool;
        public string Spool
        {
            get { return spool; }
            set
            {
                spool = value;
                OnPropertyChanged(nameof(Spool));
            }
        }

        private string grade;
        public string Grade
        {
            get { return grade; }
            set
            {
                grade = value;
                OnPropertyChanged(nameof(Grade));
            }
        }

        private int boxes;
        public int Boxes
        {
            get { return boxes; }
            set
            {
                boxes = value;
                OnPropertyChanged(nameof(Boxes));
            }
        }

        private int selectedInventoryTypeIndex;
        public int SelectedInventoryTypeIndex
        {
            get { return selectedInventoryTypeIndex; }
            set
            {
                selectedInventoryTypeIndex = value;
                OnPropertyChanged(nameof(SelectedInventoryTypeIndex));
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


        AppLogic logic = new AppLogic();
        public Command ClearCommand { get; }
        public Command GetStockInBarcodeDetailCommand { get; }
        #endregion
        public StockInViewModel()
        {
            Title = "Stock In";
            LoadInventoryType();
            ScanCount = 0;
            LastScan = string.Empty;
            ClearCommand = new Command(ExecuteClearCommand);
            GetStockInBarcodeDetailCommand = new Command(GetBarcodeInfo);
        }

        private async void GetBarcodeInfo(object obj)
        {
            IsBusy = true;
            try
            {
                if (SelectedInventoryTypeIndex > 0)
                {

                    var result = await logic.StockInGetScanBarcodeDetail(ItemList[SelectedInventoryTypeIndex].ItemTypeId, BarcodeNumber);
                    if (result != null)
                    {
                        IsBarcodeLayoutVisible = true;
                        ProductName = result[0].ItemName;
                        Spool = result[0].Spool;
                        Grade = result[0].Grade;
                        Boxes = result[0].BoxQty;
                        foreach (StockInBarcodeDetail item in result)
                        {
                            StockInFinalDetailModel data = new StockInFinalDetailModel(item);
                            var response = await logic.AddOperationStockInFinalInventory(data);
                            if (response)
                            {
                                ScanCount += 1;
                                LastScan = BarcodeNumber;
                            }
                        }
                    }
                    BarcodeNumber = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "StockInViewModel - GetBarcodeInfo");
            }
            IsBusy = false;
            MessagingCenter.Send(this, "StockInFocusBarcodeEntry");
        }

        private async void LoadInventoryType()
        {
            IsBusy = true;
            try
            {
                var result = await logic.GetItemTypeMasterList();
                if (result != null && result.Count > 0)
                {
                    ItemList = result;
                    SelectedInventoryTypeIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "StockInViewModel - LoadInventoryType");
            }
            IsBusy = false;
        }

        private async void ExecuteClearCommand(object obj)
        {
            try
            {
                IsBarcodeLayoutVisible = false;
                SelectedInventoryTypeIndex = 0;
                BarcodeNumber = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "StockInViewModel - ExecuteClearCommand");
            }
        }
    }
}
