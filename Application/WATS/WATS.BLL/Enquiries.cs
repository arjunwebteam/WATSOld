using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace WATS.BLL
{
   public class Enquiries
    {
       WATS.DAL.Enquiries _Enquiries = new WATS.DAL.Enquiries();

        #region Methods

           public Int64 InsertEnquiries(Entities.Enquiries objEnquiries)
            {
                Int64 _status = 0;
                if (objEnquiries != null)
                {
                    _status = _Enquiries.InsertEnquiries(objEnquiries);

                }
                return _status;
            }

           public Int64 DeleteEnquiry(Int64 EnquiryId)
            {
                Int64 _status = 0;
                _status = _Enquiries.DeleteEnquiry(EnquiryId);
                return _status;
            }

        #endregion

        #region Entities filling

           public List<WATS.Entities.Enquiries> GetEnquiriesList(ref int status)
            {
                List<WATS.Entities.Enquiries> lstEnquiries = new List<Entities.Enquiries>();
                DataTable dt = _Enquiries.GetEnquiriesList(ref status);

                if (dt.Rows.Count != 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        WATS.Entities.Enquiries objlstEnquiries = new WATS.Entities.Enquiries();

                        objlstEnquiries.EnquiryId = Convert.ToInt64(dr["EnquiryId"].ToString());
                        objlstEnquiries.Name = dr["Name"].ToString();
                        objlstEnquiries.Email = dr["Email"].ToString();
                        objlstEnquiries.Subject = dr["Subject"].ToString();
                        objlstEnquiries.Description = dr["Description"].ToString();
                        objlstEnquiries.PhoneNo = dr["PhoneNo"].ToString();
                        objlstEnquiries.IsActive = Convert.ToBoolean(dr["IsActive"]);
                        objlstEnquiries.InsertedTime = Convert.ToDateTime(dr["InsertedTime"].ToString());

                        lstEnquiries.Add(objlstEnquiries);
                    }

                }
                return lstEnquiries;
            }

           public WATS.Entities.Enquiries GetEnquirysById(Int64 EnquiryId, ref int status)
           {
               WATS.Entities.Enquiries objEnquiries = new WATS.Entities.Enquiries();
               DataTable dt = new DataTable();
               if (EnquiryId != 0)
               {
                   dt = _Enquiries.GetEnquiryById(EnquiryId, ref status);
                   if (dt.Rows.Count == 1)
                   {
                       objEnquiries.EnquiryId = Convert.ToInt64(dt.Rows[0]["EnquiryId"].ToString());
                       objEnquiries.Name = dt.Rows[0]["Name"].ToString();
                       objEnquiries.Email = dt.Rows[0]["Email"].ToString();
                       objEnquiries.Description = dt.Rows[0]["Description"].ToString();
                       objEnquiries.Subject = dt.Rows[0]["Subject"].ToString();
                       objEnquiries.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                       objEnquiries.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                       objEnquiries.InsertedTime = Convert.ToDateTime(dt.Rows[0]["InsertedTime"].ToString());

                   }
               }
               return objEnquiries;
           }

           public List<WATS.Entities.Enquiries> GetEnquiriesListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total)
           {
               List<WATS.Entities.Enquiries> lstEnquiries = new List<WATS.Entities.Enquiries>();
               DataTable dt = _Enquiries.GetEnquiriesListByVariable(Search, Sort, PageNo, Items, ref Total);
               if (dt.Rows.Count == 0 && PageNo != 0)
               {
                   dt = _Enquiries.GetEnquiriesListByVariable(Search, Sort, PageNo - 1, Items, ref Total);
               }
               if (dt.Rows.Count != 0)
               {
                   foreach (DataRow dr in dt.Rows)
                   {
                       WATS.Entities.Enquiries objEnquiries = new WATS.Entities.Enquiries();

                       objEnquiries.RId = Convert.ToInt64(dr["RId"].ToString());
                       objEnquiries.EnquiryId = Convert.ToInt64(dr["EnquiryId"].ToString());
                       objEnquiries.Name = dr["Name"].ToString();
                       objEnquiries.Email = dr["Email"].ToString();
                       objEnquiries.Description = dr["Description"].ToString();
                       objEnquiries.Subject = dr["Subject"].ToString();
                       objEnquiries.PhoneNo = dr["PhoneNo"].ToString();
                       objEnquiries.IsActive = Convert.ToBoolean(dr["IsActive"]);
                       objEnquiries.InsertedTime = Convert.ToDateTime(dr["InsertedTime"].ToString());

                       lstEnquiries.Add(objEnquiries);
                   }
               }
               return lstEnquiries;
           }    

        #endregion
    }
}
