using Newtonsoft.Json;
using PHWAndriod.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
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

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<List<ItemTypeModel>>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch(Exception ex)
            {
                
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

                    if (response.IsSuccessStatusCode)
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

                    if (response.IsSuccessStatusCode)
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
                
                return null;
            }
        }

        #endregion

        #region PhysicalVerification
        public async Task<PhysicalListModel> GetPhysicalList ()
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/getphysicallist";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public async Task<PhysicalListModel> GetPhysicalListById(int id, string createdBy)
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/getphysicallistbyid?id={id}&CreatedBY={createdBy}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public async Task<PhysicalListModel> AddOperationPhysicalVerify(PhysicalListModel request)
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/addOperationPhysicalVerfiy";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public async Task<PhysicalListModel> UpdateOperationPhysicalVerfiy(PhysicalListModel request)
        {
            PhysicalListModel data = new PhysicalListModel();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/updateOperationPhysicalVerfiy";

                    string jsonData = JsonConvert.SerializeObject(request);
                    HttpContent requestContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PutAsync(apiUrl, requestContent);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PhysicalListModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public async Task<bool> DeleteOperationPhysical(int id)
        {
            bool data = false;
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/PhysicalVerification/deleteOperationPhysical?Id={id}";

                    HttpResponseMessage response = await client.DeleteAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        return data = true;
                    }
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                
                return false;
            }
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

                    if (response.IsSuccessStatusCode)
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
                
                return null;
            }
        }
        public async Task<PickOutProductListModel> GetPickOutWiseProductList(int pickOutId)
        {
            PickOutProductListModel itemList = new PickOutProductListModel();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductList?PickOutId={pickOutId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        itemList = JsonConvert.DeserializeObject<PickOutProductListModel>(content);
                        return itemList;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public async Task<PickOutProductSpoolModel> GetPickOutWiseProductWiseSpoolList(int pickOutId, int productId)
        {
            PickOutProductSpoolModel result = new PickOutProductSpoolModel();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolList?PickOutId={pickOutId}&ItemId={productId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<PickOutProductSpoolModel>(content);
                        return result;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }
        public async Task<PickOutProductSpoolConditionModel> GetPickOutWiseProductWiseSpoolWiseConditionList(int pickOutId, int productId, int spoolId)
        {
            PickOutProductSpoolConditionModel data = new PickOutProductSpoolConditionModel();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}GetPickOutWiseProductWiseSpoolWiseConditionList?PickOutId={pickOutId}&ItemId={productId}&SpoolId={spoolId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<PickOutProductSpoolConditionModel>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
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

                    if (response.IsSuccessStatusCode)
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
                
                return null;
            }
        }
        #endregion

        #region StockIn

        public async Task<StockInBarcodeDetail> StockInGetScanBarcodeDetail(int itemTypeId, string scanBarcode)
        {
            StockInBarcodeDetail data = new StockInBarcodeDetail();
            try
            {

                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = $"{BaseURL}api/StockIn/StockIn_GetScanBarcodeDetail?ScanBarcode={scanBarcode}&ItemTypeId={itemTypeId}";
                    HttpResponseMessage response = await client.GetAsync(apiUrl);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        data = JsonConvert.DeserializeObject<StockInBarcodeDetail>(content);
                        return data;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                
                return null;
            }
        }


        #endregion
    }
}
