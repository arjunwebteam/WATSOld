﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WATS.DAL
{
  public class MailTemplates
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public DataTable GetMailTemplatesList(string MailType, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MailType",MailType),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("MailTemplatesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 InsertMailTemplates(Entities.MailTemplates objMailTemplates)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MailTemplateId",objMailTemplates.MailTemplateId),
                    new SqlParameter("@Heading",objMailTemplates.Heading),
                    new SqlParameter("@Subject",objMailTemplates.Subject),
                    new SqlParameter("@Description",objMailTemplates.Description),
                    new SqlParameter("@MailType",(objMailTemplates.MailType == null ?DBNull.Value:(object)objMailTemplates.MailType.Trim())),
                    new SqlParameter("@UpdatedBy",objMailTemplates.UpdatedBy),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MailTemplatesInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetMailTemplatesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("MailTemplatesGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetMailTemplateById(string TemplateName, Int64 MailTemplateId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@TemplateName",TemplateName),
                    new SqlParameter("@MailTemplateId",MailTemplateId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("MailTemplatesGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteMailTemplate(Int64 MailTemplateId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MailTemplateId",MailTemplateId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MailTemplatesDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }
    }
}
