using ClosedXML.Excel;
using System.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Configuration;

namespace WATS.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,")]
    public class SponsorRegistrationsController : Controller
    {
        WATS.BLL.SponsorRegistrations _SponsorRegistration = new WATS.BLL.SponsorRegistrations();
        WATS.BLL.SponsorRegistrationCategories _SponsorRegistrationCategories = new WATS.BLL.SponsorRegistrationCategories();
        WATS.DAL.SponsorRegistrations _DSponsorRegistration = new WATS.DAL.SponsorRegistrations();
        BLL.Members _Members = new BLL.Members();
        WATS.Entities.SponsorRegistrations objRequestCalls = new WATS.Entities.SponsorRegistrations();
        WATS.BLL.Events _Events = new WATS.BLL.Events();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            int Status1 = 0;
            List<Entities.SponsorRegistrationCategories> lstSponsorRegistrationCategories = _SponsorRegistrationCategories.GetSponsorRegistrationCategoriesList(ref Status1);

            ViewBag.lstSponsorRegistrationCategories = lstSponsorRegistrationCategories;

            int Status = 0;
            List<Entities.Events> lstEvents = _Events.SGetEventsList(ref Status);
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult SponsorRegistrationsList(Int64 SponsorRegistrationCategoryId=0, Int64 EventId = 0, string search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.SponsorRegistrations> lstSponsorRegistrations = new List<Entities.SponsorRegistrations>();
            try
            {
                lstSponsorRegistrations = _SponsorRegistration.GetSponsorRegistrationsListByVariable(SponsorRegistrationCategoryId, EventId,HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.Total = Total;
            ViewBag.items = PageItems;
            ViewBag.PageNo = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.lstSponsorRegistrations = lstSponsorRegistrations;
            return View();
        }

        public JsonResult DeleteSponsorRegistration(Int64 SponsorRegistrationId, string BannerUrl = "")
        {
            string str = "";
            try
            {
                Int64 _status = _SponsorRegistration.DeleteSponsorRegistration(SponsorRegistrationId);
                if (_status == 1)
                {
                    if (System.IO.File.Exists(ConfigurationManager.AppSettings["uploadpath"] + @"\\SponsorRegistration\\NormalImages\\" + BannerUrl))
                    {
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\SponsorRegistration\\NormalImages\\" + BannerUrl);
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\SponsorRegistration\\ThumbImages\\" + BannerUrl);
                    }

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
        public ActionResult ViewSponsorRegistration(Int64 SponsorRegistrationId)
        {
            Entities.SponsorRegistrations objSponsorRegistrations = new Entities.SponsorRegistrations();
            int status = 0;
            try
            {
                int Status1 = 0;
                List<Entities.SponsorRegistrationCategories> lstSponsorRegistrationCategories = _SponsorRegistrationCategories.GetSponsorRegistrationCategoriesList(ref Status1);

                ViewBag.lstSponsorRegistrationCategories = lstSponsorRegistrationCategories;
                objSponsorRegistrations = _SponsorRegistration.GetSponsorRegistrationsById(SponsorRegistrationId, ref status);

                if (objSponsorRegistrations == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "SponsorRegistrations");
                }

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "SponsorRegistrations");
            }

            ViewBag.objSponsorRegistrations = objSponsorRegistrations;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditSponsorRegistration(Int64 SponsorRegistrationId)
        {
            Entities.SponsorRegistrations objSponsorRegistrations = new Entities.SponsorRegistrations();
            Entities.Members objMembers = new Entities.Members();

            int status = 0;
            try
            {
                int _qstatus = 0;
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);
                objSponsorRegistrations = _SponsorRegistration.GetSponsorRegistrationsById(SponsorRegistrationId, ref status);

                int Status1 = 0;
                List<Entities.SponsorRegistrationCategories> lstSponsorRegistrationCategories = _SponsorRegistrationCategories.GetSponsorRegistrationCategoriesList(ref Status1);

                ViewBag.lstSponsorRegistrationCategories = lstSponsorRegistrationCategories;
                if (objSponsorRegistrations == null && objMembers == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "SponsorRegistrations");
                }

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "SponsorRegistrations");
            }
            ViewBag.objSponsorRegistrations = objSponsorRegistrations;
            ViewBag.objMembers = objMembers;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddSponsorRegistration(Entities.SponsorRegistrations objSponsorRegistrations)
        {
            try
            {
                Int64 SponsorRegistrationId = 0;

                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                

                objSponsorRegistrations.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objSponsorRegistrations.InsertedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _SponsorRegistration.InsertSponsorRegistrations(objSponsorRegistrations, ref SponsorRegistrationId, ref imageurl);
                if (_status == 1)
                {
                    if (imageurl != "")
                    {
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\SponsorRegistrations\\NormalImages\\" + imageurl);

                        image.Resize(130, 130, true, false);
                        image.Crop(1, 1, 1, 1);
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\SponsorRegistrations\\ThumbImages\\" + imageurl);

                    }
                    TempData["message"] = "<div class=\"success closable\">Created SponsorRegistration Successfully</div>";
                    return RedirectToAction("Index", "SponsorRegistrations");
                }
                if (_status == 2)
                {
                    if (imageurl != "")
                    {
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\SponsorRegistrations\\NormalImages\\" + imageurl);

                        image.Resize(130, 130, true, false);
                        image.Crop(1, 1, 1, 1);
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\SponsorRegistrations\\ThumbImages\\" + imageurl);

                    }

                    TempData["message"] = "<div class=\"success closable\">Updated SponsorRegistration Successfully</div>";
                    return RedirectToAction("EditSponsorRegistration", "SponsorRegistrations", new { SponsorRegistrationId = objSponsorRegistrations.SponsorRegistrationId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("Index", "SponsorRegistrations");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "SponsorRegistrations");
            }

        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult SponsorRegistrationsStatus(Int64 SponsorRegistrationId)
        {
            string str = "";
            try
            {
                Int64 _status = _SponsorRegistration.UpdateSponsorRegistrationsStatus(SponsorRegistrationId);
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
        public void ExportSponsorRegistrationsToExcel(Int64 SponsorRegistrationCategoryId = 0, Int64 EventId = 0, string search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            try
            {
                int Total = 0;
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DSponsorRegistration.ExportSponserRegistrationList(SponsorRegistrationCategoryId, EventId, search, Sort, PageNo, PageItems, ref Total);
                if (dtUni.Rows.Count != 0)
                {
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dtUni, "Sponsor-Registration-Export");

                        Response.Clear();
                        Response.Buffer = true;
                        Response.Charset = "";
                        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                        Response.AddHeader("content-disposition", "attachment;filename=Sponsor-Registration-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".xlsx");
                        using (MemoryStream MyMemoryStream = new MemoryStream())
                        {
                            wb.SaveAs(MyMemoryStream);
                            MyMemoryStream.WriteTo(Response.OutputStream);
                            Response.Flush();
                            Response.End();
                        }
                    }
                }
                else
                {
                    TempData["message"] = "<div class=\"success closable\">No records found for your search.</div>";
                }

            }
            catch (Exception ex)
            {
                TempData["message"] = "<div class=\"error closable\">" + ex.Message + "</div>";
            }
        }

    }
}
