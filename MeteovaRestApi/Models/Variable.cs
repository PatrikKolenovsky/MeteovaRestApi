using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class Variable
    {
        public Variable()
        {
            Valint = new HashSet<Valint>();
            Valreal = new HashSet<Valreal>();
            Valstring = new HashSet<Valstring>();
        }

        public int VariableId { get; set; }
        public string Name { get; set; }
        public string Pub { get; set; }
        public int ModuleId { get; set; }
        public int VarDefId { get; set; }
        public string Description { get; set; }

        public virtual Module Module { get; set; }
        public virtual Vardef VarDef { get; set; }
        public virtual ICollection<Valint> Valint { get; set; }
        public virtual ICollection<Valreal> Valreal { get; set; }
        public virtual ICollection<Valstring> Valstring { get; set; }
    }
}
