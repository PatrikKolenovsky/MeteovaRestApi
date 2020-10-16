using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IModuletypeRepository
    {
        List<Moduletype> GetModuletypes();
        Moduletype GetModuletypeById(int id);
        void CreateModuletype(Moduletype module);
        void UpdateModuletype(Moduletype module);
        void DeleteModuletype(Moduletype module);
    }
}
