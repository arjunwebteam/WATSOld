using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
  public  class TeluguBadiRegistrations
    {

        public Int64 RId { get; set; }

        public Int64 TRegistrationId { get; set; }
        public Int64 MemberId { get; set; }

        public string FatherFirstName { get; set; }

        public string FatherLastName { get; set; }

        public string FatherEmail { get; set; }
        public string FatherPhoneNo { get; set; }

        public string MotherFirstName { get; set; }

        public string MotherLastName { get; set; }

        public string MotherEmail { get; set; }
        public string MotherPhoneNo { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string TeluguBadiCenterName { get; set; }
        public string VolunteerFor { get; set; }
        public Boolean IsApproved { get; set; }
        public string InsertedBy { get; set; }

        public DateTime InsertedDate { get; set; }
        public string UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentMethod { get; set; }

        public string Type { get; set; }
        public Int64 TeluguBadiTypeId { get; set; }
        public DateTime ExpiryDate{ get; set; }
        public DateTime OrderDate { get; set; }
        public Int64 PaymentStatusId { get; set; }
        public Int64 PaymentMethodId { get; set; }
         
        public decimal Amount { get; set; }
        public TeluguBadiStudents objTeluguBadiStudents = new TeluguBadiStudents();
        public List<TeluguBadiStudents> lstTeluguBadiStudents { get; set; }


        public TeluguBadiOrders objTeluguBadiOrders = new TeluguBadiOrders();
        public List<TeluguBadiOrders> lstTeluguBadiOrders { get; set; }
        public List<TeluguBadiTypes> lstTeluguBadiTypes { get; set; }
        public List<PaymentStatus> lstPaymentStatus { get; set; }

        public List<PaymentMethods> lstPaymentMethod { get; set; }

        public string UserName { get; set; }

    }

    public class TeluguBadiStudents
    {
        public Int64 RId { get; set; }

    public Int64 TStudentId { get; set; }
    public Int64 TRegistrationId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Int64  Age { get; set; }
    public string LevelOfferings { get; set; }
    public string Comments { get; set; }
    public string Field1 { get; set; }

    public string InsertedBy { get; set; }

    public DateTime InsertedDate { get; set; }
    public string UpdatedBy { get; set; }

    public DateTime UpdatedDate { get; set; }


    }


    public class TeluguBadiOrders
    {
        public Int64 RId { get; set; }

        public Int64 OrderId { get; set; }
        public Int64 TRegistrationId { get; set; }
        public string FatherFirstName { get; set; }
        public string FatherLastName { get; set; }
        public Int64 TeluguBadiTypeId { get; set; }
        public string Type { get; set; }
        public decimal Amount { get; set; }
        public string TransactionId { get; set; }
        public Int64 PaymentStatusId { get; set; }
        public Int64 PaymentMethodId { get; set; }
        public string PaymentBy { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderDate1 { get; set; }

        public DateTime ExpiryDate { get; set; }
        public string ExpiryDate1 { get; set; }

        
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; } 
    }


}
