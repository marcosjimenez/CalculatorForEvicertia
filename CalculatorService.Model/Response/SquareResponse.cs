namespace CalculatorService.Model.Response
{
    public class SquareResponse
    {
        public SquareResponse()
        {

        }

        public SquareResponse(double square)
        {
            Square = square;
        }

        public double Square { get; set; }
    }
}
