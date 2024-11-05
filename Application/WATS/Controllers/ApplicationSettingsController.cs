using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
     [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,")]
    public class ApplicationSettingsController : Controller
    {
        BLL.AppInfo _appinfo = new BLL.AppInfo();
         
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            try
            {
                int status = 0;                
                Entities.AppInfo objAppInfo = _appinfo.GetAppInfoDetails(ref status);
                if (status != 1)
                {
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.objAppInfo = objAppInfo;
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult UpdateAppInfo(Entities.AppInfo objAppInfo)
        {
            try
            {
                objAppInfo.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 status = _appinfo.UpdateAppInfoDetails(objAppInfo);
                if (status != -1)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated application details successfully.</div>";
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed updating application details.</div>";
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return RedirectToAction("Index", "ApplicationSettings");
        }

    }
}
