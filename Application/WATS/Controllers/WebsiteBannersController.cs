using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
     [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,WebsiteBanners,WebMaster")]
    public class WebsiteBannersController : Controller
    {
        WATS.BLL.WebsiteBanners _WebsiteBanners = new WATS.BLL.WebsiteBanners();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {            
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult BannersList(string search = "", int PageNo = 1, int PageItems = 10, string SortColumn = "", string SortOrder = "")
        {
            int Total = 0;
            List<Entities.WebsiteBanners> Bannerslist =new List<Entities.WebsiteBanners>();
            try
            {
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
               
               Bannerslist = _WebsiteBanners.GetWebsiteBannerListByVariable(HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
               
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
            ViewBag.Bannerslist = Bannerslist;
            return View();
        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddWebsiteBanners(Entities.WebsiteBanners objWebsiteBanner)
        {
            try
            {

                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                objWebsiteBanner.UpdatedBy = this.User.Identity.Name;
                Int64 _status = _WebsiteBanners.InsertWebsiteBanners(objWebsiteBanner, ref imageurl);
                if (_status != -1)
                {
                    if (imageurl != "")
                    {
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\WebsiteBanners\\NormalImages\\" + imageurl);
                        
                        image.Resize(130, 130, true, false);
                        image.Crop(1, 1, 1, 1);
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\WebsiteBanners\\ThumbImages\\" + imageurl);
                        
                    }
                    TempData["message"] = "<div class=\"success closable\">Banner Uploaded successfully.</div>";
                    return RedirectToAction("Index", "WebsiteBanners");

                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\"Uploading Failed.</div>";
                    return RedirectToAction("Index", "WebsiteBanners");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "WebsiteBanners");
            }
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult EditBanner(Int64 WebsiteBannerId)
        {
            string str = "";
            int status = 0;
            try
            {
                Entities.WebsiteBanners objWebsiteBanners = _WebsiteBanners.GetWebsiteBannerById(WebsiteBannerId, ref status);
                if (objWebsiteBanners != null)
                {
                    return Json(new { ok = true, data = objWebsiteBanners });
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

        public JsonResult DeleteBanner(Int64 WebsiteBannerId, string BannerUrl = "")
        {
            string str = "";
            try
            {
                Int64 _status = _WebsiteBanners.DeleteWebsiteBanner(WebsiteBannerId);
                if (_status == 1)
                {
                    System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\WebsiteBanners\\NormalImages\\" + BannerUrl);
                    System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\WebsiteBanners\\ThumbImages\\" + BannerUrl);
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
        public JsonResult WebsiteBannersStatus(Int64 WebsiteBannerId)
        {
            string str = "";
            try
            {
                Int64 _status = _WebsiteBanners.UpdateWebsiteBannersStatus(WebsiteBannerId);
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
        public JsonResult WebsiteBannerOrderNo(int OrderNo, Int64 WebsiteBannerId)
        {
            string str = "";
            try
            {
                Int64 _status = _WebsiteBanners.UpdateWebsiteBannersOrderNo(OrderNo, WebsiteBannerId);
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

        public ActionResult Crop(string CategoryName = "", string filename = "", int top = 0, int left = 0, int bottom = 0, int right = 0)
        {
            var image = new WebImage(Path.Combine(ConfigurationManager.AppSettings["uploadPath"] + "\\WebsiteBanners\\NormalImages\\", filename));
            if (image != null)
            {
                image.Crop(top, left, bottom, right);
                image.Resize(145, 80, true, false);
                image.Crop(1, 1, 1, 1);
                image.Save(Path.Combine(ConfigurationManager.AppSettings["uploadPath"] + "\\WebsiteBanners\\ThumbImages\\" + filename));

            }
            return RedirectToAction("Index", "WebsiteBanners", new { Type = "close", CategoryName = CategoryName });
        }

        public ActionResult Preview(Int64 WebsiteBannerId = 0, string filename = "", int imgheight = 0, int imgwidth = 0)
        {
            int status = 0;
            Entities.WebsiteBanners objWebsiteBanners = new Entities.WebsiteBanners();
            try
            {
                objWebsiteBanners = _WebsiteBanners.GetWebsiteBannerById(WebsiteBannerId, ref status);
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }

            var image = new WebImage(Path.Combine(ConfigurationManager.AppSettings["uploadPath"] + "\\WebsiteBanners\\NormalImages\\" + objWebsiteBanners.BannerUrl));
            ViewBag.filename = objWebsiteBanners.BannerUrl;
            ViewBag.imgheight = image.Height;
            ViewBag.imgwidth = image.Width;
            return View();
        }

    }
}
