using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class Valstring
    {
        public long ValStringId { get; set; }
        public int VariableId { get; set; }
        public string Value { get; set; }
        public DateTime Time { get; set; }

        public virtual Variable Variable { get; set; }
    }
}
