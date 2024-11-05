﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WATS.BLL
{
    public class PhotoCategories
    {
        WATS.DAL.PhotoCategories _PhotoCategories = new WATS.DAL.PhotoCategories();

        #region Methods

        public Int64 InsertPhotoCategories(Entities.PhotoCategories objPhotoCategories)
        {
            Int64 _status = 0;
            if (objPhotoCategories != null)
            {
                _status = _PhotoCategories.InsertPhotoCategories(objPhotoCategories);

            }
            return _status;
        }

        public Int64 DeletePhotoCategories(Int64 PhotoCategoryId)
        {
            Int64 _status = 0;
            _status = _PhotoCategories.DeletePhotoCategories(PhotoCategoryId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.PhotoCategories> GetPhotoCategoriesList(ref int status)
        {
            List<WATS.Entities.PhotoCategories> lstPhotoCategories = new List<Entities.PhotoCategories>();
            DataTable dt = _PhotoCategories.GetPhotoCategoriesList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.PhotoCategories objlstPhotoCategories = new WATS.Entities.PhotoCategories();

                    objlstPhotoCategories.PhotoCategoryId = Convert.ToInt32(dr["PhotoCategoryId"].ToString());
                    objlstPhotoCategories.CategoryName = dr["CategoryName"].ToString();
                    objlstPhotoCategories.Year = Convert.ToInt64(dr["Year"].ToString());
                    objlstPhotoCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstPhotoCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());

                    lstPhotoCategories.Add(objlstPhotoCategories);
                }

            }
            return lstPhotoCategories;
        }

        public WATS.Entities.PhotoCategories GetPhotoCategoriesById(Int64 PhotoCategoryId, ref int status)
        {
            WATS.Entities.PhotoCategories objPhotoCategories = new WATS.Entities.PhotoCategories();
            DataTable dt = new DataTable();
            if (PhotoCategoryId != 0)
            {
                dt = _PhotoCategories.GetPhotoCategoriesById(PhotoCategoryId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objPhotoCategories.PhotoCategoryId = Convert.ToInt32(dt.Rows[0]["PhotoCategoryId"].ToString());
                    objPhotoCategories.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                    objPhotoCategories.Year =Convert.ToInt64(dt.Rows[0]["Year"].ToString());
                    objPhotoCategories.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objPhotoCategories.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"].ToString());

                }
            }
            return objPhotoCategories;
        }
        
        public List<WATS.Entities.PhotoCategories> GetPhotoCategoriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.PhotoCategories> lstPhotoCategories = new List<WATS.Entities.PhotoCategories>();
            DataTable dt = _PhotoCategories.GetPhotoCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _PhotoCategories.GetPhotoCategoriesListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.PhotoCategories objPhotoCategories = new WATS.Entities.PhotoCategories();

                    objPhotoCategories.PhotoCategoryId = Convert.ToInt64(dr["PhotoCategoryId"].ToString());
                    objPhotoCategories.CategoryName = dr["CategoryName"].ToString();
                    objPhotoCategories.Year =Convert.ToInt64(dr["Year"].ToString());
                    objPhotoCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                    objPhotoCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                    objPhotoCategories.RId = Convert.ToInt64(dr["RId"].ToString());
                    objPhotoCategories.PhotosCount = Convert.ToInt64(dr["PhotosCount"].ToString());

                    lstPhotoCategories.Add(objPhotoCategories);
                }
            }
            return lstPhotoCategories;
        }

        #endregion

        #region Front-end

        public List<WATS.Entities.PhotoCategories> FEGetPhotoCategoriesList(ref int status)
        {
            List<WATS.Entities.PhotoCategories> lstPhotoCategories = new List<Entities.PhotoCategories>();
            DataSet ds = _PhotoCategories.FEGetPhotoCategoriesList(ref status);
            DataTable dt = ds.Tables[0];

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.PhotoCategories objPhotoCategories = new WATS.Entities.PhotoCategories();

                    objPhotoCategories.PhotoCategoryId = Convert.ToInt32(dr["PhotoCategoryId"].ToString());
                    objPhotoCategories.CategoryName = dr["CategoryName"].ToString();

                    objPhotoCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                    objPhotoCategories.ImageUrl = dr["ImageUrl"].ToString();
                    objPhotoCategories.PhotoCount = (dr["PhotosCount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PhotosCount"]));

                    lstPhotoCategories.Add(objPhotoCategories);
                }

            }
            return lstPhotoCategories;
        }

        #endregion
    }
}
