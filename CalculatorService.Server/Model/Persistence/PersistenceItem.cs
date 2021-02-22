using System;

namespace CalculatorService.Model.Persistence
{
    public class PersistenceItem
    {

        public PersistenceItem(string trackingId, string name, int[] values, object result)
        {
            TrackingId = trackingId;
            Name = name;
            Values = values;
            Result = result;
            TimeStamp = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string TrackingId { get; set; }
        public string Name { get; set; }
        public int[] Values { get; set; }
        public object Result { get; set; }
        public DateTime TimeStamp { get; set; }

    }
}
