using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class ModuleDto
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ModuleTypeId { get; set; }
        public string Description { get; set; }
    }
}
