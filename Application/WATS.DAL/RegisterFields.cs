using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class RegisterFields
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        #region Method

        public Int64 DeleteRegisterFields(Int64 RegisterFieldsId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@RegisterFieldsId",RegisterFieldsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("RegisterFieldsDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 DeleteRegisterOptions(Int64 RegisterOptionsId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@RegisterOptionsId",RegisterOptionsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("RegisterOptionsDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 InsertRegisterFields(Entities.RegisterFields objRegisterFields)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@RegisterFieldId",objRegisterFields.RegisterFieldId),
                    new SqlParameter("@EventId",objRegisterFields.EventId),
                    new SqlParameter("@Name",objRegisterFields.Name),
                    new SqlParameter("@HelpText",(objRegisterFields.HelpText == null?DBNull.Value:(object)objRegisterFields.HelpText)),
                    new SqlParameter("@QuestionType",objRegisterFields.QuestionType),
                    new SqlParameter("@DisplayOrder",objRegisterFields.DisplayOrder),
                    new SqlParameter("@IsRequired",objRegisterFields.IsRequired),
                    new SqlParameter("@ValidationType",(objRegisterFields.ValidationType == null?DBNull.Value:(object)objRegisterFields.ValidationType)),
                    new SqlParameter("@Options",(objRegisterFields.Options == null?DBNull.Value:(object)objRegisterFields.Options)),
                    new SqlParameter("@UpdatedBy",objRegisterFields.UpdatedBy),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[10].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("RegisterFieldsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[10].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        #endregion

        #region Entity

        public DataSet GetRegisterFieldsById(Int64 RegisterFieldsId, ref int status)
        {
            DataSet ds = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@RegisterFieldId",RegisterFieldsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds = _dbAccess.GetDataSet("RegisterFieldsGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public DataSet GetRegisterFieldsList(Int64 EventId, ref int status)
        {
            DataSet ds = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@Qstatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds = _dbAccess.GetDataSet("RegisterFieldsGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        #endregion
    }
}
