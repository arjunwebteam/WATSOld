using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.DAL
{
   public class ChoreographerInfo
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public Int64 FEChoreographerInfoInsert(Entities.ChoreographerInfo objChoreographerInfo, ref string ImageUrl)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@ChoreographerId",objChoreographerInfo.ChoreographerId),
                    new SqlParameter("@FirstName",objChoreographerInfo.FirstName),
                    new SqlParameter("@LastName",objChoreographerInfo.LastName),
                    new SqlParameter("@Email",objChoreographerInfo.Email),
                    new SqlParameter("@Password",(objChoreographerInfo.Password == null ?DBNull.Value:(object)objChoreographerInfo.Password)),
                    new SqlParameter("@MobileNo",(objChoreographerInfo.MobileNo == null ?DBNull.Value:(object)objChoreographerInfo.MobileNo)),
                    new SqlParameter("@Passion",(objChoreographerInfo.Passion == null ?DBNull.Value:(object)objChoreographerInfo.Passion)),
                    new SqlParameter("@ImageUrl", ImageUrl),
                    new SqlParameter("@Description",(objChoreographerInfo.Description == null ?DBNull.Value:(object)objChoreographerInfo.Description)),
                    new SqlParameter("@IsActive",objChoreographerInfo.IsActive),
                    new SqlParameter("@Field1",(objChoreographerInfo.Field1 == null ?DBNull.Value:(object)objChoreographerInfo.Field1)),
                    new SqlParameter("@InsertedBy",objChoreographerInfo.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objChoreographerInfo.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[7].SqlDbType = SqlDbType.NVarChar;
                _sqlP[7].Size = 256;
                _sqlP[7].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[15].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("ChoreographerInfoInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[15].Value);

                ImageUrl = _sqlP[7].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 ChangePassword(Int64 ChoreographerId, string Password)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@ChoreographerId",ChoreographerId),
                    new SqlParameter("@Password",Password),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("ChoreographerChangePassword", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataSet GetChoreographerFullDetailsByEmail(string Email, ref int status)
        {
            DataSet ds0 = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@Email",Email),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataSet("ChoreographerInfoGetByEmail", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        public DataTable GetCPassword(Int64 _ChoreographerId, ref int _QStatus)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] {
                new SqlParameter("@ChoreographerId",_ChoreographerId),
                new SqlParameter("@QStatus",_QStatus)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;

                dt = _dbAccess.GetDataTable("ChoreographerGetPassword", ref _sqlP);
                _QStatus = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetEventParticipantsGetlistbyId(Int64 ChoreographerId, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@ChoreographerId",ChoreographerId), 
                    new SqlParameter("@Total",Total)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("FEGetEventParticipantsGetdetailsById", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        //public DataTable GetEventParticipantsGetlistbyId( Int64 ChoreographerId, string Search, string Sort, int PageNo, int Items, ref int Total)
        //{
        //    DataTable dt = null;
        //    try
        //    {
        //        _sqlP = new[]
        //        {
        //            new SqlParameter("@ChoreographerId",ChoreographerId),
        //            new SqlParameter("@Search",Search),
        //            new SqlParameter("@Sort",Sort),
        //            new SqlParameter("@PageNo",PageNo),
        //            new SqlParameter("@Items",Items),
        //            new SqlParameter("@Total",Total)
        //        };
        //        _sqlP[5].Direction = System.Data.ParameterDirection.Output;
        //        dt = _dbAccess.GetDataTable("FEGetEventParticipantsGetlistById", ref _sqlP);
        //        Total = Convert.ToInt32(_sqlP[5].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return dt;
        //}
    }
}
