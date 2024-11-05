using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;

namespace WATS.BLL
{
    public  class Form3
    {
        WATS.DAL.Form3 _Form3 = new WATS.DAL.Form3();

        #region Methods

        public Int64 InsertForm3(Entities.Form3 objForm3)
        {
            Int64 _status = 0;
            if (objForm3 != null)
            {
                _status = _Form3.InsertForm3(objForm3);

            }
            return _status;
        }

        public Int64 FEInsertForm3(Entities.Form3 objForm3, ref Int64 EventRegistrationForm3Id)
        {
            Int64 _status = 0;
            if (objForm3 != null)
            {
                _status = _Form3.FEInsertForm3(objForm3, ref EventRegistrationForm3Id);

            }
            return _status;
        }

        public Int64 UpdateForm3(Entities.Form3 objForm3)
        {
            Int64 _status = 0;
            if (objForm3 != null)
            {
                _status = _Form3.UpdateForm3(objForm3);

            }
            return _status;
        }


        public Int64 DeleteForm3(Int64 EventRegistrationForm3Id)
        {
            Int64 _status = 0;
            _status = _Form3.DeleteForm3ById(EventRegistrationForm3Id);
            return _status;
        }


        public Int64 UpdateForm3StatusById(Int64 EventRegistrationForm3Id)
        {
            Int64 _status = 0;
            _status = _Form3.UpdateForm3StatusById(EventRegistrationForm3Id);
            return _status;
        }


        #endregion

        #region Entities filling

