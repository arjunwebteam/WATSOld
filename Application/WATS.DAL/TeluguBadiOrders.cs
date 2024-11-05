using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;


namespace WATS.DAL
{
  public  class TeluguBadiOrders
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public DataTable GetTeluguBadiOrdersListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("TeluguBadiOrdersGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 InsertTeluguBadiOrder(WATS.Entities.TeluguBadiOrders objTeluguBadiOrders)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                        new SqlParameter("@OrderId",objTeluguBadiOrders.OrderId),
                        new SqlParameter("@TRegistrationId",objTeluguBadiOrders.TRegistrationId),
                        new SqlParameter("@TeluguBadiTypeId",objTeluguBadiOrders.TeluguBadiTypeId),
                        new SqlParameter("@Amount",(objTeluguBadiOrders.Amount == 0 ?DBNull.Value:(object)objTeluguBadiOrders.Amount)),
                        new SqlParameter("@TransactionId",(objTeluguBadiOrders.TransactionId == null ?DBNull.Value:(object)objTeluguBadiOrders.TransactionId)),
                        new SqlParameter("@PaymentStatus",(objTeluguBadiOrders.PaymentStatus == null ?DBNull.Value:(object)objTeluguBadiOrders.PaymentStatus)),
                        new SqlParameter("@PaymentMethod",(objTeluguBadiOrders.PaymentMethod == null ?DBNull.Value:(object)objTeluguBadiOrders.PaymentMethod)),
                        new SqlParameter("@PaymentStatusId",(objTeluguBadiOrders.PaymentStatusId == 0 ?DBNull.Value:(object)objTeluguBadiOrders.PaymentStatusId)),
                        new SqlParameter("@PaymentMethodId",(objTeluguBadiOrders.PaymentMethodId == 0 ?DBNull.Value:(object)objTeluguBadiOrders.PaymentMethodId)),
                        new SqlParameter("@PaymentBy",(objTeluguBadiOrders.PaymentBy == null ?DBNull.Value:(object)objTeluguBadiOrders.PaymentBy)),
                        new SqlParameter("@OrderDate",(objTeluguBadiOrders.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objTeluguBadiOrders.OrderDate)),
                        new SqlParameter("@ExpiryDate",(objTeluguBadiOrders.ExpiryDate == DateTime.MinValue  ?DBNull.Value:(object)objTeluguBadiOrders.ExpiryDate)),
                        new SqlParameter("@UpdatedBy",objTeluguBadiOrders.UpdatedBy),
                        new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                        new SqlParameter("@QStatus",0)
                    };
                _sqlP[14].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiOrdersInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[14].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public DataTable GetTeluguBadiOrdersById(Int64 OrderId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@OrderId",OrderId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("TeluguBadiOrdersGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteTeluguBadiOrders(Int64 OrderId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@OrderId",OrderId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiOrdersDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataSet AddTeluguBadiRequirement(ref int status)
        {
            DataSet ds = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                ds = _dbAccess.GetDataSet("AddTeluguBadiRequirement", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataTable GetTeluguBadiOrdersList(Int64 TRegistrationId,ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TRegistrationId",TRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("TeluguBadiOrdersGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }
}
