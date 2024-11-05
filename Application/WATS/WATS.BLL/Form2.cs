using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;

namespace WATS.BLL
{
    public class Form2
    {
        WATS.DAL.Form2 _Form2 = new WATS.DAL.Form2();

        #region Methods

        public Int64 InsertForm2(Entities.Form2 objForm2, ref Int64 CulturalRegistrationId)
        {
            Int64 _status = 0;
            if (objForm2 != null)
            {
                _status = _Form2.InsertForm2(objForm2, ref CulturalRegistrationId);

            }
            return _status;
        }

        public Int64 DeleteForm2(Int64 CulturalRegistrationId)
        {
            Int64 _status = 0;
            _status = _Form2.DeleteForm2ById(CulturalRegistrationId);
            return _status;
        }


        public Int64 UpdateForm2StatusById(Int64 CulturalRegistrationId)
        {
            Int64 _status = 0;
            _status = _Form2.UpdateForm2StatusById(CulturalRegistrationId);
            return _status;
        }


        #endregion

        #region Entities filling

        public List<WATS.Entities.Form2> GetForm2List(ref int status)
        {
            List<WATS.Entities.Form2> lstForm2 = new List<WATS.Entities.Form2>();
            DataTable dt = _Form2.GetForm2List(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form2 objlstForm2 = new WATS.Entities.Form2();

            
                    objlstForm2.CulturalRegistrationId = Convert.ToInt64(dr["CulturalRegistrationId"].ToString());
                    objlstForm2.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstForm2.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm2.MemberId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objlstForm2.ProgramType = (dr["ProgramType"] != DBNull.Value ? dr["ProgramType"].ToString() : null);
                    objlstForm2.ProgramName = (dr["ProgramName"] != DBNull.Value ? dr["ProgramName"].ToString() : null);
                    objlstForm2.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : null);
                    objlstForm2.MediaTrack = (dr["MediaTrack"] != DBNull.Value ? dr["MediaTrack"].ToString() : null);
                    objlstForm2.NumberOfParticipants = (dr["NumberOfParticipants"] != DBNull.Value ? dr["NumberOfParticipants"].ToString() : null);
                    objlstForm2.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
                    objlstForm2.ParticipantsFullNames = (dr["ParticipantsFullNames"] != DBNull.Value ? dr["ParticipantsFullNames"].ToString() : null);
                    objlstForm2.ProgramDuration = (dr["ProgramDuration"] != DBNull.Value ? dr["ProgramDuration"].ToString() : null);
                    objlstForm2.ChoreographerName = (dr["ChoreographerName"] != DBNull.Value ? dr["ChoreographerName"].ToString() : null);
                    objlstForm2.ContactPhoneNumber = (dr["ContactPhoneNumber"] != DBNull.Value ? dr["ContactPhoneNumber"].ToString() : null);
                    objlstForm2.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objlstForm2.SchoolName = (dr["SchoolName"] != DBNull.Value ? dr["SchoolName"].ToString() : null);
                    objlstForm2.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"] != DBNull.Value ? Convert.ToBoolean(dr["TermsandConditions"]) : false);
                    objlstForm2.IsApproved = Convert.ToBoolean(dr["IsApproved"] != DBNull.Value ? Convert.ToBoolean(dr["IsApproved"]) : false);
                    objlstForm2.ApprovedDate = Convert.ToDateTime(dr["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dr["ApprovedDate"]) : DateTime.MinValue);
                    objlstForm2.PaymentStatusId = Convert.ToInt64(dr["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentStatusId"]) : 0);
                    objlstForm2.PaymentMethodId = Convert.ToInt64(dr["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentStatusId"]) : 0);
                    objlstForm2.PaymentDate = Convert.ToDateTime(dr["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["PaymentDate"]) : DateTime.MinValue);
                    objlstForm2.TransactionId = (dr["TransactionId"] != DBNull.Value ? dr["TransactionId"].ToString() : null);
                    objlstForm2.AmountPaid = Convert.ToDecimal(dr["AmountPaid"] != DBNull.Value ? dr["AmountPaid"].ToString() : null);
                    objlstForm2.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objlstForm2.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objlstForm2.ChequeDate = Convert.ToDateTime(dr["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dr["ChequeDate"]) : DateTime.MinValue);
                    objlstForm2.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objlstForm2.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objlstForm2.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objlstForm2.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objlstForm2.InstertedBy = dr["InstertedBy"].ToString();
                    objlstForm2.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstForm2.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstForm2.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());


                    lstForm2.Add(objlstForm2);
                }

            }
            return lstForm2;
        }

        public WATS.Entities.Form2 GetForm2ById(Int64 CulturalRegistrationId, ref int status)
        {
            WATS.Entities.Form2 objForm2 = new WATS.Entities.Form2();
            DataTable dt = new DataTable();
            if (CulturalRegistrationId != 0)
            {
                dt = _Form2.GetForm2ById(CulturalRegistrationId, ref status);
                if (dt.Rows.Count == 1)
                {
                    
                    objForm2.CulturalRegistrationId = Convert.ToInt64(dt.Rows[0]["CulturalRegistrationId"].ToString());
                    objForm2.EventId = (dt.Rows[0]["EventId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["EventId"]) : 0);
                    objForm2.RegistrationCategoryId = (dt.Rows[0]["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["RegistrationCategoryId"]) : 0);
                    objForm2.MemberId = (dt.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["MemberId"]) : 0);
                    objForm2.ProgramType = (dt.Rows[0]["ProgramType"] != DBNull.Value ? dt.Rows[0]["ProgramType"].ToString() : null);
                    objForm2.ProgramName = (dt.Rows[0]["ProgramName"] != DBNull.Value ? dt.Rows[0]["ProgramName"].ToString() : null);
                    objForm2.Description = (dt.Rows[0]["Description"] != DBNull.Value ? dt.Rows[0]["Description"].ToString() : null);
                    objForm2.MediaTrack = (dt.Rows[0]["MediaTrack"] != DBNull.Value ? dt.Rows[0]["MediaTrack"].ToString() : null);
                    objForm2.NumberOfParticipants = (dt.Rows[0]["NumberOfParticipants"] != DBNull.Value ? dt.Rows[0]["NumberOfParticipants"].ToString() : null);
                    objForm2.Age = (dt.Rows[0]["Age"] != DBNull.Value ? dt.Rows[0]["Age"].ToString() : null);
                    objForm2.ParticipantsFullNames = (dt.Rows[0]["ParticipantsFullNames"] != DBNull.Value ? dt.Rows[0]["ParticipantsFullNames"].ToString() : null);
                    objForm2.ProgramDuration = (dt.Rows[0]["ProgramDuration"] != DBNull.Value ? dt.Rows[0]["ProgramDuration"].ToString() : null);
                    objForm2.ChoreographerName = (dt.Rows[0]["ChoreographerName"] != DBNull.Value ? dt.Rows[0]["ChoreographerName"].ToString() : null);
                    objForm2.ContactPhoneNumber = (dt.Rows[0]["ContactPhoneNumber"] != DBNull.Value ? dt.Rows[0]["ContactPhoneNumber"].ToString() : null);
                    objForm2.ContactEmail = (dt.Rows[0]["ContactEmail"] != DBNull.Value ? dt.Rows[0]["ContactEmail"].ToString() : null);
                    objForm2.SchoolName = (dt.Rows[0]["SchoolName"] != DBNull.Value ? dt.Rows[0]["SchoolName"].ToString() : null);
                    objForm2.TermsandConditions = Convert.ToBoolean(dt.Rows[0]["TermsandConditions"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["TermsandConditions"]) : false);
                    objForm2.IsApproved = Convert.ToBoolean(dt.Rows[0]["IsApproved"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsApproved"]) : false);
                    objForm2.ApprovedDate = Convert.ToDateTime(dt.Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ApprovedDate"]) : DateTime.MinValue);
                    objForm2.PaymentStatusId = Convert.ToInt64(dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objForm2.PaymentMethodId = Convert.ToInt64(dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objForm2.PaymentDate = Convert.ToDateTime(dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objForm2.TransactionId = (dt.Rows[0]["TransactionId"] != DBNull.Value ? dt.Rows[0]["TransactionId"].ToString() : null);
                    objForm2.AmountPaid = Convert.ToDecimal(dt.Rows[0]["AmountPaid"] != DBNull.Value ? dt.Rows[0]["AmountPaid"].ToString() : null);
                    objForm2.BankName = (dt.Rows[0]["BankName"] != DBNull.Value ? dt.Rows[0]["BankName"].ToString() : null);
                    objForm2.ChequeNo = (dt.Rows[0]["ChequeNo"] != DBNull.Value ? dt.Rows[0]["ChequeNo"].ToString() : null);
                    objForm2.ChequeDate = Convert.ToDateTime(dt.Rows[0]["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ChequeDate"]) : DateTime.MinValue);
                    objForm2.AdminComments = (dt.Rows[0]["AdminComments"] != DBNull.Value ? dt.Rows[0]["AdminComments"].ToString() : null);
                    objForm2.Field1 = (dt.Rows[0]["Field1"] != DBNull.Value ? dt.Rows[0]["Field1"].ToString() : null);
                    objForm2.Field2 = (dt.Rows[0]["Field2"] != DBNull.Value ? dt.Rows[0]["Field2"].ToString() : null);
                    objForm2.Field3 = (dt.Rows[0]["Field3"] != DBNull.Value ? dt.Rows[0]["Field3"].ToString() : null);
                    objForm2.InstertedBy = dt.Rows[0]["InstertedBy"].ToString();
                    objForm2.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["InsertedDate"]) : DateTime.MinValue);
                    objForm2.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objForm2.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]) : DateTime.MinValue);
                    objForm2.PaymentStatus = (dt.Rows[0]["PaymentStatus"] != DBNull.Value ? dt.Rows[0]["PaymentStatus"].ToString() : null);
                    objForm2.PaymentMethod = (dt.Rows[0]["PaymentMethod"] != DBNull.Value ? dt.Rows[0]["PaymentMethod"].ToString() : null);
                    objForm2.CategoryName = (dt.Rows[0]["CategoryName"] != DBNull.Value ? dt.Rows[0]["CategoryName"].ToString() : null);
                    objForm2.EventName = (dt.Rows[0]["EventName"] != DBNull.Value ? dt.Rows[0]["EventName"].ToString() : null);
                }
            }
            return objForm2;
        }

        public List<WATS.Entities.Form2> GetForm2ListByVariable(Int64 EventId , Int64 RegistrationCategoryId , Int64 PaymentMethodId , Int64 PaymentStatusId , string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Form2> lstForm2 = new List<WATS.Entities.Form2>();
            DataTable dt = _Form2.GetForm2ListByVariable(EventId, RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Form2.GetForm2ListByVariable(EventId, RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Form2 objForm2 = new WATS.Entities.Form2();

                    objForm2.RId = Convert.ToInt64(dr["RId"].ToString());
                    objForm2.CulturalRegistrationId = Convert.ToInt64(dr["CulturalRegistrationId"].ToString());
                    objForm2.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objForm2.RegistrationCategoryId = (dr["RegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["RegistrationCategoryId"]) : 0);
                    objForm2.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objForm2.ProgramType = (dr["ProgramType"] != DBNull.Value ? dr["ProgramType"].ToString() : null);
                    objForm2.ProgramName = (dr["ProgramName"] != DBNull.Value ? dr["ProgramName"].ToString() : null);
                    objForm2.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : null);
                    objForm2.MediaTrack = (dr["MediaTrack"] != DBNull.Value ? dr["MediaTrack"].ToString() : null);
                    objForm2.NumberOfParticipants = (dr["NumberOfParticipants"] != DBNull.Value ? dr["NumberOfParticipants"].ToString() : null);
                    objForm2.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
                    objForm2.ParticipantsFullNames = (dr["ParticipantsFullNames"] != DBNull.Value ? dr["ParticipantsFullNames"].ToString() : null);
                    objForm2.ProgramDuration = (dr["ProgramDuration"] != DBNull.Value ? dr["ProgramDuration"].ToString() : null);
                    objForm2.ChoreographerName = (dr["ChoreographerName"] != DBNull.Value ? dr["ChoreographerName"].ToString() : null);
                    objForm2.ContactPhoneNumber = (dr["ContactPhoneNumber"] != DBNull.Value ? dr["ContactPhoneNumber"].ToString() : null);
                    objForm2.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objForm2.SchoolName = (dr["SchoolName"] != DBNull.Value ? dr["SchoolName"].ToString() : null);
                    objForm2.TermsandConditions = Convert.ToBoolean(dr["TermsandConditions"] != DBNull.Value ? Convert.ToBoolean(dr["TermsandConditions"]) : false);
                    objForm2.IsApproved = Convert.ToBoolean(dr["IsApproved"] != DBNull.Value ? Convert.ToBoolean(dr["IsApproved"]) : false);
                    objForm2.ApprovedDate = Convert.ToDateTime(dr["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(dr["ApprovedDate"]) : DateTime.MinValue);
                    objForm2.PaymentStatusId = Convert.ToInt64(dr["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentStatusId"]) : 0);
                    objForm2.PaymentMethodId = Convert.ToInt64(dr["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dr["PaymentStatusId"]) : 0);
                    objForm2.PaymentDate = (Convert.ToDateTime(dr["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["PaymentDate"]) : DateTime.MinValue));
                    objForm2.TransactionId = (dr["TransactionId"] != DBNull.Value ? dr["TransactionId"].ToString() : null);
                    objForm2.AmountPaid = Convert.ToDecimal(dr["AmountPaid"] != DBNull.Value ? dr["AmountPaid"].ToString() : null);
                    objForm2.BankName = (dr["BankName"] != DBNull.Value ? dr["BankName"].ToString() : null);
                    objForm2.ChequeNo = (dr["ChequeNo"] != DBNull.Value ? dr["ChequeNo"].ToString() : null);
                    objForm2.ChequeDate = (Convert.ToDateTime(dr["ChequeDate"] != DBNull.Value ? Convert.ToDateTime(dr["ChequeDate"]) : DateTime.MinValue));
                    objForm2.AdminComments = (dr["AdminComments"] != DBNull.Value ? dr["AdminComments"].ToString() : null);
                    objForm2.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objForm2.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objForm2.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objForm2.InstertedBy = dr["InstertedBy"].ToString();
                    objForm2.InsertedDate = (Convert.ToDateTime(dr["InsertedDate"] != DBNull.Value ? Convert.ToDateTime(dr["InsertedDate"]) : DateTime.MinValue));
                    objForm2.UpdatedBy = dr["UpdatedBy"].ToString();
                    objForm2.UpdatedDate = (Convert.ToDateTime(dr["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(dr["UpdatedDate"]) : DateTime.MinValue));
                    objForm2.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    objForm2.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
                    objForm2.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    objForm2.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
                    objForm2.CategoryName = (dr["CategoryName"] != DBNull.Value ? dr["CategoryName"].ToString() : null);
                    objForm2.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);

                    lstForm2.Add(objForm2);

                }
            }
            return lstForm2;
        }


        #endregion
    }
}
