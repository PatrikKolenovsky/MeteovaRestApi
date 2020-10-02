using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.DataTransferObjects.Comtype;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeteovaRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComtypeController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public ComtypeController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetComtypes()
        {
            var comtypes = _repository.Comtype.GetComtypes();

            _logger.LogInfo($"Returned {comtypes.Count} devices from database.");

            var comtypesResult = _mapper.Map<IEnumerable<ComtypeDto>>(comtypes);

            return Ok(comtypesResult);
        }

        // PUT: api/device/3
        [HttpPut("{id}")]
        public IActionResult UpdateComtype(int id, [FromBody] ComtypeUpdateDto comtype)
        {
            try
            {
                if (comtype == null)
                {
                    _logger.LogError("Comtype object sent from client is null.");
                    return BadRequest("Comtype object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid comtype object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var comtypeEntity = _repository.Comtype.GetComtypeById(id);
                if (comtypeEntity == null)
                {
                    _logger.LogError($"Comtype with id: {id}, has not been found in db.");
                    return NotFound();
                }

                _mapper.Map(comtype, comtypeEntity);

                _repository.Comtype.UpdateComtype(comtypeEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateComtype action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/device
        [HttpPost]
        public IActionResult CreateComtype([FromBody] ComtypeCreateDto comtype)
        {
            try
            {
                if (comtype == null)
                {
                    _logger.LogError("Comtype object sent from client is null.");
                    return BadRequest("Comtype object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid comtype object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                var comtypeEntity = _mapper.Map<Comtype>(comtype);

                _repository.Comtype.CreateComtype(comtypeEntity);
                _repository.Save();

                var createdComtype = _mapper.Map<Comtype>(comtypeEntity);

                return CreatedAtRoute("ComtypeById", new { id = createdComtype.ComTypeId }, createdComtype);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateComtype action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
