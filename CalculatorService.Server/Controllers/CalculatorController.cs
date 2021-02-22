using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using CalculatorService.Server.Services.Interfaces;
using CalculatorService.Model;
using CalculatorService.Model.Response;
using CalculatorService.Server.Infrastructure.Extensions;
using CalculatorService.Server.Infrastructure;
using CalculatorService.Model.Request;

namespace CalculatorService.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CalculatorController : GenericController
    {

        private readonly IMathService _mathService;

        public CalculatorController(IMathService mathService)
        {
            Log.Debug("CalculatorController ctor");
            _mathService = mathService;
        }

        /// <summary>
        /// Add two or more operands and retrieve the result
        /// </summary>
        /// <param name="addRequest"></param>
        /// <returns>
        /// AddResponse object with the result
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AddRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("add")]
        public IActionResult Add([FromBody] AddRequest addRequest)
        {
            Log.Debug("Add");
            if (!ModelState.IsValid)
                return GetError(StatusCodes.Status400BadRequest);

            try
            {
                var result = _mathService.Add(addRequest.Addends, Request.GetHeader(CalculatorServiceConstants.EvilTrackingHeader));
                if (result.HasValue)
                    return Ok(new AddResponse(result.Value));
            }
            catch(Exception ex)
            {
                Log.Error(ex.Message);
            }

            return GetError(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Substracts two or more operands and retrieve the result
        /// </summary>
        /// <param name="subRequest"></param>
        /// <returns>
        /// SubResponse object with the result
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("sub")]
        public IActionResult Sub([FromBody] SubRequest subRequest)
        {
            Log.Debug("Sub");
            if (!ModelState.IsValid)
                return GetError(StatusCodes.Status400BadRequest);

            try
            {
                var result = _mathService.Sub(subRequest.Minuend, subRequest.Sustraend, Request.GetHeader(CalculatorServiceConstants.EvilTrackingHeader));
                if (result.HasValue)
                    return Ok(new SubResponse(result.Value));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return GetError(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Multiply two or more operands and retrieve the result
        /// </summary>
        /// <param name="multRequest"></param>
        /// <returns>
        /// MultResponse object with the result
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MultRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("mult")]
        public IActionResult Mult([FromBody] MultRequest multRequest)
        {
            Log.Debug("Mult");
            if (!ModelState.IsValid)
                return GetError(StatusCodes.Status400BadRequest);

            try
            {
                var result = _mathService.Mult(multRequest.Factors, Request.GetHeader(CalculatorServiceConstants.EvilTrackingHeader));
                if (result.HasValue)
                    return Ok(new MultResponse(result.Value));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return GetError(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Divide two or more operands and retrieve the result
        /// </summary>
        /// <param name="divRequest"></param>
        /// <returns>
        /// DivResponse object with the result
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DivRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("div")]
        public IActionResult Div([FromBody] DivRequest divRequest)
        {
            Log.Debug("Div");
            if (!ModelState.IsValid)
                return GetError(StatusCodes.Status400BadRequest);

            try
            {
                var result = _mathService.Div(divRequest.Dividend, divRequest.Divisor, Request.GetHeader(CalculatorServiceConstants.EvilTrackingHeader));
                if (result != null)
                    return Ok(new DivResponse(result.Quotient, result.Remainder));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return GetError(StatusCodes.Status500InternalServerError);
        }

        /// <summary>
        /// Square root two or more operands and retrieve the result
        /// </summary>
        /// <param name="squareRequest"></param>
        /// <returns>
        /// DivResponse object with the result
        /// </returns>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DivRequest))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("sqrt")]
        public IActionResult Sqrt([FromBody] SquareRequest squareRequest)
        {
            Log.Debug("Sqrt");
            if (!ModelState.IsValid)
                return GetError(StatusCodes.Status400BadRequest);

            try
            {
                var result = _mathService.Sqrt(squareRequest.Number, Request.GetHeader(CalculatorServiceConstants.EvilTrackingHeader));
                if (result.HasValue)
                    return Ok(new SquareResponse(result.Value));
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }

            return GetError(StatusCodes.Status500InternalServerError);
        }
    }
}
