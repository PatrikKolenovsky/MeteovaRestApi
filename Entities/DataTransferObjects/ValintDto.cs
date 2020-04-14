using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ValintDto
    {
        public long ValIntId { get; set; }
        public int VariableId { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
