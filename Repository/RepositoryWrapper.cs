using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly MeteovaContext _meteovaContext;
        private IEnvidataRepository _envidata;
        private IDeviceRepository _device;
        private IVariableRepository _variable;
        private IModuleRepository _module;
        private IDevicenameRepository _devicename;
        private IComtypeRepository _comtype;

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

        public IEnvidataRepository Envidata
        {
            get
            {
                if (_envidata == null)
                {
                    _envidata = new EnvidataRepository(_meteovaContext);
                }

                return _envidata;
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

        public IDevicenameRepository Devicename
        {
            get
            {
                if (_variable == null)
                {
                    _devicename = new DevicenameRepository(_meteovaContext);
                }
                return _devicename;
            }
        }

        public IComtypeRepository Comtype
        {
            get
            {
                if (_variable == null)
                {
                    _comtype = new ComtypeRepository(_meteovaContext);
                }
                return _comtype;
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
