using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.IO;
using System.Web.Mail;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Net.Mail;
using System.Xml;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Net.Sockets;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using RestSharp;
using System.Collections.Specialized;

namespace WATS.BLL
{
    public class Common
    {

        public static string ValidateImage(string absoluteUrl, string defaultUrl)
        {
            Uri myUri = null;
            if (Uri.TryCreate(absoluteUrl, UriKind.Absolute, out myUri))
            {
                using (WebClient client = new WebClient())
                {
                    try
                    {
                        using (Stream stream = client.OpenRead(myUri))
                        {
                            System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                            return (image != null) ? absoluteUrl : defaultUrl;
                        }
                    }
                    catch (ArgumentException)
                    {
                        return defaultUrl;
                    }
                    catch (WebException)
                    {
                        return defaultUrl;
                    }
                }
            }
            else
            {
                return defaultUrl;
            }
        }

        public static string SetPaging(Int64 RecordsPerPage, ref Int64 TotalRecords, Int64 CurrentPageNo, string pclass)
        {
            Int64 Page_Mod = default(Int64);
            Int64 Page_Size = default(Int64);
            StringBuilder sbPage_HTML = new StringBuilder();
            string strRet = string.Empty;
            string strRSS = string.Empty;
            Int64 Page_Mid = 0;
            Int64 MaxPageSize = 5;

            if (TotalRecords > RecordsPerPage)
            {
                Page_Mid = (MaxPageSize / 2);
                Page_Mid = Page_Mid + 1;

                if (RecordsPerPage > 0)
                {
                    Page_Mod = TotalRecords % RecordsPerPage;
                    Page_Size = (TotalRecords / RecordsPerPage);
                    if (Page_Mod > 0)
                    {
                        Page_Size = Page_Size + 1;
                    }
                }
                else
                {
                    Page_Size = 1;
                }

                if ((Page_Size > 1))
                {
                    Int64 Start = ((CurrentPageNo - 1) * RecordsPerPage) + 1;
                    Int64 End = ((CurrentPageNo - 1) * RecordsPerPage) + RecordsPerPage;
                    if (End > TotalRecords)
                        End = TotalRecords;
                    sbPage_HTML.Append("<div class=\""+pclass+"\"><ul>");
                    //sbPage_HTML.Append("<div class='pagination'>v><ul>");
                }

                bool isShow_Forward = true;

                if (CurrentPageNo > Page_Mid)
                {
                    sbPage_HTML.Append("<li><a id='«'>" + "«" + "</a></li>");
                }

                for (int i = 1; i <= MaxPageSize; i++)
                {
                    Int64 PageId = default(Int64);
                    if (CurrentPageNo > Page_Mid)
                    {
                        PageId = CurrentPageNo + (i - Page_Mid);
                    }
                    else
                    {
                        PageId = i;
                    }
                    if (PageId <= Page_Size)
                    {
                        if (Convert.ToInt64(CurrentPageNo) == PageId)
                        {
                            sbPage_HTML.Append("<li class=\"active\"><a ><span>" + PageId.ToString() + "</span></a></li>");

                        }
                        else
                        {
                            sbPage_HTML.Append("<li><a id='" + PageId.ToString() + "'>" + PageId.ToString() + "</a></li>");
                            //sbPage_HTML.Append("<a id='pgr_" + PageId.ToString() + "' href='?pageno=" + PageId.ToString() + "'>" + PageId.ToString() + "</a>");

                        }
                    }
                    if (PageId == Page_Size)
                    {
                        isShow_Forward = false;
                    }
                }


                if (isShow_Forward == true)
                {
                    sbPage_HTML.Append("<li><a id='»'>" + "»" + "</a></li>");
                }

                if ((Page_Size > 1))
                {
                    sbPage_HTML.Append("</ul></div>");
                }

            }

            strRet = sbPage_HTML.ToString();
            return strRet;
        }

