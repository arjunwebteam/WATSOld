﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WATS.DAL
{
  public  class Committees
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        #region Admin

        public DataTable GetCommitteesList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("CommitteesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 InsertCommittees(Entities.Committees objCommittees, ref string ImageUrl)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@CommitteeId",objCommittees.CommitteeId),
                    new SqlParameter("@Name",objCommittees.Name),
                    new SqlParameter("@PhoneNo",(objCommittees.PhoneNo == null ?DBNull.Value:(object)objCommittees.PhoneNo)),
                    new SqlParameter("@Address",(objCommittees.Address == null ?DBNull.Value:(object)objCommittees.Address)),
                    new SqlParameter("@City",(objCommittees.City == null ?DBNull.Value:(object)objCommittees.City)),
                    new SqlParameter("@State",(objCommittees.State == null ?DBNull.Value:(object)objCommittees.State)),
                    new SqlParameter("@Email",(objCommittees.Email == null ?DBNull.Value:(object)objCommittees.Email)),
                    new SqlParameter("@ImageUrl",ImageUrl),
                    new SqlParameter("@DisplayOrder",(objCommittees.DisplayOrder == 0 ?DBNull.Value:(object)objCommittees.DisplayOrder)),
                    new SqlParameter("@IsActive",(objCommittees.IsActive == false ?DBNull.Value:(object)objCommittees.IsActive)),
                    new SqlParameter("@Description",(objCommittees.Description == null ?DBNull.Value:(object)objCommittees.Description)),
                    new SqlParameter("@UpdatedBy",objCommittees.UpdatedBy),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[7].SqlDbType = SqlDbType.NVarChar;
                _sqlP[7].Size = 512;
                _sqlP[7].Direction = System.Data.ParameterDirection.InputOutput;
                
                _sqlP[13].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteesInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[13].Value);

                ImageUrl = _sqlP[7].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetCommitteesListByVariable(Int64 CommitteeCategoryId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@CommitteeCategoryId",CommitteeCategoryId),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),                    
                    new SqlParameter("@Total",Total)
                };

                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("CommitteesGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetCommitteeById(Int64 CommitteeId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeId",CommitteeId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("CommitteesGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteCommittee(Int64 CommitteeId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeId",CommitteeId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteesDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateCommitteeStatus(Int64 CommitteeId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeId",CommitteeId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteesUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetCommitteeMembersListById(Int64 CommitteeCategoryId, ref int status)
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
                dt = _dbAccess.GetDataTable("CommitteesGetListById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 UpdateCommitteesDisplayOrder(int DisplayOrder, Int64 CommitteeId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CommitteeId",CommitteeId),
                    new SqlParameter("@DisplayOrder",DisplayOrder),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("CommitteesUpdateDisplayOrder", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        #endregion

        #region Front End

        public DataSet FECommitteesGetList(string Type, ref int status)
        {
            DataSet dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@Type",Type),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataSet("FECommitteesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataSet FECommitteesGetListAll(ref int status)
        {
            DataSet dt = null;
            try
            {
                _sqlP = new[] 
                { 
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataSet("FECommitteesGetListAll", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
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
