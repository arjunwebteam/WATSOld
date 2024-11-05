using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
     [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Events,")]
    public class EventRegistrationsController : Controller
    {
        BLL.Events _Events = new BLL.Events();
        DAL.Events _DEvents = new DAL.Events();
        BLL.MailTemplates _MailTemplates = new BLL.MailTemplates();
        List<Entities.EventUserInfo> lstEventUserInfo = new List<Entities.EventUserInfo>();
        Entities.EventUserInfo objEventUserInfo = new Entities.EventUserInfo();
        BLL.Members _Members = new BLL.Members();
        Entities.Members objMembers = new Entities.Members();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index(Int64 EventId = 0 , string EventName="")
        {
           
            ViewBag.EventId = EventId;
            ViewBag.EventName = EventName;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EventUsersList(Int64 EventId=0, string Type = "", string Search = "", string SortColumn = "InsertedTime", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            try
            {
                lstEventUserInfo = _Events.GetEventUserInfoListByVariable(EventId, Type, Search, Sort, PageNo, Items, ref Total);
               
            }
            catch 
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstEventUserInfo = lstEventUserInfo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditEventUser(Int64 EventUserInfoId = 0)
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
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "EventRegistrations");
                }

                int _qstatus = 0;
                List<Entities.EventRegistrationCounts> lstEventRegCounts = new List<Entities.EventRegistrationCounts>();
                List<Entities.EventsTickets> lstEventsTickets = new List<Entities.EventsTickets>();
                Entities.Events objEvents = new Entities.Events();

                objEventUserInfo = _Events.GetEventUserInfoFullDetailsById(EventUserInfoId, 0, ref objEvents, ref lstEventRegCounts, ref lstEventsTickets, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objEventUserInfo = objEventUserInfo;
                    ViewBag.lstEventRegCounts = lstEventRegCounts;
                    ViewBag.lstEventsTickets = lstEventsTickets;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "EventRegistrations");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "EventRegistrations");
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateEventUser(Entities.EventUserInfo objEventUserInfo)
        {
            try
            {
               
                objEventUserInfo.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objEventUserInfo.InsertedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _Events.UpdateEventUserInfo(objEventUserInfo);
                if (_status != -1)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated user details successfully.</div>";
                    return RedirectToAction("EditEventUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
                }
                else {
                    TempData["message"] = "<div class=\"error closable\">Failed Transaction.</div>";
                    return RedirectToAction("EditEventUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditEventUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
            }

        }
        

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewEventUser(Int64 EventUserInfoId = 0)
        {
            try
            {
               
                int _qstatus = 0;
                List<Entities.EventRegistrationCounts> lstEventRegCounts = new List<Entities.EventRegistrationCounts>();
                List<Entities.EventsTickets> lstEventsTickets = new List<Entities.EventsTickets>();
                Entities.Events objEvents = new Entities.Events();

                objEventUserInfo = _Events.GetEventUserInfoFullDetailsById(EventUserInfoId, 0, ref objEvents, ref lstEventRegCounts, ref lstEventsTickets, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objEventUserInfo = objEventUserInfo;
                    ViewBag.lstEventRegCounts = lstEventRegCounts;
                    ViewBag.lstEventsTickets = lstEventsTickets;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "EventRegistrations");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "EventRegistrations");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteEventUser(Int64 EventUserInfoId)
        {
            string str = "";
            try
            {
               
                Int64 _status = _Events.DeleteEventUserInfoById(EventUserInfoId);
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Deleted user successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"error closable\">Failed deleting user</div>";
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
        public JsonResult EventUserInfoStatus(Int64 EventUserInfoId)
        {
            string str = "";
            try
            {
                Int64 _status = _Events.UpdateEventUserInfoStatus(EventUserInfoId);
                int status = 0;
                if (_status == 1)
                {
                    str = "<div class=\"success closable\">Updated user status successfully</div>";
                    Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Event Registration", 0, ref status);
                    if (objTemplates != null)
                    {
                        Entities.EventUserInfo objEventUserInfo = _Events.GetEventUserInfoById(EventUserInfoId,ref status);
                        StringBuilder body = new StringBuilder();
                        if (objEventUserInfo.IsApproved == true)
                        {
                            body.Append(objTemplates.Description);
                            body.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                            body.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                            body.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                            body.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                            body.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                            body.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                            body.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.FirstName + "" + objEventUserInfo.LastName));
                            body.Replace("[EVENTNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.EventName));
                            BLL.Common.SendMail(objEventUserInfo.Email, objTemplates.Subject, body.ToString());
                        }
                    }
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

        #region export to excel

        public void EventuserExporttoExcel(Int64 EventId = 0, string Type = "", string Search = "", string SortColumn = "InsertedTime", string SortOrder = "DESC")
        {
            try
            {
                //if(Type == "")
                //{
                //    Type = "Normal Events";
                //}
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DEvents.ExportToEventUserInfoList(EventId, Type, Search, Sort);
                MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                var filename = "CSV-EventUsers-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".csv";
                var contenttype = "text/csv";
                Response.Clear();
                Response.ContentType = contenttype;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }

        #endregion

        #region CulturalRegistrations

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Registrations(Int64 EventId = 0, string EventName = "")
        {
            int status = 0;
            List<Entities.Events> lstEvents = new List<Entities.Events>();
            try
            {
                lstEvents = _Events.GetAllEventsList(ref status);
            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.lstEvents = lstEvents;
            ViewBag.EventId = EventId;
            ViewBag.EventName = EventName;
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult RegistrationsEventUsersList(Int64 EventId = 0, string EventCategory = "", string Search = "", string SortColumn = "InsertedTime", string SortOrder = "DESC", int PageNo = 1, int Items = 20)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            try
            {
                lstEventUserInfo = _Events.RegistrationEventUserInfoGetListByVariable(EventId, EventCategory, Search, Sort, PageNo, Items, ref Total);

            }
            catch
            {
                ViewBag.message = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.pageno = PageNo;
            ViewBag.items = Items;
            ViewBag.lstEventUserInfo = lstEventUserInfo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            return View();
        }


        public void RegEventuserExporttoExcel(Int64 EventId = 0, string EventCategory = "", string Search = "", string SortColumn = "InsertedTime", string SortOrder = "DESC")
        {
            try
            {
                //if(Type == "")
                //{
                //    Type = "Normal Events";
                //}
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DEvents.RegisterExporttoEventUserInfo(EventId, EventCategory, Search, Sort);
                MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                var filename = "CSV-Eventculrural-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".csv";
                var contenttype = "text/csv";
                Response.Clear();
                Response.ContentType = contenttype;
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }

        #endregion
    }
}
