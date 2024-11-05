using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
    public class SponsorRegistrations
    {
        public Int64 RId { get; set; }

        public Int64 SponsorRegistrationId { get; set; }

        public Int64 SponsorRegistrationCategoryId { get; set; }

        public string CategoryName { get; set; }

        public Int64 MemberId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Address { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public Decimal Amount { get; set; }

        public string TransactionId { get; set; }

        public Int64 PaymentStatusId { get; set; }

        public string PaymentStatus { get; set; }

        public Int64 PaymentMethodId { get; set; }

        public string PaymentMethod { get; set; }

        public string EventName { get; set; }

        public DateTime OrderDate { get; set; }

        public string PaymentBy { get; set; }

        public string InsertedBy { get; set; }

        public DateTime InsertedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string CardNumber { get; set; }

        public string DCaptcha { get; set; }

        public string CSVMonth { get; set; }

        public string CSVYear { get; set; }

        public string Cvv { get; set; }
    }
}
