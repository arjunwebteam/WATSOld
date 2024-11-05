using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Enquiries,WebMaster")]
    public class EnquiryController : Controller
    {
        WATS.BLL.Enquiries _Enquiry = new WATS.BLL.Enquiries();
        WATS.Entities.Enquiries objRequestCalls = new WATS.Entities.Enquiries();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
           
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EnquiriesList(string search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            int Total = 0;
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            List<Entities.Enquiries> lstEnquiries = new List<Entities.Enquiries>();
            try
            {
                lstEnquiries = _Enquiry.GetEnquiriesListByVariable(HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
               
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.items = PageItems;
            ViewBag.pageno = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.lstEnquiries =lstEnquiries;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult DeleteEnquiry(Int64 EnquiryId)
        {
            string str = "";
            try
            {
                Int64 _status = _Enquiry.DeleteEnquiry(EnquiryId);
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
                str = "<div class=\"error closable\">Failed transaction.</div>";
                return Json(new { ok = false, data = str });
            }
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewEnquiry(Int64 EnquiryId)
        {
            Entities.Enquiries objEnquiriy = new Entities.Enquiries();
            int status = 0;
            try
            {
                objEnquiriy = _Enquiry.GetEnquirysById(EnquiryId, ref status);

                if (objEnquiriy == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "Enquiry");
                }
                
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Enquiry");
            }

            ViewBag.objEnquiriy = objEnquiriy;
            return View();
        }

    }
}
