using Microsoft.AspNetCore.Http;
using System.Linq;

namespace CalculatorService.Server.Infrastructure.Extensions
{
    public static class RequestExtensions
    {
        /// <summary>
        /// Returns the value for the specified header on the request
        /// </summary>
        /// <param name="request">Request</param>
        /// <param name="headerName">Header name</param>
        /// <returns>String object with the specified header value</returns>
        public static string GetHeader(this HttpRequest request, string headerName)
        {
            return request.Headers.FirstOrDefault(x => x.Key.ToUpper() == headerName.ToUpper()).Value;
        }

    }
}
