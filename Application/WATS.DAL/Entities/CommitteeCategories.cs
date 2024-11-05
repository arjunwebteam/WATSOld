using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
   public class CommitteeCategories
    {
        public Int64 CommitteeCategoryId { get; set; }        

        public Int64 RId { get; set; }

        public string CategoryName { get; set; }

        public string Type { get; set; }

        public int DisplayOrder { get; set; }

        public Boolean IsActive { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public Int64 CommitteeMemberCount { get; set; }
       
    }
    
}
