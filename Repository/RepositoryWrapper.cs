using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Sg1Context _sg1Context;
        private IDeviceRepository _device;
        private IVariableRepository _variable;

        public IDeviceRepository Device
        {
            get
            {
                if (_device == null)
                {
                    _device = new DeviceRepository(_sg1Context);
                }

                return _device;
            }
        }

        public IVariableRepository Variable
        {
            get
            {
                if (_variable == null)
                {
                    _variable = new VariableRepository(_sg1Context);
                }

                return _variable;
            }
        }

        public RepositoryWrapper(Sg1Context sg1Context)
        {
            _sg1Context = sg1Context;
        }

        public void Save()
        {
            _sg1Context.SaveChanges();
        }

    }
}
