using Contracts;
using Entities;
using Entities.Models;
using MeteovaRestApi.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(Sg1Context sg1Context)
            : base(sg1Context)
        {
        }

        public PagedList<Device> GetDevices(DeviceParameters deviceParameters)
        {
            return PagedList<Device>.ToPagedList(FindAll(), deviceParameters.PageNumber, deviceParameters.PageSize);
        }

        public Device GetDeviceById(int deviceId)
        {
            return FindByCondition(device => device.DeviceId.Equals(deviceId))
                .FirstOrDefault();
        }

        public Device GetDeviceWithDetails(int deviceId)
        {
            return FindByCondition(device => device.DeviceId.Equals(deviceId))
                    .Include(md => md.Module)
                        .ThenInclude(var => var.Variable)
                            .ThenInclude(vali => vali.Valint)
                    .Include(md => md.Module)
                        .ThenInclude(var => var.Variable)
                            .ThenInclude(valr => valr.Valreal)
                    .Include(md => md.Module)
                        .ThenInclude(var => var.Variable)
                            .ThenInclude(vals => vals.Valstring)
                    .FirstOrDefault();
        }

        public void CreateDevice(Device device)
        {
            Create(device);
        }

        public void UpdateDevice(Device device)
        {
            Update(device);
        }

        public void DeleteDevice(Device device)
        {
            Delete(device);
        }
    }
}
