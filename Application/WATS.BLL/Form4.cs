using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;
namespace WATS.BLL
{
   public class Form4
    {
        WATS.DAL.Form4 _Form4 = new WATS.DAL.Form4();

        #region Methods

        public Int64 InsertForm4(Entities.Form4 objForm4)
        {
            Int64 _status = 0;
            if (objForm4 != null)
            {
                _status = _Form4.InsertForm4(objForm4);

            }
            return _status;
        }


        public Int64 UpdateForm4(Entities.Form4 objForm4)
        {
            Int64 _status = 0;
            if (objForm4 != null)
            {
                _status = _Form4.UpdateForm4(objForm4);

            }
            return _status;
        }


        public Int64 FEInsertForm4(Entities.Form4 objForm4, ref Int64 EventRegistrationForm4Id)
        {
            Int64 _status = 0;
            if (objForm4 != null)
            {
                _status = _Form4.FEInsertForm4(objForm4, ref EventRegistrationForm4Id);

            }
            return _status;
        }

        public Int64 DeleteForm4(Int64 EventRegistrationForm4Id)
        {
            Int64 _status = 0;
            _status = _Form4.DeleteForm4(EventRegistrationForm4Id);
            return _status;
        }

       

        public Int64 UpdateForm4StatusById(Int64 EventRegistrationForm4Id)
        {
            Int64 _status = 0;
            _status = _Form4.UpdateForm4Status(EventRegistrationForm4Id);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.Form4> GetForm4List(ref int status)
        {
            List<WATS.Entities.Form4> lstForm4 = new List<WATS.Entities.Form4>();
            DataTable dt = _Form4.GetForm4List(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form4 objlstForm4 = new WATS.Entities.Form4();

                    objlstForm4.EventRegistrationForm4Id = Convert.ToInt64(dr["EventRegistrationForm4Id"].ToString());
                    objlstForm4.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm4.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm4.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm4.Type = (dr["Type"] != DBNull.Value ? dr["Type"].ToString() : null);
                    objlstForm4.BusinessName = (dr["BusinessName"] != DBNull.Value ? dr["BusinessName"].ToString() : null);
                    objlstForm4.FullName = (dr["FullName"] != DBNull.Value ? dr["FullName"].ToString() : null);
                    objlstForm4.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objlstForm4.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                    objlstForm4.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objlstForm4.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"]);
                    objlstForm4.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstForm4.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm4.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objlstForm4.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objlstForm4.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objlstForm4.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objlstForm4.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objlstForm4.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm4.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm4.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objlstForm4.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm4.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm4.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm4.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm4.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm4.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm4.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm4.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());


                    lstForm4.Add(objlstForm4);
                }

            }
            return lstForm4;
        }

