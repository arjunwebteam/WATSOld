using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WATS.BLL
{
  public  class TeluguBadiOrders
    {
        WATS.DAL.TeluguBadiOrders _TeluguBadiOrders = new WATS.DAL.TeluguBadiOrders();

        public Int64 DeleteTeluguBadiOrders(Int64 OrderId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiOrders.DeleteTeluguBadiOrders(OrderId);
            return _status;
        }

        public Int64 InsertTeluguBadiOrder(Entities.TeluguBadiOrders objTeluguBadiOrders)
        {
            Int64 _status = 0;
            if (objTeluguBadiOrders != null)
            {
                _status = _TeluguBadiOrders.InsertTeluguBadiOrder(objTeluguBadiOrders);

            }
            return _status;
        }


        public WATS.Entities.TeluguBadiOrders GetTeluguBadiOrdersById(Int64 OrderId, ref int status)
        {
            WATS.Entities.TeluguBadiOrders objTeluguBadiOrders = new WATS.Entities.TeluguBadiOrders();
            DataTable dt = new DataTable();
            if (OrderId != 0)
            {
                dt = _TeluguBadiOrders.GetTeluguBadiOrdersById(OrderId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objTeluguBadiOrders.OrderId = Convert.ToInt64(dt.Rows[0]["OrderId"].ToString());
                    objTeluguBadiOrders.TRegistrationId = (dt.Rows[0]["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["TRegistrationId"]) : 0);
                    objTeluguBadiOrders.TeluguBadiTypeId = (dt.Rows[0]["TeluguBadiTypeId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["TeluguBadiTypeId"]) : 0);
                    objTeluguBadiOrders.Amount = (dt.Rows[0]["Amount"] != DBNull.Value ? Convert.ToDecimal(dt.Rows[0]["Amount"]) : 0);
                    objTeluguBadiOrders.TransactionId = dt.Rows[0]["TransactionId"].ToString();
                    objTeluguBadiOrders.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objTeluguBadiOrders.PaymentMethod = dt.Rows[0]["PaymentMethod"].ToString();
                    objTeluguBadiOrders.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objTeluguBadiOrders.OrderDate = (dt.Rows[0]["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["OrderDate"]) : DateTime.MinValue);
                    objTeluguBadiOrders.OrderDate1 = objTeluguBadiOrders.OrderDate.ToString("dd/MM/yyyy");

                    objTeluguBadiOrders.PaymentBy = dt.Rows[0]["PaymentBy"].ToString();
                    objTeluguBadiOrders.ExpiryDate = (dt.Rows[0]["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]) : DateTime.MinValue);
                    objTeluguBadiOrders.ExpiryDate1 = objTeluguBadiOrders.ExpiryDate.ToString("dd/MM/yyyy");

                    objTeluguBadiOrders.Type = (dt.Rows[0]["Type"] != DBNull.Value ? dt.Rows[0]["Type"].ToString() : "");
                    objTeluguBadiOrders.FatherFirstName = (dt.Rows[0]["FatherFirstName"] != DBNull.Value ? dt.Rows[0]["FatherFirstName"].ToString() : "");
                    objTeluguBadiOrders.FatherLastName = (dt.Rows[0]["FatherLastName"] != DBNull.Value ? dt.Rows[0]["FatherLastName"].ToString() : "");
                    objTeluguBadiOrders.UpdatedBy = (dt.Rows[0]["UpdatedBy"] != DBNull.Value ? dt.Rows[0]["UpdatedBy"].ToString() : "");
                    objTeluguBadiOrders.UpdatedDate = (dt.Rows[0]["UpdatedDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["UpdatedDate"]) : DateTime.MinValue);

                }
            }
            return objTeluguBadiOrders;
        }


        public List<WATS.Entities.TeluguBadiOrders> GetTeluguBadiOrdersList(Int64 TRegistrationId,ref int status)
        {
            List<WATS.Entities.TeluguBadiOrders> lstTeluguBadiOrders = new List<Entities.TeluguBadiOrders>();
            DataTable dt = _TeluguBadiOrders.GetTeluguBadiOrdersList(TRegistrationId,ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.TeluguBadiOrders objTeluguBadiOrders = new WATS.Entities.TeluguBadiOrders();

                     objTeluguBadiOrders.OrderId = Convert.ToInt64(dr["OrderId"].ToString());
                    objTeluguBadiOrders.TRegistrationId = (dr["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dr["TRegistrationId"]) : 0);
                    objTeluguBadiOrders.TeluguBadiTypeId = (dr["TeluguBadiTypeId"] != DBNull.Value ? Convert.ToInt64(dr["TeluguBadiTypeId"]) : 0);
                    objTeluguBadiOrders.Type = dr["Type"].ToString();
                    objTeluguBadiOrders.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    objTeluguBadiOrders.TransactionId = dt.Rows[0]["TransactionId"].ToString();
                    objTeluguBadiOrders.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objTeluguBadiOrders.PaymentMethod = dt.Rows[0]["PaymentMethod"].ToString();
                    objTeluguBadiOrders.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objTeluguBadiOrders.PaymentStatus = dt.Rows[0]["PaymentStatus"].ToString();
                    objTeluguBadiOrders.OrderDate = (dt.Rows[0]["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["OrderDate"]) : DateTime.MinValue);
                    objTeluguBadiOrders.PaymentBy = dt.Rows[0]["PaymentBy"].ToString();
                    objTeluguBadiOrders.ExpiryDate = (dt.Rows[0]["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]) : DateTime.MinValue);
                    objTeluguBadiOrders.FatherFirstName = (dr["FatherFirstName"] != DBNull.Value ? dr["FatherFirstName"].ToString() : "");
                    objTeluguBadiOrders.FatherLastName = (dr["FatherLastName"] != DBNull.Value ? dr["FatherLastName"].ToString() : "");
                    objTeluguBadiOrders.UpdatedBy = dr["UpdatedBy"].ToString();
                    objTeluguBadiOrders.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());

                    lstTeluguBadiOrders.Add(objTeluguBadiOrders);
                }

            }
            return lstTeluguBadiOrders;
        }

        public List<WATS.Entities.TeluguBadiOrders> GetTeluguBadiOrdersListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.TeluguBadiOrders> lstTeluguBadiOrders = new List<WATS.Entities.TeluguBadiOrders>();
            DataTable dt = _TeluguBadiOrders.GetTeluguBadiOrdersListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _TeluguBadiOrders.GetTeluguBadiOrdersListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.TeluguBadiOrders objTeluguBadiOrders = new WATS.Entities.TeluguBadiOrders();

                    objTeluguBadiOrders.RId = Convert.ToInt64(dr["RId"].ToString());
                    objTeluguBadiOrders.OrderId = Convert.ToInt64(dr["OrderId"].ToString());
                    objTeluguBadiOrders.TRegistrationId = (dr["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dr["TRegistrationId"]) : 0);
                    objTeluguBadiOrders.TeluguBadiTypeId = (dr["TeluguBadiTypeId"] != DBNull.Value ? Convert.ToInt64(dr["TeluguBadiTypeId"]) : 0);
                    objTeluguBadiOrders.Type = dr["Type"].ToString();
                    objTeluguBadiOrders.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"]) : 0);
                    objTeluguBadiOrders.TransactionId = dt.Rows[0]["TransactionId"].ToString();
                    objTeluguBadiOrders.PaymentMethodId = (dt.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentMethodId"]) : 0);
                    objTeluguBadiOrders.PaymentMethod = dt.Rows[0]["PaymentMethod"].ToString();
                    objTeluguBadiOrders.PaymentStatusId = (dt.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["PaymentStatusId"]) : 0);
                    objTeluguBadiOrders.PaymentStatus = dt.Rows[0]["PaymentStatus"].ToString();
                    objTeluguBadiOrders.OrderDate = (dt.Rows[0]["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["OrderDate"]) : DateTime.MinValue);
                    objTeluguBadiOrders.PaymentBy = dt.Rows[0]["PaymentBy"].ToString();
                    objTeluguBadiOrders.ExpiryDate = (dt.Rows[0]["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["ExpiryDate"]) : DateTime.MinValue);
                    objTeluguBadiOrders.FatherFirstName = (dr["FatherFirstName"] != DBNull.Value ? dr["FatherFirstName"].ToString() : "");
                    objTeluguBadiOrders.FatherLastName = (dr["FatherLastName"] != DBNull.Value ? dr["FatherLastName"].ToString() : "");
                    objTeluguBadiOrders.UpdatedBy = dr["UpdatedBy"].ToString();
                    objTeluguBadiOrders.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());

                    lstTeluguBadiOrders.Add(objTeluguBadiOrders);
                }
            }
            return lstTeluguBadiOrders;
        }


        public Entities.TeluguBadiRegistrations AddTeluguBadiRequirement(ref int status)
        {
            DataSet ds = _TeluguBadiOrders.AddTeluguBadiRequirement(ref status);
            Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = new Entities.TeluguBadiRegistrations();
            List<Entities.PaymentMethods> lstPaymentMethod = new List<Entities.PaymentMethods>();
            List<Entities.TeluguBadiTypes> lstTeluguBadiTypes = new List<Entities.TeluguBadiTypes>();
            List<Entities.PaymentStatus> lstPaymentStatus = new List<Entities.PaymentStatus>();

            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Entities.TeluguBadiTypes objTeluguBadiTypes = new Entities.TeluguBadiTypes();

                    objTeluguBadiTypes.TeluguBadiTypeId = Convert.ToInt64(dr["TeluguBadiTypeId"]);
                    objTeluguBadiTypes.Type = dr["Type"].ToString();
                    objTeluguBadiTypes.Price = Convert.ToDecimal(dr["Price"]);
                    lstTeluguBadiTypes.Add(objTeluguBadiTypes);
                }
            }
            objTeluguBadiRegistrations.lstTeluguBadiTypes = lstTeluguBadiTypes;

            if (ds.Tables[1].Rows.Count != 0)
            {

                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    Entities.PaymentStatus objPaymentStatus = new Entities.PaymentStatus();

                    objPaymentStatus.PaymentStatusId = Convert.ToInt64(dr["PaymentStatusId"]);
                    objPaymentStatus.PaymentStatus1 = dr["PaymentStatus"].ToString();

                    lstPaymentStatus.Add(objPaymentStatus);
                }
            }
            objTeluguBadiRegistrations.lstPaymentStatus = lstPaymentStatus;

            if (ds.Tables[2].Rows.Count != 0)
            {

                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    Entities.PaymentMethods objPaymentMethod = new Entities.PaymentMethods();

                    objPaymentMethod.PaymentMethodId = Convert.ToInt64(dr["PaymentMethodId"]);
                    objPaymentMethod.PaymentMethod = dr["PaymentMethod"].ToString();

                    lstPaymentMethod.Add(objPaymentMethod);
                }
            }
            objTeluguBadiRegistrations.lstPaymentMethod = lstPaymentMethod;

            return objTeluguBadiRegistrations;
        }



    }
}
