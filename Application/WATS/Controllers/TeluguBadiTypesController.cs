using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
     [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,TeluguBadiTypes")]
    public class TeluguBadiTypesController : Controller
    {
        BLL.TeluguBadiTypes _TeluguBadiTypes = new BLL.TeluguBadiTypes();
        List<Entities.TeluguBadiTypes> lstTeluguBadiTypes = new List<Entities.TeluguBadiTypes>();

        #region TeluguBadiTypes

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult TeluguBadiTypesList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstTeluguBadiTypes = _TeluguBadiTypes.GetTeluguBadiTypesListByVariable(Search, Sort, PageNo, Items, ref Total);

            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstTeluguBadiTypes = lstTeluguBadiTypes;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();

            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddTeluguBadiType(Entities.TeluguBadiTypes objTeluguBadiTypes)
        {
            string str = "";
            bool _bool = true;
            try
            {
                objTeluguBadiTypes.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objTeluguBadiTypes.InsertedBy = HttpContext.User.Identity.Name.ToString();
                objTeluguBadiTypes.InsertedDate = DateTime.Now;
                objTeluguBadiTypes.UpdatedDate = DateTime.Now;
              Int64 _status = _TeluguBadiTypes.InsertTeluguBadiTypes(objTeluguBadiTypes);
                switch (_status)
                {
                    case 1:
                        str = "<div class=\"success closable\"> Inserted TeluguBadi Type details successfully.</div>";
                        _bool = true;
                        break;
                    case 2:
                        str = "<div class=\"success closable\"> Updated TeluguBadi Type details successfully.</div>";
                        _bool = true;
                        break;
                    case 3:
                        str = "<div class=\"error-alert closable\">'" + objTeluguBadiTypes.Type + "' is already existed..</div>";
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
        public ActionResult EditTeluguBadiType(Int64 TeluguBadiTypeId = 0)
        {
            string str = "";
            try
            {

                int _qstatus = 0;
                Entities.TeluguBadiTypes _objTeluguBadiTypes = _TeluguBadiTypes.GetTeluguBadiTypesById(TeluguBadiTypeId, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objTeluguBadiTypes });
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
        public JsonResult DeleteTeluguBadiType(Int64 TeluguBadiTypeId)
        {
            string str = "";
            try
            {

                Int64 _status = _TeluguBadiTypes.DeleteTeluguBadiTypes(TeluguBadiTypeId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted TeluguBadi Type successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed deleting TeluguBadi Type</div>";
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
        public JsonResult TeluguBadiTypeStatus(Int64 TeluguBadiTypeId)
        {
            string str = "";
            try
            {

                Int64 _status = _TeluguBadiTypes.UpdateTeluguBadiTypesStatus(TeluguBadiTypeId);
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
        public JsonResult TeluguBadiTypeDisplayOrder(int DisplayOrder, Int64 TeluguBadiTypeId)
        {
            string str = "";
            try
            {
                Int64 _status = _TeluguBadiTypes.UpdateTeluguBadiTypesDisplayOrder(DisplayOrder, TeluguBadiTypeId);
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