        public WATS.Entities.Form4 GetForm4ById(Int64 EventRegistrationForm4Id, ref int status)
        {
            WATS.Entities.Form4 objForm4 = new WATS.Entities.Form4();
            DataTable dt = new DataTable();
            if (EventRegistrationForm4Id != 0)
            {
                dt = _Form4.GetForm4ById(EventRegistrationForm4Id, ref status);
                if (dt.Rows.Count == 1)
                {
                    objForm4.EventRegistrationForm4Id = Convert.ToInt64(dt.Rows[0]["EventRegistrationForm4Id"].ToString());
                    objForm4.RegistrationCategoryId = (dt.Rows[0]["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["RegistrationCategoryId"]) : 0);
                    objForm4.EventId = (dt.Rows[0]["EventId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["EventId"]) : 0);
                    objForm4.MemberId = (dt.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["MemberId"]) : 0);
                    objForm4.Type = (dt.Rows[0]["Type"] != DBNull.Value ? dt.Rows[0]["Type"].ToString() : "");
                    objForm4.BusinessName = (dt.Rows[0]["BusinessName"] != DBNull.Value ? dt.Rows[0]["BusinessName"].ToString() : "");
                    objForm4.FullName = (dt.Rows[0]["FullName"] != DBNull.Value ? dt.Rows[0]["FullName"].ToString() : "");
                    objForm4.Email = (dt.Rows[0]["Email"] != DBNull.Value ? dt.Rows[0]["Email"].ToString() : "");
                    objForm4.PhoneNo = (dt.Rows[0]["PhoneNo"] != DBNull.Value ? dt.Rows[0]["PhoneNo"].ToString() : "");
                    objForm4.Notes = (dt.Rows[0]["Notes"] != DBNull.Value ? dt.Rows[0]["Notes"].ToString() : "");
                    objForm4.TermsandConditions = Convert.ToBoolean(dt.Rows[0]["TermsandConditions"].ToString());
                    objForm4.IsApproved = Convert.ToBoolean(dt.Rows[0]["IsApproved"].ToString());
                    objForm4.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objForm4.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objForm4.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objForm4.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objForm4.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objForm4.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objForm4.BankName = (dt.Rows[0]["BankName"] != DBNull.Value ? dt.Rows[0]["BankName"].ToString() : "");
                    objForm4.ChequeNo = (dt.Rows[0]["ChequeNo"] != DBNull.Value ? dt.Rows[0]["ChequeNo"].ToString() : "");
                    objForm4.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objForm4.AdminComments = (dt.Rows[0]["AdminComments"] != DBNull.Value ? dt.Rows[0]["AdminComments"].ToString() : "");
                    objForm4.Field1 = (dt.Rows[0]["Field1"] != DBNull.Value ? dt.Rows[0]["Field1"].ToString() : "");
                    objForm4.Field2 = (dt.Rows[0]["Field2"] != DBNull.Value ? dt.Rows[0]["Field2"].ToString() : "");
                    objForm4.Field3 = (dt.Rows[0]["Field3"] != DBNull.Value ? dt.Rows[0]["Field3"].ToString() : "");
                    objForm4.InstertedBy = dt.Rows[0]["InstertedBy"].ToString();
                    objForm4.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());
                    objForm4.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objForm4.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString());
                    objForm4.EventName = (dt.Rows[0]["EventName"] != DBNull.Value ? dt.Rows[0]["EventName"].ToString() : "");
                    objForm4.CategoryName = (dt.Rows[0]["CategoryName"] != DBNull.Value ? dt.Rows[0]["CategoryName"].ToString() : "");
                    objForm4.PaymentStatus = (dt.Rows[0]["PaymentStatus"] != DBNull.Value ? dt.Rows[0]["PaymentStatus"].ToString() : "");
                    objForm4.PaymentMethod = (dt.Rows[0]["PaymentMethod"] != DBNull.Value ? dt.Rows[0]["PaymentMethod"].ToString() : "");
                    objForm4.UserName = (dt.Rows[0]["UserName"] != DBNull.Value ? dt.Rows[0]["UserName"].ToString() : "");

                }
            }
            return objForm4;
        }

        public List<WATS.Entities.Form4> GetForm4ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentStatusId, Int64 PaymentMethodId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Form4> lstForm4 = new List<WATS.Entities.Form4>();
            DataTable dt = _Form4.GetForm4ListByVariable(EventId, RegistrationCategoryId, MemberId, PaymentStatusId, PaymentMethodId, Search, Sort, PageNo, Items, ref Total);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form4 objlstForm4 = new WATS.Entities.Form4();

                    objlstForm4.RId = Convert.ToInt64(dr["RId"].ToString());
                    objlstForm4.EventRegistrationForm4Id = Convert.ToInt64(dr["EventRegistrationForm4Id"].ToString());
                    objlstForm4.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm4.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm4.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm4.Type = (dr["Type"] != DBNull.Value ? dr["Type"].ToString() : null);
                    objlstForm4.BusinessName = (dr["BusinessName"] != DBNull.Value ? dr["BusinessName"].ToString().Trim() : null);
                    objlstForm4.FullName = (dr["FullName"] != DBNull.Value ? dr["FullName"].ToString() : null);
                    objlstForm4.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objlstForm4.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                    objlstForm4.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objlstForm4.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"]);
                    objlstForm4.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstForm4.ApprovedDate = (dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm4.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objlstForm4.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objlstForm4.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objlstForm4.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : "");
                    objlstForm4.AmountPaid = (dt.Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["AmountPaid"]) : 0);
                    objlstForm4.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm4.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm4.ChequeDate = (dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objlstForm4.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm4.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm4.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm4.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm4.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm4.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm4.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm4.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
                    objlstForm4.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
                    objlstForm4.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);

                  
                    lstForm4.Add(objlstForm4);
                }

            }
            return lstForm4;
        }


        #endregion
    }
}