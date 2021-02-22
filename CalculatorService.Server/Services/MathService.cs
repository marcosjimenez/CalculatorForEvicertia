using System;
using System.Linq;
using Serilog;
using CalculatorService.Server.Services.Interfaces;
using CalculatorService.Server.Infrastructure;
using CalculatorService.Model.Operations;

namespace CalculatorService.Server.Services
{
    public class MathService : IMathService
    {

        private readonly IPersistenceService _persistenceService;

        public MathService(IPersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
        }

        public int? Add(int[] addEnds)
        {
            Log.Information("MathService->Add (with no Id)");

            if (addEnds == null)
                throw new ArgumentNullException(nameof(addEnds));

            try
            {
                return addEnds.Sum();
            }
            catch (StackOverflowException)
            {
                Log.Error($"Stack Overflow");
            }
            catch (Exception ex)
            {
                Log.Error($"Error adding: {ex.Message}");
            }

            return null;
        }

        public int? Add(int[] addEnds, string operationId)
        {
            Log.Information($"MathService->Add ({operationId})");

            var result = Add(addEnds);
            if (result.HasValue && operationId != null)
            {
                _persistenceService.SaveOperation(operationId, CalculatorServiceConstants.AddOperation, addEnds, result.Value);
                Log.Information($"Add Operation saved. {operationId}");
            }

            return result;
        }

        public int? Sub(int minuend, int sustraend)
        {
            Log.Information("MathService->Sub (with no Id)");

            try
            {
                return minuend - sustraend;
            }
            catch (StackOverflowException)
            {
                Log.Error($"Stack Overflow");
            }
            catch (Exception ex)
            {
                Log.Error($"Error substracting: {ex.Message}");
            }

            return null;
        }

        public int? Sub(int minuend, int sustraend, string operationId)
        {
            Log.Information($"MathService->Sub ({operationId})");

            var result = Sub(minuend, sustraend);
            if (result.HasValue && operationId != null)
            {
                int[] values = { minuend, sustraend };
                _persistenceService.SaveOperation(operationId, CalculatorServiceConstants.SubOperation, values, result.Value);
                Log.Information($"Sub Operation saved. {operationId}");
            }

            return result;
        }

        public int? Mult(int[] factors)
        {
            Log.Information("MathService->Mult (with no Id)");

            try
            {
                return factors.Aggregate(1, (x, y) => x * y);
            }
            catch (StackOverflowException)
            {
                Log.Error($"Stack Overflow");
            }
            catch (Exception ex)
            {
                Log.Error($"Error multipying: {ex.Message}");
            }

            return null;
        }

        public int? Mult(int[] factors, string operationId)
        {
            Log.Information($"MathService->Mult ({operationId})");

            var result = Mult(factors);
            if (result.HasValue && operationId != null)
            {
                _persistenceService.SaveOperation(operationId, CalculatorServiceConstants.MultOperation, factors, result.Value);
                Log.Information($"Mult Operation saved. {operationId}");
            }

            return result;
        }

        public DivOperationResult Div(int dividend, int divisor)
        {
            Log.Information("MathService->Div (with no Id)");

            if (divisor == 0)
                throw new DivideByZeroException(nameof(divisor));

            var retVal = new DivOperationResult();
            try
            {
                retVal.Quotient = Math.DivRem(dividend, divisor, out var remainder);
                retVal.Remainder = remainder;

                return retVal;
            }
            catch (StackOverflowException)
            {
                Log.Error($"Stack Overflow");
            }
            catch (Exception ex)
            {
                Log.Error($"Error dividing: {ex.Message}");
            }

            return null;
        }

        public DivOperationResult Div(int dividend, int divisor, string operationId)
        {
            Log.Information($"MathService->Div ({operationId})");

            var result = Div(dividend, divisor);
            if (result != null && operationId != null)
            {
                _persistenceService.SaveOperation(operationId, CalculatorServiceConstants.DivOperation, new int[] { dividend, divisor }, result.Quotient); 
                Log.Information($"Div Operation saved. {operationId}");
            }

            return result;
        }

        public double? Sqrt(int number)
        {
            Log.Information("MathService->Sqrt (with no Id)");

            try
            {
                return Math.Sqrt(number);
            }
            catch (StackOverflowException)
            {
                Log.Error($"Stack Overflow");
            }
            catch (Exception ex)
            {
                Log.Error($"Error squaring: {ex.Message}");
            }

            return null;
        }

        public double? Sqrt(int number, string operationId)
        {
            Log.Information($"MathService->Sqrt ({operationId})");

            var result = Sqrt(number);
            if (result != null && operationId != null)
            {
                _persistenceService.SaveOperation(operationId, CalculatorServiceConstants.SqrtOperation, new int[] { number }, result);
                Log.Information($"Sqrt Operation saved. {operationId}");
            }

            return result;
        }
    }
}
