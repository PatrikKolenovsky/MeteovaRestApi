using Entities.Models;
using MeteovaRestApi.Extensions;

namespace Contracts
{
    public interface IDeviceRepository : IRepositoryBase<Device>
    {
        PagedList<Device> GetDevices(DeviceParameters deviceParameters);
        PagedList<Device> GetDevicesWithDetails(DeviceParameters deviceParameters);
        Device GetDeviceById(int deviceId);
        Device GetDeviceWithDetails(int deviceId);
        void CreateDevice(Device device);
        void UpdateDevice(Device device);
        void DeleteDevice(Device device);
    }
}
