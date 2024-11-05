using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace WATS.DAL
{
  public  class TeluguBadiRegistrations
    {

        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public DataTable GetTeluguBadiRegistrationsList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("TeluguBadiRegistrationsGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 InsertTeluguBadiRegistrations(Entities.TeluguBadiRegistrations objTeluguBadiRegistrations)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@TRegistrationId",objTeluguBadiRegistrations.TRegistrationId),
                    new SqlParameter("@MemberId",(objTeluguBadiRegistrations.MemberId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.MemberId)),
                    new SqlParameter("@FatherFirstName",(objTeluguBadiRegistrations.FatherFirstName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherFirstName)),
                    new SqlParameter("@FatherLastName",(objTeluguBadiRegistrations.FatherLastName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherLastName)),
                    new SqlParameter("@FatherEmail",(objTeluguBadiRegistrations.FatherEmail == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherEmail)),
                    new SqlParameter("@FatherPhoneNo",(objTeluguBadiRegistrations.FatherPhoneNo == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherPhoneNo)),
                    new SqlParameter("@MotherFirstName",(objTeluguBadiRegistrations.MotherFirstName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherFirstName)),
                    new SqlParameter("@MotherLastName",(objTeluguBadiRegistrations.MotherLastName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherLastName)),
                    new SqlParameter("@MotherEmail",(objTeluguBadiRegistrations.MotherEmail == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherEmail)),
                    new SqlParameter("@MotherPhoneNo",(objTeluguBadiRegistrations.MotherPhoneNo == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherPhoneNo)),
                    new SqlParameter("@Address",(objTeluguBadiRegistrations.Address == null ?DBNull.Value:(object)objTeluguBadiRegistrations.Address)),
                    new SqlParameter("@City",(objTeluguBadiRegistrations.City == null ?DBNull.Value:(object)objTeluguBadiRegistrations.City)),
                    new SqlParameter("@State",(objTeluguBadiRegistrations.State == null ?DBNull.Value:(object)objTeluguBadiRegistrations.State)),
                    new SqlParameter("@ZipCode",(objTeluguBadiRegistrations.ZipCode == null ?DBNull.Value:(object)objTeluguBadiRegistrations.ZipCode)),
                    new SqlParameter("@TeluguBadiCenterName",(objTeluguBadiRegistrations.TeluguBadiCenterName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.TeluguBadiCenterName)),
                    new SqlParameter("@VolunteerFor",(objTeluguBadiRegistrations.VolunteerFor == null ?DBNull.Value:(object)objTeluguBadiRegistrations.VolunteerFor)),
                    new SqlParameter("@IsApproved",objTeluguBadiRegistrations.IsApproved),
                    new SqlParameter("@InsertedBy",objTeluguBadiRegistrations.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objTeluguBadiRegistrations.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0),
                    new SqlParameter("@TeluguBadiTypeId",(objTeluguBadiRegistrations.TeluguBadiTypeId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.TeluguBadiTypeId)),
                    new SqlParameter("@Amount",(objTeluguBadiRegistrations.Amount == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.Amount)),
                    new SqlParameter("@PaymentStatusId",(objTeluguBadiRegistrations.PaymentStatusId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objTeluguBadiRegistrations.PaymentMethodId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.PaymentMethodId)),
                    new SqlParameter("@OrderDate",(objTeluguBadiRegistrations.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objTeluguBadiRegistrations.OrderDate)),
                    new SqlParameter("@ExpiryDate",(objTeluguBadiRegistrations.ExpiryDate == DateTime.MinValue ?DBNull.Value:(object)objTeluguBadiRegistrations.ExpiryDate)),


                    };

                _sqlP[21].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiRegistrationsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[21].Value);


            }


            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 FEInsertTeluguBadiRegistrations(Entities.TeluguBadiRegistrations objTeluguBadiRegistrations, ref Int64 TRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@TRegistrationId",objTeluguBadiRegistrations.TRegistrationId),
                    new SqlParameter("@MemberId",(objTeluguBadiRegistrations.MemberId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.MemberId)),
                    new SqlParameter("@FatherFirstName",(objTeluguBadiRegistrations.FatherFirstName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherFirstName)),
                    new SqlParameter("@FatherLastName",(objTeluguBadiRegistrations.FatherLastName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherLastName)),
                    new SqlParameter("@FatherEmail",(objTeluguBadiRegistrations.FatherEmail == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherEmail)),
                    new SqlParameter("@FatherPhoneNo",(objTeluguBadiRegistrations.FatherPhoneNo == null ?DBNull.Value:(object)objTeluguBadiRegistrations.FatherPhoneNo)),
                    new SqlParameter("@MotherFirstName",(objTeluguBadiRegistrations.MotherFirstName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherFirstName)),
                    new SqlParameter("@MotherLastName",(objTeluguBadiRegistrations.MotherLastName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherLastName)),
                    new SqlParameter("@MotherEmail",(objTeluguBadiRegistrations.MotherEmail == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherEmail)),
                    new SqlParameter("@MotherPhoneNo",(objTeluguBadiRegistrations.MotherPhoneNo == null ?DBNull.Value:(object)objTeluguBadiRegistrations.MotherPhoneNo)),
                    new SqlParameter("@Address",(objTeluguBadiRegistrations.Address == null ?DBNull.Value:(object)objTeluguBadiRegistrations.Address)),
                    new SqlParameter("@City",(objTeluguBadiRegistrations.City == null ?DBNull.Value:(object)objTeluguBadiRegistrations.City)),
                    new SqlParameter("@State",(objTeluguBadiRegistrations.State == null ?DBNull.Value:(object)objTeluguBadiRegistrations.State)),
                    new SqlParameter("@ZipCode",(objTeluguBadiRegistrations.ZipCode == null ?DBNull.Value:(object)objTeluguBadiRegistrations.ZipCode)),
                    new SqlParameter("@TeluguBadiCenterName",(objTeluguBadiRegistrations.TeluguBadiCenterName == null ?DBNull.Value:(object)objTeluguBadiRegistrations.TeluguBadiCenterName)),
                    new SqlParameter("@VolunteerFor",(objTeluguBadiRegistrations.VolunteerFor == null ?DBNull.Value:(object)objTeluguBadiRegistrations.VolunteerFor)),
                    new SqlParameter("@IsApproved",objTeluguBadiRegistrations.IsApproved),
                    new SqlParameter("@InsertedBy",objTeluguBadiRegistrations.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objTeluguBadiRegistrations.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0),
                    new SqlParameter("@TeluguBadiTypeId",(objTeluguBadiRegistrations.TeluguBadiTypeId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.TeluguBadiTypeId)),
                    new SqlParameter("@Amount",(objTeluguBadiRegistrations.Amount == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.Amount)),
                    new SqlParameter("@PaymentStatusId",(objTeluguBadiRegistrations.PaymentStatusId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objTeluguBadiRegistrations.PaymentMethodId == 0 ?DBNull.Value:(object)objTeluguBadiRegistrations.PaymentMethodId)),
                    new SqlParameter("@OrderDate",(objTeluguBadiRegistrations.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objTeluguBadiRegistrations.OrderDate)),
                    new SqlParameter("@ExpiryDate",(objTeluguBadiRegistrations.ExpiryDate == DateTime.MinValue ?DBNull.Value:(object)objTeluguBadiRegistrations.ExpiryDate)),

                    };

                _sqlP[0].Direction = _sqlP[21].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("FETeluguBadiRegistrationsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[21].Value);

                TRegistrationId = Convert.ToInt64(_sqlP[0].Value);
            }


            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetTeluguBadiRegistrationsListByVariable(string Search, Int64 TeluguBadiTypeId, Int64 PaymentStatusId, string StartDate, string EndDate, string ExpiryDate, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TeluguBadiTypeId",TeluguBadiTypeId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@ExpiryDate",ExpiryDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[9].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("TeluguBadiRegistrationsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[9].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetTeluguBadiRegistrationsById(Int64 TRegistrationId, ref int status)
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
                dt = _dbAccess.GetDataTable("TeluguBadiRegistrationsGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteTeluguBadiRegistrations(Int64 TRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TRegistrationId",TRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiRegistrationsDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateTeluguBadiRegistrationsStatus(Int64 TRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TRegistrationId",TRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiRegistrationsUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateTeluguBadiRegistrationsDisplayOrder(int DisplayOrder, Int64 TRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TRegistrationId",TRegistrationId),
                    new SqlParameter("@DisplayOrder",DisplayOrder),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiRegistrationsUpdateOrderNo", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }



        public Int64 InsertTeluguBadiStudents(Entities.TeluguBadiStudents objTeluguBadiStudents)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@TStudentId",objTeluguBadiStudents.TStudentId),
                    new SqlParameter("@TRegistrationId",(objTeluguBadiStudents.TRegistrationId == 0 ?DBNull.Value:(object)objTeluguBadiStudents.TRegistrationId)),
                    new SqlParameter("@FirstName",(objTeluguBadiStudents.FirstName == null ?DBNull.Value:(object)objTeluguBadiStudents.FirstName)),
                    new SqlParameter("@LastName",(objTeluguBadiStudents.LastName == null ?DBNull.Value:(object)objTeluguBadiStudents.LastName)),
                    new SqlParameter("@Age",(objTeluguBadiStudents.Age == 0 ?DBNull.Value:(object)objTeluguBadiStudents.Age)),
                    new SqlParameter("@LevelOfferings",(objTeluguBadiStudents.LevelOfferings == null ?DBNull.Value:(object)objTeluguBadiStudents.LevelOfferings)),
                    new SqlParameter("@Comments",(objTeluguBadiStudents.Comments == null ?DBNull.Value:(object)objTeluguBadiStudents.Comments)),
                    new SqlParameter("@Field1",(objTeluguBadiStudents.Field1 == null ?DBNull.Value:(object)objTeluguBadiStudents.Field1)),
                    new SqlParameter("@InsertedBy",objTeluguBadiStudents.InsertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objTeluguBadiStudents.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[12].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiStudentsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[12].Value);


            }


            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 DeleteTeluguBadiStudents(Int64 TStudentId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TStudentId",TStudentId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("TeluguBadiStudentsDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }
        public DataSet GetTBudiRegistrationsFullDetailsById(Int64 TRegistrationId, ref int status)
        {
            DataSet ds0 = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TRegistrationId",TRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataSet("TeluguBadiRegistrationsGetFullDetailsById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        public DataSet GetTBudiRegistrationsFullDetailsByEmail(string Email, ref int status)
        {
            DataSet ds0 = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@Email",Email),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataSet("TeluguBadiRegistrationsGetFullDetailsByEmail", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }


        public DataTable ExportTeluguBadiRegistrationsList(string Search, Int64 TeluguBadiTypeId, Int64 PaymentStatusId, string StartDate, string EndDate, string ExpiryDate, string Sort)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@TeluguBadiTypeId",TeluguBadiTypeId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@StartDate",StartDate),
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@ExpiryDate",ExpiryDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportTeluguBadiRegistrationsGetList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


    }
}
