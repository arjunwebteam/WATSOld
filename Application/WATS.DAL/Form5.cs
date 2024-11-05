using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace WATS.DAL
{
   public class Form5
    {

        DBAccess _dbAccess = new DBAccess();

        SqlParameter[] _sqlP;

        public Int64 InsertForm5(WATS.Entities.Form5 objForm5)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm5Id",objForm5.EventRegistrationForm5Id),
                    new SqlParameter("@EventId",(objForm5.EventId == 0 ?DBNull.Value:(object)objForm5.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm5.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm5.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm5.MemberId == 0 ?DBNull.Value:(object)objForm5.MemberId)),
                    new SqlParameter("@TeamName",(objForm5.TeamName== null ?DBNull.Value:(object)objForm5.TeamName)),
                    new SqlParameter("@PContactName",(objForm5.PContactName== null ?DBNull.Value:(object)objForm5.PContactName)),
                    new SqlParameter("@PContactEmail",(objForm5.PContactEmail== null ?DBNull.Value:(object)objForm5.PContactEmail)),
                    new SqlParameter("@PContactPhoneNo",(objForm5.PContactPhoneNo== null ?DBNull.Value:(object)objForm5.PContactPhoneNo)),
                    new SqlParameter("@SContactName",(objForm5.SContactName== null ?DBNull.Value:(object)objForm5.SContactName)),
                    new SqlParameter("@SContactEmail",(objForm5.SContactEmail== null ?DBNull.Value:(object)objForm5.SContactEmail)),
                    new SqlParameter("@SContactPhoneNo",(objForm5.SContactPhoneNo== null ?DBNull.Value:(object)objForm5.SContactPhoneNo)),
                    new SqlParameter("@SportsType",(objForm5.SportsType== null ?DBNull.Value:(object)objForm5.SportsType)),
                    new SqlParameter("@SportsCategory",(objForm5.SportsCategory== null ?DBNull.Value:(object)objForm5.SportsCategory)),
                    new SqlParameter("@ParticipantsFullNames",(objForm5.ParticipantsFullNames== null ?DBNull.Value:(object)objForm5.ParticipantsFullNames)),
                    new SqlParameter("@TermsandConditions",objForm5.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm5.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm5.PaymentStatusId == 0?DBNull.Value:(object)objForm5.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm5.PaymentMethodId == 0?DBNull.Value:(object)objForm5.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm5.TransactionId== null ?DBNull.Value:(object)objForm5.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm5.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm5.AmountPaid)),  
                    new SqlParameter("@BankName",(objForm5.BankName== null ?DBNull.Value:(object)objForm5.BankName)),
                    new SqlParameter("@ChequeNo",(objForm5.ChequeNo== null ?DBNull.Value:(object)objForm5.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm5.AdminComments== null ?DBNull.Value:(object)objForm5.AdminComments)),
                    new SqlParameter("@Field1",(objForm5.Field1== null ?DBNull.Value:(object)objForm5.Field1)),
                    new SqlParameter("@Field2",(objForm5.Field2== null ?DBNull.Value:(object)objForm5.Field2)),
                    new SqlParameter("@Field3",(objForm5.Field3== null ?DBNull.Value:(object)objForm5.Field3)),
                    new SqlParameter("@InstertedBy",objForm5.InstertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objForm5.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[33].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form5Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[33].Value);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 FEInsertForm5(WATS.Entities.Form5 objForm5, ref Int64 EventRegistrationForm5Id)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm5Id",objForm5.EventRegistrationForm5Id),
                    new SqlParameter("@EventId",(objForm5.EventId == 0 ?DBNull.Value:(object)objForm5.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm5.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm5.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm5.MemberId == 0 ?DBNull.Value:(object)objForm5.MemberId)),
                    new SqlParameter("@TeamName",(objForm5.TeamName== null ?DBNull.Value:(object)objForm5.TeamName)),
                    new SqlParameter("@PContactName",(objForm5.PContactName== null ?DBNull.Value:(object)objForm5.PContactName)),
                    new SqlParameter("@PContactEmail",(objForm5.PContactEmail== null ?DBNull.Value:(object)objForm5.PContactEmail)),
                    new SqlParameter("@PContactPhoneNo",(objForm5.PContactPhoneNo== null ?DBNull.Value:(object)objForm5.PContactPhoneNo)),
                    new SqlParameter("@SContactName",(objForm5.SContactName== null ?DBNull.Value:(object)objForm5.SContactName)),
                    new SqlParameter("@SContactEmail",(objForm5.SContactEmail== null ?DBNull.Value:(object)objForm5.SContactEmail)),
                    new SqlParameter("@SContactPhoneNo",(objForm5.SContactPhoneNo== null ?DBNull.Value:(object)objForm5.SContactPhoneNo)),
                    new SqlParameter("@SportsType",(objForm5.SportsType== null ?DBNull.Value:(object)objForm5.SportsType)),
                    new SqlParameter("@SportsCategory",(objForm5.SportsCategory== null ?DBNull.Value:(object)objForm5.SportsCategory)),
                    new SqlParameter("@ParticipantsFullNames",(objForm5.ParticipantsFullNames== null ?DBNull.Value:(object)objForm5.ParticipantsFullNames)),
                    new SqlParameter("@TermsandConditions",objForm5.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm5.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm5.PaymentStatusId == 0?DBNull.Value:(object)objForm5.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm5.PaymentMethodId == 0?DBNull.Value:(object)objForm5.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm5.TransactionId== null ?DBNull.Value:(object)objForm5.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm5.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm5.AmountPaid)),
                    new SqlParameter("@BankName",(objForm5.BankName== null ?DBNull.Value:(object)objForm5.BankName)),
                    new SqlParameter("@ChequeNo",(objForm5.ChequeNo== null ?DBNull.Value:(object)objForm5.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm5.AdminComments== null ?DBNull.Value:(object)objForm5.AdminComments)),
                    new SqlParameter("@Field1",(objForm5.Field1== null ?DBNull.Value:(object)objForm5.Field1)),
                    new SqlParameter("@Field2",(objForm5.Field2== null ?DBNull.Value:(object)objForm5.Field2)),
                    new SqlParameter("@Field3",(objForm5.Field3== null ?DBNull.Value:(object)objForm5.Field3)),
                    new SqlParameter("@InstertedBy",objForm5.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm5.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm5.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm5.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[0].Direction =  _sqlP[33].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("FEForm5Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[33].Value);

                EventRegistrationForm5Id = Convert.ToInt64(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm5(WATS.Entities.Form5 objForm5)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm5Id",objForm5.EventRegistrationForm5Id),
                    new SqlParameter("@EventId",(objForm5.EventId == 0 ?DBNull.Value:(object)objForm5.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm5.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm5.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm5.MemberId == 0 ?DBNull.Value:(object)objForm5.MemberId)),
                    new SqlParameter("@TeamName",(objForm5.TeamName== null ?DBNull.Value:(object)objForm5.TeamName)),
                    new SqlParameter("@PContactName",(objForm5.PContactName== null ?DBNull.Value:(object)objForm5.PContactName)),
                    new SqlParameter("@PContactEmail",(objForm5.PContactEmail== null ?DBNull.Value:(object)objForm5.PContactEmail)),
                    new SqlParameter("@PContactPhoneNo",(objForm5.PContactPhoneNo== null ?DBNull.Value:(object)objForm5.PContactPhoneNo)),
                    new SqlParameter("@SContactName",(objForm5.SContactName== null ?DBNull.Value:(object)objForm5.SContactName)),
                    new SqlParameter("@SContactEmail",(objForm5.SContactEmail== null ?DBNull.Value:(object)objForm5.SContactEmail)),
                    new SqlParameter("@SContactPhoneNo",(objForm5.SContactPhoneNo== null ?DBNull.Value:(object)objForm5.SContactPhoneNo)),
                    new SqlParameter("@SportsType",(objForm5.SportsType== null ?DBNull.Value:(object)objForm5.SportsType)),
                    new SqlParameter("@SportsCategory",(objForm5.SportsCategory== null ?DBNull.Value:(object)objForm5.SportsCategory)),
                    new SqlParameter("@ParticipantsFullNames",(objForm5.ParticipantsFullNames== null ?DBNull.Value:(object)objForm5.ParticipantsFullNames)),
                    new SqlParameter("@TermsandConditions",objForm5.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm5.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm5.PaymentStatusId == 0?DBNull.Value:(object)objForm5.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm5.PaymentMethodId == 0?DBNull.Value:(object)objForm5.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm5.TransactionId== null ?DBNull.Value:(object)objForm5.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm5.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm5.AmountPaid)),
                    new SqlParameter("@BankName",(objForm5.BankName== null ?DBNull.Value:(object)objForm5.BankName)),
                    new SqlParameter("@ChequeNo",(objForm5.ChequeNo== null ?DBNull.Value:(object)objForm5.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm5.AdminComments== null ?DBNull.Value:(object)objForm5.AdminComments)),
                    new SqlParameter("@Field1",(objForm5.Field1== null ?DBNull.Value:(object)objForm5.Field1)),
                    new SqlParameter("@Field2",(objForm5.Field2== null ?DBNull.Value:(object)objForm5.Field2)),
                    new SqlParameter("@Field3",(objForm5.Field3== null ?DBNull.Value:(object)objForm5.Field3)),
                    new SqlParameter("@InstertedBy",objForm5.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm5.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm5.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm5.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[33].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("UpdateForm5", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[33].Value);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetForm5ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentStatusId, Int64 PaymentMethodId, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@RegistrationCategoryId",RegistrationCategoryId),
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),                    
                    new SqlParameter("@Total",Total),
                     new SqlParameter("@PaymentStatusId",PaymentStatusId),
                   new SqlParameter("@PaymentMethodId",PaymentMethodId)
                };

                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form5GetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetForm5ById(Int64 EventRegistrationForm5Id, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm5Id",EventRegistrationForm5Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form5GetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public Int64 DeleteForm5(Int64 EventRegistrationForm5Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm5Id",EventRegistrationForm5Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form5Delete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm5Status(Int64 EventRegistrationForm5Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm5Id",EventRegistrationForm5Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form5UpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }
        public DataTable GetForm5List(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form5GetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ExportToForm5(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentStatusId, Int64 PaymentMethodId, string Search, string Sort, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                   
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),             
                    new SqlParameter("@Total",Total),
                    new SqlParameter("@EventId",EventId),
                    new SqlParameter("@RegistrationCategoryId",RegistrationCategoryId),
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@PaymentMethodId",PaymentMethodId)
                };

                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToForm5", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
