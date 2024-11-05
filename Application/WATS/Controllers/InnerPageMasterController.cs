using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,InnerPages,SubAdmin,")]
    public class InnerPageMasterController : Controller
    {
        BLL.InnerPageCategories _InnerPageCategory = new BLL.InnerPageCategories();
        List<Entities.InnerPageCategories> lstInnerPageCategory = new List<Entities.InnerPageCategories>();

        #region InnerPageCategories

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {           
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult InnerPageCategoriesList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstInnerPageCategory = _InnerPageCategory.GetInnerPageCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);
               
            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstInnerPageCategory = lstInnerPageCategory;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddInnerPageCategory(Entities.InnerPageCategories objInnerPageCategory)
        {
           
            string str = "";
            bool _bool = true;
            try
            {
                objInnerPageCategory.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _InnerPageCategory.InsertInnerPageCategory(objInnerPageCategory);
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
        public ActionResult EditInnerPageCategory(Int64 InnerPageCategoryId = 0)
        {
           
            string str = "";
            try
            {
                int _qstatus = 0;
                Entities.InnerPageCategories _objInnerPageCategory = _InnerPageCategory.GetInnerPageCategoryById(InnerPageCategoryId, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objInnerPageCategory });
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
        public JsonResult DeleteInnerPageCategory(Int64 InnerPageCategoryId)
        {
            string str = "";
            try
            {
                Int64 _status = _InnerPageCategory.DeleteInnerPageCategory(InnerPageCategoryId);
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

        #endregion  

    }
}
