using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;
namespace WATS.BLL
{
  public  class Form5
    {

        WATS.DAL.Form5 _Form5 = new WATS.DAL.Form5();

        #region Methods

        public Int64 InsertForm5(Entities.Form5 objForm5)
        {
            Int64 _status = 0;
            if (objForm5 != null)
            {
                _status = _Form5.InsertForm5(objForm5);

            }
            return _status;
        }

        public Int64 FEInsertForm5(Entities.Form5 objForm5, ref Int64 EventRegistrationForm5Id)
        {
            Int64 _status = 0;
            if (objForm5 != null)
            {
                _status = _Form5.FEInsertForm5(objForm5, ref EventRegistrationForm5Id);

            }
            return _status;
        }

        public Int64 UpdateForm5(Entities.Form5 objForm5)
        {
            Int64 _status = 0;
            if (objForm5 != null)
            {
                _status = _Form5.UpdateForm5(objForm5);

            }
            return _status;
        }

        public Int64 DeleteForm5(Int64 EventRegistrationForm5Id)
        {
            Int64 _status = 0;
            _status = _Form5.DeleteForm5(EventRegistrationForm5Id);
            return _status;
        }



        public Int64 UpdateForm5StatusById(Int64 EventRegistrationForm5Id)
        {
            Int64 _status = 0;
            _status = _Form5.UpdateForm5Status(EventRegistrationForm5Id);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.Form5> GetForm5List(ref int status)
        {
            List<WATS.Entities.Form5> lstForm5 = new List<WATS.Entities.Form5>();
            DataTable dt = _Form5.GetForm5List(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form5 objlstForm5 = new WATS.Entities.Form5();

                    objlstForm5.EventRegistrationForm5Id = Convert.ToInt64(dr["EventRegistrationForm5Id"].ToString());
                    objlstForm5.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm5.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm5.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm5.TeamName = (dr["TeamName"] != DBNull.Value ? dr["TeamName"].ToString() : null);
                    objlstForm5.PContactName = (dr["PContactName"] != DBNull.Value ? dr["PContactName"].ToString() : null);
                    objlstForm5.PContactEmail = (dr["PContactEmail"] != DBNull.Value ? dr["PContactEmail"].ToString() : null);
                    objlstForm5.PContactPhoneNo = (dr["PContactPhoneNo"] != DBNull.Value ? dr["PContactPhoneNo"].ToString() : null);
                    objlstForm5.SContactName = (dr["SContactName"] != DBNull.Value ? dr["SContactName"].ToString() : null);
                    objlstForm5.SContactEmail = (dr["SContactEmail"] != DBNull.Value ? dr["SContactEmail"].ToString() : null);
                    objlstForm5.SContactPhoneNo = (dr["SContactPhoneNo"] != DBNull.Value ? dr["SContactPhoneNo"].ToString() : null);
                    objlstForm5.SportsType = (dr["SportsType"] != DBNull.Value ? dr["SportsType"].ToString() : null);
                    objlstForm5.SportsCategory = (dr["SportsCategory"] != DBNull.Value ? dr["SportsCategory"].ToString() : null);
                    objlstForm5.ParticipantsFullNames = (dr["ParticipantsFullNames"] != DBNull.Value ? dr["ParticipantsFullNames"].ToString() : null);
                    objlstForm5.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"]);
                    objlstForm5.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstForm5.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm5.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objlstForm5.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objlstForm5.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objlstForm5.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objlstForm5.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objlstForm5.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm5.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm5.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objlstForm5.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm5.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm5.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm5.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm5.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm5.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm5.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm5.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());


                    lstForm5.Add(objlstForm5);
                }

            }
            return lstForm5;
        }

