using System.Collections.Generic;
using CommandLine;

namespace CalculatorService.Client.Verbs
{
    [Verb("mult", HelpText = "Multiply two or more operands and retrieve the result.")]
    public class MultVerb : BaseVerb
    {
        [Option('f', "factors", Required = true, HelpText = "Values to multiply")]
        public IEnumerable<int> Factors { get; set; }

    }
}
