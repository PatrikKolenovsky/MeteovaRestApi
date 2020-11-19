using Entities.Models;
using MeteovaRestApi.Extensions;
using System.Collections.Generic;

namespace Contracts
{
    public interface IModuleRepository : IRepositoryBase<Module>
    {
        PagedList<Module> ModulesByDevice(int deviceId, ModuleParameters parameters);
        List<Module> GetOtherModulesByDevice(int deviceId);
        List<Module> GetModuleByDevice(int deviceId);
        List<Module> GetModules();        
        Module GetModuleById(int id);
        void CreateModule(Module module);
        void UpdateModule(Module module);
        void DeleteModule(Module module);
    }
}
