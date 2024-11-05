using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Xml;


namespace WATS.BLL
{
    public class AppInfo
    {
        WATS.DAL.AppInfo _AppInfo = new WATS.DAL.AppInfo();

        #region Admin

        #region Methods

        public Int64 UpdateAppInfoDetails(Entities.AppInfo objAppInfo)
        {
            Int64 _status = 0;
            _status = _AppInfo.UpdateAppInfoDetails(objAppInfo);

            return _status;
        }

        public Int64 GetAppInfoEmail(ref string CompanyEmail)
        {
            Int64 _status = 0;
            _status = _AppInfo.GetAppInfoEmail(ref CompanyEmail);
            return _status;
        }

        #endregion

        #region Entities filling

        public Entities.AppInfo GetAppInfoDetails(ref int Status)
        {
            DataTable dt = _AppInfo.GetAppInfoDetails(ref Status);
            Entities.AppInfo objAppInfo = new Entities.AppInfo();

            if (Status == 1 && dt.Rows.Count == 1)
            {
                objAppInfo.AppInfoId = Convert.ToInt64(dt.Rows[0]["AppInfoId"]);
                objAppInfo.SiteName = dt.Rows[0]["SiteName"].ToString();
                objAppInfo.CompanyAddress = (dt.Rows[0]["CompanyAddress"] != DBNull.Value ? dt.Rows[0]["CompanyAddress"].ToString() : null);
                objAppInfo.CompanyWebSite = (dt.Rows[0]["CompanyWebSite"] != DBNull.Value ? dt.Rows[0]["CompanyWebSite"].ToString() : null);
                objAppInfo.CompanyEmail = (dt.Rows[0]["CompanyEmail"] != DBNull.Value ? dt.Rows[0]["CompanyEmail"].ToString() : null);
                objAppInfo.CompanyPhone = (dt.Rows[0]["CompanyPhone"] != DBNull.Value ? dt.Rows[0]["CompanyPhone"].ToString() : null);
                objAppInfo.PresidentEmail = (dt.Rows[0]["PresidentEmail"] != DBNull.Value ? dt.Rows[0]["PresidentEmail"].ToString() : null);
                objAppInfo.PresidentPhone = (dt.Rows[0]["PresidentPhone"] != DBNull.Value ? dt.Rows[0]["PresidentPhone"].ToString() : null);
                objAppInfo.SecretaryEmail = (dt.Rows[0]["SecretaryEmail"] != DBNull.Value ? dt.Rows[0]["SecretaryEmail"].ToString() : null);
                objAppInfo.SecretaryPhone = (dt.Rows[0]["SecretaryPhone"] != DBNull.Value ? dt.Rows[0]["SecretaryPhone"].ToString() : null);
                objAppInfo.CustomerCareNumber = (dt.Rows[0]["CustomerCareNumber"] != DBNull.Value ? dt.Rows[0]["CustomerCareNumber"].ToString() : null);
                objAppInfo.TollFreeNumber = (dt.Rows[0]["TollFreeNumber"] != DBNull.Value ? dt.Rows[0]["TollFreeNumber"].ToString() : null);
                objAppInfo.FacebookUrl = (dt.Rows[0]["FacebookUrl"] != DBNull.Value ? dt.Rows[0]["FacebookUrl"].ToString() : null);
                objAppInfo.TwitterUrl = (dt.Rows[0]["TwitterUrl"] != DBNull.Value ? dt.Rows[0]["TwitterUrl"].ToString() : null);
                objAppInfo.YoutubeUrl = (dt.Rows[0]["YoutubeUrl"] != DBNull.Value ? dt.Rows[0]["YoutubeUrl"].ToString() : null);
                objAppInfo.SupportEmail = (dt.Rows[0]["SupportEmail"] != DBNull.Value ? dt.Rows[0]["SupportEmail"].ToString() : null);
                objAppInfo.EnqueryEmail = (dt.Rows[0]["EnqueryEmail"] != DBNull.Value ? dt.Rows[0]["EnqueryEmail"].ToString() : null);
                objAppInfo.PageTitle = (dt.Rows[0]["PageTitle"] != DBNull.Value ? dt.Rows[0]["PageTitle"].ToString() : null);
                objAppInfo.MetaDescription = (dt.Rows[0]["MetaDescription"] != DBNull.Value ? dt.Rows[0]["MetaDescription"].ToString() : null);
                objAppInfo.MetaKeywords = (dt.Rows[0]["MetaKeywords"] != DBNull.Value ? dt.Rows[0]["MetaKeywords"].ToString() : null);
                objAppInfo.Topline = (dt.Rows[0]["Topline"] != DBNull.Value ? dt.Rows[0]["Topline"].ToString() : null);
                objAppInfo.PageItems = (dt.Rows[0]["PageItems"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["PageItems"].ToString()) : 0);
                objAppInfo.UpdatedBy = (dt.Rows[0]["UpdatedBy"] != DBNull.Value ? dt.Rows[0]["UpdatedBy"].ToString() : null);
                objAppInfo.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"]);

            }
            return objAppInfo;
        }

