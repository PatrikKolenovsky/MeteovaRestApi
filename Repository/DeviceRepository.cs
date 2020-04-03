using Contracts;
using Entities;
using Entities.Models;

namespace Repository
{
    public class DeviceRepository : RepositoryBase<Device>, IDeviceRepository
    {
        public DeviceRepository(Sg1Context sg1Context)
            : base(sg1Context)
        {
        }
    }
}
