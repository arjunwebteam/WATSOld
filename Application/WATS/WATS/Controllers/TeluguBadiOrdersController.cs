using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
     [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,TeluguBadiOrders")]
    public class TeluguBadiOrdersController : Controller
    {
        BLL.TeluguBadiOrders _TeluguBadiOrders = new BLL.TeluguBadiOrders();
        List<Entities.TeluguBadiOrders> lstTeluguBadiOrders = new List<Entities.TeluguBadiOrders>();

        #region TeluguBadiOrders

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult TeluguBadiOrdersList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstTeluguBadiOrders = _TeluguBadiOrders.GetTeluguBadiOrdersListByVariable(Search, Sort, PageNo, Items, ref Total);

            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstTeluguBadiOrders = lstTeluguBadiOrders;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();

            return View();
        }


        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddTeluguBadiOrders(Entities.TeluguBadiOrders objTeluguBadiOrders, List<Entities.TeluguBadiStudents> lstTeluguBadiStudents)
        {
            try
            {
                     objTeluguBadiOrders.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                     objTeluguBadiOrders.UpdatedDate = DateTime.Now;
                Int64 TRegistrationId = objTeluguBadiOrders.TRegistrationId;
                Int64 _status = _TeluguBadiOrders.InsertTeluguBadiOrder(objTeluguBadiOrders);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Created TeluguBadiOrders Successfully</div>";
                    return RedirectToAction("Index", "TeluguBadiOrders");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated TeluguBadiOrders Successfully</div>";
                    return RedirectToAction("Index", "TeluguBadiOrders");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("AddTeluguBadiOrders", "TeluguBadiOrders");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddTeluguBadiOrders", "TeluguBadiOrders");
            }

        }



        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditTeluguBadiOrder(Int64 OrderId = 0)
        {
            try
            {
                Entities.TeluguBadiRegistrations objTeluguBadiRegistrations = new Entities.TeluguBadiRegistrations();

                int qstatus = 0;
                objTeluguBadiRegistrations = _TeluguBadiOrders.AddTeluguBadiRequirement(ref qstatus);

                if (qstatus == 1)
                {
                    ViewBag.objTeluguBadiRegistrations = objTeluguBadiRegistrations;
                    ViewBag.status = qstatus;
                }
                int _qstatus = 0;
                Entities.TeluguBadiOrders _objTeluguBadiOrders = _TeluguBadiOrders.GetTeluguBadiOrdersById(OrderId, ref _qstatus);

                if (_qstatus == 1 && qstatus == 1)
                {
                    ViewBag.objTeluguBadiOrders = _objTeluguBadiOrders;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "TeluguBadiOrders");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "TeluguBadiOrders");
            }
            return View();
        }


   
        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteTeluguBadiType(Int64 OrderId)
        {
            string str = "";
            try
            {

                Int64 _status = _TeluguBadiOrders.DeleteTeluguBadiOrders(OrderId);
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

     
        #endregion  
    }
}
