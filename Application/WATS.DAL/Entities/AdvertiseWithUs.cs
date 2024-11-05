using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class AdvertiseWithUs
    {

        public Int64 RId { get; set; }

        public Int64   AdvertiseWithUsId  { get; set;}

	    public string  CompanyName   { get; set;}

	    public string  FirstName   { get; set;}

	    public string  LastName   { get; set;}

	    public string  Email   { get; set;}

	    public string  PhoneNo   { get; set;}

	    public string  Address   { get; set;}

	    public string  ImageUrl   { get; set;}

	    public bool  IsActive   { get; set;}

	    public Decimal  Amount   { get; set;}

	    public string  TransactionId  { get; set;}

	    public Int64  PaymentStatusId { get; set;}

        public string PaymentStatus { get; set; }

	    public Int64  PaymentMethodId { get; set;}

        public string PaymentMethod { get; set; }

	    public DateTime  PaymentDate { get; set;}

	    public string  Comment   { get; set;}

	    public string  InsertedBy   { get; set;}

	    public DateTime  InsertedDate   { get; set;}

	    public string  UpdatedBy   { get; set;}

        public DateTime UpdatedDate { get; set; }

    }
}
