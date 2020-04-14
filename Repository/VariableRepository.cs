using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class VariableRepository : RepositoryBase<Variable>, IVariableRepository
    {
        public VariableRepository(Sg1Context sg1Context)
            : base(sg1Context)
        {
        }

        public IEnumerable<Variable> VariableByModule(int moduleId)
        {
            return FindByCondition(a => a.ModuleId.Equals(moduleId)).ToList();
        }
    }
}
