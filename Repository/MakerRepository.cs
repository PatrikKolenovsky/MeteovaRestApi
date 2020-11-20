using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    class MakerRepository : RepositoryBase<Maker>, IMakerRepository
    {
        public MakerRepository(MeteovaContext meteovaContext)
            : base(meteovaContext)
        {
        }

        public void CreateMaker(Maker maker)
        {
            Create(maker);
        }

        public void DeleteMaker(Maker maker)
        {
            Delete(maker);
        }

        public Maker GetMakerById(int id)
        {
            return FindByCondition(m => m.MakerId.Equals(id)).AsNoTracking().FirstOrDefault();
        }

        public List<Maker> GetMakers()
        {
            return FindAll().AsNoTracking().ToList();
        }

        public void UpdateMaker(Maker maker)
        {
            Update(maker);
        }
    }
}
