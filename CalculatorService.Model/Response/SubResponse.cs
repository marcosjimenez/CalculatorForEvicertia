namespace CalculatorService.Model.Response
{
    public class SubResponse
    {

        public SubResponse()
        {

        }

        public SubResponse(int difference)
        {
            Difference = difference;
        }

       public int Difference { get; set; }
    }
}