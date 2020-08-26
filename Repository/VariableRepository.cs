using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class VariableRepository : RepositoryBase<Variable>, IVariableRepository
    {
        public VariableRepository(MeteovaContext meteovaContext)
            : base(meteovaContext)
        {
        }

        public IEnumerable<Variable> VariableByModule(int moduleId)
        {
            return FindByCondition(a => a.ModuleId.Equals(moduleId)).ToList();
        }
    }
}
