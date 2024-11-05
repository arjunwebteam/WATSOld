using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
  public  class Form4
    {
        DBAccess _dbAccess = new DBAccess();

        SqlParameter[] _sqlP;

        public Int64 InsertForm4(WATS.Entities.Form4 objForm4)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm4Id",objForm4.EventRegistrationForm4Id),
                    new SqlParameter("@EventId",(objForm4.EventId == 0 ?DBNull.Value:(object)objForm4.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm4.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm4.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm4.MemberId == 0 ?DBNull.Value:(object)objForm4.MemberId)),
                    new SqlParameter("@Type",(objForm4.Type== null ?DBNull.Value:(object)objForm4.Type)),
                    new SqlParameter("@BusinessName",(objForm4.BusinessName== null ?DBNull.Value:(object)objForm4.BusinessName)),
                    new SqlParameter("@FullName",(objForm4.FullName== null ?DBNull.Value:(object)objForm4.FullName)),
                    new SqlParameter("@Email",(objForm4.Email== null ?DBNull.Value:(object)objForm4.Email)),
                    new SqlParameter("@PhoneNo",(objForm4.PhoneNo== null ?DBNull.Value:(object)objForm4.PhoneNo)),
                    new SqlParameter("@Notes",(objForm4.Notes== null ?DBNull.Value:(object)objForm4.Notes)),
                    new SqlParameter("@TermsandConditions",objForm4.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm4.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm4.PaymentStatusId == 0?DBNull.Value:(object)objForm4.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm4.PaymentMethodId == 0?DBNull.Value:(object)objForm4.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm4.TransactionId== null ?DBNull.Value:(object)objForm4.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm4.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm4.AmountPaid)),  
                    new SqlParameter("@BankName",(objForm4.BankName== null ?DBNull.Value:(object)objForm4.BankName)),
                    new SqlParameter("@ChequeNo",(objForm4.ChequeNo== null ?DBNull.Value:(object)objForm4.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm4.AdminComments== null ?DBNull.Value:(object)objForm4.AdminComments)),
                    new SqlParameter("@Field1",(objForm4.Field1== null ?DBNull.Value:(object)objForm4.Field1)),
                    new SqlParameter("@Field2",(objForm4.Field2== null ?DBNull.Value:(object)objForm4.Field2)),
                    new SqlParameter("@Field3",(objForm4.Field3== null ?DBNull.Value:(object)objForm4.Field3)),
                    new SqlParameter("@InstertedBy",objForm4.InstertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objForm4.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[29].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form4Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[29].Value);

               
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 FEInsertForm4(WATS.Entities.Form4 objForm4, ref Int64 EventRegistrationForm4Id)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm4Id",objForm4.EventRegistrationForm4Id),
                    new SqlParameter("@EventId",(objForm4.EventId == 0 ?DBNull.Value:(object)objForm4.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm4.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm4.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm4.MemberId == 0 ?DBNull.Value:(object)objForm4.MemberId)),
                    new SqlParameter("@Type",(objForm4.Type== null ?DBNull.Value:(object)objForm4.Type)),
                    new SqlParameter("@BusinessName",(objForm4.BusinessName== null ?DBNull.Value:(object)objForm4.BusinessName)),
                    new SqlParameter("@FullName",(objForm4.FullName== null ?DBNull.Value:(object)objForm4.FullName)),
                    new SqlParameter("@Email",(objForm4.Email== null ?DBNull.Value:(object)objForm4.Email)),
                    new SqlParameter("@PhoneNo",(objForm4.PhoneNo== null ?DBNull.Value:(object)objForm4.PhoneNo)),
                    new SqlParameter("@Notes",(objForm4.Notes== null ?DBNull.Value:(object)objForm4.Notes)),
                    new SqlParameter("@TermsandConditions",objForm4.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm4.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm4.PaymentStatusId == 0?DBNull.Value:(object)objForm4.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm4.PaymentMethodId == 0?DBNull.Value:(object)objForm4.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm4.TransactionId== null ?DBNull.Value:(object)objForm4.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm4.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm4.AmountPaid)),
                    new SqlParameter("@BankName",(objForm4.BankName== null ?DBNull.Value:(object)objForm4.BankName)),
                    new SqlParameter("@ChequeNo",(objForm4.ChequeNo== null ?DBNull.Value:(object)objForm4.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm4.AdminComments== null ?DBNull.Value:(object)objForm4.AdminComments)),
                    new SqlParameter("@Field1",(objForm4.Field1== null ?DBNull.Value:(object)objForm4.Field1)),
                    new SqlParameter("@Field2",(objForm4.Field2== null ?DBNull.Value:(object)objForm4.Field2)),
                    new SqlParameter("@Field3",(objForm4.Field3== null ?DBNull.Value:(object)objForm4.Field3)),
                    new SqlParameter("@InstertedBy",objForm4.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm4.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm4.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm4.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[0].Direction = _sqlP[29].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("FEForm4Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[29].Value);


                EventRegistrationForm4Id = Convert.ToInt64(_sqlP[0].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 UpdateForm4(WATS.Entities.Form4 objForm4)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm4Id",objForm4.EventRegistrationForm4Id),
                    new SqlParameter("@EventId",(objForm4.EventId == 0 ?DBNull.Value:(object)objForm4.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm4.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm4.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm4.MemberId == 0 ?DBNull.Value:(object)objForm4.MemberId)),
                    new SqlParameter("@Type",(objForm4.Type== null ?DBNull.Value:(object)objForm4.Type)),
                    new SqlParameter("@BusinessName",(objForm4.BusinessName== null ?DBNull.Value:(object)objForm4.BusinessName)),
                    new SqlParameter("@FullName",(objForm4.FullName== null ?DBNull.Value:(object)objForm4.FullName)),
                    new SqlParameter("@Email",(objForm4.Email== null ?DBNull.Value:(object)objForm4.Email)),
                    new SqlParameter("@PhoneNo",(objForm4.PhoneNo== null ?DBNull.Value:(object)objForm4.PhoneNo)),
                    new SqlParameter("@Notes",(objForm4.Notes== null ?DBNull.Value:(object)objForm4.Notes)),
                    new SqlParameter("@TermsandConditions",objForm4.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm4.IsApproved),
                    new SqlParameter("@ApprovedDate",DateTime.UtcNow),
                    new SqlParameter("@PaymentStatusId",(objForm4.PaymentStatusId == 0?DBNull.Value:(object)objForm4.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm4.PaymentMethodId == 0?DBNull.Value:(object)objForm4.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",DateTime.UtcNow),
                    new SqlParameter("@TransactionId",(objForm4.TransactionId== null ?DBNull.Value:(object)objForm4.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm4.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm4.AmountPaid)),
                    new SqlParameter("@BankName",(objForm4.BankName== null ?DBNull.Value:(object)objForm4.BankName)),
                    new SqlParameter("@ChequeNo",(objForm4.ChequeNo== null ?DBNull.Value:(object)objForm4.ChequeNo)),
                    new SqlParameter("@ChequeDate",DateTime.UtcNow),
                    new SqlParameter("@AdminComments",(objForm4.AdminComments== null ?DBNull.Value:(object)objForm4.AdminComments)),
                    new SqlParameter("@Field1",(objForm4.Field1== null ?DBNull.Value:(object)objForm4.Field1)),
                    new SqlParameter("@Field2",(objForm4.Field2== null ?DBNull.Value:(object)objForm4.Field2)),
                    new SqlParameter("@Field3",(objForm4.Field3== null ?DBNull.Value:(object)objForm4.Field3)),
                    new SqlParameter("@InstertedBy",objForm4.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm4.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm4.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm4.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };


                _sqlP[29].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("FEForm4Update", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[29].Value);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public DataTable GetForm4ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentStatusId , Int64 PaymentMethodId , string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("Form4GetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetForm4ById(Int64 EventRegistrationForm4Id, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm4Id",EventRegistrationForm4Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form4GetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }



        public Int64 DeleteForm4(Int64 EventRegistrationForm4Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm4Id",EventRegistrationForm4Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form4Delete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm4Status(Int64 EventRegistrationForm4Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm4Id",EventRegistrationForm4Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form4UpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }
        public DataTable GetForm4List(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form4GetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ExportToForm4(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentStatusId , Int64 PaymentMethodId , string Search, string Sort, ref int Total)
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
                dt = _dbAccess.GetDataTable("ExportToForm4", ref _sqlP);
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
