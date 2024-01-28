namespace PHWAndriod.Models
{
    public class CancelBookingModel
    {
        public int Id { get; set; }
        public string ScanBarcode { get; set; }
        public string ItemDescription { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string MaterialType { get; set; }
    }
}
