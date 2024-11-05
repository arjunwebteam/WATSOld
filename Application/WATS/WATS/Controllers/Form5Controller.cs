using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using System.Data;
using System.IO;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Administrator,Forms,")]
    public class Form5Controller : Controller
    {
        BLL.Events _Events = new BLL.Events();
        DAL.Form5 __DForm5 = new DAL.Form5();
        List<Entities.Events> lstEvents = new List<Entities.Events>();
        BLL.RegistrationCategories _RegistrationCategories = new BLL.RegistrationCategories();
        List<Entities.RegistrationCategories> lstRegistrationCategories = new List<Entities.RegistrationCategories>();

        #region  RegistrationCategories
        BLL.Form5 _Form5 = new BLL.Form5();
        List<Entities.Form5> lstForm5 = new List<Entities.Form5>();
        BLL.Members _Members = new BLL.Members();
        BLL.PaymentSettings _PaymentSettings = new BLL.PaymentSettings();

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 EventCategoryId = 0)
        {
            Entities.Members objMembers = new Entities.Members();
            try
            {
                int _qstatus = 0;
                ViewBag.catlist = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);
                ViewBag.Eventlist = _Events.GetAllEventsList(ref _qstatus);
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);
                ViewBag.EventCategoryId = EventCategoryId;
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
            }
            ViewBag.objMembers = objMembers;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Form5List(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 MemberId = 0, Int64 PaymentStatusId = 0, Int64 PaymentMethodId = 0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {

            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstForm5 = _Form5.GetForm5ListByVariable(EventId, RegistrationCategoryId, MemberId, PaymentStatusId, PaymentMethodId, Search, Sort, PageNo, Items, ref Total);

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                Total = 1;
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstForm5 = lstForm5;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult AddForm5Registration(Int64 EventRegistrationForm5Id = 0)
        {
           
            List<Entities.RegistrationCategories> lstRegistrationCategories = new List<Entities.RegistrationCategories>();
            Entities.Members objMembers = new Entities.Members();
            List<Entities.Events> lstEvents = new List<Entities.Events>();

            int Total = 0;
            int _qstatus = 0;
            try
            {
                lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref Total);
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);
                lstEvents = _Events.GetAllEventsList(ref _qstatus);
            }
            catch
            {
                Total = -1;
            }
            ViewBag.lstRegistrationCategories = lstRegistrationCategories;
            ViewBag.objMembers = objMembers;
            ViewBag.lstEvents = lstEvents;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddForm5Registration(Entities.Form5 objForm5)
        {
            try
            {
                objForm5.InstertedBy = this.User.Identity.Name;
                objForm5.UpdatedBy = this.User.Identity.Name;
                objForm5.IsApproved = true;
                objForm5.TermsandConditions = true;
                objForm5.ApprovedDate = DateTime.Now;
                Int64 _status = _Form5.InsertForm5(objForm5);
                switch (_status)
                {
                    case 1:

                        TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Inserted Record Successfully</div>";
                        return RedirectToAction("Index", "Form5");
                    case 2:

                        TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Changes has been Updated Successfully</div>";
                        if (objForm5.EventRegistrationForm5Id == 0)
                        {
                            return RedirectToAction("Index", "Form5");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Form5", new { EventRegistrationForm5Id = objForm5.EventRegistrationForm5Id });
                        }
                    case -1:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed processing your request.</div>";

                        return RedirectToAction("Index", "Form5");
                    default:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        return RedirectToAction("Index", "Form5");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("AddForm5Registration", "Form5");
            }

        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult EditForm5Registrations(Int64 EventRegistrationForm5Id = 0)
        {
            Entities.Members objMembers = new Entities.Members();
            List<Entities.RegistrationCategories> lstRegistrationCategories = new List<Entities.RegistrationCategories>();
            List<Entities.Events> lstEvents = new List<Entities.Events>();
            List<Entities.Members> lstMembers = new List<Entities.Members>();
            int qstatus = 0;
            try
            {

                lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref qstatus);
               // lstMembers = _Members.GetMembersList(ref qstatus);
                lstEvents = _Events.GetAllEventsList(ref qstatus);
                objMembers = _Members.AddMembershipRequirement(ref qstatus);

                int _qstatus = 0;
                Entities.Form5 _objForm5 = _Form5.GetForm5ById(EventRegistrationForm5Id, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objDetails = _objForm5;
                    ViewBag.lstRegistrationCategories = lstRegistrationCategories;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Form5");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form5");
            }
            ViewBag.lstEvents = lstEvents;
            ViewBag.objMembers = objMembers;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewForm5Details(Int64 EventRegistrationForm5Id = 0)
        {
            try
            {

                int _qstatus = 0;
                Entities.Form5 _objForm5 = _Form5.GetForm5ById(EventRegistrationForm5Id, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objForm5 = _objForm5;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Form5");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form5");
            }
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteDetails(Int64 EventRegistrationForm5Id)
        {
            string str = "";
            try
            {

                Int64 _status = _Form5.DeleteForm5(EventRegistrationForm5Id);
                if (_status == 1)
                {
                    str = "<div class=\"alert alert-success alert-dismissable\">Deleted page successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"alert alert-danger alert-dismissable\">Failed deleting page</div>";
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
        public JsonResult Form5Status(Int64 EventRegistrationForm5Id)
        {
            string str = "";
            try
            {
                Int64 _status = _Form5.UpdateForm5StatusById(EventRegistrationForm5Id);
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

        #region export to excel

        public void ExportToForm5(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 MemberId = 0, Int64 PaymentMethodId = 0, Int64 PaymentStatusId = 0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC")
        {
            int Total = 0;
            try
            {
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = __DForm5.ExportToForm5(EventId, RegistrationCategoryId, MemberId, PaymentStatusId, PaymentMethodId, Search, Sort, ref Total);
                //MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                //var filename = "CSV-Donor-Registration-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".csv";
                //var contenttype = "text/csv";
                //Response.Clear();
                //Response.ContentType = contenttype;
                //Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(stream.ToArray());
                //Response.End();

                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "Form5-Registration-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Form5-Registration-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
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
