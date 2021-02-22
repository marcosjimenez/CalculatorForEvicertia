using System.Collections.Generic;
using CalculatorService.Model.Persistence;

namespace CalculatorService.Server.Services.Interfaces
{
    public interface IPersistenceService
    {
        void SaveOperation(string trackingID, string name, int[] values, object result);
        PersistenceItem GetOperation(string id);
        List<PersistenceItem> Query(string trackingId);
    }
}