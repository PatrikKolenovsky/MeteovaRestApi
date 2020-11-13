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
        public string DeviceName { get; set; }
        public string Ip { get; set; }
        public int Port { get; set; }
        public string ComServIp { get; set; }
        public int ComServPort { get; set; }
        public bool InUse { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Module> Module { get; set; }
    }
}
