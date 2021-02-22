using System.Collections.Generic;
using CommandLine;

namespace CalculatorService.Client.Verbs
{
    [Verb("add", HelpText = "Add two or more operands and retrieve the result.")]
    public class AddVerb : BaseVerb
    {
        [Option('n', "numbers", Required = true, HelpText = "Values to add")]
        public IEnumerable<int> Numbers { get; set; }

    }
}
