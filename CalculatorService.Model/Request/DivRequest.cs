using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Model.Request
{
    public class DivRequest
    {
        [Required]
        public int Dividend { get; set; }

        [Required]
        public int Divisor{ get; set; }
    }
}
