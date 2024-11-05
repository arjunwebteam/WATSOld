using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
   public class VolunteerCategories
    {

        public Int64 RId { get; set; }

        public Int64 VolunteerCategoryId { get; set; }

        public string CategoryName { get; set; }

        public int OrderNo { get; set; }

        public Boolean IsActive { get; set; }

        public Int32 VolunteerCount { get; set; }

        public string Type { get; set; }
    }
}
