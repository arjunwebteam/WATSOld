using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;
namespace WATS.BLL
{
  public  class Form6
    {

        WATS.DAL.Form6 _Form6 = new WATS.DAL.Form6();

        #region Methods

        public Int64 InsertForm6(Entities.Form6 objForm6)
        {
            Int64 _status = 0;
            if (objForm6 != null)
            {
                _status = _Form6.InsertForm6(objForm6);

            }
            return _status;
        }

        public Int64 FEInsertForm6(Entities.Form6 objForm6, ref Int64 EventRegistrationForm6Id)
        {
            Int64 _status = 0;
            if (objForm6 != null)
            {
                _status = _Form6.FEInsertForm6(objForm6, ref EventRegistrationForm6Id);

            }
            return _status;
        }

        public Int64 UpdateForm6(Entities.Form6 objForm6)
        {
            Int64 _status = 0;
            if (objForm6 != null)
            {
                _status = _Form6.UpdateForm6(objForm6);

            }
            return _status;
        }


        public Int64 DeleteForm6(Int64 EventRegistrationForm6Id)
        {
            Int64 _status = 0;
            _status = _Form6.DeleteForm6(EventRegistrationForm6Id);
            return _status;
        }



        public Int64 UpdateForm6StatusById(Int64 EventRegistrationForm6Id)
        {
            Int64 _status = 0;
            _status = _Form6.UpdateForm6Status(EventRegistrationForm6Id);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.Form6> GetForm6List(ref int status)
        {
            List<WATS.Entities.Form6> lstForm6 = new List<WATS.Entities.Form6>();
            DataTable dt = _Form6.GetForm6List(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form6 objlstForm6 = new WATS.Entities.Form6();

                    objlstForm6.EventRegistrationForm6Id = Convert.ToInt64(dr["EventRegistrationForm6Id"].ToString());
                    objlstForm6.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm6.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm6.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm6.ParticipantName = (dr["ParticipantName"] != DBNull.Value ? dr["ParticipantName"].ToString() : null);
                    objlstForm6.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objlstForm6.ContactPhoneNo = (dr["ContactPhoneNo"] != DBNull.Value ? dr["ContactPhoneNo"].ToString() : null);
                    objlstForm6.ParticipationSection = (dr["ParticipationSection"] != DBNull.Value ? dr["ParticipationSection"].ToString() : null);
                    objlstForm6.USCFMembershipNo = (dr["USCFMembershipNo"] != DBNull.Value ? dr["USCFMembershipNo"].ToString() : null);
                    objlstForm6.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objlstForm6.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"]);
                    objlstForm6.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstForm6.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm6.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objlstForm6.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objlstForm6.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objlstForm6.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objlstForm6.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objlstForm6.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm6.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm6.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objlstForm6.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm6.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm6.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm6.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm6.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm6.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm6.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm6.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());


                    lstForm6.Add(objlstForm6);
                }

            }
            return lstForm6;
        }

