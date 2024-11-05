using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace WATS.DAL
{
    public class SponsorRegistrations
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public Int64 InsertSponsorRegistration(Entities.SponsorRegistrations objSponsorRegistrations, ref Int64 SponsorRegistrationId, ref string imageurl)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@SponsorRegistrationId",objSponsorRegistrations.SponsorRegistrationId),
                    new SqlParameter("@FirstName",objSponsorRegistrations.FirstName),
                    new SqlParameter("@LastName",objSponsorRegistrations.LastName),
                    new SqlParameter("@Email",objSponsorRegistrations.Email),
                    new SqlParameter("@PhoneNo",(objSponsorRegistrations.PhoneNo == null ?DBNull.Value:(object)objSponsorRegistrations.PhoneNo)),
                    new SqlParameter("@Address",(objSponsorRegistrations.Address == null ?DBNull.Value:(object)objSponsorRegistrations.Address)),
                    new SqlParameter("@ImageUrl",imageurl),
                    new SqlParameter("@IsActive",objSponsorRegistrations.IsActive),
                    new SqlParameter("@Amount",(objSponsorRegistrations.Amount == 0 ?DBNull.Value:(object)objSponsorRegistrations.Amount)),
                    new SqlParameter("@TransactionId",(objSponsorRegistrations.TransactionId == null ?DBNull.Value:(object)objSponsorRegistrations.TransactionId)),
                    new SqlParameter("@PaymentStatusId",(objSponsorRegistrations.PaymentStatusId == 0 ?DBNull.Value:(object)objSponsorRegistrations.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objSponsorRegistrations.PaymentMethodId == 0 ?DBNull.Value:(object)objSponsorRegistrations.PaymentMethodId)),
                    new SqlParameter("@OrderDate",(objSponsorRegistrations.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objSponsorRegistrations.OrderDate)),
                    new SqlParameter("@PaymentBy",(objSponsorRegistrations.PaymentBy == null ?DBNull.Value:(object)objSponsorRegistrations.PaymentBy)),                    
                    new SqlParameter("@InsertedBy",objSponsorRegistrations.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objSponsorRegistrations.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0),
                    new SqlParameter("@SponsorRegistrationCategoryId",(objSponsorRegistrations.SponsorRegistrationCategoryId == null ?DBNull.Value:(object)objSponsorRegistrations.SponsorRegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objSponsorRegistrations.MemberId == null ?DBNull.Value:(object)objSponsorRegistrations.MemberId)),
                    };

                
                _sqlP[0].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[6].SqlDbType = SqlDbType.NVarChar;
                _sqlP[6].Size = 512;
                _sqlP[6].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[18].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[18].Value);

                SponsorRegistrationId = Convert.ToInt64(_sqlP[0].Value);
                imageurl = _sqlP[6].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateSponsorRegistrationStatus(Int64 SponsorRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistrationId",SponsorRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateSponsorRegistration(Entities.SponsorRegistrations objSponsorRegistrations)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@SponsorRegistrationId",objSponsorRegistrations.SponsorRegistrationId),                    
                    new SqlParameter("@Amount",(objSponsorRegistrations.Amount == 0 ?DBNull.Value:(object)objSponsorRegistrations.Amount)),
                    new SqlParameter("@TransactionId",(objSponsorRegistrations.TransactionId == null ?DBNull.Value:(object)objSponsorRegistrations.TransactionId)),
                    new SqlParameter("@PaymentStatusId",(objSponsorRegistrations.PaymentStatusId == 0 ?DBNull.Value:(object)objSponsorRegistrations.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objSponsorRegistrations.PaymentMethodId == 0 ?DBNull.Value:(object)objSponsorRegistrations.PaymentMethodId)),
                    new SqlParameter("@PaymentStatus",(objSponsorRegistrations.PaymentStatus == null ?DBNull.Value:(object)objSponsorRegistrations.PaymentStatus)),
                    new SqlParameter("@PaymentMethod",(objSponsorRegistrations.PaymentMethod == null ?DBNull.Value:(object)objSponsorRegistrations.PaymentMethod)),
                    new SqlParameter("@OrderDate",(objSponsorRegistrations.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objSponsorRegistrations.OrderDate)),                   
                    new SqlParameter("@UpdatedBy",objSponsorRegistrations.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[10].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationUpdate", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[10].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetSponsorRegistrationListByVariable(Int64 SponsorRegistrationCategoryId, Int64 EventId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistrationCategoryId",SponsorRegistrationCategoryId),
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),                    
                    new SqlParameter("@Total",Total)
                };

                _sqlP[6].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("SponsorRegistrationGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetSponsorRegistrationById(Int64 SponsorRegistrationId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistrationId",SponsorRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("SponsorRegistrationGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteSponsorRegistration(Int64 SponsorRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistrationId",SponsorRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable ExportSponserRegistrationList(Int64 SponsorRegistrationCategoryId, Int64 EventId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@SponsorRegistrationCategoryId",SponsorRegistrationCategoryId),
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    //new SqlParameter("@PageNo",PageNo),
                    //new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportSponsorRegistrationGetList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
