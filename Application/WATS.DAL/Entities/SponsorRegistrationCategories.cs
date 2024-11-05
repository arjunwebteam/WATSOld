using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
    public class SponsorRegistrationCategories
    {
        public Int64 RId { get; set; }
        public Int64 SponsorRegistrationCategoryId { get; set; }
        public Int64 EventId { get; set; }
        public string Description { get; set; }
        public int OrderNo { get; set; }
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public bool IsActive { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string EventName { get; set; }
        public string BannerDisplay { get; set; }
        public string DinnerTickets { get; set; }
    }
}
