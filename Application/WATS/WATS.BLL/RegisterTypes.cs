using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class RegisterTypes
    {
        DAL.RegisterTypes _RegisterType = new DAL.RegisterTypes();

        #region Methods

        public Int64 DeleteRegisterType(Int64 ApplicationPageId)
        {
            Int64 _status = 0;
            if (ApplicationPageId != 0)
            {
                _status = _RegisterType.DeleteRegisterType(ApplicationPageId);
            }
            return _status;
        }

        public Int64 InsertRegisterType(Entities.RegisterTypes objRegisterType)
        {
            Int64 _status = 0;
            if (objRegisterType != null)
            {
                _status = _RegisterType.InsertRegisterType(objRegisterType);
            }
            return _status;
        }

        public Int64 ApproveRegisterType(Int64 RegisterTypeId)
        {
            Int64 _status = 0;
            if (RegisterTypeId != 0)
            {
                _status = _RegisterType.ApproveRegisterType(RegisterTypeId);
            }
            return _status;
        }

        #endregion

        #region Entity Loading

        public List<Entities.RegisterTypes> GetRegisterTypeList(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = _RegisterType.GetRegisterTypeList(Search, Sort, PageNo, Items, ref Total);
            List<Entities.RegisterTypes> lstRegisterType = new List<Entities.RegisterTypes>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.RegisterTypes objRegisterType = new Entities.RegisterTypes();
                    objRegisterType.RId = Convert.ToInt64(dr["Rid"]);
                    objRegisterType.RegisterTypeId = Convert.ToInt64(dr["RegisterTypeId"]);
                    objRegisterType.RegisterType = dr["RegisterType"].ToString();
                    objRegisterType.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objRegisterType.Amount = Convert.ToDecimal(dr["Amount"]);
                    objRegisterType.Duration = Convert.ToDecimal(dr["Duration"]);
                    objRegisterType.UpdatedBy = dr["UpdatedBy"].ToString();
                    objRegisterType.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

                    lstRegisterType.Add(objRegisterType);
                }
            }
            return lstRegisterType;
        }

        public List<Entities.RegisterTypes> RegisterTypeList(ref int status)
        {
            DataTable dt = _RegisterType.RegisterTypeList(ref status);
            List<Entities.RegisterTypes> lstRegisterType = new List<Entities.RegisterTypes>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.RegisterTypes objRegisterType = new Entities.RegisterTypes();
                    objRegisterType.RegisterTypeId = Convert.ToInt64(dr["RegisterTypeId"]);
                    objRegisterType.RegisterType = dr["RegisterType"].ToString();
                    objRegisterType.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objRegisterType.Amount = Convert.ToDecimal(dr["Amount"]);
                    objRegisterType.Duration = Convert.ToDecimal(dr["Duration"]);
                    objRegisterType.UpdatedBy = dr["UpdatedBy"].ToString();
                    objRegisterType.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);

                    lstRegisterType.Add(objRegisterType);
                }
            }
            return lstRegisterType;
        }

        public Entities.RegisterTypes GetRegisterTypeById(Int64 RegisterTypeId, ref int status)
        {
            DataTable dt = _RegisterType.GetRegisterTypeById(RegisterTypeId, ref status);
            Entities.RegisterTypes objRegisterType = new Entities.RegisterTypes();

            if (dt.Rows.Count != 0)
            {
                objRegisterType.RegisterTypeId = Convert.ToInt64(dt.Rows[0]["RegisterTypeId"]);
                objRegisterType.RegisterType = dt.Rows[0]["RegisterType"].ToString();
                objRegisterType.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                objRegisterType.Amount = Convert.ToDecimal(dt.Rows[0]["Amount"]);
                objRegisterType.Duration = Convert.ToDecimal(dt.Rows[0]["Duration"]);
                objRegisterType.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                objRegisterType.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]);
            }
            return objRegisterType;
        }

        #endregion
    }
}
