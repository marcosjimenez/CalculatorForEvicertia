using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CalculatorService.Server.Infrastructure.Validation
{
    public class NotEmptyIntegerArrayValidator : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            if (value is IList<int> list)
                return list.Count > 0;

            return false;
        }

    }
}
