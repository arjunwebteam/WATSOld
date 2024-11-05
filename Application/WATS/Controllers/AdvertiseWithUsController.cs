using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,")]
    public class AdvertiseWithUsController : Controller
    {

        WATS.BLL.AdvertiseWithUs _AdvertiseWithUs = new WATS.BLL.AdvertiseWithUs();
        BLL.Members _Members = new BLL.Members();
        BLL.DonationCategories _DonationCategories = new BLL.DonationCategories();
        WATS.Entities.AdvertiseWithUs objRequestCalls = new WATS.Entities.AdvertiseWithUs();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AdvertiseWithUsList(string search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.AdvertiseWithUs> lstAdvertiseWithUs = new List<Entities.AdvertiseWithUs>();
            try
            {
                lstAdvertiseWithUs = _AdvertiseWithUs.GetAdvertiseWithUsListByVariable(HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);

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
            ViewBag.lstAdvertiseWithUs = lstAdvertiseWithUs;
            return View();
        }

        public JsonResult DeleteAdvertiseWithUs(Int64 AdvertiseWithUsId, string ImageUrl)
        {
            string str = "";
            try
            {
                Int64 _status = _AdvertiseWithUs.DeleteAdvertiseWithUs(AdvertiseWithUsId);
                if (_status == 1)
                {
                    if (System.IO.File.Exists(ConfigurationManager.AppSettings["uploadpath"] + @"\\advertisewithus\\normalimages\\" + ImageUrl))
                    {
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\advertisewithus\\normalimages\\" + ImageUrl);
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
        public ActionResult ViewAdvertiseWithUs(Int64 AdvertiseWithUsId)
        {
            Entities.AdvertiseWithUs objAdvertiseWithUs = new Entities.AdvertiseWithUs();
            int status = 0;
            try
            {
                objAdvertiseWithUs = _AdvertiseWithUs.GetAdvertiseWithUsById(AdvertiseWithUsId, ref status);

                if (objAdvertiseWithUs == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "AdvertiseWithUs");
                }

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "AdvertiseWithUs");
            }

            ViewBag.objAdvertiseWithUs = objAdvertiseWithUs;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditAdvertiseWithUs(Int64 AdvertiseWithUsId)
        {
            Entities.AdvertiseWithUs objAdvertiseWithUs = new Entities.AdvertiseWithUs();
            Entities.Members objMembers = new Entities.Members();
            List<Entities.DonationCategories> lstDonationCategories = new List<Entities.DonationCategories>();

            int status = 0;
            int Donationstatus = 0;
            try
            {
                int _qstatus = 0;
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);
                objAdvertiseWithUs = _AdvertiseWithUs.GetAdvertiseWithUsById(AdvertiseWithUsId, ref status);
                lstDonationCategories = _DonationCategories.FEDonationCategoriesGetList(ref Donationstatus);

                if (objAdvertiseWithUs == null && objMembers == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "AdvertiseWithUs");
                }

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "AdvertiseWithUs");
            }
            ViewBag.lstDonationCategories = lstDonationCategories;
            ViewBag.objAdvertiseWithUs = objAdvertiseWithUs;
            ViewBag.objMembers = objMembers;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddAdvertiseWithUs(Entities.AdvertiseWithUs objAdvertiseWithUs)
        {
            try
            {
                Int64 AdvertiseWithUsId = 0;
                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                objAdvertiseWithUs.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objAdvertiseWithUs.InsertedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _AdvertiseWithUs.InsertAdvertiseWithUs(objAdvertiseWithUs, ref AdvertiseWithUsId, ref imageurl);
                              

                if (_status == 1)
                {
                    if (imageurl != "")
                    {
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\advertisewithus\\normalimages\\" + imageurl);

                    }
                    TempData["message"] = "<div class=\"success closable\">Created Details Successfully</div>";
                    return RedirectToAction("Index", "AdvertiseWithUs");
                }
                if (_status == 2)
                {
                    if (imageurl != "")
                    {
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\advertisewithus\\normalimages\\" + imageurl);

                    }
                    TempData["message"] = "<div class=\"success closable\">Updated Details Successfully</div>";
                    return RedirectToAction("EditAdvertiseWithUs", "AdvertiseWithUs", new { AdvertiseWithUsId = objAdvertiseWithUs.AdvertiseWithUsId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("Index", "AdvertiseWithUs");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "AdvertiseWithUs");
            }

        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult AdvertiseWithUsStatus(Int64 AdvertiseWithUsId)
        {
            string str = "";
            try
            {
                Int64 _status = _AdvertiseWithUs.UpdateAdvertiseWithUsStatus(AdvertiseWithUsId);
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

    }
}
