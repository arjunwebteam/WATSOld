using WATS.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ClosedXML.Excel;

namespace WATS.Admin.Controllers
{
   [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Members,WebMaster,Cultural,Treasurer,VicePresident,")]
    public class MembersController : Controller
    {
        BLL.Members _Members = new BLL.Members();
        DAL.Members _DMembers = new DAL.Members();
        List<Entities.Members> lstMembers = new List<Entities.Members>();
        Entities.Members objMembers = new Entities.Members();
        BLL.MembershipTypes _MembershipType = new BLL.MembershipTypes();
        List<Entities.MembershipTypes> lstMembershipType = new List<Entities.MembershipTypes>();
        BLL.MailTemplates _MailTemplates = new BLL.MailTemplates();

        #region Members

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 MembershipTypeId = 0, string LType = "")
        {
            try
            {
                int _qstatus = 0;
                objMembers = _Members.AddMembershipRequirement(ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objMembers = objMembers;
                    ViewBag.status = _qstatus;
                    
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Members");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.MembershipTypeId = MembershipTypeId;
            ViewBag.LType = LType;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult MembersList(string ListType = "", string Search = "", Int64 MembershipTypeId = 0, Int64 PaymentStatusId = 0, string StartDate = "", string EndDate = "", string ExpiryDate = "", string IsVolunteer = "", string SortColumn = "InsertedTime", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            try
            {
                lstMembers = _Members.GetMembersListByVariable(ListType, Search, MembershipTypeId, PaymentStatusId, StartDate, EndDate, ExpiryDate, IsVolunteer, Sort, PageNo, Items, ref Total);
                
            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstMembers = lstMembers;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddMember()
        {
            try
            {
                int _qstatus = 0;
                objMembers= _Members.AddMembershipRequirement(ref _qstatus);
               
                if (_qstatus == 1)
                {
                    ViewBag.objMembers = objMembers;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Members");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Members");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddMember(Entities.Members objMembers, List<Entities.ChildrenInfo> lstChildrenInfo, HttpPostedFileBase file)
        {
            try
            {
                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");
                Guid guid = WATS.BLL.Common.generateGUID();
                if (objMembers.PaymentMethod == "Cash/Cheque")
                {
                    objMembers.IsApproved = false;
                }
                else
                {
                    objMembers.IsApproved = true;
                }
                objMembers.UpdatedTime = DateTime.UtcNow;
                objMembers.IsApproved = false;
                objMembers.IsLockedOut = false;
                objMembers.Password = BLL.Common.GetRandomString(8);
                objMembers.Password = Password.ComputeHash(objMembers.Password.Trim(), "SHA512", null);
                objMembers.IsActivated = false;
                objMembers.RegistrationGUID = guid;
                objMembers.DateActivated = DateTime.MinValue;
                objMembers.LastPasswordChangedDate = DateTime.MinValue;
                Int64 MemberId = objMembers.MemberId;
                objMembers.objMembershipOrder.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                
                objMembers.objMembershipOrder.TransactionId = objMembers.TransactionId;
                objMembers.objMembershipOrder.BankName = objMembers.BankName;
                objMembers.objMembershipOrder.ChequeNo = objMembers.ChequeNo;
                objMembers.objMembershipOrder.ChequeDate = objMembers.ChequeDate;
                objMembers.objMembershipOrder.PaymentStatusId = objMembers.PaymentStatusId;
                objMembers.objMembershipOrder.PaymentMethodId = objMembers.PaymentMethodId;
                objMembers.objMembershipOrder.PaymentBy = objMembers.PaymentBy;
                objMembers.objMembershipOrder.AdminComment = objMembers.AdminComment;
                objMembers.objMembershipOrder.UserComment = objMembers.UserComment;
                
                Int64 _status = _Members.InsertMembers(objMembers, ref MemberId, ref imageurl);
                if(_status==1)
                {
                    if (imageurl != "" && imageurl != "NA")
                    {
                        image.Resize(94, 93, true, false);
                        image.Crop(1, 1, 1, 1);
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\Members\\" + imageurl);
                    }
                    if (lstChildrenInfo != null && lstChildrenInfo.Count() != 0)
                        {
                            foreach (Entities.ChildrenInfo objChildrenInfo in lstChildrenInfo)
                            {
                                objChildrenInfo.MemberId = objChildrenInfo.MemberId;
                                if (objChildrenInfo != null && objChildrenInfo.FirstName != null)
                                {
                                    Int64 estatus = _Members.InsertChildrenInfo(objChildrenInfo);
                                    if (estatus == -1)
                                    {
                                        TempData["message"] = "<div class=\"error closable\">Failed inserting member details.</div>";
                                        return RedirectToAction("Index", "Members");
                                    }
                                }
                            }
                        }

                    Entities.Members objMemberdetails = new Entities.Members();
                    int status1 = 0;
                    Int64 result = 0;
                    int result1 = 0;
                    string Username = "";
                    objMemberdetails = _Members.GetMemberFullDetailsById(MemberId, ref result1);

                    int _status1 = 0; Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Thank you for Becoming a Member", 0, ref _status1);
                    if (objTemplates != null)
                    {
                        StringBuilder body = new StringBuilder();
                        body.Append(objTemplates.Description);
                        body.Replace("[usersiteurl]", ConfigurationManager.AppSettings["baseurl"].ToString());
                        body.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                        body.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                        body.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                        body.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                        body.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                        body.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objMemberdetails.UserName));
                        body.Replace("[MemberId]", objMemberdetails.SpouseCell);
                        body.Replace("[MEMBERID]", objMemberdetails.MemberId.ToString());
                        body.Replace("[FirstName]", objMemberdetails.FirstName);
                        body.Replace("[LastName]", objMemberdetails.LastName);
                        body.Replace("[IntrestedArea]", objMemberdetails.SpouseSkils);
                        body.Replace("[SpouseEmail]", objMemberdetails.SpouseEmail);
                        body.Replace("[Email]", objMemberdetails.Email);
                        body.Replace("[MobilePhone]", objMemberdetails.MobilePhone);
                        body.Replace("[MembershipType]", objMemberdetails.MembershipType);
                        body.Replace("[TransactionId]", objMemberdetails.objMembershipOrder.TransactionId);
                        body.Replace("[PaymentType]", objMemberdetails.objMembershipOrder.PaymentMethod);
                        body.Replace("[PaymentStatus]", objMemberdetails.objMembershipOrder.PaymentStatus);
                        body.Replace("[PaymentDate]", DateTime.UtcNow.ToString());
                        body.Replace("[ExpiryDate]", objMemberdetails.ExpiryDate.ToShortDateString());
                        BLL.Common.SendMailwithfrom(objMemberdetails.Email, ConfigurationManager.AppSettings["adminemailid"].ToString(), objTemplates.Subject, body.ToString());
                    }


                    int statusAdmin = 0;
                    Entities.MailTemplates objTemplatesAdmin = _MailTemplates.GetMailTemplateById("Member Registration for admin", 0, ref statusAdmin);
                    if (objTemplatesAdmin != null && objTemplatesAdmin.MailTemplateId != 0)
                    {
                        StringBuilder body1 = new StringBuilder();
                        body1.Append(objTemplates.Description);
                        body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["baseurl"].ToString());
                        body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                        body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                        body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                        body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                        body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                        body1.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objMemberdetails.UserName));
                        body1.Replace("[MemberId]", objMemberdetails.SpouseCell);
                        body1.Replace("[MEMBERID]", objMemberdetails.MemberId.ToString());
                        body1.Replace("[FirstName]", objMemberdetails.FirstName);
                        body1.Replace("[LastName]", objMemberdetails.LastName);
                        body1.Replace("[Email]", objMemberdetails.Email);
                        body1.Replace("[MobilePhone]", objMemberdetails.MobilePhone);
                        body1.Replace("[MemberSkils]", objMemberdetails.MemberSkils);
                        body1.Replace("[IntrestedArea]", objMemberdetails.SpouseSkils);
                        body1.Replace("[SpouseCell]", objMemberdetails.SpouseCell);
                        body1.Replace("[SpouseEmail]", objMemberdetails.SpouseEmail);
                        body1.Replace("[MembershipType]", objMemberdetails.MembershipType);
                        body1.Replace("[TransactionId]", objMemberdetails.objMembershipOrder.TransactionId);
                        body1.Replace("[PaymentType]", objMemberdetails.objMembershipOrder.PaymentMethod);
                        body1.Replace("[PaymentStatus]", objMemberdetails.objMembershipOrder.PaymentStatus);
                        body1.Replace("[PaymentDate]", DateTime.UtcNow.ToString());
                        body1.Replace("[ExpiryDate]", objMemberdetails.ExpiryDate.ToShortDateString());

                        BLL.Common.SendMailwithfrom(ConfigurationManager.AppSettings["adminemailid"].ToString(), ConfigurationManager.AppSettings["adminemailid"].ToString(), "Registered Member Details - WATS", body1.ToString());
                    }

                    TempData["message"] = "<div class=\"success closable\">New Member Added Successfully.</div>";
                        return RedirectToAction("Index", "Members");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed Transaction.</div>";
                    return RedirectToAction("AddMember", "Members");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddMember", "Members");
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateMember(Entities.Members objMembers, List<Entities.ChildrenInfo> lstChildrenInfo)
        {
            try
            {
                objMembers.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _Members.UpdateMembers(objMembers);
                if (_status!=-1)
                {
                    if (lstChildrenInfo != null)
                    {
                        foreach (Entities.ChildrenInfo objChildrenInfo in lstChildrenInfo)
                        {
                            objChildrenInfo.MemberId = objMembers.MemberId;
                            if (objChildrenInfo != null && objChildrenInfo.FirstName != null)
                            {
                                Int64 estatus = _Members.InsertChildrenInfo(objChildrenInfo);
                                if (estatus == -1)
                                {
                                    TempData["message"] = "<div class=\"error closable\">Failed inserting member details.</div>";
                                    return RedirectToAction("EditMember", "Members", new { MemberId = objMembers.MemberId });
                                }
                            }
                        }
                    }
                        TempData["message"] = "<div class=\"success closable\">Updated member details successfully.</div>";
                        return RedirectToAction("EditMember", "Members", new { MemberId = objMembers.MemberId });
                      
                }
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">New Member Added Successfully</div>";
                    return RedirectToAction("EditMember", "Members", new { MemberId = objMembers.MemberId });
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated Member Details Successfully</div>";
                    return RedirectToAction("EditMember", "Members", new { MemberId = objMembers.MemberId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed Transaction.</div>";
                    return RedirectToAction("EditMember", "Members", new { MemberId = objMembers.MemberId });
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditMember", "Members", new { MemberId = objMembers.MemberId });
            }

        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditMember(Int64 MemberId = 0)
        {
            try
            {
                int qstatus = 0;
                objMembers = _Members.AddMembershipRequirement(ref qstatus);

                if (qstatus == 1)
                {
                    ViewBag.objMembers = objMembers;
                    ViewBag.status = qstatus;
                }
                int _qstatus = 0;
                Entities.Members _objMembers = _Members.GetMemberFullDetailsById(MemberId, ref _qstatus);

                if (_qstatus == 1 && qstatus == 1)
                {
                    ViewBag.objMemberDetails = _objMembers;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Members");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Members");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewMember(Int64 MemberId = 0)
        {
            try
            {
                int _qstatus = 0;
                Entities.Members _objMembers = _Members.GetMemberFullDetailsById(MemberId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objMemberDetails = _objMembers;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Members");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Members");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteMember(Int64 MemberId)
        {
            string str = "";
            try
            {
                Int64 _status = _Members.DeleteMembers(MemberId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted member successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed deleting member</div>";
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
      
        public ActionResult DeleteChildInfo(Int64 ChildInfoId,Int64 MemberId=0)
        {
            try
            {
                Int64 _status = _Members.DeleteChildInfo(ChildInfoId);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Deleted child info successfully</div>";
                    return RedirectToAction("EditMember", "Members", new { MemberId = MemberId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("EditMember", "Members", new { MemberId = MemberId });
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditMember", "Members", new { MemberId = MemberId });
            }
        }

        [HttpPost]
        public JsonResult MembersDeleteAll(string MemberId)
        {
            string str = "";
            try
            {
                Int64 _status = _Members.DeleteAllMembers(MemberId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted Selected Members successfully.</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error-alert closable\">Failed deleting members.</div>";
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
        public JsonResult MemberStatus(Int64 MemberId)
        {
            string str = "";
            try
            {
                Int64 _status = _Members.UpdateMemberStatus(MemberId);
                int status = 0;
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Updated member status successfully</div>";
                    Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Member", 0, ref status);
                    if (objTemplates != null)
                    {
                        Entities.Members objMember = _Members.GetMemberFullDetailsById(MemberId, ref status);
                        
                            if (objMember.IsApproved == true)
                            {
                                StringBuilder body = new StringBuilder();
                                body.Append(objTemplates.Description);
                                body.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                                body.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                                body.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                                body.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                                body.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                                body.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                                body.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objMember.UserName + " " + objMember.FirstName));
                                body.Replace("[MTYPE]", objMember.MembershipType.ToString());
                                body.Replace("[MEMBERID]", objMember.SpouseCell);
                                body.Replace("[Email]", objMember.Email);
                                BLL.Common.SendMail(objMember.Email, objTemplates.Subject, body.ToString());
                            }                        
                    }
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed updating member status</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch 
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
                return Json(new { ok = true, data = str });
            }
        }

        [HttpPost]
        public JsonResult CheckProfileEmailAvailability(Int64 MemberId, string Email)
        {
            int status = 0;
            try
            {
                 objMembers = _Members.GetMemberFullDetailsByEmail(Email, ref status);
                 bool data = (objMembers.MemberId == MemberId || objMembers.MemberId == 0 ? true : false);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch 
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed transaction.</div>"});
            }
        }

        [HttpPost]
        public JsonResult CheckEmailAvailability(string Email)
        {
            int status = 0;
            try
            {
                objMembers = _Members.GetMemberFullDetailsByEmail(Email, ref status);
                bool data = (objMembers != null && objMembers.MemberId != 0 ? false : true);

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
                objMembers = _Members.GetMemberFullDetailsByUserName(UserName, ref status);
                bool data = (objMembers != null && objMembers.MemberId != 0 ? false : true);

                return Json(new { ok = true, data = data, message = "" });
            }
            catch
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed transaction.</div>"});
            }
        }

        #endregion       

        public void MembersExporttoExcel(string Search = "", Int64 MembershipTypeId = 0, Int64 PaymentStatusId = 0, string StartDate = "", string EndDate = "", string ExpiryDate = "", string SortColumn = "InsertedTime", string SortOrder = "DESC")
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            try
            {
                DataTable dtUni = _DMembers.ExportMembersList(Search, MembershipTypeId, PaymentStatusId, StartDate, EndDate, ExpiryDate, Sort);
                //MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                //var filename = "CSV-Members-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".csv";
                //var contenttype = "text/csv";
                //Response.Clear();
                //Response.ContentType = contenttype;
                //Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                //Response.BinaryWrite(stream.ToArray());
                //Response.End();
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "Member-Registration-Export");

                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Member-Registration-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }

                StringBuilder body = new StringBuilder();
                body.Append("<p>Dear Admin, <br /><br />" + Session["userrole"] + " has downloaded Members report on <br />" + DateTime.UtcNow);                
                body.Append("Thank You,<br />Admin</p>");
                BLL.Common.SendMail("board@watsweb.org", "Password Details From Admin Team", body.ToString());
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }
    }
}
