using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Devicename
    {
        public Devicename()
        {
            Device = new HashSet<Device>();
        }

        public int DeviceNameId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Device> Device { get; set; }
    }
}
