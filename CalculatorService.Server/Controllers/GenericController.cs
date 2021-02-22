using CalculatorService.Model.Response;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalculatorService.Server.Controllers
{

    public class GenericController : ControllerBase
    {

        public IActionResult GetError(int status)
        {
            var retval = new ErrorResponse
            {
                ErrorStatus = status.ToString()
            };

            switch (status)
            {
                case 400:
                    retval.ErrorCode = "InternalError";
                    retval.ErrorMessage = "Unable to process request.";
                    break;

                case 401:
                    retval.ErrorCode = "Unauthorized";
                    retval.ErrorMessage = "Invalid credentials.";
                    break;

                case 500:
                    retval.ErrorCode = "InternalError";
                    retval.ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request.Please try again later";
                    break;

                default:
                    retval.ErrorCode = "UnexpectedError";
                    retval.ErrorMessage = "An unexpected error condition was triggered which made impossible to fulfill the request.Please try again later";
                    break;
            }

            return StatusCode(status, retval);
        }

    }
}
