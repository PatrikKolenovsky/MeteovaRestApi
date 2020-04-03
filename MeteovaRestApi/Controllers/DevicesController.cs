using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using Contracts;
using AutoMapper;
using Entities.DataTransferObjects;
using System.Collections.Generic;

namespace MeteovaRestApi.Controllers
{
    [Route("api/device")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly Sg1Context _context;

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

        // GET: api/device
        [HttpGet]
        public IActionResult GetAllDevices()
        {
            try
            {
                var devices = _repository.Device.GetAllDevices();

                _logger.LogInfo($"Returned all devices.");

                var devicesResult = _mapper.Map<IEnumerable<DeviceDto>>(devices);
                return Ok(devicesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"!! Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/device/5
        [HttpGet("{id}")]
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

        // GET: api/device/5/module
        [HttpGet("{id}/module")]
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

        // PUT: api/device/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, Device device)
        {
            if (id != device.DeviceId)
            {
                return BadRequest();
            }

            _context.Entry(device).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/device
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(Device device)
        {
            _context.Device.Add(device);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDevice", new { id = device.DeviceId }, device);
        }

        // DELETE: api/device/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Device>> DeleteDevice(int id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Device.Remove(device);
            await _context.SaveChangesAsync();

            return device;
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
