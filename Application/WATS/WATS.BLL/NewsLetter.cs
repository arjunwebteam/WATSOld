using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class NewsLetter
    {
        WATS.DAL.NewsLetter _NewsLetter = new WATS.DAL.NewsLetter();

        #region Methods

        public Int64 InsertNewsLetter(WATS.Entities.NewsLetter objNewsLetter)
        {

            Int64 _status = 0;
            if (objNewsLetter != null)
            {
                _status = _NewsLetter.InsertNewsLetter(objNewsLetter);
            }
            return _status;
        }

        public Int64 DeleteNewsLetter(Int64 LetterId)
        {
            Int64 _status = 0;

            _status = _NewsLetter.DeleteNewsLetterById(LetterId);
            
            return _status;
        }

        public Int64 UpdateNewsLettertatusById(Int64 LetterId)
        {
            Int64 _status = 0;

            _status = _NewsLetter.UpdateNewsLetterById(LetterId);

            return _status;
        }

        #endregion

        #region Entities filling

        public WATS.Entities.NewsLetter GetNewsLetterById(Int64 Id)
        {
            WATS.Entities.NewsLetter objNewsLetter = new WATS.Entities.NewsLetter();

            DataTable dt = new DataTable();
            if (Id != 0)
            {
                dt = _NewsLetter.GetNewsLetterById(Id);
                if (dt.Rows.Count == 1)
                {
                    objNewsLetter.LetterId = Convert.ToInt64(dt.Rows[0]["LetterId"].ToString());
                    objNewsLetter.EmailId = dt.Rows[0]["EmailId"].ToString();
                    objNewsLetter.RegisteredDate = Convert.ToDateTime(dt.Rows[0]["RegisteredDate"]);
                    objNewsLetter.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }
            }
            return objNewsLetter;
        }

        public WATS.Entities.NewsLetter GetNewsLetterByEmail(string Email,ref int status)
        {
            WATS.Entities.NewsLetter objNewsLetter = new WATS.Entities.NewsLetter();

            DataTable dt = new DataTable();
            if (Email != "")
            {
                dt = _NewsLetter.GetNewsLetterByEmail(Email,ref status);
                if (dt.Rows.Count == 1)
                {
                    objNewsLetter.LetterId = Convert.ToInt64(dt.Rows[0]["LetterId"].ToString());
                    objNewsLetter.EmailId = dt.Rows[0]["EmailId"].ToString();
                    objNewsLetter.RegisteredDate = Convert.ToDateTime(dt.Rows[0]["RegisteredDate"]);
                    objNewsLetter.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                }
            }
            return objNewsLetter;
        }

        public List<WATS.Entities.NewsLetter> GetNewsLetterListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.NewsLetter> lstNewsLetter = new List<WATS.Entities.NewsLetter>();

            DataTable dt = _NewsLetter.GetNewsLetterListByVariable(Search, Sort, PageNo, Items, ref Total);

            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _NewsLetter.GetNewsLetterListByVariable( Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.NewsLetter objNewsLetter = new WATS.Entities.NewsLetter();

                    objNewsLetter.LetterId = Convert.ToInt64(dr["LetterId"]);
                    objNewsLetter.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objNewsLetter.RegisteredDate = Convert.ToDateTime(dr["RegisteredDate"]);
                    objNewsLetter.RId = Convert.ToInt64(dr["RId"]);
                    objNewsLetter.EmailId = dr["EmailId"].ToString();

                    lstNewsLetter.Add(objNewsLetter);
                }
            }
            return lstNewsLetter;
        }

        #endregion
    }
}
