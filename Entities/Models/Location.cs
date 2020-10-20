using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Location
    {
        public Location()
        {
            Device = new HashSet<Device>();
            Module = new HashSet<Module>();
        }

        public int LocationId { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }

        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Module> Module { get; set; }
    }
}
