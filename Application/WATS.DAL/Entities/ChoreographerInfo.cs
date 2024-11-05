using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
   public class ChoreographerInfo
    {
        public Int64 RId { get; set; }

        public Int64 ChoreographerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string MobileNo { get; set; }

        public string Passion { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public Boolean IsActive { get; set; }

        public string Field1 { get; set; }

        public string InsertedBy { get; set; }

        public DateTime InsteredDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string VCaptcha { get; set; }

        //Coordinator Details

        public string CoorFirstName { get; set; }
        public string CoorLastName { get; set; }
        public string CoorEmail { get; set; }
        public string CoorMobileNo { get; set; }
        public string CoorCity { get; set; }


        public List<EventParticipants> lstEventParticipants { get; set; }
        public List<CulturalParticipants> lstEventParticipantsC { get; set; }
    }
}
