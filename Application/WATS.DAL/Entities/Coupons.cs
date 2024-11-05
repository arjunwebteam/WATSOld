using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class Coupons
    {
         public Int64 RId { get; set; }

         public Int64  CouponId {get;set;}

         public Int64 MemberId { get; set; }

	     public Int64 MembershipTypeId  {get;set;}

         public string MembershipType { get; set; }

	     public string CouponName  {get;set;}

	     public string LogoUrl  {get;set;}

	     public string DocumentUrl  {get;set;}

	     public string RedirectUrl  {get;set;}

	     public string Description  {get;set;}

	     public Boolean IsActive {get;set;}

	     public string UpdatedBy  {get;set;}

         public DateTime UpdatedTime { get; set; }

    }
}
