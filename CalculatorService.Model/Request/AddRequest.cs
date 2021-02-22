using System.ComponentModel.DataAnnotations;
using CalculatorService.Server.Infrastructure.Validation;

namespace CalculatorService.Model.Request
{
    public class AddRequest
    {
        [Required]
        [NotEmptyIntegerArrayValidator(ErrorMessage = "Addends cannot be empty")]
        public int[] Addends { get; set; }

    }
}
