using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeteovaRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicenameController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        // Injecting logger and repository wrapper to the constructor
        public DevicenameController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDevicename()
        {
            var devicenames = _repository.Devicename.GetAllDevicename();

            _logger.LogInfo($"Returned {devicenames.Count} devices from database.");

            var devicenamesResult = _mapper.Map<IEnumerable<DevicenameDto>>(devicenames);

            return Ok(devicenamesResult);
        }
    }
}
