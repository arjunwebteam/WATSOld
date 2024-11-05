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
    public class Form3Controller : Controller
    {
        BLL.Form3 _Form3 = new BLL.Form3();
        List<Entities.Form3> lstForm3 = new List<Entities.Form3>();
        BLL.RegistrationCategories _RegistrationCategories = new BLL.RegistrationCategories();
        List<Entities.RegistrationCategories> lstRegistrationCategories = new List<Entities.RegistrationCategories>();
        DAL.Form3 _DForm3 = new DAL.Form3();
        BLL.PaymentSettings _PaymentSettings = new BLL.PaymentSettings();
        BLL.Members _Members = new BLL.Members();
        Entities.Members objMembers = new Entities.Members();
        BLL.Events _Events = new BLL.Events();
        List<Entities.Events> lstEvents = new List<Entities.Events>();
        #region  Form3

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 RegistrationCategoryId = 0)
        {
            int _qstatus = 0;
            
            ViewBag.Eventlist = _Events.GetAllEventsList(ref _qstatus);
            ViewBag.RegistrationCategoriesList = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);
            objMembers = _Members.AddMembershipRequirement(ref _qstatus);
           

            ViewBag.RegistrationCategoryId = RegistrationCategoryId;
            ViewBag.objMembers = objMembers;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Form3List(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 PaymentMethodId = 0, Int64 PaymentStatusId = 0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {

            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstForm3 = _Form3.GetForm3ListByVariable(EventId,RegistrationCategoryId, PaymentMethodId, PaymentStatusId, Search, Sort, PageNo, Items, ref Total);

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                Total = -1;
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstForm3 = lstForm3;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult AddForm3(Int64 RegistrationCategoryId = 0)
        {
            try
            {

                int _qstatus = 0;
    
                lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);
                lstEvents = _Events.GetAllEventsList(ref _qstatus);

            

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", " Form3");
            }
            ViewBag.RegistrationCategoryId = RegistrationCategoryId;
            ViewBag.objMembers = objMembers;
            ViewBag.lstEvents = lstEvents;
            ViewBag.lstRegistrationCategories = lstRegistrationCategories;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddForm3(Entities.Form3 objForm3)
        {
            try
            {
                objForm3.InstertedBy = (Session["name"] != null ? Session["name"].ToString() : "");
                objForm3.UpdatedBy = (Session["name"] != null ? Session["name"].ToString() : "");
                objForm3.IsApproved = true;
                objForm3.IsApproved = true;
                objForm3.TermsandConditions = true;
                objForm3.ApprovedDate = DateTime.Now;
                Int64 _status = _Form3.InsertForm3(objForm3);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Inserted Event Registration Successfully</div>";
                    return RedirectToAction(("Index"), "Form3");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"alert alert-success alert-dismissable\">Updated Event Registration Successfully</div>";
                    return RedirectToAction("Index", "Form3");
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed uploading page.</div>";
                    return RedirectToAction("Index", "Form3");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form3");
            }

        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult EditForm3(Int64 EventRegistrationForm3Id = 0)
        {
            Entities.Members objMembers = new Entities.Members();
            try
            {

                int qstatus = 0;
              
                List<Entities.RegistrationCategories> _lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref qstatus);
                objMembers = _Members.AddMembershipRequirement(ref qstatus);
                lstEvents = _Events.GetAllEventsList(ref qstatus);

                int _qstatus = 0;
                Entities.Form3 _objForm3 = _Form3.GetForm3ById(EventRegistrationForm3Id, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objForm3 = _objForm3;
                    ViewBag.lstEvents = lstEvents;
                    ViewBag.lstRegistrationCategories = _lstRegistrationCategories;
                    ViewBag.objMembers = objMembers;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Form3");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", "Form3");
            }
            ViewBag.objMembers = objMembers;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewForm3(Int64 EventRegistrationForm3Id = 0)
        {
            try
            {

                int _qstatus = 0;
                Entities.Form3 _objForm3 = _Form3.GetForm3ById(EventRegistrationForm3Id, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag._objForm3 = _objForm3;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                    return RedirectToAction("Index", " Form3");
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"alert alert-danger alert-dismissable\">" + ex.Message + ".</div>";
                return RedirectToAction("Index", " Form3");
            }
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteForm3(Int64 EventRegistrationForm3Id)
        {
            string str = "";
            try
            {

                Int64 _status = _Form3.DeleteForm3(EventRegistrationForm3Id);
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
        public JsonResult Form3Status(Int64 EventRegistrationForm3Id)
        {
            string str = "";
            try
            {
                Int64 _status = _Form3.UpdateForm3StatusById(EventRegistrationForm3Id);
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

      



        public void Form3ExportToExcel(Int64 EventId = 0, Int64 RegistrationCategoryId = 0, Int64 MemberId = 0, Int64 PaymentStatusId = 0, Int64 PaymentMethodId = 0, string Search = "", string SortColumn = "UpdatedDate", string SortOrder = "DESC")
        {
            int Total = 0;
            try
            {
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DForm3.Form3ExportToExcel(EventId, RegistrationCategoryId, MemberId, PaymentStatusId, PaymentMethodId, Search, Sort, ref Total);
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
                    wb.Worksheets.Add(dtUni, "Form3-Registration-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Form3-Registration-Export-" + DateTime.UtcNow.ToString("dd-MM-yyyy") + ".xlsx");
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
