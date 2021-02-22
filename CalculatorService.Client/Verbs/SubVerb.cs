using CommandLine;

namespace CalculatorService.Client.Verbs
{
    [Verb("sub", HelpText = "Substracts two numbers")]
    public class SubVerb : BaseVerb
    {
        [Option('m', "minuend", Required = true, HelpText = "Minuend")]
        public int Minuend { get; set; }
        
        [Option('s', "sustraend", Required = true, HelpText = "Sustraend")]
        public int Sustraend { get; set; }

    }
}
