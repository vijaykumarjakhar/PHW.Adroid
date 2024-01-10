using System;
using System.Collections.Generic;
using System.Text;

namespace PHWAndriod.Models
{
    public class StockInBarcodeDetail
    {
        public int StockId { get; set; }
        public string InventoryType { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string Spool { get; set; }
        public int SpoolId { get; set; }
        public string Grade { get; set; }
        public int GradeId { get; set; }
        public int ConditionId { get; set; }
        public int SizeId { get; set; }
        public int MachineId { get; set; }
        public double? TareWeight { get; set; }  // Note: Nullable double
        public double? NetWeight { get; set; }   // Note: Nullable double
        public double? GrossWeight { get; set; } // Note: Nullable double
        public double? ReGrossWeight { get; set; } // Note: Nullable double
        public string CoilDia { get; set; }
        public string LotNo { get; set; }
        public string PalletBarcode { get; set; }
        public string BoxBarcode { get; set; }
        public string TranType { get; set; }
        public int SpoolQty { get; set; }
        public int BoxQty { get; set; }
        public int PalletQty { get; set; }
        public double? StockInQty { get; set; }  // Note: Nullable double
        public double? StockOutQty { get; set; } // Note: Nullable double
        public double? CurrentQty { get; set; }  // Note: Nullable double
    }

}
