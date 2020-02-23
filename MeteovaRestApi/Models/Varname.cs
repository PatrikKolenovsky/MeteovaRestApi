using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class Varname
    {
        public Varname()
        {
            Vardef = new HashSet<Vardef>();
        }

        public int VarNameId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Vardef> Vardef { get; set; }
    }
}
