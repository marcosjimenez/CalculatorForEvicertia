using CalculatorService.Model.Operations;

namespace CalculatorService.Server.Services.Interfaces
{
    public interface IMathService
    {
        int? Add(int[] addEnds);
        int? Add(int[] addEnds, string operationId);

        int? Sub(int minuend, int sustraend);
        int? Sub(int minuend, int sustraend, string operationId);

        int? Mult(int[] factors);
        int? Mult(int[] factors, string operationId);

        DivOperationResult Div(int dividend, int divisor);
        DivOperationResult Div(int dividend, int divisor, string operationId);

        double? Sqrt(int number);
        double? Sqrt(int number, string operationId);
    }
}
