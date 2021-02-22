using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Server.Infrastructure.Validation
{
    public class NotEmptyIntegerArrayValidator : ValidationAttribute
    {

        public override bool IsValid(object value)
        {
            var list = value as IList<int>;
            if (list != null)
                return list.Count > 0;

            return false;
        }

    }
}
