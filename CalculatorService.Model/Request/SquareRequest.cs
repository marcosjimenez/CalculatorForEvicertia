using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Model.Request
{
    public class SquareRequest
    {
        [Required]
        public int Number { get; set; }

    }
}
