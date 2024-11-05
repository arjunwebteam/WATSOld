using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
   public class VolunteerCategories
    {
        WATS.DAL.VolunteerCategories _VolunteerCategories = new WATS.DAL.VolunteerCategories();

        #region Methods

        public Int64 InsertVolunteerCategories(Entities.VolunteerCategories objVolunteerCategories)
        {
            Int64 _status = 0;
            if (objVolunteerCategories != null)
            {
                _status = _VolunteerCategories.InsertVolunteerCategories(objVolunteerCategories);

            }
            return _status;
        }

        public Int64 DeleteVolunteerCategory(Int64 VolunteerCategoryId)
        {
            Int64 _status = 0;
            _status = _VolunteerCategories.DeleteVolunteerCategory(VolunteerCategoryId);
            return _status;
        }

        public Int64 UpdateVolunteerCategoryStatus(Int64 VolunteerCategoryId)
        {
            Int64 _status = 0;
            _status = _VolunteerCategories.UpdateVolunteerCategoryStatus(VolunteerCategoryId);
            return _status;
        }

        public Int64 UpdateVolunteerCategoryDisplayOrder(int DisplayOrder, Int64 VolunteerCategoryId)
        {
            Int64 _status = 0;
            _status = _VolunteerCategories.UpdateVolunteerCategoryDisplayOrder(DisplayOrder, VolunteerCategoryId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.VolunteerCategories> GetVolunteerCategoriesList(ref int status)
        {
            List<WATS.Entities.VolunteerCategories> lstVolunteerCategories = new List<Entities.VolunteerCategories>();
            DataTable dt = _VolunteerCategories.GetVolunteerCategoriesList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.VolunteerCategories objlstVolunteerCategories = new WATS.Entities.VolunteerCategories();

                    objlstVolunteerCategories.VolunteerCategoryId = Convert.ToInt64(dr["VolunteerCategoryId"].ToString());
                    objlstVolunteerCategories.CategoryName = dr["CategoryName"].ToString();
                    objlstVolunteerCategories.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"]) : 0);
                    objlstVolunteerCategories.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objlstVolunteerCategories.Type = (dr["Type"] != DBNull.Value ? dr["Type"].ToString() : null);

                    lstVolunteerCategories.Add(objlstVolunteerCategories);
                }

            }
            return lstVolunteerCategories;
        }

        public WATS.Entities.VolunteerCategories GetVolunteerCategoryById(Int64 VolunteerCategoryId, ref int status)
        {
            WATS.Entities.VolunteerCategories objVolunteerCategories = new WATS.Entities.VolunteerCategories();
            DataTable dt = new DataTable();
            if (VolunteerCategoryId != 0)
            {
                dt = _VolunteerCategories.GetVolunteerCategoryById(VolunteerCategoryId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objVolunteerCategories.VolunteerCategoryId = Convert.ToInt64(dt.Rows[0]["VolunteerCategoryId"].ToString());
                    objVolunteerCategories.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                    objVolunteerCategories.OrderNo = (dt.Rows[0]["OrderNo"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["OrderNo"]) : 0);
                    objVolunteerCategories.Type = (dt.Rows[0]["Type"] != DBNull.Value ? dt.Rows[0]["Type"].ToString() : null);
                    objVolunteerCategories.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }
            }
            return objVolunteerCategories;
        }

        public List<WATS.Entities.VolunteerCategories> GetVolunteerCategoriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.VolunteerCategories> lstVolunteerCategories = new List<WATS.Entities.VolunteerCategories>();
            DataTable dt = _VolunteerCategories.GetVolunteerCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _VolunteerCategories.GetVolunteerCategoriesListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.VolunteerCategories objVolunteerCategories = new WATS.Entities.VolunteerCategories();

                    objVolunteerCategories.RId = Convert.ToInt64(dr["RId"].ToString());
                    objVolunteerCategories.VolunteerCategoryId = Convert.ToInt64(dr["VolunteerCategoryId"].ToString());
                    objVolunteerCategories.CategoryName = dr["CategoryName"].ToString();
                    objVolunteerCategories.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"]) : 0);
                    objVolunteerCategories.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objVolunteerCategories.Type = (dr["Type"] != DBNull.Value ? dr["Type"].ToString() : null);

                    lstVolunteerCategories.Add(objVolunteerCategories);
                }
            }
            return lstVolunteerCategories;
        }


        public List<WATS.Entities.VolunteerCategories> FEGetVolunteerCategoriesList(ref int status)
        {
            List<WATS.Entities.VolunteerCategories> lstVolunteerCategories = new List<Entities.VolunteerCategories>();
            DataTable dt = _VolunteerCategories.FEGetVolunteerCategoriesList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.VolunteerCategories objlstVolunteerCategories = new WATS.Entities.VolunteerCategories();

                    objlstVolunteerCategories.VolunteerCategoryId = Convert.ToInt64(dr["VolunteerCategoryId"].ToString());
                    objlstVolunteerCategories.CategoryName = dr["CategoryName"].ToString();
                    objlstVolunteerCategories.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"]) : 0);
                    objlstVolunteerCategories.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objlstVolunteerCategories.Type = (dr["Type"] != DBNull.Value ? dr["Type"].ToString() : null);

                    lstVolunteerCategories.Add(objlstVolunteerCategories);
                }

            }
            return lstVolunteerCategories;
        }

        #endregion

    }
}
