using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class AdvertiseWithUs
    {
        WATS.DAL.AdvertiseWithUs _AdvertiseWithUs = new WATS.DAL.AdvertiseWithUs();

        #region Methods

        public Int64 InsertAdvertiseWithUs(Entities.AdvertiseWithUs objAdvertiseWithUs, ref Int64 AdvertiseWithUsId,ref string ImageUrl)
        {
            Int64 _status = 0;
            if (objAdvertiseWithUs != null)
            {
                _status = _AdvertiseWithUs.InsertAdvertiseWithUs(objAdvertiseWithUs, ref AdvertiseWithUsId, ref ImageUrl);

            }
            return _status;
        }

        public Int64 UpdateAdvertiseWithUs(Entities.AdvertiseWithUs objAdvertiseWithUs)
        {
            Int64 _status = 0;
            if (objAdvertiseWithUs != null)
            {
                _status = _AdvertiseWithUs.UpdateAdvertiseWithUs(objAdvertiseWithUs);

            }
            return _status;
        }

        public Int64 DeleteAdvertiseWithUs(Int64 AdvertiseWithUsId)
        {
            Int64 _status = 0;
            _status = _AdvertiseWithUs.DeleteAdvertiseWithUs(AdvertiseWithUsId);
            return _status;
        }

        public Int64 UpdateAdvertiseWithUsStatus(Int64 AdvertiseWithUsId)
        {
            Int64 _status = 0;
            _status = _AdvertiseWithUs.UpdateAdvertiseWithUsStatus(AdvertiseWithUsId);
            return _status;
        }

        #endregion

        #region Entities filling

        public WATS.Entities.AdvertiseWithUs GetAdvertiseWithUsById(Int64 AdvertiseWithUsId, ref int status)
        {
            WATS.Entities.AdvertiseWithUs objAdvertiseWithUs = new WATS.Entities.AdvertiseWithUs();
            DataTable dt = new DataTable();
            if (AdvertiseWithUsId != 0)
            {
                dt = _AdvertiseWithUs.GetAdvertiseWithUsById(AdvertiseWithUsId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objAdvertiseWithUs.AdvertiseWithUsId = Convert.ToInt64(dt.Rows[0]["AdvertiseWithUsId"].ToString());
                    objAdvertiseWithUs.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    objAdvertiseWithUs.FirstName = dt.Rows[0]["FirstName"].ToString();
                    objAdvertiseWithUs.Email = dt.Rows[0]["Email"].ToString();
                    objAdvertiseWithUs.LastName = dt.Rows[0]["LastName"].ToString();
                    objAdvertiseWithUs.ImageUrl = dt.Rows[0]["ImageUrl"].ToString();
                    objAdvertiseWithUs.Address = dt.Rows[0]["Address"].ToString();
                    objAdvertiseWithUs.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                    objAdvertiseWithUs.IsActive = (dt.Rows[0]["IsActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsActive"]) : false);
                    objAdvertiseWithUs.Amount = (dt.Rows[0]["Amount"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["Amount"]) : 0);
                    objAdvertiseWithUs.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objAdvertiseWithUs.TransactionId = dt.Rows[0]["TransactionId"].ToString();
                    objAdvertiseWithUs.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objAdvertiseWithUs.PaymentMethod = dt.Rows[0]["PaymentMethod"].ToString();
                    objAdvertiseWithUs.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objAdvertiseWithUs.PaymentStatus = dt.Rows[0]["PaymentStatus"].ToString();
                    objAdvertiseWithUs.PaymentDate = (dt.Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["PaymentDate"]) : DateTime.MinValue);
                    objAdvertiseWithUs.Comment = dt.Rows[0]["Comment"].ToString();
                    objAdvertiseWithUs.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());

                }
            }
            return objAdvertiseWithUs;
        }

        public List<WATS.Entities.AdvertiseWithUs> GetAdvertiseWithUsListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.AdvertiseWithUs> lstAdvertiseWithUs = new List<WATS.Entities.AdvertiseWithUs>();
            DataTable dt = _AdvertiseWithUs.GetAdvertiseWithUsListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _AdvertiseWithUs.GetAdvertiseWithUsListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.AdvertiseWithUs objAdvertiseWithUs = new WATS.Entities.AdvertiseWithUs();

                    objAdvertiseWithUs.RId = Convert.ToInt64(dr["RId"].ToString());
                    objAdvertiseWithUs.AdvertiseWithUsId = Convert.ToInt64(dr["AdvertiseWithUsId"].ToString());
                    objAdvertiseWithUs.CompanyName = dr["CompanyName"].ToString();
                    objAdvertiseWithUs.FirstName = dr["FirstName"].ToString();
                    objAdvertiseWithUs.LastName = dr["LastName"].ToString();
                    objAdvertiseWithUs.Email = dr["Email"].ToString();
                    objAdvertiseWithUs.ImageUrl = dr["ImageUrl"].ToString();
                    objAdvertiseWithUs.PhoneNo = dr["PhoneNo"].ToString();
                    objAdvertiseWithUs.IsActive = (dr["IsActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsActive"]) : false);
                    objAdvertiseWithUs.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    objAdvertiseWithUs.TransactionId = dr["TransactionId"].ToString();
                    objAdvertiseWithUs.PaymentMethod = dr["PaymentMethod"].ToString();
                    objAdvertiseWithUs.PaymentStatus = dr["PaymentStatus"].ToString();
                    objAdvertiseWithUs.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());

                    lstAdvertiseWithUs.Add(objAdvertiseWithUs);
                }
            }
            return lstAdvertiseWithUs;
        }

        #endregion

        #region Front-end

        public List<WATS.Entities.AdvertiseWithUs> FEAdvertiseWithUsGetList(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.AdvertiseWithUs> lstAdvertiseWithUs = new List<Entities.AdvertiseWithUs>();
            DataTable dt = _AdvertiseWithUs.FEAdvertiseWithUsGetList(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _AdvertiseWithUs.FEAdvertiseWithUsGetList(Search, Sort, PageNo - 1, Items, ref Total);
            }

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.AdvertiseWithUs objAdvertiseWithUs = new WATS.Entities.AdvertiseWithUs();

                    objAdvertiseWithUs.AdvertiseWithUsId = Convert.ToInt64(dr["AdvertiseWithUsId"].ToString());
                    objAdvertiseWithUs.FirstName = dr["FirstName"].ToString();
                    objAdvertiseWithUs.LastName = dr["LastName"].ToString();
                    objAdvertiseWithUs.Email = dr["Email"].ToString();
                    objAdvertiseWithUs.PhoneNo = dr["PhoneNo"].ToString();
                    objAdvertiseWithUs.Address = dr["Address"].ToString();
                    objAdvertiseWithUs.IsActive = (dr["IsActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsActive"]) : false);
                    objAdvertiseWithUs.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    objAdvertiseWithUs.PaymentDate = (dr["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(dr["PaymentDate"]) : DateTime.MinValue);
                    objAdvertiseWithUs.TransactionId = dr["TransactionId"].ToString();
                    objAdvertiseWithUs.PaymentStatus = dr["PaymentStatus"].ToString();
                    objAdvertiseWithUs.CompanyName = dr["CompanyName"].ToString();
                    objAdvertiseWithUs.Comment = dr["Comment"].ToString();
                    objAdvertiseWithUs.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
                    objAdvertiseWithUs.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());

                    lstAdvertiseWithUs.Add(objAdvertiseWithUs);
                }

            }
            return lstAdvertiseWithUs;
        }

        #endregion
    }
}
