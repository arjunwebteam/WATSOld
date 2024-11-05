using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class InnerPageCategories
    {
        DAL.InnerPageCategories _InnerPageCategory = new DAL.InnerPageCategories();        

        #region Methods

        public Int64 DeleteInnerPageCategory(Int64 InnerPageCategoryId)
        {
            Int64 _status = 0;
            if (InnerPageCategoryId != 0)
            {
                _status = _InnerPageCategory.DeleteInnerPageCategory(InnerPageCategoryId);
            }
            return _status;
        }

        public Int64 InsertInnerPageCategory(Entities.InnerPageCategories objInnerPageCategory)
        {
            Int64 _status = 0;
            if (objInnerPageCategory != null)
            {
                _status = _InnerPageCategory.InsertInnerPageCategory(objInnerPageCategory);
            }
            return _status;
        }

        #endregion

        #region Entity Loading

        public List<Entities.InnerPageCategories> GetInnerPageCategoriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = _InnerPageCategory.GetInnerPageCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
            List<Entities.InnerPageCategories> lstInnerPageCategory = new List<Entities.InnerPageCategories>();

            if (dt.Rows.Count == 0 && PageNo > 1)
            {
                dt = _InnerPageCategory.GetInnerPageCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
            }

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.InnerPageCategories objInnerPageCategory = new Entities.InnerPageCategories();

                    objInnerPageCategory.RId = Convert.ToInt64(dr["Rid"]);
                    objInnerPageCategory.InnerPageCategoryId = Convert.ToInt64(dr["InnerPageCategoryId"]);
                    objInnerPageCategory.CategoryName = dr["CategoryName"].ToString();
                    objInnerPageCategory.UpdatedBy = dr["UpdatedBy"].ToString();
                    objInnerPageCategory.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
                    objInnerPageCategory.InnerPagesCount = Convert.ToInt64(dr["InnerPagesCount"]);

                    lstInnerPageCategory.Add(objInnerPageCategory);
                }
            }
            return lstInnerPageCategory;
        }

        public Entities.InnerPageCategories GetInnerPageCategoryById(Int64 InnerPageCategoryId, ref int status)
        {
            DataTable dt = _InnerPageCategory.GetInnerPageCategoryById(InnerPageCategoryId, ref status);
            Entities.InnerPageCategories objInnerPages = new Entities.InnerPageCategories();

            if (dt.Rows.Count == 1)
            {
                objInnerPages.InnerPageCategoryId = Convert.ToInt64(dt.Rows[0]["InnerPageCategoryId"]);
                objInnerPages.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                objInnerPages.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                objInnerPages.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"]);
            }

            return objInnerPages;
        }

        public List<Entities.InnerPageCategories> GetInnerPageCategoriesList(ref int status)
        {
            DataTable dt = _InnerPageCategory.GetInnerPageCategoriesList(ref status);
            List<Entities.InnerPageCategories> lstInnerPageCategory = new List<Entities.InnerPageCategories>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.InnerPageCategories objInnerPageCategory = new Entities.InnerPageCategories();

                    objInnerPageCategory.InnerPageCategoryId = Convert.ToInt64(dr["InnerPageCategoryId"]);
                    objInnerPageCategory.CategoryName = dr["CategoryName"].ToString();

                    lstInnerPageCategory.Add(objInnerPageCategory);
                }
            }

            return lstInnerPageCategory;
        }

        #endregion
    }
}
