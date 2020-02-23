using System;
using System.Collections.Generic;

namespace MeteovaRestApi.Models
{
    public partial class Vardef
    {
        public Vardef()
        {
            Variable = new HashSet<Variable>();
        }

        public int VarDefId { get; set; }
        public int ModuleTypeId { get; set; }
        public int VarNameId { get; set; }
        public int VarTypeId { get; set; }

        public virtual Moduletype ModuleType { get; set; }
        public virtual Varname VarName { get; set; }
        public virtual Vartype VarType { get; set; }
        public virtual ICollection<Variable> Variable { get; set; }
    }
}
