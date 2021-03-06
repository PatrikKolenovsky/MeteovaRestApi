﻿using Contracts;
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

        public List<Module> GetModules()
        {
            return FindAll().ToList();
        }
        public Module GetModuleById(int id)
        {
            return FindByCondition(module => module.ModuleId == id).FirstOrDefault();
        }
        public void CreateModule(Module module)
        {
            Create(module);
        }

        public void DeleteModule(Module module)
        {
            Delete(module);
        }

        public Module ModuleByDevice(int deviceId, int id)
        {
            throw new System.NotImplementedException();
        }

        public PagedList<Module> ModulesByDevice(int deviceId, ModuleParameters parameters)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateModule(Module module)
        {
            Update(module);
        }
    }
}
