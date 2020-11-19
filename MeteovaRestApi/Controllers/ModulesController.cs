using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using Entities.Models;
using AutoMapper;
using Entities.DataTransferObjects;
using Contracts;
using Entities.DataTransferObjects.Module;

namespace MeteovaRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ModulesController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Modules
        [HttpGet]
        public IActionResult GetModules()
        {
            var modules = _repository.Module.GetModules();

            var modulesResult = _mapper.Map<IEnumerable<ModuleDto>>(modules);

            return Ok(modulesResult);
        }

        // GET: api/Modules/5
        [HttpGet("{id}", Name = "ModuleById")]
        public IActionResult GetModuleById(int id)
        {
            try
            {
                var module = _repository.Module.GetModuleById(id);

                if (module == null)
                {
                    _logger.LogError($"Module with id: {id}, has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned module with id: {id}");

                    var moduleResult = _mapper.Map<ModuleDto>(module);
                    return Ok(moduleResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetModuleById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Modules/device/5
        [HttpGet("device/{deviceId}")]
        public IActionResult GetModuleByDeviceId(int deviceId)
        {
            try
            {
                var module = _repository.Module.GetModuleByDevice(deviceId);

                if (module == null)
                {
                    _logger.LogError($"There is no module/s connected to device id: {deviceId}.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned module/s connected to device id: {deviceId}");

                    var moduleResult = _mapper.Map<IEnumerable<ModuleDto>>(module);
                    return Ok(moduleResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetModuleByDeviceId action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Modules/other/5
        [HttpGet("other/{deviceId}", Name = "OtherModulesByDeviceId")]
        public IActionResult GetOtherModulesByDevice(int deviceId)
        {
            try
            {
                var modules = _repository.Module.GetOtherModulesByDevice(deviceId);

                if (modules == null)
                {
                    _logger.LogError($"There are no modules missing on device with id: {deviceId}");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned modules not connected to device id: {deviceId}");

                    var modulesResult = _mapper.Map<IEnumerable<ModuleDto>>(modules);
                    return Ok(modulesResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetOtherModulesByDevice action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult UpdateModule(int id,[FromBody] ModuleUpdateDto module)
        {
            try
            {
                if (module == null)
                {
                    _logger.LogError("Module object sent from client is null.");
                    return BadRequest("Module object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid module object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var moduleEntity = _repository.Module.GetModuleById(id);
                if (moduleEntity == null)
                {
                    _logger.LogError($"Module with id: {id}, has not been found in db.");
                    return NotFound();
                }

                _mapper.Map(module, moduleEntity);

                _repository.Module.UpdateModule(moduleEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateModule action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Modules
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult CreateModule([FromBody] ModuleCreateDto module)
        {
            try
            {
                if (module == null)
                {
                    _logger.LogError("Module object sent from client is null.");
                    return BadRequest("Module object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid module object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                var moduleEntity = _mapper.Map<Module>(module);

                _repository.Module.CreateModule(moduleEntity);
                _repository.Save();

                var createdModule = _mapper.Map<ModuleDto>(moduleEntity);

                return CreatedAtRoute("ModuleById", new { id = createdModule.ModuleId }, createdModule);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateModule action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
