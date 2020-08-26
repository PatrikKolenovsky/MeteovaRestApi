using Contracts;
using Entities;
using Entities.Models;
using MeteovaRestApi.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    class ModuleRepository : RepositoryBase<Module>, IModuleRepository
    {
        public ModuleRepository(MeteovaContext meteovaContext)
            : base(meteovaContext)
        {
        }

        public Module ModuleByDevice(int deviceId, int id)
        {
            throw new System.NotImplementedException();
        }

        public PagedList<Module> ModulesByDevice(int deviceId, ModuleParameters parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
