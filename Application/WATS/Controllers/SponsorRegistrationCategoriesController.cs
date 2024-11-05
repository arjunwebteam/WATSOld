using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,SubAdmin,WebMaster,")]
    public class SponsorRegistrationCategoriesController : Controller
    {
        BLL.SponsorRegistrationCategories _SponsorRegistrationCategory = new BLL.SponsorRegistrationCategories();
        WATS.BLL.Events _Events = new WATS.BLL.Events();
        List<Entities.SponsorRegistrationCategories> lstSponsorRegistrationCategory = new List<Entities.SponsorRegistrationCategories>();

        #region SponsorRegistrationCategories

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            int Status=0;
            List<Entities.Events> lstEvents = _Events.SGetEventsList(ref Status);

            ViewBag.lstEvents = lstEvents;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult SponsorRegistrationCategoriesList(Int64 EventId=0,string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstSponsorRegistrationCategory = _SponsorRegistrationCategory.GetSponsorRegistrationCategoriesListByVariable(EventId,Search, Sort, PageNo, Items, ref Total);

            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstSponsorRegistrationCategory = lstSponsorRegistrationCategory;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddSponsorRegistrationCategory(Entities.SponsorRegistrationCategories objSponsorRegistrationCategory)
        {

            string str = "";
            bool _bool = true;
            try
            {
                objSponsorRegistrationCategory.IsActive = true;
                objSponsorRegistrationCategory.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _SponsorRegistrationCategory.InsertSponsorRegistration(objSponsorRegistrationCategory);
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
        public ActionResult EditSponsorRegistrationCategory(Int64 SponsorRegistrationCategoryId = 0)
        {

            string str = "";
            try
            {
                int _qstatus = 0;
                Entities.SponsorRegistrationCategories _objSponsorRegistrationCategory = _SponsorRegistrationCategory.GetSponsorRegistrationById(SponsorRegistrationCategoryId, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objSponsorRegistrationCategory });
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
        public JsonResult DeleteSponsorRegistrationCategory(Int64 SponsorRegistrationCategoryId)
        {
            string str = "";
            try
            {
                Int64 _status = _SponsorRegistrationCategory.DeleteSponsorRegistration(SponsorRegistrationCategoryId);
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
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult SponsorRegistrationCategoryStatus(Int64 SponsorRegistrationCategoryId)
        {
            string str = "";
            try
            {
                Int64 _status = _SponsorRegistrationCategory.UpdateSponsorRegistrationStatus(SponsorRegistrationCategoryId);
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
        public JsonResult SponsorRegistrationCategoryDisplayOrder(int DisplayOrder, Int64 SponsorRegistrationCategoryId)
        {
            string str = "";
            try
            {
                Int64 _status = _SponsorRegistrationCategory.UpdateSponsorRegistrationCategoryDisplayOrder(DisplayOrder, SponsorRegistrationCategoryId);
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
