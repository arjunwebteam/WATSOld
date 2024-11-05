using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class SponsorRegistrations
    {
        WATS.DAL.SponsorRegistrations _SponsorRegistration = new WATS.DAL.SponsorRegistrations();

        #region Methods

        public Int64 InsertSponsorRegistrations(Entities.SponsorRegistrations objSponsorRegistrations, ref Int64 DonorId,ref string ImageUrl)
        {
            Int64 _status = 0;
            if (objSponsorRegistrations != null)
            {
                _status = _SponsorRegistration.InsertSponsorRegistration(objSponsorRegistrations, ref DonorId,ref ImageUrl);

            }
            return _status;
        }

        public Int64 UpdateSponsorRegistrations(Entities.SponsorRegistrations objSponsorRegistrations)
        {
            Int64 _status = 0;
            if (objSponsorRegistrations != null)
            {
                _status = _SponsorRegistration.UpdateSponsorRegistration(objSponsorRegistrations);

            }
            return _status;
        }

        public Int64 DeleteSponsorRegistration(Int64 SponsorRegistrationId)
        {
            Int64 _status = 0;
            _status = _SponsorRegistration.DeleteSponsorRegistration(SponsorRegistrationId);
            return _status;
        }

        public Int64 UpdateSponsorRegistrationsStatus(Int64 SponsorRegistrationId)
        {
            Int64 _status = 0;
            _status = _SponsorRegistration.UpdateSponsorRegistrationStatus(SponsorRegistrationId);
            return _status;
        }

        #endregion

        #region Entities filling

        public WATS.Entities.SponsorRegistrations GetSponsorRegistrationsById(Int64 SponsorRegistrationId, ref int status)
        {
            WATS.Entities.SponsorRegistrations objSponsorRegistrations = new WATS.Entities.SponsorRegistrations();
            DataTable dt = new DataTable();
            if (SponsorRegistrationId != 0)
            {
                dt = _SponsorRegistration.GetSponsorRegistrationById(SponsorRegistrationId, ref status);
                if (dt.Rows.Count == 1)
                {
                    
                    objSponsorRegistrations.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objSponsorRegistrations.FirstName = dt.Rows[0]["FirstName"].ToString();
                    objSponsorRegistrations.Email = dt.Rows[0]["Email"].ToString();
                    objSponsorRegistrations.LastName = dt.Rows[0]["LastName"].ToString();
                    objSponsorRegistrations.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    objSponsorRegistrations.Address = dt.Rows[0]["Address"].ToString();
                    objSponsorRegistrations.IsActive = (dt.Rows[0]["IsActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsActive"]) : false);
                    objSponsorRegistrations.Amount = (dt.Rows[0]["Amount"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["Amount"]) : 0);
                    objSponsorRegistrations.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objSponsorRegistrations.TransactionId = dt.Rows[0]["TransactionId"].ToString();
                    objSponsorRegistrations.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objSponsorRegistrations.PaymentMethod = dt.Rows[0]["PaymentMethod"].ToString();
                    objSponsorRegistrations.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objSponsorRegistrations.SponsorRegistrationId = (dt.Rows[0]["SponsorRegistrationId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["SponsorRegistrationId"]) : 0);
                    objSponsorRegistrations.SponsorRegistrationCategoryId = (dt.Rows[0]["SponsorRegistrationCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["SponsorRegistrationCategoryId"]) : 0);
                    objSponsorRegistrations.PaymentStatus = dt.Rows[0]["PaymentStatus"].ToString();
                    objSponsorRegistrations.OrderDate = (dt.Rows[0]["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["OrderDate"]) : DateTime.MinValue);
                    objSponsorRegistrations.PaymentBy = dt.Rows[0]["PaymentBy"].ToString();
                    objSponsorRegistrations.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());

                }
            }

            return objSponsorRegistrations;
        }

        public List<WATS.Entities.SponsorRegistrations> GetSponsorRegistrationsListByVariable(Int64 SponsorRegistrationCategoryId, Int64 EventId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.SponsorRegistrations> lstSponsorRegistrations = new List<WATS.Entities.SponsorRegistrations>();
            DataTable dt = _SponsorRegistration.GetSponsorRegistrationListByVariable(SponsorRegistrationCategoryId, EventId,Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _SponsorRegistration.GetSponsorRegistrationListByVariable(SponsorRegistrationCategoryId, EventId, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.SponsorRegistrations objSponsorRegistrations = new WATS.Entities.SponsorRegistrations();

                    objSponsorRegistrations.RId = Convert.ToInt64(dr["RId"].ToString());
                    objSponsorRegistrations.SponsorRegistrationId = (dr["SponsorRegistrationId"] != DBNull.Value ? Convert.ToInt64(dr["SponsorRegistrationId"]) : 0);
                    objSponsorRegistrations.ImageUrl = dr["ImageUrl"].ToString();
                    objSponsorRegistrations.FirstName = dr["FirstName"].ToString();
                    objSponsorRegistrations.Email = dr["Email"].ToString();
                    objSponsorRegistrations.LastName = dr["LastName"].ToString();
                    objSponsorRegistrations.PhoneNo = dr["PhoneNo"].ToString();
                    objSponsorRegistrations.IsActive = (dr["IsActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsActive"]) : false);
                    objSponsorRegistrations.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    objSponsorRegistrations.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objSponsorRegistrations.TransactionId = dr["TransactionId"].ToString();
                    objSponsorRegistrations.PaymentMethod = dr["PaymentMethod"].ToString();
                    objSponsorRegistrations.PaymentStatus = dr["PaymentStatus"].ToString();

                    objSponsorRegistrations.CategoryName = dr["CategoryName"].ToString();
                    objSponsorRegistrations.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());

                    lstSponsorRegistrations.Add(objSponsorRegistrations);
                }
            }
            return lstSponsorRegistrations;
        }

        #endregion
    }
}
