﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
   public class Form4
    {
        public Int64 RId { get; set; }  

        public Int64 EventRegistrationForm4Id { get; set; }

        public Int64 RegistrationCategoryId { get; set; }

        public Int64 EventId { get; set; }

        public Int64 MemberId { get; set; }

        public string Type { get; set; }

        public string BusinessName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Notes { get; set; }

        public bool TermsandConditions { get; set; }

        public bool IsApproved { get; set; }

        public DateTime ApprovedDate { get; set; }

        public Int64 PaymentStatusId { get; set; }

        public Int64 PaymentMethodId { get; set; }

        public DateTime PaymentDate { get; set; }

        public string TransactionId { get; set; }

        public decimal AmountPaid { get; set; }

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

        public string PaymentMethod { get; set; }

        public string PaymentStatus { get; set; }

        public string CategoryName { get; set; }

        public string EventName { get; set; }

        public string UserName { get; set; }
    }
}