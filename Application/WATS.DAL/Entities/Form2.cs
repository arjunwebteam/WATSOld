﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class Form2
    {
        public Int64 RId { get; set; }

        public Int64 CulturalRegistrationId { get; set; }

        public Int64 EventId { get; set; }

        public Int64 RegistrationCategoryId { get; set; }

        public Int64 MemberId { get; set; }

        public string ProgramType { get; set; }

        public string ProgramName { get; set; }

        public string Description { get; set; }

        public string MediaTrack { get; set; }

        public string NumberOfParticipants { get; set; }

        public string Age { get; set; }

        public string ParticipantsFullNames { get; set; }

        public string ProgramDuration { get; set; }

        public string ChoreographerName { get; set; }

        public string ContactPhoneNumber { get; set; }

        public string ContactEmail { get; set; }

        public string SchoolName { get; set; }

        public bool TermsandConditions { get; set; }

        public bool IsApproved { get; set; }

        public DateTime ApprovedDate { get; set; }

        public Int64 PaymentStatusId { get; set; }

        public Int64 PaymentMethodId { get; set; }

        public DateTime PaymentDate { get; set; }

        public string TransactionId { get; set; }

        public Decimal AmountPaid { get; set; }

        public string BankName { get; set; }

        public string ChequeNo { get; set; }

        public DateTime ChequeDate { get; set; }

        public string AdminComments { get; set; }

        public string Field1 { get; set; }

        public string Field2 { get; set; }

        public string Field3 { get; set; }

        public string InstertedBy { get; set; }

        public DateTime InsertedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public string PaymentStatus { get; set; }

        public string PaymentMethod { get; set; }

        public string CategoryName { get; set; }

        public string EventName { get; set; }
    }
}