using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Module
{
    public class ModuleDto
    {
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Device.DeviceDto Device { get; set; }
        public IEnumerable<VariableDto> Variable { get; set; }
        public Moduletype.ModuletypeDto ModuleType { get; set; }
    }
}
