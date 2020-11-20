using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    class ModuletypeRepository : RepositoryBase<Moduletype>, IModuletypeRepository
    {
        public ModuletypeRepository(MeteovaContext meteovaContext)
            : base(meteovaContext)
        {
        }

        public void CreateModuletype(Moduletype module)
        {
            Create(module);
        }

        public void DeleteModuletype(Moduletype module)
        {
            Delete(module);
        }

        public Moduletype GetModuletypeById(int id)
        {
            return FindByCondition(mt => mt.ModuleTypeId.Equals(id)).Include(mk => mk.Maker).AsNoTracking().FirstOrDefault();
        }

        public List<Moduletype> GetModuletypes()
        {
            return FindAll().Include(mk => mk.Maker).AsNoTracking()
                .ToList();
        }

        public void UpdateModuletype(Moduletype module)
        {
            Update(module);
        }
    }
}
