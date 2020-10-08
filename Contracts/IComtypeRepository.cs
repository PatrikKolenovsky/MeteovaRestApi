using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IComtypeRepository
    {
        List<Comtype> GetComtypes();
        Comtype GetComtypeById(int id);
        void CreateComtype(Comtype comtype);
        void UpdateComtype(Comtype comtype);
        void DeleteComtype(Comtype comtype);
    }
}
