using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
   public  class YouthUserInfo
    {
        public Int64 RId { get; set; }

        public Int64 YouthUserInfoId {get;set;}

	    public string FirstName{get;set;}

	    public string LastName {get;set;}

	    public string Email {get;set;}

	    public string Mobile {get;set;}

	    public string Grade {get;set;}

	    public int Age {get;set;}

	    public string Hobbies {get;set;}

	    public string WhyCommitteeMember {get;set;}

	    public string AdminComment {get;set;}

	    public Boolean IsMember {get;set;}

	    public string UpdatedBy {get;set;}

        public DateTime UpdatedTime { get; set; }
    }
}
