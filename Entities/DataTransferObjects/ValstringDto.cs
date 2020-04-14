using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ValstringDto
    {
        public long ValStringId { get; set; }
        public int VariableId { get; set; }
        public string Value { get; set; }
        public DateTime Time { get; set; }
    }
}
