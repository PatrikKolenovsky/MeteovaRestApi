using System;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using System.Linq;
using Newtonsoft.Json;

namespace MeteovaRestApi.Controllers
{
    [Route("api/device")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        // Injecting logger and repository wrapper to the constructor
        public DevicesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDevices([FromQuery] DeviceParameters deviceParameters)
        {
            try
            {
                var devices = _repository.Device.GetDevices(deviceParameters);

                var metadata = new
                {
                    devices.TotalCount,
                    devices.PageSize,
                    devices.CurrentPage,
                    devices.TotalPages,
                    devices.HasNext,
                    devices.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInfo($"Returned {devices.TotalCount} devices from database.");

                return Ok(devices);
            }
            catch (Exception ex)
            {
                _logger.LogError($"!! Something went wrong inside GetDevices action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/device/detail
        [HttpGet("detail")]
        public IActionResult GetDevicesWithDetails([FromQuery] DeviceParameters deviceParameters)
        {
            try
            {
                var devices = _repository.Device.GetDevicesWithDetails(deviceParameters);

                var metadata = new
                {
                    devices.TotalCount,
                    devices.PageSize,
                    devices.CurrentPage,
                    devices.TotalPages,
                    devices.HasNext,
                    devices.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInfo($"Returned {devices.TotalCount} devices from database.");

                return Ok(devices);
            }
            catch (Exception ex)
            {
                _logger.LogError($"!! Something went wrong inside GetDevicesWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/device/5
        [HttpGet("{id}", Name = "DeviceById")]
        public IActionResult GetDeviceById(int id)
        {
            try
            {
                var device = _repository.Device.GetDeviceById(id);

                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned owner with id: {id}");

                    var deviceResult = _mapper.Map<DeviceDto>(device);
                    return Ok(deviceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeviceById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/device/5/detailed
        [HttpGet("{id}/detailed")]
        public IActionResult GetDeviceWithDetails(int id)
        {
            try
            {
                var device = _repository.Device.GetDeviceWithDetails(id);

                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned device with details for id: {id}");

                    var deviceResult = _mapper.Map<DeviceDto>(device);
                    return Ok(deviceResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetDeviceWithDetails action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/device/3
        [HttpPut("{id}")]
        public IActionResult UpdateDevice(int id, [FromBody] DeviceForUpdateDto device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from client is null.");
                    return BadRequest("Device object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var deviceEntity = _repository.Device.GetDeviceById(id);
                if (deviceEntity == null)
                {
                    _logger.LogError($"Device with id: {id}, has not been found in db.");
                    return NotFound();
                }

                _mapper.Map(device, deviceEntity);

                _repository.Device.UpdateDevice(deviceEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/device
        [HttpPost]
        public IActionResult CreateDevice([FromBody] DeviceForCreationDto device)
        {
            try
            {
                if (device == null)
                {
                    _logger.LogError("Device object sent from client is null.");
                    return BadRequest("Device object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid device object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                var deviceEntity = _mapper.Map<Device>(device);

                _repository.Device.CreateDevice(deviceEntity);
                _repository.Save();

                var createdDevice = _mapper.Map<DeviceDto>(deviceEntity);

                return CreatedAtRoute("DeviceById", new { id = createdDevice.DeviceId }, createdDevice);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /* Work with modules in progress
        // DELETE: api/device/3
        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(int id)
        {
            try
            {
                var device = _repository.Device.GetDeviceById(id);
                if (device == null)
                {
                    _logger.LogError($"Device with id: {id}, has not been found in db.");
                    return NotFound();
                }

                if (_repository.Module.ModulesByDevice(id, [FromQuery] ModuleParameters moduleParameters).Any())
                {
                    _logger.LogError($"Cannot delete device with id: {id}. It has related module/s. Delete those modules first");
                    return BadRequest("Cannot delete device. It has related module/s. Delete those modules first.");
                }

                _repository.Device.DeleteDevice(device);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DelteDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        */
    }
}
