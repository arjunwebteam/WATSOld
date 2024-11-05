﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WATS.DAL
{
    public class Members
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        #region Admin

        public Int64 InsertMember(WATS.Entities.Members objMember,ref Int64 MemberId,ref string imageurl)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MemberId",objMember.MemberId),
                    new SqlParameter("@UserName",objMember.UserName),
                    new SqlParameter("@Email",objMember.Email ),
                    new SqlParameter("@Password",(objMember.Password == null ?DBNull.Value:(object)objMember.Password)),
                    new SqlParameter("@FirstName",objMember.FirstName),
                    new SqlParameter("@LastName",objMember.LastName),
                    new SqlParameter("@ProfileImage",imageurl),
                    new SqlParameter("@Occupation",(objMember.Occupation == null ?DBNull.Value:(object)objMember.Occupation)),
                    new SqlParameter("@MemberAge",(objMember.MemberAge == null ?DBNull.Value:(object)objMember.MemberAge)),
                    new SqlParameter("@MemberSkils",(objMember.MemberSkils == null ?DBNull.Value:(object)objMember.MemberSkils)),
                    new SqlParameter("@SpouseFirstName",(objMember.SpouseFirstName == null ?DBNull.Value:(object)objMember.SpouseFirstName)),
                    new SqlParameter("@SpouseLastName",(objMember.SpouseLastName == null ?DBNull.Value:(object)objMember.SpouseLastName)),
                    new SqlParameter("@SpouseOccupation",(objMember.SpouseOccupation == null ?DBNull.Value:(object)objMember.SpouseOccupation)),
                    new SqlParameter("@SpouseEmail",(objMember.SpouseEmail == null ?DBNull.Value:(object)objMember.SpouseEmail)),
                    new SqlParameter("@SpouseCell",(objMember.SpouseCell == null ?DBNull.Value:(object)objMember.SpouseCell)),
                    new SqlParameter("@SpouseSkils",(objMember.SpouseSkils == null ?DBNull.Value:(object)objMember.SpouseSkils)),
                    new SqlParameter("@Address",(objMember.Address  == null?DBNull.Value: (object)objMember.Address)),
                    new SqlParameter("@City",(objMember.City  == null?DBNull.Value: (object)objMember.City)),
                    new SqlParameter("@State",(objMember.State  == null?DBNull.Value: (object)objMember.State)),
                    new SqlParameter("@ZipCode",(objMember.ZipCode  == null?DBNull.Value: (object)objMember.ZipCode)),
                    new SqlParameter("@HomePhone",(objMember.HomePhone  == null?DBNull.Value: (object)objMember.HomePhone)),
                    new SqlParameter("@MobilePhone",(objMember.MobilePhone  == null?DBNull.Value: (object)objMember.MobilePhone)),
                    new SqlParameter("@IsApproved",objMember.IsApproved),
                    new SqlParameter("@IsLockedOut",objMember.IsLockedOut),
                    new SqlParameter("@IsActivated",objMember.IsActivated),
                    new SqlParameter("@DateActivated",(objMember.DateActivated  == DateTime.MinValue?DBNull.Value: (object)objMember.DateActivated)),
                    new SqlParameter("@RegistrationGUID",objMember.RegistrationGUID),                    
                    new SqlParameter("@FailedPasswordAttemptCount",(objMember.FailedPasswordAttemptCount == 0 ?DBNull.Value:(object)objMember.FailedPasswordAttemptCount)),
                    new SqlParameter("@LastPasswordChangedDate",(objMember.LastPasswordChangedDate == DateTime.MinValue ?DBNull.Value:(object)objMember.LastPasswordChangedDate)),
                    new SqlParameter("@LastActivityDate",(objMember.LastActivityDate == DateTime.MinValue ?DBNull.Value:(object)objMember.LastActivityDate)),
                    new SqlParameter("@MembershipTypeId",(objMember.MembershipTypeId == 0 ?DBNull.Value:(object)objMember.MembershipTypeId)),
                    new SqlParameter("@IsVolunteer",objMember.IsVolunteer),
                    new SqlParameter("@IsTeluguorigin",objMember.IsTeluguorigin),
                    new SqlParameter("@Comments",(objMember.Comments  == null?DBNull.Value: (object)objMember.Comments)),
                    new SqlParameter("@ReferredBy",(objMember.ReferredBy  == null?DBNull.Value: (object)objMember.ReferredBy)),
                    new SqlParameter("@InsertedTime",DateTime.UtcNow),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@MembershipOrderId",objMember.objMembershipOrder.MembershipOrderId),
                    new SqlParameter("@Amount",(objMember.objMembershipOrder.Amount == 0 ?DBNull.Value:(object)objMember.objMembershipOrder.Amount)),
                    new SqlParameter("@TransactionId",(objMember.objMembershipOrder.TransactionId == null ?DBNull.Value:(object)objMember.objMembershipOrder.TransactionId)),
                    new SqlParameter("@BankName",(objMember.objMembershipOrder.BankName == null ?DBNull.Value:(object)objMember.objMembershipOrder.BankName)),
                    new SqlParameter("@ChequeNo",(objMember.objMembershipOrder.ChequeNo == null ?DBNull.Value:(object)objMember.objMembershipOrder.ChequeNo)),
                    new SqlParameter("@ChequeDate",(objMember.objMembershipOrder.ChequeDate == DateTime.MinValue ?DBNull.Value:(object)objMember.objMembershipOrder.ChequeDate)),
                    new SqlParameter("@PaymentStatusId",(objMember.objMembershipOrder.PaymentStatusId == 0 ?DBNull.Value:(object)objMember.objMembershipOrder.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objMember.objMembershipOrder.PaymentMethodId == 0 ?DBNull.Value:(object)objMember.objMembershipOrder.PaymentMethodId)),
                    new SqlParameter("@PaymentBy",(objMember.objMembershipOrder.PaymentBy == null ?DBNull.Value:(object)objMember.objMembershipOrder.PaymentBy)),
                    new SqlParameter("@AdminComment",(objMember.objMembershipOrder.AdminComment == null ?DBNull.Value:(object)objMember.objMembershipOrder.AdminComment)),
                    new SqlParameter("@UserComment",(objMember.objMembershipOrder.UserComment == null ?DBNull.Value:(object)objMember.objMembershipOrder.UserComment)),
                    new SqlParameter("@OrderDate",(objMember.objMembershipOrder.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objMember.objMembershipOrder.OrderDate)),
                    new SqlParameter("@ExpiryDate",(objMember.objMembershipOrder.ExpiryDate == DateTime.MinValue  ?DBNull.Value:(object)objMember.objMembershipOrder.ExpiryDate)),
                    new SqlParameter("@UpdatedBy",objMember.objMembershipOrder.UpdatedBy),
                     new SqlParameter("@Fax",(objMember.Fax  == null?DBNull.Value: (object)objMember.Fax)),
                     new SqlParameter("@WebsiteAddress",(objMember.WebsiteAddress  == null?DBNull.Value: (object)objMember.WebsiteAddress)),
                     new SqlParameter("@Address2",(objMember.Address2  == null?DBNull.Value: (object)objMember.Address2)),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[6].SqlDbType = SqlDbType.NVarChar;
                _sqlP[6].Size = 256;
                _sqlP[6].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[0].Direction = _sqlP[54].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MembersInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[54].Value);
                MemberId = Convert.ToInt64(_sqlP[0].Value);
                imageurl = _sqlP[6].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }        

        public Int64 UpdateMemberStatus(Int64 MemberId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MemberUpdateStatus", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateMember(WATS.Entities.Members objMember)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MemberId",objMember.MemberId),
                    new SqlParameter("@UserName",objMember.UserName),
                    new SqlParameter("@Email",objMember.Email),
                    new SqlParameter("@FirstName",objMember.FirstName),
                    new SqlParameter("@LastName",objMember.LastName),
                    new SqlParameter("@Occupation",(objMember.Occupation == null ?DBNull.Value:(object)objMember.Occupation)),
                    new SqlParameter("@SpouseFirstName",(objMember.SpouseFirstName == null ?DBNull.Value:(object)objMember.SpouseFirstName)),
                    new SqlParameter("@SpouseLastName",(objMember.SpouseLastName == null ?DBNull.Value:(object)objMember.SpouseLastName)),
                    new SqlParameter("@SpouseOccupation",(objMember.SpouseOccupation == null ?DBNull.Value:(object)objMember.SpouseOccupation)),
                    new SqlParameter("@SpouseSkils",(objMember.SpouseSkils == null ?DBNull.Value:(object)objMember.SpouseSkils)),
                     new SqlParameter("@MemberAge",(objMember.MemberAge == null ?DBNull.Value:(object)objMember.MemberAge)),
                    new SqlParameter("@MemberSkils",(objMember.MemberSkils == null ?DBNull.Value:(object)objMember.MemberSkils)),
                    new SqlParameter("@SpouseEmail",(objMember.SpouseEmail == null ?DBNull.Value:(object)objMember.SpouseEmail)),
                    new SqlParameter("@SpouseCell",(objMember.SpouseCell == null ?DBNull.Value:(object)objMember.SpouseCell)),
                    new SqlParameter("@Address",(objMember.Address  == null?DBNull.Value: (object)objMember.Address)),
                    new SqlParameter("@City",(objMember.City  == null?DBNull.Value: (object)objMember.City)),
                    new SqlParameter("@State",(objMember.State  == null?DBNull.Value: (object)objMember.State)),
                    new SqlParameter("@ZipCode",(objMember.ZipCode  == null?DBNull.Value: (object)objMember.ZipCode)),
                    new SqlParameter("@HomePhone",(objMember.HomePhone  == null?DBNull.Value: (object)objMember.HomePhone)),
                    new SqlParameter("@MobilePhone",(objMember.MobilePhone  == null?DBNull.Value: (object)objMember.MobilePhone)),
                    new SqlParameter("@MembershipTypeId",(objMember.MembershipTypeId == 0 ?DBNull.Value:(object)objMember.MembershipTypeId)),
                    new SqlParameter("@IsVolunteer",objMember.IsVolunteer),
                    new SqlParameter("@IsTeluguorigin",objMember.IsTeluguorigin),
                    new SqlParameter("@Comments",(objMember.Comments  == null?DBNull.Value: (object)objMember.Comments)),
                    new SqlParameter("@ReferredBy",(objMember.ReferredBy  == null?DBNull.Value: (object)objMember.ReferredBy)),
                  
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@MembershipOrderId",objMember.MembershipOrderId),
                    new SqlParameter("@Amount",(objMember.Amount == 0 ?DBNull.Value:(object)objMember.Amount)),
                    new SqlParameter("@TransactionId",(objMember.TransactionId == null ?DBNull.Value:(object)objMember.TransactionId)),
                    new SqlParameter("@BankName",(objMember.BankName == null ?DBNull.Value:(object)objMember.BankName)),
                    new SqlParameter("@ChequeNo",(objMember.ChequeNo == null ?DBNull.Value:(object)objMember.ChequeNo)),
                    new SqlParameter("@ChequeDate",(objMember.ChequeDate == DateTime.MinValue ?DBNull.Value:(object)objMember.ChequeDate)),
                    new SqlParameter("@PaymentStatusId",(objMember.PaymentStatusId == 0 ?DBNull.Value:(object)objMember.PaymentStatusId)),
                    new SqlParameter("@PaymentMethodId",(objMember.PaymentMethodId == 0 ?DBNull.Value:(object)objMember.PaymentMethodId)),
                    new SqlParameter("@PaymentBy",(objMember.PaymentBy == null ?DBNull.Value:(object)objMember.PaymentBy)),
                    new SqlParameter("@AdminComment",(objMember.AdminComment == null ?DBNull.Value:(object)objMember.AdminComment)),
                    new SqlParameter("@UserComment",(objMember.UserComment == null ?DBNull.Value:(object)objMember.UserComment)),
                    new SqlParameter("@OrderDate",(objMember.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objMember.OrderDate)),
                    new SqlParameter("@ExpiryDate",(objMember.ExpiryDate == DateTime.MinValue  ?DBNull.Value:(object)objMember.ExpiryDate)),
                    new SqlParameter("@UpdatedBy",objMember.UpdatedBy),
                    new SqlParameter("@Fax",(objMember.Fax  == null?DBNull.Value: (object)objMember.Fax)),
                    new SqlParameter("@WebsiteAddress",(objMember.WebsiteAddress  == null?DBNull.Value: (object)objMember.WebsiteAddress)),
                    new SqlParameter("@Address2",(objMember.Address2  == null?DBNull.Value: (object)objMember.Address2)),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[43].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MembersUpdate", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[43].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateMemberProfile(WATS.Entities.Members objMember)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MemberId",objMember.MemberId),
                    new SqlParameter("@UserName",objMember.UserName),
                    new SqlParameter("@FirstName",objMember.FirstName),
                    new SqlParameter("@LastName",objMember.LastName),
                    new SqlParameter("@Occupation",(objMember.Occupation == null ?DBNull.Value:(object)objMember.Occupation)),
                    new SqlParameter("@MemberSkils",(objMember.MemberSkils == null ?DBNull.Value:(object)objMember.MemberSkils)),
                    new SqlParameter("@SpouseSkils",(objMember.SpouseSkils == null ?DBNull.Value:(object)objMember.SpouseSkils)),
                    new SqlParameter("@SpouseFirstName",(objMember.SpouseFirstName == null ?DBNull.Value:(object)objMember.SpouseFirstName)),
                    new SqlParameter("@SpouseLastName",(objMember.SpouseLastName == null ?DBNull.Value:(object)objMember.SpouseLastName)),
                    new SqlParameter("@SpouseOccupation",(objMember.SpouseOccupation == null ?DBNull.Value:(object)objMember.SpouseOccupation)),
                    new SqlParameter("@SpouseEmail",(objMember.SpouseEmail == null ?DBNull.Value:(object)objMember.SpouseEmail)),
                    new SqlParameter("@SpouseCell",objMember.SpouseCell),
                    new SqlParameter("@Address",(objMember.Address  == null?DBNull.Value: (object)objMember.Address)),
                    new SqlParameter("@City",(objMember.City  == null?DBNull.Value: (object)objMember.City)),
                    new SqlParameter("@State",(objMember.State  == null?DBNull.Value: (object)objMember.State)),
                    new SqlParameter("@ZipCode",(objMember.ZipCode  == null?DBNull.Value: (object)objMember.ZipCode)),
                    new SqlParameter("@HomePhone",(objMember.HomePhone  == null?DBNull.Value: (object)objMember.HomePhone)),
                    new SqlParameter("@MobilePhone",(objMember.MobilePhone  == null?DBNull.Value: (object)objMember.MobilePhone)),
                    new SqlParameter("@MembershipTypeId",(objMember.MembershipTypeId == 0 ?DBNull.Value:(object)objMember.MembershipTypeId)),
                    new SqlParameter("@IsVolunteer",objMember.IsVolunteer),
                    new SqlParameter("@Comments",(objMember.Comments  == null?DBNull.Value: (object)objMember.Comments)),
                    new SqlParameter("@ReferredBy",(objMember.ReferredBy  == null?DBNull.Value: (object)objMember.ReferredBy)),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@UpdatedBy",objMember.UpdatedBy),
                    new SqlParameter("@Fax",(objMember.Fax  == null?DBNull.Value: (object)objMember.Fax)),
                    new SqlParameter("@WebsiteAddress",(objMember.WebsiteAddress  == null?DBNull.Value: (object)objMember.WebsiteAddress)),
                    new SqlParameter("@Address2",(objMember.Address2  == null?DBNull.Value: (object)objMember.Address2)),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[27].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MemberProfileUpdate", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[27].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 ProfileEmailUpdate(string Email, Int64 MemberId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@Email",Email),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("ProfileEmailUpdate", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdateUserProfileImage(Int64 MemberId, ref string ProfileImage)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@ProfileImage",ProfileImage),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[1].SqlDbType = SqlDbType.NVarChar;
                _sqlP[1].Size = 256;
                _sqlP[1].Direction = System.Data.ParameterDirection.InputOutput;
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MembersProfileImage", ref _sqlP);
                ProfileImage = _sqlP[1].Value.ToString();
                _status = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetMembersListByVariable(string ListType, string Search, Int64 MembershipTypeId, Int64 PaymentStatusId, string StartDate, string EndDate, string ExpiryDate, string IsVolunteer, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MembershipTypeId",MembershipTypeId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@StartDate",StartDate),                    
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@ExpiryDate",ExpiryDate),
                    new SqlParameter("@IsVolunteer",IsVolunteer),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@Items",Items),
                    new SqlParameter("@Total",Total),
                    new SqlParameter("@ListType",ListType)
                };

                _sqlP[10].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("MembersGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[10].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable ExportMembersList(string Search, Int64 MembershipTypeId, Int64 PaymentStatusId, string StartDate, string EndDate, string ExpiryDate, string Sort)
        {
            DataTable dt = null;
            int Total = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MembershipTypeId",MembershipTypeId),
                    new SqlParameter("@PaymentStatusId",PaymentStatusId),
                    new SqlParameter("@StartDate",StartDate),                    
                    new SqlParameter("@EndDate",EndDate),
                    new SqlParameter("@ExpiryDate",ExpiryDate),
                    new SqlParameter("@Search",Search),
                    new SqlParameter("@Sort",Sort),
                    new SqlParameter("@Total",Total)
                };

                _sqlP[7].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("ExportMembersGetList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetMembersOrderDetailsListByVariable(string Search,string Sort, int PageNo, int Items, ref int Total)
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
                dt = _dbAccess.GetDataTable("MembersOrderDetailsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetMembersList(ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("MembersGetList", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetMemberById(Int64 MemberId, ref int status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("MembersGetById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeleteMember(Int64 MemberId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MembersDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 DeleteMemberOrder(Int64 MemberOrderId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberOrderId",MemberOrderId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MemberorderDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 DeleteChildInfo(Int64 ChildInfoId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@ChildInfoId",ChildInfoId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("ChildInfoDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataSet GetMembersFullDetailsById(Int64 MemberId, ref int status)
        {
            DataSet ds2 = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds2 = _dbAccess.GetDataSet("MembersGetFullDetailsById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds2;
        }

        public DataSet GetMemberFullDetailsById(Int64 MemberId, ref int status)
        {
            DataSet ds0 = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataSet("MemberGetFullDetailsById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        public DataTable GetMemberOrderById(Int64 MemberOrderId, ref int status)
        {
            DataTable ds0 = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberOrderId",MemberOrderId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataTable("MemberOrderById", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        public DataSet GetMemberFullDetailsByUserName(string UserName, ref int status)
        {
            DataSet ds0 = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@UserName",UserName),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataSet("MemberGetFullDetailsByUserName", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        public DataSet GetMemberFullDetailsByNameAndMemberId(string SpouseCell, string LastName, ref int status)
        {
            DataSet ds0 = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@SpouseCell",SpouseCell),
                    new SqlParameter("@LastName",LastName),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataSet("MemberGetFullDetailsByUserNameAndSpousecell", ref _sqlP);
                status = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        public Int64 DeleteAllMembers(string MemberId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@QStatus",0)
                };

                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MembersDeleteAll", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataSet GetMemberFullDetailsByEmail(string Email, ref int status)
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
                ds0 = _dbAccess.GetDataSet("MemberGetFullDetailsByEmail", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        public DataSet AddMembershipRequirement(ref int status)
        {
            DataSet ds = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                ds = _dbAccess.GetDataSet("AddMembershipRequirement", ref _sqlP);
                status = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public Int64 InsertChildrenInfo(WATS.Entities.ChildrenInfo objChildrenInfo)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@ChildrenInfoId",objChildrenInfo.ChildrenInfoId),
                    new SqlParameter("@MemberId",(objChildrenInfo.MemberId==0?(object)DBNull.Value:objChildrenInfo.MemberId)),
                    new SqlParameter("@Age",(objChildrenInfo.Age==0?(object)DBNull.Value:objChildrenInfo.Age)),
                    new SqlParameter("@FirstName",(objChildrenInfo.FirstName==null?(object)DBNull.Value:objChildrenInfo.FirstName)),
                    new SqlParameter("@LastName",(objChildrenInfo.LastName==null?(object)DBNull.Value:objChildrenInfo.LastName)),
                    new SqlParameter("@Relationship",(objChildrenInfo.Relationship==null?(object)DBNull.Value:objChildrenInfo.Relationship)),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[6].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("ChildrenInfoInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 InsertMemberOrder(WATS.Entities.MembershipOrders objMembershipOrders)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                        new SqlParameter("@MemberId",objMembershipOrders.MemberId),
                        new SqlParameter("@MembershipTypeId",objMembershipOrders.MembershipTypeId),
                        new SqlParameter("@MembershipOrderId",objMembershipOrders.MembershipOrderId),
                        new SqlParameter("@Amount",(objMembershipOrders.Amount == 0 ?DBNull.Value:(object)objMembershipOrders.Amount)),
                        new SqlParameter("@PaymentMethodId",(objMembershipOrders.PaymentMethodId == 0 ?DBNull.Value:(object)objMembershipOrders.PaymentMethodId)),
                        new SqlParameter("@PaymentStatusId",(objMembershipOrders.PaymentStatusId == 0 ?DBNull.Value:(object)objMembershipOrders.PaymentStatusId)),
                        new SqlParameter("@TransactionId",(objMembershipOrders.TransactionId == null ?DBNull.Value:(object)objMembershipOrders.TransactionId)),
                        new SqlParameter("@BankName",(objMembershipOrders.BankName == null ?DBNull.Value:(object)objMembershipOrders.BankName)),
                        new SqlParameter("@ChequeNo",(objMembershipOrders.ChequeNo == null ?DBNull.Value:(object)objMembershipOrders.ChequeNo)),
                        new SqlParameter("@ChequeDate",(objMembershipOrders.ChequeDate == DateTime.MinValue ?DBNull.Value:(object)objMembershipOrders.ChequeDate)),
                        new SqlParameter("@PaymentStatus",(objMembershipOrders.PaymentStatus == null ?DBNull.Value:(object)objMembershipOrders.PaymentStatus)),
                        new SqlParameter("@PaymentMethod",(objMembershipOrders.PaymentMethod == null?DBNull.Value:(object)objMembershipOrders.PaymentMethod)),
                        new SqlParameter("@PaymentBy",(objMembershipOrders.PaymentBy == null ?DBNull.Value:(object)objMembershipOrders.PaymentBy)),
                        new SqlParameter("@OrderType",(objMembershipOrders.OrderType == null ?DBNull.Value:(object)objMembershipOrders.OrderType)),
                        new SqlParameter("@AdminComment",(objMembershipOrders.AdminComment == null ?DBNull.Value:(object)objMembershipOrders.AdminComment)),
                        new SqlParameter("@UserComment",(objMembershipOrders.UserComment == null ?DBNull.Value:(object)objMembershipOrders.UserComment)),
                        new SqlParameter("@OrderDate",(objMembershipOrders.OrderDate == DateTime.MinValue ?DBNull.Value:(object)objMembershipOrders.OrderDate)),
                        new SqlParameter("@ExpiryDate",(objMembershipOrders.ExpiryDate == DateTime.MinValue  ?DBNull.Value:(object)objMembershipOrders.ExpiryDate)),
                        new SqlParameter("@IsVolunteer",objMembershipOrders.IsVolunteer),
                        new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                        new SqlParameter("@UpdatedBy",objMembershipOrders.UpdatedBy),
                        new SqlParameter("@QStatus",0)
                    };
                _sqlP[21].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MemberOrderInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[21].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 ChangePassword(Int64 MemberId, string Password)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@Password",Password),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MembersChangePassword", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[2].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetPassword(Int64 _Memberid, ref int _QStatus)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] {
                new SqlParameter("@MemberId",_Memberid),
                new SqlParameter("@QStatus",_QStatus)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;

                dt = _dbAccess.GetDataTable("MembersGetPassword", ref _sqlP);
                _QStatus = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 UpdateMemberProfileImage(Int64 MemberId, ref string ProfileImage)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MemberId",MemberId),
                    new SqlParameter("@ProfileImage",ProfileImage),
                    new SqlParameter("@QStatus",0)
                    };
                _sqlP[1].SqlDbType = SqlDbType.NVarChar;
                _sqlP[1].Size = 256;
                _sqlP[1].Direction = System.Data.ParameterDirection.InputOutput;
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("MemberProfileImage", ref _sqlP);
                ProfileImage = _sqlP[1].Value.ToString();
                _status = Convert.ToInt64(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 Dashboard(ref int status, ref Int64 TotalCount, ref Int64 WeeklyCount, ref Int64 MonthlyCount, ref Int64 LifeFamilyCount, ref Int64 AnnualFamilyCount, ref Int64 AnnualSingleCount, ref Int64 LifeSingleCount, ref Int64 DonorsWeeklyCount, ref Int64 DonorsMonthlyCount, ref Int64 DonorsTotalCount)
        {
            Int64 _status = 0;

            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@QStatus",0),
                    new SqlParameter("@TotalCount",TotalCount),
                    new SqlParameter("@WeeklyCount",WeeklyCount),
                    new SqlParameter("@MonthlyCount",MonthlyCount),
                    new SqlParameter("@LifeFamilyCount",LifeFamilyCount),
                    new SqlParameter("@AnnualFamilyCount",AnnualFamilyCount),
                    new SqlParameter("@AnnualSingleCount",AnnualSingleCount),
                    new SqlParameter("@LifeSingleCount",LifeSingleCount),
                    new SqlParameter("@DonorsWeeklyCount",DonorsWeeklyCount),
                    new SqlParameter("@DonorsMonthlyCount",DonorsMonthlyCount),
                    new SqlParameter("@DonorsTotalCount",DonorsTotalCount),

                    };
                //_sqlP[1].SqlDbType = _sqlP[2].SqlDbType = _sqlP[3].SqlDbType = _sqlP[4].SqlDbType = _sqlP[5].SqlDbType = _sqlP[6].SqlDbType = _sqlP[7].SqlDbType = _sqlP[8].SqlDbType = _sqlP[9].SqlDbType = _sqlP[10].SqlDbType = SqlDbType.NVarChar;
                //_sqlP[1].Size = _sqlP[2].Size = _sqlP[3].Size = _sqlP[4].Size = _sqlP[5].Size = _sqlP[6].Size = _sqlP[7].Size = _sqlP[8].Size = _sqlP[9].Size = _sqlP[10].Size = 256;
                _sqlP[1].Direction = _sqlP[2].Direction = _sqlP[3].Direction = _sqlP[4].Direction = _sqlP[5].Direction = _sqlP[6].Direction = _sqlP[7].Direction = _sqlP[8].Direction = _sqlP[9].Direction = _sqlP[10].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("DashboardGetList", ref _sqlP);
                TotalCount = Convert.ToInt64(_sqlP[1].Value);
                WeeklyCount = Convert.ToInt64(_sqlP[2].Value);
                MonthlyCount = Convert.ToInt64(_sqlP[3].Value);
                LifeFamilyCount = Convert.ToInt64(_sqlP[4].Value);
                AnnualFamilyCount = Convert.ToInt64(_sqlP[5].Value);
                AnnualSingleCount = Convert.ToInt64(_sqlP[6].Value);
                LifeSingleCount = Convert.ToInt64(_sqlP[7].Value);
                DonorsWeeklyCount = Convert.ToInt64(_sqlP[8].Value);
                DonorsMonthlyCount = Convert.ToInt64(_sqlP[9].Value);
                DonorsTotalCount = Convert.ToInt64(_sqlP[10].Value);
                _status = Convert.ToInt64(_sqlP[0].Value);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        #endregion

        #region Front-End

        public Int64 FEInsertMember(WATS.Entities.Members objMember, ref Int64 MemberId, ref string imageurl)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                    new SqlParameter("@MemberId",objMember.MemberId),
                    new SqlParameter("@UserName",objMember.UserName),
                    new SqlParameter("@Email",objMember.Email ),
                    new SqlParameter("@Password",(objMember.Password == null ?DBNull.Value:(object)objMember.Password)),
                    new SqlParameter("@FirstName",objMember.FirstName),
                    new SqlParameter("@LastName",objMember.LastName),
                    new SqlParameter("@ProfileImage",imageurl),
                    new SqlParameter("@Occupation",(objMember.Occupation == null ?DBNull.Value:(object)objMember.Occupation)),
                    new SqlParameter("@MemberAge",(objMember.MemberAge == null ?DBNull.Value:(object)objMember.MemberAge)),
                    new SqlParameter("@MemberSkils",(objMember.MemberSkils == null ?DBNull.Value:(object)objMember.MemberSkils)),
                    new SqlParameter("@SpouseFirstName",(objMember.SpouseFirstName == null ?DBNull.Value:(object)objMember.SpouseFirstName)),
                    new SqlParameter("@SpouseLastName",(objMember.SpouseLastName == null ?DBNull.Value:(object)objMember.SpouseLastName)),
                    new SqlParameter("@SpouseOccupation",(objMember.SpouseOccupation == null ?DBNull.Value:(object)objMember.SpouseOccupation)),
                    new SqlParameter("@SpouseEmail",(objMember.SpouseEmail == null ?DBNull.Value:(object)objMember.SpouseEmail)),
                    new SqlParameter("@SpouseCell",(objMember.SpouseCell == null ?DBNull.Value:(object)objMember.SpouseCell)),
                    new SqlParameter("@SpouseSkils",(objMember.SpouseSkils == null ?DBNull.Value:(object)objMember.SpouseSkils)),
                    new SqlParameter("@Address",(objMember.Address  == null?DBNull.Value: (object)objMember.Address)),
                    new SqlParameter("@Address2",(objMember.Address2  == null?DBNull.Value: (object)objMember.Address2)),
                    new SqlParameter("@City",(objMember.City  == null?DBNull.Value: (object)objMember.City)),
                    new SqlParameter("@State",(objMember.State  == null?DBNull.Value: (object)objMember.State)),
                    new SqlParameter("@ZipCode",(objMember.ZipCode  == null?DBNull.Value: (object)objMember.ZipCode)),
                    new SqlParameter("@HomePhone",(objMember.HomePhone  == null?DBNull.Value: (object)objMember.HomePhone)),
                    new SqlParameter("@MobilePhone",(objMember.MobilePhone  == null?DBNull.Value: (object)objMember.MobilePhone)),
                    new SqlParameter("@Fax",(objMember.Fax  == null?DBNull.Value: (object)objMember.Fax)),
                    new SqlParameter("@WebsiteAddress",(objMember.WebsiteAddress  == null?DBNull.Value: (object)objMember.WebsiteAddress)),
                    new SqlParameter("@IsApproved",objMember.IsApproved),
                    new SqlParameter("@IsLockedOut",objMember.IsLockedOut),
                    new SqlParameter("@IsActivated",objMember.IsActivated),
                    new SqlParameter("@DateActivated",(objMember.DateActivated  == DateTime.MinValue?DBNull.Value: (object)objMember.DateActivated)),
                    new SqlParameter("@RegistrationGUID",objMember.RegistrationGUID),                    
                    new SqlParameter("@FailedPasswordAttemptCount",(objMember.FailedPasswordAttemptCount == 0 ?DBNull.Value:(object)objMember.FailedPasswordAttemptCount)),
                    new SqlParameter("@LastPasswordChangedDate",(objMember.LastPasswordChangedDate == DateTime.MinValue ?DBNull.Value:(object)objMember.LastPasswordChangedDate)),
                    new SqlParameter("@LastActivityDate",(objMember.LastActivityDate == DateTime.MinValue ?DBNull.Value:(object)objMember.LastActivityDate)),
                    new SqlParameter("@MembershipTypeId",(objMember.MembershipTypeId == 0 ?DBNull.Value:(object)objMember.MembershipTypeId)),
                    new SqlParameter("@IsVolunteer",objMember.IsVolunteer),
                    new SqlParameter("@IsTeluguorigin",objMember.IsTeluguorigin),
                    new SqlParameter("@Comments",(objMember.Comments  == null?DBNull.Value: (object)objMember.Comments)),
                    new SqlParameter("@ReferredBy",(objMember.ReferredBy  == null?DBNull.Value: (object)objMember.ReferredBy)),
                    new SqlParameter("@InsertedTime",DateTime.UtcNow),
                    new SqlParameter("@UpdatedTime",DateTime.UtcNow),
                    new SqlParameter("@QStatus",0)
                    };

                _sqlP[6].SqlDbType = SqlDbType.NVarChar;
                _sqlP[6].Size = 256;
                _sqlP[6].Direction = System.Data.ParameterDirection.InputOutput;

                _sqlP[0].Direction = _sqlP[40].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("FEMembersInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[40].Value);
                MemberId = Convert.ToInt64(_sqlP[0].Value);
                imageurl = _sqlP[6].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataSet FEVerifyMemberBySpouseeCell(string SpouseCell, ref int status)
        {
            DataSet ds0 = null;
            try
            {
                _sqlP = new[]
                {
                    new SqlParameter("@SpouseCell",SpouseCell),                    
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                ds0 = _dbAccess.GetDataSet("VerifyMembersBySpouseCell", ref _sqlP);
                status = Convert.ToInt32(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds0;
        }

        #endregion
    }
}
