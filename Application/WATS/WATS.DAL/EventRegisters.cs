using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class EventRegisters
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        #region Methods

        public Int64 InsertEventReigisters(Entities.EventRegisters objEventRegisters, ref Int64 EventRegisterId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@UserIdentity",objEventRegisters.UserIdentity),
                    new SqlParameter("@EventId",objEventRegisters.EventId),
                    new SqlParameter("@EventRegisterId",EventRegisterId),                    
                    new SqlParameter("@UpdatedBy",objEventRegisters.UpdatedBy),                    
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[2].Direction = _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("EventRegistersInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[4].Value);

                EventRegisterId = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 InsertEventReigisterAnswers(Entities.RegisterAnswer objRegisterAnswer)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@RegisterFieldId",objRegisterAnswer.RegisterFieldId),
                    new SqlParameter("@EventRegisterId",objRegisterAnswer.EventRegisterId),                    
                    new SqlParameter("@Answer",objRegisterAnswer.Answer),                    
                    new SqlParameter("@UpdatedBy",objRegisterAnswer.UpdatedBy),                    
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("EventRegisterAnswersInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 BulkInsertEventReigisterAnswers(string AnswersXml)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegisterAnswersXML",AnswersXml),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("EventRegisterAnswersBulkInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 BulkInsertEventMembers(string MembersXml)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MembersXml",MembersXml),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("EventMembersInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
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
