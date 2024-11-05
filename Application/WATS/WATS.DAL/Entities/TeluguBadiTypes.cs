using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
   public class TeluguBadiTypes
    {
        public Int64 RId { get; set; }
        public Int64 TeluguBadiTypeId { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public Int64 Year { get; set; }
        public DateTime ExpiryDate { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 OrderNo { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string ExpiryDate1 { get; set; }




    }
}
