﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WATS.BLL
{
   public class Videos
    {
       WATS.DAL.Videos _Videos = new WATS.DAL.Videos();

        #region Methods

       public Int64 InsertVideos(Entities.Videos objVideos)
        {
            Int64 _status = 0;
            if (objVideos != null)
            {
                _status = _Videos.InsertVideos(objVideos);

            }
            return _status;
        }

       public Int64 DeleteVideo(Int64 VideoId)
        {
            Int64 _status = 0;
            _status = _Videos.DeleteVideo(VideoId);
            return _status;
        }
       
       public Int64 VideosDefaultVideo(Int64 VideoId, Int64 VideoCategoryId)
       {
           Int64 _status = 0;
           _status = _Videos.VideosDefaultVideo(VideoId, VideoCategoryId);
           return _status;
       }

       public Int64 DeleteAllVideos(string VideoId)
       {
           Int64 _status = 0;
           _status = _Videos.DeleteAllVideos(VideoId);
           return _status;
       }

       public Int64 UpdateWebsiteBannersStatus(Int64 VideoId)
       {
           Int64 _status = 0;
           _status = _Videos.UpdateVideosStatus(VideoId);
           return _status;
       }

       public Int64 UpdateVideosDisplayOrder(int DisplayOrder, Int64 VideoId)
       {
           Int64 _status = 0;
           _status = _Videos.UpdateVideosDisplayOrder(DisplayOrder, VideoId);
           return _status;
       }

        #endregion

       #region Entities filling

       public List<WATS.Entities.Videos> GetVideosList(ref int status)
        {
            List<WATS.Entities.Videos> lstVideos = new List<Entities.Videos>();
            DataTable dt = _Videos.GetVideosList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Videos objlstVideos = new WATS.Entities.Videos();
                    objlstVideos.VideoId = Convert.ToInt32(dr["VideoId"].ToString());
                    objlstVideos.VideoCategoryId = Convert.ToInt32(dr["VideoCategoryId"].ToString());
                    objlstVideos.Heading = dr["Heading"].ToString();
                    objlstVideos.VideoUrl = dr["VideoUrl"].ToString();
                    objlstVideos.VideoDescription = (dr["VideoDescription"] != DBNull.Value ? dr["VideoDescription"].ToString() : "");
                    objlstVideos.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0);
                    objlstVideos.IsHome = Convert.ToBoolean(dr["IsHome"].ToString());
                    objlstVideos.IsActive = Convert.ToBoolean(dr["IsActive"]);                   
                    objlstVideos.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstVideos.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                    lstVideos.Add(objlstVideos);
                }

            }
            return lstVideos;
        }

       public WATS.Entities.Videos GetVideoById(Int64 PhotoId, ref int status)
        {
            WATS.Entities.Videos objVideos = new WATS.Entities.Videos();
            DataTable dt = new DataTable();
            if (PhotoId != 0)
            {
                dt = _Videos.GetVideoById(PhotoId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objVideos.VideoId = Convert.ToInt32(dt.Rows[0]["VideoId"].ToString());
                    objVideos.VideoCategoryId = Convert.ToInt32(dt.Rows[0]["VideoCategoryId"].ToString());
                    objVideos.VideoUrl = dt.Rows[0]["VideoUrl"].ToString();
                    objVideos.Heading = dt.Rows[0]["Heading"].ToString();
                    objVideos.VideoDescription = (dt.Rows[0]["VideoDescription"] != DBNull.Value ? dt.Rows[0]["VideoDescription"].ToString() : "");
                    objVideos.DisplayOrder = (dt.Rows[0]["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["DisplayOrder"]) : 0);
                    objVideos.IsHome = Convert.ToBoolean(dt.Rows[0]["IsHome"].ToString());
                    objVideos.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"].ToString());
                    objVideos.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objVideos.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"].ToString());

                }
            }
            return objVideos;
        }

       public List<WATS.Entities.Videos> GetVideosListByVariable(Int64 VideoCategoryId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Videos> lstVideos = new List<WATS.Entities.Videos>();
            DataTable dt = _Videos.GetVideoListByVariable(VideoCategoryId, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Videos.GetVideoListByVariable(VideoCategoryId, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Videos objVideos = new WATS.Entities.Videos();

                    objVideos.RId = Convert.ToInt64(dr["RId"].ToString());
                    objVideos.VideoId = Convert.ToInt64(dr["VideoId"].ToString());
                    objVideos.VideoCategoryId = Convert.ToInt64(dr["VideoCategoryId"].ToString());
                    objVideos.CategoryName = dr["CategoryName"].ToString();
                    objVideos.Heading = dr["Heading"].ToString();
                    objVideos.VideoUrl = dr["VideoUrl"].ToString();
                    objVideos.VideoDescription = (dr["VideoDescription"] != DBNull.Value ? dr["VideoDescription"].ToString() : "");
                    objVideos.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt64(dr["DisplayOrder"]) : 0);
                    objVideos.IsHome = Convert.ToBoolean(dr["IsHome"].ToString());
                    objVideos.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                    objVideos.UpdatedBy = dr["UpdatedBy"].ToString();
                    objVideos.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());

                    lstVideos.Add(objVideos);
                }
            }
            return lstVideos;
        }

        #endregion

       #region Front-End

       public List<WATS.Entities.Videos> FEGetVideosListById(string VideoCategoryName, ref List<Entities.VideoCategories> lstVideoCategories, ref int status)
       {
           List<WATS.Entities.Videos> lstVideos = new List<Entities.Videos>();
           DataSet ds = _Videos.FEGetVideosListById(VideoCategoryName, ref status);
           DataTable dt = ds.Tables[0];

           if (dt.Rows.Count != 0)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   Entities.Videos objVideos = new Entities.Videos();

                   objVideos.VideoId = Convert.ToInt64(dr["VideoId"]);
                   objVideos.Heading = dr["Heading"].ToString();
                   objVideos.VideoUrl = dr["VideoUrl"].ToString();
                   objVideos.VideoDescription = dr["VideoDescription"].ToString();
                   objVideos.VideoUrl = dr["VideoUrl"].ToString();
                   objVideos.VideoCategoryId = Convert.ToInt64(dr["VideoCategoryId"]);
                   objVideos.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                   lstVideos.Add(objVideos);
               }

           }
           if (ds.Tables[1].Rows.Count != 0)
           {
               foreach (DataRow dr in ds.Tables[1].Rows)
               {
                   WATS.Entities.VideoCategories objlstVideoCategories = new WATS.Entities.VideoCategories();

                   objlstVideoCategories.VideoCategoryId = Convert.ToInt64(dr["VideoCategoryId"].ToString());
                   objlstVideoCategories.VideosCount = Convert.ToInt64(dr["VideosCount"].ToString());
                   objlstVideoCategories.CategoryName = (dr["CategoryName"] != DBNull.Value ? dr["CategoryName"].ToString() : "");
                   objlstVideoCategories.Year = Convert.ToInt64(dr["Year"].ToString());
                   objlstVideoCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                   objlstVideoCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());


                   lstVideoCategories.Add(objlstVideoCategories);
               }

           }

           return lstVideos;
       }

       public List<WATS.Entities.Videos> FEGetVideoList(ref List<Entities.VideoCategories> lstVideoCategories, ref int status)
       {
           List<WATS.Entities.Videos> lstVideos = new List<Entities.Videos>();
           DataSet ds = _Videos.FEGetVideoList(ref status);

           //Videos List          
           if (ds.Tables[0].Rows.Count != 0)
           {
               foreach (DataRow dr in ds.Tables[0].Rows)
               {
                   Entities.Videos objVideos = new Entities.Videos();

                   objVideos.VideoId = Convert.ToInt64(dr["VideoId"]);
                   objVideos.Heading = dr["Heading"].ToString();
                   objVideos.VideoUrl = dr["VideoUrl"].ToString();
                   objVideos.VideoDescription = dr["VideoDescription"].ToString();
                   objVideos.VideoUrl = dr["VideoUrl"].ToString();
                   objVideos.VideoCategoryId = Convert.ToInt64(dr["VideoCategoryId"]);
                   objVideos.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                   lstVideos.Add(objVideos);
               }
           }

           if (ds.Tables[1].Rows.Count != 0)
           {
               foreach (DataRow dr in ds.Tables[1].Rows)
               {
                   WATS.Entities.VideoCategories objlstVideoCategories = new WATS.Entities.VideoCategories();

                   objlstVideoCategories.VideoCategoryId = Convert.ToInt64(dr["VideoCategoryId"].ToString());
                   objlstVideoCategories.VideosCount = Convert.ToInt64(dr["VideosCount"].ToString());
                   objlstVideoCategories.CategoryName = (dr["CategoryName"] != DBNull.Value ? dr["CategoryName"].ToString() : "");
                   objlstVideoCategories.Year = Convert.ToInt64(dr["Year"].ToString());
                   objlstVideoCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                   objlstVideoCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());


                   lstVideoCategories.Add(objlstVideoCategories);
               }

           }
           return lstVideos;
       }

       #endregion
    }
}
