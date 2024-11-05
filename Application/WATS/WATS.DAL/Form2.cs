using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class Form2
    {
        DBAccess _dbAccess = new DBAccess();

        SqlParameter[] _sqlP;

        public Int64 InsertForm2(WATS.Entities.Form2 objForm2, ref Int64 CulturalRegistrationId)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@CulturalRegistrationId",objForm2.CulturalRegistrationId),
                    new SqlParameter("@EventId",(objForm2.EventId == 0 ?DBNull.Value:(object)objForm2.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm2.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm2.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm2.MemberId == 0 ?DBNull.Value:(object)objForm2.MemberId)),
                    new SqlParameter("@ProgramType",(objForm2.ProgramType== null ?DBNull.Value:(object)objForm2.ProgramType)),
                    new SqlParameter("@ProgramName",(objForm2.ProgramName== null ?DBNull.Value:(object)objForm2.ProgramName)),
                    new SqlParameter("@Description",(objForm2.Description== null ?DBNull.Value:(object)objForm2.Description)),
                    new SqlParameter("@MediaTrack",(objForm2.MediaTrack== null ?DBNull.Value:(object)objForm2.MediaTrack)),
                    new SqlParameter("@NumberOfParticipants",(objForm2.NumberOfParticipants== null ?DBNull.Value:(object)objForm2.NumberOfParticipants)),
                    new SqlParameter("@Age",(objForm2.Age== null ?DBNull.Value:(object)objForm2.Age)),
                    new SqlParameter("@ParticipantsFullNames",(objForm2.ParticipantsFullNames== null ?DBNull.Value:(object)objForm2.ParticipantsFullNames)),
                    new SqlParameter("@ProgramDuration",(objForm2.ProgramDuration== null ?DBNull.Value:(object)objForm2.ProgramDuration)),
                    new SqlParameter("@ChoreographerName",(objForm2.ChoreographerName== null ?DBNull.Value:(object)objForm2.ChoreographerName)),
                    new SqlParameter("@ContactPhoneNumber",(objForm2.ContactPhoneNumber== null ?DBNull.Value:(object)objForm2.ContactPhoneNumber)),
                    new SqlParameter("@ContactEmail",(objForm2.ContactEmail== null ?DBNull.Value:(object)objForm2.ContactEmail)),
                    new SqlParameter("@SchoolName",(objForm2.SchoolName== null ?DBNull.Value:(object)objForm2.SchoolName)),
                    new SqlParameter("@TermsandConditions",(objForm2.TermsandConditions== null ?DBNull.Value:(object)objForm2.TermsandConditions)),
                    new SqlParameter("@IsApproved",objForm2.IsApproved),
                    new SqlParameter("@ApprovedDate",(objForm2.ApprovedDate == DateTime.MinValue ?DBNull.Value:(object)objForm2.ApprovedDate)),
                    new SqlParameter("@PaymentStatusId",(objForm2.PaymentStatusId == 0 ?DBNull.Value:(object)objForm2.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm2.PaymentMethodId == 0 ?DBNull.Value:(object)objForm2.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",(objForm2.PaymentDate == DateTime.MinValue ?DBNull.Value:(object)objForm2.PaymentDate)),
                    new SqlParameter("@TransactionId",(objForm2.TransactionId== null ?DBNull.Value:(object)objForm2.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm2.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm2.AmountPaid)),   
                    new SqlParameter("@BankName",(objForm2.BankName== null ?DBNull.Value:(object)objForm2.BankName)),
                    new SqlParameter("@ChequeNo",(objForm2.ChequeNo== null ?DBNull.Value:(object)objForm2.ChequeNo)),
                    new SqlParameter("@ChequeDate",(objForm2.ChequeDate == DateTime.MinValue ?DBNull.Value:(object)objForm2.ChequeDate)),
                    new SqlParameter("@AdminComments",(objForm2.AdminComments== null ?DBNull.Value:(object)objForm2.AdminComments)),
                    new SqlParameter("@Field1",(objForm2.Field1== null ?DBNull.Value:(object)objForm2.Field1)),
                    new SqlParameter("@Field2",(objForm2.Field2== null ?DBNull.Value:(object)objForm2.Field2)),
                    new SqlParameter("@Field3",(objForm2.Field3== null ?DBNull.Value:(object)objForm2.Field3)),
                    new SqlParameter("@InstertedBy",objForm2.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm2.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm2.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm2.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[0].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[35].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form2Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[35].Value);

                CulturalRegistrationId = Convert.ToInt64(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetForm2ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 PaymentMethodId, Int64 PaymentStatusId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@RegistrationCategoryId",RegistrationCategoryId),
                    new SqlParameter("@PaymentMethodId",PaymentMethodId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[8].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form2GetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[8].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetForm2ById(Int64 CulturalRegistrationId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CulturalRegistrationId",CulturalRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form2GetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteForm2ById(Int64 CulturalRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CulturalRegistrationId",CulturalRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form2Delete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm2StatusById(Int64 CulturalRegistrationId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@CulturalRegistrationId",CulturalRegistrationId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form2UpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetForm2List(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form2GetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable Form2ExportToExcel(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentMethodId, Int64 PaymentStatusId, string Search, string Sort, ref int Total)
        {
            DataTable dt = null;
          
            try
            {
                _sqlP = new[] 
                {
                     new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@RegistrationCategoryId",RegistrationCategoryId),
                    new SqlParameter("@PaymentMethodId",PaymentMethodId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@Total",Total)
                };
                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form2ExportToExcel", ref _sqlP);
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
