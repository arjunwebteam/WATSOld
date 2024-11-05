using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class EventMembers
    {
        public Int64 RId { get; set; }
        public Int64 EventMemberId { get; set; }
        public Int64 EventId { get; set; }
        public string EventName { get; set; }
        public Int64 EventRegisterId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
