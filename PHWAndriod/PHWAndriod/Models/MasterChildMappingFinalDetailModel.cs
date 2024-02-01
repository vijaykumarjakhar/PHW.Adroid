namespace PHWAndriod.Models
{
    public class MasterChildMappingFinalDetailModel
    {
        private MasterBarcodeDetailModel Master;
        private string ChildBarcodeEntry;
        public MasterChildMappingFinalDetailModel(MasterBarcodeDetailModel master, string child)
        {
            Master = master;
            ChildBarcodeEntry = child;
        }
        public int MasterId => Master.MasterId;
        public string MaterialType => Master.MaterialType;
        public int ItemId => Master.ItemId;
        public string ItemName => Master.ItemName;
        public string MasterBarcode => Master.MasterBarcode;
        public string ChildBarcode => ChildBarcodeEntry;
        public string CreatedBy => "Admin";
    }
}
