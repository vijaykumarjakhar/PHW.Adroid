using PHWAndriod.Models;
using PHWAndriod.Services;
using System;
using System.Collections.Generic;
using System.Text;
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


        public Command ClearCommand { get; }
        #endregion
        public StockInViewModel()
        {
            Title = "Stock In";
            ClearCommand = new Command(ExecuteClearCommand);
        }

        private async void ExecuteClearCommand(object obj)
        {
            try
            {
                AppLogic logic = new AppLogic();
                var result = await logic.GetItemTypeMasterList();
            }
            catch(Exception ex)
            {
            
            }
        }
    }
}
