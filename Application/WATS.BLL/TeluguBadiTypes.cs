using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WATS.BLL
{
 public   class TeluguBadiTypes
    {
        WATS.DAL.TeluguBadiTypes _TeluguBadiTypes = new WATS.DAL.TeluguBadiTypes();

        #region Methods

        public Int64 InsertTeluguBadiTypes(Entities.TeluguBadiTypes objTeluguBadiTypes)
        {
            Int64 _status = 0;
            if (objTeluguBadiTypes != null)
            {
                _status = _TeluguBadiTypes.InsertTeluguBadiTypes(objTeluguBadiTypes);

            }
            return _status;
        }

        public Int64 DeleteTeluguBadiTypes(Int64 TeluguBadiTypeId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiTypes.DeleteTeluguBadiTypes(TeluguBadiTypeId);
            return _status;
        }

        public Int64 UpdateTeluguBadiTypesStatus(Int64 TeluguBadiTypeId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiTypes.UpdateTeluguBadiTypesStatus(TeluguBadiTypeId);
            return _status;
        }

        public Int64 UpdateTeluguBadiTypesDisplayOrder(int DisplayOrder, Int64 TeluguBadiTypeId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiTypes.UpdateTeluguBadiTypesDisplayOrder(DisplayOrder, TeluguBadiTypeId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.TeluguBadiTypes> GetTeluguBadiTypesList(ref int status)
        {
            List<WATS.Entities.TeluguBadiTypes> lstTeluguBadiTypes = new List<Entities.TeluguBadiTypes>();
            DataTable dt = _TeluguBadiTypes.GetTeluguBadiTypesList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.TeluguBadiTypes objlstTeluguBadiTypes = new WATS.Entities.TeluguBadiTypes();

                    objlstTeluguBadiTypes.TeluguBadiTypeId = Convert.ToInt64(dr["TeluguBadiTypeId"].ToString());
                    objlstTeluguBadiTypes.Type = dr["Type"].ToString();
                    objlstTeluguBadiTypes.Price = (dr["Price"] != DBNull.Value ? Convert.ToInt64(dr["Price"]) : 0);
                    objlstTeluguBadiTypes.ExpiryDate = (dr["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dr["ExpiryDate"]) : DateTime.MinValue);
                    objlstTeluguBadiTypes.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objlstTeluguBadiTypes.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt64(dr["OrderNo"]) : 0);
                    objlstTeluguBadiTypes.InsertedBy = dr["InsertedBy"].ToString();
                    objlstTeluguBadiTypes.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstTeluguBadiTypes.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstTeluguBadiTypes.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());

                    lstTeluguBadiTypes.Add(objlstTeluguBadiTypes);
                }

            }
            return lstTeluguBadiTypes;
        }

        public WATS.Entities.TeluguBadiTypes GetTeluguBadiTypesById(Int64 TeluguBadiTypeId, ref int status)
        {
            WATS.Entities.TeluguBadiTypes objTeluguBadiTypes = new WATS.Entities.TeluguBadiTypes();
            DataTable dt = new DataTable();
            if (TeluguBadiTypeId != 0)
            {
                dt = _TeluguBadiTypes.GetTeluguBadiTypesById(TeluguBadiTypeId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objTeluguBadiTypes.TeluguBadiTypeId = Convert.ToInt64(dt.Rows[0]["TeluguBadiTypeId"].ToString());
                    objTeluguBadiTypes.Type = dt.Rows[0]["Type"].ToString();
                    objTeluguBadiTypes.Price = (dt.Rows[0]["Price"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["Price"]) : 0);
                    objTeluguBadiTypes.Year = (dt.Rows[0]["Year"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["Year"]) : 0);
                    objTeluguBadiTypes.ExpiryDate = (dt.Rows[0]["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]) : DateTime.MinValue);
                    objTeluguBadiTypes.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objTeluguBadiTypes.OrderNo = (dt.Rows[0]["OrderNo"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["OrderNo"]) : 0);
                    objTeluguBadiTypes.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    objTeluguBadiTypes.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());
                    objTeluguBadiTypes.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objTeluguBadiTypes.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString());
                    objTeluguBadiTypes.ExpiryDate1 = objTeluguBadiTypes.ExpiryDate.ToString("dd/MM/yyyy");


                }
            }
            return objTeluguBadiTypes;
        }

        public List<WATS.Entities.TeluguBadiTypes> GetTeluguBadiTypesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.TeluguBadiTypes> lstTeluguBadiTypes = new List<WATS.Entities.TeluguBadiTypes>();
            DataTable dt = _TeluguBadiTypes.GetTeluguBadiTypesListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _TeluguBadiTypes.GetTeluguBadiTypesListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.TeluguBadiTypes objTeluguBadiTypes = new WATS.Entities.TeluguBadiTypes();

                    objTeluguBadiTypes.RId = Convert.ToInt64(dr["RId"].ToString());
                    objTeluguBadiTypes.TeluguBadiTypeId = Convert.ToInt64(dr["TeluguBadiTypeId"].ToString());
                    objTeluguBadiTypes.Type = dr["Type"].ToString();
                    objTeluguBadiTypes.Price = (dr["Price"] != DBNull.Value ? Convert.ToInt64(dr["Price"]) : 0);
                    objTeluguBadiTypes.ExpiryDate = (dr["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dr["ExpiryDate"]) : DateTime.MinValue);
                    objTeluguBadiTypes.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objTeluguBadiTypes.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt64(dr["OrderNo"]) : 0);
                    objTeluguBadiTypes.InsertedBy = dr["InsertedBy"].ToString();
                    objTeluguBadiTypes.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objTeluguBadiTypes.UpdatedBy = dr["UpdatedBy"].ToString();
                    objTeluguBadiTypes.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());

                    lstTeluguBadiTypes.Add(objTeluguBadiTypes);
                }
            }
            return lstTeluguBadiTypes;
        }

        #endregion
    }
}
