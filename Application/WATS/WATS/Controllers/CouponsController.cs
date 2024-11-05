using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Members,")]
    [WATS.Models.SessionClass.SessionExpireFilter]
    public class CouponsController : Controller
    {
        WATS.BLL.Coupons _Coupons = new WATS.BLL.Coupons();
        WATS.BLL.MembershipTypes _MembershipTypes = new WATS.BLL.MembershipTypes();
                
        public ActionResult Index()
        {
            int _qstatus = 0;           
            try
            {
                List<Entities.MembershipTypes> lstMembershipTypes = _MembershipTypes.GetMembershipTypesList(ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.lstMembershipTypes = lstMembershipTypes;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Coupons");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }

            return View();
        }

        [HttpGet]
        public ActionResult CouponsList(string search = "", int PageNo = 1, int PageItems = 10, string SortColumn = "", string SortOrder = "")
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            int Total = 0;
            List<Entities.Coupons> lstcoupons = new List<Entities.Coupons>();
            try
            {
                lstcoupons = _Coupons.GetCouponListByVariable(HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);
                
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }


            ViewBag.total = Total;
            ViewBag.items = PageItems;
            ViewBag.PageNo = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder;
            ViewBag.lstcoupons = lstcoupons;
            return View();
        }

        [HttpPost]
        public ActionResult AddCoupons(Entities.Coupons objCoupon,HttpPostedFileBase DocumentUrl)
        {
            try
            {
                var image = WebImage.GetImageFromRequest();
                string imageurl = (image != null ? image.ImageFormat : "NA");

                if (DocumentUrl != null)
                {
                    string filename = objCoupon.CouponName + DateTime.Now.ToString("ddMMyyyyHHmmss") + DocumentUrl.FileName;

                    DocumentUrl.SaveAs(ConfigurationManager.AppSettings["uploadPath"] + "\\coupons\\document\\" + filename);
                    objCoupon.DocumentUrl = filename;
                }

                objCoupon.UpdatedBy = this.User.Identity.Name;
                Int64 _status = _Coupons.InsertCoupons(objCoupon, ref imageurl);
                if (_status != -1)
                {
                    if (imageurl != "")
                    {
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\coupons\\normalimages\\" + imageurl);

                        image.Resize(130, 130, true, false);
                        image.Crop(1, 1, 1, 1);
                        image.Save(ConfigurationManager.AppSettings["uploadPath"] + "\\coupons\\thumbimages\\" + imageurl);

                    }
                    TempData["message"] = "<div class=\"success closable\">Coupon details Uploaded successfully.</div>";
                    return RedirectToAction("Index", "Coupons");

                }
                else
                {
                    if (imageurl != null)
                    {
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\UserProfileImages\\" + imageurl);
                    }
                    if (DocumentUrl != null)
                    {
                        System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\UserProfileImages\\" + imageurl);
                    }
                    TempData["message"] = "<div class=\"error closable\"Uploading Failed.</div>";
                    return RedirectToAction("Index", "Coupons");
                }
            }
            catch 
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Coupons");
            }
        }

        [HttpPost]
        public ActionResult EditCoupon(Int64 CouponId)
        {
            string str = "";
            int status = 0;
            try
            {
                Entities.Coupons objCoupons = _Coupons.GetCouponById(CouponId, ref status);
                if (objCoupons != null)
                {
                    return Json(new { ok = true, data = objCoupons });
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

        [HttpPost]
        public ActionResult ViewCoupon(Int64 CouponId)
        {
            string str = "";
            int status = 0;
            try
            {
                Entities.Coupons objCoupons = _Coupons.GetCouponById(CouponId, ref status);
                if (objCoupons != null)
                {
                    return Json(new { ok = true, data = objCoupons });
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

        [HttpPost]
        public JsonResult DeleteCoupon(Int64 CouponId, string LogoUrl = "", string DocumentUrl = "")
        {
            string str = "";
            try
            {
                Int64 _status = _Coupons.DeleteCoupon(CouponId);
                if (_status == 1)
                {
                    System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\coupons\\normalimages\\" + LogoUrl);
                    System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\coupons\\thumbimages\\" + LogoUrl);
                    System.IO.File.Delete(ConfigurationManager.AppSettings["uploadpath"] + @"\\coupons\\document\\" + DocumentUrl);
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

        [HttpPost]
        public JsonResult CouponsStatus(Int64 CouponId)
        {
            string str = "";
            try
            {
                Int64 _status = _Coupons.UpdateCouponsStatus(CouponId);
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
