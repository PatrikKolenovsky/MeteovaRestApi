using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ValrealDto
    {
        public long ValRealId { get; set; }
        public int VariableId { get; set; }
        public double Value { get; set; }
        public DateTime Time { get; set; }
    }
}
