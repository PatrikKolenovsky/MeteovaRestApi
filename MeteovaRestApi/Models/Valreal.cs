using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class Valreal
    {
        public long ValRealId { get; set; }
        public int VariableId { get; set; }
        public double Value { get; set; }
        public DateTime Time { get; set; }

        public virtual Variable Variable { get; set; }
    }
}
