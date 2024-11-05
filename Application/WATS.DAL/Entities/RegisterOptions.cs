using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class RegisterOptions
    {
        public Int64 RId { get; set; }
        public Int64 RegisterOptionId { get; set; }
        public Int64 RegisterFieldId { get; set; }
        public string QOption { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
