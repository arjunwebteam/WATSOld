using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Web.Configuration;
using System.Data;
using System.IO;


namespace WATS.Admin.Controllers
{
    [Models.SessionClass.PermitAccess(Roles = "SuperAdmin,Asset")]
    public class AssetController : Controller
    {
        WATS.BLL.Asset _Asset = new WATS.BLL.Asset();
        WATS.Entities.Asset objAsset = new WATS.Entities.Asset();
        WATS.DAL.Asset _DAsset = new WATS.DAL.Asset();

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AssetList(string search = "", string SortColumn = "", string SortOrder = "", int PageNo = 1, int PageItems = 10)
        {
            int Total = 0;
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            List<Entities.Asset> lstAsset = new List<Entities.Asset>();
            try
            {
                lstAsset = _Asset.GetAssetListByVariable(HttpUtility.UrlDecode(search.Trim()), Sort, PageNo, PageItems, ref Total);

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
            }

            ViewBag.total = Total;
            ViewBag.items = PageItems;
            ViewBag.pageno = PageNo;
            ViewBag.sortcolumn = SortColumn;
            ViewBag.sortorder = SortOrder.ToLower();
            ViewBag.lstAsset = lstAsset;
            return View();
        }



        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult AddAsset()
        {
            return View();
        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddAsset(Entities.Asset objAsset)
        {
            try
            {

                objAsset.UpdatedBy = HttpContext.User.Identity.Name.ToString();
                Int64 _status = _Asset.InsertAsset(objAsset);
                if (_status == 1)
                {
                    TempData["message"] = "<div class=\"success closable\">Created Asset Successfully</div>";
                    return RedirectToAction("Index", "Asset");
                }
                if (_status == 2)
                {
                    TempData["message"] = "<div class=\"success closable\">Updated Asset Successfully</div>";
                    return RedirectToAction("Index", "Asset");
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed uploading page.</div>";
                    return RedirectToAction("AddAsset", "Asset");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("AddAsset", "Asset");
            }

        }

        [WATS.Models.SessionClass.SessionExpireFilter]
        public ActionResult EditAsset(Int64 AssetId = 0)
        {
            try
            {

                int _qstatus = 0;
                Entities.Asset objAsset = _Asset.GetAssetById(AssetId, ref _qstatus);

                if (_qstatus == 1)
                {
                    ViewBag.objAsset = objAsset;
                    ViewBag.status = _qstatus;
                }
                else
                {
                    TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                    return RedirectToAction("Index", "Asset");
                }
            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Failed transaction.</div>";
                return RedirectToAction("Index", "Asset");
            }
            return View();
        }


        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult DeleteAsset(Int64 AssetId)
        {
            string str = "";
            try
            {
                Int64 _status = _Asset.DeleteAsset(AssetId);
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
        public ActionResult ViewAsset(Int64 AssetId)
        {
            Entities.Asset objAsset = new Entities.Asset();
            int status = 0;
            try
            {
                objAsset = _Asset.GetAssetById(AssetId, ref status);

                if (objAsset == null)
                {
                    TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                    return RedirectToAction("Index", "Asset");
                }

            }
            catch
            {
                TempData["message"] = "<div class=\"error closable\">Sorry, failed processing your request.</div>";
                return RedirectToAction("Index", "Asset");
            }

            ViewBag.objAsset = objAsset;
            return View();
        }

        public void AssetExporttoExcel(string Search = "", string SortColumn = "UpdatedTime", string SortOrder = "DESC")
        {
            string Sort = (SortColumn != "" ? SortColumn + " " + SortOrder : "");
            try
            {
                DataTable dtUni = _DAsset.ExportAssetGetList(Search, Sort);
                MemoryStream stream = BLL.Common.CSVUtility.GetCSV(dtUni);

                var filename = "CSV-Asset-Export-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".csv";
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

        [HttpPost]
        [WATS.Models.SessionClass.SessionExpireFilter]
        public JsonResult AssetStatus(Int64 AssetId)
        {
            string str = "";
            try
            {
                Int64 _status = _Asset.UpdateAssetStatus(AssetId);
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
