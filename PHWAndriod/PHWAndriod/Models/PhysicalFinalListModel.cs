using System;

namespace PHWAndriod.Models
{
    public class PhysicalFinalListModel
    {
        PhysicalListModel BaseModel { get; set; }
        public PhysicalFinalListModel(PhysicalListModel baseModel)
        {
            BaseModel = baseModel;
        }
        public int Id => BaseModel.Id;
        public string ScanBarcode => BaseModel.ScanBarcode;
        public string SystemIP => ""; //TODO : Check for IP
        public DateTime ScanDateTime => DateTime.Now;
        public string CreatedBY => "Admin";
    }
}
