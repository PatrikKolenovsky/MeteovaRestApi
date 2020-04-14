using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class VariableDto
    {
        public int VariableId { get; set; }
        public string Name { get; set; }
        public string Pub { get; set; }
        public int VarDefId { get; set; }
        public string Description { get; set; }

        public ICollection<ValintDto> Valint { get; set; }
        public ICollection<ValrealDto> Valreal { get; set; }
        public ICollection<ValstringDto> Valstring { get; set; }
    }
}
