using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Administrator,Forms,")]
    public class Form2Controller : Controller
    {
        BLL.Form2 _Form2 = new BLL.Form2();
        List<Entities.Form2> lstForm2 = new List<Entities.Form2>();
        BLL.RegistrationCategories _RegistrationCategories = new BLL.RegistrationCategories();
        List<Entities.RegistrationCategories> lstRegistrationCategories = new List<Entities.RegistrationCategories>();
        DAL.Form2 _DForm2 = new DAL.Form2();
        BLL.PaymentSettings _PaymentSettings = new BLL.PaymentSettings();
        BLL.Members _Members = new BLL.Members();
        Entities.Members objMembers = new Entities.Members();
        BLL.Events _Events = new BLL.Events();

        #region  Form2

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 RegistrationCategoryId = 0)
        {
            int _qstatus = 0;
            ViewBag.lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);
            ViewBag.lstEvents = _Events.GetAllEventsList(ref _qstatus);
            int _qstatus1 = 0;

            objMembers = _Members.AddMembershipRequirement(ref _qstatus1);

            ViewBag.objMembers = objMembers;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Form2List(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 PaymentMethodId = 0, Int64 PaymentStatusId = 0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {

            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstForm2 = _Form2.GetForm2ListByVariable(EventId, RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo, Items, ref Total);

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                Total = -1;
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstForm2 = lstForm2;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult AddForm2(Int64 RegistrationCategoryId = 0)
        {
            try
            {

                int _qstatus = 0;
                ViewBag.lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);
                ViewBag.lstEvents = _Events.GetAllEventsList(ref _qstatus);

                int _qstatus1 = 0;
                objMembers = _Members.AddMembershipRequirement(ref _qstatus1);

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form2");
            }
            ViewBag.RegistrationCategoryId = RegistrationCategoryId;
            ViewBag.objMembers = objMembers;

            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddForm2(Entities.Form2 objForm2)
        {
            try
            {
                objForm2.InstertedBy = HttpContext.User.Identity.Name.ToString();
                objForm2.UpdatedBy = HttpContext.User.Identity.Name.ToString(); 
                objForm2.IsApproved = true;

                Int64 CulturalRegistrationId = 0;

                Int64 _status = _Form2.InsertForm2(objForm2, ref CulturalRegistrationId);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Inserted Event Registration Successfully</div>";
                    return RedirectToAction("Index", "Form2");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Updated Event Registration Successfully</div>";
                    return RedirectToAction("Index", "Form2");
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed uploading page.</div>";
                    return RedirectToAction("AddForm2", "Form2");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("AddForm2", "Form2");
            }

        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult EditForm2(Int64 CulturalRegistrationId = 0)
        {
            Entities.Members objMembers = new Entities.Members();
            try
            {

                int qstatus = 0;
                int _qstatus1 = 0;
                List<Entities.RegistrationCategories> _lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref qstatus);
                objMembers = _Members.AddMembershipRequirement(ref qstatus);
                ViewBag.lstEvents = _Events.GetAllEventsList(ref _qstatus1);

                int _qstatus = 0;
                Entities.Form2 _objForm2 = _Form2.GetForm2ById(CulturalRegistrationId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objForm2 = _objForm2;
                    ViewBag.lstRegistrationCategories = _lstRegistrationCategories;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Form2");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form2");
            }
            ViewBag.objMembers = objMembers;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewForm2(Int64 CulturalRegistrationId = 0)
        {
            try
            {

                int _qstatus = 0;
                Entities.Form2 _objForm2 = _Form2.GetForm2ById(CulturalRegistrationId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag._objForm2 = _objForm2;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Form2");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form2");
            }
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteForm2(Int64 CulturalRegistrationId)
        {
            string str = "";
            try
            {

                Int64 _status = _Form2.DeleteForm2(CulturalRegistrationId);
                if (_status == 1)
                {
                    str = "<div class=\"alert alert-success alert-dismissable\">Deleted Event Registration successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"alert alert-danger alert-dismissable\">Failed deleting Event Registration</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch (Exception ex)
            {
                str = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return Json(new { ok = false, data = str });
            }
        }


        [HttpPost]
        public JsonResult Form2Status(Int64 CulturalRegistrationId)
        {
            string str = "";
            try
            {
                Int64 _status = _Form2.UpdateForm2StatusById(CulturalRegistrationId);
                if (_status == 1)
                {
                    str = "<div class=\"alert alert-success alert-dismissable\">Updated status successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"alert alert-danger alert-dismissable\">Failed updating status</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch (Exception ex)
            {
                str = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + "</div>";
                return Json(new { ok = false, data = str });
            }
        }

        #endregion

        #region Export

        public void Form2ExportToExcel(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 MemberId = 0, Int64 PaymentMethodId = 0, Int64 PaymentStatusId = 0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC")
        {
            int Total = 0;
            try
            {
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DForm2.Form2ExportToExcel(EventId, RegistrationCategoryId, MemberId, PaymentMethodId, PaymentStatusId, Search, Sort, ref Total);

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "Form2-Registration-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Form2-Registration-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + "</div>";
            }
        }






        #endregion 
    }
}