        public WATS.Entities.Form5 GetForm5ById(Int64 EventRegistrationForm5Id, ref int status)
        {
            WATS.Entities.Form5 objForm5 = new WATS.Entities.Form5();
            DataTable dt = new DataTable();
            if (EventRegistrationForm5Id != 0)
            {
                dt = _Form5.GetForm5ById(EventRegistrationForm5Id, ref status);
                if (dt.Rows.Count == 1)
                {
                    objForm5.EventRegistrationForm5Id = Convert.ToInt64(dt.Rows[0]["EventRegistrationForm5Id"].ToString());
                    objForm5.EventId = (dt.Rows[0]["EventId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["EventId"]) : 0);
                    objForm5.RegistrationCategoryId = (dt.Rows[0]["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["RegistrationCategoryId"]) : 0);
                    objForm5.MemberId = (dt.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["MemberId"]) : 0);
                    objForm5.TeamName = (dt.Rows[0]["TeamName"] != DBNull.Value ? dt.Rows[0]["TeamName"].ToString() : "");
                    objForm5.PContactName = (dt.Rows[0]["PContactName"] != DBNull.Value ? dt.Rows[0]["PContactName"].ToString() : "");
                    objForm5.PContactEmail = (dt.Rows[0]["PContactEmail"] != DBNull.Value ? dt.Rows[0]["PContactEmail"].ToString() : "");
                    objForm5.PContactPhoneNo = (dt.Rows[0]["PContactPhoneNo"] != DBNull.Value ? dt.Rows[0]["PContactPhoneNo"].ToString() : "");
                    objForm5.PContactEmail = (dt.Rows[0]["PContactEmail"] != DBNull.Value ? dt.Rows[0]["PContactEmail"].ToString() : "");
                    objForm5.SContactName = (dt.Rows[0]["SContactName"] != DBNull.Value ? dt.Rows[0]["SContactName"].ToString() : "");
                    objForm5.SContactEmail = (dt.Rows[0]["SContactEmail"] != DBNull.Value ? dt.Rows[0]["SContactEmail"].ToString() : "");
                    objForm5.SContactPhoneNo = (dt.Rows[0]["SContactPhoneNo"] != DBNull.Value ? dt.Rows[0]["SContactPhoneNo"].ToString() : "");
                    objForm5.SportsType = (dt.Rows[0]["SportsType"] != DBNull.Value ? dt.Rows[0]["SportsType"].ToString() : "");
                    objForm5.SportsCategory = (dt.Rows[0]["SportsCategory"] != DBNull.Value ? dt.Rows[0]["SportsCategory"].ToString() : "");
                    objForm5.ParticipantsFullNames = (dt.Rows[0]["ParticipantsFullNames"] != DBNull.Value ? dt.Rows[0]["ParticipantsFullNames"].ToString() : "");
                    objForm5.TermsandConditions = Convert.ToBoolean(dt.Rows[0]["TermsandConditions"].ToString());
                    objForm5.IsApproved = Convert.ToBoolean(dt.Rows[0]["IsApproved"].ToString());
                    objForm5.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objForm5.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objForm5.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objForm5.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objForm5.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objForm5.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objForm5.BankName = (dt.Rows[0]["BankName"] != DBNull.Value ? dt.Rows[0]["BankName"].ToString() : "");
                    objForm5.ChequeNo = (dt.Rows[0]["ChequeNo"] != DBNull.Value ? dt.Rows[0]["ChequeNo"].ToString() : "");
                    objForm5.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objForm5.AdminComments = (dt.Rows[0]["AdminComments"] != DBNull.Value ? dt.Rows[0]["AdminComments"].ToString() : "");
                    objForm5.Field1 = (dt.Rows[0]["Field1"] != DBNull.Value ? dt.Rows[0]["Field1"].ToString() : "");
                    objForm5.Field2 = (dt.Rows[0]["Field2"] != DBNull.Value ? dt.Rows[0]["Field2"].ToString() : "");
                    objForm5.Field3 = (dt.Rows[0]["Field3"] != DBNull.Value ? dt.Rows[0]["Field3"].ToString() : "");
                    objForm5.InstertedBy = dt.Rows[0]["InstertedBy"].ToString();
                    objForm5.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());
                    objForm5.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objForm5.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString());
                    objForm5.EventName = (dt.Rows[0]["EventName"] != DBNull.Value ? dt.Rows[0]["EventName"].ToString() : "");
                    objForm5.CategoryName = (dt.Rows[0]["CategoryName"] != DBNull.Value ? dt.Rows[0]["CategoryName"].ToString() : "");
                    objForm5.PaymentStatus = (dt.Rows[0]["PaymentStatus"] != DBNull.Value ? dt.Rows[0]["PaymentStatus"].ToString() : "");
                    objForm5.PaymentMethod = (dt.Rows[0]["PaymentMethod"] != DBNull.Value ? dt.Rows[0]["PaymentMethod"].ToString() : "");
                    objForm5.UserName = (dt.Rows[0]["UserName"] != DBNull.Value ? dt.Rows[0]["UserName"].ToString() : "");

                }
            }
            return objForm5;
        }

        public List<WATS.Entities.Form5> GetForm5ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentStatusId, Int64 PaymentMethodId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Form5> lstForm5 = new List<WATS.Entities.Form5>();
            DataTable dt = _Form5.GetForm5ListByVariable(EventId, RegistrationCategoryId, MemberId, PaymentStatusId, PaymentMethodId, Search, Sort, PageNo, Items, ref Total);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form5 objlstForm5 = new WATS.Entities.Form5();
                    objlstForm5.RId = Convert.ToInt64(dr["RId"].ToString());
                    objlstForm5.EventRegistrationForm5Id = Convert.ToInt64(dr["EventRegistrationForm5Id"].ToString());
                    objlstForm5.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm5.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm5.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm5.TeamName = (dr["TeamName"] != DBNull.Value ? dr["TeamName"].ToString() : null);
                    objlstForm5.PContactName = (dr["PContactName"] != DBNull.Value ? dr["PContactName"].ToString() : null);
                    objlstForm5.PContactEmail = (dr["PContactEmail"] != DBNull.Value ? dr["PContactEmail"].ToString() : null);
                    objlstForm5.PContactPhoneNo = (dr["PContactPhoneNo"] != DBNull.Value ? dr["PContactPhoneNo"].ToString() : null);
                    objlstForm5.SContactName = (dr["SContactName"] != DBNull.Value ? dr["SContactName"].ToString() : null);
                    objlstForm5.SContactEmail = (dr["SContactEmail"] != DBNull.Value ? dr["SContactEmail"].ToString() : null);
                    objlstForm5.SContactPhoneNo = (dr["SContactPhoneNo"] != DBNull.Value ? dr["SContactPhoneNo"].ToString() : null);
                    objlstForm5.SportsType = (dr["SportsType"] != DBNull.Value ? dr["SportsType"].ToString() : null);
                    objlstForm5.SportsCategory = (dr["SportsCategory"] != DBNull.Value ? dr["SportsCategory"].ToString() : null);
                    objlstForm5.ParticipantsFullNames = (dr["ParticipantsFullNames"] != DBNull.Value ? dr["ParticipantsFullNames"].ToString() : null);
                    objlstForm5.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"]);
                    objlstForm5.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstForm5.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm5.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objlstForm5.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objlstForm5.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objlstForm5.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objlstForm5.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objlstForm5.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm5.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm5.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objlstForm5.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm5.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm5.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm5.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm5.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm5.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm5.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm5.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
                    objlstForm5.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
                    objlstForm5.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);



                    lstForm5.Add(objlstForm5);
                }

            }
            return lstForm5;
        }


        #endregion
    }
}