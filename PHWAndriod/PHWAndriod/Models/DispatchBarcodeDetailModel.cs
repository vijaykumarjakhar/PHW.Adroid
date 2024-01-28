namespace PHWAndriod.Models
{
    public class DispatchBarcodeDetailModel
    {
        public int StockId { get; set; }
        public string InventoryType { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public int SpoolId { get; set; }
        public int GradeId { get; set; }
        public int ConditionId { get; set; }
        public int SizeId { get; set; }
        public int MachineId { get; set; }
        public double TareWeight { get; set; }
        public double NetWeight { get; set; }
        public double GrossWeight { get; set; }
        public double ReGrossWeight { get; set; }
        public string CoilDia { get; set; }
        public string LotNo { get; set; }
        public string PalletBarcode { get; set; }
        public string BoxBarcode { get; set; }
        public string TranType { get; set; }
        public int SpoolQty { get; set; }
        public int BoxQty { get; set; }
        public int PalletQty { get; set; }
    }
}
