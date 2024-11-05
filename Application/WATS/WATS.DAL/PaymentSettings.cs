﻿using System;
using System.Data;
using System.Linq;
using System.Data.SqlClient;
using System.Configuration;

namespace WATS.DAL
{
    public class PaymentSettings
    {
        DBAccess _dbAccess = new DBAccess();
        SqlParameter[] _sqlP;

        public DataTable GetPaymentSettingsDetails(Int64 PaymentSettingId,string PaymentMethod, ref int Status)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@PaymentSettingId",PaymentSettingId),
                    new SqlParameter("@PaymentMethod",PaymentMethod),
                    new SqlParameter("@Qstatus",0)
                };
                _sqlP[2].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("PaymentSettingsGetDetails", ref _sqlP);
                Status = Convert.ToInt32(_sqlP[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 UpdatePaymentDetails(WATS.Entities.PaymentSettings objPaymentSettings)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[]
                    {
                        new SqlParameter("@PaymentSettingId",objPaymentSettings.PaymentSettingId),
                        new SqlParameter("@PaymentMethodId",objPaymentSettings.PaymentMethodId),
                        new SqlParameter("@AccountType",objPaymentSettings.AccountType),
                        new SqlParameter("@PaymentUrl",objPaymentSettings.PaymentUrl),
                        new SqlParameter("@PaymentEmail",objPaymentSettings.PaymentEmail),
                        new SqlParameter("@PaymentPassword",objPaymentSettings.PaymentPassword),
                        new SqlParameter("@CurrencyCodeId",objPaymentSettings.CurrencyCodeId),
                        new SqlParameter("@SuccessUrl",objPaymentSettings.SuccessUrl),
                        new SqlParameter("@CancelUrl",objPaymentSettings.CancelUrl),
                        new SqlParameter("@NotifyUrl",(objPaymentSettings.NotifyUrl==null?(object)DBNull.Value:objPaymentSettings.NotifyUrl)),
                        new SqlParameter("@TokenNo",(objPaymentSettings.TokenNo==null?(object)DBNull.Value:objPaymentSettings.TokenNo)),
                        new SqlParameter("@QStatus",0)
                    };
                _sqlP[11].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("PaymentSettingsInsert", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[11].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable GetPaymentSettingsListByVariable(string search,int PageNo, int ItemsPerPage, ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@search",search),
                    new SqlParameter("@PageNo",PageNo),
                    new SqlParameter("@ItemsPerPage",ItemsPerPage),                    
                    new SqlParameter("@Total",Total)
                };

                _sqlP[3].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("PaymentSettingsGetListByVariable", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[3].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable GetPaymentSettingById(Int64 PaymentSettingId)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@PaymentSettingId",PaymentSettingId)
                };
                dt = _dbAccess.GetDataTable("PaymentSettingsGetById", ref _sqlP);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public Int64 DeletePaymentSettingById(Int64 PaymentSettingId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@PaymentSettingId",PaymentSettingId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("PaymentSettingsDelete", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 DeleteAllPaymentSettingsById(string PaymentSettingsId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@PaymentSettingsId",PaymentSettingsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("PaymentSettingsDeleteAll", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public Int64 UpdatePaymentSettingApprovalById(Int64 PaymentSettingsId)
        {
            Int64 _status = 0;
            try
            {
                _sqlP = new[] 
                {
                    new SqlParameter("@PaymentSettingId",PaymentSettingsId),
                    new SqlParameter("@QStatus",0)
                };
                _sqlP[1].Direction = System.Data.ParameterDirection.Output;
                _dbAccess.SP_ExecuteScalar("PaymentSettingsChangeStatusById", ref _sqlP);
                _status = Convert.ToInt64(_sqlP[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _status;
        }

        public DataTable CurrencyCodesList(ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {             
                    new SqlParameter("@Qstatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("CurrencyCodesList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        public DataTable PaymentMethodsList(ref int Total)
        {
            DataTable dt = null;
            try
            {
                _sqlP = new[] 
                {             
                    new SqlParameter("@Qstatus",0)
                };
                _sqlP[0].Direction = System.Data.ParameterDirection.Output;
                dt = _dbAccess.GetDataTable("PaymentMethodsList", ref _sqlP);
                Total = Convert.ToInt32(_sqlP[0].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
    }
}
