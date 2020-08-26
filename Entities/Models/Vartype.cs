using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Vartype
    {
        public Vartype()
        {
            Vardef = new HashSet<Vardef>();
        }

        public int VarTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vardef> Vardef { get; set; }
    }
}
