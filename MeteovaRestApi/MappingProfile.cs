using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Comtype;
using Entities.DataTransferObjects.Device;
using Entities.DataTransferObjects.Devicename;
using Entities.DataTransferObjects.Module;
using Entities.Models;

namespace MeteovaRestApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Device, DeviceDto>();

            CreateMap<Module, ModuleDto>();

            CreateMap<Variable, VariableDto>();

            CreateMap<Valint, ValintDto>();

            CreateMap<Valreal, ValrealDto>();

            CreateMap<Valstring, ValstringDto>();

            CreateMap<DeviceCreateDto, Device>();

            CreateMap<DeviceUpdateDto, Device>();

            CreateMap<Envidata, EnvidataDto>();

            CreateMap<Devicename, DevicenameDto>();

            CreateMap<Comtype, ComtypeDto>();
        }
    }
}
