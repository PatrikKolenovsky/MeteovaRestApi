using Entities.DataTransferObjects.Location;
using Entities.DataTransferObjects.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.Device
{
    public class DeviceDto
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string ComServIp { get; set; }
        public int ComServPort { get; set; }
        public bool InUse { get; set; }
        public string Description { get; set; }
        public int LocationId { get; set; }

        public LocationDto Location { get; set; }
        public IEnumerable<ModuleDto> Module { get; set; }
    }
}
