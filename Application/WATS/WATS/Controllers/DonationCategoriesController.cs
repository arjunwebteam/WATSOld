using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,DonationCategories")]
    public class DonationCategoriesController : Controller
    {
        BLL.DonationCategories _DonationCategory = new BLL.DonationCategories();
        List<Entities.DonationCategories> lstDonationCategory = new List<Entities.DonationCategories>();

        #region DonationCategories

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult DonationCategoriesList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstDonationCategory = _DonationCategory.GetDonationCategoriesListByVariable(Search, Sort, PageNo, Items, ref Total);

            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstDonationCategory = lstDonationCategory;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();

            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddDonationCategory(Entities.DonationCategories objDonationCategory)
        {
            string str = "";
            bool _bool = true;
            try
            {

                Int64 _status = _DonationCategory.InsertDonationCategories(objDonationCategory);
                switch (_status)
                {
                    case 1:
                        str = "<div class=\"success closable\"> Inserted Donation Category details successfully.</div>";
                        _bool = true;
                        break;
                    case 2:
                        str = "<div class=\"success closable\"> Updated Donation Category details successfully.</div>";
                        _bool = true;
                        break;
                    case 3:
                        str = "<div class=\"error-alert closable\">'" + objDonationCategory.CategoryName + "' is already existed..</div>";
                        _bool = false;
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
        public ActionResult EditDonationCategory(Int64 DonationCategoryId = 0)
        {
            string str = "";
            try
            {

                int _qstatus = 0;
                Entities.DonationCategories _objDonationCategory = _DonationCategory.GetDonationCategoryById(DonationCategoryId, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objDonationCategory });
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
        public JsonResult DeleteDonationCategory(Int64 DonationCategoryId)
        {
            string str = "";
            try
            {

                Int64 _status = _DonationCategory.DeleteDonationCategory(DonationCategoryId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted Donation Category successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed deleting Donation Category</div>";
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
        public JsonResult DonationCategoryStatus(Int64 DonationCategoryId)
        {
            string str = "";
            try
            {

                Int64 _status = _DonationCategory.UpdateDonationCategoryStatus(DonationCategoryId);
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
        public JsonResult DonationCategoryDisplayOrder(int DisplayOrder, Int64 DonationCategoryId)
        {
            string str = "";
            try
            {
                Int64 _status = _DonationCategory.UpdateDonationCategoryDisplayOrder(DisplayOrder, DonationCategoryId);
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
                str = "<div class=\"error closable\">Failed Transaction</div>";
                return Json(new { ok = false, data = str });
            }
        }

        #endregion  

    }
}
