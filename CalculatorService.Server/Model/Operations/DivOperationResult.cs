using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Model.Operations
{
    public class DivOperationResult
    {

        public DivOperationResult()
        {

        }

        public DivOperationResult(int quotient, int remainder)
        {
            Quotient = quotient;
            Remainder = remainder;
        }

        public int Quotient { get; set; }
        public int Remainder { get; set; }

    }
}
