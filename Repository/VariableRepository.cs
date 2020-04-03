using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class VariableRepository : RepositoryBase<Variable>, IVariableRepository
    {
        public VariableRepository(Sg1Context sg1Context)
            : base(sg1Context)
        {
        }
    }
}
