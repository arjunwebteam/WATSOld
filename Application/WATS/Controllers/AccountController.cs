using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Configuration;
using WATS.Entities;
using System.Text;
using WATS.Models;
using System.Web.Helpers;

namespace WATS.Admin.Controllers
{   
    public class AccountController : Controller
    {
        WATS.BLL.Users _user = new WATS.BLL.Users();

        public ActionResult LogOn(string str = "")
        {
            
            if (str == "session")
            {
                ViewBag.Message = "<div class=\"error closable\">Session Expired.</div>";
            }
            if (str == "noaccess")
            {
                ViewBag.Message = "<div class=\"error closable\">Admin need to provide role access.</div>";
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            try
            {
                int _status = 0;
                Entities.Users objUser = _user.GetUserByUserName(model.UserName, ref _status);
                if (objUser != null && objUser.UserId != 0 && objUser.RoleName != "EndUser")
                {
                    if (objUser.IsApproved == true)
                    {
                        int _qstatus = 0;
                        string password = _user.GetPassword(objUser.UserId, ref _qstatus);
                        if (_qstatus == 1)
                        {
                            if (WATS.BLL.Password.VerifyHash(model.Password.Trim(), "SHA512", password) == true)
                            {
                                Session["username"] = HttpContext.User.Identity.Name.ToString();
                                Session["userrole"] = objUser.RoleName;
                                string UserRole = objUser.RoleName;
                                var authTicket = new FormsAuthenticationTicket(
                                    1,                             // version
                                    objUser.UserName,              // user name
                                    DateTime.UtcNow,                  // created
                                    DateTime.UtcNow.AddMinutes(20),   // expires
                                    model.RememberMe,              // persistent?
                                    objUser.RoleName);

                                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                                var authCookie = new HttpCookie("UserCookie", encryptedTicket);
                                HttpContext.Response.Cookies.Add(authCookie);
                                FormsAuthentication.RedirectFromLoginPage(model.UserName, model.RememberMe);
                                if (UserRole.Contains("SuperAdmin"))
                                { return RedirectToAction("Index", "InnerPages"); }
                                else if (UserRole.Contains("Volunteers") || UserRole.Contains("SuperAdmin") || UserRole.Contains("WebMaster") || UserRole.Contains("VicePresident"))
                                { return RedirectToAction("Index", "Volunteers"); }
                                else if (UserRole.Contains("SuperAdmin")|| UserRole.Contains("SubAdmin") || UserRole.Contains("InnerPages"))
                                { return RedirectToAction("Index", "InnerPages"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Events") || UserRole.Contains("WebMaster") || UserRole.Contains("Cultural"))
                                { return RedirectToAction("Index", "Events"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Enquiries") || UserRole.Contains("WebMaster"))
                                { return RedirectToAction("Index", "Enquiry"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Photos") || UserRole.Contains("WebMaster"))
                                { return RedirectToAction("Index", "PhotoGallery"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Videos") || UserRole.Contains("WebMaster"))
                                { return RedirectToAction("Index", "VideoGallery"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Committees") || UserRole.Contains("WebMaster"))
                                { return RedirectToAction("Index", "Committees"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("News") || UserRole.Contains("WebMaster"))
                                { return RedirectToAction("Index", "News"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Members") || UserRole.Contains("WebMaster") || UserRole.Contains("VicePresident") || UserRole.Contains("Cultural") || UserRole.Contains("Treasurer"))
                                { return RedirectToAction("Index", "Members"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Sponsors") || UserRole.Contains("WebMaster") || UserRole.Contains("VicePresident") || UserRole.Contains("Treasurer"))
                                { return RedirectToAction("Index", "Sponsors"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Donors") || UserRole.Contains("WebMaster") || UserRole.Contains("VicePresident") || UserRole.Contains("Treasurer"))
                                { return RedirectToAction("Index", "Donors"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("DonationCategories") || UserRole.Contains("WebMaster") || UserRole.Contains("VicePresident") || UserRole.Contains("Treasurer"))
                                { return RedirectToAction("Index", "DonationCategories"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("Asset"))
                                { return RedirectToAction("Index", "Asset"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("NewsLetter") || UserRole.Contains("WebMaster"))
                                { return RedirectToAction("Index", "NewsLetter"); }
                                else if (UserRole.Contains("SuperAdmin") || UserRole.Contains("SubAdmin") || UserRole.Contains("WebsiteBanners") || UserRole.Contains("WebMaster"))
                                { return RedirectToAction("Index", "WebsiteBanners"); }
                                else if (UserRole.Contains(""))
                                {
                                    ViewBag.Message = "<div class=\"error closable\">Admin need to provide role access.</div>";
                                    return RedirectToAction("LogOn", "Account", new {str="noaccess" });
                                }
                            }
                            else
                            {
                                ViewBag.Message = "<div class=\"error closable\">Username or password is incorrect.</div>";
                            }
                        }
                        else
                        {
                            ViewBag.Message = "<div class=\"error closable\">Username or password is incorrect.</div>";
                        }
                    }
                    else
                    {
                        ViewBag.Message = "<div class=\"error closable\">Your status has been deactivated.Please contact to admin.</div>";
                    }
                }
                else
                {
                    ViewBag.Message = "<div class=\"error closable\">Username or password is incorrect.</div>";
                }

            }
            catch 
            {
                ViewBag.Message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogOn", "Account");
        }

        #region Profile

        public ActionResult ChangePassword()
        {
            int _qstatus = 0;
            Entities.Users _objuser = new Entities.Users();
            try
            {
                _objuser = _user.GetUserByUserName(HttpContext.User.Identity.Name.ToString(), ref _qstatus);
            }
            catch
            {
                ViewBag.Message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.objuser = _objuser;
            return View();
        }

        [Authorize]
        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            try
            {
                if (model.UserId != 0)
                {
                    int _qstatus = 0;
                    string oldpass = _user.GetPassword(model.UserId, ref _qstatus);

                    if (_qstatus == 1)
                    {
                        if (WATS.BLL.Password.VerifyHash(model.OldPassword.Trim(), "SHA512", oldpass) == true)
                        {
                            string newpass = WATS.BLL.Password.ComputeHash(model.NewPassword, "SHA512", null);
                            Int64 _pstatus = _user.ChangePassword(model.UserId, newpass);
                            if (_pstatus == 1)
                            {
                                TempData["message"] = "<div class=\"success closable\">Password changed successfully.</div>";
                            }
                            else
                            {
                                TempData["message"] = "<div class=\"error closable\">The current password is incorrect or the new password is invalid.</div>";
                            }
                        }
                        else
                        {
                            TempData["message"] = "<div class=\"error closable\">The current password is incorrect or the new password is invalid.</div>";
                        }
                    }
                    else
                    {
                        TempData["message"] = "<div class=\"error closable\">The current password is incorrect or the new password is invalid.</div>";
                    }
                }
                return RedirectToAction("Profile", "Account");
            }
            catch
            {
                ViewBag.Message = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Profile", "Account");
            }
            
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Profile()
        {
            try
            {
                int _qstatus = 0;
                Entities.Users _objuser = _user.GetUserByUserName(HttpContext.User.Identity.Name.ToString(), ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objuser = _objuser;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Home");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }

            return View();
        }

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ProfilePic(HttpPostedFileBase file, Int64 UserId)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    var image = WebImage.GetImageFromRequest();
                    string imageurl = (image != null ? image.ImageFormat : "NA");
                    Int64 _status = _user.UpdateUserProfileImage(UserId, ref imageurl);
                    if (_status == 1)
                    {
                        image.Resize(94, 93, true, false);
                        image.Crop(1, 1, 1, 1);
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\UserProfileImages\\" + imageurl);
                        TempData["message"] = "<div class=\"success closable\">Change your profile picture successfully.</div>";
                    }
                    else
                    {
                        TempData["message"] = "<div class=\"error closable\">Failed uploading image.</div>";
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\UserProfileImages\\" +imageurl);
                    }
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return RedirectToAction("Profile", "Account");
        }

        #endregion

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string Email = "")
        {
            try
            {
                int _status = 0;
                Entities.Users _objuser = new Entities.Users();
                _objuser = _user.GetUserByEmail(Email, ref _status);

                if (_objuser.UserId == 0 && _objuser.Email != Email)
                {
                    TempData["message"] = "<div class=\"error closable\">Email is not valid.</div>";
                }
                else
                {
                    if (_objuser.IsLockedOut && _objuser.RoleName.Contains("SuperAdmin"))
                    {
                        Int64 status = _user.UnlockUser(_objuser.UserId);
                    }

                    string _password = BLL.Password.GetUniqueKey(8);
                    string _passwordhash = BLL.Password.ComputeHash(_password, "SHA512", null);

                    Int64 _pstatus = _user.ChangePassword(_objuser.UserId, _passwordhash);
                    if (_pstatus == 1)
                    {
                        StringBuilder body = new StringBuilder();
                        body.Append("<p>Dear " + _objuser.UserName + ", <br /><br />You have requested password retrieve. Please find the login details below. <br />");
                        body.Append("<br />Password: " + _password + " <br /><br /><a href=\"" + ConfigurationManager.AppSettings["adminsiteurl"].ToString() + "\">Click here to Login.</a><br /><br />");
                        body.Append("Thank You,<br />Admin</p>");
                        BLL.Common.SendMail(_objuser.Email, "Password Details From Admin Team", body.ToString());

                        TempData["message"] = "<div class=\"success closable\">Password details sent to Email Id registered.</div>";
                    }
                    else
                    {
                        TempData["message"] = "<div class=\"error closable\">Failed generating password.</div>";
                    }
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return View();
        }

        public ActionResult UserValidate(string name, string id = "")
        {
            try
            {
                int _status = 0;
                Entities.Users objuser = _user.GetUserByUserName(name, ref _status);
                if (objuser.UserName != null)
                {
                    if (_status != -1 && objuser != null)
                    {
                        if (id == "reactivate")
                        {
                            Guid guid = WATS.BLL.Common.generateGUID();
                            objuser.IsActivated = false;
                            objuser.RegistrationGUID = guid;
                            Int64 _guidStatus = _user.UpdateRegistrationGUID(objuser.UserId, "false", guid);
                            if (_guidStatus != -1)
                            {
                                StringBuilder body = new StringBuilder();
                                body.Append("<p>Dear " + objuser.UserName + ", <br /><br />Request for reactivation is accepted, please find the activation link <a href=\"" + ConfigurationManager.AppSettings["baseurl"] + "Account/UserValidate?name=" + objuser.UserName + "&id=" + guid.ToString() + "\">here</a>. <br />");
                                body.Append("Thank You,<br />Admin</p>");
                                BLL.Common.SendMail(objuser.Email, "Account Reactivation Link - ATM Admin Team", body.ToString());

                                ViewBag.message = "<div >Activation details sent to mail.</div>";
                            }
                            else
                            {
                                ViewBag.message = "<div >Failed reactivating account.</div>";
                            }
                        }
                        else
                        {
                            if (!objuser.IsActivated && objuser.RegistrationGUID != Guid.Empty)
                            {
                                if (objuser.RegistrationGUID.ToString() == id)
                                {
                                    string _password = BLL.Password.GetUniqueKey(8);
                                    string _hashpassword = BLL.Password.ComputeHash(_password, "SHA512", null);
                                    Int64 _passStatus = _user.ChangePassword(objuser.UserId, _hashpassword);
                                    if (_passStatus != -1)
                                    {
                                        Int64 _guidStatus = _user.UpdateRegistrationGUID(objuser.UserId, "true", Guid.Empty);

                                        StringBuilder body = new StringBuilder();
                                        body.Append("<p>Dear " + objuser.UserName + ", <br /><br />Your account is activated and password is reset, please find the details below. <br />");
                                        body.Append("<br />User Name: " + objuser.UserName + "<br />Password: " + _password + " <br /><br /><a href=\"" + ConfigurationManager.AppSettings["baseurl"] + "Account/Logon\">Click here to Login.</a><br /><br />");
                                        body.Append("Thank You,<br />Admin</p>");
                                        BLL.Common.SendMail(objuser.Email, "Activation Details From Admin Team", body.ToString());
                                        ViewBag.message = "<div >Hi " + objuser.UserName + ", <br/> Your account is activated successfully. Futher details are posted to mail registered.</div>";
                                    }
                                }
                                else
                                {
                                    ViewBag.message = "<div >Activation link is not valid. Please try <a href=\"UserValidate?name=" + objuser.UserName + "&id=reactivate\">reactivating</a> account.</div>";
                                }
                            }
                            else
                            {
                                ViewBag.message = "<div >User is already activated. <br/>Please click here to <a class=\"red-t\" href='Account/LogOn'>login</a></div>";
                            }
                        }
                    }
                    else
                    {
                        ViewBag.message = "<div >Invalid activation link. Please try again from mail.</div>";
                    }
                }
                else
                {
                    ViewBag.message = "<div >Your account has been removed. So please contact to admin.</div>";
                }
            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return View();
        }

        [HttpPost]
        public JsonResult CheckProfileEmailAvailability(Int64 UserId, string Email)
        {
            try
            {
                int _status = 0;
                Entities.Users objEuser = _user.GetUserByEmail(Email, ref _status);
                bool data = (objEuser.UserId == UserId || objEuser.UserId == 0 ? true : false);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch 
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed transaction.</div>" });
            }
        }

        #region CAPTCHA

        public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }

        [HttpPost]
        public JsonResult GetCaptcha()
        {
            try
            {
                string str = HttpContext.Session["captchastring"].ToString();

                return Json(new { ok = true, data = str, message = "" });
            }
            catch
            {
                return Json(new { ok = false, message ="<div class=\"error closable\">Failed transaction.</div>" });
            }
        }

        #endregion
    }
}
