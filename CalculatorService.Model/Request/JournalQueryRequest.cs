using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Model.Request
{
    public class JournalQueryRequest
    {
        [Required]
        public string Id { get; set; }

    }
}
