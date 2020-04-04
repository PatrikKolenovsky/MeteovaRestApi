using Contracts;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(Sg1Context sg1Context)
            : base(sg1Context)
        {
        }

        public IEnumerable<Module> ModuleByDevice(int moduleId)
        {
            return FindByCondition(a => a.DeviceId.Equals(moduleId)).ToList();
        }
    }
}