        #endregion

        #endregion

        #region Front End

        public void FEGetListInitialLoad(
            ref Entities.InnerPages objPInnerPages,
            ref Entities.InnerPages objMInnerPages,
            ref Entities.InnerPages objPSInnerPages,
            ref List<Entities.News> lstNews,
            ref List<Entities.WebsiteBanners> lstWebsiteBanners
          , ref List<Entities.Events> lstUpcommingEvents,
            ref List<Entities.Sponsors> lstSponsors,
            ref List<Entities.Sponsors> lstMediaSponsors,
            ref Entities.AppInfo objAppInfo,
            ref Entities.InnerPages objPGInnerPages,
            ref List<Entities.CommitteeCategories> lstCommitteeCategories,
            ref List<Entities.SponsorCategories> lstSponsorCategories,

            ref int status)
        {
            DataSet ds = _AppInfo.FEGetListInitialLoad(ref status);

            //WebsiteBanners List   
            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Entities.WebsiteBanners objWebsiteBanners = new Entities.WebsiteBanners();

                    objWebsiteBanners.WebsiteBannerId = Convert.ToInt64(dr["WebsiteBannerId"]);
                    objWebsiteBanners.BannerTitle = dr["BannerTitle"].ToString();
                    objWebsiteBanners.BannerUrl = dr["BannerUrl"].ToString();
                    objWebsiteBanners.Target = dr["Target"].ToString();
                    objWebsiteBanners.RedirectUrl = dr["RedirectUrl"].ToString();
                    objWebsiteBanners.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    lstWebsiteBanners.Add(objWebsiteBanners);
                }
            }

            // Upcomming Events List 
            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    Entities.Events objUpcommingEvents = new Entities.Events();

