using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    //[Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Members,")]
    public class MailTemplatesController : Controller
    {
        BLL.MailTemplates _MailTemplate = new BLL.MailTemplates();
        List<Entities.MailTemplates> lstMailTemplate = new List<Entities.MailTemplates>();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {           
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult MailTemplatesList(string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstMailTemplate = _MailTemplate.GetMailTemplatesListByVariable(Search, Sort, PageNo, Items, ref Total);
               
            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstMailTemplate = lstMailTemplate;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddMailTemplate()
        {           
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMailTemplate(Entities.MailTemplates objMailTemplate)
        {
            try
            {
               
                objMailTemplate.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _MailTemplate.InsertMailTemplates(objMailTemplate);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Created MailTemplate Successfully</div>";
                    return RedirectToAction("Index", "MailTemplates");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated MailTemplate Successfully</div>";
                    return RedirectToAction("Index", "MailTemplates");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("AddMailTemplate", "MailTemplates");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddMailTemplate", "MailTemplates");
            }

        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditMailTemplate(Int64 MailTemplateId = 0)
        {
            try
            {
               
                int _qstatus = 0;
                Entities.MailTemplates objTemplates = _MailTemplate.GetMailTemplateById("",MailTemplateId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objTemplates = objTemplates;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "MailTemplates");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "MailTemplates");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewMailTemplate(Int64 MailTemplateId = 0)
        {
            try
            {
               
                int _qstatus = 0;
                Entities.MailTemplates objTemplates = _MailTemplate.GetMailTemplateById("",MailTemplateId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objTemplates = objTemplates;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "MailTemplates");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "MailTemplates");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteMailTemplate(Int64 MailTemplateId)
        {
            string str = "";
            try
            {
                Int64 _status = _MailTemplate.DeleteMailTemplate(MailTemplateId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted Mail Template successfully</div>";
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
