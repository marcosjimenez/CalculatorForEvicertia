using System.ComponentModel.DataAnnotations;
using CalculatorService.Server.Infrastructure.Validation;

namespace CalculatorService.Model.Request
{
    public class MultRequest
    {
        [Required]
        [NotEmptyIntegerArrayValidator(ErrorMessage = "Factors cannot be empty")]
        public int[] Factors { get; set; }

    }
}
