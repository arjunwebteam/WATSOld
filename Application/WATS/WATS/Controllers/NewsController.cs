using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
     [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,News")]
    public class NewsController : Controller
    {
        BLL.News _news = new BLL.News();
        Entities.News objNews = new Entities.News();

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult NewsList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            int Total = 0;
            List<Entities.News> lstNews = new List<Entities.News>();
            try
            {
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                lstNews = _news.GetNewsListByVariable(Search, Sort, PageNo, Items, ref Total);
            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.total = Total;
            ViewBag.lstNews = lstNews;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder;
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Edit(Int64 NewsId)
        {
            string str = "";
            try
            {
                int status = 0;
                objNews = _news.GetNewsById(NewsId, ref status);
                if (status != -1 && objNews != null)
                {
                    ViewBag.objNews = objNews;
                }
                else
                {
                    str = "<div class=\"error closable\">Failed processing your request.</div>";
                    ViewBag.objDetails = "";
                }

            }
            catch 
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult View(Int64 NewsId)
        {
            string str = "";
            try
            {
                int status = 0;
                objNews = _news.GetNewsById(NewsId, ref status);
                if (status != -1 && objNews != null)
                {
                    ViewBag.objNews = objNews;
                    return Json(new { ok = true, data = objNews });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed</div>";
                    return Json(new { ok = false, data = str });
                }

            }
            catch 
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
                return Json(new { ok = false, data = str });
            }
        }


        [Models.SessionClass.SessionExpireFilter]
        public ActionResult Save()
        {
            return View();
        }

        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Save(Entities.News objNews)
        {
            try
            {
                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                objNews.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _news.InsertNews(objNews, ref imageurl);
                switch (_status)
                {
                    case 1:
                        if (image != null)
                        {
                            image.Resize(350, 350, true, false);
                            image.Crop(1, 1, 1, 1);
                            image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\news\\" + imageurl);
                        }
                        TempData["message"] = "<div class=\"success closable\">Inserted news content successfully.</div>";
                        break;
                    case 2:
                        if (image != null)
                        {
                            image.Resize(350, 350, true, false);
                            image.Crop(1, 1, 1, 1);
                            image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\news\\" + imageurl);
                        }
                        TempData["message"] = "<div class=\"success closable\">Updated news content successfully.</div>";
                        break;
                    case -1:
                        TempData["message"] = "<div class=\"error closable\">Failed inserting news details.</div>";
                        break;
                    default:
                        TempData["message"] = "<div class=\"error closable\">Failed inserting news details.</div>";
                        break;
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return RedirectToAction("Index", "News");
        }

        [HttpPost]
        [Models.SessionClass.SessionExpireFilter]
        public JsonResult Delete(Int64 NewsId, string filename)
        {
            string str = "";
            bool _bool = true;

            try
            {
                Int64 _status = _news.DeleteNews(NewsId);
                switch (_status)
                {
                    case 1:
                        if (filename != null && filename != "")
                        {
                            System.IO.File.Delete(ConfigurationManager.AppSettings["uploadPath"] + @"\news\" + filename);
                        }

                        str = "<div class=\"success closable\">Successfully deleted news details.</div>";
                        _bool = true;
                        break;
                    case -1:
                        str = "<div class=\"error closable\">Failed deleting news.</div>";
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

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult NewsStatus(Int64 NewsId)
        {
            string str = "";
            try
            {
                Int64 _status = _news.UpdateNewsStatus(NewsId);
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
        public JsonResult NewsDisplayOrder(int OrderNo, Int64 NewsId)
        {
            string str = "";
            try
            {
                Int64 _status = _news.UpdateNewsDisplayOrder(OrderNo, NewsId);
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

    }
}