        public WATS.Entities.Form6 GetForm6ById(Int64 EventRegistrationForm6Id, ref int status)
        {
            WATS.Entities.Form6 objForm6 = new WATS.Entities.Form6();
            DataTable dt = new DataTable();
            if (EventRegistrationForm6Id != 0)
            {
                dt = _Form6.GetForm6ById(EventRegistrationForm6Id, ref status);
                if (dt.Rows.Count == 1)
                {
                    objForm6.EventRegistrationForm6Id = Convert.ToInt64(dt.Rows[0]["EventRegistrationForm6Id"].ToString());
                    objForm6.EventId = (dt.Rows[0]["EventId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["EventId"]) : 0);
                    objForm6.RegistrationCategoryId = (dt.Rows[0]["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["RegistrationCategoryId"]) : 0);
                    objForm6.MemberId = (dt.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["MemberId"]) : 0);
                    objForm6.ParticipantName = (dt.Rows[0]["ParticipantName"] != DBNull.Value ? dt.Rows[0]["ParticipantName"].ToString() : "");
                    objForm6.Email = (dt.Rows[0]["Email"] != DBNull.Value ? dt.Rows[0]["Email"].ToString() : "");
                    objForm6.ContactPhoneNo = (dt.Rows[0]["ContactPhoneNo"] != DBNull.Value ? dt.Rows[0]["ContactPhoneNo"].ToString() : "");
                    objForm6.ParticipationSection = (dt.Rows[0]["ParticipationSection"] != DBNull.Value ? dt.Rows[0]["ParticipationSection"].ToString() : "");
                    objForm6.USCFMembershipNo = (dt.Rows[0]["USCFMembershipNo"] != DBNull.Value ? dt.Rows[0]["USCFMembershipNo"].ToString() : "");
                    objForm6.Notes = (dt.Rows[0]["Notes"] != DBNull.Value ? dt.Rows[0]["Notes"].ToString() : "");
                    objForm6.TermsandConditions = Convert.ToBoolean(dt.Rows[0]["TermsandConditions"].ToString());
                    objForm6.IsApproved = Convert.ToBoolean(dt.Rows[0]["IsApproved"].ToString());
                    objForm6.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objForm6.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objForm6.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objForm6.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objForm6.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objForm6.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objForm6.BankName = (dt.Rows[0]["BankName"] != DBNull.Value ? dt.Rows[0]["BankName"].ToString() : "");
                    objForm6.ChequeNo = (dt.Rows[0]["ChequeNo"] != DBNull.Value ? dt.Rows[0]["ChequeNo"].ToString() : "");
                    objForm6.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objForm6.AdminComments = (dt.Rows[0]["AdminComments"] != DBNull.Value ? dt.Rows[0]["AdminComments"].ToString() : "");
                    objForm6.Field1 = (dt.Rows[0]["Field1"] != DBNull.Value ? dt.Rows[0]["Field1"].ToString() : "");
                    objForm6.Field2 = (dt.Rows[0]["Field2"] != DBNull.Value ? dt.Rows[0]["Field2"].ToString() : "");
                    objForm6.Field3 = (dt.Rows[0]["Field3"] != DBNull.Value ? dt.Rows[0]["Field3"].ToString() : "");
                    objForm6.InstertedBy = dt.Rows[0]["InstertedBy"].ToString();
                    objForm6.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());
                    objForm6.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objForm6.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString());
                    objForm6.PaymentStatus = (dt.Rows[0]["PaymentStatus"] != DBNull.Value ? dt.Rows[0]["PaymentStatus"].ToString() : "");
                    objForm6.PaymentMethod = (dt.Rows[0]["PaymentMethod"] != DBNull.Value ? dt.Rows[0]["PaymentMethod"].ToString() : "");
                    objForm6.EventName = (dt.Rows[0]["EventName"] != DBNull.Value ? dt.Rows[0]["EventName"].ToString() : "");
                    objForm6.CategoryName = (dt.Rows[0]["CategoryName"] != DBNull.Value ? dt.Rows[0]["CategoryName"].ToString() : "");
              
                }
            }
            return objForm6;
        }

        public List<WATS.Entities.Form6> GetForm6ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 PaymentMethodId, Int64 PaymentStatusId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Form6> lstForm6 = new List<WATS.Entities.Form6>();
            DataTable dt = _Form6.GetForm6ListByVariable(EventId, RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo, Items, ref Total);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form6 objlstForm6 = new WATS.Entities.Form6();


                    objlstForm6.RId = Convert.ToInt64(dr["RId"].ToString());
                    objlstForm6.EventRegistrationForm6Id = Convert.ToInt64(dr["EventRegistrationForm6Id"].ToString());
                    objlstForm6.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm6.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm6.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm6.ParticipantName = (dr["ParticipantName"] != DBNull.Value ? dr["ParticipantName"].ToString() : null);
                    objlstForm6.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objlstForm6.ContactPhoneNo = (dr["ContactPhoneNo"] != DBNull.Value ? dr["ContactPhoneNo"].ToString() : null);
                    objlstForm6.ParticipationSection = (dr["ParticipationSection"] != DBNull.Value ? dr["ParticipationSection"].ToString() : null);
                    objlstForm6.USCFMembershipNo = (dr["USCFMembershipNo"] != DBNull.Value ? dr["USCFMembershipNo"].ToString() : null);
                    objlstForm6.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objlstForm6.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"]);
                    objlstForm6.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstForm6.ApprovedDate = (dr["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dr["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm6.PaymentStatusId = (dr["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentStatusId"]) : 0);
                    objlstForm6.PaymentMethodId = (dr["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentMethodId"]) : 0);
                    objlstForm6.PaymentDate = (dr["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["PaymentDate"]) : DateTime.MinValue);
                    objlstForm6.TransactionId = (dr["TransactionId"] != DBNull.Value ? dr["TransactionId"].ToString() : "");
                    objlstForm6.AmountPaid = (dr["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dr["AmountPaid"]) : 0);
                    objlstForm6.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm6.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm6.ChequeDate = (dr["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dr["ChequeDate"]) : DateTime.MinValue);
                    objlstForm6.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm6.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm6.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm6.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm6.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm6.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm6.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm6.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
                    objlstForm6.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    objlstForm6.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);

                    lstForm6.Add(objlstForm6);
                }

            }
            return lstForm6;
        }

        public List<WATS.Entities.Form6> GetFEForm6ListByVariable(Int64 EventId,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Form6> lstForm6 = new List<WATS.Entities.Form6>();
            DataTable dt = _Form6.GetFEForm6ListByVariable(EventId, Search, Sort, PageNo, Items, ref Total);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form6 objlstForm6 = new WATS.Entities.Form6();


                    objlstForm6.RId = Convert.ToInt64(dr["RId"].ToString());
                    objlstForm6.EventRegistrationForm6Id = Convert.ToInt64(dr["EventRegistrationForm6Id"].ToString());
                    objlstForm6.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm6.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm6.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm6.ParticipantName = (dr["ParticipantName"] != DBNull.Value ? dr["ParticipantName"].ToString() : null);
                    objlstForm6.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objlstForm6.ContactPhoneNo = (dr["ContactPhoneNo"] != DBNull.Value ? dr["ContactPhoneNo"].ToString() : null);
                    objlstForm6.ParticipationSection = (dr["ParticipationSection"] != DBNull.Value ? dr["ParticipationSection"].ToString() : null);
                    objlstForm6.USCFMembershipNo = (dr["USCFMembershipNo"] != DBNull.Value ? dr["USCFMembershipNo"].ToString() : null);
                    objlstForm6.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objlstForm6.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"]);
                    objlstForm6.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstForm6.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm6.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objlstForm6.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objlstForm6.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objlstForm6.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objlstForm6.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objlstForm6.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm6.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm6.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objlstForm6.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm6.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm6.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm6.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm6.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm6.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm6.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm6.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
                    objlstForm6.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    objlstForm6.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);

                    lstForm6.Add(objlstForm6);
                }

            }
            return lstForm6;
        }



        #endregion
    }
}