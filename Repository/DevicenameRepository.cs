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

        public List<Devicename> GetAllDevicename()
        {
            var deviceNames = FindAll().ToList();

            return deviceNames;
        }
    }
}
