using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class AdvertiseWithUs
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public Int64 InsertAdvertiseWithUs(Entities.AdvertiseWithUs objAdvertiseWithUs, ref Int64 AdvertiseWithUsId, ref string ImageUrl)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@AdvertiseWithUsId",objAdvertiseWithUs.AdvertiseWithUsId),
                    new SqlParameter("@CompanyName",(objAdvertiseWithUs.CompanyName == null ?DBNull.Value:(object)objAdvertiseWithUs.CompanyName)),
                    new SqlParameter("@FirstName",(objAdvertiseWithUs.FirstName == null ?DBNull.Value:(object)objAdvertiseWithUs.FirstName)),
                    new SqlParameter("@LastName",(objAdvertiseWithUs.LastName == null ?DBNull.Value:(object)objAdvertiseWithUs.LastName)),
                    new SqlParameter("@Email",(objAdvertiseWithUs.Email == null ?DBNull.Value:(object)objAdvertiseWithUs.Email)),
                    new SqlParameter("@ImageUrl",ImageUrl),
                    new SqlParameter("@PhoneNo",(objAdvertiseWithUs.PhoneNo == null ?DBNull.Value:(object)objAdvertiseWithUs.PhoneNo)),
                    new SqlParameter("@Address",(objAdvertiseWithUs.Address == null ?DBNull.Value:(object)objAdvertiseWithUs.Address)),
                    new SqlParameter("@IsActive",objAdvertiseWithUs.IsActive),
                    new SqlParameter("@Amount",(objAdvertiseWithUs.Amount == 0 ?DBNull.Value:(object)objAdvertiseWithUs.Amount)),
                    new SqlParameter("@TransactionId",(objAdvertiseWithUs.TransactionId == null ?DBNull.Value:(object)objAdvertiseWithUs.TransactionId)),
                    new SqlParameter("@PaymentStatusId",(objAdvertiseWithUs.PaymentStatusId == 0 ?DBNull.Value:(object)objAdvertiseWithUs.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objAdvertiseWithUs.PaymentMethodId == 0 ?DBNull.Value:(object)objAdvertiseWithUs.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",(objAdvertiseWithUs.PaymentDate == DateTime.MinValue ?DBNull.Value:(object)objAdvertiseWithUs.PaymentDate)),
                    new SqlParameter("@Comment",(objAdvertiseWithUs.Comment == null ?DBNull.Value:(object)objAdvertiseWithUs.Comment)),                    
                    new SqlParameter("@InsertedBy",objAdvertiseWithUs.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objAdvertiseWithUs.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[5].SqlDbType = SqlDbType.NVarChar;
                _sqlP[5].Size = 512;
                _sqlP[5].Direction = System.Data.ParameterDirection.InputOutput;
                _sqlP[0].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[19].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("AdvertiseWithUsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[19].Value);

                AdvertiseWithUsId = Convert.ToInt64(_sqlP[0].Value);
                ImageUrl = _sqlP[5].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateAdvertiseWithUsStatus(Int64 AdvertiseWithUsId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@AdvertiseWithUsId",AdvertiseWithUsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("AdvertiseWithUsUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateAdvertiseWithUs(Entities.AdvertiseWithUs objAdvertiseWithUs)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@AdvertiseWithUsId",objAdvertiseWithUs.AdvertiseWithUsId),                    
                    new SqlParameter("@Amount",(objAdvertiseWithUs.Amount == 0 ?DBNull.Value:(object)objAdvertiseWithUs.Amount)),
                    new SqlParameter("@TransactionId",(objAdvertiseWithUs.TransactionId == null ?DBNull.Value:(object)objAdvertiseWithUs.TransactionId)),
                    new SqlParameter("@PaymentStatusId",(objAdvertiseWithUs.PaymentStatusId == 0 ?DBNull.Value:(object)objAdvertiseWithUs.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objAdvertiseWithUs.PaymentMethodId == 0 ?DBNull.Value:(object)objAdvertiseWithUs.PaymentMethodId)),
                    new SqlParameter("@PaymentStatus",(objAdvertiseWithUs.PaymentStatus == null ?DBNull.Value:(object)objAdvertiseWithUs.PaymentStatus)),
                    new SqlParameter("@PaymentMethod",(objAdvertiseWithUs.PaymentMethod == null ?DBNull.Value:(object)objAdvertiseWithUs.PaymentMethod)),
                    new SqlParameter("@PaymentDate",(objAdvertiseWithUs.PaymentDate == DateTime.MinValue ?DBNull.Value:(object)objAdvertiseWithUs.PaymentDate)),                   
                    new SqlParameter("@UpdatedBy",objAdvertiseWithUs.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[10].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("AdvertiseWithUsUpdate", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[10].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetAdvertiseWithUsListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),                    
                    new SqlParameter("@Total",Total)
                };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("AdvertiseWithUsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetAdvertiseWithUsById(Int64 AdvertiseWithUsId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@AdvertiseWithUsId",AdvertiseWithUsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("AdvertiseWithUsGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteAdvertiseWithUs(Int64 AdvertiseWithUsId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@AdvertiseWithUsId",AdvertiseWithUsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("AdvertiseWithUsDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        #region Front-end

        public DataTable FEAdvertiseWithUsGetList(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),                    
                    new SqlParameter("@Total",Total)
                };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("FEAdvertiseWithUsGetList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #endregion
    }
}
