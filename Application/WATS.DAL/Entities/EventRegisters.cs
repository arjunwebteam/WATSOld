using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class EventRegisters
    {
        public Int64 RId { get; set; }
        public Int64 EventRegisterId { get; set; }
        public Int64 UserId { get; set; }
        public string UserIdentity { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 EventId { get; set; }
        public string EventName { get; set; }
        public bool IsApproved { get; set; }
        public DateTime ApprovedDate { get; set; }
        public Int64 PaymentStatusId { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public Int64 PaymentMethodId { get; set; }
        public string PaymentMethod { get; set; }
        public string TransctionId { get; set; }
        public decimal AmountPaid { get; set; }
        public bool IsAttended { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
