using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(MeteovaContext meteovaContext)
            : base(meteovaContext)
        {
        }

        public IEnumerable<Device> GetAllDevices()
        {
            return FindAll()
                .ToList();
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
