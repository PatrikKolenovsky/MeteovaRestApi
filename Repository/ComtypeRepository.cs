using Contracts;
using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class ComtypeRepository : RepositoryBase<Comtype>, IComtypeRepository
    {
        public ComtypeRepository(MeteovaContext meteovaContext)
            :base(meteovaContext)
        {
        }
        public void CreateComtype(Comtype comtype)
        {
            Create(comtype);
        }

        public void DeleteComtype(Comtype comtype)
        {
            Delete(comtype);
        }

        public List<Comtype> GetComtypes()
        {
            return FindAll().ToList();
        }

        public Comtype GetComtypeById(int id)
        {
            return FindByCondition(com => com.ComTypeId == id).FirstOrDefault();
        }

        public void UpdateComtype(Comtype comtype)
        {
            Update(comtype);
        }
    }
}
