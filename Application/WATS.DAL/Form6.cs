using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace WATS.DAL
{
   public class Form6
    {
        DBAccess _dbAccess = new DBAccess();

        SqlParameter[] _sqlP;

        public Int64 InsertForm6(WATS.Entities.Form6 objForm6)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm6Id",objForm6.EventRegistrationForm6Id),
                    new SqlParameter("@EventId",(objForm6.EventId == 0 ?DBNull.Value:(object)objForm6.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm6.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm6.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm6.MemberId == 0 ?DBNull.Value:(object)objForm6.MemberId)),
                    new SqlParameter("@ParticipantName",(objForm6.ParticipantName== null ?DBNull.Value:(object)objForm6.ParticipantName)),
                    new SqlParameter("@Email",(objForm6.Email== null ?DBNull.Value:(object)objForm6.Email)),
                    new SqlParameter("@ContactPhoneNo",(objForm6.ContactPhoneNo== null ?DBNull.Value:(object)objForm6.ContactPhoneNo)),
                    new SqlParameter("@ParticipationSection",(objForm6.ParticipationSection== null ?DBNull.Value:(object)objForm6.ParticipationSection)),
                    new SqlParameter("@USCFMembershipNo",(objForm6.USCFMembershipNo== null ?DBNull.Value:(object)objForm6.USCFMembershipNo)),
                    new SqlParameter("@Notes",(objForm6.Notes== null ?DBNull.Value:(object)objForm6.Notes)),
                    new SqlParameter("@TermsandConditions",objForm6.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm6.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm6.PaymentStatusId== 0?DBNull.Value:(object)objForm6.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm6.PaymentMethodId== 0?DBNull.Value:(object)objForm6.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm6.TransactionId== null ?DBNull.Value:(object)objForm6.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm6.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm6.AmountPaid)),  
                    new SqlParameter("@BankName",(objForm6.BankName== null ?DBNull.Value:(object)objForm6.BankName)),
                    new SqlParameter("@ChequeNo",(objForm6.ChequeNo== null ?DBNull.Value:(object)objForm6.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm6.AdminComments== null ?DBNull.Value:(object)objForm6.AdminComments)),
                    new SqlParameter("@Field1",(objForm6.Field1== null ?DBNull.Value:(object)objForm6.Field1)),
                    new SqlParameter("@Field2",(objForm6.Field2== null ?DBNull.Value:(object)objForm6.Field2)),
                    new SqlParameter("@Field3",(objForm6.Field3== null ?DBNull.Value:(object)objForm6.Field3)),
                    new SqlParameter("@InstertedBy",objForm6.InstertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objForm6.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[29].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form6Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[29].Value);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 FEInsertForm6(WATS.Entities.Form6 objForm6, ref Int64 EventRegistrationForm6Id)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm6Id",objForm6.EventRegistrationForm6Id),
                    new SqlParameter("@EventId",(objForm6.EventId == 0 ?DBNull.Value:(object)objForm6.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm6.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm6.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm6.MemberId == 0 ?DBNull.Value:(object)objForm6.MemberId)),
                    new SqlParameter("@ParticipantName",(objForm6.ParticipantName== null ?DBNull.Value:(object)objForm6.ParticipantName)),
                    new SqlParameter("@Email",(objForm6.Email== null ?DBNull.Value:(object)objForm6.Email)),
                    new SqlParameter("@ContactPhoneNo",(objForm6.ContactPhoneNo== null ?DBNull.Value:(object)objForm6.ContactPhoneNo)),
                    new SqlParameter("@ParticipationSection",(objForm6.ParticipationSection== null ?DBNull.Value:(object)objForm6.ParticipationSection)),
                    new SqlParameter("@USCFMembershipNo",(objForm6.USCFMembershipNo== null ?DBNull.Value:(object)objForm6.USCFMembershipNo)),
                    new SqlParameter("@Notes",(objForm6.Notes== null ?DBNull.Value:(object)objForm6.Notes)),
                    new SqlParameter("@TermsandConditions",objForm6.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm6.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm6.PaymentStatusId== 0?DBNull.Value:(object)objForm6.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm6.PaymentMethodId== 0?DBNull.Value:(object)objForm6.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm6.TransactionId== null ?DBNull.Value:(object)objForm6.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm6.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm6.AmountPaid)),
                    new SqlParameter("@BankName",(objForm6.BankName== null ?DBNull.Value:(object)objForm6.BankName)),
                    new SqlParameter("@ChequeNo",(objForm6.ChequeNo== null ?DBNull.Value:(object)objForm6.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm6.AdminComments== null ?DBNull.Value:(object)objForm6.AdminComments)),
                    new SqlParameter("@Field1",(objForm6.Field1== null ?DBNull.Value:(object)objForm6.Field1)),
                    new SqlParameter("@Field2",(objForm6.Field2== null ?DBNull.Value:(object)objForm6.Field2)),
                    new SqlParameter("@Field3",(objForm6.Field3== null ?DBNull.Value:(object)objForm6.Field3)),
                    new SqlParameter("@InstertedBy",objForm6.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm6.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm6.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm6.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[0].Direction = _sqlP[29].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form6Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[29].Value);

                EventRegistrationForm6Id = Convert.ToInt64(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm6(WATS.Entities.Form6 objForm6)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm6Id",objForm6.EventRegistrationForm6Id),
                    new SqlParameter("@EventId",(objForm6.EventId == 0 ?DBNull.Value:(object)objForm6.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm6.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm6.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm6.MemberId == 0 ?DBNull.Value:(object)objForm6.MemberId)),
                    new SqlParameter("@ParticipantName",(objForm6.ParticipantName== null ?DBNull.Value:(object)objForm6.ParticipantName)),
                    new SqlParameter("@Email",(objForm6.Email== null ?DBNull.Value:(object)objForm6.Email)),
                    new SqlParameter("@ContactPhoneNo",(objForm6.ContactPhoneNo== null ?DBNull.Value:(object)objForm6.ContactPhoneNo)),
                    new SqlParameter("@ParticipationSection",(objForm6.ParticipationSection== null ?DBNull.Value:(object)objForm6.ParticipationSection)),
                    new SqlParameter("@USCFMembershipNo",(objForm6.USCFMembershipNo== null ?DBNull.Value:(object)objForm6.USCFMembershipNo)),
                    new SqlParameter("@Notes",(objForm6.Notes== null ?DBNull.Value:(object)objForm6.Notes)),
                    new SqlParameter("@TermsandConditions",objForm6.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm6.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm6.PaymentStatusId== 0?DBNull.Value:(object)objForm6.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm6.PaymentMethodId== 0?DBNull.Value:(object)objForm6.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm6.TransactionId== null ?DBNull.Value:(object)objForm6.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm6.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm6.AmountPaid)),
                    new SqlParameter("@BankName",(objForm6.BankName== null ?DBNull.Value:(object)objForm6.BankName)),
                    new SqlParameter("@ChequeNo",(objForm6.ChequeNo== null ?DBNull.Value:(object)objForm6.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm6.AdminComments== null ?DBNull.Value:(object)objForm6.AdminComments)),
                    new SqlParameter("@Field1",(objForm6.Field1== null ?DBNull.Value:(object)objForm6.Field1)),
                    new SqlParameter("@Field2",(objForm6.Field2== null ?DBNull.Value:(object)objForm6.Field2)),
                    new SqlParameter("@Field3",(objForm6.Field3== null ?DBNull.Value:(object)objForm6.Field3)),
                    new SqlParameter("@InstertedBy",objForm6.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm6.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm6.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm6.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[29].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form6Update", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[29].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetForm6ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 PaymentMethodId,Int64 PaymentStatusId, string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("Form6GetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[8].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetFEForm6ListByVariable(Int64 EventId,string Search, string Sort, int PageNo, int Items, ref int Total)
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
                    new SqlParameter("@Total",Total)
                };

                _sqlP[5].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("FEForm6GetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        public DataTable GetForm6ById(Int64 EventRegistrationForm6Id, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm6Id",EventRegistrationForm6Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form6GetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public Int64 DeleteForm6(Int64 EventRegistrationForm6Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm6Id",EventRegistrationForm6Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form6Delete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm6Status(Int64 EventRegistrationForm6Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm6Id",EventRegistrationForm6Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form6UpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }
        public DataTable GetForm6List(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form6GetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ExportToForm6(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentMethodId, Int64 PaymentStatusId, string Search, string Sort, ref int Total)
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
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@PaymentMethodId",PaymentMethodId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportToForm6", ref _sqlP);
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

