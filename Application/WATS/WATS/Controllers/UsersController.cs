﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Volunteers,")]
    public class UsersController : Controller
    {

        BLL.Users _user = new BLL.Users();
        Entities.Roles objRoles = new Entities.Roles();
        List<Entities.Roles> lstRoles = new List<Entities.Roles>();
        List<Entities.Roles> userRoles = new List<Entities.Roles>();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(string RoleName = "")
        {
            ViewBag.Title = "Admin Panel User List";
            ViewBag.RoleName = RoleName;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult UserList(string Search="", Int64 UserId = 0, string RoleName = "", string RoleIds = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Users> lstuser = new List<Entities.Users>();
            try
            {
                lstuser = _user.GetUserListByVariable(UserId,RoleIds,Search,Sort, PageNo, Items, ref Total);
               
            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstuser = lstuser;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult CreateUser(Entities.Users objUsers)
        {
            try
            {
                Guid guid = WATS.BLL.Common.generateGUID();
                objUsers.InsertedBy = HttpContext.User.Identity.Name.ToString();
                objUsers.InsertedTime = DateTime.UtcNow;
                objUsers.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objUsers.UpdatedTime = DateTime.UtcNow;
                objUsers.IsApproved = false;
                objUsers.IsLockedOut = false;
                objUsers.IsActivated = false;
                objUsers.RegistrationGUID = guid;
                objUsers.DateActivated = DateTime.MinValue;
                objUsers.LastLoginDate = DateTime.MinValue;
                objUsers.LastPasswordChangedDate = DateTime.MinValue;
                objUsers.RoleName = "Volunteers";

                Int64 _status = _user.InsertUserProfile(objUsers);
                if (_status == 1)
                {
                    StringBuilder body = new StringBuilder();
                    body.Append("<p>Dear " + objUsers.UserName + ", <br /><br />Your account has been created, please find the activation link <a href=\"" + ConfigurationManager.AppSettings["baseurl"] + "Account/UserValidate?name=" + objUsers.UserName + "&id=" + guid.ToString() + "\">here</a>. <br />");
                    body.Append("Thank You,<br />Admin</p>");
                    BLL.Common.SendMail(objUsers.Email, "Account Created - Admin Panel Admin Team", body.ToString());
                    TempData["message"] = "<div class=\"success closable\">Created user account with username " + objUsers.UserName + ".</div>";
                    return RedirectToAction("Index", "Users", new { RoleName = "Admin" });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading image.</div>";
                    return RedirectToAction("Index", "Users", new { RoleName = "Admin" });
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Users", new { RoleName = "Admin" });
            }
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult EditUser(Int64 UserId)
        {
            string str = "";
            try
            {
                Int64 _qstatus = 0;
                Entities.Users _objuser = _user.GetUserDetailsById(UserId, ref _qstatus);

                if (_qstatus == 1)
                {
                    return Json(new { ok = true, data = _objuser });
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
        public ActionResult UpdateUser(Entities.Users _objuser,string Type="")
        {
            try
            {
                int status = 0;
                WATS.Entities.Users _objEuser = _user.GetUserByEmail(_objuser.Email, ref status);
                if (_objEuser.UserId == _objuser.UserId || _objEuser.UserId == 0)
                {
                    _objuser.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                    Int64 _qstatus = _user.UpdateUser(_objuser);
                    TempData["message"] = (_qstatus == 1 ? "<div class=\"success closable\">Updated details successfully.</div>" : "<div class=\"error closable\">Failed editing profile.</div>");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">We have a account with email.</div>";
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            if (Type == "Profile")
            {
                return RedirectToAction("Profile", "Account");
            }
            else
            {
                return RedirectToAction("Index", "Users");
            }
        }

        [Authorize]
        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ChangePassword(Entities.ChangePasswordModel model)
        {
            try
            {
                if (model.UserId != 0)
                {
                    string newpass = WATS.BLL.Password.ComputeHash(model.NewPassword, "SHA512", null);
                    Int64 _pstatus = _user.ChangePassword(model.UserId, newpass);
                    if (_pstatus == 1)
                    {
                        TempData["message"] = "<div class=\"success closable\">Password changed successfully.<div>";
                    }
                    else
                    {
                        TempData["message"] = "<div class=\"error closable\">New password is invalid.</div>";
                    }
                }
                return RedirectToAction("EditUser", "Users", new { UserId = model.UserId });
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditUser", "Users", new { UserId = model.UserId });
            }
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult UserStatus(Int64 UserId)
        {
            string str = "";
            try
            {
                Int64 _status = _user.UpdateUserStatus(UserId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Updated user status successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed updating user status</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch 
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
                return Json(new { ok = true, data = str });
            }
        }


        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult UserAccess(Int64 UserId)
        {
            try
            {
                int _qstatus = 0;
                userRoles = _user.GetUserRolesListById(UserId, ref _qstatus);
                lstRoles = _user.GetUserRolesList(ref _qstatus);
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.lstRoles = lstRoles;
            ViewBag.userRoleslst = userRoles;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public ActionResult UpdateUserAccess(Entities.UserRoles _objuser)
        {
            try
            {
                Int64 _qstatus = _user.UpdateUserAccess(_objuser);
                TempData["message"] = (_qstatus == 1 ? "<div class=\"success closable\">Updated details successfully.</div>" : "<div class=\"error closable\">Failed editing profile.</div>");
               
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            return RedirectToAction("Index", "Users");
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult UserDelete(Int64 UserId)
        {
            string str = "";
            try
            {
                Int64 _status = _user.DeleteUser(UserId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted user successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed deleting user status</div>";
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
        public JsonResult CheckProfileEmailAvailability(Int64 UserId, string Email)
        {
            int status = 0;
            try
            {
                Entities.Users objEuser = _user.GetUserByEmail(Email, ref status);
                bool data = (objEuser.UserId == UserId || objEuser.UserId == 0 ? true : false);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch 
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed transaction.</div>" });
            }
        }

        [HttpPost]
        public JsonResult CheckEmailAvailability(string Email)
        {
            int status = 0;
            try
            {
                Entities.Users objEuser = _user.GetUserByEmail(Email, ref status);
                bool data = (objEuser != null && objEuser.UserId != 0 ? false : true);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed transaction.</div>" });
            }
        }

        [HttpPost]
        public JsonResult CheckUserNameAvailability(string UserName)
        {
            int status = 0;
            try
            {
                Entities.Users objUser = _user.GetUserByUserName(UserName, ref status);
                bool data = (objUser != null && objUser.UserId != 0 ? false : true);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch 
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed transaction.</div>" });
            }
        }
    }
}
