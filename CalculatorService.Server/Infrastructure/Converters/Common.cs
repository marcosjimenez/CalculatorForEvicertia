using CalculatorService.Model.Persistence;
using CalculatorService.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorService.Server.Infrastructure.Converters
{

    /// <summary>
    /// TODO: Change this to bigger mapper library (i.e. Automapper) when number of method increases
    /// </summary>
    public static class Common
    {

        public static JournalQueryResponseItem ToResponse(this PersistenceItem persistenceItem)
        {
            if (persistenceItem == null)
                throw new ArgumentNullException(nameof(persistenceItem));

            var retVal = new JournalQueryResponseItem { 
                Operation = persistenceItem.Name, 
                Date = persistenceItem.TimeStamp 
            };
            
            switch  (persistenceItem.Name)
            {
                case CalculatorServiceConstants.AddOperation:
                    retVal.Calculation = $"{string.Join(" + ", persistenceItem.Values)} = {persistenceItem.Result}";
                    break;
                case CalculatorServiceConstants.DivOperation:
                    retVal.Calculation = $"{persistenceItem.Values[0]} / {persistenceItem.Values[1]} = {persistenceItem.Result}";
                    break;
                case CalculatorServiceConstants.MultOperation:
                    retVal.Calculation = $"{string.Join(" * ", persistenceItem.Values)} = {persistenceItem.Result}";
                    break;
                case CalculatorServiceConstants.SqrtOperation:
                    retVal.Calculation = $"x ^ {persistenceItem.Values[0]} = {persistenceItem.Result}";
                    break;
                case CalculatorServiceConstants.SubOperation:
                    retVal.Calculation = $"{persistenceItem.Values[0]} - {persistenceItem.Values[1]} = {persistenceItem.Result}";
                    break;
            }

            return retVal;
        }

        public static JournalQueryResponse ToResponse(this List<PersistenceItem> items)
        {
            var retVal = new JournalQueryResponse();
            items.ForEach(x => retVal.Operations.Add(x.ToResponse()));

            return retVal;
        }

    }
}
