﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WATS.DAL;


namespace WATS.DAL
{
   public class CommitteeCategories
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public DataTable GetCommitteeCategoriesList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("CommitteeCategoriesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 InsertCommitteeCategories(Entities.CommitteeCategories objCommitteeCategories)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@CommitteeCategoryId",objCommitteeCategories.CommitteeCategoryId),
                    new SqlParameter("@CategoryName",objCommitteeCategories.CategoryName),
                    new SqlParameter("@Type",objCommitteeCategories.Type),
                    new SqlParameter("@DisplayOrder",objCommitteeCategories.DisplayOrder),
                    new SqlParameter("@IsActive",objCommitteeCategories.IsActive),
                    new SqlParameter("@UpdatedBy",objCommitteeCategories.UpdatedBy),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteeCategoriesInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetCommitteeCategoriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("CommitteeCategoriesGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetCommitteeCategoryById(Int64 CommitteeCategoryId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeCategoryId",CommitteeCategoryId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("CommitteeCategoriesGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteCommitteeCategory(Int64 CommitteeCategoryId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeCategoryId",CommitteeCategoryId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteeCategoriesDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateCommitteeCategoryStatus(Int64 CommitteeCategoryId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeCategoryId",CommitteeCategoryId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteeCategoriesUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateCommitteeCategoriesDisplayOrder(int DisplayOrder, Int64 CommitteeCategoryId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeCategoryId",CommitteeCategoryId),
                    new SqlParameter("@DisplayOrder",DisplayOrder),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteeCategoriesUpdateDisplayOrder", ref _sqlP);
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