        public List<WATS.Entities.Form3> GetForm3List(ref int status)
        {
            List<WATS.Entities.Form3> lstForm3 = new List<WATS.Entities.Form3>();
            DataTable dt = _Form3.GetForm3List(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form3 objlstForm3 = new WATS.Entities.Form3();

                    objlstForm3.EventRegistrationForm3Id = Convert.ToInt64(dr["EventRegistrationForm3Id"].ToString());
                    objlstForm3.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm3.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm3.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstForm3.FirstName = (dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : null);
                    objlstForm3.LastName = (dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : null);
                    objlstForm3.ContactPhone = (dr["ContactPhone"] != DBNull.Value ? dr["ContactPhone"].ToString() : null);
                    objlstForm3.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objlstForm3.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objlstForm3.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"] != DBNull.Value ? Convert.ToBoolean(dr["TermsandConditions"]) : false);
                    objlstForm3.IsApproved = Convert.ToBoolean(dr["IsApproved"] != DBNull.Value ? Convert.ToBoolean(dr["IsApproved"]) : false);
                    objlstForm3.ApprovedDate = Convert.ToDateTime(dr["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dr["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm3.PaymentStatusId = (dr["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentStatusId"]) : 0);
                    objlstForm3.PaymentMethodId = (dr["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentMethodId"]) : 0);
                    objlstForm3.PaymentDate = Convert.ToDateTime(dr["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["PaymentDate"]) : DateTime.MinValue);
                    objlstForm3.TransactionId = (dr["TransactionId"] != DBNull.Value ? dr["TransactionId"].ToString() : null);
                    objlstForm3.AmountPaid = Convert.ToDecimal(dr["AmountPaid"] != DBNull.Value ? dr["AmountPaid"].ToString() : null);
                    objlstForm3.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm3.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm3.ChequeDate = Convert.ToDateTime(dr["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dr["ChequeDate"]) : DateTime.MinValue);
                    objlstForm3.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm3.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm3.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm3.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm3.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm3.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm3.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm3.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());


                    lstForm3.Add(objlstForm3);
                }

            }
            return lstForm3;
        }

        public WATS.Entities.Form3 GetForm3ById(Int64 EventRegistrationForm3Id, ref int status)
        {
            WATS.Entities.Form3 objForm3 = new WATS.Entities.Form3();
            DataTable dt = new DataTable();
            if (EventRegistrationForm3Id != 0)
            {
                dt = _Form3.GetForm3ById(EventRegistrationForm3Id, ref status);
                if (dt.Rows.Count == 1)
                {
             
                    objForm3.EventRegistrationForm3Id = Convert.ToInt64(dt.Rows[0]["EventRegistrationForm3Id"].ToString());
                    objForm3.EventId = (dt.Rows[0]["EventId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["EventId"]) : 0);
                    objForm3.RegistrationCategoryId = (dt.Rows[0]["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["RegistrationCategoryId"]) : 0);
                    objForm3.MemberId = (dt.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["MemberId"]) : 0);
                    objForm3.FirstName = (dt.Rows[0]["FirstName"] != DBNull.Value ? dt.Rows[0]["FirstName"].ToString() : null);
                    objForm3.LastName = (dt.Rows[0]["LastName"] != DBNull.Value ? dt.Rows[0]["LastName"].ToString() : null);
                    objForm3.ContactPhone = (dt.Rows[0]["ContactPhone"] != DBNull.Value ? dt.Rows[0]["ContactPhone"].ToString() : null);
                    objForm3.ContactEmail = (dt.Rows[0]["ContactEmail"] != DBNull.Value ? dt.Rows[0]["ContactEmail"].ToString() : null);
                    objForm3.Notes = (dt.Rows[0]["Notes"] != DBNull.Value ? dt.Rows[0]["Notes"].ToString() : null);
                    objForm3.TermsandConditions = Convert.ToBoolean(dt.Rows[0]["TermsandConditions"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["TermsandConditions"]) : false);
                    objForm3.IsApproved = Convert.ToBoolean(dt.Rows[0]["IsApproved"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsApproved"]) : false);
                    objForm3.ApprovedDate = Convert.ToDateTime(dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objForm3.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objForm3.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objForm3.PaymentDate = Convert.ToDateTime(dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objForm3.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : null);
                    objForm3.AmountPaid = Convert.ToDecimal(dt.Rows[0]["AmountPaid"] != DBNull.Value ? dt.Rows[0]["AmountPaid"].ToString() : null);
                    objForm3.BankName = (dt.Rows[0]["BankName"] != DBNull.Value ? dt.Rows[0]["BankName"].ToString() : null);
                    objForm3.ChequeNo = (dt.Rows[0]["ChequeNo"] != DBNull.Value ? dt.Rows[0]["ChequeNo"].ToString() : null);
                    objForm3.ChequeDate = Convert.ToDateTime(dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objForm3.AdminComments = (dt.Rows[0]["AdminComments"] != DBNull.Value ? dt.Rows[0]["AdminComments"].ToString() : null);
                    objForm3.Field1 = (dt.Rows[0]["Field1"] != DBNull.Value ? dt.Rows[0]["Field1"].ToString() : null);
                    objForm3.Field2 = (dt.Rows[0]["Field2"] != DBNull.Value ? dt.Rows[0]["Field2"].ToString() : null);
                    objForm3.Field3 = (dt.Rows[0]["Field3"] != DBNull.Value ? dt.Rows[0]["Field3"].ToString() : null);
                    objForm3.InstertedBy = dt.Rows[0]["InstertedBy"].ToString();
                    objForm3.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());
                    objForm3.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objForm3.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString());
                    objForm3.PaymentStatus = (dt.Rows[0]["PaymentStatus"] != DBNull.Value ? dt.Rows[0]["PaymentStatus"].ToString() : null);
                    objForm3.PaymentMethod = (dt.Rows[0]["PaymentMethod"] != DBNull.Value ? dt.Rows[0]["PaymentMethod"].ToString() : null);
                    objForm3.CategoryName = (dt.Rows[0]["CategoryName"] != DBNull.Value ? dt.Rows[0]["CategoryName"].ToString() : null);
                    objForm3.EventName = (dt.Rows[0]["EventName"] != DBNull.Value ? dt.Rows[0]["EventName"].ToString() : null);
                }

            }
            return objForm3;
        }

        public List<WATS.Entities.Form3> GetForm3ListByVariable(Int64 EventId , Int64 RegistrationCategoryId , Int64 PaymentMethodId , Int64 PaymentStatusId , string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Form3> lstForm3 = new List<WATS.Entities.Form3>();
            DataTable dt = _Form3.GetForm3ListByVariable(EventId,RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Form3.GetForm3ListByVariable(EventId, RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form3 objForm3 = new WATS.Entities.Form3();

                    objForm3.RId = Convert.ToInt64(dr["RId"].ToString());
                    objForm3.EventRegistrationForm3Id = Convert.ToInt64(dr["EventRegistrationForm3Id"].ToString());
                    objForm3.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objForm3.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objForm3.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objForm3.FirstName = (dr["FirstName"] != DBNull.Value ? dr["FirstName"].ToString() : null);
                    objForm3.LastName = (dr["LastName"] != DBNull.Value ? dr["LastName"].ToString() : null);
                    objForm3.ContactPhone = (dr["ContactPhone"] != DBNull.Value ? dr["ContactPhone"].ToString() : null);
                    objForm3.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objForm3.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objForm3.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"] != DBNull.Value ? Convert.ToBoolean(dr["TermsandConditions"]) : false);
                    objForm3.IsApproved = Convert.ToBoolean(dr["IsApproved"] != DBNull.Value ? Convert.ToBoolean(dr["IsApproved"]) : false);
                    objForm3.ApprovedDate = Convert.ToDateTime(dr["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dr["ApprovedDate"]) : DateTime.MinValue);
                    objForm3.PaymentStatusId = (dr["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentStatusId"]) : 0);
                    objForm3.PaymentMethodId = (dr["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentMethodId"]) : 0);
                    objForm3.PaymentDate = Convert.ToDateTime(dr["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["PaymentDate"]) : DateTime.MinValue);
                    objForm3.TransactionId = (dr["TransactionId"] != DBNull.Value ? dr["TransactionId"].ToString() : null);
                    objForm3.AmountPaid = Convert.ToDecimal(dr["AmountPaid"] != DBNull.Value ? dr["AmountPaid"].ToString() : null);
                    objForm3.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objForm3.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objForm3.ChequeDate = Convert.ToDateTime(dr["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dr["ChequeDate"]) : DateTime.MinValue);
                    objForm3.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objForm3.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objForm3.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objForm3.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objForm3.InstertedBy = dr["InstertedBy"].ToString();
                    objForm3.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objForm3.UpdatedBy = dr["UpdatedBy"].ToString();
                    objForm3.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
                    objForm3.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    objForm3.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
                    objForm3.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    objForm3.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);

                    lstForm3.Add(objForm3);
                }
            }
            return lstForm3;
        }


        #endregion
    }
}
