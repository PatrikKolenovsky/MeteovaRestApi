using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Moduletype
{
    public class ModuletypeCreateDto
    {
        public int ModuleTypeId { get; set; }
        public string Name { get; set; }
        public int MakerId { get; set; }
        public string Description { get; set; }
    }
}
