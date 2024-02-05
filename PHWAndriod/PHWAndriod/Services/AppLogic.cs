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
        public async Task<List<ChildBarcodeDetailModel>> GetScanChildBarcodeDetail(string material, string item, string barcode)
        {
            List<ChildBarcodeDetailModel> data = new List<ChildBarcodeDetailModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/MasterMapping/GetScanChildBarcodeDetail?MaterialType={material}&ItemName={item}&ScanChildBarcode={barcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<ChildBarcodeDetailModel>>(content);
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

        public async Task<List<MasterBarcodeDetailModel>> GetScanMasterBarcodeDetail(string barcode)
        {
            List<MasterBarcodeDetailModel> data = new List<MasterBarcodeDetailModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/MasterMapping/GetScanMasterBarcodeDetail?ScanMasterBarcode={barcode}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<MasterBarcodeDetailModel>>(content);
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

        public async Task<bool> AddOperationMasterChildMapping(MasterChildMappingFinalDetailModel request)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/MasterMapping/addOperationMasterChildMapping";

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
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationMasterChildMapping");
            }
            return data;
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
                        //await App.Current.MainPage.DisplayAlert("Paramhans Wires", response.ReasonPhrase, "Ok");
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

        public async Task<List<PickListModel>> PickListMasterList(bool booking = false)
        {
            List<PickListModel> itemList = new List<PickListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = string.Empty;
                    if (booking)
                    {
                        apiUrl = $"{BaseURL}Booking_PickListMasterList";
                    }
                    else
                    {
                        apiUrl = $"{BaseURL}Dispatch_PickListMasterList";
                    }
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
        public async Task<List<PickOutProductListModel>> GetPickOutWiseProductList(int pickOutId, bool booking = false)
        {
            List<PickOutProductListModel> itemList = new List<PickOutProductListModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = string.Empty;
                    if (booking)
                    {
                        apiUrl = $"{BaseURL}Booking_GetPickOutWiseProductList?PickOutId={pickOutId}";
                    }
                    else
                    {
                        apiUrl = $"{BaseURL}Dispatch_GetPickOutWiseProductList?PickOutId={pickOutId}";
                    }
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
        public async Task<List<PickOutProductSpoolModel>> GetPickOutWiseProductWiseSpoolList(int pickOutId, int productId, bool booking = false)
        {
            List<PickOutProductSpoolModel> result = new List<PickOutProductSpoolModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = string.Empty;
                    if (booking)
                    {
                        apiUrl = $"{BaseURL}Booking_GetPickOutWiseProductWiseSpoolList?PickOutId={pickOutId}&ItemId={productId}";
                    }
                    else
                    {
                        apiUrl = $"{BaseURL}Dispatch_GetPickOutWiseProductWiseSpoolList?PickOutId={pickOutId}&ItemId={productId}";
                    }
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
        public async Task<List<PickOutProductSpoolConditionModel>> GetPickOutWiseProductWiseSpoolWiseConditionList(int pickOutId, int productId, int spoolId, bool booking = false)
        {
            List<PickOutProductSpoolConditionModel> data = new List<PickOutProductSpoolConditionModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = string.Empty;
                    if (booking)
                    {
                        apiUrl = $"{BaseURL}Booking_GetPickOutWiseProductWiseSpoolWiseConditionList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}";
                    }
                    else
                    {
                        apiUrl = $"{BaseURL}Dispatch_GetPickOutWiseProductWiseSpoolWiseConditionList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}";
                    }
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
        public async Task<List<PickOutProductSpoolConditionSizeModel>> GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList(int pickOutId, int productId, int spoolId, int conditionId, bool booking = false)
        {
            List<PickOutProductSpoolConditionSizeModel> data = new List<PickOutProductSpoolConditionSizeModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = string.Empty;
                    if (booking)
                    {
                        apiUrl = $"{BaseURL}Booking_GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}&ConditionId={conditionId}";
                    }
                    else
                    {
                        apiUrl = $"{BaseURL}Dispatch_GetPickOutWiseProductWiseSpoolWiseConditionWiseSizeList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}&ConditionId={conditionId}";
                    }
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

        public async Task<List<BookingBarcodeDetailModel>> GetBookingBarcodeDetail(string packType, int spoolId, int conditionId, int sizeId, int gradeId, int itemId, string scanBarcode)
        {
            List<BookingBarcodeDetailModel> data = new List<BookingBarcodeDetailModel>();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/BookingStock/BookingStock_GetScanBarcodeDetail?&PackType={packType}&SpoolId={spoolId}&ConditionId={conditionId}&SizeId={sizeId}&GradeId={gradeId}&ScanBarcode={scanBarcode}&ItemId={itemId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode && response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<List<BookingBarcodeDetailModel>>(content);
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
                ExceptionHandler.HandleException(ex, "AppLogic - GetBookingBarcodeDetail");
                return null;
            }
        }

        public async Task<bool> AddOperationBookingStockOutChild(BookingBarcodeFinalDetailModel request)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/BookingStock/addOperationBookingStockIn_StockBookChild";

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
                ExceptionHandler.HandleException(ex, "AppLogic - AddOperationBookingStockOutChild");
            }
            return data;
        }

        #endregion
    }
}
