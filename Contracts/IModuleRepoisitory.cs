using Entities.Models;
using MeteovaRestApi.Extensions;

namespace Contracts
{
    public interface IModuleRepository : IRepositoryBase<Module>
    {
        PagedList<Module> ModulesByDevice(int deviceId, ModuleParameters parameters);
        Module ModuleByDevice(int deviceId, int id);
    }
}
