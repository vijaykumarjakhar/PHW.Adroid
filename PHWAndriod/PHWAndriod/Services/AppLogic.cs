using Newtonsoft.Json;
using PHWAndriod.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PHWAndriod.Services
{
    public class AppLogic
    {
        public string BaseURL = "https://vijay-test-api.azurewebsites.net/";

        #region ItemTypeMaster
        public async Task<List<ItemTypeModel>> GetItemTypeMasterList()
        {
            List<ItemTypeModel> itemList = new List<ItemTypeModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/ItemTypeMaster/ItemTypeMasterList";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<List<ItemTypeModel>>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetItemTypeMasterList");
                return null;
            }
        }
        #endregion

        #region MasterMapping
        public async Task<ChildBarcodeDetailModel> GetScanChildBarcodeDetail(string material, string item, string barcode)
        {
            ChildBarcodeDetailModel data = new ChildBarcodeDetailModel();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/MasterMapping/GetScanChildBarcodeDetail?MaterialType={material}&ItemName={item}&ScanChildBarcode={barcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<ChildBarcodeDetailModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetScanChildBarcodeDetail");
                return null;
            }
        }

        public async Task<MasterBarcodeDetailModel> GetScanMasterBarcodeDetail(string barcode)
        {
            MasterBarcodeDetailModel data = new MasterBarcodeDetailModel();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/MasterMapping/GetScanMasterBarcodeDetail?ScanMasterBarcode={barcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<MasterBarcodeDetailModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetScanMasterBarcodeDetail");
                return null;
            }
        }

        #endregion

        #region PhysicalVerification

        public async Task<List<PhysicalListModel>> GetPhysicalListBarcode(string scanBarcode)
        {
            List<PhysicalListModel> data = new List<PhysicalListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/getphysicallistbyBarcode?ScanBarcode={scanBarcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<PhysicalListModel>>(content);
                        return data;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Paramhans Wires", response.ReasonPhrase, "Ok");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPhysicalListBarcode");
                return null;
            }
        }

        public async Task<bool> AddOperationPhysicalList(PhysicalFinalListModel request)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}/api/PhysicalVerification/addOperationPhysicalVerfiy";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationPhysicalList");
            }
            return data;
        }
        #endregion

        #region Cancel Booking

        public async Task<List<CancelBookingModel>> GetCancelBookingListBarcode(string scanBarcode)
        {
            List<CancelBookingModel> data = new List<CancelBookingModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/BookingStock/CancelBookingStock_GetScanBarcodeDetail?ScanBarcode={scanBarcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<CancelBookingModel>>(content);
                        return data;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Paramhans Wires", response.ReasonPhrase, "Ok");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPhysicalListBarcode");
                return null;
            }
        }

        public async Task<bool> AddOperationCancelBookingList(CancelBookingFinalModel request)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}/api/BookingStock/addOperation_CancelBookingStock";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationCancelBookingList");
            }
            return data;
        }

        #endregion

        #region PickListMaster

        public async Task<List<PickListModel>> PickListMasterList()
        {
            List<PickListModel> itemList = new List<PickListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}PickListMasterList";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<List<PickListModel>>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - PickListMasterList");
                return null;
            }
        }
        public async Task<List<PickOutProductListModel>> GetPickOutWiseProductList(int pickOutId)
        {
            List<PickOutProductListModel> itemList = new List<PickOutProductListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductList?PickOutId={pickOutId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<List<PickOutProductListModel>>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductList");
                return null;
            }
        }
        public async Task<List<PickOutProductSpoolModel>> GetPickOutWiseProductWiseSpoolList(int pickOutId, int productId)
        {
            List<PickOutProductSpoolModel> result = new List<PickOutProductSpoolModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolList?PickOutId={pickOutId}&ItemId={productId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<List<PickOutProductSpoolModel>>(content);
                        return result;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductWiseSpoolList");
                return null;
            }
        }
        public async Task<List<PickOutProductSpoolConditionModel>> GetPickOutWiseProductWiseSpoolWiseConditionList(int pickOutId, int productId, int spoolId)
        {
            List<PickOutProductSpoolConditionModel> data = new List<PickOutProductSpoolConditionModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolWiseConditionList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<PickOutProductSpoolConditionModel>>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductWiseSpoolWiseConditionList");
                return null;
            }
        }
        public async Task<List<PickOutProductSpoolConditionSizeModel>> GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList(int pickOutId, int productId, int spoolId, int conditionId)
        {
            List<PickOutProductSpoolConditionSizeModel> data = new List<PickOutProductSpoolConditionSizeModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}&ConditionId={conditionId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<PickOutProductSpoolConditionSizeModel>>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList");
                return null;
            }
        }
        public async Task<List<BookingDispatchProductDetailListModel>> GetDispatchProductdetail(int pickOutId, int productId, int spoolId, int conditionId, int sizeId)
        {
            List<BookingDispatchProductDetailListModel> data = new List<BookingDispatchProductDetailListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickList_Dispatch_ProductDetailListAsync?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}&ConditionId={conditionId}&SizeId={sizeId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<BookingDispatchProductDetailListModel>>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetDispatchProductdetail");
                return null;
            }
        }
        public async Task<List<BookingDispatchProductDetailListModel>> GetBookingProductdetail(int pickOutId, int productId, int spoolId, int conditionId, int sizeId)
        {
            List<BookingDispatchProductDetailListModel> data = new List<BookingDispatchProductDetailListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickList_Booking_ProductDetailListAsync?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}&ConditionId={conditionId}&SizeId={sizeId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<BookingDispatchProductDetailListModel>>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetBookingProductdetail");
                return null;
            }
        }
        #endregion

        #region StockIn

        public async Task<List<StockInBarcodeDetail>> StockInGetScanBarcodeDetail(int itemTypeId, string scanBarcode)
        {
            List<StockInBarcodeDetail> data = new List<StockInBarcodeDetail>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/StockIn/StockIn_GetScanBarcodeDetail?ScanBarcode={scanBarcode}&ItemTypeId={itemTypeId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<StockInBarcodeDetail>>(content);
                        return data;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Paramhans Wires", response.ReasonPhrase, "Ok");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - StockInGetScanBarcodeDetail");
                return null;
            }
        }

        public async Task<bool> AddOperationStockInFinalInventory(StockInFinalDetailModel request)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/StockIn/addOperationStockIn_FinalInventory";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationStockInFinalInventory");
            }
            return data;
        }
        #endregion

        #region Dispatch

        public async Task<List<DispatchBarcodeDetailModel>> GetDispatchBarcodeDetail(string packType, int spoolId, int conditionId, int sizeId, int gradeId, int itemId, string scanBarcode)
        {
            List<DispatchBarcodeDetailModel> data = new List<DispatchBarcodeDetailModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/Dispatch/Dispatch_GetScanBarcodeDetail?&PackType={packType}&SpoolId={spoolId}&ConditionId={conditionId}&SizeId={sizeId}&GradeId={gradeId}&ScanBarcode={scanBarcode}&ItemId={itemId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<DispatchBarcodeDetailModel>>(content);
                        return data;
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Paramhans Wires", response.ReasonPhrase, "Ok");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - GetDispatchBarcodeDetail");
                return null;
            }
        }

        public async Task<bool> AddOperationDispatchStockOutChild(DispatchFinalDetailModel request)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/Dispatch/addOperationDispatch_tblStockOutChild";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationDispatchStockOutChild");
            }
            return data;
        }

        #endregion

        #region Booking

        #endregion
    }
}
