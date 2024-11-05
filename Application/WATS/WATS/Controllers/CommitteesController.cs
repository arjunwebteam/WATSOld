using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Committees,")]
    public class CommitteesController : Controller
    {
        BLL.Committees _Committees = new BLL.Committees();
        List<Entities.Committees> lstCommittees = new List<Entities.Committees>();
        BLL.CommitteeCategories _CommitteeCategory = new BLL.CommitteeCategories();
        List<Entities.CommitteeCategories> lstCommitteeCategory = new List<Entities.CommitteeCategories>();       

        #region Committees

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 CommitteeCategoryId = 0)
        {
            List<Entities.CommitteeMembers> _lstCommittee = new List<Entities.CommitteeMembers>();
            try
            {

                if (CommitteeCategoryId != 0)
                {
                    int _qstatus = 0;
                    _lstCommittee = _Committees.GetCommitteeMembersListById(CommitteeCategoryId, ref _qstatus);

                    if (_qstatus != 1)
                    {
                        TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                        return RedirectToAction("Index", "Committees");
                    }
                    
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.lstCommittee = _lstCommittee;
            ViewBag.CommitteeCategoryId = CommitteeCategoryId;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult CommitteesList(Int64 CommitteeCategoryId = 0 , string Search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;

            try
            {
                lstCommittees = _Committees.GetCommitteesListByVariable(CommitteeCategoryId,Search, Sort, PageNo, Items, ref Total);
               
            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstCommittees = lstCommittees;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddCommittee()
        {           
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddCommittee(Entities.Committees objCommittees)
        {
            try
            {               
                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                objCommittees.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objCommittees.IsActive = true;
                Int64 _status = _Committees.InsertCommittees(objCommittees, ref imageurl);
                switch (_status)
                {
                    case 1:
                        if (image != null)
                        {
                            image.Resize(350, 350, true, false);
                            image.Crop(1, 1, 1, 1);
                            image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\committees\\normalphoto\\" + imageurl);
                            var image_thumb = image;
                            image_thumb.Resize(120, 150, true, false);
                            image_thumb.Crop(1, 1, 1, 1);
                            image_thumb.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\committees\\thumbphoto\\" + imageurl);
                        }
                        TempData["message"] = "<div class=\"success closable\">Inserted Details successfully.</div>";
                        return RedirectToAction("Index", "Committees");
                    case 2:
                        if (image != null)
                        {
                            image.Resize(350, 350, true, false);
                            image.Crop(1, 1, 1, 1);
                            image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\committees\\normalphoto\\" + imageurl);
                            var image_thumb = image;
                            image_thumb.Resize(120, 150, true, false);
                            image_thumb.Crop(1, 1, 1, 1);
                            image_thumb.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\committees\\thumbphoto\\" + imageurl);
                        }
                        TempData["message"] = "<div class=\"success closable\">Updated Details successfully.</div>";
                        if (objCommittees.CommitteeCategoryId == 0)
                        {
                            return RedirectToAction("Index", "Committees");
                        }
                        else 
                        {
                            return RedirectToAction("Index", "CommitteeMember", new {CommitteeCategoryId= objCommittees.CommitteeCategoryId });
                        }
                    case -1:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        if (image != null)
                        {
                            System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + "\\committees\\thumbphoto\\" + imageurl);
                            System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + "\\committees\\normalphoto\\" + imageurl);
                        }
                        return RedirectToAction("AddCommittee", "Committees");
                    default:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        return RedirectToAction("AddCommittee", "Committees");
                }                
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddCommittee", "Committees");
            }

        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditCommittee(Int64 CommitteeId = 0, Int64 CommitteeCategoryId=0)
        {
            try
            {
               
                int _qstatus = 0;
                Entities.Committees _objCommittees = _Committees.GetCommitteeById(CommitteeId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objCommittees = _objCommittees;
                    ViewBag.CommitteeCategoryId = CommitteeCategoryId;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Committees");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Committees");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewCommittee(Int64 CommitteeId = 0)
        {
            try
            {
               
                int _qstatus = 0;
                Entities.Committees _objCommittees = _Committees.GetCommitteeById(CommitteeId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objDetails = _objCommittees;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Committees");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Committees");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteCommittee(Int64 CommitteeId,string ImageUrl)
        {
            string str = "";
            try
            {
               
                Int64 _status = _Committees.DeleteCommittee(CommitteeId);
                if (_status == 1)
                {
                    if (System.IO.File.Exists(ConfigurationManager.AppSettings["uploadPath"] + @"\committees\normalphoto\" + ImageUrl))
                    {
                        if (System.IO.File.Exists(ConfigurationManager.AppSettings["uploadPath"] + @"\committees\normalphoto\" + ImageUrl))
                        {
                            System.IO.File.Delete(ConfigurationManager.AppSettings["uploadPath"] + @"\committees\normalphoto\" + ImageUrl);
                            System.IO.File.Delete(ConfigurationManager.AppSettings["uploadPath"] + @"\committees\thumbphoto\" + ImageUrl);
                        }
                    }
                    str = "<div class=\"success closable\">Deleted Committee successfully</div>";
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
        public JsonResult CommitteeStatus(Int64 CommitteeId)
        {
            string str = "";
            try
            {
                Int64 _status = _Committees.UpdateCommitteeStatus(CommitteeId);
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
        public JsonResult CommitteeDisplayOrder(int DisplayOrder, Int64 CommitteeId)
        {
            string str = "";
            try
            {
                Int64 _status = _Committees.UpdateCommitteesDisplayOrder(DisplayOrder, CommitteeId);
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
