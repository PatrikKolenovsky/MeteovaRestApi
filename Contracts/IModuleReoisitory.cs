using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IModuleRepository : IRepositoryBase<Module>
    {
        IEnumerable<Module> ModuleByDevice(int deviceId);
    }
}
