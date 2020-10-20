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
        private IModuletypeRepository _moduletype;

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

        public IModuletypeRepository Moduletype
        {
            get
            {
                if (_variable == null)
                {
                    _moduletype = new ModuletypeRepository(_meteovaContext);
                }
                return _moduletype;
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
