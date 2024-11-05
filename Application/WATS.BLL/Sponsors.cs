﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WATS.BLL
{
   public class Sponsors
    {
       WATS.DAL.Sponsors _Sponsors = new WATS.DAL.Sponsors();

        #region Methods

        public Int64 InsertSponsors(Entities.Sponsors objCommittees, ref string LogoUrl)
        {
            Int64 _status = 0;
            if (objCommittees != null)
            {
                _status = _Sponsors.InsertSponsors(objCommittees,ref LogoUrl);

            }
            return _status;
        }

        public Int64 DeleteSponsor(Int64 SponsorId)
        {
            Int64 _status = 0;
            _status = _Sponsors.DeleteSponsor(SponsorId);
            return _status;
        }

        public Int64 UpdateSponsorsStatus(Int64 SponsorId)
        {
            Int64 _status = 0;
            _status = _Sponsors.UpdateSponsorsStatus(SponsorId);
            return _status;
        }

        public Int64 UpdateSponsorsDisplayOrder(int DisplayOrder, Int64 SponsorId)
        {
            Int64 _status = 0;
            _status = _Sponsors.UpdateSponsorsDisplayOrder(DisplayOrder, SponsorId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.Sponsors> GetSponsorsList(ref int status)
        {
            List<WATS.Entities.Sponsors> lstSponsors = new List<Entities.Sponsors>();
            DataTable dt = _Sponsors.GetSponsorsList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Sponsors objlstSponsors = new WATS.Entities.Sponsors();

                    objlstSponsors.SponsorId = Convert.ToInt64(dr["SponsorId"].ToString());
                    objlstSponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objlstSponsors.LogoUrl = dr["LogoUrl"].ToString();
                    objlstSponsors.RedirectUrl = (dr["RedirectUrl"] != DBNull.Value ? dr["RedirectUrl"].ToString() : "");
                    objlstSponsors.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objlstSponsors.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt64(dr["DisplayOrder"]) : 0);
                    objlstSponsors.Target = (dr["Target"] != DBNull.Value ? dr["Target"].ToString() : "");
                    objlstSponsors.InsertedTime = Convert.ToDateTime(dr["InsertedTime"].ToString());
                    objlstSponsors.InsertedBy = dr["InsertedBy"].ToString();

                    lstSponsors.Add(objlstSponsors);
                }

            }
            return lstSponsors;
        }

        public WATS.Entities.Sponsors GetSponsorById(Int64 SponsorId, ref int status)
        {
            WATS.Entities.Sponsors objSponsors = new WATS.Entities.Sponsors();
            DataTable dt = new DataTable();
            if (SponsorId != 0)
            {
                dt = _Sponsors.GetSponsorById(SponsorId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objSponsors.SponsorId = Convert.ToInt64(dt.Rows[0]["SponsorId"].ToString());
                    objSponsors.SponsorCategoryId = Convert.ToInt64(dt.Rows[0]["SponsorCategoryId"].ToString());
                    objSponsors.LogoUrl = dt.Rows[0]["LogoUrl"].ToString();
                    objSponsors.RedirectUrl = (dt.Rows[0]["RedirectUrl"] != DBNull.Value ? dt.Rows[0]["RedirectUrl"].ToString() : "");
                    objSponsors.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objSponsors.DisplayOrder = (dt.Rows[0]["DisplayOrder"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["DisplayOrder"]) : 0);
                    objSponsors.Target = (dt.Rows[0]["Target"] != DBNull.Value ? dt.Rows[0]["Target"].ToString() : "");
                    objSponsors.InsertedTime = Convert.ToDateTime(dt.Rows[0]["InsertedTime"].ToString());
                    objSponsors.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();                 

                }
            }
            return objSponsors;
        }

        public List<WATS.Entities.Sponsors> GetSponsorsListByVariable(Int64 SponsorCategoryId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Sponsors> lstSponsors= new List<WATS.Entities.Sponsors>();
            DataTable dt = _Sponsors.GetSponsorsListByVariable(SponsorCategoryId,Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Sponsors.GetSponsorsListByVariable(SponsorCategoryId,Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Sponsors objSponsors = new WATS.Entities.Sponsors();

                    objSponsors.RId = Convert.ToInt64(dr["RId"].ToString());
                    objSponsors.SponsorId = Convert.ToInt64(dr["SponsorId"].ToString());
                    objSponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objSponsors.LogoUrl = dr["LogoUrl"].ToString();
                    objSponsors.RedirectUrl = (dr["RedirectUrl"] != DBNull.Value ? dr["RedirectUrl"].ToString() : "");
                    objSponsors.CategoryName = (dr["CategoryName"] != DBNull.Value ? dr["CategoryName"].ToString() : "");
                    objSponsors.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objSponsors.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt64(dr["DisplayOrder"]) : 0);
                    objSponsors.Target = (dr["Target"] != DBNull.Value ? dr["Target"].ToString() : "");
                    objSponsors.InsertedTime = Convert.ToDateTime(dr["InsertedTime"].ToString());
                    objSponsors.InsertedBy = dr["InsertedBy"].ToString();

                    lstSponsors.Add(objSponsors);
                }
            }
            return lstSponsors;
        }

        #endregion

        #region Front-end

        public List<WATS.Entities.Sponsors> FEGetListLeftBlock(ref List<WATS.Entities.SponsorCategories> lstSponsorCategories, ref int status)
        {
            List<WATS.Entities.Sponsors> lstSponsors = new List<WATS.Entities.Sponsors>();

            DataSet ds = _Sponsors.FEGetListLeftBlock(ref status);
            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    WATS.Entities.Sponsors objlstSponsors = new WATS.Entities.Sponsors();

                    objlstSponsors.SponsorId = Convert.ToInt64(dr["SponsorId"].ToString());
                    objlstSponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objlstSponsors.LogoUrl = dr["LogoUrl"].ToString();
                    objlstSponsors.RedirectUrl = (dr["RedirectUrl"] != DBNull.Value ? dr["RedirectUrl"].ToString() : "");
                    //objlstSponsors.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt64(dr["DisplayOrder"]) : 0);
                    objlstSponsors.Target = (dr["Target"] != DBNull.Value ? dr["Target"].ToString() : "");


                    lstSponsors.Add(objlstSponsors);
                }
            }
            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    WATS.Entities.SponsorCategories objSponsorCategories = new WATS.Entities.SponsorCategories();

                    objSponsorCategories.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objSponsorCategories.SponsorsCount = Convert.ToInt64(dr["SponsorsCount"].ToString());
                    objSponsorCategories.CategoryName = dr["CategoryName"].ToString();
                    lstSponsorCategories.Add(objSponsorCategories);
                }
            }
            return lstSponsors;
        }

        #endregion 
    }
}
