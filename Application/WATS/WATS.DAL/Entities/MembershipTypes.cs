using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class MembershipTypes
    {
        public Int64 RId { get; set; }

        public Int64 MembershipTypeId { get; set; }

        public Int64 Validity { get; set; }

        public string MembershipType { get; set; }

        public Decimal Price { get; set; }
    }
}
