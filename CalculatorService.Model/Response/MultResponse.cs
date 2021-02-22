namespace CalculatorService.Model.Response
{
    public class MultResponse
    {
        public MultResponse()
        {

        }

        public MultResponse(int product)
        {
            Product = product;
        }

        public int Product { get; set; }
    }
}
