namespace CalculatorService.Model.Response
{
    public class DivResponse
    {
        public DivResponse()
        {

        }

        public DivResponse(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public int Quotient { get; set; }
        public int Remainder { get; set; }
    }
}
