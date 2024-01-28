namespace PHWAndriod.Models
{
    public class CancelBookingFinalModel
    {
        CancelBookingModel BaseModel { get; set; }

        public CancelBookingFinalModel(CancelBookingModel baseModel)
        {
            BaseModel = baseModel;
        }

        public int Id => BaseModel.Id;
        public string ScanBarcode => BaseModel.ScanBarcode;
        public string CreatedBy => "Admin";
    }
}
