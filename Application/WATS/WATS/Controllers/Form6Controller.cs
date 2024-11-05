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
    public class Form6Controller : Controller
    {
        BLL.Events _Events = new BLL.Events();
        List<Entities.Events> lstEvents = new List<Entities.Events>();
        BLL.EventCategories _EventCategories = new BLL.EventCategories();
        List<Entities.EventCategories> lstEventCategories = new List<Entities.EventCategories>();
        BLL.RegistrationCategories _RegistrationCategories = new BLL.RegistrationCategories();
        #region  EventCategories
        BLL.Form6 _Form6 = new BLL.Form6();

        DAL.Form6 __DForm6 = new DAL.Form6();
        List<Entities.Form6> lstForm6 = new List<Entities.Form6>();
        BLL.Members _Members = new BLL.Members();
        BLL.PaymentSettings _PaymentSettings = new BLL.PaymentSettings();
        Entities.Members objMembers = new Entities.Members();
        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 EventCategoryId = 0)
        {
            try
            {
                int _qstatus = 0;
                ViewBag.catlist = _EventCategories.GetEventCategoriesList(ref _qstatus);
                ViewBag.Eventlist = _Events.GetAllEventsList(ref _qstatus);
                ViewBag.RegistrationCategoriesList = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);
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
        public ActionResult Form6List(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 PaymentMethodId=0, Int64 PaymentStatusId=0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {

            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstForm6 = _Form6.GetForm6ListByVariable(EventId, RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo, Items, ref Total);

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                Total = 1;
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstForm6 = lstForm6;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult AddForm6Registration(Int64 EventRegistrationForm6Id = 0)
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
        public ActionResult AddForm6Registration(Entities.Form6 objForm6)
        {
            try
            {
                objForm6.InstertedBy = this.User.Identity.Name;
                objForm6.UpdatedBy = this.User.Identity.Name;
                objForm6.IsApproved = true;
                objForm6.TermsandConditions = true;
                objForm6.ApprovedDate = DateTime.Now;
                Int64 _status = _Form6.InsertForm6(objForm6);
                switch (_status)
                {
                    case 1:

                        TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Inserted Record Successfully</div>";
                        return RedirectToAction("Index", "Form6");
                    case 2:

                        TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Changes has been Updated Successfully</div>";
                        if (objForm6.EventRegistrationForm6Id == 0)
                        {
                            return RedirectToAction("Index", "Form6");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Form6", new { EventRegistrationForm6Id = objForm6.EventRegistrationForm6Id });
                        }
                    case -1:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed processing your request.</div>";

                        return RedirectToAction("Index", "Form6");
                    default:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        return RedirectToAction("Index", "Form6");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("AddForm6", "Form6");
            }

        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult EditForm6Registrations(Int64 EventRegistrationForm6Id = 0)
        {
            Entities.Members objMembers = new Entities.Members();
            List<Entities.EventCategories> lstEventCategories = new List<Entities.EventCategories>();
            List<Entities.Events> lstEvents = new List<Entities.Events>();
            List<Entities.Members> lstMembers = new List<Entities.Members>();
            List<Entities.RegistrationCategories> lstRegistrationCategories = new List<Entities.RegistrationCategories>();
            int qstatus = 0;
            try
            {

                lstEventCategories = _EventCategories.GetEventCategoriesList(ref qstatus);
                lstMembers = _Members.GetMembersList(ref qstatus);
                lstEvents = _Events.GetAllEventsList(ref qstatus);
                objMembers = _Members.AddMembershipRequirement(ref qstatus);
                lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref qstatus);
                int _qstatus = 0;
                Entities.Form6 _objForm6 = _Form6.GetForm6ById(EventRegistrationForm6Id, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objDetails = _objForm6;
                    ViewBag.lstEventCategories = lstEventCategories;
                    ViewBag.lstEvents = lstEvents;
                    ViewBag.lstRegistrationCategories = lstRegistrationCategories;
                    ViewBag.status = _qstatus;
                    ViewBag.objMembers = objMembers;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Form6");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form6");
            }
           
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewForm6Registrations(Int64 EventRegistrationForm6Id = 0)
        {
            try
            {

                int _qstatus = 0;
                Entities.Form6 _objForm6 = _Form6.GetForm6ById(EventRegistrationForm6Id, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objDetails = _objForm6;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Form6");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form6");
            }
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteDetails(Int64 EventRegistrationForm6Id)
        {
            string str = "";
            try
            {

                Int64 _status = _Form6.DeleteForm6(EventRegistrationForm6Id);
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
        public JsonResult Form6tatus(Int64 EventRegistrationForm6Id)
        {
            string str = "";
            try
            {
                Int64 _status = _Form6.UpdateForm6StatusById(EventRegistrationForm6Id);
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



      

        public void ExportToForm6(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 MemberId = 0, Int64 PaymentMethodId=0, Int64 PaymentStatusId=0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC")
        {
            int Total = 0;
            try
            {
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = __DForm6.ExportToForm6(EventId, RegistrationCategoryId, MemberId, PaymentMethodId, PaymentStatusId, Search, Sort, ref Total);
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
                    wb.Worksheets.Add(dtUni, "Form6-Registration-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Form6-Registration-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
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

        
    }
}
