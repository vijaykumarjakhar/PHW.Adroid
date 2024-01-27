namespace PHWAndriod.Models
{
    public class StockInFinalDetailModel
    {
        private StockInBarcodeDetail result;

        public StockInFinalDetailModel(StockInBarcodeDetail result)
        {
            this.result = result;
        }

        public int StockId => result.StockId;
        public string InventoryType => result.InventoryType;
        public string ItemCode => result.ItemCode;
        public string ItemName => result.ItemName;
        public int SpoolId => result.SpoolId;
        public int GradeId => result.GradeId;
        public int ConditionId => result.ConditionId;
        public int SizeId => result.SizeId;
        public int MachineId => result.MachineId;
        public double? TareWeight => result.TareWeight;
        public double? NetWeight => result.NetWeight;
        public double? GrossWeight => result.GrossWeight;
        public double? ReGrossWeight => result.ReGrossWeight;
        public string CoilDia => result.CoilDia;
        public string LotNo => result.LotNo;
        public string PalletBarcode => result.PalletBarcode;
        public string BoxBarcode => result.BoxBarcode;
        public string TranType => result.TranType;
        public int SpoolQty => result.SpoolQty;
        public int BoxQty => result.BoxQty;
        public int PalletQty => result.PalletQty;
        public int StockInQty => result.StockInQty;
        public int StockOutQty => result.StockOutQty;
        public int CurrentQty => result.CurrentQty;
        public string CreatedBy => "Admin";
        public int CompanyId => 0;
        public int FYId => 0;
        public int VerticalId => 0;
    }
}
