using System;
using System.Collections.Generic;
using System.Text;

namespace PHWAndriod.Models
{
    public class PhysicalListModel
    {
        public int Id { get; set; }
        public string ScanBarcode { get; set; }
        public string SystemIP { get; set; }
        public DateTime ScanDateTime { get; set; }
        public string CreatedBY { get; set; }
    }
}
