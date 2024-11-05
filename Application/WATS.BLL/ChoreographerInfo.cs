using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.BLL
{
   public class ChoreographerInfo
    { 

        WATS.DAL.ChoreographerInfo _ChoreographerInfo = new WATS.DAL.ChoreographerInfo();

        #region Methods

        public Int64 FEChoreographerInfoInsert(Entities.ChoreographerInfo objChoreographerInfo, ref string imageurl)
        {
            Int64 _status = 0;
            if (objChoreographerInfo != null)
            {
                _status = _ChoreographerInfo.FEChoreographerInfoInsert(objChoreographerInfo, ref imageurl);

            }
            return _status;
        }

        public Int64 ChangePassword(Int64 ChoreographerId, string Password)
        {
            Int64 _status = 0;
            if (ChoreographerId != 0 && Password != null && Password.Trim() != "")
            {
                _status = _ChoreographerInfo.ChangePassword(ChoreographerId, Password);
            }
            return _status;
        }

        public Entities.ChoreographerInfo GetChoreographerFullDetailsByEmail(string Email, ref int status)
        {
            DataSet ds0 = _ChoreographerInfo.GetChoreographerFullDetailsByEmail(Email, ref status);

            DataTable dt_Choreographers = ds0.Tables[0];
            DataTable dt_EventParticipants = ds0.Tables[1]; 


            Entities.ChoreographerInfo objChoreographerInfo = new Entities.ChoreographerInfo();
            List<Entities.CulturalParticipants> lstEventParticipantsC = new List<Entities.CulturalParticipants>();

            if (dt_Choreographers.Rows.Count == 1)
            {

                objChoreographerInfo.ChoreographerId = Convert.ToInt64(dt_Choreographers.Rows[0]["ChoreographerId"]);
                objChoreographerInfo.FirstName = dt_Choreographers.Rows[0]["FirstName"].ToString();
                objChoreographerInfo.LastName = dt_Choreographers.Rows[0]["LastName"].ToString();
                objChoreographerInfo.Email = dt_Choreographers.Rows[0]["Email"].ToString();
                objChoreographerInfo.Password = (dt_Choreographers.Rows[0]["Password"] != DBNull.Value ? dt_Choreographers.Rows[0]["Password"].ToString() : null);
                objChoreographerInfo.MobileNo = (dt_Choreographers.Rows[0]["MobileNo"] != DBNull.Value ? dt_Choreographers.Rows[0]["MobileNo"].ToString() : null);
                objChoreographerInfo.Passion = (dt_Choreographers.Rows[0]["Passion"] != DBNull.Value ? dt_Choreographers.Rows[0]["Passion"].ToString() : null);
                objChoreographerInfo.IsActive = Convert.ToBoolean(dt_Choreographers.Rows[0]["IsActive"]); 
            }

            if (dt_EventParticipants.Rows.Count != 0)
            {

                foreach (DataRow dr in dt_EventParticipants.Rows)
                {
                    Entities.CulturalParticipants objEventParticipants = new Entities.CulturalParticipants();

                    objEventParticipants.CulturalParticipantId = Convert.ToInt64(dr["CulturalParticipantId"]);
                    objEventParticipants.EventId = Convert.ToInt64(dr["EventId"]);
                    objEventParticipants.FirstName = dr["FirstName"].ToString();
                    objEventParticipants.LastName = dr["LastName"].ToString();
                    objEventParticipants.Email = dr["Email"].ToString();
                    objEventParticipants.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
                    objEventParticipants.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
                    objEventParticipants.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objEventParticipants.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    lstEventParticipantsC.Add(objEventParticipants);
                }
            }

            objChoreographerInfo.lstEventParticipantsC = lstEventParticipantsC;
             
            return objChoreographerInfo;
        }

        public string GetCPassword(Int64 _ChoreographerId, ref int _qstatus)
        {
            string _password = "";
            DataTable dt = _ChoreographerInfo.GetCPassword(_ChoreographerId, ref _qstatus);
            if (dt.Rows.Count == 1)
            {
                _password = dt.Rows[0]["Password"].ToString();
            }
            return _password;
        }


        public List<WATS.Entities.CulturalParticipants> GetEventParticipantsGetlistbyId(Int64 ChoreographerId, ref int Total)
        {
            List<WATS.Entities.CulturalParticipants> lstEventParticipants = new List<WATS.Entities.CulturalParticipants>();

            DataTable dt = _ChoreographerInfo.GetEventParticipantsGetlistbyId(ChoreographerId, ref Total);
            if (dt.Rows.Count == 0)
            {
                dt = _ChoreographerInfo.GetEventParticipantsGetlistbyId(ChoreographerId, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.CulturalParticipants objEventParticipants = new Entities.CulturalParticipants();

                    objEventParticipants.CulturalParticipantId = Convert.ToInt64(dr["CulturalParticipantId"]);
                    objEventParticipants.EventId = Convert.ToInt64(dr["EventId"]);
                    objEventParticipants.EventUserInfoId = Convert.ToInt64(dr["EventUserInfoId"]);
                    objEventParticipants.FirstName = dr["FirstName"].ToString();
                    objEventParticipants.LastName = dr["LastName"].ToString();
                    objEventParticipants.Email = dr["Email"].ToString();
                    objEventParticipants.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
                    objEventParticipants.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
                    objEventParticipants.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objEventParticipants.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
                    objEventParticipants.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);
                    objEventParticipants.CutOfDate = (dr["CutOfDate"] != DBNull.Value ? dr["CutOfDate"].ToString() : null);

                    lstEventParticipants.Add(objEventParticipants);
                }

            }
            return lstEventParticipants;
        }

        //public List<WATS.Entities.EventParticipants> GetEventParticipantsGetlistbyId(Int64 ChoreographerId, string Search, string Sort, int PageNo, int Items, ref int Total)
        //{
        //    List<WATS.Entities.EventParticipants> lstEventParticipants = new List<WATS.Entities.EventParticipants>();

        //    DataTable dt = _ChoreographerInfo.GetEventParticipantsGetlistbyId(ChoreographerId, Search, Sort, PageNo, Items, ref Total);
        //    if (dt.Rows.Count == 0 && PageNo != 0)
        //    {
        //        dt = _ChoreographerInfo.GetEventParticipantsGetlistbyId(ChoreographerId, Search, Sort, PageNo - 1, Items, ref Total);
        //    }
        //    if (dt.Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Entities.EventParticipants objEventParticipants = new Entities.EventParticipants();

        //            objEventParticipants.EventParticipantId = Convert.ToInt64(dr["EventParticipantId"]);
        //            objEventParticipants.EventId = Convert.ToInt64(dr["EventId"]);
        //            objEventParticipants.FirstName = dr["FirstName"].ToString();
        //            objEventParticipants.LastName = dr["LastName"].ToString();
        //            objEventParticipants.Email = dr["Email"].ToString();
        //            objEventParticipants.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
        //            objEventParticipants.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
        //            objEventParticipants.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
        //            objEventParticipants.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
        //            objEventParticipants.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);
        //            objEventParticipants.CutOfDate = (dr["CutOfDate"] != DBNull.Value ? dr["CutOfDate"].ToString() : null);

        //            lstEventParticipants.Add(objEventParticipants);
        //        }

        //    }
        //    return lstEventParticipants;
        //}



        #endregion
    }
}