        public static async Task SendMail(string to, string subject, string body)
        {
            try
            {
                string[] emails = to.Split(',');
                string from1 = ConfigurationManager.AppSettings["adminemailid"].ToString();
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                foreach (string recipientemail in emails)
                {
                    var client = new SendGridClient(ConfigurationManager.AppSettings["GridMailKey"]);
                    var frommail = new EmailAddress(from1, ConfigurationManager.AppSettings["mailname"]);
                    var tomail = new EmailAddress(recipientemail);
                    var htmlContent = body;
                    var msg = MailHelper.CreateSingleEmail(frommail, tomail, subject, "", htmlContent);
                    var response = await client.SendEmailAsync(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task SendMailwithfrom(string to, string from1, string subject, string body)
        {
            try
            {
                string[] emails = to.Split(',');
                //string from1 = ConfigurationManager.AppSettings["adminemailid"].ToString();
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                foreach (string recipientemail in emails)
                {
                    var client = new SendGridClient(ConfigurationManager.AppSettings["GridMailKey"]);
                    var frommail = new EmailAddress(from1, ConfigurationManager.AppSettings["mailname"]);
                    var tomail = new EmailAddress(recipientemail);
                    var htmlContent = body;
                    var msg = MailHelper.CreateSingleEmail(frommail, tomail, subject, "", htmlContent);
                    var response = await client.SendEmailAsync(msg);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task SendMailwithCC(string to, string from1, string cc, string subject, string body)
        {
            try
            {
                string[] emails = to.Split(',');
                //string from1 = ConfigurationManager.AppSettings["adminemailid"].ToString();
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                foreach (string recipientemail in emails)
                {

                    var client = new SendGridClient(ConfigurationManager.AppSettings["MailKey"]);
                    var frommail = new EmailAddress(from1, ConfigurationManager.AppSettings["mailname"]);
                    var tomail = new EmailAddress(recipientemail);
                    var ccmail = new EmailAddress(cc);
                    var htmlContent = body;
                    var msg = MailHelper.CreateSingleEmail(frommail, tomail, subject, "", htmlContent);
                    msg.AddCc(ccmail);
                    var response = client.SendEmailAsync(msg);

                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static async Task SendMailWithattachment(string to, string subject, string body, string attachment)
        {
            // Write Log Report as [Started this]
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string[] emails = to.Split(',');
            foreach (string recipientemail in emails)
            {
                var client = new SendGridClient(ConfigurationManager.AppSettings["GridMailKey"]);
                var frommail = new EmailAddress(ConfigurationManager.AppSettings["adminemailid"], ConfigurationManager.AppSettings["mailname"]);
                var tomail = new EmailAddress(recipientemail);
                var htmlContent = body;
                var msg = MailHelper.CreateSingleEmail(frommail, tomail, subject, "", htmlContent);

                if (attachment != null)
                {
                    //msg.Attachments.Add(attachment);  
                    string filepath = ConfigurationManager.AppSettings["cuploadPath"] + attachment;
                    var bytes = File.ReadAllBytes(filepath);
                    var file = Convert.ToBase64String(bytes);
                    msg.AddAttachment(attachment, file);
                }
                var response = client.SendEmailAsync(msg);
            }

            // Write Log Report as [Ended this]
        }


        //public static void SendMailwithfrom(string to,string frommail, string subject, string body)
        //{
        //    try
        //    {
        //        string[] emails = to.Split(',');
        //        string from1 = frommail;
        //        foreach (string recipientemail in emails)
        //        {
        //            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
        //            MailAddress from = new MailAddress(from1,frommail);
        //            MailAddress to1 = new MailAddress(recipientemail);
        //            System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(from, to1);
        //            mm.BodyEncoding = Encoding.UTF8;
        //            mm.Subject = subject;
        //            mm.From = from;
        //            mm.Body = body;
        //            mm.Priority = System.Net.Mail.MailPriority.High;
        //            mm.IsBodyHtml = true;

        //            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient(settings.Smtp.Network.Host, settings.Smtp.Network.Port);
        //            Client.Credentials = new System.Net.NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
        //            if (ConfigurationManager.AppSettings["EnableSsl"] == "true")
        //            { Client.EnableSsl = true; }
        //            else { Client.EnableSsl = false; }
        //            Client.Send(mm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static void SendMailwithCC(string to, string from1, string cc, string subject, string body)
        //{
        //    try
        //    {
        //        string[] emails = to.Split(',');
        //        //string from1 = ConfigurationManager.AppSettings["adminemailid"].ToString();
        //        foreach (string recipientemail in emails)
        //        {
        //            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
        //            MailAddress from = new MailAddress(from1);
        //            MailAddress to1 = new MailAddress(recipientemail);
        //            string str = to;
        //            str = str.Replace(recipientemail.Trim() + ",", "");
        //            //MailAddress cc = new MailAddress(str);

        //            System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(from, to1);
        //            mm.BodyEncoding = Encoding.UTF8;
        //            mm.Subject = subject;
        //            mm.Body = body;
        //            mm.CC.Add(cc);
        //            mm.Priority = System.Net.Mail.MailPriority.High;
        //            mm.IsBodyHtml = true;
        //            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient(settings.Smtp.Network.Host, settings.Smtp.Network.Port);
        //            Client.Credentials = new System.Net.NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
        //            if (ConfigurationManager.AppSettings["EnableSsl"] == "true")
        //            { Client.EnableSsl = true; }
        //            else { Client.EnableSsl = false; }
        //            Client.Send(mm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static void SendMail(string to, string subject, string body)
        //{
        //    try
        //    {
        //        string[] emails = to.Split(',');
        //        string from1 = ConfigurationManager.AppSettings["adminemailid"].ToString();
        //        foreach (string recipientemail in emails)
        //        {
        //            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
        //            MailAddress from = new MailAddress(from1);
        //            MailAddress to1 = new MailAddress(recipientemail);
        //            System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(from, to1);
        //            mm.BodyEncoding = Encoding.UTF8;
        //            mm.Subject = subject;
        //            mm.Body = body;
        //            mm.Priority = System.Net.Mail.MailPriority.High;
        //            mm.IsBodyHtml = true;
        //            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient(settings.Smtp.Network.Host, settings.Smtp.Network.Port);
        //            Client.Credentials = new System.Net.NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
        //            if (ConfigurationManager.AppSettings["EnableSsl"] == "true")
        //            { Client.EnableSsl = true; }
        //            else { Client.EnableSsl = false; }
        //            Client.Send(mm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public static void SendMailwithAttachment(string to, string subject, string body, HttpPostedFileBase fileUploader,HttpPostedFileBase fileUploader1)
        //{
        //    try
        //    {
        //        string[] emails = to.Split(',');
        //        string from1 = ConfigurationManager.AppSettings["adminemailid"].ToString();
        //        foreach (string recipientemail in emails)
        //        {
        //            Configuration config = WebConfigurationManager.OpenWebConfiguration(HttpContext.Current.Request.ApplicationPath);
        //            MailSettingsSectionGroup settings = (MailSettingsSectionGroup)config.GetSectionGroup("system.net/mailSettings");
        //            MailAddress from = new MailAddress(from1);
        //            MailAddress to1 = new MailAddress(recipientemail);
        //            System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage(from, to1);
        //            mm.BodyEncoding = Encoding.UTF8;
        //            mm.Subject = subject;
        //            mm.Body = body;
        //            mm.Priority = System.Net.Mail.MailPriority.High;
        //            if (fileUploader != null)
        //            {

        //                string fileName = Path.GetFileName(fileUploader.FileName);

        //                mm.Attachments.Add(new Attachment(fileUploader.InputStream, fileName));

        //            }
        //            if (fileUploader1 != null)
        //            {

        //                string fileName1 = Path.GetFileName(fileUploader1.FileName);

        //                mm.Attachments.Add(new Attachment(fileUploader1.InputStream, fileName1));

        //            }
        //            mm.IsBodyHtml = true;
        //            System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient(settings.Smtp.Network.Host, settings.Smtp.Network.Port);
        //            Client.Credentials = new System.Net.NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
        //            if (ConfigurationManager.AppSettings["EnableSsl"] == "true")
        //            { Client.EnableSsl = true; }
        //            else { Client.EnableSsl = false; }
        //            Client.Send(mm);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static string CreateXMLForObject(Object YourClassObject)
        {
            XmlDocument xmlDoc = new XmlDocument();   //Represents an XML document, 
            // Initializes a new instance of the XmlDocument class.          
            XmlSerializer xmlSerializer = new XmlSerializer(YourClassObject.GetType());
            // Creates a stream whose backing store is memory. 
            using (MemoryStream xmlStream = new MemoryStream())
            {
                xmlSerializer.Serialize(xmlStream, YourClassObject);
                xmlStream.Position = 0;
                //Loads the XML document from the specified string.
                xmlDoc.Load(xmlStream);
                return xmlDoc.InnerXml;
            }
        }

        public static string EncodeURL(string input)
        {
            return Regex.Replace(input.Trim(), "[&/:*?<>|.]", string.Empty).Replace(" ", "-").Replace("--", "-").Replace("---", "-").Replace("----", "-").ToLower();
        }

        public static string DecodeURL(string input)
        {
            return input.Trim().Replace("_", "/").Replace("-", " ").Replace(".", "-");
        }
 
        public static Guid generateGUID()
        {
            return Guid.NewGuid();
        }

        public static string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public static string GetRandomString(int maxSize)
        {
            char[] chars = new char[80];
            chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }
                if (let == '>')
                {
                    inside = false;
                    continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static string ConvertDatatableToXML(DataTable dt)
        {
            MemoryStream str = new MemoryStream();
            dt.WriteXml(str, true);
            str.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(str);
            string xmlstr;
            xmlstr = sr.ReadToEnd();
            return (xmlstr);
        }

        public static class CSVUtility
        {
            public static MemoryStream GetCSV(DataTable data)
            {
                string[] fieldsToExpose = new string[data.Columns.Count];
                for (int i = 0; i < data.Columns.Count; i++)
                {
                    fieldsToExpose[i] = data.Columns[i].ColumnName;
                }

                return GetCSV(fieldsToExpose, data);
            }

            public static MemoryStream GetCSV(string[] fieldsToExpose, DataTable data)
            {
                MemoryStream stream = new MemoryStream();
                using (var writer = new StreamWriter(stream))
                {
                    for (int i = 0; i < fieldsToExpose.Length; i++)
                    {
                        if (i != 0) { writer.Write(","); }
                        //writer.Write("\"");
                        writer.Write(fieldsToExpose[i]);
                        //writer.Write("\"");                    
                    }
                    //writer.Write("\n");
                    writer.Write(Environment.NewLine);

                    foreach (DataRow row in data.Rows)
                    {
                        for (int i = 0; i < fieldsToExpose.Length; i++)
                        {
                            if (i != 0) { writer.Write(","); }
                            //writer.Write("\"");
                            writer.Write(Regex.Replace(row[fieldsToExpose[i]].ToString(), @"\t|\n|\r", ""));
                            //writer.Write("\"");
                        }
                        //writer.Write("\n");
                        writer.Write(Environment.NewLine);
                    }
                }

                return stream;
            }
        }


    }
}
