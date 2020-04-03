using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class DeviceDto
    {
        public int DeviceId { get; set; }
        public int DeviceNameId { get; set; }
        public string Description { get; set; }
        public string Device_location { get; set; }

        public IEnumerable<ModuleDto> Module { get; set; }
    }
}
