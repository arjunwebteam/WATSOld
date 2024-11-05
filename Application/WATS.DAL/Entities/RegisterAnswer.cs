using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class RegisterAnswer
    {
        public Int64 RId { get; set; }
        public Int64 RegisterAnswerId { get; set; }
        public Int64 RegisterFieldId { get; set; }
        public Int64 EventId { get; set; }
        public string EventName { get; set; }
        public Int64 EventRegisterId { get; set; }
        public string Answer { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
