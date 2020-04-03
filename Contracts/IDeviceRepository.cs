using Entities.Models;
using System.Collections.Generic;

namespace Contracts
{
    public interface IDeviceRepository : IRepositoryBase<Device>
    {
        IEnumerable<Device> GetAllDevices();
        Device GetDeviceById(int deviceId);
        Device GetDeviceWithDetails(int deviceId);
    }
}
