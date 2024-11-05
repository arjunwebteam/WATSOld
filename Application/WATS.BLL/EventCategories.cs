using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class EventCategories
    {
        WATS.DAL.EventCategories _EventCategories = new WATS.DAL.EventCategories();

        #region Methods

        public Int64 InsertEventCategory(WATS.Entities.EventCategories objEventCategory)
        {

            Int64 _status = 0;
            if (objEventCategory != null)
            {
                _status = _EventCategories.InsertEventCategory(objEventCategory);
            }
            return _status;
        }

        public Int64 DeleteEventCategory(Int64 EventCategoryId)
        {
            Int64 _status = 0;
            _status = _EventCategories.DeleteEventCategoryById(EventCategoryId);

            return _status;
        }

        #endregion

        #region Entities filling

        public WATS.Entities.EventCategories GetEventCategoryById(Int64 Id)
        {
            WATS.Entities.EventCategories objEventCategory = new WATS.Entities.EventCategories();
            DataTable dt = new DataTable();
            if (Id != 0)
            {
                dt = _EventCategories.GetEventCategoryById(Id);
                if (dt.Rows.Count == 1)
                {
                    objEventCategory.EventCategoryId = Convert.ToInt64(dt.Rows[0]["EventCategoryId"]);
                    objEventCategory.EventCategory = dt.Rows[0]["EventCategory"].ToString();
                    objEventCategory.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objEventCategory.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"]);
                    objEventCategory.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                }
            }
            return objEventCategory;
        }

        public List<WATS.Entities.EventCategories> GetEventCategoriesList(ref int Total)
        {
            List<WATS.Entities.EventCategories> lstEventCategories = new List<WATS.Entities.EventCategories>();
            DataTable dt = _EventCategories.GetEventCategoriesList(ref Total);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.EventCategories objEventCategory = new WATS.Entities.EventCategories();

                    objEventCategory.EventCategoryId = Convert.ToInt64(dr["EventCategoryId"]);
                    objEventCategory.EventCategory = dr["EventCategory"].ToString();
                    objEventCategory.IsActive =Convert.ToBoolean(dr["IsActive"]);
                    objEventCategory.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
                    objEventCategory.UpdatedBy = dr["UpdatedBy"].ToString();
                    lstEventCategories.Add(objEventCategory);
                }

            }
            return lstEventCategories;
        }

        public List<WATS.Entities.EventCategories> GetEventCategoriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.EventCategories> lstEventCategorie = new List<WATS.Entities.EventCategories>();
            DataTable dt = _EventCategories.GetEventCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _EventCategories.GetEventCategoriesListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.EventCategories objEventCategorie = new WATS.Entities.EventCategories();

                    objEventCategorie.EventCategoryId = Convert.ToInt64(dr["EventCategoryId"]);
                    objEventCategorie.EventCategory = dr["EventCategory"].ToString();
                    objEventCategorie.IsActive =Convert.ToBoolean(dr["IsActive"]);
                    objEventCategorie.UpdatedBy = dr["UpdatedBy"].ToString();
                    objEventCategorie.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
                    objEventCategorie.RId = Convert.ToInt64(dr["RId"]);

                    lstEventCategorie.Add(objEventCategorie);
                }
            }
            return lstEventCategorie;
        }

        #endregion
    }
}
