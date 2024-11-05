using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
   public class Enquiries
    {
        public Int64 RId { get; set; }

        public Int64 EnquiryId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string ECaptcha { get; set; }

        public string Description { get; set; }

        public string Subject { get; set; }

        public string PhoneNo { get; set; }

        public Boolean IsActive { get; set; }

        public DateTime InsertedTime { get; set; }
    }
}
