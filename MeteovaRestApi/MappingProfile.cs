using AutoMapper;
using Entities.DataTransferObjects;
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

            CreateMap<DeviceForCreationDto, Device>();

            CreateMap<DeviceForUpdateDto, Device>();

            CreateMap<Envidata, EnvidataDto>();
        }
    }
}
