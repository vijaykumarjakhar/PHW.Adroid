using PHWAndriod.Models;
using PHWAndriod.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PHWAndriod.ViewModels
{
    public class MaterialDispatchViewModel : BaseViewModel
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

        private bool isConditionListEnabled;
        public bool IsConditionListEnabled
        {
            get { return isConditionListEnabled; }
            set
            {
                isConditionListEnabled = value;
                OnPropertyChanged(nameof(IsConditionListEnabled));
            }
        }

        private bool isSpoolListEnabled;
        public bool IsSpoolListEnabled
        {
            get { return isSpoolListEnabled; }
            set
            {
                isSpoolListEnabled = value;
                OnPropertyChanged(nameof(IsSpoolListEnabled));
            }
        }

        private bool isProductListEnabled;
        public bool IsProductListEnabled
        {
            get { return isProductListEnabled; }
            set
            {
                isProductListEnabled = value;
                OnPropertyChanged(nameof(IsProductListEnabled));
            }
        }

        private bool isSizeListEnabled;
        public bool IsSizeListEnabled
        {
            get { return isSizeListEnabled; }
            set
            {
                isSizeListEnabled = value;
                OnPropertyChanged(nameof(IsSizeListEnabled));
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
        public MaterialDispatchViewModel()
        {
            Title = "Material Dispatch/Re-Dispatch";
            InitaliseScreen();
            ClearCommand = new Command(ExecuteClearCommand);
            PickListSelectedIndexChangedCommand = new Command(LoadProductList);
            ProductListSelectedIndexChangedCommand = new Command(LoadSpoolList);
            SpoolListSelectedIndexChangedCommand = new Command(LoadConditionList);
            ConditionListSelectedIndexChangedCommand = new Command(LoadSizeList);
            SizeListSelectedIndexChangedCommand = new Command(LoadData);
            GetDispatchBarcodeDetailCommand = new Command(GetDispactBarcodeDetails);
        }

        private async void GetDispactBarcodeDetails(object obj)
        {
            IsBusy = true;
            try
            {
                var result = await logic.GetDispatchBarcodeDetail(PackType, SpoolList[SelectedSpoolListIndex].SpoolId, ConditionList[SelectedConditionListIndex].ConditionId, SizeList[SelectedSizeListIndex].SizeId,
                   gradeId, ProductList[SelectedProductListIndex].ItemId, BarcodeNumber);
                if (result != null)
                {
                    BoxQty = result[0].BoxQty;
                    SpoolQty = result[0].SpoolQty;

                    DispatchFinalDetailModel finalModel = new DispatchFinalDetailModel(result[0], PickList[SelectedPickListIndex], bookingModel, ProductList[SelectedProductListIndex]);
                    var resopnse = await logic.AddOperationDispatchStockOutChild(finalModel);
                    if (resopnse)
                    {
                        LastScan = BarcodeNumber;
                        OutQty += 1;
                        if (OutQty >= ReqQty)
                        {
                            IsBusy = false;
                            await App.Current.MainPage.DisplayAlert("PHW", "Required Qty fullfilled", "Ok");
                        }
                    }
                }
                else
                {
                    BarcodeNumber = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - GetDispactBarcodeDetails");
            }
            IsBusy = false;
        }

        private async void ExecuteClearCommand(object obj)
        {
            try
            {
                InitaliseScreen();
                BarcodeNumber = string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - ExecuteClearCommand");
            }
        }

        private void InitaliseScreen()
        {
            try
            {
                Parallel.Invoke(
                    () => LoadPickList(),
                    () => LoadProductList(),
                    () => LoadSpoolList(),
                    () => LoadConditionList(),
                    () => LoadSizeList());

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
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - InitaliseScreen");
            }
        }

        private async void LoadData()
        {
            IsBusy = true;
            try
            {
                if (SelectedSizeListIndex > 0)
                {
                    var result = await logic.GetDispatchProductdetail(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, SpoolList[SelectedSpoolListIndex].SpoolId, ConditionList[SelectedConditionListIndex].ConditionId, SizeList[SelectedSizeListIndex].SizeId);
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
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - LoadData");
            }
            IsBusy = false;
        }

        private async void LoadPickList()
        {
            IsBusy = true;
            try
            {
                var result = await logic.PickListMasterList();
                if (result != null && result.Count > 0)
                {
                    PickList = result;
                    SelectedPickListIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - LoadPickList");
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
                    IsProductListEnabled = true;
                    var result = await logic.GetPickOutWiseProductList(PickList[SelectedPickListIndex].PickOutId);
                    if (result != null && result.Count > 0)
                    {
                        ProductList = result;
                        SelectedProductListIndex = 0;
                    }
                }
                else
                    IsProductListEnabled = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - LoadProductList");
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
                    IsConditionListEnabled = true;
                    var result = await logic.GetPickOutWiseProductWiseSpoolWiseConditionList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, SpoolList[SelectedSpoolListIndex].SpoolId);
                    if (result != null && result.Count > 0)
                    {
                        ConditionList = result;
                        SelectedConditionListIndex = 0;
                    }
                }
                else
                    IsConditionListEnabled = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - LoadConditionList");
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
                    IsSpoolListEnabled = true;
                    var result = await logic.GetPickOutWiseProductWiseSpoolList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId);
                    if (result != null && result.Count > 0)
                    {
                        SpoolList = result;
                        SelectedSpoolListIndex = 0;
                    }
                }
                else
                    IsSpoolListEnabled = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - LoadSpoolList");
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
                    IsSizeListEnabled = true;
                    var result = await logic.GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, SpoolList[SelectedSpoolListIndex].SpoolId, ConditionList[SelectedConditionListIndex].ConditionId);
                    if (result != null && result.Count > 0)
                    {
                        SizeList = result;
                        SelectedSizeListIndex = 0;
                    }
                }
                else
                    IsSizeListEnabled = false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "MaterialDispatchViewModel - LoadSizeList");
            }
            IsBusy = false;
        }
    }
}
