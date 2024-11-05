using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WATS;

namespace WATS.Admin.Controllers
{
     [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,")]
    public class PaymentSettingsController : Controller
    {
        BLL.PaymentSettings _PaymentSettings = new WATS.BLL.PaymentSettings();
        Entities.PaymentSettings objPaymentSettings = new WATS.Entities.PaymentSettings();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult PartialList(string search = "",int PageNo = 1, int PageItems = 5)
        {
             int Total = 0;
             List<Entities.PaymentSettings> lstPaymentSettings = new List<Entities.PaymentSettings>();
            try
            {

                lstPaymentSettings = _PaymentSettings.GetPaymentSettingsList(HttpUtility.UrlDecode(search.Trim()), PageNo, PageItems, ref Total);
               
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.pageno = PageNo;
            ViewBag.iterms = PageItems;
            ViewBag.total = Total;
            ViewBag.list = lstPaymentSettings;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Add(Int64 PaymentSettingId=0)
        {
            try
            {
                int status = 0;
                ViewBag.CurrencyCodesList = _PaymentSettings.GetCurrencyCodesList(ref status);
                ViewBag.PaymentMethodsList = _PaymentSettings.GetPaymentMethodsList(ref status);

                if (PaymentSettingId != 0)
                {
                    WATS.Entities.PaymentSettings objPaymentSettings = _PaymentSettings.GetPaymentSettingsDetails(PaymentSettingId, "", ref status);
                    ViewBag.objPaymentSettings = objPaymentSettings;
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
           
            return View();
        }


        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult View(Int64 Id)
        {
            string str = "";
            int status = 0;
            try
            {
                WATS.Entities.PaymentSettings objPaymentSettings = _PaymentSettings.GetPaymentSettingsDetails(Id, "", ref status);
                if (objPaymentSettings != null)
                {
                    return Json(new { ok = true, data = objPaymentSettings });
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

        public ActionResult UpdateAppInfo(WATS.Entities.PaymentSettings objPaymentSettings)
        {
            try
            {
                objPaymentSettings.PaymentPassword = "";
                Int64 status = _PaymentSettings.UpdatePaymentSettingsDetails(objPaymentSettings);
                if (status != -1)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated payment settings successfully.</div>";
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed updating payment settings.</div>";
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return RedirectToAction("Index", "PaymentSettings");
        }

        [HttpPost]
       [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult Delete(Int64 Id)
        {
            string str = "";
            try
            {
                Int64 _status = _PaymentSettings.DeletePaymentSettingById(Id);
                if (_status == 1)
                {
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
        public JsonResult PaymentSettingstatus(Int64 PaymentSettingId)
        {
            string str = "";
            try
            {
                Int64 _status = _PaymentSettings.UpdatePaymentSettingApprovalById(PaymentSettingId);
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

    }
}
