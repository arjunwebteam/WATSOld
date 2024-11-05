using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class InnerPageCategories
    {
        public Int64 RId { get; set; }

        public Int64 InnerPageCategoryId { get; set; }

        public string CategoryName { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public Int64 InnerPagesCount { get; set; }
    }
}
