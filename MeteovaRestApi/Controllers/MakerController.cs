using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.Maker;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeteovaRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakerController : ControllerBase
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public MakerController(IRepositoryWrapper repository, IMapper mapper, ILoggerManager logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: api/Maker
        [HttpGet]
        public IActionResult GetMakers()
        {
            var makers = _repository.Maker.GetMakers();

            var makersResult = _mapper.Map<IEnumerable<MakerDto>>(makers);

            return Ok(makersResult);
        }

        // GET: api/Maker/5
        [HttpGet("{id}", Name = "MakerById")]
        public IActionResult GetMaker(int id)
        {
            try
            {
                var maker = _repository.Maker.GetMakerById(id);

                if (maker == null)
                {
                    _logger.LogError($"Maker with id: {id}, has not been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned maker with id: {id}");

                    var makerResult = _mapper.Map<MakerDto>(maker);
                    return Ok(makerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetMaker action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // PUT: api/Maker/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult UpdateMaker(int id, [FromBody] MakerUpdateDto maker)
        {
            try
            {
                if (maker == null)
                {
                    _logger.LogError("Maker object sent from client is null.");
                    return BadRequest("Maker object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid maker object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var makerEntity = _repository.Maker.GetMakerById(id);
                if (makerEntity == null)
                {
                    _logger.LogError($"Maker with id: {id}, has not been found in db.");
                    return NotFound();
                }

                _mapper.Map(maker, makerEntity);

                _repository.Maker.UpdateMaker(makerEntity);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateMaker action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // POST: api/Maker
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public IActionResult CreateMaker([FromBody] MakerCreateDto maker)
        {
            try
            {
                if (maker == null)
                {
                    _logger.LogError("Maker object sent from client is null.");
                    return BadRequest("Maker object is null.");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid maker object sent from client.");
                    return BadRequest("Invalid model object.");
                }

                var makerEntity = _mapper.Map<Maker>(maker);

                _repository.Maker.CreateMaker(makerEntity);
                _repository.Save();

                var createdMaker = _mapper.Map<MakerDto>(makerEntity);

                return CreatedAtRoute("MakerById", new { id = createdMaker.MakerId }, createdMaker);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateMaker action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Maker/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMaker(int id)
        {
            try
            {
                var maker = _repository.Maker.GetMakerById(id);
                if (maker == null)
                {
                    _logger.LogError($"Maker with id: {id}, has not been found in db.");
                    return NotFound();
                }

                _repository.Maker.DeleteMaker(maker);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteMaker action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
