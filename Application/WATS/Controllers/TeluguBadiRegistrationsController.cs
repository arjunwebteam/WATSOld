using WATS.BLL;
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
using ClosedXML.Excel;


namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,TeluguBadiRegistrations")]
    public class TeluguBadiRegistrationsController : Controller
    {
        WATS.BLL.TeluguBadiRegistrations _TeluguBadiRegistrations = new WATS.BLL.TeluguBadiRegistrations();
        WATS.Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = new WATS.Entities.TeluguBadiRegistrations();
        WATS.DAL.TeluguBadiRegistrations _DTeluguBadiRegistrations = new WATS.DAL.TeluguBadiRegistrations();
        WATS.BLL.TeluguBadiOrders _TeluguBadiOrders = new WATS.BLL.TeluguBadiOrders();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 TeluguBadiTypeId = 0)
        {
            try
            {
                Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = new Entities.TeluguBadiRegistrations();

                int qstatus = 0;
                objTeluguBadiRegistrations = _TeluguBadiOrders.AddTeluguBadiRequirement(ref qstatus);

                if (qstatus == 1)
                {
                    ViewBag.objTeluguBadiRegistrations = objTeluguBadiRegistrations;
                    ViewBag.status = qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "TeluguBadiRegistrations");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.TeluguBadiTypeId = TeluguBadiTypeId;
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult TeluguBadiRegistrationsList(string search = "", Int64 TeluguBadiTypeId=0, Int64 PaymentStatusId=0, string StartDate = "", string EndDate = "", string ExpiryDate="", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            int Total = 0;
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            List<Entities.TeluguBadiRegistrations> lstTeluguBadiRegistrations = new List<Entities.TeluguBadiRegistrations>();
            try
            {
                lstTeluguBadiRegistrations = _TeluguBadiRegistrations.GetTeluguBadiRegistrationsListByVariable(HttpUtility.UrlDecode(search.Trim()), TeluguBadiTypeId, PaymentStatusId, StartDate, EndDate, ExpiryDate, Sort, PageNo, PageItems, ref Total);

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
            ViewBag.lstTeluguBadiRegistrations = lstTeluguBadiRegistrations;
            return View();
        }



        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddTeluguBadiRegistrations()
        {
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTeluguBadiRegistrations(Entities.TeluguBadiRegistrations objTeluguBadiRegistrations, List<Entities.TeluguBadiStudents> lstTeluguBadiStudents)
        {
            try
            {
                objTeluguBadiRegistrations.IsApproved = false;
                objTeluguBadiRegistrations.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objTeluguBadiRegistrations.InsertedBy = HttpContext.User.Identity.Name.ToString();
                objTeluguBadiRegistrations.InsertedDate = DateTime.Now;
                objTeluguBadiRegistrations.UpdatedDate = DateTime.Now;
                Int64 TRegistrationId = objTeluguBadiRegistrations.TRegistrationId;
                Int64 _status = _TeluguBadiRegistrations.InsertTeluguBadiRegistrations(objTeluguBadiRegistrations);
                if (_status == 1)
                {
                    if (lstTeluguBadiStudents != null && lstTeluguBadiStudents.Count() != 0)
                    {
                        foreach (Entities.TeluguBadiStudents objTeluguBadiStudents in lstTeluguBadiStudents)
                        {
                            objTeluguBadiStudents.TRegistrationId = TRegistrationId;
                            objTeluguBadiStudents.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                            objTeluguBadiStudents.InsertedBy = HttpContext.User.Identity.Name.ToString();
                            objTeluguBadiStudents.InsertedDate = DateTime.Now;
                            objTeluguBadiStudents.UpdatedDate = DateTime.Now;
                            if (objTeluguBadiStudents != null && objTeluguBadiStudents.FirstName != null)
                            {
                                Int64 estatus = _TeluguBadiRegistrations.InsertTeluguBadiStudents(objTeluguBadiStudents);
                                if (estatus == -1)
                                {
                                    TempData["message"] = "<div class=\"error closable\">Failed inserting member details.</div>";
                                    return RedirectToAction("Index", "TeluguBadiRegistrations");
                                }
                            }
                        }
                    }
                    TempData["message"] = "<div class=\"success closable\">Created TeluguBadiRegistrations Successfully</div>";
                    return RedirectToAction("Index", "TeluguBadiRegistrations");
                }
                if (_status == 2)
                {
                    if (lstTeluguBadiStudents != null && lstTeluguBadiStudents.Count() != 0)
                    {
                        foreach (Entities.TeluguBadiStudents objTeluguBadiStudents in lstTeluguBadiStudents)
                        {
                            objTeluguBadiStudents.TRegistrationId = TRegistrationId;
                            objTeluguBadiStudents.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                            objTeluguBadiStudents.InsertedBy = HttpContext.User.Identity.Name.ToString();
                            objTeluguBadiStudents.InsertedDate = DateTime.Now;
                            objTeluguBadiStudents.UpdatedDate = DateTime.Now;
                            if (objTeluguBadiStudents != null && objTeluguBadiStudents.FirstName != null)
                            {
                                Int64 estatus = _TeluguBadiRegistrations.InsertTeluguBadiStudents(objTeluguBadiStudents);
                                if (estatus == -1)
                                {
                                    TempData["message"] = "<div class=\"error closable\">Failed inserting member details.</div>";
                                    return RedirectToAction("Index", "TeluguBadiRegistrations");
                                }
                            }
                        }
                    }


                    TempData["message"] = "<div class=\"success closable\">Updated TeluguBadiRegistrations Successfully</div>";
                    return RedirectToAction("Index", "TeluguBadiRegistrations");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("AddTeluguBadiRegistrations", "TeluguBadiRegistrations");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddTeluguBadiRegistrations", "TeluguBadiRegistrations");
            }

        }

        //[WATS.Models.SessionClass.SessionExpireFilter]
        //public ActionResult EditTeluguBadiRegistrations(Int64 TRegistrationId = 0)
        //{
        //    try
        //    {

        //        int _qstatus = 0;
        //        Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = _TeluguBadiRegistrations.GetTeluguBadiRegistrationsById(TRegistrationId, ref _qstatus);

        //        if (_qstatus == 1)
        //        {
        //            ViewBag.objTeluguBadiRegistrations = objTeluguBadiRegistrations;
        //            ViewBag.status = _qstatus;
        //        }
        //        else
        //        {
        //            TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
        //            return RedirectToAction("Index", "TeluguBadiRegistrations");
        //        }
        //    }
        //    catch
        //    {
        //        TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
        //        return RedirectToAction("Index", "TeluguBadiRegistrations");
        //    }
        //    return View();
        //}



        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditTeluguBadiRegistrations(Int64 TRegistrationId = 0)
        {
            try
            {
                Entities.TeluguBadiRegistrations objTeluguBadiRequirement = new Entities.TeluguBadiRegistrations();
                List<Entities.TeluguBadiOrders> lstTeluguBadiOrders = new List<Entities.TeluguBadiOrders>();

                int qstatus = 0;
                objTeluguBadiRequirement = _TeluguBadiOrders.AddTeluguBadiRequirement(ref qstatus);
                lstTeluguBadiOrders = _TeluguBadiOrders.GetTeluguBadiOrdersList(TRegistrationId, ref qstatus);

                if (qstatus == 1)
                {
                    ViewBag.objTeluguBadiRequirement = objTeluguBadiRequirement;
                    ViewBag.status = qstatus;
                }
                int _qstatus = 0;
                Entities.TeluguBadiRegistrations _objTeluguBadiRegistrations = _TeluguBadiRegistrations.GetTBudiRegistrationsFullDetailsById(TRegistrationId, ref _qstatus);

                if (_qstatus == 1 && qstatus == 1)
                {
                    ViewBag.objTeluguBadiRegistrationsorders = _objTeluguBadiRegistrations;
                    ViewBag.lstTeluguBadiOrders = lstTeluguBadiOrders;

                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "TeluguBadiRegistrations");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "TeluguBadiRegistrations");
            }
            return View();
        }


        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult DeleteTeluguBadiRegistrations(Int64 TRegistrationId)
        {
            string str = "";
            try
            {
                Int64 _status = _TeluguBadiRegistrations.DeleteTeluguBadiRegistrations(TRegistrationId);
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
        public ActionResult ViewTeluguBadiRegistrations(Int64 TRegistrationId = 0)
        {
            try
            {
                Entities.TeluguBadiRegistrations objTeluguBadiRequirement = new Entities.TeluguBadiRegistrations();
                List<Entities.TeluguBadiOrders> lstTeluguBadiOrders = new List<Entities.TeluguBadiOrders>();

                int qstatus = 0;
                objTeluguBadiRequirement = _TeluguBadiOrders.AddTeluguBadiRequirement(ref qstatus);
                lstTeluguBadiOrders = _TeluguBadiOrders.GetTeluguBadiOrdersList(TRegistrationId, ref qstatus);

                if (qstatus == 1)
                {
                    ViewBag.objTeluguBadiRequirement = objTeluguBadiRequirement;
                    ViewBag.status = qstatus;
                }
                int _qstatus = 0;
                Entities.TeluguBadiRegistrations _objTeluguBadiRegistrations = _TeluguBadiRegistrations.GetTBudiRegistrationsFullDetailsById(TRegistrationId, ref _qstatus);

                if (_qstatus == 1 && qstatus == 1)
                {
                    ViewBag.objTeluguBadiRegistrationsorders = _objTeluguBadiRegistrations;
                    ViewBag.lstTeluguBadiOrders = lstTeluguBadiOrders;

                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "TeluguBadiRegistrations");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "TeluguBadiRegistrations");
            }
            return View();
        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult TeluguBadiRegistrationsStatus(Int64 TRegistrationId)
        {
            string str = "";
            try
            {
                Int64 _status = _TeluguBadiRegistrations.UpdateTeluguBadiRegistrationsStatus(TRegistrationId);
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


        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult DeleteTeluguBadiStudents(Int64 TStudentId)
        {
            string str = "";
            try
            {
                Int64 _status = _TeluguBadiRegistrations.DeleteTeluguBadiStudents(TStudentId);
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

        public void TeluguBadiRegistrationsExporttoExcel(string Search = "", Int64 TeluguBadiTypeId = 0, Int64 PaymentStatusId = 0, string StartDate = "", string EndDate = "", string ExpiryDate = "", string SortColumn = "InsertedTime", string SortOrder = "DESC")
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            try
            {
                DataTable dtUni = _DTeluguBadiRegistrations.ExportTeluguBadiRegistrationsList(Search, TeluguBadiTypeId, PaymentStatusId, StartDate, EndDate, ExpiryDate, Sort);
                //MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                //var filename = "CSV-Members-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".csv";
                //var contenttype = "text/csv";
                //Response.Clear();
                //Response.ContentType = contenttype;
                //Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(stream.ToArray());
                //Response.End();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "TeluguBadi-Registration-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=TeluguBadi-Registration-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".xlsx");
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
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }


    }
}
