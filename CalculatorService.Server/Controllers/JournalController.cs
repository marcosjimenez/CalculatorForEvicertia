using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using CalculatorService.Model.Request;
using CalculatorService.Model.Response;
using CalculatorService.Server.Services.Interfaces;
using CalculatorService.Server.Infrastructure.Converters;

namespace CalculatorService.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class JournalController : GenericController
    {

        private readonly IPersistenceService _persistenceService;

        public JournalController(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JournalQueryResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("query")]
        public IActionResult Query([FromBody] JournalQueryRequest request)
        {
            Log.Debug("Journal Query");
            if (!ModelState.IsValid)
                return GetError(StatusCodes.Status400BadRequest);

            try
            {
                var result = _persistenceService.Query(request.Id);
                return Ok(result.ToResponse());
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return GetError(StatusCodes.Status500InternalServerError);
        }
    }
}
