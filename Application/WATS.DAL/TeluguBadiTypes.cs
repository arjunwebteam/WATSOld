using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WATS.DAL
{
   public class TeluguBadiTypes
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public DataTable GetTeluguBadiTypesList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("TeluguBadiTypesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 InsertTeluguBadiTypes(Entities.TeluguBadiTypes objTeluguBadiTypes)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@TeluguBadiTypeId",objTeluguBadiTypes.TeluguBadiTypeId),
                    new SqlParameter("@Type",objTeluguBadiTypes.Type),
                    new SqlParameter("@Price",(objTeluguBadiTypes.Price == 0 ?DBNull.Value:(object)objTeluguBadiTypes.Price)),
                    new SqlParameter("@Year",(objTeluguBadiTypes.Year == 0 ?DBNull.Value:(object)objTeluguBadiTypes.Year)),
                    new SqlParameter("@ExpiryDate",(objTeluguBadiTypes.ExpiryDate  == DateTime.MinValue?DBNull.Value: (object)objTeluguBadiTypes.ExpiryDate)),
                    new SqlParameter("@IsActive",objTeluguBadiTypes.IsActive),
                    new SqlParameter("@OrderNo",objTeluguBadiTypes.OrderNo),
                    new SqlParameter("@InsertedBy",objTeluguBadiTypes.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objTeluguBadiTypes.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };
               
                _sqlP[11].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiTypesInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[11].Value);


            }


            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetTeluguBadiTypesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("TeluguBadiTypesGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetTeluguBadiTypesById(Int64 TeluguBadiTypeId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TeluguBadiTypeId",TeluguBadiTypeId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("TeluguBadiTypesGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteTeluguBadiTypes(Int64 TeluguBadiTypeId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TeluguBadiTypeId",TeluguBadiTypeId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiTypesDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateTeluguBadiTypesStatus(Int64 TeluguBadiTypeId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TeluguBadiTypeId",TeluguBadiTypeId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiTypesUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateTeluguBadiTypesDisplayOrder(int DisplayOrder, Int64 TeluguBadiTypeId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TeluguBadiTypeId",TeluguBadiTypeId),
                    new SqlParameter("@DisplayOrder",DisplayOrder),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiTypesUpdateOrderNo", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

    }
}
