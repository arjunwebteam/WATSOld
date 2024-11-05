using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WATS.DAL;
using System.Data;

namespace WATS.BLL
{
    public class CommitteeCategories
    {
        WATS.DAL.CommitteeCategories _CommitteeCategories = new WATS.DAL.CommitteeCategories();        

        #region Methods

        public Int64 InsertCommitteeCategories(Entities.CommitteeCategories objCommitteeCategories)
        {
            Int64 _status = 0;
            if (objCommitteeCategories != null )
            {
                _status = _CommitteeCategories.InsertCommitteeCategories(objCommitteeCategories);

            }
            return _status;
        }

        public Int64 DeleteCommitteeCategory(Int64 CommitteeCategoryId)
        {
            Int64 _status = 0;
            _status = _CommitteeCategories.DeleteCommitteeCategory(CommitteeCategoryId);
            return _status;
        }

        public Int64 UpdateCommitteeCategoryStatus(Int64 CommitteeCategoryId)
        {
            Int64 _status = 0;
            _status = _CommitteeCategories.UpdateCommitteeCategoryStatus(CommitteeCategoryId);
            return _status;
        }

        public Int64 UpdateCommitteeCategoriesDisplayOrder(int DisplayOrder, Int64 CommitteeCategoryId)
        {
            Int64 _status = 0;
            _status = _CommitteeCategories.UpdateCommitteeCategoriesDisplayOrder(DisplayOrder, CommitteeCategoryId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<WATS.Entities.CommitteeCategories> GetCommitteeCategoriesList(ref int status)
        {
            List<WATS.Entities.CommitteeCategories> lstCommitteeCategories = new List<Entities.CommitteeCategories>();
            DataTable dt = _CommitteeCategories.GetCommitteeCategoriesList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.CommitteeCategories objlstCommitteeCategories = new WATS.Entities.CommitteeCategories();

                    objlstCommitteeCategories.CommitteeCategoryId =Convert.ToInt64( dr["CommitteeCategoryId"].ToString());
                    objlstCommitteeCategories.CategoryName = dr["CategoryName"].ToString();
                    objlstCommitteeCategories.Type = dr["Type"].ToString();
                    objlstCommitteeCategories.DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]);
                    objlstCommitteeCategories.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objlstCommitteeCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstCommitteeCategories.UpdatedTime =Convert.ToDateTime(dr["UpdatedTime"].ToString());

                    lstCommitteeCategories.Add(objlstCommitteeCategories);
                }

            }
            return lstCommitteeCategories;
        }

        public WATS.Entities.CommitteeCategories GetCommitteeCategoryById(Int64 CommitteeCategoryId, ref int status)
        {
            WATS.Entities.CommitteeCategories objCommitteeCategories = new WATS.Entities.CommitteeCategories();
            DataTable dt = new DataTable();
            if (CommitteeCategoryId != 0)
            {
                dt = _CommitteeCategories.GetCommitteeCategoryById(CommitteeCategoryId, ref status);
                if (dt.Rows.Count == 1)
                {
                    objCommitteeCategories.CommitteeCategoryId = Convert.ToInt32(dt.Rows[0]["CommitteeCategoryId"].ToString());
                    objCommitteeCategories.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                    objCommitteeCategories.Type = dt.Rows[0]["Type"].ToString();
                    objCommitteeCategories.DisplayOrder = Convert.ToInt32(dt.Rows[0]["DisplayOrder"]);
                    objCommitteeCategories.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objCommitteeCategories.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objCommitteeCategories.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"].ToString());
                  
                }
            }
            return objCommitteeCategories;
        }

        public List<WATS.Entities.CommitteeCategories> GetCommitteeCategoriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.CommitteeCategories> lstCommitteeCategories = new List<WATS.Entities.CommitteeCategories>();
            DataTable dt = _CommitteeCategories.GetCommitteeCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _CommitteeCategories.GetCommitteeCategoriesListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.CommitteeCategories objCommitteeCategories = new WATS.Entities.CommitteeCategories();

                    objCommitteeCategories.RId = Convert.ToInt64(dr["RId"].ToString());
                    objCommitteeCategories.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
                    objCommitteeCategories.CategoryName = dr["CategoryName"].ToString();
                    objCommitteeCategories.Type = dr["Type"].ToString();
                    objCommitteeCategories.DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]);
                    objCommitteeCategories.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objCommitteeCategories.UpdatedBy = dr["UpdatedBy"].ToString();
                    objCommitteeCategories.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());
                    objCommitteeCategories.CommitteeMemberCount = Convert.ToInt64(dr["CommitteeMemberCount"].ToString());

                    lstCommitteeCategories.Add(objCommitteeCategories);
                }
            }
            return lstCommitteeCategories;
        }

        #endregion
    }
}
