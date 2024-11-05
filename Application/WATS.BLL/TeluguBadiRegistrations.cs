using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace WATS.BLL
{
   public class TeluguBadiRegistrations
    {
        WATS.DAL.TeluguBadiRegistrations _TeluguBadiRegistrations = new WATS.DAL.TeluguBadiRegistrations();

        #region Methods

        public Int64 InsertTeluguBadiRegistrations(Entities.TeluguBadiRegistrations objTeluguBadiRegistrations)
        {
            Int64 _status = 0;
            if (objTeluguBadiRegistrations != null)
            {
                _status = _TeluguBadiRegistrations.InsertTeluguBadiRegistrations(objTeluguBadiRegistrations);

            }
            return _status;
        }

        public Int64 FEInsertTeluguBadiRegistrations(Entities.TeluguBadiRegistrations objTeluguBadiRegistrations, ref Int64 TRegistrationId)
        {
            Int64 _status = 0;
            if (objTeluguBadiRegistrations != null)
            {
                _status = _TeluguBadiRegistrations.FEInsertTeluguBadiRegistrations(objTeluguBadiRegistrations, ref TRegistrationId);

            }
            return _status;
        }

        public Int64 InsertTeluguBadiStudents(Entities.TeluguBadiStudents objTeluguBadiStudents)
        {
            Int64 _status = 0;
            if (objTeluguBadiStudents != null)
            {
                _status = _TeluguBadiRegistrations.InsertTeluguBadiStudents(objTeluguBadiStudents);

            }
            return _status;
        }

        public Int64 DeleteTeluguBadiStudents(Int64 TStudentId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiRegistrations.DeleteTeluguBadiStudents(TStudentId);
            return _status;
        }


        public Int64 DeleteTeluguBadiRegistrations(Int64 TRegistrationId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiRegistrations.DeleteTeluguBadiRegistrations(TRegistrationId);
            return _status;
        }

        public Int64 UpdateTeluguBadiRegistrationsStatus(Int64 TRegistrationId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiRegistrations.UpdateTeluguBadiRegistrationsStatus(TRegistrationId);
            return _status;
        }

        public Int64 UpdateTeluguBadiRegistrationsDisplayOrder(int DisplayOrder, Int64 TRegistrationId)
        {
            Int64 _status = 0;
            _status = _TeluguBadiRegistrations.UpdateTeluguBadiRegistrationsDisplayOrder(DisplayOrder, TRegistrationId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.TeluguBadiRegistrations> GetTeluguBadiRegistrationsList(ref int status)
        {
            List<WATS.Entities.TeluguBadiRegistrations> lstTeluguBadiRegistrations = new List<Entities.TeluguBadiRegistrations>();
            DataTable dt = _TeluguBadiRegistrations.GetTeluguBadiRegistrationsList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.TeluguBadiRegistrations objlstTeluguBadiRegistrations = new WATS.Entities.TeluguBadiRegistrations();

                    objlstTeluguBadiRegistrations.TRegistrationId = Convert.ToInt64(dr["TRegistrationId"].ToString());
                    objlstTeluguBadiRegistrations.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstTeluguBadiRegistrations.FatherFirstName = (dr["FatherFirstName"] != DBNull.Value ? dr["FatherFirstName"].ToString() : "");
                    objlstTeluguBadiRegistrations.FatherLastName = (dr["FatherLastName"] != DBNull.Value ? dr["FatherLastName"].ToString() : "");
                    objlstTeluguBadiRegistrations.FatherEmail = (dr["FatherEmail"] != DBNull.Value ? dr["FatherEmail"].ToString() : "");
                    objlstTeluguBadiRegistrations.FatherPhoneNo = (dr["FatherPhoneNo"] != DBNull.Value ? dr["FatherPhoneNo"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherFirstName = (dr["MotherFirstName"] != DBNull.Value ? dr["MotherFirstName"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherLastName = (dr["MotherLastName"] != DBNull.Value ? dr["MotherLastName"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherEmail = (dr["MotherEmail"] != DBNull.Value ? dr["MotherEmail"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherPhoneNo = (dr["MotherPhoneNo"] != DBNull.Value ? dr["MotherPhoneNo"].ToString() : "");
                    objlstTeluguBadiRegistrations.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : "");
                    objlstTeluguBadiRegistrations.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : "");
                    objlstTeluguBadiRegistrations.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : "");
                    objlstTeluguBadiRegistrations.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : "");
                    objlstTeluguBadiRegistrations.TeluguBadiCenterName = (dr["TeluguBadiCenterName"] != DBNull.Value ? dr["TeluguBadiCenterName"].ToString() : "");
                    objlstTeluguBadiRegistrations.VolunteerFor = (dr["VolunteerFor"] != DBNull.Value ? dr["VolunteerFor"].ToString() : "");
                    objlstTeluguBadiRegistrations.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstTeluguBadiRegistrations.InsertedBy = dr["InsertedBy"].ToString();
                    objlstTeluguBadiRegistrations.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstTeluguBadiRegistrations.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstTeluguBadiRegistrations.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());

                   
                    lstTeluguBadiRegistrations.Add(objlstTeluguBadiRegistrations);
                }

            }
            return lstTeluguBadiRegistrations;
        }

        public WATS.Entities.TeluguBadiRegistrations GetTeluguBadiRegistrationsById(Int64 TRegistrationId, ref int status)
        {
            WATS.Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = new WATS.Entities.TeluguBadiRegistrations();
            DataTable dt = new DataTable();
            if (TRegistrationId != 0)
            {
                dt = _TeluguBadiRegistrations.GetTeluguBadiRegistrationsById(TRegistrationId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objTeluguBadiRegistrations.TRegistrationId = Convert.ToInt64(dt.Rows[0]["TRegistrationId"].ToString());
                    objTeluguBadiRegistrations.MemberId = (dt.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["MemberId"]) : 0);
                    objTeluguBadiRegistrations.FatherFirstName = (dt.Rows[0]["FatherFirstName"] != DBNull.Value ? dt.Rows[0]["FatherFirstName"].ToString() : null);
                    objTeluguBadiRegistrations.FatherLastName = (dt.Rows[0]["FatherLastName"] != DBNull.Value ? dt.Rows[0]["FatherLastName"].ToString() : null);
                    objTeluguBadiRegistrations.FatherEmail = (dt.Rows[0]["FatherEmail"] != DBNull.Value ? dt.Rows[0]["FatherEmail"].ToString() : null);
                    objTeluguBadiRegistrations.FatherPhoneNo = (dt.Rows[0]["FatherPhoneNo"] != DBNull.Value ? dt.Rows[0]["FatherPhoneNo"].ToString() : null);
                    objTeluguBadiRegistrations.MotherFirstName = (dt.Rows[0]["MotherFirstName"] != DBNull.Value ? dt.Rows[0]["MotherFirstName"].ToString() : null);
                    objTeluguBadiRegistrations.MotherLastName = (dt.Rows[0]["MotherLastName"] != DBNull.Value ? dt.Rows[0]["MotherLastName"].ToString() : null);
                    objTeluguBadiRegistrations.MotherEmail = (dt.Rows[0]["MotherEmail"] != DBNull.Value ? dt.Rows[0]["MotherEmail"].ToString() : null);
                    objTeluguBadiRegistrations.MotherPhoneNo = (dt.Rows[0]["MotherPhoneNo"] != DBNull.Value ? dt.Rows[0]["MotherPhoneNo"].ToString() : null);
                    objTeluguBadiRegistrations.Address = (dt.Rows[0]["Address"] != DBNull.Value ? dt.Rows[0]["Address"].ToString() : null);
                    objTeluguBadiRegistrations.City = (dt.Rows[0]["City"] != DBNull.Value ? dt.Rows[0]["City"].ToString() : null);
                    objTeluguBadiRegistrations.State = (dt.Rows[0]["State"] != DBNull.Value ? dt.Rows[0]["State"].ToString() : null);
                    objTeluguBadiRegistrations.ZipCode = (dt.Rows[0]["ZipCode"] != DBNull.Value ? dt.Rows[0]["ZipCode"].ToString() : null);
                    objTeluguBadiRegistrations.TeluguBadiCenterName = (dt.Rows[0]["TeluguBadiCenterName"] != DBNull.Value ? dt.Rows[0]["TeluguBadiCenterName"].ToString() : null);
                    objTeluguBadiRegistrations.VolunteerFor = (dt.Rows[0]["VolunteerFor"] != DBNull.Value ? dt.Rows[0]["VolunteerFor"].ToString() : null);
                    objTeluguBadiRegistrations.IsApproved = Convert.ToBoolean(dt.Rows[0]["IsApproved"]);
                    objTeluguBadiRegistrations.InsertedBy = dt.Rows[0]["InsertedBy"].ToString();
                    objTeluguBadiRegistrations.InsertedDate = Convert.ToDateTime(dt.Rows[0]["InsertedDate"].ToString());
                    objTeluguBadiRegistrations.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objTeluguBadiRegistrations.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString());


                }
            }
            return objTeluguBadiRegistrations;
        }

        public List<WATS.Entities.TeluguBadiRegistrations> GetTeluguBadiRegistrationsListByVariable(string Search, Int64 TeluguBadiTypeId, Int64 PaymentStatusId, string StartDate, string EndDate, string ExpiryDate, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.TeluguBadiRegistrations> lstTeluguBadiRegistrations = new List<WATS.Entities.TeluguBadiRegistrations>();
            DataTable dt = _TeluguBadiRegistrations.GetTeluguBadiRegistrationsListByVariable(Search, TeluguBadiTypeId, PaymentStatusId, StartDate, EndDate, ExpiryDate, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _TeluguBadiRegistrations.GetTeluguBadiRegistrationsListByVariable(Search, TeluguBadiTypeId, PaymentStatusId, StartDate, EndDate, ExpiryDate, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.TeluguBadiRegistrations objlstTeluguBadiRegistrations = new WATS.Entities.TeluguBadiRegistrations();

                    objlstTeluguBadiRegistrations.RId = Convert.ToInt64(dr["RId"].ToString());
                    objlstTeluguBadiRegistrations.TRegistrationId = Convert.ToInt64(dr["TRegistrationId"].ToString());
                    objlstTeluguBadiRegistrations.MemberId = (dr["MemberId"] != DBNull.Value ? Convert.ToInt64(dr["MemberId"]) : 0);
                    objlstTeluguBadiRegistrations.FatherFirstName = (dr["FatherFirstName"] != DBNull.Value ? dr["FatherFirstName"].ToString() : "");
                    objlstTeluguBadiRegistrations.FatherLastName = (dr["FatherLastName"] != DBNull.Value ? dr["FatherLastName"].ToString() : "");
                    objlstTeluguBadiRegistrations.FatherEmail = (dr["FatherEmail"] != DBNull.Value ? dr["FatherEmail"].ToString() : "");
                    objlstTeluguBadiRegistrations.FatherPhoneNo = (dr["FatherPhoneNo"] != DBNull.Value ? dr["FatherPhoneNo"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherFirstName = (dr["MotherFirstName"] != DBNull.Value ? dr["MotherFirstName"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherLastName = (dr["MotherLastName"] != DBNull.Value ? dr["MotherLastName"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherEmail = (dr["MotherEmail"] != DBNull.Value ? dr["MotherEmail"].ToString() : "");
                    objlstTeluguBadiRegistrations.MotherPhoneNo = (dr["MotherPhoneNo"] != DBNull.Value ? dr["MotherPhoneNo"].ToString() : "");
                    objlstTeluguBadiRegistrations.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : "");
                    objlstTeluguBadiRegistrations.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : "");
                    objlstTeluguBadiRegistrations.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : "");
                    objlstTeluguBadiRegistrations.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : "");
                    objlstTeluguBadiRegistrations.TeluguBadiCenterName = (dr["TeluguBadiCenterName"] != DBNull.Value ? dr["TeluguBadiCenterName"].ToString() : "");
                    objlstTeluguBadiRegistrations.VolunteerFor = (dr["VolunteerFor"] != DBNull.Value ? dr["VolunteerFor"].ToString() : "");
                    objlstTeluguBadiRegistrations.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objlstTeluguBadiRegistrations.InsertedBy = dr["InsertedBy"].ToString();
                    objlstTeluguBadiRegistrations.InsertedDate = Convert.ToDateTime(dr["InsertedDate"].ToString());
                    objlstTeluguBadiRegistrations.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstTeluguBadiRegistrations.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"].ToString());
                    objlstTeluguBadiRegistrations.ExpiryDate = (dr["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dr["ExpiryDate"]) : DateTime.MinValue);
                    objlstTeluguBadiRegistrations.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : "");
                    objlstTeluguBadiRegistrations.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : "");
                    objlstTeluguBadiRegistrations.TeluguBadiTypeId = (dr["TeluguBadiTypeId"] != DBNull.Value ? Convert.ToInt64(dr["TeluguBadiTypeId"]) : 0);
                    objlstTeluguBadiRegistrations.Type = (dr["Type"] != DBNull.Value ? dr["Type"].ToString() : "");
       
                    lstTeluguBadiRegistrations.Add(objlstTeluguBadiRegistrations);
                }
            }
            return lstTeluguBadiRegistrations;
        }

        #endregion


        public Entities.TeluguBadiRegistrations GetTBudiRegistrationsFullDetailsById(Int64 TRegistrationId, ref int status)
        {
            DataSet ds0 = _TeluguBadiRegistrations.GetTBudiRegistrationsFullDetailsById(TRegistrationId, ref status);

            DataTable dt_TeluguBadiRegistrations = ds0.Tables[0];
            DataTable dt_TeluguBadiStudents = ds0.Tables[1];
            DataTable dt_TeluguBadiOrders = ds0.Tables[2];


            Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = new Entities.TeluguBadiRegistrations();
            List<Entities.TeluguBadiStudents> lstTeluguBadiStudents = new List<Entities.TeluguBadiStudents>();
            List<Entities.TeluguBadiOrders> lstTeluguBadiOrders = new List<Entities.TeluguBadiOrders>();

            if (dt_TeluguBadiRegistrations.Rows.Count == 1)
            {

                objTeluguBadiRegistrations.TRegistrationId = Convert.ToInt64(dt_TeluguBadiRegistrations.Rows[0]["TRegistrationId"]);
                objTeluguBadiRegistrations.MemberId = (dt_TeluguBadiRegistrations.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt32(dt_TeluguBadiRegistrations.Rows[0]["MemberId"]) : 0);
                objTeluguBadiRegistrations.FatherFirstName = (dt_TeluguBadiRegistrations.Rows[0]["FatherFirstName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherFirstName"].ToString() : null);
                objTeluguBadiRegistrations.FatherLastName = (dt_TeluguBadiRegistrations.Rows[0]["FatherLastName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherLastName"].ToString() : null);
                objTeluguBadiRegistrations.FatherEmail = (dt_TeluguBadiRegistrations.Rows[0]["FatherEmail"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherEmail"].ToString() : null);
                objTeluguBadiRegistrations.FatherPhoneNo = (dt_TeluguBadiRegistrations.Rows[0]["FatherPhoneNo"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherPhoneNo"].ToString() : null);
                objTeluguBadiRegistrations.MotherFirstName = (dt_TeluguBadiRegistrations.Rows[0]["MotherFirstName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherFirstName"].ToString() : null);
                objTeluguBadiRegistrations.MotherLastName = (dt_TeluguBadiRegistrations.Rows[0]["MotherLastName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherLastName"].ToString() : null);
                objTeluguBadiRegistrations.MotherEmail = (dt_TeluguBadiRegistrations.Rows[0]["MotherEmail"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherEmail"].ToString() : null);
                objTeluguBadiRegistrations.MotherPhoneNo = (dt_TeluguBadiRegistrations.Rows[0]["MotherPhoneNo"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherPhoneNo"].ToString() : null);
                objTeluguBadiRegistrations.Address = (dt_TeluguBadiRegistrations.Rows[0]["Address"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["Address"].ToString() : null);
                objTeluguBadiRegistrations.City = (dt_TeluguBadiRegistrations.Rows[0]["City"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["City"].ToString() : null);
                objTeluguBadiRegistrations.State = (dt_TeluguBadiRegistrations.Rows[0]["State"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["State"].ToString() : null);
                objTeluguBadiRegistrations.ZipCode = (dt_TeluguBadiRegistrations.Rows[0]["ZipCode"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["ZipCode"].ToString() : null);
                objTeluguBadiRegistrations.TeluguBadiCenterName = (dt_TeluguBadiRegistrations.Rows[0]["TeluguBadiCenterName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["TeluguBadiCenterName"].ToString() : null);
                objTeluguBadiRegistrations.VolunteerFor = (dt_TeluguBadiRegistrations.Rows[0]["VolunteerFor"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["VolunteerFor"].ToString() : null);
                objTeluguBadiRegistrations.IsApproved = Convert.ToBoolean(dt_TeluguBadiRegistrations.Rows[0]["IsApproved"]);
                objTeluguBadiRegistrations.InsertedBy = (dt_TeluguBadiRegistrations.Rows[0]["InsertedBy"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["InsertedBy"].ToString() : null);
                objTeluguBadiRegistrations.InsertedDate = Convert.ToDateTime(dt_TeluguBadiRegistrations.Rows[0]["InsertedDate"]);
                objTeluguBadiRegistrations.UpdatedBy = (dt_TeluguBadiRegistrations.Rows[0]["UpdatedBy"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["UpdatedBy"].ToString() : null);
                objTeluguBadiRegistrations.UpdatedDate = Convert.ToDateTime(dt_TeluguBadiRegistrations.Rows[0]["UpdatedDate"]);
          }

            if (dt_TeluguBadiStudents.Rows.Count != 0)
            {

                foreach (DataRow dr in dt_TeluguBadiStudents.Rows)
                {
                    Entities.TeluguBadiStudents objTeluguBadiStudents = new Entities.TeluguBadiStudents();

                    objTeluguBadiStudents.TStudentId = Convert.ToInt64(dr["TStudentId"]);
                    objTeluguBadiStudents.TRegistrationId = Convert.ToInt64(dr["TRegistrationId"]);
                    objTeluguBadiStudents.FirstName = dr["FirstName"].ToString();
                    objTeluguBadiStudents.LastName = dr["LastName"].ToString();
                    objTeluguBadiStudents.Age = (dr["Age"] != DBNull.Value ? Convert.ToInt32(dr["Age"].ToString()) : 0);
                    objTeluguBadiStudents.LevelOfferings = (dr["LevelOfferings"] != DBNull.Value ? dr["LevelOfferings"].ToString() : "");
                    objTeluguBadiStudents.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : "");

                    lstTeluguBadiStudents.Add(objTeluguBadiStudents);
                }
            }

            objTeluguBadiRegistrations.lstTeluguBadiStudents = lstTeluguBadiStudents;

            if (dt_TeluguBadiOrders.Rows.Count == 1)
            {
              
                objTeluguBadiRegistrations.objTeluguBadiOrders.OrderId = Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["OrderId"]);
                objTeluguBadiRegistrations.objTeluguBadiOrders.TRegistrationId = (dt_TeluguBadiOrders.Rows[0]["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["TRegistrationId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.TeluguBadiTypeId = (dt_TeluguBadiOrders.Rows[0]["TeluguBadiTypeId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["TeluguBadiTypeId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.Amount = (dt_TeluguBadiOrders.Rows[0]["Amount"] != DBNull.Value ? Convert.ToDecimal(dt_TeluguBadiOrders.Rows[0]["Amount"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.TransactionId = (dt_TeluguBadiOrders.Rows[0]["TransactionId"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["TransactionId"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentStatusId = (dt_TeluguBadiOrders.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["PaymentStatusId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentMethodId = (dt_TeluguBadiOrders.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["PaymentMethodId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentBy = (dt_TeluguBadiOrders.Rows[0]["PaymentBy"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["PaymentBy"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentStatus = (dt_TeluguBadiOrders.Rows[0]["PaymentStatus"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["PaymentStatus"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentMethod = (dt_TeluguBadiOrders.Rows[0]["PaymentMethod"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["PaymentMethod"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.OrderDate = (dt_TeluguBadiOrders.Rows[0]["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dt_TeluguBadiOrders.Rows[0]["OrderDate"]) : DateTime.MinValue);
                objTeluguBadiRegistrations.objTeluguBadiOrders.ExpiryDate = (dt_TeluguBadiOrders.Rows[0]["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dt_TeluguBadiOrders.Rows[0]["ExpiryDate"]) : DateTime.MinValue);
                objTeluguBadiRegistrations.objTeluguBadiOrders.UpdatedDate = Convert.ToDateTime(dt_TeluguBadiOrders.Rows[0]["UpdatedDate"]);
                objTeluguBadiRegistrations.objTeluguBadiOrders.UpdatedBy = dt_TeluguBadiOrders.Rows[0]["UpdatedBy"].ToString();
                objTeluguBadiRegistrations.objTeluguBadiOrders.FatherFirstName = (dt_TeluguBadiOrders.Rows[0]["FatherFirstName"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["FatherFirstName"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.FatherLastName = (dt_TeluguBadiOrders.Rows[0]["FatherLastName"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["FatherLastName"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.Type = (dt_TeluguBadiOrders.Rows[0]["Type"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["Type"].ToString() : null);

            }

            objTeluguBadiRegistrations.lstTeluguBadiOrders = lstTeluguBadiOrders;

            return objTeluguBadiRegistrations;
        }



        public Entities.TeluguBadiRegistrations GetTBudiRegistrationsFullDetailsByEmail(string Email, ref int status)
        {
            DataSet ds0 = _TeluguBadiRegistrations.GetTBudiRegistrationsFullDetailsByEmail(Email, ref status);

            DataTable dt_TeluguBadiRegistrations = ds0.Tables[0];
            DataTable dt_TeluguBadiStudents = ds0.Tables[1];
            DataTable dt_TeluguBadiOrders = ds0.Tables[2];


            Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = new Entities.TeluguBadiRegistrations();
            List<Entities.TeluguBadiStudents> lstTeluguBadiStudents = new List<Entities.TeluguBadiStudents>();
            List<Entities.TeluguBadiOrders> lstTeluguBadiOrders = new List<Entities.TeluguBadiOrders>();

            if (dt_TeluguBadiRegistrations.Rows.Count == 1)
            {

                objTeluguBadiRegistrations.TRegistrationId = Convert.ToInt64(dt_TeluguBadiRegistrations.Rows[0]["TRegistrationId"]);
                objTeluguBadiRegistrations.MemberId = (dt_TeluguBadiRegistrations.Rows[0]["MemberId"] != DBNull.Value ? Convert.ToInt32(dt_TeluguBadiRegistrations.Rows[0]["MemberId"]) : 0);
                objTeluguBadiRegistrations.FatherFirstName = (dt_TeluguBadiRegistrations.Rows[0]["FatherFirstName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherFirstName"].ToString() : null);
                objTeluguBadiRegistrations.FatherLastName = (dt_TeluguBadiRegistrations.Rows[0]["FatherLastName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherLastName"].ToString() : null);
                objTeluguBadiRegistrations.FatherEmail = (dt_TeluguBadiRegistrations.Rows[0]["FatherEmail"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherEmail"].ToString() : null);
                objTeluguBadiRegistrations.FatherPhoneNo = (dt_TeluguBadiRegistrations.Rows[0]["FatherPhoneNo"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["FatherPhoneNo"].ToString() : null);
                objTeluguBadiRegistrations.MotherFirstName = (dt_TeluguBadiRegistrations.Rows[0]["MotherFirstName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherFirstName"].ToString() : null);
                objTeluguBadiRegistrations.MotherLastName = (dt_TeluguBadiRegistrations.Rows[0]["MotherLastName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherLastName"].ToString() : null);
                objTeluguBadiRegistrations.MotherEmail = (dt_TeluguBadiRegistrations.Rows[0]["MotherEmail"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherEmail"].ToString() : null);
                objTeluguBadiRegistrations.MotherPhoneNo = (dt_TeluguBadiRegistrations.Rows[0]["MotherPhoneNo"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["MotherPhoneNo"].ToString() : null);
                objTeluguBadiRegistrations.Address = (dt_TeluguBadiRegistrations.Rows[0]["Address"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["Address"].ToString() : null);
                objTeluguBadiRegistrations.City = (dt_TeluguBadiRegistrations.Rows[0]["City"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["City"].ToString() : null);
                objTeluguBadiRegistrations.State = (dt_TeluguBadiRegistrations.Rows[0]["State"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["State"].ToString() : null);
                objTeluguBadiRegistrations.ZipCode = (dt_TeluguBadiRegistrations.Rows[0]["ZipCode"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["ZipCode"].ToString() : null);
                objTeluguBadiRegistrations.TeluguBadiCenterName = (dt_TeluguBadiRegistrations.Rows[0]["TeluguBadiCenterName"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["TeluguBadiCenterName"].ToString() : null);
                objTeluguBadiRegistrations.VolunteerFor = (dt_TeluguBadiRegistrations.Rows[0]["VolunteerFor"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["VolunteerFor"].ToString() : null);
                objTeluguBadiRegistrations.IsApproved = Convert.ToBoolean(dt_TeluguBadiRegistrations.Rows[0]["IsApproved"]);
                objTeluguBadiRegistrations.InsertedBy = (dt_TeluguBadiRegistrations.Rows[0]["InsertedBy"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["InsertedBy"].ToString() : null);
                objTeluguBadiRegistrations.InsertedDate = Convert.ToDateTime(dt_TeluguBadiRegistrations.Rows[0]["InsertedDate"]);
                objTeluguBadiRegistrations.UpdatedBy = (dt_TeluguBadiRegistrations.Rows[0]["UpdatedBy"] != DBNull.Value ? dt_TeluguBadiRegistrations.Rows[0]["UpdatedBy"].ToString() : null);
                objTeluguBadiRegistrations.UpdatedDate = Convert.ToDateTime(dt_TeluguBadiRegistrations.Rows[0]["UpdatedDate"]);
            }

            if (dt_TeluguBadiStudents.Rows.Count != 0)
            {

                foreach (DataRow dr in dt_TeluguBadiStudents.Rows)
                {
                    Entities.TeluguBadiStudents objTeluguBadiStudents = new Entities.TeluguBadiStudents();

                    objTeluguBadiStudents.TStudentId = Convert.ToInt64(dr["TStudentId"]);
                    objTeluguBadiStudents.TRegistrationId = Convert.ToInt64(dr["TRegistrationId"]);
                    objTeluguBadiStudents.FirstName = dr["FirstName"].ToString();
                    objTeluguBadiStudents.LastName = dr["LastName"].ToString();
                    objTeluguBadiStudents.Age = (dr["Age"] != DBNull.Value ? Convert.ToInt32(dr["Age"].ToString()) : 0);
                    objTeluguBadiStudents.LevelOfferings = (dr["LevelOfferings"] != DBNull.Value ? dr["LevelOfferings"].ToString() : "");
                    objTeluguBadiStudents.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : "");

                    lstTeluguBadiStudents.Add(objTeluguBadiStudents);
                }
            }

            objTeluguBadiRegistrations.lstTeluguBadiStudents = lstTeluguBadiStudents;

            if (dt_TeluguBadiOrders.Rows.Count == 1)
            {

                objTeluguBadiRegistrations.objTeluguBadiOrders.OrderId = Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["OrderId"]);
                objTeluguBadiRegistrations.objTeluguBadiOrders.TRegistrationId = (dt_TeluguBadiOrders.Rows[0]["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["TRegistrationId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.TeluguBadiTypeId = (dt_TeluguBadiOrders.Rows[0]["TeluguBadiTypeId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["TeluguBadiTypeId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.Amount = (dt_TeluguBadiOrders.Rows[0]["Amount"] != DBNull.Value ? Convert.ToDecimal(dt_TeluguBadiOrders.Rows[0]["Amount"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.TransactionId = (dt_TeluguBadiOrders.Rows[0]["TransactionId"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["TransactionId"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentStatusId = (dt_TeluguBadiOrders.Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["PaymentStatusId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentMethodId = (dt_TeluguBadiOrders.Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(dt_TeluguBadiOrders.Rows[0]["PaymentMethodId"]) : 0);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentBy = (dt_TeluguBadiOrders.Rows[0]["PaymentBy"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["PaymentBy"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentStatus = (dt_TeluguBadiOrders.Rows[0]["PaymentStatus"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["PaymentStatus"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.PaymentMethod = (dt_TeluguBadiOrders.Rows[0]["PaymentMethod"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["PaymentMethod"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.OrderDate = (dt_TeluguBadiOrders.Rows[0]["OrderDate"] != DBNull.Value ? Convert.ToDateTime(dt_TeluguBadiOrders.Rows[0]["OrderDate"]) : DateTime.MinValue);
                objTeluguBadiRegistrations.objTeluguBadiOrders.ExpiryDate = (dt_TeluguBadiOrders.Rows[0]["ExpiryDate"] != DBNull.Value ? Convert.ToDateTime(dt_TeluguBadiOrders.Rows[0]["ExpiryDate"]) : DateTime.MinValue);
                objTeluguBadiRegistrations.objTeluguBadiOrders.UpdatedDate = Convert.ToDateTime(dt_TeluguBadiOrders.Rows[0]["UpdatedDate"]);
                objTeluguBadiRegistrations.objTeluguBadiOrders.UpdatedBy = dt_TeluguBadiOrders.Rows[0]["UpdatedBy"].ToString();
                objTeluguBadiRegistrations.objTeluguBadiOrders.FatherFirstName = (dt_TeluguBadiOrders.Rows[0]["FatherFirstName"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["FatherFirstName"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.FatherLastName = (dt_TeluguBadiOrders.Rows[0]["FatherLastName"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["FatherLastName"].ToString() : null);
                objTeluguBadiRegistrations.objTeluguBadiOrders.Type = (dt_TeluguBadiOrders.Rows[0]["Type"] != DBNull.Value ? dt_TeluguBadiOrders.Rows[0]["Type"].ToString() : null);

            }

            objTeluguBadiRegistrations.lstTeluguBadiOrders = lstTeluguBadiOrders;

            return objTeluguBadiRegistrations;
        }

    }
}
