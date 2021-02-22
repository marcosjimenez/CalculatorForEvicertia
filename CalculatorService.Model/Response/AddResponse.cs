namespace CalculatorService.Model.Response
{
    public class AddResponse
    {

        public AddResponse()
        {

        }

        public AddResponse(int operationResult)
        {
            Sum = operationResult;
        }

        public int Sum { get; set; }
    }
}
