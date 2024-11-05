using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class Coupons
    {
        WATS.DAL.Coupons _Coupons = new WATS.DAL.Coupons();

        #region Methods

        public Int64 InsertCoupons(Entities.Coupons objCoupons, ref string LogoUrl)
        {
            Int64 _status = 0;
            if (objCoupons != null)
            {
                _status = _Coupons.InsertCoupons(objCoupons, ref LogoUrl);

            }
            return _status;
        }

        public Int64 DeleteCoupon(Int64 CouponId)
        {
            Int64 _status = 0;
            _status = _Coupons.DeleteCoupon(CouponId);
            return _status;
        }

        public Int64 UpdateCouponsStatus(Int64 CouponId)
        {
            Int64 _status = 0;
            _status = _Coupons.UpdateCouponsStatus(CouponId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.Coupons> GetCouponsList(ref int status)
        {
            List<WATS.Entities.Coupons> lstCoupons = new List<Entities.Coupons>();
            DataTable dt = _Coupons.GetCouponsList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Coupons objCoupons = new WATS.Entities.Coupons();

                    objCoupons.CouponId = Convert.ToInt64(dr["CouponId"].ToString());
                    objCoupons.MembershipTypeId = Convert.ToInt64(dr["MembershipTypeId"].ToString());
                    objCoupons.CouponName = dr["CouponName"].ToString();
                    objCoupons.LogoUrl = (dr["LogoUrl"] != DBNull.Value ? dr["LogoUrl"].ToString() : "");
                    objCoupons.RedirectUrl = (dr["RedirectUrl"] != DBNull.Value ? dr["RedirectUrl"].ToString() : "");
                    objCoupons.DocumentUrl = (dr["DocumentUrl"] != DBNull.Value ? dr["DocumentUrl"].ToString() : "");
                    objCoupons.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objCoupons.UpdatedBy = dr["UpdatedBy"].ToString();
                    objCoupons.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                    lstCoupons.Add(objCoupons);
                }

            }
            return lstCoupons;
        }

        public WATS.Entities.Coupons GetCouponById(Int64 PhotoId, ref int status)
        {
            WATS.Entities.Coupons objCoupons = new WATS.Entities.Coupons();
            DataTable dt = new DataTable();
            if (PhotoId != 0)
            {
                dt = _Coupons.GetCouponById(PhotoId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objCoupons.CouponId = Convert.ToInt64(dt.Rows[0]["CouponId"].ToString());
                    objCoupons.MembershipTypeId = Convert.ToInt64(dt.Rows[0]["MembershipTypeId"].ToString());
                    objCoupons.MembershipType = dt.Rows[0]["MembershipType"].ToString();
                    objCoupons.CouponName = dt.Rows[0]["CouponName"].ToString();
                    objCoupons.LogoUrl = (dt.Rows[0]["LogoUrl"] != DBNull.Value ? dt.Rows[0]["LogoUrl"].ToString() : "");
                    objCoupons.RedirectUrl = (dt.Rows[0]["RedirectUrl"] != DBNull.Value ? dt.Rows[0]["RedirectUrl"].ToString() : "");
                    objCoupons.DocumentUrl = (dt.Rows[0]["DocumentUrl"] != DBNull.Value ? dt.Rows[0]["DocumentUrl"].ToString() : "");
                    objCoupons.Description = (dt.Rows[0]["Description"] != DBNull.Value ? dt.Rows[0]["Description"].ToString() : "");
                    objCoupons.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                    objCoupons.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objCoupons.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"].ToString());

                }
            }
            return objCoupons;
        }
        
        public List<WATS.Entities.Coupons> GetCouponListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Coupons> lstCoupons = new List<WATS.Entities.Coupons>();

            DataTable dt = _Coupons.GetCouponListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Coupons.GetCouponListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Coupons objCoupons = new WATS.Entities.Coupons();

                    objCoupons.RId = Convert.ToInt32(dr["RId"].ToString());
                    objCoupons.CouponId = Convert.ToInt32(dr["CouponId"].ToString());
                    objCoupons.MembershipTypeId = Convert.ToInt64(dr["MembershipTypeId"].ToString());
                    objCoupons.MembershipType = dr["MembershipType"].ToString();
                    objCoupons.CouponName = dr["CouponName"].ToString();
                    objCoupons.LogoUrl = (dr["LogoUrl"] != DBNull.Value ? dr["LogoUrl"].ToString() : "");
                    objCoupons.RedirectUrl = (dr["RedirectUrl"] != DBNull.Value ? dr["RedirectUrl"].ToString() : "");
                    objCoupons.DocumentUrl = (dr["DocumentUrl"] != DBNull.Value ? dr["DocumentUrl"].ToString() : "");
                    objCoupons.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objCoupons.UpdatedBy = dr["UpdatedBy"].ToString();
                    objCoupons.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());

                    lstCoupons.Add(objCoupons);
                }
            }
            return lstCoupons;
        }

        #endregion

        #region Front-end

        public List<WATS.Entities.Coupons> FEMemberCouponsGetListById(Int64 MemberId, ref int status)
        {
            List<WATS.Entities.Coupons> lstCoupons = new List<Entities.Coupons>();
            DataTable dt = _Coupons.FEMemberCouponsGetListById(MemberId,ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Coupons objCoupons = new WATS.Entities.Coupons();

                    objCoupons.CouponId = Convert.ToInt64(dr["CouponId"].ToString());
                    objCoupons.MemberId = Convert.ToInt64(dr["MemberId"].ToString());
                    objCoupons.MembershipTypeId = Convert.ToInt64(dr["MembershipTypeId"].ToString());
                    objCoupons.CouponName = dr["CouponName"].ToString();
                    objCoupons.LogoUrl = (dr["LogoUrl"] != DBNull.Value ? dr["LogoUrl"].ToString() : "");
                    objCoupons.RedirectUrl = (dr["RedirectUrl"] != DBNull.Value ? dr["RedirectUrl"].ToString() : "");
                    objCoupons.DocumentUrl = (dr["DocumentUrl"] != DBNull.Value ? dr["DocumentUrl"].ToString() : "");
                    objCoupons.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objCoupons.UpdatedBy = dr["UpdatedBy"].ToString();
                    objCoupons.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                    lstCoupons.Add(objCoupons);
                }

            }
            return lstCoupons;
        }

        #endregion 
    }
}
