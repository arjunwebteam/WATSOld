using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Volunteers")]
    public class VolunteersController : Controller
    {
        BLL.Volunteers _Volunteers = new BLL.Volunteers();
        BLL.VolunteerCategories _VolunteerCategory = new BLL.VolunteerCategories();
        List<Entities.VolunteerCategories> lstVolunteerCategory = new List<Entities.VolunteerCategories>();
        BLL.Events _Events = new BLL.Events();
        DAL.Volunteers _DVolunteers = new DAL.Volunteers();

        #region Volunteers

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            int _qstatus = 0;
            ViewBag.catlist = _VolunteerCategory.GetVolunteerCategoriesList(ref _qstatus);
            ViewBag.eventlist = _Events.SGetEventsList(ref _qstatus);
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult VolunteersList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Volunteers> lstVolunteers = new List<Entities.Volunteers>();

            try
            {
                lstVolunteers = _Volunteers.GetVolunteersListByVariable(Search, Sort, PageNo, Items, ref Total);

            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstVolunteers = lstVolunteers;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddVolunteer()
        {
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddVolunteer(Entities.Volunteers objVolunteers)
        {
            try
            {
                objVolunteers.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objVolunteers.InsertedBy = HttpContext.User.Identity.Name.ToString();
                objVolunteers.IsActive = false;
                Int64 _status = _Volunteers.InsertVolunteers(objVolunteers);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Created Volunteer Successfully</div>";
                    return RedirectToAction("Index", "Volunteers");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated Volunteer Successfully</div>";
                    return RedirectToAction("EditVolunteer", "Volunteers", new { VolunteerId = objVolunteers.VolunteerId });
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddVolunteer", "Volunteers");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditVolunteer(Int64 VolunteerId = 0, Int64 VolunteerCategoryId = 0)
        {
            try
            {

                int _qstatus = 0;
                Entities.Volunteers _objVolunteers = _Volunteers.GetVolunteerById(VolunteerId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objVolunteers = _objVolunteers;
                    ViewBag.VolunteerCategoryId = VolunteerCategoryId;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Volunteers");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Volunteers");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewVolunteer(Int64 VolunteerId = 0)
        {
             int _qstatus = 0;
             Entities.Volunteers _objVolunteers = new Entities.Volunteers();
            try
            {
                _objVolunteers = _Volunteers.GetVolunteerById(VolunteerId, ref _qstatus);

                if (_qstatus != 1)
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Volunteers");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Volunteers");
            }

            ViewBag.objVolunteers = _objVolunteers;
            ViewBag.status = _qstatus;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteVolunteer(Int64 VolunteerId)
        {
            string str = "";
            try
            {

                Int64 _status = _Volunteers.DeleteVolunteer(VolunteerId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted Volunteer successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed deleting page</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch 
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
                return Json(new { ok = false, data = str });
            }
        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult Volunteerstatus(Int64 VolunteerId)
        {
            string str = "";
            try
            {
                Int64 _status = _Volunteers.UpdateVolunteerstatus(VolunteerId);
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
                str = "<div class=\"error closable\">Failed transaction.</div>";
                return Json(new { ok = false, data = str });
            }
        }

        [HttpPost]
        public JsonResult CheckEmailAvailability(string Email,Int64 VolunteerId)
        {
            int status = 0;
            try
            {
                Entities.Volunteers objVolunteers = _Volunteers.VolunteerValidationByEmail(Email, ref status);
                bool data = (objVolunteers.VolunteerId == VolunteerId || objVolunteers.VolunteerId == 0 ? true : false);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed transaction.</div>" });
            }
        }

        #endregion

        #region export to excel

        public void VolunteersExporttoExcel(string Search = "", Int64 VolunteerCategoryId = 0, Int64 EventId = 0, string SortColumn = "UpdatedDate", string SortOrder = "DESC", int PageNo = 1, int PageItems = 10)
        {
            try
            {
                int Total = 0;
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DVolunteers.ExportToVolunteers(VolunteerCategoryId, EventId, Search, Sort, PageNo, PageItems, ref Total);

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "Volunteers-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Volunteers-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
            }
        }

        #endregion

    }
}
