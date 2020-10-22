using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Moduletype
{
    public class ModuletypeDto
    {
        public int ModuleTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Maker Maker { get; set; }
    }
}
