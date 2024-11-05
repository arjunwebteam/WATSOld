using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class Volunteers
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        #region Admin
        
        public Int64 InsertVolunteers(Entities.Volunteers objVolunteers)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@VolunteerId",objVolunteers.VolunteerId),
                    new SqlParameter("@VolunteerCategoryId",(objVolunteers.VolunteerCategoryId==0?(object)DBNull.Value:objVolunteers.VolunteerCategoryId)),
                    new SqlParameter("@EventId",(objVolunteers.EventId==0?(object)DBNull.Value:objVolunteers.EventId)),
                    new SqlParameter("@TRegistrationId",(objVolunteers.TRegistrationId==0?(object)DBNull.Value:objVolunteers.TRegistrationId)),
                    new SqlParameter("@FirstName",objVolunteers.FirstName),
                    new SqlParameter("@LastName",objVolunteers.LastName),
                    new SqlParameter("@Email",objVolunteers.Email),
                    new SqlParameter("@PhoneNo",(objVolunteers.PhoneNo == null ?DBNull.Value:(object)objVolunteers.PhoneNo)),
                    new SqlParameter("@Address",(objVolunteers.Address == null ?DBNull.Value:(object)objVolunteers.Address)),
                    new SqlParameter("@Comment",(objVolunteers.Comment == null ?DBNull.Value:(object)objVolunteers.Comment)),
                    new SqlParameter("@Profile",(objVolunteers.Profile == null ?DBNull.Value:(object)objVolunteers.Profile)),
                    new SqlParameter("@Password",(objVolunteers.Password == null ?DBNull.Value:(object)objVolunteers.Password)),
                     new SqlParameter("@CompanyName",(objVolunteers.CompanyName == null ?DBNull.Value:(object)objVolunteers.CompanyName)),
                     new SqlParameter("@Designation",(objVolunteers.Designation == null ?DBNull.Value:(object)objVolunteers.Designation)),
                     new SqlParameter("@HoursSpent",(objVolunteers.HoursSpent == null ?DBNull.Value:(object)objVolunteers.HoursSpent)),
                     new SqlParameter("@SchoolName",(objVolunteers.SchoolName == null ?DBNull.Value:(object)objVolunteers.SchoolName)),
                     new SqlParameter("@Gradeinschool",(objVolunteers.Gradeinschool == null ?DBNull.Value:(object)objVolunteers.Gradeinschool)),
                     new SqlParameter("@Age",(objVolunteers.Age == null ?DBNull.Value:(object)objVolunteers.Age)),
                     new SqlParameter("@Notes",(objVolunteers.Notes == null ?DBNull.Value:(object)objVolunteers.Notes)),
                     new SqlParameter("@Field1",(objVolunteers.Field1 == null ?DBNull.Value:(object)objVolunteers.Field1)),
                     new SqlParameter("@Field2",(objVolunteers.Field2 == null ?DBNull.Value:(object)objVolunteers.Field2)),
                     new SqlParameter("@Field3",(objVolunteers.Field3 == null ?DBNull.Value:(object)objVolunteers.Field3)),
                     new SqlParameter("@Field4",(objVolunteers.Field4 == null ?DBNull.Value:(object)objVolunteers.Field4)),
                    new SqlParameter("@IsActive",objVolunteers.IsActive),
                    new SqlParameter("@InsertedBy",objVolunteers.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objVolunteers.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[28].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("VolunteersInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[28].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetVolunteersListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("VolunteersGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetVolunteerById(Int64 VolunteerId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@VolunteerId",VolunteerId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("VolunteersGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteVolunteer(Int64 VolunteerId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@VolunteerId",VolunteerId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("VolunteersDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateVolunteerstatus(Int64 VolunteerId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@VolunteerId",VolunteerId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("VolunteersUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }
        
        public DataTable VolunteerValidationByEmail(string Email, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@Email",Email),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("VolunteersValidationByEmail", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        
        #endregion

        #region Front-end

        public DataTable FEGetVolunteersList(string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("FEGetVolunteersList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 FEVolunteerInsert(Entities.Volunteers objVolunteers)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@VolunteerId",objVolunteers.VolunteerId),
                    new SqlParameter("@VolunteerCategoryId",(objVolunteers.VolunteerCategoryId==0?(object)DBNull.Value:objVolunteers.VolunteerCategoryId)),
                    new SqlParameter("@EventId",(objVolunteers.EventId==0?(object)DBNull.Value:objVolunteers.EventId)),
                    new SqlParameter("@TRegistrationId",(objVolunteers.TRegistrationId==0?(object)DBNull.Value:objVolunteers.TRegistrationId)),
                    new SqlParameter("@FirstName",objVolunteers.FirstName),
                    new SqlParameter("@LastName",objVolunteers.LastName),
                    new SqlParameter("@Email",objVolunteers.Email),
                    new SqlParameter("@PhoneNo",(objVolunteers.PhoneNo == null ?DBNull.Value:(object)objVolunteers.PhoneNo)),
                    new SqlParameter("@Address",(objVolunteers.Address == null ?DBNull.Value:(object)objVolunteers.Address)),
                    new SqlParameter("@Comment",(objVolunteers.Comment == null ?DBNull.Value:(object)objVolunteers.Comment)),
                    new SqlParameter("@Profile",(objVolunteers.Profile == null ?DBNull.Value:(object)objVolunteers.Profile)),
                    new SqlParameter("@Password",(objVolunteers.Password == null ?DBNull.Value:(object)objVolunteers.Password)),
                     new SqlParameter("@CompanyName",(objVolunteers.CompanyName == null ?DBNull.Value:(object)objVolunteers.CompanyName)),
                     new SqlParameter("@Designation",(objVolunteers.Designation == null ?DBNull.Value:(object)objVolunteers.Designation)),
                     new SqlParameter("@HoursSpent",(objVolunteers.HoursSpent == null ?DBNull.Value:(object)objVolunteers.HoursSpent)),
                     new SqlParameter("@SchoolName",(objVolunteers.SchoolName == null ?DBNull.Value:(object)objVolunteers.SchoolName)),
                     new SqlParameter("@Gradeinschool",(objVolunteers.Gradeinschool == null ?DBNull.Value:(object)objVolunteers.Gradeinschool)),
                     new SqlParameter("@Age",(objVolunteers.Age == null ?DBNull.Value:(object)objVolunteers.Age)),
                     new SqlParameter("@Notes",(objVolunteers.Notes == null ?DBNull.Value:(object)objVolunteers.Notes)),
                     new SqlParameter("@Field1",(objVolunteers.Field1 == null ?DBNull.Value:(object)objVolunteers.Field1)),
                     new SqlParameter("@Field2",(objVolunteers.Field2 == null ?DBNull.Value:(object)objVolunteers.Field2)),
                     new SqlParameter("@Field3",(objVolunteers.Field3 == null ?DBNull.Value:(object)objVolunteers.Field3)),
                     new SqlParameter("@Field4",(objVolunteers.Field4 == null ?DBNull.Value:(object)objVolunteers.Field4)),
                    new SqlParameter("@IsActive",objVolunteers.IsActive),
                    new SqlParameter("@InsertedBy",objVolunteers.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objVolunteers.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[28].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("FEVolunteerInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[28].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable ExportToVolunteers(Int64 VolunteerCategoryId,Int64 EventId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@VolunteerCategoryId",VolunteerCategoryId),
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[4].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportVolunteersGetList", ref _sqlP);
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
