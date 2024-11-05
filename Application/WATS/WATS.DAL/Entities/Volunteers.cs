using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class Volunteers
    {
        public Int64 RId { get; set; }

        public Int64 VolunteerId { get; set; }
		public Int64 VolunteerCategoryId { get; set; }
		public Int64 EventId { get; set; }
		public Int64 TRegistrationId { get; set; }

		public string FirstName  { get; set; }

	    public string LastName  { get; set; }

	    public string Email  { get; set; }

	    public string PhoneNo  { get; set; }

	    public string Address  { get; set; }

	    public string Comment  { get; set; }
		public string Profile { get; set; }
		public string Password { get; set; }
		public string CompanyName { get; set; }
		public string Designation { get; set; }
		public string HoursSpent { get; set; }
		public string SchoolName { get; set; }
		public string Gradeinschool { get; set; }
		public string Age { get; set; }
		public string Notes { get; set; }
		public string Field1 { get; set; }
		public string Field2 { get; set; }
		public string Field3 { get; set; }
		public string Field4 { get; set; }

		public bool IsActive  { get; set; }

	    public string InsertedBy  { get; set; }

	    public DateTime InsertedDate { get; set; }

	    public string UpdatedBy  { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string VCaptcha { get; set; }
		public string CName { get; set; }
	}
}

