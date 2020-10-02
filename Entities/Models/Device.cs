using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public partial class Device
    {
        public Device()
        {
            Module = new HashSet<Module>();
        }

        public int DeviceId { get; set; }
        public string DeviceIDVar { get; set; }
        public int DeviceNameId { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string ComServIp { get; set; }
        public int ComServPort { get; set; }
        public int ComTypeId { get; set; }
        public bool InUse { get; set; }
        public string Description { get; set; }
        public string DeviceLocation { get; set; }

        public virtual Comtype ComType { get; set; }
        public virtual Devicename DeviceName { get; set; }
        public virtual ICollection<Module> Module { get; set; }
    }
}
