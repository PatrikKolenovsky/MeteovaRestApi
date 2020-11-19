using Contracts;
using Entities;
using Entities.Models;
using MeteovaRestApi.Extensions;
using Microsoft.EntityFrameworkCore;
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

        public List<Module> GetModules()
        {
            return FindAll()
                .Include(d => d.Device)
                .Include(x => x.ModuleType).ThenInclude(mk => mk.Maker)
                .ToList();
        }
        public Module GetModuleById(int id)
        {
            return FindByCondition(module => module.ModuleId.Equals(id))
                .Include(d => d.Device)
                .Include(x => x.ModuleType).ThenInclude(mk => mk.Maker)
                .FirstOrDefault();
        }
        public void CreateModule(Module module)
        {
            Create(module);
        }

        public void DeleteModule(Module module)
        {
            Delete(module);
        }

        public Module GetModuleByDevice(int deviceId)
        {
            return FindByCondition(md => md.DeviceId.Equals(deviceId))
                .Include(d => d.Device)
                .Include(type => type.ModuleType).ThenInclude(mk => mk.Maker)
                .FirstOrDefault();
        }

        public PagedList<Module> ModulesByDevice(int deviceId, ModuleParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateModule(Module module)
        {
            Update(module);
        }

        public List<Module> GetOtherModulesByDevice(int deviceId)
        {
            return FindByCondition(md => md.DeviceId != deviceId)
                .Include(d => d.Device)
                .Include(x => x.ModuleType).ThenInclude(mk => mk.Maker)
                .ToList();
        }
    }
}
