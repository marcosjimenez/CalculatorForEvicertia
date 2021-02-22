using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using CalculatorService.Model.Persistence;
using CalculatorService.Server.Services.Interfaces;

namespace CalculatorService.Server.Services
{
    public class PersistenceService : IPersistenceService
    {

        private readonly ConcurrentQueue<PersistenceItem> _cache;

        public PersistenceService()
        {
            _cache = new ConcurrentQueue<PersistenceItem>();
        }

        /// <summary>
        /// Stores a operation on the cache
        /// </summary>
        /// <param name="name">Operation name</param>
        /// <param name="values">Array of values</param>
        /// <param name="result">Operation result</param>
        public void SaveOperation(string trackingID, string name, int[] values, object result)
        {
            var operation = new PersistenceItem(trackingID, name, values, result);
            _cache.Enqueue(operation);
        }

        /// <summary>
        /// Returns a cache stored item by Id
        /// </summary>
        /// <param name="id">ID to retrieve</param>
        /// <returns>PersistenceItem with the selected ID, null if not found</returns>
        public PersistenceItem GetOperation(string id)
        => _cache.FirstOrDefault(x => x.TrackingId == id);

        /// <summary>
        /// Returns all stored items with the provided tracking Id
        /// </summary>
        /// <param name="trackingId">Tracking Id</param>
        /// <returns>List of stored operations</returns>
        public List<PersistenceItem> Query(string trackingId)
        => _cache
            .Where(x => x.TrackingId.ToUpper() == trackingId.ToUpper())
            .ToList();
    }
}
