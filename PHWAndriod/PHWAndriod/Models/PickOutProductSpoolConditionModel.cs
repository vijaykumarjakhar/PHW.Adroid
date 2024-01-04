using System;
using System.Collections.Generic;
using System.Text;

namespace PHWAndriod.Models
{
    public class PickOutProductSpoolConditionModel
    {
        public int ConditionId { get; set; }

        public int SpoolId { get; set; }

        public int ItemId { get; set; }

        public int PickOutId { get; set; }

        public string Condition { get; set; }

    }
}
