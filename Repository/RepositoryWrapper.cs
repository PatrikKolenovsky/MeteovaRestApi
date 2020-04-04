using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private Sg1Context _sg1Context;
        private IDeviceRepository _device;
        private IVariableRepository _variable;
        private IModuleRepository _module;

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

        public IModuleRepository Module
        {
            get
            {
                if (_variable == null)
                {
                    _module = new ModuleRepository(_sg1Context);
                }

                return _module;
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
