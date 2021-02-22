using CommandLine;

namespace CalculatorService.Client.Verbs
{
    [Verb("div", HelpText = "Divides two or more operands and retrieve the result.")]
    public class DivVerb : BaseVerb
    {
        [Option('d', "dividend", Required = true, HelpText = "Dividend")]
        public int Dividend { get; set; }

        [Option('o', "divisor", Required = true, HelpText = "Divisor")]
        public int Divisor { get; set; }

    }
}
