using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Model.Request
{
    public class SubRequest
    {
        [Required]
        public int Minuend { get; set; }

        [Required]
        public int Sustraend{ get; set; }

    }
}
