﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WATS.BLL
{
   public class SponsorCategories
    {
        WATS.DAL.SponsorCategories _SponsorCategories = new WATS.DAL.SponsorCategories();

        #region Methods

        public Int64 InsertSponsorCategories(Entities.SponsorCategories objSponsorCategories)
        {
            Int64 _status = 0;
            if (objSponsorCategories != null)
            {
                _status = _SponsorCategories.InsertSponsorCategories(objSponsorCategories);

            }
            return _status;
        }

        public Int64 DeleteSponsorCategory(Int64 SponsorCategoryId)
        {
            Int64 _status = 0;
            _status = _SponsorCategories.DeleteSponsorCategory(SponsorCategoryId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.SponsorCategories> GetSponsorCategoriesList(ref int status)
        {
            List<WATS.Entities.SponsorCategories> lstSponsorCategories = new List<Entities.SponsorCategories>();
            DataTable dt = _SponsorCategories.GetSponsorCategoriesList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.SponsorCategories objlstSponsorCategories = new WATS.Entities.SponsorCategories();

                    objlstSponsorCategories.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objlstSponsorCategories.CategoryName = dr["CategoryName"].ToString();
                    objlstSponsorCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstSponsorCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());

                    lstSponsorCategories.Add(objlstSponsorCategories);
                }

            }
            return lstSponsorCategories;
        }

        public WATS.Entities.SponsorCategories GetSponsorCategoryById(Int64 SponsorCategoryId, ref int status)
        {
            WATS.Entities.SponsorCategories objSponsorCategories = new WATS.Entities.SponsorCategories();
            DataTable dt = new DataTable();
            if (SponsorCategoryId != 0)
            {
                dt = _SponsorCategories.GetSponsorCategoryById(SponsorCategoryId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objSponsorCategories.SponsorCategoryId = Convert.ToInt64(dt.Rows[0]["SponsorCategoryId"].ToString());
                    objSponsorCategories.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                    objSponsorCategories.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objSponsorCategories.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"].ToString());

                }
            }
            return objSponsorCategories;
        }

        public List<WATS.Entities.SponsorCategories> GetSponsorCategoriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.SponsorCategories> lstSponsorCategories = new List<WATS.Entities.SponsorCategories>();
            DataTable dt = _SponsorCategories.GetSponsorCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _SponsorCategories.GetSponsorCategoriesListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.SponsorCategories objSponsorCategories = new WATS.Entities.SponsorCategories();

                    objSponsorCategories.RId = Convert.ToInt32(dr["RId"].ToString());
                    objSponsorCategories.SponsorCategoryId = Convert.ToInt32(dr["SponsorCategoryId"].ToString());
                    objSponsorCategories.CategoryName = dr["CategoryName"].ToString();
                    objSponsorCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                    objSponsorCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                    objSponsorCategories.SponsorsCount = Convert.ToInt32(dr["SponsorsCount"].ToString());

                    lstSponsorCategories.Add(objSponsorCategories);
                }
            }
            return lstSponsorCategories;
        }

        #endregion
    }
}
