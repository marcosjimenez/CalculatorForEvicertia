namespace CalculatorService.Model.Response
{
    public class ErrorResponse
    {
        private const string InternalError = "InternalError";

        public ErrorResponse()
        {

        }

        public ErrorResponse(string errorCode, string errorStatus, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorStatus = errorStatus;
            ErrorMessage = errorMessage;
        }

        public string ErrorCode { get; set; } = InternalError;
        public string ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
