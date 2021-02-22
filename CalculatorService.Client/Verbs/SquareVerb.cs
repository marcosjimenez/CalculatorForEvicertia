using CommandLine;

namespace CalculatorService.Client.Verbs
{
    [Verb("sqrt", HelpText = "Returns the square of the number.")]
    public class SquareVerb : BaseVerb
    {
        [Option('n', "number", Required = true, HelpText = "Number")]
        public int Number { get; set; }

    }
}
