using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class Location
    {
        public Location()
        {
            Module = new HashSet<Module>();
        }

        public int LocationId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Module> Module { get; set; }
    }
}
