using System;
using System.Collections.Generic;

namespace CalculatorService.Model.Response
{
    public class JournalQueryResponse
    {
        public IList<JournalQueryResponseItem> Operations { get; set; }
        public JournalQueryResponse()
        {
            Operations = new List<JournalQueryResponseItem>();
        }
    }

    public class JournalQueryResponseItem
    {
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public DateTime Date { get; set; }
    }

}
