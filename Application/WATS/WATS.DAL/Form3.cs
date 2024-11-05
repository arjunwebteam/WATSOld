using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class Form3
    {
        DBAccess _dbAccess = new DBAccess();

        SqlParameter[] _sqlP;

        public Int64 InsertForm3(WATS.Entities.Form3 objForm3)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm3Id",objForm3.EventRegistrationForm3Id),
                    new SqlParameter("@EventId",(objForm3.EventId == 0 ?DBNull.Value:(object)objForm3.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm3.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm3.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm3.MemberId == 0 ?DBNull.Value:(object)objForm3.MemberId)),
                    new SqlParameter("@FirstName",(objForm3.FirstName== null ?DBNull.Value:(object)objForm3.FirstName)),
                    new SqlParameter("@LastName",(objForm3.LastName== null ?DBNull.Value:(object)objForm3.LastName)),
                    new SqlParameter("@ContactPhone",(objForm3.ContactPhone== null ?DBNull.Value:(object)objForm3.ContactPhone)),
                    new SqlParameter("@ContactEmail",(objForm3.ContactEmail== null ?DBNull.Value:(object)objForm3.ContactEmail)),
                    new SqlParameter("@Notes",(objForm3.Notes== null ?DBNull.Value:(object)objForm3.Notes)),
                    new SqlParameter("@TermsandConditions",objForm3.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm3.IsApproved),
                    new SqlParameter("@ApprovedDate",(objForm3.ApprovedDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.ApprovedDate)),
                    new SqlParameter("@PaymentStatusId",(objForm3.PaymentStatusId == 0 ?DBNull.Value:(object)objForm3.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm3.PaymentMethodId == 0 ?DBNull.Value:(object)objForm3.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",(objForm3.PaymentDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.PaymentDate)),
                    new SqlParameter("@TransactionId",(objForm3.TransactionId== null ?DBNull.Value:(object)objForm3.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm3.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm3.AmountPaid)),   
                    new SqlParameter("@BankName",(objForm3.BankName== null ?DBNull.Value:(object)objForm3.BankName)),
                    new SqlParameter("@ChequeNo",(objForm3.ChequeNo== null ?DBNull.Value:(object)objForm3.ChequeNo)),
                    new SqlParameter("@ChequeDate",(objForm3.ChequeDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.ChequeDate)),
                    new SqlParameter("@AdminComments",(objForm3.AdminComments== null ?DBNull.Value:(object)objForm3.AdminComments)),
                    new SqlParameter("@Field1",(objForm3.Field1== null ?DBNull.Value:(object)objForm3.Field1)),
                    new SqlParameter("@Field2",(objForm3.Field2== null ?DBNull.Value:(object)objForm3.Field2)),
                    new SqlParameter("@Field3",(objForm3.Field3== null ?DBNull.Value:(object)objForm3.Field3)),
                    new SqlParameter("@InstertedBy",objForm3.InstertedBy),
                    new SqlParameter("@InsertedDate",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objForm3.UpdatedBy),
                    new SqlParameter("@UpdatedDate",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[28].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form3Insert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[28].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }


        public Int64 FEInsertForm3(WATS.Entities.Form3 objForm3, ref Int64 EventRegistrationForm3Id)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm3Id",objForm3.EventRegistrationForm3Id),
                    new SqlParameter("@EventId",(objForm3.EventId == 0 ?DBNull.Value:(object)objForm3.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm3.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm3.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm3.MemberId == 0 ?DBNull.Value:(object)objForm3.MemberId)),
                    new SqlParameter("@FirstName",(objForm3.FirstName== null ?DBNull.Value:(object)objForm3.FirstName)),
                    new SqlParameter("@LastName",(objForm3.LastName== null ?DBNull.Value:(object)objForm3.LastName)),
                    new SqlParameter("@ContactPhone",(objForm3.ContactPhone== null ?DBNull.Value:(object)objForm3.ContactPhone)),
                    new SqlParameter("@ContactEmail",(objForm3.ContactEmail== null ?DBNull.Value:(object)objForm3.ContactEmail)),
                    new SqlParameter("@Notes",(objForm3.Notes== null ?DBNull.Value:(object)objForm3.Notes)),
                    new SqlParameter("@TermsandConditions",objForm3.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm3.IsApproved),
                    new SqlParameter("@ApprovedDate",(objForm3.ApprovedDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.ApprovedDate)),
                    new SqlParameter("@PaymentStatusId",(objForm3.PaymentStatusId == 0 ?DBNull.Value:(object)objForm3.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm3.PaymentMethodId == 0 ?DBNull.Value:(object)objForm3.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",(objForm3.PaymentDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.PaymentDate)),
                    new SqlParameter("@TransactionId",(objForm3.TransactionId== null ?DBNull.Value:(object)objForm3.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm3.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm3.AmountPaid)),
                    new SqlParameter("@BankName",(objForm3.BankName== null ?DBNull.Value:(object)objForm3.BankName)),
                    new SqlParameter("@ChequeNo",(objForm3.ChequeNo== null ?DBNull.Value:(object)objForm3.ChequeNo)),
                    new SqlParameter("@ChequeDate",(objForm3.ChequeDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.ChequeDate)),
                    new SqlParameter("@AdminComments",(objForm3.AdminComments== null ?DBNull.Value:(object)objForm3.AdminComments)),
                    new SqlParameter("@Field1",(objForm3.Field1== null ?DBNull.Value:(object)objForm3.Field1)),
                    new SqlParameter("@Field2",(objForm3.Field2== null ?DBNull.Value:(object)objForm3.Field2)),
                    new SqlParameter("@Field3",(objForm3.Field3== null ?DBNull.Value:(object)objForm3.Field3)),
                    new SqlParameter("@InstertedBy",objForm3.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm3.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm3.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm3.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[0].Direction = _sqlP[28].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("FEInsertForm3", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[28].Value);

                EventRegistrationForm3Id = Convert.ToInt64(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm3(WATS.Entities.Form3 objForm3)
        {

            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@EventRegistrationForm3Id",objForm3.EventRegistrationForm3Id),
                    new SqlParameter("@EventId",(objForm3.EventId == 0 ?DBNull.Value:(object)objForm3.EventId)),
                    new SqlParameter("@RegistrationCategoryId",(objForm3.RegistrationCategoryId == 0 ?DBNull.Value:(object)objForm3.RegistrationCategoryId)),
                    new SqlParameter("@MemberId",(objForm3.MemberId == 0 ?DBNull.Value:(object)objForm3.MemberId)),
                    new SqlParameter("@FirstName",(objForm3.FirstName== null ?DBNull.Value:(object)objForm3.FirstName)),
                    new SqlParameter("@LastName",(objForm3.LastName== null ?DBNull.Value:(object)objForm3.LastName)),
                    new SqlParameter("@ContactPhone",(objForm3.ContactPhone== null ?DBNull.Value:(object)objForm3.ContactPhone)),
                    new SqlParameter("@ContactEmail",(objForm3.ContactEmail== null ?DBNull.Value:(object)objForm3.ContactEmail)),
                    new SqlParameter("@Notes",(objForm3.Notes== null ?DBNull.Value:(object)objForm3.Notes)),
                    new SqlParameter("@TermsandConditions",objForm3.TermsandConditions),
                    new SqlParameter("@IsApproved",objForm3.IsApproved),
                    new SqlParameter("@ApprovedDate",(objForm3.ApprovedDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.ApprovedDate)),
                    new SqlParameter("@PaymentStatusId",(objForm3.PaymentStatusId == 0 ?DBNull.Value:(object)objForm3.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objForm3.PaymentMethodId == 0 ?DBNull.Value:(object)objForm3.PaymentMethodId)),
                    new SqlParameter("@PaymentDate",(objForm3.PaymentDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.PaymentDate)),
                    new SqlParameter("@TransactionId",(objForm3.TransactionId== null ?DBNull.Value:(object)objForm3.TransactionId)),
                    new SqlParameter("@AmountPaid",(objForm3.AmountPaid==Decimal.MinValue?(object)DBNull.Value:objForm3.AmountPaid)),
                    new SqlParameter("@BankName",(objForm3.BankName== null ?DBNull.Value:(object)objForm3.BankName)),
                    new SqlParameter("@ChequeNo",(objForm3.ChequeNo== null ?DBNull.Value:(object)objForm3.ChequeNo)),
                    new SqlParameter("@ChequeDate",(objForm3.ChequeDate == DateTime.MinValue ?DBNull.Value:(object)objForm3.ChequeDate)),
                    new SqlParameter("@AdminComments",(objForm3.AdminComments== null ?DBNull.Value:(object)objForm3.AdminComments)),
                    new SqlParameter("@Field1",(objForm3.Field1== null ?DBNull.Value:(object)objForm3.Field1)),
                    new SqlParameter("@Field2",(objForm3.Field2== null ?DBNull.Value:(object)objForm3.Field2)),
                    new SqlParameter("@Field3",(objForm3.Field3== null ?DBNull.Value:(object)objForm3.Field3)),
                    new SqlParameter("@InstertedBy",objForm3.InstertedBy),
                    new SqlParameter("@InsertedDate",objForm3.InsertedDate),
                    new SqlParameter("@UpdatedBy",objForm3.UpdatedBy),
                    new SqlParameter("@UpdatedDate",objForm3.UpdatedDate),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[28].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form3Update", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[28].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetForm3ListByVariable(Int64 EventId, Int64 RegistrationCategoryId, Int64 PaymentMethodId, Int64 PaymentStatusId, string Search, string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("Form3GetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[8].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetForm3ById(Int64 EventRegistrationForm3Id, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm3Id",EventRegistrationForm3Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form3GetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteForm3ById(Int64 EventRegistrationForm3Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm3Id",EventRegistrationForm3Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form3Delete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateForm3StatusById(Int64 EventRegistrationForm3Id)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@EventRegistrationForm3Id",EventRegistrationForm3Id),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("Form3UpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetForm3List(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("Form3GetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

      


        public DataTable Form3ExportToExcel(Int64 EventId, Int64 RegistrationCategoryId, Int64 MemberId, Int64 PaymentStatusId, Int64 PaymentMethodId, string Search, string Sort, ref int Total)
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
                dt = _dbAccess.GetDataTable("Form3ExportToExcel", ref _sqlP);
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
