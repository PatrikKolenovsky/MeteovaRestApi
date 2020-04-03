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

            CreateMap<Module, ModuleDto>();

            CreateMap<Device, DeviceDto>();
        }
    }
}
