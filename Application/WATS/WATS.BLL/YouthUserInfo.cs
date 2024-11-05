using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;


namespace WATS.BLL
{
    public class YouthUserInfo
    {
        DAL.YouthUserInfo _YouthUserInfo = new DAL.YouthUserInfo();

        #region Admin

        public Int64 UpdateYouthUserInfo(Entities.YouthUserInfo objYouthUserInfo)
        {
            Int64 _status = 0;
            if (objYouthUserInfo != null)
            {
                _status = _YouthUserInfo.UpdateYouthUserInfo(objYouthUserInfo);
            }
            return _status;
        }

        public Entities.YouthUserInfo GetYouthUserInfoById(Int64 YouthUserInfoId, ref int status)
        {
            DataTable dt = _YouthUserInfo.GetYouthUserInfoById(YouthUserInfoId, ref status);
            Entities.YouthUserInfo objYouthUserInfo = new Entities.YouthUserInfo();

            if (dt.Rows.Count == 1)
            {
                objYouthUserInfo.YouthUserInfoId = Convert.ToInt64(dt.Rows[0]["YouthUserInfoId"]);
                objYouthUserInfo.FirstName = dt.Rows[0]["FirstName"].ToString();
                objYouthUserInfo.LastName = dt.Rows[0]["LastName"].ToString();
                objYouthUserInfo.Email = dt.Rows[0]["Email"].ToString();
                objYouthUserInfo.Mobile = (dt.Rows[0]["Mobile"] != DBNull.Value ? dt.Rows[0]["Mobile"].ToString() : null);
                objYouthUserInfo.Grade = (dt.Rows[0]["Grade"] != DBNull.Value ? dt.Rows[0]["Grade"].ToString() : null);
                objYouthUserInfo.Age = (dt.Rows[0]["Age"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["Age"].ToString()) : 0);
                objYouthUserInfo.Hobbies = (dt.Rows[0]["Hobbies"] != DBNull.Value ? dt.Rows[0]["Hobbies"].ToString() : null);
                objYouthUserInfo.WhyCommitteeMember = (dt.Rows[0]["WhyCommitteeMember"] != DBNull.Value ? dt.Rows[0]["WhyCommitteeMember"].ToString() : null);               
                objYouthUserInfo.AdminComment = (dt.Rows[0]["AdminComment"] != DBNull.Value ? dt.Rows[0]["AdminComment"].ToString() : null);
                objYouthUserInfo.IsMember = Convert.ToBoolean(dt.Rows[0]["IsMember"]);
                objYouthUserInfo.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                objYouthUserInfo.UpdatedTime = DateTime.UtcNow;
            }

            return objYouthUserInfo;
        }

        public Int64 DeleteYouthUserInfoById(Int64 YouthUserInfoId)
        {
            Int64 _status = 0;
            _status = _YouthUserInfo.DeleteYouthUserInfoById(YouthUserInfoId);
            return _status;
        }

        public List<WATS.Entities.YouthUserInfo> GetYouthUserInfoListByVariable(string StartDate,string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.YouthUserInfo> lstYouthUserInfo = new List<WATS.Entities.YouthUserInfo>();
            DataTable dt = _YouthUserInfo.GetYouthUserInfoListByVariable(StartDate,EndDate, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _YouthUserInfo.GetYouthUserInfoListByVariable(StartDate, EndDate, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.YouthUserInfo objYouthUserInfo = new WATS.Entities.YouthUserInfo();

                    objYouthUserInfo.RId = Convert.ToInt64(dr["RId"]);
                    objYouthUserInfo.YouthUserInfoId = Convert.ToInt64(dr["YouthUserInfoId"]);
                    objYouthUserInfo.FirstName = dr["FirstName"].ToString();
                    objYouthUserInfo.LastName = dr["LastName"].ToString();
                    objYouthUserInfo.Email = dr["Email"].ToString();
                    objYouthUserInfo.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
                    objYouthUserInfo.Grade = (dr["Grade"] != DBNull.Value ? dr["Grade"].ToString() : null);
                    objYouthUserInfo.Age = (dr["Age"] != DBNull.Value ? Convert.ToInt32(dr["Age"].ToString()) : 0);
                    objYouthUserInfo.Hobbies = (dr["Hobbies"] != DBNull.Value ? dr["Hobbies"].ToString() : null);
                    objYouthUserInfo.IsMember = Convert.ToBoolean(dt.Rows[0]["IsMember"]);
                    objYouthUserInfo.UpdatedBy = dr["UpdatedBy"].ToString();
                    objYouthUserInfo.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    lstYouthUserInfo.Add(objYouthUserInfo);
                }
            }
            return lstYouthUserInfo;
        }

        #endregion

        #region Front End

        public Int64 InsertYouthUserInfo(Entities.YouthUserInfo objYouthUserInfo)
        {
            Int64 _status = 0;
            if (objYouthUserInfo != null)
            {
                _status = _YouthUserInfo.InsertYouthUserInfo(objYouthUserInfo);
            }
            return _status;
        }

        #endregion 
    }
}
