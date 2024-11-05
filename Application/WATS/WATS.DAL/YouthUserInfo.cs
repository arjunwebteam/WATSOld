using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class YouthUserInfo
    {

        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        #region Admin

        public Int64 UpdateYouthUserInfo(WATS.Entities.YouthUserInfo objYouthUserInfo)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@YouthUserInfoId",objYouthUserInfo.YouthUserInfoId),                   
                    new SqlParameter("@FirstName",objYouthUserInfo.FirstName ),
                    new SqlParameter("@LastName",objYouthUserInfo.LastName),
                    new SqlParameter("@Email",objYouthUserInfo.Email),
                    new SqlParameter("@Mobile",(objYouthUserInfo.Mobile==null?(object)DBNull.Value:objYouthUserInfo.Mobile)),
                    new SqlParameter("@Grade",(objYouthUserInfo.Grade==null?(object)DBNull.Value:objYouthUserInfo.Grade)),                
                    new SqlParameter("@Age",(objYouthUserInfo.Age==0    ?(object)DBNull.Value:objYouthUserInfo.Age)),
                    new SqlParameter("@Hobbies",(objYouthUserInfo.Hobbies==null?(object)DBNull.Value:objYouthUserInfo.Hobbies)),
                    new SqlParameter("@WhyCommitteeMember",(objYouthUserInfo.WhyCommitteeMember==null?(object)DBNull.Value:objYouthUserInfo.WhyCommitteeMember)),
                    new SqlParameter("@AdminComment",(objYouthUserInfo.AdminComment==null?(object)DBNull.Value:objYouthUserInfo.AdminComment)),
                    new SqlParameter("@IsMember",objYouthUserInfo.IsMember),
                    new SqlParameter("@UpdatedBy",objYouthUserInfo.UpdatedBy),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[13].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("YouthUserInfoUpdate", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[13].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }       

        public DataTable GetYouthUserInfoListByVariable(string StartDate,string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",0)
                };
                _sqlP[6].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("YouthUserInfoGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetYouthUserInfoById(Int64 YouthUserInfoId, ref int Status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@YouthUserInfoId",YouthUserInfoId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("YouthUserInfoGetById", ref _sqlP);
                Status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteYouthUserInfoById(Int64 YouthUserInfoId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@YouthUserInfoId",YouthUserInfoId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("YouthUserInfoDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        #endregion

        #region Front End

        public Int64 InsertYouthUserInfo(WATS.Entities.YouthUserInfo objYouthUserInfo)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@YouthUserInfoId",objYouthUserInfo.YouthUserInfoId),                   
                    new SqlParameter("@FirstName",objYouthUserInfo.FirstName ),
                    new SqlParameter("@LastName",objYouthUserInfo.LastName),
                    new SqlParameter("@Email",objYouthUserInfo.Email),
                    new SqlParameter("@Mobile",(objYouthUserInfo.Mobile==null?(object)DBNull.Value:objYouthUserInfo.Mobile)),
                    new SqlParameter("@Grade",(objYouthUserInfo.Grade==null?(object)DBNull.Value:objYouthUserInfo.Grade)),                
                    new SqlParameter("@Age",(objYouthUserInfo.Age==0    ?(object)DBNull.Value:objYouthUserInfo.Age)),
                    new SqlParameter("@Hobbies",(objYouthUserInfo.Hobbies==null?(object)DBNull.Value:objYouthUserInfo.Hobbies)),
                    new SqlParameter("@WhyCommitteeMember",(objYouthUserInfo.WhyCommitteeMember==null?(object)DBNull.Value:objYouthUserInfo.WhyCommitteeMember)),
                    new SqlParameter("@AdminComment",(objYouthUserInfo.AdminComment==null?(object)DBNull.Value:objYouthUserInfo.AdminComment)),
                    new SqlParameter("@IsMember",objYouthUserInfo.IsMember),
                    new SqlParameter("@UpdatedBy",objYouthUserInfo.UpdatedBy),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[13].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("YouthUserInfoInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[13].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        #endregion
    }
}
