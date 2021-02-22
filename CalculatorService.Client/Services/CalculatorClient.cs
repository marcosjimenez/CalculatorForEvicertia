using System;
using System.Collections.Generic;
using Flurl;
using Flurl.Http;
using CalculatorService.Model.Request;
using CalculatorService.Model.Response;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace CalculatorService.Client.Services
{
    public class CalculatorClient
    {
        private const string CalculatorPath = "calculator";
        private const string AddPath = "add";
        private const string DivPath = "div";
        private const string MultPath = "mult";
        private const string SquarePath = "sqrt";
        private const string SubPath = "sub";
        private const string JournalPath = "journal";
        private const string JournalQueryPath = "query";

        private string MainUrl { get; set; }

        public CalculatorClient(string mainUrl)
        {
            MainUrl = mainUrl;
        }

        public async Task<int> Add(string trackingId, IEnumerable<int> numbers)
        {
            var request = new AddRequest { Addends = numbers.ToArray() };

            var response = await GetRequest(trackingId, CalculatorPath, AddPath)
                .PostJsonAsync(request)
                .ReceiveJson<AddResponse>();

            return response.Sum;
        }

        public async Task<Tuple<int, int>> Div(string trackingId, int dividend, int divisor)
        {
            var request = new DivRequest { Dividend = dividend, Divisor = divisor };

            var response = await GetRequest(trackingId, CalculatorPath, DivPath)
                .PostJsonAsync(request)
                .ReceiveJson<DivResponse>();

            return new Tuple<int, int>(response.Quotient, response.Remainder);
        }

        public async Task<int> Mult(string trackingId, int[] numbers)
        {
            var request = new MultRequest{ Factors = numbers.ToArray() };

            var response = await GetRequest(trackingId, CalculatorPath, MultPath)
                .PostJsonAsync(request)
                .ReceiveJson<MultResponse>();

            return response.Product;
        }

        public async Task<double> Square(string trackingId, int number)
        {
            var request = new SquareRequest { Number = number };

            var response = await GetRequest(trackingId, CalculatorPath, SquarePath)
                .PostJsonAsync(request)
                .ReceiveJson<SquareResponse>();

            return response.Square;
        }

        public async Task<int> Sub(string trackingId, int minuend, int sustraend)
        {
            var request = new SubRequest { Minuend = minuend, Sustraend = sustraend };

            var response = await GetRequest(trackingId, CalculatorPath, SubPath)
                .PostJsonAsync(request)
                .ReceiveJson<SubResponse>();

            return response.Difference;
        }

        public async Task<string> Journal(string trackingId)
        {
            var request = new JournalQueryRequest { Id = trackingId };

            var response = await GetRequest(trackingId, JournalPath, JournalQueryPath)
                .PostJsonAsync(request)
                .ReceiveJson<JournalQueryResponse>();

            var builder = new StringBuilder();
            foreach(var item in response.Operations)
            {
                builder.AppendLine($"Operation: {item.Operation}, Calculation = {item.Calculation}, Date = {item.Date}");
            }

            return builder.ToString();
        }

        private IFlurlRequest GetRequest(string trackingId, params string[] path)
        {
            return MainUrl
                .WithHeader("x-evi-tracking-id", trackingId)
                .AppendPathSegments(path)
                .WithTimeout(5);
        }

    }
}
