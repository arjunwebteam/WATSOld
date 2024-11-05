using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class Volunteers
    {
        WATS.DAL.Volunteers _Volunteers = new WATS.DAL.Volunteers();

        #region Admin

        #region Methods

        public Int64 InsertVolunteers(Entities.Volunteers objVolunteers)
        {
            Int64 _status = 0;
            if (objVolunteers != null)
            {
                _status = _Volunteers.InsertVolunteers(objVolunteers);

            }
            return _status;
        }

        public Int64 DeleteVolunteer(Int64 VolunteerId)
        {
            Int64 _status = 0;
            _status = _Volunteers.DeleteVolunteer(VolunteerId);
            return _status;
        }

        public Int64 UpdateVolunteerstatus(Int64 VolunteerId)
        {
            Int64 _status = 0;
            _status = _Volunteers.UpdateVolunteerstatus(VolunteerId);
            return _status;
        }
        
        #endregion

        #region Entities filling

        public WATS.Entities.Volunteers GetVolunteerById(Int64 VolunteerId, ref int status)
        {
            WATS.Entities.Volunteers objVolunteers = new WATS.Entities.Volunteers();
            DataTable dt = new DataTable();
            if (VolunteerId != 0)
            {
                dt = _Volunteers.GetVolunteerById(VolunteerId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objVolunteers.VolunteerId = Convert.ToInt64(dt.Rows[0]["VolunteerId"].ToString());
                    objVolunteers.VolunteerCategoryId = (dt.Rows[0]["VolunteerCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["VolunteerCategoryId"]) : 0);
                    objVolunteers.EventId = (dt.Rows[0]["EventId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["EventId"]) : 0);
                    objVolunteers.TRegistrationId = (dt.Rows[0]["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["TRegistrationId"]) : 0);

                    objVolunteers.FirstName = dt.Rows[0]["FirstName"].ToString();
                    objVolunteers.LastName = dt.Rows[0]["LastName"].ToString();
                    objVolunteers.Email = dt.Rows[0]["Email"].ToString();
                    objVolunteers.PhoneNo = (dt.Rows[0]["PhoneNo"] != DBNull.Value ? dt.Rows[0]["PhoneNo"].ToString() : null);
                    objVolunteers.Address = (dt.Rows[0]["Address"] != DBNull.Value ? dt.Rows[0]["Address"].ToString() : null);
                    objVolunteers.Comment = (dt.Rows[0]["Comment"] != DBNull.Value ? dt.Rows[0]["Comment"].ToString() : null);
                    objVolunteers.Profile = (dt.Rows[0]["Profile"] != DBNull.Value ? dt.Rows[0]["Profile"].ToString() : null);
                    objVolunteers.Password = (dt.Rows[0]["Password"] != DBNull.Value ? dt.Rows[0]["Password"].ToString() : null);
                    objVolunteers.CompanyName = (dt.Rows[0]["CompanyName"] != DBNull.Value ? dt.Rows[0]["CompanyName"].ToString() : null);
                    objVolunteers.Designation = (dt.Rows[0]["Designation"] != DBNull.Value ? dt.Rows[0]["Designation"].ToString() : null);
                    objVolunteers.HoursSpent = (dt.Rows[0]["HoursSpent"] != DBNull.Value ? dt.Rows[0]["HoursSpent"].ToString() : null);
                    objVolunteers.SchoolName = (dt.Rows[0]["SchoolName"] != DBNull.Value ? dt.Rows[0]["SchoolName"].ToString() : null);
                    objVolunteers.Gradeinschool = (dt.Rows[0]["Gradeinschool"] != DBNull.Value ? dt.Rows[0]["Gradeinschool"].ToString() : null);
                    objVolunteers.Age = (dt.Rows[0]["Age"] != DBNull.Value ? dt.Rows[0]["Age"].ToString() : null);
                    objVolunteers.Notes = (dt.Rows[0]["Notes"] != DBNull.Value ? dt.Rows[0]["Notes"].ToString() : null);
                    objVolunteers.Field1 = (dt.Rows[0]["Field1"] != DBNull.Value ? dt.Rows[0]["Field1"].ToString() : null);
                    objVolunteers.Field2 = (dt.Rows[0]["Field2"] != DBNull.Value ? dt.Rows[0]["Field2"].ToString() : null);
                    objVolunteers.Field3 = (dt.Rows[0]["Field3"] != DBNull.Value ? dt.Rows[0]["Field3"].ToString() : null);
                    objVolunteers.Field4 = (dt.Rows[0]["Field4"] != DBNull.Value ? dt.Rows[0]["Field4"].ToString() : null);
                    objVolunteers.IsActive = (dt.Rows[0]["IsActive"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsActive"]) : false);
                    objVolunteers.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objVolunteers.UpdatedDate = Convert.ToDateTime(dt.Rows[0]["UpdatedDate"].ToString());

                }
            }
            return objVolunteers;
        }
        
        public List<WATS.Entities.Volunteers> GetVolunteersListByVariable( string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Volunteers> lstVolunteers = new List<WATS.Entities.Volunteers>();
            DataTable dt = _Volunteers.GetVolunteersListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Volunteers.GetVolunteersListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Volunteers objVolunteers = new WATS.Entities.Volunteers();

                    objVolunteers.RId = Convert.ToInt64(dr["RId"].ToString());
                    objVolunteers.VolunteerId = Convert.ToInt64(dr["VolunteerId"].ToString());
                    objVolunteers.VolunteerCategoryId = (dr["VolunteerCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["VolunteerCategoryId"]) : 0);
                    objVolunteers.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objVolunteers.TRegistrationId = (dr["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dr["TRegistrationId"]) : 0);
                    objVolunteers.FirstName = dr["FirstName"].ToString();
                    objVolunteers.LastName = dr["LastName"].ToString();
                    objVolunteers.Email = dr["Email"].ToString();
                    objVolunteers.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : "");
                    objVolunteers.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : "");
                    objVolunteers.Comment = (dr["Comment"] != DBNull.Value ? dr["Comment"].ToString() : "");
                    objVolunteers.CompanyName = (dr["CompanyName"] != DBNull.Value ? dr["CompanyName"].ToString() : "");
                    objVolunteers.Designation = (dr["Designation"] != DBNull.Value ? dr["Designation"].ToString() : "");
                    objVolunteers.HoursSpent = (dr["HoursSpent"] != DBNull.Value ? dr["HoursSpent"].ToString() : "");
                    objVolunteers.SchoolName = (dr["SchoolName"] != DBNull.Value ? dr["SchoolName"].ToString() : "");
                    objVolunteers.Gradeinschool = (dr["Gradeinschool"] != DBNull.Value ? dr["Gradeinschool"].ToString() : "");
                    objVolunteers.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : "");
                    objVolunteers.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : "");
                    objVolunteers.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : "");
                    objVolunteers.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : "");
                    objVolunteers.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : "");
                    objVolunteers.Field4 = (dr["Field4"] != DBNull.Value ? dr["Field4"].ToString() : "");
                    objVolunteers.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objVolunteers.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                    objVolunteers.UpdatedBy = dr["UpdatedBy"].ToString();
                  

                    lstVolunteers.Add(objVolunteers);
                }
            }
            return lstVolunteers;
        }

        public Entities.Volunteers VolunteerValidationByEmail(string Email, ref int status)
        {
            WATS.Entities.Volunteers objVolunteers = new WATS.Entities.Volunteers();
            DataTable dt = _Volunteers.VolunteerValidationByEmail(Email, ref status);

            if (Email != null && Email.Trim() != "")
            {
                if (dt.Rows.Count == 1)
                {
                    objVolunteers.VolunteerId = Convert.ToInt64(dt.Rows[0]["VolunteerId"]);
                    objVolunteers.FirstName = dt.Rows[0]["FirstName"].ToString();
                    objVolunteers.LastName = dt.Rows[0]["LastName"].ToString();
                    objVolunteers.Email = dt.Rows[0]["Email"].ToString();          
                }
            }
            return objVolunteers;
        }

        #endregion

        #endregion

        #region Front-end

        public List<WATS.Entities.Volunteers> FEGetVolunteersList(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Volunteers> lstVolunteers = new List<WATS.Entities.Volunteers>();
            DataTable dt = _Volunteers.FEGetVolunteersList(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Volunteers.FEGetVolunteersList(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Volunteers objVolunteers = new WATS.Entities.Volunteers();

                    objVolunteers.VolunteerId = Convert.ToInt64(dr["VolunteerId"]);
                    objVolunteers.VolunteerCategoryId = (dr["VolunteerCategoryId"] != DBNull.Value ? Convert.ToInt64(dr["VolunteerCategoryId"]) : 0);
                    objVolunteers.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objVolunteers.TRegistrationId = (dr["TRegistrationId"] != DBNull.Value ? Convert.ToInt64(dr["TRegistrationId"]) : 0);
                    objVolunteers.FirstName = dr["FirstName"].ToString();
                    objVolunteers.LastName = dr["LastName"].ToString();
                    objVolunteers.Email = dr["Email"].ToString();
                    objVolunteers.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                    objVolunteers.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
                    objVolunteers.Comment = (dr["Comment"] != DBNull.Value ? dr["Comment"].ToString() : null);
                    objVolunteers.Profile = (dr["Profile"] != DBNull.Value ? dr["Profile"].ToString() : null);
                    objVolunteers.Password = (dr["Password"] != DBNull.Value ? dr["Password"].ToString() : null);
                    objVolunteers.CompanyName = (dr["CompanyName"] != DBNull.Value ? dr["CompanyName"].ToString() : null);
                    objVolunteers.Designation = (dr["Designation"] != DBNull.Value ? dr["Designation"].ToString() : null);
                    objVolunteers.HoursSpent = (dr["HoursSpent"] != DBNull.Value ? dr["HoursSpent"].ToString() : null);
                    objVolunteers.SchoolName = (dr["SchoolName"] != DBNull.Value ? dr["SchoolName"].ToString() : null);
                    objVolunteers.Gradeinschool = (dr["Gradeinschool"] != DBNull.Value ? dr["Gradeinschool"].ToString() : null);
                    objVolunteers.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
                    objVolunteers.Notes = (dr["Notes"] != DBNull.Value ? dr["Notes"].ToString() : null);
                    objVolunteers.Field1 = (dr["Field1"] != DBNull.Value ? dr["Field1"].ToString() : null);
                    objVolunteers.Field2 = (dr["Field2"] != DBNull.Value ? dr["Field2"].ToString() : null);
                    objVolunteers.Field3 = (dr["Field3"] != DBNull.Value ? dr["Field3"].ToString() : null);
                    objVolunteers.Field4 = (dr["Field4"] != DBNull.Value ? dr["Field4"].ToString() : null);

                    objVolunteers.IsActive = (dr["IsActive"] != DBNull.Value ? Convert.ToBoolean(dr["IsActive"]) : false);
                    objVolunteers.UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"]);
                    objVolunteers.UpdatedBy = dr["UpdatedBy"].ToString();
                    objVolunteers.InsertedDate = Convert.ToDateTime(dr["InsertedDate"]);
                    objVolunteers.InsertedBy = dr["InsertedBy"].ToString();
                    lstVolunteers.Add(objVolunteers);
                }

            }
            return lstVolunteers;
        }
        public Int64 FEVolunteerInsert(Entities.Volunteers objVolunteer)
        {
            Int64 _status = 0;
            if (objVolunteer != null)
            {
                _status = _Volunteers.FEVolunteerInsert(objVolunteer);

            }
            return _status;
        }


        #endregion
    }
}
