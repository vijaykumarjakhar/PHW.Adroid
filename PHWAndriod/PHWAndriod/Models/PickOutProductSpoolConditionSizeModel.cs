using System;
using System.Collections.Generic;
using System.Text;

namespace PHWAndriod.Models
{
    public class PickOutProductSpoolConditionSizeModel
    {
        public int SizeId { get; set; }

        public int ConditionId { get; set; }

        public int SpoolId { get; set; }

        public int ItemId { get; set; }

        public int PickOutId { get; set; }

        public string Size { get; set;}
    }
}
