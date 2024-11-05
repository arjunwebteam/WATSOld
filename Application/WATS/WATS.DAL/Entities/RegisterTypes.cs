using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class RegisterTypes
    {
        public Int64 RId { get; set; }

        public Int64 RegisterTypeId { get; set; }

        public string RegisterType { get; set; }

        public bool IsActive { get; set; }

        public decimal Amount { get; set; }

        public decimal Duration { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