                    objUpcommingEvents.EventId = Convert.ToInt64(dr["EventId"]);
                    objUpcommingEvents.StartDate = (dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]) : DateTime.MinValue);
                    objUpcommingEvents.EndDate = (dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]) : DateTime.MinValue);
                    objUpcommingEvents.EventName = dr["EventName"].ToString();
                    objUpcommingEvents.Location = dr["Location"].ToString();
                    objUpcommingEvents.BannerUrl = dr["BannerUrl"].ToString();
                    objUpcommingEvents.EventDetails = dr["EventDetails"].ToString();
                    objUpcommingEvents.City = dr["City"].ToString();
                    objUpcommingEvents.StateName = dr["StateName"].ToString();
                    objUpcommingEvents.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    objUpcommingEvents.IsChild = (dr["IsChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsChild"].ToString()) : false);
                    objUpcommingEvents.ChildAmount = (dr["ChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["ChildAmount"]) : 0);
                    objUpcommingEvents.NonChildAmount = (dr["NonChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonChildAmount"]) : 0);
                    objUpcommingEvents.IsAdult = (dr["IsAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsAdult"].ToString()) : false);
                    objUpcommingEvents.AdultAmount = (dr["AdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["AdultAmount"]) : 0);
                    objUpcommingEvents.NonAdultAmount = (dr["NonAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonAdultAmount"]) : 0);
                    objUpcommingEvents.IsCouple = (dr["IsCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsCouple"].ToString()) : false);
                    objUpcommingEvents.CoupleAmount = (dr["CoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["CoupleAmount"]) : 0);
                    objUpcommingEvents.NonCoupleAmount = (dr["NonCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonCoupleAmount"]) : 0);
                    objUpcommingEvents.IsFamily = (dr["IsFamily"] != DBNull.Value ? Convert.ToBoolean(dr["IsFamily"].ToString()) : false);
                    objUpcommingEvents.FamilyAmount = (dr["FamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["FamilyAmount"]) : 0);
                    objUpcommingEvents.NonFamilyAmount = (dr["NonFamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonFamilyAmount"]) : 0);
                    objUpcommingEvents.IsVIP = (dr["IsVIP"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIP"].ToString()) : false);
                    objUpcommingEvents.VIPAmount = (dr["VIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPAmount"]) : 0);
                    objUpcommingEvents.NonVIPAmount = (dr["NonVIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPAmount"]) : 0);
                    objUpcommingEvents.IsVIPChild = (dr["IsVIPChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPChild"].ToString()) : false);
                    objUpcommingEvents.VIPChildAmount = (dr["VIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPChildAmount"]) : 0);
                    objUpcommingEvents.NonVIPChildAmount = (dr["NonVIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPChildAmount"]) : 0);
                    objUpcommingEvents.IsVIPSingleAdult = (dr["IsVIPSingleAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPSingleAdult"].ToString()) : false);
                    objUpcommingEvents.VIPSingleAdultAmount = (dr["VIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPSingleAdultAmount"]) : 0);
                    objUpcommingEvents.NonVIPSingleAdultAmount = (dr["NonVIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPSingleAdultAmount"]) : 0);
                    objUpcommingEvents.IsVIPCouple = (dr["IsVIPCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPCouple"].ToString()) : false);
                    objUpcommingEvents.VIPCoupleAmount = (dr["VIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPCoupleAmount"]) : 0);
                    objUpcommingEvents.NonVIPCoupleAmount = (dr["NonVIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPCoupleAmount"]) : 0);
                    objUpcommingEvents.IsRegistration = (dr["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(dr["IsRegistration"].ToString()) : false);
                    objUpcommingEvents.RegistrationStartDate = (dr["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationStartDate"]) : DateTime.MinValue);
                    objUpcommingEvents.RegistrationEndDate = (dr["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationEndDate"]) : DateTime.MinValue);

                    lstUpcommingEvents.Add(objUpcommingEvents);
                }
            }

            //News List
            if (ds.Tables[2].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    Entities.News objNews = new Entities.News();

                    objNews.NewsId = Convert.ToInt64(dr["NewsId"]);
                    objNews.PostDate = Convert.ToDateTime(dr["PostDate"]);
                    objNews.NewsText = dr["NewsText"].ToString();
                    objNews.Title = dr["Title"].ToString();
                    objNews.ImageUrl = dr["ImageUrl"].ToString();

                    lstNews.Add(objNews);
                }
            }

            //President Message
            if (ds.Tables[3].Rows.Count == 1)
            {
                DataTable dt = ds.Tables[3];
                objPInnerPages.InnerPageId = Convert.ToInt64(dt.Rows[0]["InnerPageId"]);
                objPInnerPages.Heading = dt.Rows[0]["Heading"].ToString();
                objPInnerPages.Description = dt.Rows[0]["Description"].ToString();
            }

            //Welcome Message
            if (ds.Tables[4].Rows.Count == 1)
            {
                DataTable dt = ds.Tables[4];
                objMInnerPages.InnerPageId = Convert.ToInt64(dt.Rows[0]["InnerPageId"]);
                objMInnerPages.Heading = dt.Rows[0]["Heading"].ToString();
                objMInnerPages.Description = dt.Rows[0]["Description"].ToString();
            }

            //Photos section
            if (ds.Tables[5].Rows.Count == 1)
            {
                DataTable dt = ds.Tables[5];
                objPSInnerPages.InnerPageId = Convert.ToInt64(dt.Rows[0]["InnerPageId"]);
                objPSInnerPages.Heading = dt.Rows[0]["Heading"].ToString();
                objPSInnerPages.Description = dt.Rows[0]["Description"].ToString();
            }

            // Sponsors List  
            if (ds.Tables[6].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[6].Rows)
                {
                    Entities.Sponsors objHTCASponsors = new Entities.Sponsors();

                    objHTCASponsors.SponsorId = Convert.ToInt64(dr["SponsorId"]);
                    objHTCASponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"]);
                    objHTCASponsors.LogoUrl = dr["LogoUrl"].ToString();
                    objHTCASponsors.RedirectUrl = dr["RedirectUrl"].ToString();
                    objHTCASponsors.InsertedTime = Convert.ToDateTime(dr["InsertedTime"]);

                    lstSponsors.Add(objHTCASponsors);
                }
            }

            // Sponsors List  
            if (ds.Tables[7].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[7].Rows)
                {
                    Entities.Sponsors objHTCASponsors = new Entities.Sponsors();

                    objHTCASponsors.SponsorId = Convert.ToInt64(dr["SponsorId"]);
                    objHTCASponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"]);
                    objHTCASponsors.LogoUrl = dr["LogoUrl"].ToString();
                    objHTCASponsors.RedirectUrl = dr["RedirectUrl"].ToString();
                    objHTCASponsors.InsertedTime = Convert.ToDateTime(dr["InsertedTime"]);

                    lstMediaSponsors.Add(objHTCASponsors);
                }
            }



            //AppInfo List  
            if (ds.Tables[8].Rows.Count != 0)
            {
                if (ds.Tables[8].Rows.Count == 1)
                {
                    objAppInfo.AppInfoId = Convert.ToInt64(ds.Tables[8].Rows[0]["AppInfoId"]);
                    objAppInfo.SiteName = ds.Tables[8].Rows[0]["SiteName"].ToString();
                    objAppInfo.CompanyAddress = ds.Tables[8].Rows[0]["CompanyAddress"].ToString();
                    objAppInfo.CompanyWebSite = ds.Tables[8].Rows[0]["CompanyWebSite"].ToString();
                    objAppInfo.CompanyEmail = ds.Tables[8].Rows[0]["CompanyEmail"].ToString();
                    objAppInfo.CompanyPhone = ds.Tables[8].Rows[0]["CompanyPhone"].ToString();
                    objAppInfo.PresidentPhone = ds.Tables[8].Rows[0]["PresidentPhone"].ToString();
                    objAppInfo.PresidentEmail = ds.Tables[8].Rows[0]["PresidentEmail"].ToString();
                    objAppInfo.SecretaryEmail = ds.Tables[8].Rows[0]["SecretaryEmail"].ToString();
                    objAppInfo.SecretaryPhone = ds.Tables[8].Rows[0]["SecretaryPhone"].ToString();
                    objAppInfo.CustomerCareNumber = ds.Tables[8].Rows[0]["CustomerCareNumber"].ToString();
                    objAppInfo.TollFreeNumber = ds.Tables[8].Rows[0]["TollFreeNumber"].ToString();
                    objAppInfo.FacebookUrl = ds.Tables[8].Rows[0]["FacebookUrl"].ToString();
                    objAppInfo.TwitterUrl = ds.Tables[8].Rows[0]["TwitterUrl"].ToString();
                    objAppInfo.YoutubeUrl = ds.Tables[8].Rows[0]["YoutubeUrl"].ToString();
                    objAppInfo.SupportEmail = ds.Tables[8].Rows[0]["SupportEmail"].ToString();
                    objAppInfo.EnqueryEmail = ds.Tables[8].Rows[0]["EnqueryEmail"].ToString();
                    objAppInfo.PageTitle = ds.Tables[8].Rows[0]["PageTitle"].ToString();
                    objAppInfo.MetaDescription = ds.Tables[8].Rows[0]["MetaDescription"].ToString();
                    objAppInfo.MetaKeywords = ds.Tables[8].Rows[0]["MetaKeywords"].ToString();
                    objAppInfo.Topline = ds.Tables[8].Rows[0]["Topline"].ToString();
                    objAppInfo.PageItems = (ds.Tables[8].Rows[0]["PageItems"] != DBNull.Value ? Convert.ToInt64(ds.Tables[8].Rows[0]["PageItems"]) : 0);
                    objAppInfo.UpdatedTime = Convert.ToDateTime(ds.Tables[8].Rows[0]["UpdatedTime"]);
                }
            }

            //Photo GAllery
            if (ds.Tables[9].Rows.Count == 1)
            {
                DataTable dt = ds.Tables[9];
                objPGInnerPages.InnerPageId = Convert.ToInt64(dt.Rows[0]["InnerPageId"]);
                objPGInnerPages.Heading = dt.Rows[0]["Heading"].ToString();
                objPGInnerPages.Description = dt.Rows[0]["Description"].ToString();
            }

            //Committee Categories 
            if (ds.Tables[10].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[10].Rows)
                {
                    WATS.Entities.CommitteeCategories objCommitteeCategories = new WATS.Entities.CommitteeCategories();

                    objCommitteeCategories.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
                    objCommitteeCategories.CategoryName = dr["CategoryName"].ToString();
                    objCommitteeCategories.Type = dr["Type"].ToString();
                    lstCommitteeCategories.Add(objCommitteeCategories);
                }
            }
            //Sponsor Categories 
            if (ds.Tables[11].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[11].Rows)
                {
                    WATS.Entities.SponsorCategories objSponsorCategories = new WATS.Entities.SponsorCategories();

                    objSponsorCategories.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objSponsorCategories.SponsorsCount = Convert.ToInt64(dr["SponsorsCount"].ToString());
                    objSponsorCategories.CategoryName = dr["CategoryName"].ToString();
                    lstSponsorCategories.Add(objSponsorCategories);
                }
            }


        }

        public void FEGetListAppInfo(ref Entities.AppInfo objAppInfo, ref List<Entities.News> lstLatestNews, ref int status)
        {
            DataSet ds = _AppInfo.FEGetListAppInfo(ref status);

            //AppInfo List  
            if (ds.Tables[0].Rows.Count != 0)
            {
                if (ds.Tables[0].Rows.Count == 1)
                {
                    objAppInfo.AppInfoId = Convert.ToInt64(ds.Tables[0].Rows[0]["AppInfoId"]);
                    objAppInfo.SiteName = ds.Tables[0].Rows[0]["SiteName"].ToString();
                    objAppInfo.CompanyAddress = ds.Tables[0].Rows[0]["CompanyAddress"].ToString();
                    objAppInfo.CompanyWebSite = ds.Tables[0].Rows[0]["CompanyWebSite"].ToString();
                    objAppInfo.CompanyEmail = ds.Tables[0].Rows[0]["CompanyEmail"].ToString();
                    objAppInfo.CompanyPhone = ds.Tables[0].Rows[0]["CompanyPhone"].ToString();
                    objAppInfo.PresidentPhone = ds.Tables[0].Rows[0]["PresidentPhone"].ToString();
                    objAppInfo.PresidentEmail = ds.Tables[0].Rows[0]["PresidentEmail"].ToString();
                    objAppInfo.SecretaryEmail = ds.Tables[0].Rows[0]["SecretaryEmail"].ToString();
                    objAppInfo.SecretaryPhone = ds.Tables[0].Rows[0]["SecretaryPhone"].ToString();
                    objAppInfo.CustomerCareNumber = ds.Tables[0].Rows[0]["CustomerCareNumber"].ToString();
                    objAppInfo.TollFreeNumber = ds.Tables[0].Rows[0]["TollFreeNumber"].ToString();
                    objAppInfo.FacebookUrl = ds.Tables[0].Rows[0]["FacebookUrl"].ToString();
                    objAppInfo.TwitterUrl = ds.Tables[0].Rows[0]["TwitterUrl"].ToString();
                    objAppInfo.YoutubeUrl = ds.Tables[0].Rows[0]["YoutubeUrl"].ToString();
                    objAppInfo.SupportEmail = ds.Tables[0].Rows[0]["SupportEmail"].ToString();
                    objAppInfo.EnqueryEmail = ds.Tables[0].Rows[0]["EnqueryEmail"].ToString();
                    objAppInfo.PageTitle = ds.Tables[0].Rows[0]["PageTitle"].ToString();
                    objAppInfo.MetaDescription = ds.Tables[0].Rows[0]["MetaDescription"].ToString();
                    objAppInfo.MetaKeywords = ds.Tables[0].Rows[0]["MetaKeywords"].ToString();
                    objAppInfo.Topline = ds.Tables[0].Rows[0]["Topline"].ToString();
                    objAppInfo.PageItems = (ds.Tables[0].Rows[0]["PageItems"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["PageItems"]) : 0);
                    objAppInfo.UpdatedTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedTime"]);
                }
            }

            //LatestNews List
            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    Entities.News objLatestNews = new Entities.News();

                    objLatestNews.NewsId = Convert.ToInt64(dr["NewsId"]);
                    objLatestNews.Title = dr["Title"].ToString();
                    objLatestNews.NewsText = dr["NewsText"].ToString();
                    objLatestNews.ImageUrl = dr["ImageUrl"].ToString();
                    objLatestNews.PostDate = Convert.ToDateTime(dr["PostDate"]);
                    objLatestNews.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt64(dr["OrderNo"]) : 0);
                    objLatestNews.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    lstLatestNews.Add(objLatestNews);
                }
            }
        }

        //public void FEMainLayoutPageList(
        //    ref List<Entities.Sponsors> lstSponsors,
        //    ref List<Entities.Sponsors> lstMediaSponsors,
        //    ref List<Entities.News> lstNews,
        //    ref Entities.AppInfo objAppInfo,
        //    string Email,
        //    ref int _status)
        //{
        //    DataSet ds = new DataSet();
        //    ds = _AppInfo.FEGetListMainLayout(Email, ref _status);

        //    //News List
        //    if (ds.Tables[0].Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[0].Rows)
        //        {
        //            Entities.News objNews = new Entities.News();

        //            objNews.NewsId = Convert.ToInt64(dr["NewsId"]);
        //            objNews.PostDate = Convert.ToDateTime(dr["PostDate"]);
        //            objNews.NewsText = dr["NewsText"].ToString();
        //            objNews.Title = dr["Title"].ToString();
        //            objNews.ImageUrl = dr["ImageUrl"].ToString();

        //            lstNews.Add(objNews);
        //        }
        //    }

        //    // Sponsors List  
        //    if (ds.Tables[1].Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[1].Rows)
        //        {
        //            Entities.Sponsors objHTCASponsors = new Entities.Sponsors();

        //            objHTCASponsors.SponsorId = Convert.ToInt64(dr["SponsorId"]);
        //            objHTCASponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"]);
        //            objHTCASponsors.LogoUrl = dr["LogoUrl"].ToString();
        //            objHTCASponsors.RedirectUrl = dr["RedirectUrl"].ToString();
        //            objHTCASponsors.InsertedTime = Convert.ToDateTime(dr["InsertedTime"]);

        //            lstSponsors.Add(objHTCASponsors);
        //        }
        //    }

        //    // Sponsors List  
        //    if (ds.Tables[2].Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in ds.Tables[2].Rows)
        //        {
        //            Entities.Sponsors objHTCASponsors = new Entities.Sponsors();

        //            objHTCASponsors.SponsorId = Convert.ToInt64(dr["SponsorId"]);
        //            objHTCASponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"]);
        //            objHTCASponsors.LogoUrl = dr["LogoUrl"].ToString();
        //            objHTCASponsors.RedirectUrl = dr["RedirectUrl"].ToString();
        //            objHTCASponsors.InsertedTime = Convert.ToDateTime(dr["InsertedTime"]);

        //            lstMediaSponsors.Add(objHTCASponsors);
        //        }
        //    }


        //    //AppInfo List  
        //    if (ds.Tables[3].Rows.Count != 0)
        //    {
        //        if (ds.Tables[3].Rows.Count == 1)
        //        {
        //            objAppInfo.AppInfoId = Convert.ToInt64(ds.Tables[3].Rows[0]["AppInfoId"]);
        //            objAppInfo.SiteName = ds.Tables[3].Rows[0]["SiteName"].ToString();
        //            objAppInfo.CompanyAddress = ds.Tables[3].Rows[0]["CompanyAddress"].ToString();
        //            objAppInfo.CompanyWebSite = ds.Tables[3].Rows[0]["CompanyWebSite"].ToString();
        //            objAppInfo.CompanyEmail = ds.Tables[3].Rows[0]["CompanyEmail"].ToString();
        //            objAppInfo.CompanyPhone = ds.Tables[3].Rows[0]["CompanyPhone"].ToString();
        //            objAppInfo.PresidentPhone = ds.Tables[3].Rows[0]["PresidentPhone"].ToString();
        //            objAppInfo.PresidentEmail = ds.Tables[3].Rows[0]["PresidentEmail"].ToString();
        //            objAppInfo.SecretaryEmail = ds.Tables[3].Rows[0]["SecretaryEmail"].ToString();
        //            objAppInfo.SecretaryPhone = ds.Tables[3].Rows[0]["SecretaryPhone"].ToString();
        //            objAppInfo.CustomerCareNumber = ds.Tables[3].Rows[0]["CustomerCareNumber"].ToString();
        //            objAppInfo.TollFreeNumber = ds.Tables[3].Rows[0]["TollFreeNumber"].ToString();
        //            objAppInfo.FacebookUrl = ds.Tables[3].Rows[0]["FacebookUrl"].ToString();
        //            objAppInfo.TwitterUrl = ds.Tables[3].Rows[0]["TwitterUrl"].ToString();
        //            objAppInfo.YoutubeUrl = ds.Tables[3].Rows[0]["YoutubeUrl"].ToString();
        //            objAppInfo.SupportEmail = ds.Tables[3].Rows[0]["SupportEmail"].ToString();
        //            objAppInfo.EnqueryEmail = ds.Tables[3].Rows[0]["EnqueryEmail"].ToString();
        //            objAppInfo.PageTitle = ds.Tables[3].Rows[0]["PageTitle"].ToString();
        //            objAppInfo.MetaDescription = ds.Tables[3].Rows[0]["MetaDescription"].ToString();
        //            objAppInfo.MetaKeywords = ds.Tables[3].Rows[0]["MetaKeywords"].ToString();
        //            objAppInfo.Topline = ds.Tables[3].Rows[0]["Topline"].ToString();
        //            objAppInfo.PageItems = (ds.Tables[3].Rows[0]["PageItems"] != DBNull.Value ? Convert.ToInt64(ds.Tables[3].Rows[0]["PageItems"]) : 0);
        //            objAppInfo.UpdatedTime = Convert.ToDateTime(ds.Tables[3].Rows[0]["UpdatedTime"]);
        //        }
        //    }

        //#endregion
        //}


        public Entities.InnerPages FEGetListMainLayout(string Email, ref WATS.Entities.InnerPages objPMInnerPages, ref WATS.Entities.InnerPages objGMInnerPages, ref int status)
        {
            List<WATS.Entities.Sponsors> lstSponsors = new List<WATS.Entities.Sponsors>();
            List<WATS.Entities.Sponsors> lstMediaSponsors = new List<WATS.Entities.Sponsors>();
            List<WATS.Entities.News> lstNews = new List<WATS.Entities.News>();
            WATS.Entities.InnerPages objInnerPages = new WATS.Entities.InnerPages();
            WATS.Entities.Members objMembers = new WATS.Entities.Members();
            //List<Entities.SponsorCategories> lstSponsorCategories = new List<Entities.SponsorCategories>();
            
            List<WATS.Entities.CommitteeCategories> lstCommitteeCategories = new List<WATS.Entities.CommitteeCategories>();
            //List<WATS.Entities.DonationCategories> lstDonationCategories = new List<WATS.Entities.DonationCategories>();

            DataSet ds = _AppInfo.FEGetListMainLayout(Email,ref status);
            if (ds.Tables[0].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    WATS.Entities.Sponsors objSponsors = new WATS.Entities.Sponsors();

                    objSponsors.SponsorId = Convert.ToInt64(dr["SponsorId"].ToString());
                    objSponsors.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objSponsors.LogoUrl = dr["LogoUrl"].ToString();
                    objSponsors.RedirectUrl = (dr["RedirectUrl"] != DBNull.Value ? dr["RedirectUrl"].ToString() : "");
                    //objlstSponsors.DisplayOrder = (dr["DisplayOrder"] != DBNull.Value ? Convert.ToInt64(dr["DisplayOrder"]) : 0);
                    objSponsors.Target = (dr["Target"] != DBNull.Value ? dr["Target"].ToString() : "");


                    lstSponsors.Add(objSponsors);
                }
            }
            objInnerPages.lstSponsors = lstSponsors;

            List<WATS.Entities.SponsorCategories> lstSponsorCategories = new List<WATS.Entities.SponsorCategories>();
            //Sponsor Categories 
            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    WATS.Entities.SponsorCategories objSponsorCategories = new WATS.Entities.SponsorCategories();

                    objSponsorCategories.SponsorCategoryId = Convert.ToInt64(dr["SponsorCategoryId"].ToString());
                    objSponsorCategories.SponsorsCount = Convert.ToInt64(dr["SponsorsCount"].ToString());
                    objSponsorCategories.CategoryName = dr["CategoryName"].ToString();
                    lstSponsorCategories.Add(objSponsorCategories);
                }
            }
            objInnerPages.lstSponsorCategories = lstSponsorCategories;
            
            //News List
            if (ds.Tables[2].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    Entities.News objNews = new Entities.News();

                    objNews.NewsId = Convert.ToInt64(dr["NewsId"]);
                    objNews.PostDate = Convert.ToDateTime(dr["PostDate"]);
                    objNews.NewsText = dr["NewsText"].ToString();
                    objNews.Title = dr["Title"].ToString();
                    objNews.ImageUrl = dr["ImageUrl"].ToString();

                    lstNews.Add(objNews);
                }
            }
            objInnerPages.lstNews = lstNews;

            //Committee Categories 
            if (ds.Tables[3].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    WATS.Entities.CommitteeCategories objCommitteeCategories = new WATS.Entities.CommitteeCategories();

                    objCommitteeCategories.CommitteeCategoryId = Convert.ToInt64(dr["CommitteeCategoryId"].ToString());
                   objCommitteeCategories.CategoryName = dr["CategoryName"].ToString();
                    objCommitteeCategories.Type = dr["Type"].ToString();
                    lstCommitteeCategories.Add(objCommitteeCategories);
                }
            }
            objInnerPages.lstCommitteeCategories = lstCommitteeCategories;

            //President Message
            if (ds.Tables[4].Rows.Count == 1)
            {
                DataTable dt = ds.Tables[4];
                objPMInnerPages.InnerPageId = Convert.ToInt64(dt.Rows[0]["InnerPageId"]);
                objPMInnerPages.Heading = dt.Rows[0]["Heading"].ToString();
                objPMInnerPages.Description = dt.Rows[0]["Description"].ToString();
            }
            //Gallery
            if (ds.Tables[5].Rows.Count == 1)
            {
                DataTable dt = ds.Tables[5];
                objGMInnerPages.InnerPageId = Convert.ToInt64(dt.Rows[0]["InnerPageId"]);
                objGMInnerPages.Heading = dt.Rows[0]["Heading"].ToString();
                objGMInnerPages.Description = dt.Rows[0]["Description"].ToString();
            }
            if (ds.Tables[6].Rows.Count == 1)
            {
                objMembers.MemberId = Convert.ToInt64(ds.Tables[6].Rows[0]["MemberId"]);
                objMembers.UserName = ds.Tables[6].Rows[0]["UserName"].ToString();
                objMembers.Email = ds.Tables[6].Rows[0]["Email"].ToString();
                objMembers.FirstName = ds.Tables[6].Rows[0]["FirstName"].ToString();
                objMembers.LastName = ds.Tables[6].Rows[0]["LastName"].ToString();
                objMembers.ProfileImage = (ds.Tables[6].Rows[0]["ProfileImage"] != DBNull.Value ? ds.Tables[6].Rows[0]["ProfileImage"].ToString() : null);
                objMembers.Occupation = (ds.Tables[6].Rows[0]["Occupation"] != DBNull.Value ? ds.Tables[6].Rows[0]["Occupation"].ToString() : null);
                objMembers.SpouseFirstName = (ds.Tables[6].Rows[0]["SpouseFirstName"] != DBNull.Value ? ds.Tables[6].Rows[0]["SpouseFirstName"].ToString() : null);
                objMembers.SpouseLastName = (ds.Tables[6].Rows[0]["SpouseLastName"] != DBNull.Value ? ds.Tables[6].Rows[0]["SpouseLastName"].ToString() : null);
                objMembers.SpouseOccupation = (ds.Tables[6].Rows[0]["SpouseOccupation"] != DBNull.Value ? ds.Tables[6].Rows[0]["SpouseOccupation"].ToString() : null);
                objMembers.SpouseEmail = (ds.Tables[6].Rows[0]["SpouseEmail"] != DBNull.Value ? ds.Tables[6].Rows[0]["SpouseEmail"].ToString() : null);
                objMembers.SpouseCell = (ds.Tables[6].Rows[0]["SpouseCell"] != DBNull.Value ? ds.Tables[6].Rows[0]["SpouseCell"].ToString() : null);
                objMembers.Address = (ds.Tables[6].Rows[0]["Address"] != DBNull.Value ? ds.Tables[6].Rows[0]["Address"].ToString() : null);
                objMembers.City = (ds.Tables[6].Rows[0]["City"] != DBNull.Value ? ds.Tables[6].Rows[0]["City"].ToString() : null);
                objMembers.State = (ds.Tables[6].Rows[0]["State"] != DBNull.Value ? ds.Tables[6].Rows[0]["State"].ToString() : null);
                objMembers.ZipCode = (ds.Tables[6].Rows[0]["ZipCode"] != DBNull.Value ? ds.Tables[6].Rows[0]["ZipCode"].ToString() : null);
                objMembers.HomePhone = (ds.Tables[6].Rows[0]["HomePhone"] != DBNull.Value ? ds.Tables[6].Rows[0]["HomePhone"].ToString() : null);
                objMembers.MobilePhone = (ds.Tables[6].Rows[0]["MobilePhone"] != DBNull.Value ? ds.Tables[6].Rows[0]["MobilePhone"].ToString() : null);
                objMembers.IsApproved = Convert.ToBoolean(ds.Tables[6].Rows[0]["IsApproved"]);
                objMembers.IsLockedOut = Convert.ToBoolean(ds.Tables[6].Rows[0]["IsLockedOut"]);
                objMembers.IsActivated = Convert.ToBoolean(ds.Tables[6].Rows[0]["IsActivated"]);
                objMembers.DateActivated = (ds.Tables[6].Rows[0]["DateActivated"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[6].Rows[0]["DateActivated"]) : DateTime.MinValue);
                objMembers.MembershipTypeId = Convert.ToInt64(ds.Tables[6].Rows[0]["MembershipTypeId"]);
                objMembers.MembershipType = ds.Tables[6].Rows[0]["MembershipType"].ToString();
                objMembers.IsVolunteer = Convert.ToBoolean(ds.Tables[6].Rows[0]["IsVolunteer"]);
                objMembers.MemberAmount = (ds.Tables[6].Rows[0]["MemberAmount"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[6].Rows[0]["MemberAmount"]) : 0);
                objMembers.IsTeluguorigin = Convert.ToBoolean(ds.Tables[6].Rows[0]["IsTeluguorigin"]);
                objMembers.Comments = (ds.Tables[6].Rows[0]["Comments"] != DBNull.Value ? ds.Tables[6].Rows[0]["Comments"].ToString() : null);
                objMembers.ReferredBy = (ds.Tables[6].Rows[0]["ReferredBy"] != DBNull.Value ? ds.Tables[6].Rows[0]["ReferredBy"].ToString() : null);
                objMembers.MobilePhone = (ds.Tables[6].Rows[0]["MobilePhone"] != DBNull.Value ? ds.Tables[6].Rows[0]["MobilePhone"].ToString() : null);
                objMembers.InsertedTime = Convert.ToDateTime(ds.Tables[6].Rows[0]["InsertedTime"]);
                objMembers.UpdatedTime = Convert.ToDateTime(ds.Tables[6].Rows[0]["UpdatedTime"]);
            }
            objInnerPages.objMembers = objMembers;
            
            return objInnerPages;


        }
        #endregion

    }
      
            
}