using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.DAL
{
    public class SponsorRegistrationCategories
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        #region Method

        public Int64 DeleteSponsorRegistrationCategory(Int64 SponsorRegistrationCategoryId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistrationCategoryId",SponsorRegistrationCategoryId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationCategoriesDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 InsertSponsorRegistrationCategory(Entities.SponsorRegistrationCategories objSponsorRegistrationCategory)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@SponsorRegistrationCategoryId",(objSponsorRegistrationCategory.SponsorRegistrationCategoryId!= 0?(object)objSponsorRegistrationCategory.SponsorRegistrationCategoryId:DBNull.Value.ToString())),
                    new SqlParameter("@EventId",(objSponsorRegistrationCategory.EventId!= 0?(object)objSponsorRegistrationCategory.EventId:DBNull.Value.ToString())),
                    new SqlParameter("@CategoryName",objSponsorRegistrationCategory.CategoryName),
                    new SqlParameter("@Description",objSponsorRegistrationCategory.Description),
                    new SqlParameter("@OrderNo",(objSponsorRegistrationCategory.OrderNo == 0 ?DBNull.Value:(object)objSponsorRegistrationCategory.OrderNo)),
                    new SqlParameter("@Amount",(objSponsorRegistrationCategory.Amount != 0?(object)objSponsorRegistrationCategory.Amount:DBNull.Value)),
                    new SqlParameter("@IsActive",objSponsorRegistrationCategory.IsActive),                 
                    
                    new SqlParameter("@QStatus",0),
                    new SqlParameter("@BannerDisplay",(objSponsorRegistrationCategory.BannerDisplay!= null?(object)objSponsorRegistrationCategory.BannerDisplay:DBNull.Value.ToString())),
                    new SqlParameter("@DinnerTickets",(objSponsorRegistrationCategory.DinnerTickets!= null?(object)objSponsorRegistrationCategory.DinnerTickets:DBNull.Value.ToString()))
                    };
                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationCategoriesInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateSponsorRegistrationCategoryStatus(Int64 SponsorRegistrationCategoryId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistrationCategoryId",SponsorRegistrationCategoryId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationCategoriesUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        #endregion

        #region Admin Section

        public DataTable GetSponsorRegistrationCategoryById(Int64 SponsorRegistrationCategoryId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistrationCategoryId",SponsorRegistrationCategoryId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("SponsorRegistrationCategoriesGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetSponsorRegistrationCategoriesListByVariable(Int64 EventId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",0)
                };
                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("SponsorRegistrationCategoriesGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetSponsorRegistrationCategoriesList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("SponsorRegistrationCategoriesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable FEGetSponsorRegistrationCategoriesList(Int64 EventId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0),
                    new SqlParameter("@EventId",EventId)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("FESponsorRegistrationCategoriesGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 UpdateSponsorRegistrationCategoryDisplayOrder(int OrderNo, Int64 SponsorRegistrationCategoryId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@SponsorRegistration",SponsorRegistrationCategoryId),
                    new SqlParameter("@OrderNo",OrderNo),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("SponsorRegistrationCategoriesUpdateDisplayOrder", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);
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
