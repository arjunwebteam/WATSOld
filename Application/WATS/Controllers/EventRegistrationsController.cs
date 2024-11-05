using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using ClosedXML.Excel;
using QRCoder;


namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Events,WebMaster,Treasurer,Cultural")]
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
            int status = 0;
            int Batch1 = 0;
            int Batch2 = 0;
            int Batch3 = 0;
            int Batch4 = 0;
            int Batch5 = 0;
            int Others = 0;
            List<Entities.EventRegistrationCounts> lstRegistrationCount = new List<Entities.EventRegistrationCounts>();
            try
            {
                lstRegistrationCount = _Events.EventTicketsCount(EventId, ref status, ref Batch1, ref Batch2, ref Batch3, ref Batch4, ref Batch5, ref Others);
            }
            catch(Exception ex)
            {
                ViewBag.message = "<div class=\"error closable\">" + ex.Message + "</div>";
            }
           
            ViewBag.EventId = EventId;
            ViewBag.EventName = EventName;
            ViewBag.lstRegistrationCount = lstRegistrationCount;
            ViewBag.Batch1 = Batch1;
            ViewBag.Batch2 = Batch2;
            ViewBag.Batch3 = Batch3;
            ViewBag.Batch4 = Batch4;
            ViewBag.Batch5 = Batch5;
            ViewBag.Others = Others;
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

                objEventUserInfo = _Events.FEGetEventUserInfoFullDetailsById(EventUserInfoId, 0, ref objEvents, ref lstEventRegCounts, ref lstEventsTickets, ref _qstatus);

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
        public ActionResult UpdateEventUser(Entities.EventUserInfo objEventUserInfo, List<Entities.EventParticipants> lstParticipantsInfo)
        {
            try
            {
               
                objEventUserInfo.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objEventUserInfo.InsertedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _Events.UpdateEventUserInfo(objEventUserInfo);

                if (_status != -1)
                {
                    foreach (Entities.EventParticipants objChildrenInfo in lstParticipantsInfo)
                    {
                        objChildrenInfo.EventUserInfoId = objEventUserInfo.EventUserInfoId;
                        if (objChildrenInfo != null && objChildrenInfo.FirstName != null)
                        {
                            objChildrenInfo.IsApproved = false;
                            objChildrenInfo.UpdatedBy = objChildrenInfo.FirstName;
                            Int64 estatus = _Events.InsertEventParticipant(objChildrenInfo);
                            if (estatus == -1)
                            {
                                TempData["message"] = "<div class=\"error closable\">Failed inserting member details.</div>";
                                return RedirectToAction("EditEventUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
                            }
                        }
                    }
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

                objEventUserInfo = _Events.FEGetEventUserInfoFullDetailsById(EventUserInfoId, 0, ref objEvents, ref lstEventRegCounts, ref lstEventsTickets, ref _qstatus);

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
        public JsonResult EventUserInfoStatus(Int64 EventUserInfoId, string type = "")
        {
            
            string str = "";
            string QrUri = "";
            try
            {
                Int64 _status = _Events.UpdateEventUserInfoStatus(EventUserInfoId);
                
                int status = 0;
                if (_status == 1)
                {
                    string RefCode = "WATS" + EventUserInfoId;
                    Entities.EventComments objcomments = new Entities.EventComments();


                    objcomments.EmployeeRefUrl = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "qrcode-preview.html?id=" + EventUserInfoId;
                    
                    string WebUri = objcomments.EmployeeRefUrl;

                    string UriPayload = WebUri.ToString();

                    QRCodeGenerator QrGenerator = new QRCodeGenerator();
                    QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(UriPayload, QRCodeGenerator.ECCLevel.Q);

                    //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    //imgBarCode.Height = 150;
                    //imgBarCode.Width = 150;




                    //QRCode QrCode = new QRCode(QrCodeInfo);
                    //Bitmap QrBitmap = QrCode.GetGraphic(60);
                    //byte[] BitmapArray = QrBitmap.BitmapToByteArray();
                    //QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
                    //ViewBag.QrCodeUri = QrUri;

                    #region QRCode Generation Code
                   

                    string pdffilepath = "";

                    #region Barcode

                    //GenerateBacode(item.Field1);

                    #endregion

                    #region Ticket Image Generation
                    System.Drawing.Image orgImg;


                    //Load the Image to be written on.
                    Bitmap bitMapImage = new System.Drawing.Bitmap(Server.MapPath("~/Content/QRCodeGeneration/Qrcodesample.png"));
                    Graphics graphicImage = Graphics.FromImage(bitMapImage);


                    //Smooth graphics is nice.
                    graphicImage.SmoothingMode = SmoothingMode.AntiAlias;
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    pdffilepath = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "qrcode-preview.html?id=" + EventUserInfoId; ;

                    string code = pdffilepath;


                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();


                    imgBarCode.Height = 140;
                    imgBarCode.Width = 140;

                    string strB = System.Configuration.ConfigurationManager.AppSettings["uploadPath"] + "\\TrainingQRCode\\QR-of-" + RefCode + ".jpg";

                    strB = strB.Replace("https://", "");
                    strB = strB.Replace("/", "");
                  

                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream msa = new MemoryStream())
                        {
                            bitMap.Save(msa, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = msa.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            bitMap.Save(strB);
                        }
                    }


                    //Clean house.
                    graphicImage.Dispose();
                    bitMapImage.Dispose();

                    #endregion

                    #endregion


                    str = "<div class=\"success closable\">Updated user status successfully</div>";
                    if (type == "Cultural")
                    {
                        Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Cultural Registration", 0, ref status);
                        if (objTemplates != null)
                        {
                            Entities.EventUserInfo objEventUserInfo = _Events.GetEventUserInfoById(EventUserInfoId, ref status);
                            StringBuilder body1 = new StringBuilder();
                            if (objEventUserInfo.IsApproved == true)
                            {
                                body1.Append(objTemplates.Description);
                                body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                                body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                                body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                                body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                                body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                                body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                                body1.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.FirstName + "" + objEventUserInfo.LastName));
                                body1.Replace("[EVENTNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.EventName));
                                string url = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "Content/TrainingQRCode/QR-of-" + RefCode + ".jpg";
                                var image = "<img width=\"113\" height=\"113\" src=\"" + url + "\" />";
                                body1.Replace("[QRCode]", image);
                                BLL.Common.SendMail(objEventUserInfo.Email, objTemplates.Subject, body1.ToString());
                            }
                        }
                    }
                    else if(type == "Event")
                    {
                        Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Event Registration", 0, ref status);
                        if (objTemplates != null)
                        {
                            Entities.EventUserInfo objEventUserInfo = _Events.GetEventUserInfoById(EventUserInfoId, ref status);
                            StringBuilder body1 = new StringBuilder();
                            if (objEventUserInfo.IsApproved == true)
                            {
                                body1.Append(objTemplates.Description);
                                body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                                body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                                body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                                body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                                body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                                body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                                body1.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.FirstName + "" + objEventUserInfo.LastName));
                                body1.Replace("[EVENTNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.EventName));
                                string url = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "Content/TrainingQRCode/QR-of-" + RefCode + ".jpg";
                                var image = "<img width=\"113\" height=\"113\" src=\"" + url + "\" />";
                                body1.Replace("[QRCode]", image);
                                BLL.Common.SendMail(objEventUserInfo.Email, objTemplates.Subject, body1.ToString());
                            }
                        }
                    }
                    return Json(new { ok = true, data = str });
                }
                else if(_status == 2)
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
            catch (Exception ex)
            {
                str = "<div class=\"error closable\">" + ex.Message + "</div>";
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

        public void TicketInfoExport(Int64 EventId = 0, string Type = "", string Search = "", string SortColumn = "InsertedTime", string SortOrder = "DESC")
        {
            try
            {
                //if(Type == "")
                //{
                //    Type = "Normal Events";
                //}
                string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
                DataTable dtUni = _DEvents.TicketInfoExport(EventId, Type, Search, Sort);
                MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                var filename = "CSV-Ticketsinfo-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".csv";
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
                
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dtUni, "Eventculrural-Export");
                    Response.Clear();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=Eventculrural-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".xlsx");
                    using (MemoryStream MyMemoryStream = new MemoryStream())
                    {
                        wb.SaveAs(MyMemoryStream);
                        MyMemoryStream.WriteTo(Response.OutputStream);
                        Response.Flush();
                        Response.End();
                    }
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }
        }

        [WATS.Models.SessionClass.SessionExpireFilter]

        public ActionResult DeleteParticipants(Int64 EventParticipantId, Int64 EventUserInfoId = 0)
        {
            try
            {
                Int64 _status = _Events.DeleteEventParticipantsById(EventParticipantId);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Deleted child info successfully</div>";
                    return RedirectToAction("EditEventUser", "EventRegistrations", new { EventUserInfoId = EventUserInfoId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("EditEventUser", "EventRegistrations", new { EventUserInfoId = EventUserInfoId });
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditEventUser", "EventRegistrations", new { EventUserInfoId = EventUserInfoId });
            }
        }

        public JsonResult CheckMemberIdAvailability(string SpouseCell, string LastName)
        {
            int status = 0;
            try
            {
                objMembers = _Members.GetMemberId(SpouseCell, LastName, ref status);
                bool data = (objMembers != null && objMembers.MemberId != 0 ? false : true);

                return Json(new { ok = true, data = data, message = "", type = objMembers.MembershipType });
            }
            catch
            {
                return Json(new { ok = false, message = "<div class=\"error closable\">Failed Transaction</div>" });
            }
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult ResendQRCode(Int64 EventUserInfoId, string type = "")
        {

            string str = "";
            string QrUri = "";
            int _status = 0;
            int status = 0;
            string RefCode = "WATS" + EventUserInfoId;
            try
            {
             
                if (EventUserInfoId != 0)
                {
                   
                    str = "<div class=\"success closable\">QR Code sent successfully to Registered Email-Id</div>";
                    if (type == "Cultural")
                    {
                        Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Cultural Registration", 0, ref status);
                        if (objTemplates != null)
                        {
                            Entities.CulturalUserInfo objEventUserInfo = _Events.CulturalUserInfoGetById(EventUserInfoId, ref _status);
                            StringBuilder body1 = new StringBuilder();
                            if (objEventUserInfo.IsApproved == true)
                            {
                                body1.Append(objTemplates.Description);
                                body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                                body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                                body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                                body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                                body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                                body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                                body1.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.FirstName + "" + objEventUserInfo.LastName));
                                body1.Replace("[EVENTNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.EventName));
                                string url = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "Content/TrainingQRCode/QR-of-" + RefCode + ".jpg";
                                var image = "<img width=\"113\" height=\"113\" src=\"" + url + "\" />";
                                body1.Replace("[QRCode]", image);
                                BLL.Common.SendMail(objEventUserInfo.Email, objTemplates.Subject, body1.ToString());
                            }
                        }
                    }
                    else if(type == "Event")
                    {
                        Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Event Registration", 0, ref status);

                        Entities.EventUserInfo objEventUserInfo = _Events.GetEventUserInfoById(EventUserInfoId, ref _status);

                        if (objTemplates != null)
                        {

                            StringBuilder body1 = new StringBuilder();
                            if (objEventUserInfo.IsApproved == true)
                            {
                                body1.Append(objTemplates.Description);
                                body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                                body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                                body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                                body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                                body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                                body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                                body1.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.FirstName + "" + objEventUserInfo.LastName));
                                body1.Replace("[EVENTNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.EventName));
                                string url = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "Content/TrainingQRCode/QR-of-" + RefCode + ".jpg";
                                var image = "<img width=\"113\" height=\"113\" src=\"" + url + "\" />";
                                body1.Replace("[QRCode]", image);
                                BLL.Common.SendMail(objEventUserInfo.Email, objTemplates.Subject, body1.ToString());
                            }
                        }
                    }
                    return Json(new { ok = true, data = str });
                }               
                else
                {
                    str = "<div class=\"error closable\">Failed sending QR Code</div>";
                    return Json(new { ok = false, data = str });
                }
            }
            catch (Exception ex)
            {
                str = "<div class=\"error closable\">" + ex.Message + "</div>";
                return Json(new { ok = true, data = str });
            }
        }

        #endregion
        #region CulturalInfo
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult ViewCulturalUser(Int64 EventUserInfoId = 0)
        {
            try
            {
                Entities.CulturalUserInfo objEventUserInfo = new Entities.CulturalUserInfo();

                int _qstatus = 0;
                List<Entities.EventRegistrationCounts> lstEventRegCounts = new List<Entities.EventRegistrationCounts>();
                List<Entities.EventsTickets> lstEventsTickets = new List<Entities.EventsTickets>();
                Entities.Events objEvents = new Entities.Events();

                objEventUserInfo = _Events.GetCulturalUserInfoFullDetailsById(EventUserInfoId, 0, ref objEvents, ref lstEventRegCounts, ref lstEventsTickets, ref _qstatus);

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
                    return RedirectToAction("Index", "Registrations");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Registrations");
            }
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditCulturalUser(Int64 EventUserInfoId = 0)
        {
            Entities.CulturalUserInfo objEventUserInfo = new Entities.CulturalUserInfo();
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
                    return RedirectToAction("Registrations", "EventRegistrations");
                }

                int _qstatus = 0;
                List<Entities.EventRegistrationCounts> lstEventRegCounts = new List<Entities.EventRegistrationCounts>();
                List<Entities.EventsTickets> lstEventsTickets = new List<Entities.EventsTickets>();
                Entities.Events objEvents = new Entities.Events();

                objEventUserInfo = _Events.GetCulturalUserInfoFullDetailsById(EventUserInfoId, 0, ref objEvents, ref lstEventRegCounts, ref lstEventsTickets, ref _qstatus);

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
                    return RedirectToAction("Registrations", "EventRegistrations");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Registrations", "EventRegistrations");
            }
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateCulturalUser(Entities.CulturalUserInfo objEventUserInfo, List<Entities.CulturalParticipants> lstParticipantsInfo)
        {
            try
            {

                objEventUserInfo.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                objEventUserInfo.InsertedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _Events.UpdateCulturalUserInfo(objEventUserInfo);

                if (_status != -1)
                {
                    foreach (Entities.CulturalParticipants objChildrenInfo in lstParticipantsInfo)
                    {
                        objChildrenInfo.EventUserInfoId = objEventUserInfo.EventUserInfoId;
                        if (objChildrenInfo != null && objChildrenInfo.FirstName != null)
                        {
                            objChildrenInfo.IsApproved = false;
                            objChildrenInfo.UpdatedBy = objChildrenInfo.FirstName;
                            Int64 estatus = _Events.InsertCulturalParticipant(objChildrenInfo);
                            if (estatus == -1)
                            {
                                TempData["message"] = "<div class=\"error closable\">Failed inserting member details.</div>";
                                return RedirectToAction("EditCulturalUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
                            }
                        }
                    }
                    TempData["message"] = "<div class=\"success closable\">Updated user details successfully.</div>";
                    return RedirectToAction("EditCulturalUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed Transaction.</div>";
                    return RedirectToAction("EditCulturalUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditCulturalUser", "EventRegistrations", new { EventUserInfoId = objEventUserInfo.EventUserInfoId });
            }

        }


        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        public JsonResult DeleteCulturalUser(Int64 EventUserInfoId)
        {
            string str = "";
            try
            {

                Int64 _status = _Events.DeleteCulturalUserInfoById(EventUserInfoId);
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
        public JsonResult CulturalUserInfoStatus(Int64 EventUserInfoId, string type = "")
        {

            string str = "";
            string QrUri = "";
            try
            {
                Int64 _status = _Events.UpdateCulturalUserInfoStatus(EventUserInfoId);

                int status = 0;
                if (_status == 1)
                {
                    string RefCode = "WATS" + EventUserInfoId;
                    Entities.EventComments objcomments = new Entities.EventComments();


                    objcomments.EmployeeRefUrl = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "cul-qrcode-preview.html?id=" + EventUserInfoId;

                    string WebUri = objcomments.EmployeeRefUrl;

                    string UriPayload = WebUri.ToString();

                    QRCodeGenerator QrGenerator = new QRCodeGenerator();
                    QRCodeData QrCodeInfo = QrGenerator.CreateQrCode(UriPayload, QRCodeGenerator.ECCLevel.Q);

                    //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    //imgBarCode.Height = 150;
                    //imgBarCode.Width = 150;




                    //QRCode QrCode = new QRCode(QrCodeInfo);
                    //Bitmap QrBitmap = QrCode.GetGraphic(60);
                    //byte[] BitmapArray = QrBitmap.BitmapToByteArray();
                    //QrUri = string.Format("data:image/png;base64,{0}", Convert.ToBase64String(BitmapArray));
                    //ViewBag.QrCodeUri = QrUri;

                    #region QRCode Generation Code


                    string pdffilepath = "";

                    #region Barcode

                    //GenerateBacode(item.Field1);

                    #endregion

                    #region Ticket Image Generation
                    System.Drawing.Image orgImg;


                    //Load the Image to be written on.
                    Bitmap bitMapImage = new System.Drawing.Bitmap(Server.MapPath("~/Content/QRCodeGeneration/Qrcodesample.png"));
                    Graphics graphicImage = Graphics.FromImage(bitMapImage);


                    //Smooth graphics is nice.
                    graphicImage.SmoothingMode = SmoothingMode.AntiAlias;
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;

                    StringFormat sf = new StringFormat();
                    sf.LineAlignment = StringAlignment.Center;
                    sf.Alignment = StringAlignment.Center;

                    pdffilepath = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "cul-qrcode-preview.html?id=" + EventUserInfoId; ;

                    string code = pdffilepath;


                    QRCodeGenerator qrGenerator = new QRCodeGenerator();
                    QRCodeData qrCodeData = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                    QRCode qrCode = new QRCode(qrCodeData);
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();


                    imgBarCode.Height = 140;
                    imgBarCode.Width = 140;

                    string strB = System.Configuration.ConfigurationManager.AppSettings["uploadPath"] + "\\TrainingQRCode\\QR-of-" + RefCode + ".jpg";

                    strB = strB.Replace("https://", "");
                    strB = strB.Replace("/", "");


                    using (Bitmap bitMap = qrCode.GetGraphic(20))
                    {
                        using (MemoryStream msa = new MemoryStream())
                        {
                            bitMap.Save(msa, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = msa.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                            bitMap.Save(strB);
                        }
                    }


                    //Clean house.
                    graphicImage.Dispose();
                    bitMapImage.Dispose();

                    #endregion

                    #endregion


                    str = "<div class=\"success closable\">Updated user status successfully</div>";
                    if (type == "Cultural")
                    {
                        Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Cultural Registration", 0, ref status);
                        if (objTemplates != null)
                        {
                            Entities.CulturalUserInfo objEventUserInfo = _Events.CulturalUserInfoGetById(EventUserInfoId, ref status);
                            StringBuilder body1 = new StringBuilder();
                            if (objEventUserInfo.IsApproved == true)
                            {
                                body1.Append(objTemplates.Description);
                                body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                                body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                                body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                                body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                                body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                                body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                                body1.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.FirstName + "" + objEventUserInfo.LastName));
                                body1.Replace("[EVENTNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.EventName));
                                string url = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "Content/TrainingQRCode/QR-of-" + RefCode + ".jpg";
                                var image = "<img width=\"113\" height=\"113\" src=\"" + url + "\" />";
                                body1.Replace("[QRCode]", image);
                                BLL.Common.SendMail(objEventUserInfo.Email, objTemplates.Subject, body1.ToString());
                            }
                        }
                    }
                    else if (type == "Event")
                    {
                        Entities.MailTemplates objTemplates = _MailTemplates.GetMailTemplateById("Confirm Event Registration", 0, ref status);
                        if (objTemplates != null)
                        {
                            Entities.EventUserInfo objEventUserInfo = _Events.GetEventUserInfoById(EventUserInfoId, ref status);
                            StringBuilder body1 = new StringBuilder();
                            if (objEventUserInfo.IsApproved == true)
                            {
                                body1.Append(objTemplates.Description);
                                body1.Replace("[usersiteurl]", ConfigurationManager.AppSettings["usersiteurl"].ToString());
                                body1.Replace("[FBUrl]", ConfigurationManager.AppSettings["FBUrl"].ToString());
                                body1.Replace("[TWUrl]", ConfigurationManager.AppSettings["TWUrl"].ToString());
                                body1.Replace("[YUrl]", ConfigurationManager.AppSettings["YUrl"].ToString());
                                body1.Replace("[TPhoneNo]", ConfigurationManager.AppSettings["TPhoneNo"].ToString());
                                body1.Replace("[TEmailId]", ConfigurationManager.AppSettings["TEmailId"].ToString());
                                body1.Replace("[USERNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.FirstName + "" + objEventUserInfo.LastName));
                                body1.Replace("[EVENTNAME]", BLL.Common.UppercaseFirst(objEventUserInfo.EventName));
                                string url = ConfigurationManager.AppSettings["usersiteurl"].ToString() + "Content/TrainingQRCode/QR-of-" + RefCode + ".jpg";
                                var image = "<img width=\"113\" height=\"113\" src=\"" + url + "\" />";
                                body1.Replace("[QRCode]", image);
                                BLL.Common.SendMail(objEventUserInfo.Email, objTemplates.Subject, body1.ToString());
                            }
                        }
                    }
                    return Json(new { ok = true, data = str });
                }
                else if (_status == 2)
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
            catch (Exception ex)
            {
                str = "<div class=\"error closable\">" + ex.Message + "</div>";
                return Json(new { ok = true, data = str });
            }
        }

        public ActionResult DeleteCulParticipants(Int64 CulturalParticipantId, Int64 EventUserInfoId = 0)
        {
            try
            {
                Int64 _status = _Events.DeleteCulturalParticipantsById(CulturalParticipantId);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Deleted child info successfully</div>";
                    return RedirectToAction("EditCulturalUser", "EventRegistrations", new { EventUserInfoId = EventUserInfoId });
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("EditCulturalUser", "EventRegistrations", new { EventUserInfoId = EventUserInfoId });
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("EditCulturalUser", "EventRegistrations", new { EventUserInfoId = EventUserInfoId });
            }
        }

        #endregion
    }

    //Extension method to convert Bitmap to Byte Array
    public static class BitmapExtension
    {
        public static byte[] BitmapToByteArray(this Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }
    }
}
