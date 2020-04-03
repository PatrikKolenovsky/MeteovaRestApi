using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IDeviceRepository Device { get; }
        IVariableRepository Variable { get; }
        void Save();
    }
}
