using Contracts;
using Entities;
using Entities.Models;
using MeteovaRestApi.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class DevicenameRepository : RepositoryBase<Devicename>, IDevicenameRepository
    {
        public DevicenameRepository(MeteovaContext meteovaContext)
            :base(meteovaContext)
        {
        }

        public void CreateDevicename(Devicename devicename)
        {
            Create(devicename);
        }

        public void DeleteDevicename(Devicename devicename)
        {
            Delete(devicename);
        }

        public List<Devicename> GetAllDevicename()
        {
            return FindAll().ToList();
        }

        public Devicename GetDevicenameById(int id)
        {
            return FindByCondition(devn => devn.DeviceNameId == id).FirstOrDefault();
        }

        public void UpdateDevicename(Devicename devicename)
        {
            Update(devicename);
        }
    }
}
