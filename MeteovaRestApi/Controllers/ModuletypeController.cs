using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Moduletype;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeteovaRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuletypeController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ModuletypeController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Moduletype
        [HttpGet]
        public IActionResult GetModuletypes()
        {
            var moduletypes = _repository.Moduletype.GetModuletypes();

            var moduletypesResult = _mapper.Map<IEnumerable<ModuletypeDto>>(moduletypes);

            return Ok(moduletypesResult);
        }

        // GET: api/Moduletype/5
        [HttpGet("{id}")]
        public IActionResult GetModuletype(int id)
        {
            try
            {
                var moduletype = _repository.Moduletype.GetModuletypeById(id);

                if (moduletype == null)
                {
                    _logger.LogError($"Moduletype with id: {id}, has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned moduletype with id: {id}");

                    var moduletypeResult = _mapper.Map<ModuletypeDto>(moduletype);
                    return Ok(moduletypeResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetModuletype action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult UpdateModuletype(int id, Moduletype moduletype)
        {
            try
            {
                if (moduletype == null)
                {
                    _logger.LogError("Moduletype object sent from client is null.");
                    return BadRequest("Moduletype object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid moduletype object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var moduletypeEntity = _repository.Moduletype.GetModuletypeById(id);
                if (moduletypeEntity == null)
                {
                    _logger.LogError($"Moduletype with id: {id}, has not been found in db.");
                    return NotFound();
                }

                _mapper.Map(moduletype, moduletypeEntity);

                _repository.Moduletype.UpdateModuletype(moduletypeEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateModuletype action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Modules
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult CreateModuletype([FromBody] ModuletypeCreateDto moduletype)
        {
            try
            {
                if (moduletype == null)
                {
                    _logger.LogError("Moduletype object sent from client is null.");
                    return BadRequest("Moduletype object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid moduletype object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                var moduletypeEntity = _mapper.Map<Moduletype>(moduletype);

                _repository.Moduletype.CreateModuletype(moduletypeEntity);
                _repository.Save();

                var createdModuletype = _mapper.Map<ModuletypeDto>(moduletypeEntity);

                return CreatedAtRoute("ModuletypeById", new { id = createdModuletype.ModuleTypeId }, createdModuletype);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateModuletype action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
