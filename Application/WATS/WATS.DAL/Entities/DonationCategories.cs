using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class DonationCategories
    {
        public Int64 RId { get; set; }

        public Int64 DonationCategoryId { get; set; }

        public string CategoryName { get; set; }

        public Int32 OrderNo { get; set; }

        public Boolean IsActive { get; set; }
    }
}
