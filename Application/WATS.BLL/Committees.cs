using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;
namespace WATS.BLL
{
   public class Committees
    {
        WATS.DAL.Committees _Committees = new WATS.DAL.Committees();

        #region Admin

        #region Methods

        public Int64 InsertCommittees(Entities.Committees objCommittees, ref string ImageUrl)
        {
            Int64 _status = 0;
            if (objCommittees != null )
            {
                _status = _Committees.InsertCommittees(objCommittees, ref ImageUrl);

            }
            return _status;
        }

        public Int64 DeleteCommittee(Int64 CommitteeId)
        {
            Int64 _status = 0;
            _status = _Committees.DeleteCommittee(CommitteeId);
            return _status;
        }

        public Int64 UpdateCommitteeStatus(Int64 CommitteeId)
        {
            Int64 _status = 0;
            _status = _Committees.UpdateCommitteeStatus(CommitteeId);
            return _status;
        }

        public Int64 UpdateCommitteesDisplayOrder(int DisplayOrder, Int64 CommitteeId)
        {
            Int64 _status = 0;
            _status = _Committees.UpdateCommitteesDisplayOrder(DisplayOrder, CommitteeId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.Committees> GetCommitteesList(ref int status)
        {
            List<WATS.Entities.Committees> lstCommittees = new List<Entities.Committees>();
            DataTable dt = _Committees.GetCommitteesList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Committees objlstCommittees = new WATS.Entities.Committees();

                    objlstCommittees.CommitteeId =Convert.ToInt32( dr["CommitteeId"].ToString());
                    objlstCommittees.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
                    objlstCommittees.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                    objlstCommittees.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
                    objlstCommittees.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objlstCommittees.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
                    objlstCommittees.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objlstCommittees.ImageUrl = dr["ImageUrl"].ToString();
                    objlstCommittees.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0);
                    objlstCommittees.IsActive =Convert.ToBoolean(dr["IsActive"]);
                    objlstCommittees.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : null);
                    objlstCommittees.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstCommittees.UpdatedTime =Convert.ToDateTime(dr["UpdatedTime"].ToString());

                    lstCommittees.Add(objlstCommittees);
                }

            }
            return lstCommittees;
        }

        public WATS.Entities.Committees GetCommitteeById(Int64 CommitteeId, ref int status)
        {
            WATS.Entities.Committees objCommittees = new WATS.Entities.Committees();
            DataTable dt = new DataTable();
            if (CommitteeId != 0)
            {
                dt = _Committees.GetCommitteeById(CommitteeId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objCommittees.CommitteeId = Convert.ToInt64(dt.Rows[0]["CommitteeId"].ToString());
                    objCommittees.Name = (dt.Rows[0]["Name"] != DBNull.Value ? dt.Rows[0]["Name"].ToString() : null);
                    objCommittees.PhoneNo = (dt.Rows[0]["PhoneNo"] != DBNull.Value ? dt.Rows[0]["PhoneNo"].ToString() : null);
                    objCommittees.Address = (dt.Rows[0]["Address"] != DBNull.Value ? dt.Rows[0]["Address"].ToString() : null);
                    objCommittees.City = (dt.Rows[0]["City"] != DBNull.Value ? dt.Rows[0]["City"].ToString() : null);
                    objCommittees.State = (dt.Rows[0]["State"] != DBNull.Value ? dt.Rows[0]["State"].ToString() : null);
                    objCommittees.Email = (dt.Rows[0]["Email"] != DBNull.Value ? dt.Rows[0]["Email"].ToString() : null);
                    objCommittees.ImageUrl = (dt.Rows[0]["ImageUrl"] != DBNull.Value ? dt.Rows[0]["ImageUrl"].ToString() : null);
                    objCommittees.DisplayOrder = (dt.Rows[0]["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["DisplayOrder"]) : 0);
                    objCommittees.IsActive =Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objCommittees.Description = (dt.Rows[0]["Description"] != DBNull.Value ? dt.Rows[0]["Description"].ToString() : "");
                    objCommittees.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objCommittees.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"].ToString());
                  
                }
            }
            return objCommittees;
        }

        public List<WATS.Entities.CommitteeMembers> GetCommitteeMembersListById(Int64 CommitteeCategoryId, ref int status)
        {
            List<WATS.Entities.CommitteeMembers> lstCommitteeMembers = new List<WATS.Entities.CommitteeMembers>();
            DataTable dt = _Committees.GetCommitteeMembersListById(CommitteeCategoryId, ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.CommitteeMembers objlstCommitteeMembers = new WATS.Entities.CommitteeMembers();

                    objlstCommitteeMembers.CommitteeId = Convert.ToInt64(dr["CommitteeId"].ToString());
                    objlstCommitteeMembers.Name = dr["Name"].ToString();

                    lstCommitteeMembers.Add(objlstCommitteeMembers);
                }

            }
            return lstCommitteeMembers;
        }

        public List<WATS.Entities.Committees> GetCommitteesListByVariable(Int64 CommitteeCategoryId,string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Committees> lstCommittees = new List<WATS.Entities.Committees>();
            DataTable dt = _Committees.GetCommitteesListByVariable(CommitteeCategoryId,Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Committees.GetCommitteesListByVariable(CommitteeCategoryId,Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Committees objCommittees = new WATS.Entities.Committees();

                    objCommittees.RId = Convert.ToInt64(dr["RId"].ToString());
                    objCommittees.CommitteeId = Convert.ToInt64(dr["CommitteeId"].ToString());
                    objCommittees.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
                    objCommittees.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                    objCommittees.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
                    objCommittees.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objCommittees.State = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
                    objCommittees.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objCommittees.ImageUrl = (dr["ImageUrl"] != DBNull.Value ? dr["ImageUrl"].ToString() : null);
                    objCommittees.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0);
                    objCommittees.IsActive =Convert.ToBoolean(dr["IsActive"]);
                    objCommittees.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : null);
                    objCommittees.UpdatedBy = dr["UpdatedBy"].ToString();
                    objCommittees.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                    objCommittees.CommitteeMemberCount = Convert.ToInt64(dr["CommitteeMemberCount"].ToString());

                    lstCommittees.Add(objCommittees);
                }
            }
            return lstCommittees;
        }

        #endregion

        #endregion

        #region Front End

        public List<WATS.Entities.Committees> FECommitteesGetList(ref List<WATS.Entities.CommitteeCategories> lstCommitteeCategories, string Type, ref int status)
        {
            List<WATS.Entities.Committees> lstCommittees = new List<WATS.Entities.Committees>();
            if (Type != "")
            {
                DataSet ds = _Committees.FECommitteesGetList(Type, ref status);
                DataTable dt = ds.Tables[0];
                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        WATS.Entities.Committees objCommittees = new WATS.Entities.Committees();

                        objCommittees.CommitteeId = Convert.ToInt64(dr["CommitteeId"].ToString());
                        objCommittees.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
                        objCommittees.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                        objCommittees.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
                        objCommittees.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                        objCommittees.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
                        objCommittees.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                        objCommittees.ImageUrl = (dr["ImageUrl"] != DBNull.Value ? dr["ImageUrl"].ToString() : null);
                        objCommittees.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0);
                        objCommittees.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        objCommittees.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "");
                        objCommittees.UpdatedBy = dr["UpdatedBy"].ToString();
                        objCommittees.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                        objCommittees.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
                        objCommittees.CategoryName = dr["CategoryName"].ToString();
                        objCommittees.Designation = (dr["Designation"] != DBNull.Value ? dr["Designation"].ToString() : "");
                        objCommittees.Type = dr["Type"].ToString();

                        lstCommittees.Add(objCommittees);
                    }
                }
                DataTable dt1 = ds.Tables[1];
                if (dt1.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        WATS.Entities.CommitteeCategories objlstCommitteeCategories = new WATS.Entities.CommitteeCategories();

                        objlstCommitteeCategories.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
                        objlstCommitteeCategories.CategoryName = dr["CategoryName"].ToString();
                        objlstCommitteeCategories.Type = dr["Type"].ToString();
                        objlstCommitteeCategories.DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]);
                        objlstCommitteeCategories.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        objlstCommitteeCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                        objlstCommitteeCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                        objlstCommitteeCategories.CommitteeMemberCount = Convert.ToInt64(dr["CommitteeCount"]);

                        lstCommitteeCategories.Add(objlstCommitteeCategories);
                    }
                }
            }
            return lstCommittees;
        }

        //public List<WATS.Entities.Committees> FECommitteesGetList(ref WATS.Entities.Committees objCommittee, ref List<WATS.Entities.Committees> lstCommittees2, ref List<WATS.Entities.CommitteeCategories> lstCommitteeCategories, string Type, ref int status)
        //{
        //    List<WATS.Entities.Committees> lstCommittees = new List<WATS.Entities.Committees>();

        //    if (Type != "")
        //    {
        //        DataSet ds = _Committees.FECommitteesGetList(Type, ref status);
        //        DataTable dt = ds.Tables[0];
        //        if (dt.Rows.Count != 0)
        //        {
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                WATS.Entities.Committees objCommittees = new WATS.Entities.Committees();

        //                objCommittees.CommitteeId = Convert.ToInt64(dr["CommitteeId"].ToString());
        //                objCommittees.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
        //                objCommittees.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
        //                objCommittees.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
        //                objCommittees.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
        //                objCommittees.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
        //                objCommittees.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
        //                objCommittees.ImageUrl = (dr["ImageUrl"] != DBNull.Value ? dr["ImageUrl"].ToString() : null);
        //                objCommittees.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0);
        //                objCommittees.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //                objCommittees.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "");
        //                objCommittees.UpdatedBy = dr["UpdatedBy"].ToString();
        //                objCommittees.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
        //                objCommittees.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
        //                objCommittees.CategoryName = dr["CategoryName"].ToString();
        //                objCommittees.Designation = (dr["Designation"] != DBNull.Value ? dr["Designation"].ToString() : "");
        //                objCommittees.Type = dr["Type"].ToString();

        //                lstCommittees.Add(objCommittees);
        //            }
        //        }
        //        DataTable dt1 = ds.Tables[1];
        //        if (dt1.Rows.Count == 1)
        //        {
        //            objCommittee.CommitteeId = Convert.ToInt64(dt1.Rows[0]["CommitteeId"].ToString());
        //            objCommittee.Name = (dt1.Rows[0]["Name"] != DBNull.Value ? dt1.Rows[0]["Name"].ToString() : null);
        //            objCommittee.PhoneNo = (dt1.Rows[0]["PhoneNo"] != DBNull.Value ? dt1.Rows[0]["PhoneNo"].ToString() : null);
        //            objCommittee.Address = (dt1.Rows[0]["Address"] != DBNull.Value ? dt1.Rows[0]["Address"].ToString() : null);
        //            objCommittee.City = (dt1.Rows[0]["City"] != DBNull.Value ? dt1.Rows[0]["City"].ToString() : null);
        //            objCommittee.State = (dt1.Rows[0]["State"] != DBNull.Value ? dt1.Rows[0]["State"].ToString() : null);
        //            objCommittee.Email = (dt1.Rows[0]["Email"] != DBNull.Value ? dt1.Rows[0]["Email"].ToString() : null);
        //            objCommittee.ImageUrl = (dt1.Rows[0]["ImageUrl"] != DBNull.Value ? dt1.Rows[0]["ImageUrl"].ToString() : null);
        //            objCommittee.DisplayOrder = (dt1.Rows[0]["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dt1.Rows[0]["DisplayOrder"]) : 0);
        //            objCommittee.IsActive = Convert.ToBoolean(dt1.Rows[0]["IsActive"]);
        //            objCommittee.Description = (dt1.Rows[0]["Description"] != DBNull.Value ? dt1.Rows[0]["Description"].ToString() : "");
        //            objCommittee.UpdatedBy = dt1.Rows[0]["UpdatedBy"].ToString();
        //            objCommittee.UpdatedTime = Convert.ToDateTime(dt1.Rows[0]["UpdatedTime"].ToString());
        //            objCommittee.CommitteeCategoryId = Convert.ToInt64(dt1.Rows[0]["CommitteeCategoryId"].ToString());
        //            objCommittee.CategoryName = dt1.Rows[0]["CategoryName"].ToString();
        //            objCommittee.Designation = (dt1.Rows[0]["Designation"] != DBNull.Value ? dt1.Rows[0]["Designation"].ToString() : "");
        //            objCommittee.Type = dt1.Rows[0]["Type"].ToString();
        //        }

        //        DataTable dt2 = ds.Tables[2];
        //        if (dt2.Rows.Count != 0)
        //        {
        //            foreach (DataRow dr in dt2.Rows)
        //            {
        //                WATS.Entities.Committees objCommittees = new WATS.Entities.Committees();

        //                objCommittees.CommitteeId = Convert.ToInt64(dr["CommitteeId"].ToString());
        //                objCommittees.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
        //                objCommittees.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
        //                objCommittees.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
        //                objCommittees.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
        //                objCommittees.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
        //                objCommittees.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
        //                objCommittees.ImageUrl = (dr["ImageUrl"] != DBNull.Value ? dr["ImageUrl"].ToString() : null);
        //                objCommittees.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0);
        //                objCommittees.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //                objCommittees.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "");
        //                objCommittees.UpdatedBy = dr["UpdatedBy"].ToString();
        //                objCommittees.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
        //                objCommittees.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
        //                objCommittees.CategoryName = dr["CategoryName"].ToString();
        //                objCommittees.Designation = (dr["Designation"] != DBNull.Value ? dr["Designation"].ToString() : "");
        //                objCommittees.Type = dr["Type"].ToString();

        //                lstCommittees2.Add(objCommittees);
        //            }
        //        }
                
        //    }
        //    return lstCommittees;
        //}

        //public List<WATS.Entities.Committees> FECommitteesGetListAll(ref List<WATS.Entities.CommitteeCategories> lstCommitteeCategories, ref int status)
        //{
        //    List<WATS.Entities.Committees> lstCommittees = new List<WATS.Entities.Committees>();

        //    DataSet ds = _Committees.FECommitteesGetListAll(ref status);
        //    DataTable dt = ds.Tables[0];
        //    if (dt.Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            WATS.Entities.Committees objCommittees = new WATS.Entities.Committees();

        //            objCommittees.CommitteeId = Convert.ToInt64(dr["CommitteeId"].ToString());
        //            objCommittees.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
        //            objCommittees.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
        //            objCommittees.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
        //            objCommittees.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
        //            objCommittees.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
        //            objCommittees.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
        //            objCommittees.ImageUrl = (dr["ImageUrl"] != DBNull.Value ? dr["ImageUrl"].ToString() : null);
        //            objCommittees.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt32(dr["DisplayOrder"]) : 0);
        //            objCommittees.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            objCommittees.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : "");
        //            objCommittees.UpdatedBy = dr["UpdatedBy"].ToString();
        //            objCommittees.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
        //            objCommittees.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
        //            objCommittees.CategoryName = dr["CategoryName"].ToString();
        //            objCommittees.Designation = (dr["Designation"] != DBNull.Value ? dr["Designation"].ToString() : "");
        //            objCommittees.Type = dr["Type"].ToString();

        //            lstCommittees.Add(objCommittees);
        //        }
        //    }
        //    DataTable dt1 = ds.Tables[1];
        //    if (dt1.Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in dt1.Rows)
        //        {
        //            WATS.Entities.CommitteeCategories objlstCommitteeCategories = new WATS.Entities.CommitteeCategories();

        //            objlstCommitteeCategories.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
        //            objlstCommitteeCategories.CategoryName = dr["CategoryName"].ToString();
        //            objlstCommitteeCategories.Type = dr["Type"].ToString();
        //            objlstCommitteeCategories.DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]);
        //            objlstCommitteeCategories.IsActive = Convert.ToBoolean(dr["IsActive"]);
        //            objlstCommitteeCategories.UpdatedBy = dr["UpdatedBy"].ToString();
        //            objlstCommitteeCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
        //            objlstCommitteeCategories.CommitteeMemberCount = Convert.ToInt64(dr["CommitteeCount"]);

        //            lstCommitteeCategories.Add(objlstCommitteeCategories);
        //        }
        //    }
        //    return lstCommittees;
        //}

        #endregion
    }
    
}
