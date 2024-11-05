using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class SponsorRegistrationCategories
    {
        DAL.SponsorRegistrationCategories _SponsorRegistrationCategories = new DAL.SponsorRegistrationCategories();

        #region Methods

        public Int64 DeleteSponsorRegistration(Int64 SponsorRegistrationId)
        {
            Int64 _status = 0;
            if (SponsorRegistrationId != 0)
            {
                _status = _SponsorRegistrationCategories.DeleteSponsorRegistrationCategory(SponsorRegistrationId);
            }
            return _status;
        }

        public Int64 InsertSponsorRegistration(Entities.SponsorRegistrationCategories objSponsorRegistration)
        {
            Int64 _status = 0;
            if (objSponsorRegistration != null)
            {
                _status = _SponsorRegistrationCategories.InsertSponsorRegistrationCategory(objSponsorRegistration);
            }
            return _status;
        }

        public Int64 UpdateSponsorRegistrationStatus(Int64 SponsorRegistrationId)
        {
            Int64 _status = 0;
            _status = _SponsorRegistrationCategories.UpdateSponsorRegistrationCategoryStatus(SponsorRegistrationId);
            return _status;
        }

        public Int64 UpdateSponsorRegistrationCategoryDisplayOrder(int DisplayOrder, Int64 SponsorRegistrationCategoryId)
        {
            Int64 _status = 0;
            _status = _SponsorRegistrationCategories.UpdateSponsorRegistrationCategoryDisplayOrder(DisplayOrder, SponsorRegistrationCategoryId);
            return _status;
        }

        #endregion

        #region Entity Loading

        public List<Entities.SponsorRegistrationCategories> GetSponsorRegistrationCategoriesListByVariable(Int64 EventId,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = _SponsorRegistrationCategories.GetSponsorRegistrationCategoriesListByVariable(EventId,Search, Sort, PageNo, Items, ref Total);
            List<Entities.SponsorRegistrationCategories> lstSponsorRegistration = new List<Entities.SponsorRegistrationCategories>();

            if (dt.Rows.Count == 0 && PageNo > 1)
            {
                dt = _SponsorRegistrationCategories.GetSponsorRegistrationCategoriesListByVariable(EventId,Search, Sort, PageNo, Items, ref Total);
            }

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.SponsorRegistrationCategories objSponsorRegistration = new Entities.SponsorRegistrationCategories();

                    objSponsorRegistration.RId = Convert.ToInt64(dr["Rid"]);
                    objSponsorRegistration.SponsorRegistrationCategoryId = Convert.ToInt64(dr["SponsorRegistrationCategoryId"]);
                    objSponsorRegistration.EventId = Convert.ToInt64(dr["EventId"]);
                    objSponsorRegistration.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"]) : 0);
                    objSponsorRegistration.CategoryName = dr["CategoryName"].ToString();
                    objSponsorRegistration.BannerDisplay = (dr["BannerDisplay"] != DBNull.Value ? dr["BannerDisplay"].ToString() : null);
                    objSponsorRegistration.DinnerTickets = (dr["DinnerTickets"] != DBNull.Value ? dr["DinnerTickets"].ToString() : null);
                    objSponsorRegistration.EventName = dr["EventName"].ToString();
                    
                    objSponsorRegistration.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objSponsorRegistration.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    

                    lstSponsorRegistration.Add(objSponsorRegistration);
                }
            }
            return lstSponsorRegistration;
        }

        public Entities.SponsorRegistrationCategories GetSponsorRegistrationById(Int64 SponsorRegistrationId, ref int status)
        {
            DataTable dt = _SponsorRegistrationCategories.GetSponsorRegistrationCategoryById(SponsorRegistrationId, ref status);
            Entities.SponsorRegistrationCategories objSponsorRegistration = new Entities.SponsorRegistrationCategories();

            if (dt.Rows.Count == 1)
            {
                objSponsorRegistration.SponsorRegistrationCategoryId = Convert.ToInt64(dt.Rows[0]["SponsorRegistrationCategoryId"]);
                objSponsorRegistration.SponsorRegistrationCategoryId = Convert.ToInt64(dt.Rows[0]["SponsorRegistrationCategoryId"]);
                objSponsorRegistration.EventId = Convert.ToInt64(dt.Rows[0]["EventId"]);
                objSponsorRegistration.OrderNo = (dt.Rows[0]["OrderNo"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["OrderNo"]) : 0);
                objSponsorRegistration.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                objSponsorRegistration.Description = dt.Rows[0]["Description"].ToString();
                objSponsorRegistration.BannerDisplay = (dt.Rows[0]["BannerDisplay"] != DBNull.Value ? dt.Rows[0]["BannerDisplay"].ToString() : null);
                objSponsorRegistration.DinnerTickets = (dt.Rows[0]["DinnerTickets"] != DBNull.Value ? dt.Rows[0]["DinnerTickets"].ToString() : null);
                
                objSponsorRegistration.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                objSponsorRegistration.Amount = (dt.Rows[0]["Amount"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["Amount"]) : 0);
            }

            return objSponsorRegistration;
        }

        public List<Entities.SponsorRegistrationCategories> GetSponsorRegistrationCategoriesList(ref int status)
        {
            DataTable dt = _SponsorRegistrationCategories.GetSponsorRegistrationCategoriesList(ref status);
            List<Entities.SponsorRegistrationCategories> lstSponsorRegistration = new List<Entities.SponsorRegistrationCategories>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.SponsorRegistrationCategories objSponsorRegistration = new Entities.SponsorRegistrationCategories();

                    objSponsorRegistration.SponsorRegistrationCategoryId = Convert.ToInt64(dr["SponsorRegistrationCategoryId"]);
                    objSponsorRegistration.EventId = Convert.ToInt64(dr["EventId"]);
                    objSponsorRegistration.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"]) : 0);
                    objSponsorRegistration.CategoryName = dr["CategoryName"].ToString();
                    
                    
                    objSponsorRegistration.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objSponsorRegistration.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);

                    lstSponsorRegistration.Add(objSponsorRegistration);
                }
            }

            return lstSponsorRegistration;
        }

        public List<Entities.SponsorRegistrationCategories> FEGetSponsorRegistrationCategoriesList(Int64 EventId, ref int status)
        {
            DataTable dt = _SponsorRegistrationCategories.FEGetSponsorRegistrationCategoriesList(EventId,ref status);
            List<Entities.SponsorRegistrationCategories> lstSponsorRegistration = new List<Entities.SponsorRegistrationCategories>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.SponsorRegistrationCategories objSponsorRegistration = new Entities.SponsorRegistrationCategories();

                    objSponsorRegistration.SponsorRegistrationCategoryId = Convert.ToInt64(dr["SponsorRegistrationCategoryId"]);
                    objSponsorRegistration.EventId = Convert.ToInt64(dr["EventId"]);
                    objSponsorRegistration.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"]) : 0);
                    objSponsorRegistration.CategoryName = dr["CategoryName"].ToString();
                    objSponsorRegistration.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objSponsorRegistration.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    objSponsorRegistration.BannerDisplay = (dr["BannerDisplay"] != DBNull.Value ? dr["BannerDisplay"].ToString() : null);
                    objSponsorRegistration.DinnerTickets = (dr["DinnerTickets"] != DBNull.Value ? dr["DinnerTickets"].ToString() : null);
                    lstSponsorRegistration.Add(objSponsorRegistration);
                }
            }

            return lstSponsorRegistration;
        }

        #endregion
    }
}
