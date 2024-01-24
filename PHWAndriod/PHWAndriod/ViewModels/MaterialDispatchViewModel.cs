using PHWAndriod.Models;
using PHWAndriod.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PHWAndriod.ViewModels
{
    public class MaterialDispatchViewModel: BaseViewModel
    {
        AppLogic logic = new AppLogic();

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

        public Command PickListSelectedIndexChangedCommand { get; }
        public Command ProductListSelectedIndexChangedCommand { get; }
        public Command SpoolListSelectedIndexChangedCommand { get; }
        public Command ConditionListSelectedIndexChangedCommand { get; }
        public Command SizeListSelectedIndexChangedCommand { get; }
        public MaterialDispatchViewModel()
        {
            Title = "Material Dispatch/Re-Dispatch";
            Parallel.Invoke(
                () => LoadPickList(),
                () => LoadProductList(),
                () => LoadSpoolList(),
                () => LoadConditionList(),
                () => LoadSizeList());
            PickListSelectedIndexChangedCommand = new Command(LoadProductList);
            ProductListSelectedIndexChangedCommand = new Command(LoadSpoolList);
            SpoolListSelectedIndexChangedCommand = new Command(LoadConditionList);
            ConditionListSelectedIndexChangedCommand = new Command(LoadSizeList);
            SizeListSelectedIndexChangedCommand = new Command(LoadData);
        }

        private void LoadData(object obj)
        {
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
            catch
            {
            }
            IsBusy = false;
        }

        private async void LoadProductList()
        {
            IsBusy = true;
            try
            {
                if(SelectedPickListIndex > 0)
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
            catch
            {
            }
            IsBusy = false;
        }

        private async void LoadConditionList()
        {
            IsBusy = true;
            try
            {
                if(SelectedSpoolListIndex > 0)
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
                    IsConditionListEnabled= false;
            }
            catch
            {
            }
            IsBusy = false;
        }

        private async void LoadSpoolList()
        {
            IsBusy = true;
            try
            {
                if(SelectedProductListIndex > 0)
                {
                    IsSpoolListEnabled= true;
                    var result = await logic.GetPickOutWiseProductWiseSpoolList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId);
                    if (result != null && result.Count > 0)
                    {
                        SpoolList = result;
                        SelectedSpoolListIndex = 0;
                    }
                }
                else
                    IsSpoolListEnabled= false;
            }
            catch
            {
            }
            IsBusy = false;
        }

        private async void LoadSizeList()
        {
            IsBusy = true;
            try
            {
                if(selectedConditionListIndex> 0)
                {
                    IsSizeListEnabled= true;
                    var result = await logic.GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList(PickList[SelectedPickListIndex].PickOutId, ProductList[SelectedProductListIndex].ItemId, SpoolList[SelectedSpoolListIndex].SpoolId, ConditionList[SelectedConditionListIndex].ConditionId);
                    if (result != null && result.Count > 0)
                    {
                        SizeList = result;
                        SelectedSizeListIndex = 0;
                    }
                }
                else
                    IsSizeListEnabled= false;  
            }
            catch
            {
            }
            IsBusy = false;
        }
    }
}
