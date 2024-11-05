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
      [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,InnerPages,SubAdmin,")]
    public class InnerPagesController : Controller
    {
        BLL.InnerPages _innerpages = new BLL.InnerPages();
        List<Entities.InnerPages> lstInnerPages = new List<Entities.InnerPages>();
        BLL.InnerPageCategories _InnerPageCategory = new BLL.InnerPageCategories();
        List<Entities.InnerPageCategories> lstInnerPageCategory = new List<Entities.InnerPageCategories>();

        #region InnerPages

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 InnerPageCategoryId=0)
        {

            ViewBag.userrole = (Session["userrole"]!=null?Session["userrole"].ToString():"");
            int _qstatus = 0;
            try
            {
                List<Entities.InnerPageCategories> _lstInnerPageCategory = _InnerPageCategory.GetInnerPageCategoriesList(ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.lstInnerPageCategory = _lstInnerPageCategory;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "InnerPages");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.InnerPageCategoryId = InnerPageCategoryId;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult DetailsList(Int64 InnerPageCategoryId = 0, string Search = "", string SortColumn = "UpdatedTime", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstInnerPages = _innerpages.GetInnerPagesListByVariable(InnerPageCategoryId,Search, Sort, PageNo, Items, ref Total);
                
            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstInnerPages = lstInnerPages;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddDetails()
        {
            try
            {
               
                int _qstatus = 0;
                List<Entities.InnerPageCategories> _lstInnerPageCategory = _InnerPageCategory.GetInnerPageCategoriesList(ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.lstInnerPageCategory = _lstInnerPageCategory;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "InnerPages");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "InnerPages");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddDetails(Entities.InnerPages objInnerPages)
        {
            try
            {               
                objInnerPages.InsertedBy = HttpContext.User.Identity.Name.ToString();
                objInnerPages.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objInnerPages.IsActive = true;
                Int64 _status = _innerpages.InsertInnerPages(objInnerPages);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Created Page Successfully</div>";
                    return RedirectToAction("Index", "InnerPages");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated Page Successfully</div>";
                    return RedirectToAction("EditDetails", "InnerPages", new { InnerPageId = objInnerPages.InnerPageId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("AddDetails", "InnerPages");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddDetails", "InnerPages");
            }

        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditDetails(Int64 InnerPageId = 0)
        {
            try
            {
               
                int qstatus = 0;
                List<Entities.InnerPageCategories> _lstInnerPageCategory = _InnerPageCategory.GetInnerPageCategoriesList(ref qstatus);

                int _qstatus = 0;
                Entities.InnerPages _objInnerPages = _innerpages.GetInnerPagesById(InnerPageId, ref _qstatus);

                if (_qstatus == 1 && qstatus==1)
                {
                    ViewBag.objDetails = _objInnerPages;
                    ViewBag.lstInnerPageCategory = _lstInnerPageCategory;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "InnerPages");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "InnerPages");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewDetails(Int64 InnerPageId = 0)
        {
            try
            {
               
                int _qstatus = 0;
                Entities.InnerPages _objInnerPages = _innerpages.GetInnerPagesById(InnerPageId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objDetails = _objInnerPages;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "InnerPages");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "InnerPages");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteDetails(Int64 InnerPageId)
        {
            string str = "";
            try
            {
               
                Int64 _status = _innerpages.DeleteInnerPages(InnerPageId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted page successfully</div>";
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

        [HttpPost]
        public JsonResult InnerPageDisplayOrder(int DisplayOrder, Int64 InnerPageId)
        {
            string str = "";
            try
            {
                Int64 _status = _innerpages.UpdateInnerPagesDisplayOrder(DisplayOrder, InnerPageId);
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

        #endregion       
        
    }
}
