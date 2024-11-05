using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Youth,")]
    public class YouthController : Controller
    {
        WATS.BLL.YouthUserInfo _YouthUserInfo = new WATS.BLL.YouthUserInfo();
        List<WATS.Entities.YouthUserInfo> lstYouthUserInfo = new List<Entities.YouthUserInfo>();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult YouthList(string StartDate = "", string EndDate = "", string search = "", string SortColumn = "UpdatedTime", string SortOrder = "DESC", int PageNo = 1, int PageItems = 10)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            try
            {
                lstYouthUserInfo = _YouthUserInfo.GetYouthUserInfoListByVariable(StartDate, EndDate, HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.items = PageItems;
            ViewBag.pageno = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.lstYouthUserInfo = lstYouthUserInfo;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddYouth(Entities.YouthUserInfo objYouthUserInfo)
        {
            try
            {
                objYouthUserInfo.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _YouthUserInfo.UpdateYouthUserInfo(objYouthUserInfo);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Created Youth Details Successfully</div>";
                    return RedirectToAction("Index", "Youth");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated Youth Details Successfully</div>";
                    return RedirectToAction("Index", "Youth");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("EditYouth", "Youth");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditYouth", "Youth");
            }

        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditYouth(Int64 YouthUserInfoId = 0)
        {
            try
            {
                int _qstatus = 0;
                Entities.YouthUserInfo _objYouthUserInfo = _YouthUserInfo.GetYouthUserInfoById(YouthUserInfoId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objYouthUserInfo = _objYouthUserInfo;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Youth");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Youth");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewYouth(Int64 YouthUserInfoId = 0)
        {
            try
            {
                int _qstatus = 0;
                Entities.YouthUserInfo _objYouthUserInfo = _YouthUserInfo.GetYouthUserInfoById(YouthUserInfoId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objYouthUserInfo = _objYouthUserInfo;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Youth");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Youth");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteYouth(Int64 YouthUserInfoId)
        {
            string str = "";
            try
            {
                Int64 _status = _YouthUserInfo.DeleteYouthUserInfoById(YouthUserInfoId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted youth details successfully</div>";
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
    }
}
