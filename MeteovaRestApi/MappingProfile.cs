using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Comtype;
using Entities.DataTransferObjects.Device;
using Entities.DataTransferObjects.Devicename;
using Entities.DataTransferObjects.Module;
using Entities.DataTransferObjects.Moduletype;
using Entities.Models;

namespace MeteovaRestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Device mapping
            CreateMap<Device, DeviceDto>();
            CreateMap<DeviceCreateDto, Device>();
            CreateMap<DeviceUpdateDto, Device>();

            // Module mapping
            CreateMap<Module, ModuleDto>();
            CreateMap<ModuleCreateDto, Module>();

            CreateMap<Variable, VariableDto>();

            CreateMap<Valint, ValintDto>();

            CreateMap<Valreal, ValrealDto>();

            CreateMap<Valstring, ValstringDto>();

            CreateMap<Envidata, EnvidataDto>();

            // Devicename mapping
            CreateMap<Devicename, DevicenameDto>();
            CreateMap<DevicenameCreateDto, DevicenameDto>();
            CreateMap<DevicenameUpdateDto, DevicenameDto>();

            // Comtype mapping
            CreateMap<Comtype, ComtypeDto>();
            CreateMap<ComtypeCreateDto, ComtypeDto>();
            CreateMap<ComtypeUpdateDto, ComtypeDto>();

            // Moduletype mapping
            CreateMap<Moduletype, ModuletypeDto>();
            CreateMap<ModuletypeCreateDto, ModuletypeDto>();
        }
    }
}
