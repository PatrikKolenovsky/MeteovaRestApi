﻿using AutoMapper;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Device;
using Entities.DataTransferObjects.MakerDto;
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

            // Moduletype mapping
            CreateMap<Moduletype, ModuletypeDto>();
            CreateMap<ModuletypeCreateDto, Moduletype>();

            // Others
            CreateMap<Variable, VariableDto>();

            CreateMap<Valint, ValintDto>();

            CreateMap<Valreal, ValrealDto>();

            CreateMap<Valstring, ValstringDto>();

            CreateMap<Envidata, EnvidataDto>();

            CreateMap<Maker, MakerDto>();
        }
    }
}
