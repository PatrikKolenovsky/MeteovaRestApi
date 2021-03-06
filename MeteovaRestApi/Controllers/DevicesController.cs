﻿using System;
using Microsoft.AspNetCore.Mvc;
using Entities.Models;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects.Device;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Entities.DataTransferObjects;

namespace MeteovaRestApi.Controllers
{
    [Route("api/device")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

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

                var devicesResult = _mapper.Map<IEnumerable<DeviceDto>>(devices);

                return Ok(devicesResult);
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

                var envidata = _repository.Envidata.GetEnvidata(deviceParameters);

                int totalcount = devices.TotalCount + envidata.TotalCount;
                int pagesize = devices.PageSize + envidata.PageSize;

                var metadata = new
                {
                    totalcount,
                    pagesize,
                    devices.CurrentPage,
                    devices.TotalPages,
                    devices.HasNext,
                    devices.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInfo($"Returned {devices.TotalCount} devices plus {envidata.TotalCount} envidata devices from database.");

                var devicesResult = _mapper.Map<IEnumerable<DeviceDto>>(devices);

                var enviResult = _mapper.Map<IEnumerable<EnvidataDto>>(envidata);

                return Ok(new { devicesResult, enviResult });
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
                    _logger.LogInfo($"Returned device with id: {id}");

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

        // GET: api/device/detail/5
        [HttpGet("detail/{id}")]
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
        public IActionResult UpdateDevice(int id, [FromBody] DeviceUpdateDto device)
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
        public IActionResult CreateDevice([FromBody] DeviceCreateDto device)
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
