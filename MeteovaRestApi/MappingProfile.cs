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

            CreateMap<Variable, VariableDto>();

            CreateMap<Device, DeviceDto>();

            CreateMap<Module, ModuleDto>();

            CreateMap<DeviceForCreationDto, Device>();

            CreateMap<DeviceForUpdateDto, Device>();
        }
    }
}
