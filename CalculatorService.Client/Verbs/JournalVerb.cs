using CommandLine;

namespace CalculatorService.Client.Verbs
{
    [Verb("journal", HelpText = "Query the API journal")]
    public class JournalVerb
    {
        [Option('t', Required = true, HelpText = "Tracking Id to query")]
        public string TrackingId { get; set; }
    }
}
