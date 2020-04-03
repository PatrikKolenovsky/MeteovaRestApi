using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Moduletype
    {
        public Moduletype()
        {
            Module = new HashSet<Module>();
            Vardef = new HashSet<Vardef>();
        }

        public int ModuleTypeId { get; set; }
        public string Name { get; set; }
        public int MakerId { get; set; }
        public string Description { get; set; }

        public virtual Maker Maker { get; set; }
        public virtual ICollection<Module> Module { get; set; }
        public virtual ICollection<Vardef> Vardef { get; set; }
    }
}
