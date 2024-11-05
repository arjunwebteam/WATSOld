using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Events,")]
    [WATS.Models.SessionClass.SessionExpireFilter]
    public class EventsController : Controller
    {
        WATS.BLL.Events _Events = new WATS.BLL.Events();
        WATS.BLL.EventCategories _EventCategories = new WATS.BLL.EventCategories();
        BLL.RegisterFields _registerfields = new BLL.RegisterFields();
        BLL.RegistrationCategories _RegistrationCategories = new BLL.RegistrationCategories();

        #region Events

        public ActionResult Index(string EventType = "")
        {               
            ViewBag.EventType = EventType;
            return View();
        }

        [HttpGet]
        public ActionResult EventsList(Int64 EventStatusId = 0, string EventType = "upcoming", string StartDate = "", string EndDate = "", string search = "", string SortColumn = "StartDate", string SortOrder = "DESC", int PageNo = 1, int PageItems = 10)
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            List<Entities.Events> lstEventslist = new List<Entities.Events>();
            int Total = 0;
            try
            {
                lstEventslist = _Events.GetEventsListByVariable(EventStatusId, EventType, StartDate, EndDate, HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
                
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
            ViewBag.total = Total;
            ViewBag.items = PageItems;
            ViewBag.pageno = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder;
            ViewBag.Eventslist = lstEventslist;
            return View();
        }

        public ActionResult AddEvent()
        {           
            List<Entities.EventCategories> lstEventCategories = new List<Entities.EventCategories>();

            int Total = 0;
            int _qstatus = 0;
            try
            {
                lstEventCategories = _EventCategories.GetEventCategoriesList(ref Total);
                ViewBag.lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);
            }
            catch
            {
                Total = -1;
            }
            ViewBag.lstEventCategories = lstEventCategories;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddEvent(Entities.Events objEvents, List<Entities.EventRegistrationTypes> lstEventRegistrationTypes, List<Entities.RegistrationCategories> lstRegistrationCategories)
        {
            try
            {
               
                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                objEvents.UpdatedBy = this.User.Identity.Name;

                if (lstEventRegistrationTypes != null && lstEventRegistrationTypes.Count != 0)
                {
                    objEvents.XMLRegistrationsTypes = BLL.Common.CreateXMLForObject(lstEventRegistrationTypes);
                }
                if (lstRegistrationCategories != null && lstRegistrationCategories.Count != 0)
                {
                    objEvents.XMLRegistrations = BLL.Common.CreateXMLForObject(lstRegistrationCategories);
                }

                Int64 _status = _Events.InsertEvent(objEvents, ref imageurl);
                switch (_status)
                {
                    case 1:
                        if (image != null)
                        {
                            image.Save(ConfigurationManager.AppSettings["adminuploadPath"] + "\\events\\banners\\" + imageurl);
                            //image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\events\\banners\\" + imageurl);
                            var image_th = image;
                            image_th.Resize(150, 150);
                            image.Crop(1, 1, 1, 1);
                            image_th.Save(ConfigurationManager.AppSettings["adminuploadPath"] + "\\events\\banners\\thumb\\" + imageurl);
                        }
                        TempData["message"] = "<div class=\"success closable\">Inserted event details successfully.</div>";
                        return RedirectToAction("Index", "Events");
                    case 2:
                        if (image != null)
                        {
                            image.Save(ConfigurationManager.AppSettings["adminuploadPath"] + "\\events\\banners\\" + imageurl);
                            var image_th = image;
                            image_th.Resize(150, 150);
                            image.Crop(1, 1, 1, 1);
                            image_th.Save(ConfigurationManager.AppSettings["adminuploadPath"] + "\\events\\banners\\thumb\\" + imageurl);
                        }
                        TempData["message"] = "<div class=\"success closable\">Updated event details successfully.</div>";
                        return RedirectToAction("EditEvent", "Events", new { EventId = objEvents.EventId });
                    case -1:
                        if (image != null)
                        {
                            System.IO.File.Delete(ConfigurationManager.AppSettings["adminuploadPath"] + "\\events\\banners\\" + imageurl);
                            System.IO.File.Delete(ConfigurationManager.AppSettings["adminuploadPath"] + "\\events\\banners\\thumb\\" + imageurl);
                        }
                        TempData["message"] = "<div class=\"error closable\">Failed updating event details.</div>";
                        return RedirectToAction("Index", "Events");
                    default:
                        TempData["message"] = "<div class=\"error closable\">Failed updating event details.</div>";
                        return RedirectToAction("Index", "Events");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Events");
            }
        }

        [HttpPost]
        public JsonResult EventDelete(Int64 EventId, string ImageFileName)
        {
            string str = "";
            bool _bool = true;
            try
            {
                Int64 _status = _Events.DeleteEventById(EventId);
                switch (_status)
                {
                    case 1:
                        if (System.IO.File.Exists(ConfigurationManager.AppSettings["uploadPath"] + @"\events\banners\" + ImageFileName))
                        {
                            System.IO.File.Delete(ConfigurationManager.AppSettings["uploadPath"] + @"\events\banners\" + ImageFileName);
                            System.IO.File.Delete(ConfigurationManager.AppSettings["uploadPath"] + @"\events\banners\thumb\" + ImageFileName);
                        }
                        str = "<div class=\"success closable\">Successfully deleted event record.</div>";
                        _bool = true;
                        break;
                    case -1:
                        str = "<div class=\"error closable\">Failed deleting event record</div>";
                        _bool = false;
                        break;
                    default:
                        str = "<div class=\"error closable\">Failed deleting event record</div>";
                        _bool = false;
                        break;
                }
            }
            catch 
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
                _bool = false;
            }
            return Json(new { ok = _bool, data = str });
        }

        public ActionResult EditEvent(Int64 EventId = 0,string  EventName="")
        {
           
            if (EventId == 0)
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Events");
            }

            int status = 0;
            int Total = 0;
            int _qstatus = 0;
            List<Entities.EventCategories> lstEventCategories = new List<Entities.EventCategories>();
            Entities.Events objEvent = new Entities.Events();
            List<Entities.EventRegistrationTypes> lstEventRegistrationTypes = new List<Entities.EventRegistrationTypes>();

            List<Entities.RegistrationCategories> lstEventRegistrationCategories = new List<Entities.RegistrationCategories>(); 
            ViewBag.lstRegistrationCategories = _RegistrationCategories.GetRegistrationCategoriesList(ref _qstatus);

            try
            {
                lstEventCategories = _EventCategories.GetEventCategoriesList(ref Total);
                //objEvent = _Events.AdminGetEventById(EventId, EventName, ref lstEventRegistrationTypes,  ref status);
                objEvent = _Events.FEGetEventById(EventId, EventName, ref lstEventRegistrationTypes, ref lstEventRegistrationCategories, ref status);
                if (objEvent == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "Events");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Events");
            }

            ViewBag.objEvent = objEvent;

            ViewBag.lstEventCategories = lstEventCategories;
            ViewBag.lstEventRegistrationTypes = lstEventRegistrationTypes;
            ViewBag.lstEventRegistrationCategories = lstEventRegistrationCategories;
            ViewBag.status = (Total != -1 || status != -1 ? 1 : -1);

            return View();
        }

        public ActionResult ViewEvent(Int64 EventId = 0, string EventName="")
        {
           
            if (EventId == 0)
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Events");
            }

            int status = 0;
            Entities.Events objEvent = new Entities.Events();

            try
            {
                objEvent = _Events.GetEventById(EventId,EventName, ref status);
                if (objEvent == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "Events");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Events");
            }

            ViewBag.objEvent = objEvent;
            ViewBag.status = status;

            return View();
        }

        [HttpPost]
        public JsonResult EventStatus(Int64 EventId)
        {
            string str = "";
            try
            {
                Int64 _status = _Events.UpdateEventStatus(EventId);
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
                return Json(new { ok = true, data = str });
            }
        }

        #endregion

        #region Event Registration Form

        public ActionResult EventRegistrationForm(Int64 EventId = 0, string EventName = "")
        {
            if (EventId == 0)
            {
                TempData["message"] = "<div class=\"error-alert\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Events");
            }
            ViewBag.EventId = EventId;
            ViewBag.EventName = EventName;
            return View();
        }

        public ActionResult RegistrationOptions(Int64 EventId = 0, string EventName = "")
        {
            int status = 0;
            List<Entities.RegisterFields> lstRegisterField = new List<Entities.RegisterFields>();

            try
            {
               lstRegisterField = _registerfields.GetRegisterFieldsList(EventId, ref status);
            }
            catch
            {
                status = -1;
            }

            ViewBag.lstRegisterField = lstRegisterField;
            ViewBag.status = status;
            ViewBag.EventName = EventName;

            return View();
        }

        public ActionResult AddRegisterOption(Int64 EventId = 0, string EventName = "")
        {
            ViewBag.EventId = EventId;
            ViewBag.EventName = EventName;
            return View();
        }

        public ActionResult EditRegisterOption(Int64 EventId = 0, Int64 RegisterFieldId = 0, string EventName = "")
        {
            int status = 0;
            Entities.RegisterFields objRegisterFields = new Entities.RegisterFields();

            try
            {
               objRegisterFields = _registerfields.GetRegisterFieldsById(RegisterFieldId, ref status);
            }
            catch
            {
                status = -1;
            }

            ViewBag.objRegisterFields = objRegisterFields;

            ViewBag.EventId = EventId;
            ViewBag.EventName = EventName;
            ViewBag.status = status;
            return View();
        }

        public ActionResult ViewRegisterOption(Int64 RegisterFieldId = 0, string EventName = "")
        {
            int status = 0;
            Entities.RegisterFields objRegisterFields = new Entities.RegisterFields();

            try
            {
                objRegisterFields = _registerfields.GetRegisterFieldsById(RegisterFieldId, ref status);
            }
            catch
            {
                status = -1;
            }

            ViewBag.objRegisterFields = objRegisterFields;
            ViewBag.status = status;
            ViewBag.EventName = EventName;
            return View();
        }

        [HttpPost]
        public ActionResult AddRegisterOption(Entities.RegisterFields objRegisterFields, List<Entities.RegisterOptions> lstRegisterOptions)
        {
            try
            {
                if (lstRegisterOptions != null && lstRegisterOptions.Count > 0 && (objRegisterFields.QuestionType == "checkbox" || objRegisterFields.QuestionType == "radio" || objRegisterFields.QuestionType == "dropdown"))
                {
                    List<string> options = new List<string>();
                    foreach (var item in lstRegisterOptions)
                    {
                        options.Add(item.QOption);
                    }
                    objRegisterFields.Options = string.Join(",", new List<string>(options).ToArray());
                }
                objRegisterFields.UpdatedBy = "admin";
                Int64 status = _registerfields.InsertRegisterFields(objRegisterFields);
                switch (status)
                {
                    case 1:
                        TempData["message"] = "<div class=\"success closable\">Inserted registration fields details successfully.</div>";
                        return RedirectToAction("EventRegistrationForm", "Events", new { EventId = objRegisterFields.EventId,EventName = objRegisterFields.EventName });
                    case 2:
                        TempData["message"] = "<div class=\"success closable\">Updated registration fields successfully.</div>";
                        return RedirectToAction("EventRegistrationForm", "Events", new { EventId = objRegisterFields.EventId, EventName = objRegisterFields.EventName });
                    case -1:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed updating registration fields.</div>";
                        return RedirectToAction("EventRegistrationForm", "Events", new { EventId = objRegisterFields.EventId, EventName = objRegisterFields.EventName });
                    default:
                        TempData["message"] = "<div class=\"error-alert closable\">Failed updating registration fields.</div>";
                        return RedirectToAction("EventRegistrationForm", "Events", new { EventId = objRegisterFields.EventId, EventName = objRegisterFields.EventName });
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error-alert closable\">Failed updating registration fields.</div>";
                return RedirectToAction("EventRegistrationForm", "Events", new { EventId = objRegisterFields.EventId, EventName = objRegisterFields.EventName });
            }
        }

        [HttpPost]
        public JsonResult DeleteRegisterOption(Int64 RegisterFieldId)
        {
            string str = "";
            bool _bool = true;
            try
            {
                Int64 _status = _registerfields.DeleteRegisterFields(RegisterFieldId);
                switch (_status)
                {
                    case 1:
                        str = "<div class=\"success closable\">Successfully deleted registration details record.</div>";
                        _bool = true;
                        break;
                    case -1:
                        str = "<div class=\"error-alert closable\">Failed deleting registration details record</div>";
                        _bool = false;
                        break;
                    default:
                        str = "<div class=\"error-alert closable\">Failed deleting registration details record</div>";
                        _bool = false;
                        break;
                }
            }
            catch
            {
                str = "<div class=\"error-alert closable\">Failed deleting registration details record.</div>";
                _bool = false;
            }
            return Json(new { ok = _bool, data = str });
        }

        [HttpPost]
        public JsonResult DeleteOption(Int64 RegisterOptionId)
        {
            string str = "";
            bool _bool = true;
            try
            {
                Int64 _status = _registerfields.DeleteRegisterOption(RegisterOptionId);
                switch (_status)
                {
                    case 1:
                        str = "<div class=\"success closable\">Successfully deleted option record.</div>";
                        _bool = true;
                        break;
                    case -1:
                        str = "<div class=\"error-alert closable\">Failed deleting option record</div>";
                        _bool = false;
                        break;
                    default:
                        str = "<div class=\"error-alert closable\">Failed deleting option record</div>";
                        _bool = false;
                        break;
                }
            }
            catch
            {
                str = "<div class=\"error-alert closable\">Failed deleting registration details record.</div>";
                _bool = false;
            }
            return Json(new { ok = _bool, data = str });
        }

        #endregion

        #region Event Controls

        public ActionResult EventMenu(Int64 EventId = 0, string EventName = "", string tab = "")
        {
            ViewBag.EventId = EventId;
            ViewBag.EventName = EventName;
            ViewBag.tab = tab;

            return View();
        }

        #endregion

        #region EventRegistrationTypes


        public ActionResult AddEventRegistrationTypes(Entities.EventRegistrationTypes objRegistrationTypes)
        {
            string str = "";
            bool _bool = true;

            Entities.EventRegistrationTypes objEventRegistrationTypes = new Entities.EventRegistrationTypes();
            try
            {
                objRegistrationTypes.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _Events.InsertRegistrationTypes(objRegistrationTypes);

                switch (_status)
                {
                    case 1:
                        str = "<div class=\"success closable\"> Inserted Registration Type details successfully.</div>";
                        _bool = true;
                        break;
                    case 2:
                        str = "<div class=\"success closable\"> Updated Registration Type details successfully.</div>";
                        _bool = true;
                        break;
                    case -1:
                        str = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        _bool = false;
                        break;
                    default:
                        str = "<div class=\"error-alert closable\">Failed processing your request.</div>";
                        _bool = false;
                        break;
                }
            }
            catch
            {
                str = "<div class=\"error closable\">Failed transaction.</div>";
                _bool = false;
            }

            return Json(new { ok = _bool, data = str });
        }


        [Models.SessionClass.SessionExpireFilter]
        public ActionResult EventRegistrationTypesList(Int64 EventId = 0)
        {

            int Total = 0;
            List<Entities.EventRegistrationTypes> lstEventRegistrationTypes = new List<Entities.EventRegistrationTypes>();

            try
            {
                lstEventRegistrationTypes = _Events.GetEventRegistrationTypesList(EventId, ref Total);

            }
            catch
            {
                Total = -1;
            }

            ViewBag.lstEventRegistrationTypes = lstEventRegistrationTypes;
            return View();
        }


        [Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteRegistrationType(Int64 EventRegistrationTypeId)
        {
            string str = "";
            try
            {

                Int64 _status = _Events.DeleteEventRegistrationTypes(EventRegistrationTypeId);
                if (_status == 1)
                {
                    str = "<div class=\"alert alert-success alert-dismissable\">Record Deleted successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"alert alert-danger alert-dismissable\">Failed deleting</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch
            {
                str = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                return Json(new { ok = false, data = str });
            }
        }

        [HttpPost]
        [Models.SessionClass.SessionExpireFilter]
        public JsonResult EventRegistrationTypesStatus(Int64 EventRegistrationTypeId)
        {
            string str = "";
            try
            {
                Int64 _status = _Events.UpdateEventRegistrationTypesStatus(EventRegistrationTypeId);
                if (_status == 1)
                {
                    str = "<div class=\"alert alert-success alert-dismissable\">Updated Status Successfully</div>";
                    return Json(new { ok = true, data = str });
                }
                else
                {
                    str = "<div class=\"alert alert-danger alert-dismissable\">Failed updating status</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch
            {
                str = "<div class=\"alert alert-danger alert-dismissable\">Failed transaction.</div>";
                return Json(new { ok = false, data = str });
            }
        }

        public JsonResult UpdateEventRegistrationTypesDisplayOrder(int OrderNo, Int64 EventRegistrationTypeId)
        {
            Int64 _status = 0;
            string str = "";
            _status = _Events.UpdateEventRegistrationTypesDisplayOrder(OrderNo, EventRegistrationTypeId);
            if (_status == 1)
            {
                str = "<div class=\"alert alert-success alert-dismissable\">Update Order Successfully</div>";
                return Json(new { ok = true, data = str });
            }
            else
            {
                str = "<div class=\"alert alert-danger alert-dismissable\">Failed Transaction</div>";
                return Json(new { ok = false, data = str });
            }

        }

        public JsonResult GetEventssByCategory(Int64 RegistrationCategoryId = 0)
        {
            try
            {
                List<Entities.Events> lstEvents = new List<Entities.Events>();

                int status = 0;
                lstEvents = _Events.GetEventsByCategory(RegistrationCategoryId, ref status);
                return Json(new { ok = true, data = lstEvents, message = "" });
            }
            catch
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed Transaction</div>" });
            }
        }
        #endregion

    }
}
