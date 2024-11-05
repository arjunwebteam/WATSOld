using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Sponsors,WebMaster,Treasurer,VicePresident,")]
    public class SponsorsController : Controller
    {
        WATS.BLL.Sponsors _Sponsors = new WATS.BLL.Sponsors();
        List<Entities.Sponsors> lstSponsors = new List<Entities.Sponsors>();
        WATS.BLL.SponsorCategories _SponsorCategory = new WATS.BLL.SponsorCategories();
        List<Entities.SponsorCategories> lstSponsorCategories = new List<Entities.SponsorCategories>();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 SponsorCategoryId = 0)
        {
            int status = 0;
            try
            {
                lstSponsorCategories = _SponsorCategory.GetSponsorCategoriesList(ref status);
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.lstSponsorCategories = lstSponsorCategories;
            ViewBag.SponsorCategoryId = SponsorCategoryId;
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult SponsorsList(Int64 SponsorCategoryId = 0, string search = "", int PageNo = 1, int PageItems = 10, string SortColumn = "", string SortOrder = "")
        {
             string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                int Total = 0;
            try
            {

                lstSponsors = _Sponsors.GetSponsorsListByVariable(SponsorCategoryId,HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
               
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.total = Total;
            ViewBag.items = PageItems;
            ViewBag.pageno = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder;
            ViewBag.lstSponsorsList = lstSponsors;
            return View();
        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddSponsors(Entities.Sponsors objSponsor)
        {
            try
            {

                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                objSponsor.InsertedBy = this.User.Identity.Name;
                Int64 _status = _Sponsors.InsertSponsors(objSponsor, ref imageurl);
                if (_status != -1)
                {
                    if (imageurl != "")
                    {
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\Sponsors\\NormalImages\\" + imageurl);

                        image.Resize(130, 130, true, false);
                        image.Crop(1, 1, 1, 1);
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\Sponsors\\ThumbImages\\" + imageurl);

                    }
                    TempData["message"] = "<div class=\"success closable\">Sponsor Uploaded successfully.</div>";
                    return RedirectToAction("Index", "Sponsors", new {SponsorCategoryId= objSponsor.SponsorCategoryId});

                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\"Uploading Failed.</div>";
                    return RedirectToAction("Index", "Sponsors", new { SponsorCategoryId = objSponsor.SponsorCategoryId });
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Sponsors", new { SponsorCategoryId = objSponsor.SponsorCategoryId });
            }
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult EditSponsor(Int64 SponsorId)
        {
            string str = "";
            int status = 0;
            try
            {
                Entities.Sponsors objSponsors = _Sponsors.GetSponsorById(SponsorId, ref status);
                if (objSponsors != null)
                {
                    return Json(new { ok = true, data = objSponsors });
                }
                else
                {
                    str = "<div class=\"success closable\">Failed Transaction</div>";
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
        public JsonResult DeleteSponsor(Int64 SponsorId, string BannerUrl = "")
        {
            string str = "";
            try
            {
                Int64 _status = _Sponsors.DeleteSponsor(SponsorId);
                if (_status == 1)
                {
                    if (System.IO.File.Exists(ConfigurationManager.AppSettings["uploadpath"] + @"\\Sponsors\\NormalImages\\" + BannerUrl))
                    {
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\Sponsors\\NormalImages\\" + BannerUrl);
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\Sponsors\\ThumbImages\\" + BannerUrl);
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

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult SponsorStatus(Int64 SponsorId)
        {
            string str = "";
            try
            {
                Int64 _status = _Sponsors.UpdateSponsorsStatus(SponsorId);
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
        public JsonResult SponsorDisplayOrder(int DisplayOrder, Int64 SponsorId)
        {
            string str = "";
            try
            {
                Int64 _status = _Sponsors.UpdateSponsorsDisplayOrder(DisplayOrder, SponsorId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Updated order no successfully</div>";
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

        #region Sponsor Categories

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Category()
        {
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult SponsorCategoriesList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstSponsorCategories = _SponsorCategory.GetSponsorCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
               
            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstSponsorCategories = lstSponsorCategories;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddSponsorCategory(Entities.SponsorCategories objSponsorCategory)
        {
            string str = "";
            bool _bool = true;
            try
            {
                objSponsorCategory.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _SponsorCategory.InsertSponsorCategories(objSponsorCategory);
                switch (_status)
                {
                    case 1:
                        str = "<div class=\"success closable\"> Inserted Category details successfully.</div>";
                        _bool = true;
                        break;
                    case 2:
                        str = "<div class=\"success closable\"> Updated Category details successfully.</div>";
                        _bool = true;
                        break;
                    case -1:
                        str = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        _bool = false;
                        break;
                    default:
                        str = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        _bool = false;
                        break;
                }
            }
            catch 
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
                _bool = false;
            }

            return Json(new { ok = _bool, data = str });

        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditSponsorCategory(Int64 SponsorCategoryId = 0)
        {
            string str = "";
            try
            {
                int _qstatus = 0;
                Entities.SponsorCategories _objSponsorCategory = _SponsorCategory.GetSponsorCategoryById(SponsorCategoryId, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objSponsorCategory });
                }
                else
                {
                    str = "<div class=\"success closable\">Failed Transaction</div>";
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
        [HttpPost]
        public JsonResult DeleteSponsorCategory(Int64 SponsorCategoryId)
        {
            string str = "";
            try
            {
                Int64 _status = _SponsorCategory.DeleteSponsorCategory(SponsorCategoryId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted Sponsor Category successfully</div>";
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

        #endregion  
    }
}
