using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private MeteovaContext _meteovaContext;
        private IDeviceRepository _device;
        private IVariableRepository _variable;
        private IModuleRepository _module;

        public IDeviceRepository Device
        {
            get
            {
                if (_device == null)
                {
                    _device = new DeviceRepository(_meteovaContext);
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
                    _variable = new VariableRepository(_meteovaContext);
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
                    _module = new ModuleRepository(_meteovaContext);
                }

                return _module;
            }
        }

        public RepositoryWrapper(MeteovaContext meteovaContext)
        {
            _meteovaContext = meteovaContext;
        }

        public void Save()
        {
            _meteovaContext.SaveChanges();
        }

    }
}
