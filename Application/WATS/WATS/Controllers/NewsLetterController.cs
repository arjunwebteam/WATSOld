﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.IO;

namespace WATS.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,NewsLetter")]
    public class NewsLetterController : Controller
    {
        WATS.BLL.NewsLetter _NewsLetter = new WATS.BLL.NewsLetter();
        WATS.DAL.NewsLetter _DNewsLetter = new WATS.DAL.NewsLetter();
        WATS.Entities.NewsLetter objNewsLetter = new WATS.Entities.NewsLetter();
      
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult NewsLetterList(string search = "",string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            int Total = 0;
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            List<Entities.NewsLetter> lstNewsLetter = new List<Entities.NewsLetter>();
            try
            {
                lstNewsLetter = _NewsLetter.GetNewsLetterListByVariable(HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);               
            }
            catch 
            {
                Total = -1;
            }

            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.Total = Total;
            ViewBag.items = PageItems;
            ViewBag.PageNo = PageNo;
            ViewBag.NewsLetterlist = lstNewsLetter;
            return View();
        }


       [HttpPost]
       [WATS.Models.SessionClass.SessionExpireFilter]

        public JsonResult DeleteNewsLetter(Int64 LetterId)
        {
            string str = "";
            try
            {
                Int64 _status = _NewsLetter.DeleteNewsLetter(LetterId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Successfully Deleted</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed deleting item</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch 
            {
                str = "<div class=\"error closable\">Failed Transaction</div>";
                return Json(new { ok = false, data = str });
            }
        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult NewsLetterStatus(Int64 LetterId)
        {
            string str = "";
            try
            {
                Int64 _status = _NewsLetter.UpdateNewsLettertatusById(LetterId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Updated status successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed updating status</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch
            {
                str = "<div class=\"error closable\">Failed Transaction</div>";
                return Json(new { ok = false, data = str });
            }
        }

        public void NewsLetterExporttoExcel(string Search = "", string SortColumn = "RegisteredDate", string SortOrder = "DESC")
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            try
            {
                DataTable dtUni = _DNewsLetter.ExportNewsLetterGetList(Search,Sort);
                MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                var filename = "CSV-Subscribers-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".csv";
                var contenttype = "text/csv";
                Response.Clear();
                Response.ContentType = contenttype;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }
        
    }
}
