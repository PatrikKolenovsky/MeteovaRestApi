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
        public DeviceRepository(MeteovaContext meteovaContext)
            : base(meteovaContext)
        {
        }

        public PagedList<Device> GetDevices(DeviceParameters deviceParameters)
        {
            var devices = FindAll();

            SearchByLocation(ref devices, deviceParameters.Location);

            return PagedList<Device>.ToPagedList(devices, deviceParameters.PageNumber, deviceParameters.PageSize);
        }

        // Search implementation
        private void SearchByLocation(ref IQueryable<Device> devices, string deviceLocation)
        {
            if (!devices.Any() || string.IsNullOrWhiteSpace(deviceLocation))
                return;

            devices = devices.Where(d => d.Device_location.ToLower().Contains(deviceLocation.Trim().ToLower()));
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
