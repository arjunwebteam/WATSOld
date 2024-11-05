using WATS.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Donors")]
    public class DonorsController : Controller
    {
        WATS.BLL.Donors _Donor = new WATS.BLL.Donors();
        BLL.Members _Members = new BLL.Members();
        BLL.DonationCategories _DonationCategories = new BLL.DonationCategories();
        WATS.Entities.Donors objRequestCalls = new WATS.Entities.Donors();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult DonorsList(string search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            try
            {
                lstDonors = _Donor.GetDonorsListByVariable(HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
               
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.Total = Total;
            ViewBag.items = PageItems;
            ViewBag.PageNo = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.lstDonors = lstDonors;
            return View();
        }

        public JsonResult DeleteDonor(Int64 DonorId)
        {
            string str = "";
            try
            {
                Int64 _status = _Donor.DeleteDonor(DonorId);
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

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewDonor(Int64 DonorId)
        {
            Entities.Donors objDonors = new Entities.Donors();
            int status = 0;
            try
            {
                objDonors = _Donor.GetDonorsById(DonorId, ref status);

                if (objDonors == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "Donors");
                }

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Donors");
            }

            ViewBag.objDonors = objDonors;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditDonor(Int64 DonorId)
        {
            Entities.Donors objDonors = new Entities.Donors();
            Entities.Members objMembers = new Entities.Members();
            List<Entities.DonationCategories> lstDonationCategories = new List<Entities.DonationCategories>();

            int status = 0;
            int Donationstatus = 0;
            try
            {
                int _qstatus = 0;
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);
                objDonors = _Donor.GetDonorsById(DonorId, ref status);
                lstDonationCategories = _DonationCategories.FEDonationCategoriesGetList(ref Donationstatus);

                if (objDonors == null && objMembers == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "Donors");
                }

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Donors");
            }
            ViewBag.lstDonationCategories = lstDonationCategories;
            ViewBag.objDonors = objDonors;
            ViewBag.objMembers = objMembers;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult AddDonor(Entities.Donors objDonors)
        {
            try
            {
                Int64 DonorId = 0;

                objDonors.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objDonors.InsertedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _Donor.InsertDonors(objDonors, ref DonorId);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Created Donor Successfully</div>";
                    return RedirectToAction("Index", "Donors");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated Donor Successfully</div>";
                    return RedirectToAction("EditDonor", "Donors", new { DonorId = objDonors.DonorId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("Index", "Donors");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Donors");
           
            }

            return View();
        }

        [Models.SessionClass.SessionExpireFilter]

        public ActionResult AddDonor(Int64 DonationCategoryId = 0)
        {
            Entities.Members objMembers = new Entities.Members();
            List<Entities.DonationCategories> lstDonationCategories = new List<Entities.DonationCategories>();

            int Donationstatus = 0;
            try
            {
                int _qstatus = 0;
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);
                lstDonationCategories = _DonationCategories.GetDonationCategoriesList(ref Donationstatus);
                //List<Entities.DonationCategories> lstDonationCategories = _DonationCategories.GetDonationCategoriesList(ref _qstatus);
                if (_qstatus == 1)
                {
                    ViewBag.lstDonationCategories = lstDonationCategories;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Donors");
                }
            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.DonationCategoryId = DonationCategoryId;
            ViewBag.objMembers = objMembers;
            return View();
        }

        //{
        //    int _qstatus = 0;
        //    try
        //    {
        //        List<Entities.DonationCategories> lstDonationCategories = _DonationCategories.GetDonationCategoriesList(ref _qstatus);

        //        if (_qstatus == 1)
        //        {
        //            ViewBag.lstDonationCategories = lstDonationCategories;
        //            ViewBag.status = _qstatus;
        //        }
        //        else
        //        {
        //            TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
        //            return RedirectToAction("Index", "Donors");
        //        }
        //    }
        //    catch
        //    {
        //        ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
        //    }
        //    ViewBag.CategoryName = CategoryName;
        //    return View();
        //}
       

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult DonorsStatus(Int64 DonorId)
        {
            string str = "";
            try
            {
                Int64 _status = _Donor.UpdateDonorsStatus(DonorId);
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
