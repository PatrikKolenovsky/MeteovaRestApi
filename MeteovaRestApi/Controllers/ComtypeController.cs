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
    }
}
