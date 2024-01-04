using System;
using System.Collections.Generic;
using System.Text;

namespace PHWAndriod.Models
{
    public class MasterBarcodeDetailModel
    {
        public int MasterId { get; set; }
        public string MasterBarcode { get; set; }
        public string MaterialType { get; set; }
        public string ItemName { get; set; }
        public int ItemId { get; set; }
    }
}
