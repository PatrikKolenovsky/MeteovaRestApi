using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Devicename;
using Entities.Models;
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

        // PUT: api/devicename/3
        [HttpPut("{id}")]
        public IActionResult UpdateDevicename(int id, [FromBody] DevicenameUpdateDto devicename)
        {
            try
            {
                if (devicename == null)
                {
                    _logger.LogError("Devicename object sent from client is null.");
                    return BadRequest("Devicename object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid devicename object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var devicenameEntity = _repository.Devicename.GetDevicenameById(id);
                if (devicenameEntity == null)
                {
                    _logger.LogError($"Devicename with id: {id}, has not been found in db.");
                    return NotFound();
                }

                _mapper.Map(devicename, devicenameEntity);

                _repository.Devicename.UpdateDevicename(devicenameEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateDevicename action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/device
        [HttpPost]
        public IActionResult CreateDevicename([FromBody] DevicenameCreateDto devicename)
        {
            try
            {
                if (devicename == null)
                {
                    _logger.LogError("Devicename object sent from client is null.");
                    return BadRequest("Devicename object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid devicename object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                var devicenameEntity = _mapper.Map<Devicename>(devicename);

                _repository.Devicename.CreateDevicename(devicenameEntity);
                _repository.Save();

                var createdDevicename = _mapper.Map<DevicenameDto>(devicenameEntity);

                return CreatedAtRoute("DevicenameById", new { id = createdDevicename.DeviceNameId }, createdDevicename);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateDevicename action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
