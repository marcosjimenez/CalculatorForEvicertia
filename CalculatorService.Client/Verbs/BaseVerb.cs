using CommandLine;

namespace CalculatorService.Client.Verbs
{
    public abstract class BaseVerb
    {
        [Option('t', "trackingId", HelpText = "Tracking Id", Default = "")]
        public string TrackingId { get; set; }
    }
}
