using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class Events
    {
        public Int64 RId { get; set; }

        public Int64 EventId {get;set;}

	    public string EventName  {get;set;}

	    public DateTime StartDate  {get;set;}

	    public DateTime EndDate  {get;set;}

	    public DateTime RegistrationStartDate {get;set;}

	    public DateTime RegistrationEndDate  {get;set;}

	    public string BannerUrl  {get;set;}

        public Int64 SponsorsCount { get; set; }

	    public Int64 EventCategoryId  {get;set;}

        public string EventCategory { get; set; }

	    public int MemberCount  {get;set;}

	    public string Location  {get;set;}

	    public string City  {get;set;}

	    public string StateName  {get;set;}

	    public string ZipCode  {get;set;}

	    public string EventDetails  {get;set;}

	    public string ContactEmail  {get;set;}	   
       
	    public Boolean IsRegistration  {get;set;}

	    public string PageTitle  {get;set;}

	    public string MetaDescription  {get;set;}

	    public string MetaKeywords  {get;set;}

	    public string TopLine  {get;set;}

	    public string UpdatedBy  {get;set;}

        public DateTime UpdatedTime { get; set; }

        public bool IsChild { get; set; }

        public Decimal ChildAmount { get; set; }

        public Decimal NonChildAmount { get; set; }

        public bool IsAdult { get; set; }

        public Decimal AdultAmount { get; set; }

        public Decimal NonAdultAmount { get; set; }

        public bool IsCouple { get; set; }

        public Decimal CoupleAmount { get; set; }

        public Decimal NonCoupleAmount { get; set; }

        public bool IsFamily { get; set; }

        public Decimal FamilyAmount { get; set; }

        public Decimal NonFamilyAmount { get; set; }

        public bool IsVIP { get; set; }

        public Decimal VIPAmount { get; set; }

        public Decimal NonVIPAmount { get; set; }

        public bool IsVIPSingleAdult { get; set; }

        public Decimal VIPSingleAdultAmount { get; set; }

        public Decimal NonVIPSingleAdultAmount { get; set; }

        public bool IsVIPCouple { get; set; }

        public Decimal VIPCoupleAmount { get; set; }

        public Decimal NonVIPCoupleAmount { get; set; }

        public bool IsVIPChild { get; set; }

        public Decimal VIPChildAmount { get; set; }

        public Decimal NonVIPChildAmount { get; set; }

        public EventUserInfo objEventUserInfo = new EventUserInfo();

        public EventInfo objEventInfo = new EventInfo();

        public Int64 EventParticipantsCount { get; set; }

        public string XMLRegistrationsTypes { get; set; }

        public Int32 EventRegistrationTypesCount { get; set; }

        public string XMLRegistrations { get; set; }

        public string Guidlines { get; set; }

        public string RegistrationNotes { get; set; }

        public Decimal MemberAmount { get; set; }

        public Decimal NAmount { get; set; }

        public string CategoryName { get; set; }

        public bool IsCulturalRegistration { get; set; }
    }

    public class EventInfo
    {
        public Int64 RId { get; set; }

        public Int64 EventInfoId { get; set; }

        public Int64 EventId { get; set; }

        public string Guidlines { get; set; }

        public string RegistrationNotes { get; set; }

        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; } 
    }

    public class EventUserInfo
    {
        public Int64 RId { get; set; }

        public Int64 EventId { get; set; }

        public Decimal MemberAmount { get; set; }

        public Decimal NonMemberAmount { get; set; }

        public Int64 MemberId { get; set; }

        public string EventName { get; set; }

        public Int64 EventUserInfoId  { get; set; }

	    public string FirstName  { get; set; }

	    public string LastName { get; set; }

	    public string Email  { get; set; }

	    public string Gender  { get; set; }

	    public string Address  { get; set; }

	    public string City  { get; set; }

	    public string State  { get; set; }

	    public string Mobile  { get; set; }

        public string ItemName { get; set; }

        public string ItemCategory { get; set; }

        public string ItemDescription { get; set; }

        public int ItemDuration { get; set; }

	    public Boolean IsApproved  { get; set; }

	    public string DocumentUrl  { get; set; }

	    public string UpdatedBy  { get; set; }

        public DateTime UpdatedTime { get; set; }

        public DateTime InsertedTime { get; set; }

        public Int32 ChildCount { get; set; }

        public Int32 AdultCount { get; set; }

        public Int32 CoupleCount { get; set; }

        public Int32 FamilyCount { get; set; }

        public Int32 VIPCount { get; set; }

        public Int32 VIPSingleAdultCount { get; set; }

        public Int32 VIPChildCount { get; set; }

        public Int32 VIPCoupleCount { get; set; }

        public string Password { get; set; }

        public Int64 ChoreographerId { get; set; }

        public string XMLRegistrationsCounts { get; set; }

        // EventOrder

        public Int64 EventOrderId { get; set; }

        public DateTime ApprovedDate { get; set; }

        public Int64 PaymentStatusId { get; set; }

        public string PaymentStatus { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public Int64 PaymentMethodId { get; set; }

        public string TransactionId { get; set; }

        public Decimal AmountPaid { get; set; }

        public Boolean IsAttended { get; set; }

        public string InsertedBy { get; set; }

        public DateTime InsertedDate { get; set; }

        //Event Category

        public Int64 EventCategoryId { get; set; }

        public string EventCategory { get; set; }

        public Entities.EventOrderDetails objEventOrderDetails = new EventOrderDetails();

        public List<EventParticipants> lstEventParticipant = new List<EventParticipants>();

        //Coordinator Details

        public string CoorFirstName { get; set; }
        public string CoorLastName { get; set; }
        public string CoorEmail { get; set; }
        public string CoorMobileNo { get; set; }
        public string CoorCity { get; set; }

        public Int64 EventCommentId { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }

        public string AreYouEmployee { get; set; }

        public string AcceptTerms { get; set; }

        public string IsVolunteer { get; set; }

    }

    public class EventParticipants
    {
        public Int64 RId { get; set; }

        public Int64   EventParticipantId  { get; set; }

	    public Int64  EventId  { get; set; }

	    public Int64   EventUserInfoId { get; set; }

	    public string   FirstName  { get; set; }

	    public string LastName { get; set; }

	    public string Email { get; set; }

	    public string Age { get; set; }

	    public string Mobile { get; set; }

	    public Boolean IsApproved { get; set; }

	    public string UpdatedBy  { get; set; }        

	    public DateTime UpdatedTime  { get; set; }

        public string EventName { get; set; }

        public string CutOfDate { get; set; }
    }

    public class EventOrderDetails
    {
         public Int64 EventOrderId  { get; set; }

         public Int64 EventId  { get; set; }

	     public Int64 EventUserInfoId   { get; set; }

	     public Boolean IsApproved   { get; set; }

	     public DateTime ApprovedDate   { get; set; }

	     public Int64 PaymentStatusId   { get; set; }

         public string PaymentStatus { get; set; }

         public string PaymentMethod { get; set; }

	     public DateTime PaymentDate   { get; set; }

	     public Int64 PaymentMethodId   { get; set; }

         public string TransactionId { get; set; }

	     public Decimal AmountPaid   { get; set; }

	     public Boolean IsAttended  { get; set; }

	     public string InsertedBy   { get; set; }

	     public DateTime InsertedDate   { get; set; }

	     public string UpdatedBy   { get; set; }

         public DateTime UpdatedTime { get; set; }

         public Int32 ChildCount { get; set; }

         public Int32 AdultCount { get; set; }

         public Int32 CoupleCount { get; set; }

         public Int32 FamilyCount { get; set; }

         public Int32 VIPCount { get; set; }

         public Int32 VIPSingleAdultCount { get; set; }

         public Int32 VIPChildCount { get; set; }

         public Int32 VIPCoupleCount { get; set; } 
    }

    public class EventComments
    {
        public Int64 EventCommentId { get; set; }
        public Int64 EventUserInfoId { get; set; }
        public string Status { get; set; }
        public string AdminComment { get; set; }
        public string Comment { get; set; }
        public string InsertedBy { get; set; }
        public DateTime InsertedDate { get; set; }
        public string EmployeeRefUrl { get; set; }
        public string EmployeeCode { get; set; }

    }


    public class CulturalInfo
    {
        public Int64 RId { get; set; }

        public Int64 EventInfoId { get; set; }

        public Int64 EventId { get; set; }

        public string Guidlines { get; set; }

        public string RegistrationNotes { get; set; }

        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public string Field4 { get; set; }
        public string Field5 { get; set; }
        public string Field6 { get; set; }
        public string Field7 { get; set; }
        public string Field8 { get; set; }
    }

    public class CulturalUserInfo
    {
        public string DinnerBatch { get; set; }
        public Int64 RId { get; set; }

        public Int64 EventId { get; set; }

        public Decimal MemberAmount { get; set; }

        public Decimal NonMemberAmount { get; set; }

        public Int64 MemberId { get; set; }

        public string EventName { get; set; }

        public Int64 EventUserInfoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Mobile { get; set; }

        public string ItemName { get; set; }

        public string ItemCategory { get; set; }

        public string ItemDescription { get; set; }

        public int ItemDuration { get; set; }

        public Boolean IsApproved { get; set; }

        public string DocumentUrl { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public DateTime InsertedTime { get; set; }

        public Int32 ChildCount { get; set; }

        public Int32 AdultCount { get; set; }

        public Int32 CoupleCount { get; set; }

        public Int32 FamilyCount { get; set; }

        public Int32 VIPCount { get; set; }

        public Int32 VIPSingleAdultCount { get; set; }

        public Int32 VIPChildCount { get; set; }

        public Int32 VIPCoupleCount { get; set; }

        public string Password { get; set; }

        public Int64 ChoreographerId { get; set; }

        public string XMLRegistrationsCounts { get; set; }

        // EventOrder

        public Int64 CulturalOrderId { get; set; }

        public DateTime ApprovedDate { get; set; }

        public Int64 PaymentStatusId { get; set; }

        public string PaymentStatus { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public Int64 PaymentMethodId { get; set; }

        public string TransactionId { get; set; }

        public Decimal AmountPaid { get; set; }

        public Boolean IsAttended { get; set; }

        public string InsertedBy { get; set; }

        public DateTime InsertedDate { get; set; }

        //Event Category

        public Int64 EventCategoryId { get; set; }

        public string EventCategory { get; set; }

        public Entities.CulturalOrderDetails objEventOrderDetails = new CulturalOrderDetails();

        public List<CulturalParticipants> lstEventParticipant = new List<CulturalParticipants>();

        //Coordinator Details

        public string CoorFirstName { get; set; }
        public string CoorLastName { get; set; }
        public string CoorEmail { get; set; }
        public string CoorMobileNo { get; set; }
        public string CoorCity { get; set; }

        public Int64 EventCommentId { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }

    }

    public class CulturalParticipants
    {
        public Int64 RId { get; set; }

        public Int64 CulturalParticipantId { get; set; }

        public Int64 EventId { get; set; }

        public Int64 EventUserInfoId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Age { get; set; }

        public string Mobile { get; set; }

        public Boolean IsApproved { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public string EventName { get; set; }

        public string CutOfDate { get; set; }
    }

    public class CulturalOrderDetails
    {
        public Int64 CulturalOrderId { get; set; }

        public Int64 EventId { get; set; }

        public Int64 EventUserInfoId { get; set; }

        public Boolean IsApproved { get; set; }

        public DateTime ApprovedDate { get; set; }

        public Int64 PaymentStatusId { get; set; }

        public string PaymentStatus { get; set; }

        public string PaymentMethod { get; set; }

        public DateTime PaymentDate { get; set; }

        public Int64 PaymentMethodId { get; set; }

        public string TransactionId { get; set; }

        public Decimal AmountPaid { get; set; }

        public Boolean IsAttended { get; set; }

        public string InsertedBy { get; set; }

        public DateTime InsertedDate { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public Int32 ChildCount { get; set; }

        public Int32 AdultCount { get; set; }

        public Int32 CoupleCount { get; set; }

        public Int32 FamilyCount { get; set; }

        public Int32 VIPCount { get; set; }

        public Int32 VIPSingleAdultCount { get; set; }

        public Int32 VIPChildCount { get; set; }

        public Int32 VIPCoupleCount { get; set; }
    }
}
