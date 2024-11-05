using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class MembershipTypes
    {
        DAL.MembershipTypes _MembershipType = new DAL.MembershipTypes();

        #region Methods

        public Int64 DeleteMembershipType(Int64 MembershipTypeId)
        {
            Int64 _status = 0;
            if (MembershipTypeId != 0)
            {
                _status = _MembershipType.DeleteMembershipType(MembershipTypeId);
            }
            return _status;
        }

        public Int64 InsertMembershipType(Entities.MembershipTypes objMembershipType)
        {
            Int64 _status = 0;
            if (objMembershipType != null)
            {
                _status = _MembershipType.InsertMembershipType(objMembershipType);
            }
            return _status;
        }

        #endregion

        #region Entity Loading

        public List<Entities.MembershipTypes> GetMembershipTypesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            DataTable dt = _MembershipType.GetMembershipTypesListByVariable(Search, Sort, PageNo, Items, ref Total);
            List<Entities.MembershipTypes> lstMembershipType = new List<Entities.MembershipTypes>();

            if (dt.Rows.Count == 0 && PageNo > 1)
            {
                dt = _MembershipType.GetMembershipTypesListByVariable(Search, Sort, PageNo, Items, ref Total);
            }

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.MembershipTypes objMembershipType = new Entities.MembershipTypes();

                    objMembershipType.RId = Convert.ToInt64(dr["Rid"]);
                    objMembershipType.MembershipType = dr["MembershipType"].ToString();
                    objMembershipType.MembershipTypeId = Convert.ToInt64(dr["MembershipTypeId"]);
                    objMembershipType.Price = Convert.ToDecimal(dr["Price"]);
                    objMembershipType.Validity = (dr["Validity"] != DBNull.Value ? Convert.ToInt64(dr["Validity"]) : 0);

                    lstMembershipType.Add(objMembershipType);
                }
            }
            return lstMembershipType;
        }

        public Entities.MembershipTypes GetMembershipTypeById(Int64 MembershipTypeId, ref int status)
        {
            DataTable dt = _MembershipType.GetMembershipTypeById(MembershipTypeId, ref status);
            Entities.MembershipTypes objMembershipType = new Entities.MembershipTypes();

            if (dt.Rows.Count == 1)
            {
                objMembershipType.MembershipTypeId = Convert.ToInt64(dt.Rows[0]["MembershipTypeId"]);
                objMembershipType.MembershipType = dt.Rows[0]["MembershipType"].ToString();
                objMembershipType.Price = Convert.ToDecimal(dt.Rows[0]["Price"]);
                objMembershipType.Validity = (dt.Rows[0]["Validity"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["Validity"]) : 0);
            }

            return objMembershipType;
        }

        public List<Entities.MembershipTypes> GetMembershipTypesList(ref int status)
        {
            DataTable dt = _MembershipType.GetMembershipTypesList(ref status);
            List<Entities.MembershipTypes> lstMembershipType = new List<Entities.MembershipTypes>();

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.MembershipTypes objMembershipType = new Entities.MembershipTypes();

                    objMembershipType.MembershipTypeId = Convert.ToInt64(dr["MembershipTypeId"]);
                    objMembershipType.MembershipType = dr["MembershipType"].ToString();
                    objMembershipType.Price =Convert.ToDecimal(dr["Price"]);
                    objMembershipType.Validity = Convert.ToInt64(dr["Validity"]);

                    lstMembershipType.Add(objMembershipType);
                }
            }

            return lstMembershipType;
        }

        #endregion
    }
}
