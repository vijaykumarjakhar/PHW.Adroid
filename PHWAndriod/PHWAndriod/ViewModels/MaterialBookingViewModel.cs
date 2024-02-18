using PHWAndriod.Models;
using PHWAndriod.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PHWAndriod.ViewModels
{
    public class MaterialBookingViewModel : BaseViewModel
    {
        AppLogic logic = new AppLogic();

        #region Properties
        private int gradeId { get; set; }

        private BookingDispatchProductDetailListModel bookingModel;
        private List<PickListModel> pickList;
        public List<PickListModel> PickList
        {
            get { return pickList; }
            set
            {
                pickList = value;
                OnPropertyChanged(nameof(PickList));
            }
        }

        private int selectedPickListIndex;
        public int SelectedPickListIndex
        {
            get { return selectedPickListIndex; }
            set
            {
                selectedPickListIndex = value;
                OnPropertyChanged(nameof(SelectedPickListIndex));
            }
        }

        private List<PickOutProductListModel> productList;
        public List<PickOutProductListModel> ProductList
        {
            get { return productList; }
            set
            {
                productList = value;
                OnPropertyChanged(nameof(ProductList));
            }
        }

        private int selectedProductListIndex;
        public int SelectedProductListIndex
        {
            get { return selectedProductListIndex; }
            set
            {
                selectedProductListIndex = value;
                OnPropertyChanged(nameof(SelectedProductListIndex));
            }
        }

        private List<PickOutProductSpoolModel> spoolList;
        public List<PickOutProductSpoolModel> SpoolList
        {
            get { return spoolList; }
            set
            {
                spoolList = value;
                OnPropertyChanged(nameof(SpoolList));
            }
        }

        private int selectedSpoolListIndex;
        public int SelectedSpoolListIndex
        {
            get { return selectedSpoolListIndex; }
            set
            {
                selectedSpoolListIndex = value;
                OnPropertyChanged(nameof(SelectedSpoolListIndex));
            }
        }

        private List<PickOutProductSpoolConditionModel> conditionList;
        public List<PickOutProductSpoolConditionModel> ConditionList
        {
            get { return conditionList; }
            set
            {
                conditionList = value;
                OnPropertyChanged(nameof(ConditionList));
            }
        }

        private int selectedConditionListIndex;
        public int SelectedConditionListIndex
        {
            get { return selectedConditionListIndex; }
            set
            {
                selectedConditionListIndex = value;
                OnPropertyChanged(nameof(SelectedConditionListIndex));
            }
        }

        private List<PickOutProductSpoolConditionSizeModel> sizeList;
        public List<PickOutProductSpoolConditionSizeModel> SizeList
        {
            get { return sizeList; }
            set
            {
                sizeList = value;
                OnPropertyChanged(nameof(SizeList));
            }
        }

        private int selectedSizeListIndex;
        public int SelectedSizeListIndex
        {
            get { return selectedSizeListIndex; }
            set
            {
                selectedSizeListIndex = value;
                OnPropertyChanged(nameof(SelectedSizeListIndex));
            }
        }

        private int reqQty;
        public int ReqQty
        {
            get { return reqQty; }
            set
            {
                reqQty = value;
                OnPropertyChanged(nameof(ReqQty));
            }
        }

        private int outQty;
        public int OutQty
        {
            get { return outQty; }
            set
            {
                outQty = value;
                OnPropertyChanged(nameof(OutQty));
            }
        }

        private int boxQty;
        public int BoxQty
        {
            get { return boxQty; }
            set
            {
                boxQty = value;
                OnPropertyChanged(nameof(BoxQty));
            }
        }

        private int spoolQty;
        public int SpoolQty
        {
            get { return spoolQty; }
            set
            {
                spoolQty = value;
                OnPropertyChanged(nameof(SpoolQty));
            }
        }

        private string packType;
        public string PackType
        {
            get { return packType; }
            set
            {
                packType = value;
                OnPropertyChanged(nameof(PackType));
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

        public Command PickListSelectedIndexChangedCommand { get; }
        public Command ProductListSelectedIndexChangedCommand { get; }
        public Command SpoolListSelectedIndexChangedCommand { get; }
        public Command ConditionListSelectedIndexChangedCommand { get; }
        public Command SizeListSelectedIndexChangedCommand { get; }
        public Command GetDispatchBarcodeDetailCommand { get; }
        public Command ClearCommand { get; }

        #endregion
        public MaterialBookingViewModel()
        {
            Title = "Material Booking";
            InitaliseScreen();
            ClearCommand = new Command(ExecuteClearCommand);
            PickListSelectedIndexChangedCommand = new Command(LoadProductList);
            ProductListSelectedIndexChangedCommand = new Command(LoadSpoolList);
            SpoolListSelectedIndexChangedCommand = new Command(LoadConditionList);
            ConditionListSelectedIndexChangedCommand = new Command(LoadSizeList);
            SizeListSelectedIndexChangedCommand = new Command(LoadData);
            GetDispatchBarcodeDetailCommand = new Command(GetBookingBarcodeDetails);
        }

        private async void GetBookingBarcodeDetails()
        {
            IsBusy = true;
            try
            {
                var result = await logic.GetBookingBarcodeDetail(PackType, SpoolList[SelectedSpoolListIndex].SpoolId, ConditionList[SelectedConditionListIndex].ConditionId, SizeList[SelectedSizeListIndex].SizeId,
                   gradeId, ProductList[SelectedProductListIndex].ItemId, BarcodeNumber);
                if (result != null)
                {
                    BoxQty = result[0].BoxQty;
                    SpoolQty = result[0].SpoolQty;

                    foreach (BookingBarcodeDetailModel model in result)
                    {
                        BookingBarcodeFinalDetailModel finalModel = new BookingBarcodeFinalDetailModel(model, PickList[SelectedPickListIndex], bookingModel, ProductList[SelectedProductListIndex]);
                        var resopnse = await logic.AddOperationBookingStockOutChild(finalModel);
                        if (resopnse)
                        {
                            LastScan = BarcodeNumber;
                            OutQty += 1;
                            bookingModel.OutQty = OutQty;
                            if (OutQty >= ReqQty)
                            {
                                IsBusy = false;
                                await App.Current.MainPage.DisplayAlert("PHW", "Required Qty fullfilled", "Ok");
                                ExecuteClearCommand();
                            }
                        }
                    }
                }
                BarcodeNumber = string.Empty;
                MessagingCenter.Send(this, "MaterialBookingFocusBarcodeEntry");
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - GetDispactBarcodeDetails");
            }
            IsBusy = false;
        }

        private void ExecuteClearCommand()
        {
            try
            {
                InitaliseScreen();
                SelectedPickListIndex = 0;
                SelectedProductListIndex = 0;
                SelectedSpoolListIndex = 0;
                SelectedConditionListIndex = 0;
                SelectedSizeListIndex = 0;
                BarcodeNumber = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - ExecuteClearCommand");
            }
        }

        private void InitaliseScreen()
        {
            try
            {
                LoadPickList();
                LoadProductList();
                LoadSpoolList();
                LoadConditionList();
                LoadSizeList();

                ReqQty = 0;
                OutQty = 0;
                PackType = string.Empty;
                Grade = string.Empty;
                BoxQty = 0;
                SpoolQty = 0;
                LastScan = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - InitaliseScreen");
            }
        }

        private async void LoadData()
        {
            IsBusy = true;
            try
            {
                if (SelectedSizeListIndex > 0)
                {
                    var result = await logic.GetBookingProductdetail(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, SpoolList[SelectedSpoolListIndex].SpoolId, ConditionList[SelectedConditionListIndex].ConditionId, SizeList[SelectedSizeListIndex].SizeId);
                    if (result != null && result.Count > 0)
                    {
                        ReqQty = result[0].BoxQty;
                        OutQty = result[0].OutQty;
                        PackType = result[0].PackType;
                        Grade = result[0].Grade;
                        gradeId = result[0].GradeId;
                        bookingModel = result[0];
                        if (OutQty >= ReqQty)
                        {
                            IsBusy = false;
                            await App.Current.MainPage.DisplayAlert("PHW", "Required Qty fullfilled", "Ok");
                            ExecuteClearCommand();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - LoadData");
            }
            IsBusy = false;
        }

        private async void LoadPickList()
        {
            IsBusy = true;
            try
            {
                var result = await logic.PickListMasterList(booking: true);
                if (result != null && result.Count > 0)
                {
                    PickList = result;
                    SelectedPickListIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - LoadPickList");
            }
            IsBusy = false;
        }

        private async void LoadProductList()
        {
            IsBusy = true;
            try
            {
                if (SelectedPickListIndex > 0)
                {
                    var result = await logic.GetPickOutWiseProductList(PickList[SelectedPickListIndex].PickOutId, booking: true);
                    if (result != null && result.Count > 0)
                    {
                        ProductList = result;
                        SelectedProductListIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - LoadProductList");
            }
            IsBusy = false;
        }

        private async void LoadConditionList()
        {
            IsBusy = true;
            try
            {
                if (SelectedSpoolListIndex > 0)
                {
                    var result = await logic.GetPickOutWiseProductWiseSpoolWiseConditionList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, SpoolList[SelectedSpoolListIndex].SpoolId, booking: true);
                    if (result != null && result.Count > 0)
                    {
                        ConditionList = result;
                        SelectedConditionListIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - LoadConditionList");
            }
            IsBusy = false;
        }

        private async void LoadSpoolList()
        {
            IsBusy = true;
            try
            {
                if (SelectedProductListIndex > 0)
                {
                    var result = await logic.GetPickOutWiseProductWiseSpoolList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, booking: true);
                    if (result != null && result.Count > 0)
                    {
                        SpoolList = result;
                        SelectedSpoolListIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - LoadSpoolList");
            }
            IsBusy = false;
        }

        private async void LoadSizeList()
        {
            IsBusy = true;
            try
            {
                if (selectedConditionListIndex > 0)
                {
                    var result = await logic.GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, SpoolList[SelectedSpoolListIndex].SpoolId, ConditionList[SelectedConditionListIndex].ConditionId, booking: true);
                    if (result != null && result.Count > 0)
                    {
                        SizeList = result;
                        SelectedSizeListIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialBookingViewModel - LoadSizeList");
            }
            IsBusy = false;
        }
    }
}
