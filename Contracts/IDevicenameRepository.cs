using Entities.Models;
using MeteovaRestApi.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts
{
    public interface IDevicenameRepository
    {
        List<Devicename> GetAllDevicename();
        void CreateDevicename(Devicename devicename);
        void UpdateDevicename(Devicename devicename);
        void DeleteDevicename(Devicename devicename);
    }
}
