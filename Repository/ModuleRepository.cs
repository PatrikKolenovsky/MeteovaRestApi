using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(Sg1Context sg1Context)
            : base(sg1Context)
        {
        }
    }
}
