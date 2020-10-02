using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDeviceRepository Device { get; }
        IEnvidataRepository Envidata { get; }
        IVariableRepository Variable { get; }
        IModuleRepository Module { get; }
        IDevicenameRepository Devicename { get; }
        IComtypeRepository Comtype { get; }
        void Save();
    }
}
