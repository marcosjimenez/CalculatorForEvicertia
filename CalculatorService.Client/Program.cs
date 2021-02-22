using System;
using System.Linq;
using CommandLine;
using CalculatorService.Client.Services;
using CalculatorService.Client.Verbs;

namespace CalculatorService.Client
{
    class Program
    {
        //TODO: Move the target url to the configuration file
        private const string MainUrl = "https://localhost:44380";

        static int Main(string[] args)
        {
            return CommandLine.Parser.Default.ParseArguments<AddVerb, DivVerb, MultVerb, SquareVerb, SubVerb, JournalVerb>(args)
                .MapResult(
                  (AddVerb opt) => RunAdd(opt),
                  (DivVerb opt) => RunDiv(opt),
                  (MultVerb opt) => RunMult(opt),
                  (SquareVerb opt) => RunSquare(opt),
                  (SubVerb opt) => RunSub(opt),
                  (JournalVerb opt) => RunJournal(opt),
                  errs => 1);
        }

        private static int RunAdd(AddVerb addVerb)
        {
            var client = new CalculatorClient(MainUrl);

            try
            {
                var result = client
                    .Add(addVerb.TrackingId, addVerb.Numbers)
                    .GetAwaiter()
                    .GetResult();

                ShowMessage($"Add operation result: {string.Join(" + ", addVerb.Numbers)} = {result}");
            }
            catch(Exception ex)
            {
                ShowMessage(ex.Message, ConsoleColor.Red);
            }

            return 0;
        }

        private static int RunDiv(DivVerb divVerb)
        {
            var client = new CalculatorClient(MainUrl);

            try
            {
                var result = client
                    .Div(divVerb.TrackingId, divVerb.Dividend, divVerb.Divisor)
                    .GetAwaiter()
                    .GetResult();

                ShowMessage($"Div operation result: {divVerb.Dividend} / {divVerb.Divisor} = {result.Item1} (Remainder = {result.Item2})");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, ConsoleColor.Red);
            }

            return 0;
        }

        private static int RunMult(MultVerb multVerb)
        {
            var client = new CalculatorClient(MainUrl);

            try
            {
                var result = client
                    .Mult(multVerb.TrackingId, multVerb.Factors.ToArray())
                    .GetAwaiter()
                    .GetResult();

                ShowMessage($"Mult operation result: {string.Join(" * ", multVerb.Factors)} = {result}");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, ConsoleColor.Red);
            }

            return 0;
        }
                
        private static int RunSquare(SquareVerb squareVerb)
        {
            var client = new CalculatorClient(MainUrl);

            try
            {
                var result = client
                    .Square(squareVerb.TrackingId, squareVerb.Number)
                    .GetAwaiter()
                    .GetResult();

                ShowMessage($"Square operation result: x ^ {squareVerb.Number} = {result}");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, ConsoleColor.Red);
            }

            return 0;
        }
        
        private static int RunSub(SubVerb subVerb)
        {
            var client = new CalculatorClient(MainUrl);

            try
            {
                var result = client
                    .Sub(subVerb.TrackingId, subVerb.Minuend, subVerb.Sustraend)
                    .GetAwaiter()
                    .GetResult();

                ShowMessage($"Sub operation result: {subVerb.Minuend} - {subVerb.Sustraend} = {result}");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, ConsoleColor.Red);
            }

            return 0;
        }
        
        private static int RunJournal(JournalVerb journalVerb)
        {
            var client = new CalculatorClient(MainUrl);

            try
            {
                var result = client
                    .Journal(journalVerb.TrackingId)
                    .GetAwaiter()
                    .GetResult();

                ShowMessage(result);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message, ConsoleColor.Red);
            }

            return 0;
        }

        private static void ShowMessage(string message, ConsoleColor color = ConsoleColor.White)
        {
            var lastColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = lastColor;
        }

    }
}
