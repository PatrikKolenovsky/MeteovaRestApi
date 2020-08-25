using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MeteovaRestApi.Controllers
{
    [Route("api/envidata")]
    [ApiController]
    public class EnvidataController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        // Injecting logger and repository wrapper to the constructor
        public EnvidataController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetEnvidata([FromQuery] DeviceParameters deviceParameters)
        {
            try
            {
                var envidata = _repository.Envidata.GetEnvidata(deviceParameters);

                var metadata = new
                {
                    envidata.TotalCount,
                    envidata.PageSize,
                    envidata.CurrentPage,
                    envidata.TotalPages,
                    envidata.HasNext,
                    envidata.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                _logger.LogInfo($"Returned {envidata.TotalCount} devices (envidata) from database.");

                var envidataResult = _mapper.Map<IEnumerable<EnvidataDto>>(envidata);

                return Ok(envidataResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"!! Something went wrong inside GetEnvidata action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
