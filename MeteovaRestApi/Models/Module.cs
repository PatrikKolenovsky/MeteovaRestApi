using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class Module
    {
        public Module()
        {
            Variable = new HashSet<Variable>();
        }

        public int ModuleId { get; set; }
        public string Name { get; set; }
        public int LocationId { get; set; }
        public int ModuleTypeId { get; set; }
        public int DeviceId { get; set; }
        public string Description { get; set; }

        public virtual Device Device { get; set; }
        public virtual Location Location { get; set; }
        public virtual Moduletype ModuleType { get; set; }
        public virtual ICollection<Variable> Variable { get; set; }
    }
}
