using WATS.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Donors,Treasurer,WebMaster,VicePresident,")]
    public class DonorsController : Controller
    {
        WATS.BLL.Donors _Donor = new WATS.BLL.Donors();
        BLL.Members _Members = new BLL.Members();
        BLL.DonationCategories _DonationCategories = new BLL.DonationCategories();
        WATS.Entities.Donors objRequestCalls = new WATS.Entities.Donors();
        BLL.MailTemplates _MailTemplates = new BLL.MailTemplates();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(string LType = "")
        {
            ViewBag.LType = LType;
            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult DonorsList(string LType = "", string search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Donors> lstDonors = new List<Entities.Donors>();
            try
            {
                lstDonors = _Donor.GetDonorsListByVariable(LType, HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
               
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
                    Entities.Donors objDonordetails = new Entities.Donors();
                    int status1 = 0;
                    Int64 result = 0;
                    int result1 = 0;
                    string Username = "";
                    objDonordetails = _Donor.GetDonorsById(DonorId, ref result1);

                    int _status1 = 0;
                    Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Thank you for giving donation", 0, ref _status1);
                    if (objTemplates != null)
                    {
                        StringBuilder body = new StringBuilder();
                        body.Append(objTemplates.Description);
                        body.Replace("[usersiteurl]", ConfigurationManager.AppSettings["baseurl"].ToString());
                        body.Replace("[UserName]", BLL.Common.UppercaseFirst(objDonordetails.FirstName + " " + objDonordetails.LastName));
                        body.Replace("[FirstName]", objDonordetails.FirstName);
                        body.Replace("[LastName]", objDonordetails.LastName);
                        body.Replace("[Email]", objDonordetails.Email);
                        body.Replace("[PhoneNo]", objDonordetails.PhoneNo);
                        body.Replace("[Address]", (objDonordetails.Address == "" ? "N/A" : objDonordetails.Address));
                        body.Replace("[DonationCause]", objDonordetails.DonationCause);
                        body.Replace("[DonationProgram]", objDonordetails.DonationProgram);
                        body.Replace("[DonationAmount]", objDonordetails.Amount.ToString());
                        body.Replace("[TransactionId]", objDonordetails.TransactionId);
                        body.Replace("[PaymentStatus]", objDonordetails.PaymentStatus);
                        body.Replace("[PaymentDate]", objDonors.OrderDate.ToString());
                        body.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                        body.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                        body.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                        body.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                        body.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                        BLL.Common.SendMailwithfrom(objDonordetails.Email, ConfigurationManager.AppSettings["adminemailid"].ToString(), objTemplates.Subject, body.ToString());
                    }
                    Entities.MailTemplates objTemplates1 = _MailTemplates.GetMailTemplateById("Donate for Admin", 0, ref _status1);
                    if (objTemplates1 != null)
                    {
                        StringBuilder body1 = new StringBuilder();
                        body1.Append(objTemplates1.Description);
                        body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["baseurl"].ToString());
                        body1.Replace("[UserName]", BLL.Common.UppercaseFirst(objDonordetails.FirstName + " " + objDonordetails.LastName));
                        body1.Replace("[FirstName]", objDonordetails.FirstName);
                        body1.Replace("[LastName]", objDonordetails.LastName);
                        body1.Replace("[Email]", objDonordetails.Email);
                        body1.Replace("[PhoneNo]", objDonordetails.PhoneNo);
                        body1.Replace("[Address]", (objDonordetails.Address == "" ? "N/A" : objDonordetails.Address));
                        body1.Replace("[DonationCause]", objDonordetails.DonationCause);
                        body1.Replace("[DonationProgram]", objDonordetails.DonationProgram);
                        body1.Replace("[DonationAmount]", objDonordetails.Amount.ToString());
                        body1.Replace("[TransactionId]", objDonordetails.TransactionId);
                        body1.Replace("[PaymentStatus]", objDonordetails.PaymentStatus);
                        body1.Replace("[PaymentDate]", objDonors.OrderDate.ToString());
                        body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                        body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                        body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                        body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                        body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());

                        BLL.Common.SendMailwithfrom(ConfigurationManager.AppSettings["adminemailid"].ToString(), ConfigurationManager.AppSettings["adminemailid"].ToString(), objTemplates1.Subject, body1.ToString());
                    }

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
