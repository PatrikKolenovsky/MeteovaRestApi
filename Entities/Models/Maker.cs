using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Maker
    {
        public Maker()
        {
            Moduletype = new HashSet<Moduletype>();
        }

        public int MakerId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Moduletype> Moduletype { get; set; }
    }
}
