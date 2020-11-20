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
            var devices = FindAll().AsNoTracking();

            SearchByLocation(ref devices, deviceParameters.Location);

            return PagedList<Device>.ToPagedList(devices, deviceParameters.PageNumber, deviceParameters.PageSize);
        }

        public PagedList<Device> GetDevicesWithDetails(DeviceParameters deviceParameters)
        {
            var devices = FindAll()
                .Include(md => md.Module).ThenInclude(var => var.Variable).ThenInclude(vint => vint.Valint)
                .Include(md => md.Module).ThenInclude(var => var.Variable).ThenInclude(vreal => vreal.Valreal)
                .Include(md => md.Module).ThenInclude(var => var.Variable).ThenInclude(vstring => vstring.Valstring)
                .Include(md => md.Module).ThenInclude(mt => mt.ModuleType).ThenInclude(mk => mk.Maker).AsNoTracking();

            return PagedList<Device>.ToPagedList(devices, deviceParameters.PageNumber, deviceParameters.PageSize);
        }

        
        private void SearchByLocation(ref IQueryable<Device> devices, string deviceLocation)
        {
            if (!devices.Any() || string.IsNullOrWhiteSpace(deviceLocation))
                return;

            devices = FindAll().Where(d => d.Address.Trim().ToLower().Contains(deviceLocation.Trim().ToLower())).AsNoTracking();
        }

        public Device GetDeviceById(int deviceId)
        {
            return FindByCondition(device => device.DeviceId.Equals(deviceId))
                .AsNoTracking()
                .FirstOrDefault();
        }

        public Device GetDeviceWithDetails(int deviceId)
        {
            return FindByCondition(device => device.DeviceId.Equals(deviceId))
                    .Include(md => md.Module).ThenInclude(var => var.Variable).ThenInclude(vali => vali.Valint)
                    .Include(md => md.Module).ThenInclude(var => var.Variable).ThenInclude(valr => valr.Valreal)
                    .Include(md => md.Module).ThenInclude(var => var.Variable).ThenInclude(vals => vals.Valstring)
                    .AsNoTracking()
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
