using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class Events
    {
        DAL.Events _Events = new DAL.Events();

        public Int64 InsertEvent(Entities.Events objEvents, ref string imageurl)
        {
            Int64 _status = 0;
            if (objEvents != null)
            {
                _status = _Events.InsertEvent(objEvents, ref imageurl);
            }
            return _status;
        }

        public Int64 InsertEventUserInfo(Entities.EventUserInfo objEventUserInfo, ref Int64 EventUserInfoId)
        {
            Int64 _status = 0;
            if (objEventUserInfo != null)
            {
                _status = _Events.InsertEventUserInfo(objEventUserInfo, ref EventUserInfoId);
            }
            return _status;
        }

        public Int64 FEInsertEventUserInfo(Entities.EventUserInfo objEventUserInfo, ref Int64 EventUserInfoId)
        {
            Int64 _status = 0;
            if (objEventUserInfo != null)
            {
                _status = _Events.FEInsertEventUserInfo(objEventUserInfo, ref EventUserInfoId);
            }
            return _status;
        }

        public Int64 InsertCulturalEventUserInfo(Entities.EventUserInfo objEventUserInfo, ref Int64 EventUserInfoId, ref Int64 ChoreographerId, ref string backgroundimgurl, ref string AudioFile)
        {
            Int64 _status = 0;
            if (objEventUserInfo != null)
            {
                _status = _Events.InsertCulturalEventUserInfo(objEventUserInfo, ref EventUserInfoId, ref ChoreographerId, ref backgroundimgurl, ref AudioFile);
            }
            return _status;
        }
        public Int64 UpdateCulturalEventUserInfo(Int64 ChoreographerId, ref string backgroundimgurl, ref string AudioFile,ref Int64 status)
        {
            Int64 _status = 0;
            if (ChoreographerId !=null)
            {
                _status = _Events.UpdateCulturalEventUserInfo(ChoreographerId, ref backgroundimgurl, ref AudioFile,ref status);
            }
            return _status;
        }

        public Int64 UpdateEventUserInfo(Entities.EventUserInfo objEventUserInfo)
        {
            Int64 _status = 0;
            if (objEventUserInfo != null)
            {
                _status = _Events.UpdateEventUserInfo(objEventUserInfo);
            }
            return _status;
        }

        public Int64 InsertEventParticipant(Entities.EventParticipants objEventParticipants)
        {
            Int64 _status = 0;
            if (objEventParticipants != null)
            {
                _status = _Events.InsertEventParticipant(objEventParticipants);
            }
            return _status;
        }

        public Int64 UpdateEventUserInfo(Entities.EventParticipants objEventParticipants)
        {
            Int64 _status = 0;
            if (objEventParticipants != null)
            {
                _status = _Events.UpdateEventParticipant(objEventParticipants);
            }
            return _status;
        }

        public Int64 InsertEventOrderDetail(Entities.EventOrderDetails objEventOrderDetails)
        {
            Int64 _status = 0;
            if (objEventOrderDetails != null)
            {
                _status = _Events.InsertEventOrderDetail(objEventOrderDetails);
            }
            return _status;
        }

        public Int64 UpdateEventOrderDetail(Entities.EventOrderDetails objUpdateEventOrderDetail)
        {
            Int64 _status = 0;
            if (objUpdateEventOrderDetail != null)
            {
                _status = _Events.UpdateEventOrderDetail(objUpdateEventOrderDetail);
            }
            return _status;
        }

        public Entities.Events GetEventById(Int64 EventId, string EventName, ref int status)
        {
            DataTable dt = _Events.GetEventById(EventId, EventName, ref status);
            Entities.Events objEvent = new Entities.Events();

            if (dt.Rows.Count == 1)
            {
                objEvent.EventId = Convert.ToInt64(dt.Rows[0]["EventId"]);
                objEvent.BannerUrl = (dt.Rows[0]["BannerUrl"] != DBNull.Value ? dt.Rows[0]["BannerUrl"].ToString() : null);
                objEvent.City = (dt.Rows[0]["City"] != DBNull.Value ? dt.Rows[0]["City"].ToString() : null);
                objEvent.ContactEmail = (dt.Rows[0]["ContactEmail"] != DBNull.Value ? dt.Rows[0]["ContactEmail"].ToString() : null);
                objEvent.EndDate = (dt.Rows[0]["EndDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["EndDate"]) : DateTime.MinValue);
                objEvent.EventCategoryId = (dt.Rows[0]["EventCategoryId"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["EventCategoryId"]) : 0);
                objEvent.SponsorsCount = (dt.Rows[0]["SponsorsCount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["SponsorsCount"]) : 0);
                objEvent.EventCategory = (dt.Rows[0]["EventCategory"] != DBNull.Value ? dt.Rows[0]["EventCategory"].ToString() : null);
                objEvent.EventDetails = (dt.Rows[0]["EventDetails"] != DBNull.Value ? dt.Rows[0]["EventDetails"].ToString() : null);
                objEvent.EventName = dt.Rows[0]["EventName"].ToString();
                objEvent.IsRegistration = (dt.Rows[0]["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsRegistration"]) : false);
                objEvent.Location = (dt.Rows[0]["Location"] != DBNull.Value ? dt.Rows[0]["Location"].ToString() : null);
                objEvent.MemberCount = (dt.Rows[0]["MemberCount"] != DBNull.Value ? Convert.ToInt32(dt.Rows[0]["MemberCount"]) : 0);
                objEvent.IsChild = (dt.Rows[0]["IsChild"] != DBNull.Value ?Convert.ToBoolean(dt.Rows[0]["IsChild"].ToString()) : false);
                objEvent.ChildAmount = (dt.Rows[0]["ChildAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["ChildAmount"]) : 0);
                objEvent.NonChildAmount = (dt.Rows[0]["NonChildAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonChildAmount"]) : 0);
                objEvent.IsAdult = (dt.Rows[0]["IsAdult"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsAdult"].ToString()) : false);
                objEvent.AdultAmount = (dt.Rows[0]["AdultAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["AdultAmount"]) : 0);
                objEvent.NonAdultAmount = (dt.Rows[0]["NonAdultAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonAdultAmount"]) : 0);
                objEvent.IsCouple = (dt.Rows[0]["IsCouple"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsCouple"].ToString()) : false);
                objEvent.CoupleAmount = (dt.Rows[0]["CoupleAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["CoupleAmount"]) : 0);
                objEvent.NonCoupleAmount = (dt.Rows[0]["NonCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonCoupleAmount"]) : 0);
                objEvent.IsFamily = (dt.Rows[0]["IsFamily"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsFamily"].ToString()) : false);
                objEvent.FamilyAmount = (dt.Rows[0]["FamilyAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["FamilyAmount"]) : 0);
                objEvent.NonFamilyAmount = (dt.Rows[0]["NonFamilyAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonFamilyAmount"]) : 0);
                objEvent.IsVIP = (dt.Rows[0]["IsVIP"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsVIP"].ToString()) : false);
                objEvent.VIPAmount = (dt.Rows[0]["VIPAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["VIPAmount"]) : 0);
                objEvent.NonVIPAmount = (dt.Rows[0]["NonVIPAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonVIPAmount"]) : 0);
                objEvent.IsVIPChild = (dt.Rows[0]["IsVIPChild"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsVIPChild"].ToString()) : false);
                objEvent.VIPChildAmount = (dt.Rows[0]["VIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["VIPChildAmount"]) : 0);
                objEvent.NonVIPChildAmount = (dt.Rows[0]["NonVIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonVIPChildAmount"]) : 0);
                objEvent.IsVIPSingleAdult = (dt.Rows[0]["IsVIPSingleAdult"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsVIPSingleAdult"].ToString()) : false);
                objEvent.VIPSingleAdultAmount = (dt.Rows[0]["VIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["VIPSingleAdultAmount"]) : 0);
                objEvent.NonVIPSingleAdultAmount = (dt.Rows[0]["NonVIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonVIPSingleAdultAmount"]) : 0);
                objEvent.IsVIPCouple = (dt.Rows[0]["IsVIPCouple"] != DBNull.Value ? Convert.ToBoolean(dt.Rows[0]["IsVIPCouple"].ToString()) : false);
                objEvent.VIPCoupleAmount = (dt.Rows[0]["VIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["VIPCoupleAmount"]) : 0);
                objEvent.NonVIPCoupleAmount = (dt.Rows[0]["NonVIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dt.Rows[0]["NonVIPCoupleAmount"]) : 0);
                objEvent.RegistrationEndDate = (dt.Rows[0]["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["RegistrationEndDate"]) : DateTime.MinValue);
                objEvent.RegistrationStartDate = (dt.Rows[0]["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["RegistrationStartDate"]) : DateTime.MinValue);
                objEvent.StartDate = (dt.Rows[0]["StartDate"] != DBNull.Value ? Convert.ToDateTime(dt.Rows[0]["StartDate"]) : DateTime.MinValue);
                objEvent.StateName = (dt.Rows[0]["StateName"] != DBNull.Value ? dt.Rows[0]["StateName"].ToString() : null);
                objEvent.ZipCode = (dt.Rows[0]["ZipCode"] != DBNull.Value ? dt.Rows[0]["ZipCode"].ToString() : null);
                objEvent.TopLine = (dt.Rows[0]["TopLine"] != DBNull.Value ? dt.Rows[0]["TopLine"].ToString() : null);
                objEvent.PageTitle = (dt.Rows[0]["PageTitle"] != DBNull.Value ? dt.Rows[0]["PageTitle"].ToString() : null);
                objEvent.MetaKeywords = (dt.Rows[0]["MetaKeywords"] != DBNull.Value ? dt.Rows[0]["MetaKeywords"].ToString() : null);
                objEvent.MetaDescription = (dt.Rows[0]["MetaDescription"] != DBNull.Value ? dt.Rows[0]["MetaDescription"].ToString() : null);
                objEvent.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"]);
                objEvent.Guidlines = (dt.Rows[0]["Guidlines"] != DBNull.Value ? dt.Rows[0]["Guidlines"].ToString() : null);
                objEvent.RegistrationNotes = (dt.Rows[0]["RegistrationNotes"] != DBNull.Value ? dt.Rows[0]["RegistrationNotes"].ToString() : null);
            }

            return objEvent;
        }

        public Entities.Events AdminGetEventById(Int64 EventId, string EventName, ref List<Entities.EventRegistrationTypes> lstEventRegistrationTypes, ref int status)
        {
            DataSet ds = _Events.AdminGetEventById(EventId, EventName, ref status);
            Entities.Events objEvent = new Entities.Events();

            if (ds.Tables[0].Rows.Count == 1)
            {
                objEvent.EventId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventId"]);
                objEvent.BannerUrl = (ds.Tables[0].Rows[0]["BannerUrl"] != DBNull.Value ? ds.Tables[0].Rows[0]["BannerUrl"].ToString() : null);
                objEvent.City = (ds.Tables[0].Rows[0]["City"] != DBNull.Value ? ds.Tables[0].Rows[0]["City"].ToString() : null);
                objEvent.ContactEmail = (ds.Tables[0].Rows[0]["ContactEmail"] != DBNull.Value ? ds.Tables[0].Rows[0]["ContactEmail"].ToString() : null);
                objEvent.EndDate = (ds.Tables[0].Rows[0]["EndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]) : DateTime.MinValue);
                objEvent.EventCategoryId = (ds.Tables[0].Rows[0]["EventCategoryId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["EventCategoryId"]) : 0);
                objEvent.SponsorsCount = (ds.Tables[0].Rows[0]["SponsorsCount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["SponsorsCount"]) : 0);
                objEvent.EventCategory = (ds.Tables[0].Rows[0]["EventCategory"] != DBNull.Value ? ds.Tables[0].Rows[0]["EventCategory"].ToString() : null);
                objEvent.EventDetails = (ds.Tables[0].Rows[0]["EventDetails"] != DBNull.Value ? ds.Tables[0].Rows[0]["EventDetails"].ToString() : null);
                objEvent.EventName = ds.Tables[0].Rows[0]["EventName"].ToString();
                objEvent.IsRegistration = (ds.Tables[0].Rows[0]["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRegistration"]) : false);
                objEvent.Location = (ds.Tables[0].Rows[0]["Location"] != DBNull.Value ? ds.Tables[0].Rows[0]["Location"].ToString() : null);
                objEvent.MemberCount = (ds.Tables[0].Rows[0]["MemberCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[0]["MemberCount"]) : 0);
                objEvent.IsChild = (ds.Tables[0].Rows[0]["IsChild"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsChild"].ToString()) : false);
                objEvent.ChildAmount = (ds.Tables[0].Rows[0]["ChildAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["ChildAmount"]) : 0);
                objEvent.NonChildAmount = (ds.Tables[0].Rows[0]["NonChildAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonChildAmount"]) : 0);
                objEvent.IsAdult = (ds.Tables[0].Rows[0]["IsAdult"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsAdult"].ToString()) : false);
                objEvent.AdultAmount = (ds.Tables[0].Rows[0]["AdultAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["AdultAmount"]) : 0);
                objEvent.NonAdultAmount = (ds.Tables[0].Rows[0]["NonAdultAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonAdultAmount"]) : 0);
                objEvent.IsCouple = (ds.Tables[0].Rows[0]["IsCouple"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsCouple"].ToString()) : false);
                objEvent.CoupleAmount = (ds.Tables[0].Rows[0]["CoupleAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["CoupleAmount"]) : 0);
                objEvent.NonCoupleAmount = (ds.Tables[0].Rows[0]["NonCoupleAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonCoupleAmount"]) : 0);
                objEvent.IsFamily = (ds.Tables[0].Rows[0]["IsFamily"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsFamily"].ToString()) : false);
                objEvent.FamilyAmount = (ds.Tables[0].Rows[0]["FamilyAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["FamilyAmount"]) : 0);
                objEvent.NonFamilyAmount = (ds.Tables[0].Rows[0]["NonFamilyAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonFamilyAmount"]) : 0);
                objEvent.IsVIP = (ds.Tables[0].Rows[0]["IsVIP"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsVIP"].ToString()) : false);
                objEvent.VIPAmount = (ds.Tables[0].Rows[0]["VIPAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["VIPAmount"]) : 0);
                objEvent.NonVIPAmount = (ds.Tables[0].Rows[0]["NonVIPAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonVIPAmount"]) : 0);
                objEvent.IsVIPChild = (ds.Tables[0].Rows[0]["IsVIPChild"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsVIPChild"].ToString()) : false);
                objEvent.VIPChildAmount = (ds.Tables[0].Rows[0]["VIPChildAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["VIPChildAmount"]) : 0);
                objEvent.NonVIPChildAmount = (ds.Tables[0].Rows[0]["NonVIPChildAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonVIPChildAmount"]) : 0);
                objEvent.IsVIPSingleAdult = (ds.Tables[0].Rows[0]["IsVIPSingleAdult"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsVIPSingleAdult"].ToString()) : false);
                objEvent.VIPSingleAdultAmount = (ds.Tables[0].Rows[0]["VIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["VIPSingleAdultAmount"]) : 0);
                objEvent.NonVIPSingleAdultAmount = (ds.Tables[0].Rows[0]["NonVIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonVIPSingleAdultAmount"]) : 0);
                objEvent.IsVIPCouple = (ds.Tables[0].Rows[0]["IsVIPCouple"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsVIPCouple"].ToString()) : false);
                objEvent.VIPCoupleAmount = (ds.Tables[0].Rows[0]["VIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["VIPCoupleAmount"]) : 0);
                objEvent.NonVIPCoupleAmount = (ds.Tables[0].Rows[0]["NonVIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["NonVIPCoupleAmount"]) : 0);
                objEvent.RegistrationEndDate = (ds.Tables[0].Rows[0]["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationEndDate"]) : DateTime.MinValue);
                objEvent.RegistrationStartDate = (ds.Tables[0].Rows[0]["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationStartDate"]) : DateTime.MinValue);
                objEvent.StartDate = (ds.Tables[0].Rows[0]["StartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]) : DateTime.MinValue);
                objEvent.StateName = (ds.Tables[0].Rows[0]["StateName"] != DBNull.Value ? ds.Tables[0].Rows[0]["StateName"].ToString() : null);
                objEvent.ZipCode = (ds.Tables[0].Rows[0]["ZipCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["ZipCode"].ToString() : null);
                objEvent.TopLine = (ds.Tables[0].Rows[0]["TopLine"] != DBNull.Value ? ds.Tables[0].Rows[0]["TopLine"].ToString() : null);
                objEvent.PageTitle = (ds.Tables[0].Rows[0]["PageTitle"] != DBNull.Value ? ds.Tables[0].Rows[0]["PageTitle"].ToString() : null);
                objEvent.MetaKeywords = (ds.Tables[0].Rows[0]["MetaKeywords"] != DBNull.Value ? ds.Tables[0].Rows[0]["MetaKeywords"].ToString() : null);
                objEvent.MetaDescription = (ds.Tables[0].Rows[0]["MetaDescription"] != DBNull.Value ? ds.Tables[0].Rows[0]["MetaDescription"].ToString() : null);
                objEvent.UpdatedTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedTime"]);
                objEvent.Guidlines = (ds.Tables[0].Rows[0]["Guidlines"] != DBNull.Value ? ds.Tables[0].Rows[0]["Guidlines"].ToString() : null);
                objEvent.RegistrationNotes = (ds.Tables[0].Rows[0]["RegistrationNotes"] != DBNull.Value ? ds.Tables[0].Rows[0]["RegistrationNotes"].ToString() : null);
            }

            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    WATS.Entities.EventRegistrationTypes objEventRegistrationTypes = new WATS.Entities.EventRegistrationTypes();

                    objEventRegistrationTypes.EventRegistrationTypeId = Convert.ToInt64(dr["EventRegistrationTypeId"].ToString());
                    objEventRegistrationTypes.EventId = Convert.ToInt64(dr["EventId"].ToString());
                    objEventRegistrationTypes.RegistrationTitle = dr["RegistrationTitle"].ToString();
                    objEventRegistrationTypes.RegCount = (dr["RegCount"] != DBNull.Value ? Convert.ToInt64(dr["RegCount"].ToString()) : 0);
                    objEventRegistrationTypes.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"].ToString()) : 0);
                    objEventRegistrationTypes.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                    objEventRegistrationTypes.MemberAmount = (dr["MemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["MemberAmount"].ToString()) : 0);
                    objEventRegistrationTypes.NonMemberAmount = (dr["NonMemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["NonMemberAmount"].ToString()) : 0);

                    lstEventRegistrationTypes.Add(objEventRegistrationTypes);
                }
            }

            return objEvent;
        }

        public Entities.Events FEGetEventById(Int64 EventId, string EventName, ref List<Entities.EventRegistrationTypes> lstEventRegistrationTypes, ref List<Entities.RegistrationCategories> lstEventRegistrationCategories, ref int status)
        {
            DataSet ds = _Events.FEGetEventById(EventId, EventName, ref status);
            Entities.Events objEvent = new Entities.Events();

            if (ds.Tables[0].Rows.Count == 1)
            {
                objEvent.EventId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventId"]);
                objEvent.BannerUrl = (ds.Tables[0].Rows[0]["BannerUrl"] != DBNull.Value ? ds.Tables[0].Rows[0]["BannerUrl"].ToString() : null);
                objEvent.City = (ds.Tables[0].Rows[0]["City"] != DBNull.Value ? ds.Tables[0].Rows[0]["City"].ToString() : null);
                objEvent.ContactEmail = (ds.Tables[0].Rows[0]["ContactEmail"] != DBNull.Value ? ds.Tables[0].Rows[0]["ContactEmail"].ToString() : null);
                objEvent.EndDate = (ds.Tables[0].Rows[0]["EndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]) : DateTime.MinValue);
                objEvent.EventCategoryId = (ds.Tables[0].Rows[0]["EventCategoryId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["EventCategoryId"]) : 0);
                objEvent.EventCategory = (ds.Tables[0].Rows[0]["EventCategory"] != DBNull.Value ? ds.Tables[0].Rows[0]["EventCategory"].ToString() : null);
                objEvent.EventDetails = (ds.Tables[0].Rows[0]["EventDetails"] != DBNull.Value ? ds.Tables[0].Rows[0]["EventDetails"].ToString() : null);
                objEvent.EventName = ds.Tables[0].Rows[0]["EventName"].ToString();
                objEvent.IsRegistration = (ds.Tables[0].Rows[0]["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRegistration"]) : false); 
                objEvent.Location = (ds.Tables[0].Rows[0]["Location"] != DBNull.Value ? ds.Tables[0].Rows[0]["Location"].ToString() : null);
                objEvent.MemberCount = (ds.Tables[0].Rows[0]["MemberCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[0]["MemberCount"]) : 0);
                objEvent.RegistrationEndDate = (ds.Tables[0].Rows[0]["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationEndDate"]) : DateTime.MinValue);
                objEvent.RegistrationStartDate = (ds.Tables[0].Rows[0]["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationStartDate"]) : DateTime.MinValue);
                objEvent.StartDate = (ds.Tables[0].Rows[0]["StartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]) : DateTime.MinValue);
                objEvent.EndDate = (ds.Tables[0].Rows[0]["EndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]) : DateTime.MinValue);
                objEvent.StateName = (ds.Tables[0].Rows[0]["StateName"] != DBNull.Value ? ds.Tables[0].Rows[0]["StateName"].ToString() : null);
                objEvent.ZipCode = (ds.Tables[0].Rows[0]["ZipCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["ZipCode"].ToString() : null);
                objEvent.TopLine = (ds.Tables[0].Rows[0]["TopLine"] != DBNull.Value ? ds.Tables[0].Rows[0]["TopLine"].ToString() : null);
                objEvent.PageTitle = (ds.Tables[0].Rows[0]["PageTitle"] != DBNull.Value ? ds.Tables[0].Rows[0]["PageTitle"].ToString() : null);
                objEvent.MetaKeywords = (ds.Tables[0].Rows[0]["MetaKeywords"] != DBNull.Value ? ds.Tables[0].Rows[0]["MetaKeywords"].ToString() : null);
                objEvent.MetaDescription = (ds.Tables[0].Rows[0]["MetaDescription"] != DBNull.Value ? ds.Tables[0].Rows[0]["MetaDescription"].ToString() : null);
                objEvent.UpdatedTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedTime"]);
                objEvent.SponsorsCount = (ds.Tables[0].Rows[0]["SponsorsCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[0]["SponsorsCount"]) : 0);
                //objEvent.IsFood = (ds.Tables[0].Rows[0]["IsFood"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsFood"]) : false);
            }

            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    WATS.Entities.EventRegistrationTypes objEventRegistrationTypes = new WATS.Entities.EventRegistrationTypes();
                    objEventRegistrationTypes.EventRegistrationTypeId = Convert.ToInt64(dr["EventRegistrationTypeId"].ToString());
                    objEventRegistrationTypes.EventId = Convert.ToInt64(dr["EventId"].ToString());
                    objEventRegistrationTypes.RegistrationTitle = dr["RegistrationTitle"].ToString();
                    objEventRegistrationTypes.RegCount = (dr["RegCount"] != DBNull.Value ? Convert.ToInt64(dr["RegCount"].ToString()) : 0);
                    objEventRegistrationTypes.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"].ToString()) : 0);
                    objEventRegistrationTypes.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                    objEventRegistrationTypes.MemberAmount = (dr["MemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["MemberAmount"].ToString()) : 0);
                    objEventRegistrationTypes.NonMemberAmount = (dr["NonMemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["NonMemberAmount"].ToString()) : 0);

                    lstEventRegistrationTypes.Add(objEventRegistrationTypes);
                }
            }

            if (ds.Tables[2].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[2].Rows)
                {
                    WATS.Entities.RegistrationCategories objEventRegistrationCategories = new WATS.Entities.RegistrationCategories();

                    objEventRegistrationCategories.RegistrationCategoryId = Convert.ToInt64(dr["RegistrationCategoryId"].ToString());
                    objEventRegistrationCategories.MemberAmount = (dr["MemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["MemberAmount"].ToString()) : 0);
                    objEventRegistrationCategories.NAmount = (dr["NAmount"] != DBNull.Value ? Convert.ToDecimal(dr["NAmount"].ToString()) : 0);
                    objEventRegistrationCategories.CategoryName = (dr["CategoryName"] != DBNull.Value ? dr["CategoryName"].ToString() : null);

                    lstEventRegistrationCategories.Add(objEventRegistrationCategories);
                }
            }

            return objEvent;
        }

        public Int64 DeleteEventById(Int64 EventId)
        {
            Int64 _status = 0;
            _status = _Events.DeleteEventById(EventId);
            return _status;
        }

        public List<WATS.Entities.Events> GetEventsListByVariable(Int64 EventStatusId, string EventType, string StartDate, string EndDate, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.Events> lstEvents = new List<WATS.Entities.Events>();
            DataTable dt = _Events.GetEventsListByVariable(EventStatusId, EventType, StartDate, EndDate, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Events.GetEventsListByVariable(EventStatusId, EventType, StartDate, EndDate, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Events objEvent = new WATS.Entities.Events();

                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventName = dr["EventName"].ToString();
                    objEvent.StartDate = (dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]) : DateTime.MinValue);
                    objEvent.EndDate = (dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]) : DateTime.MinValue);
                    objEvent.RegistrationStartDate = (dr["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationStartDate"]) : DateTime.MinValue);
                    objEvent.RegistrationEndDate = (dr["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationEndDate"]) : DateTime.MinValue);
                    objEvent.BannerUrl = (dr["BannerUrl"] != DBNull.Value ? dr["BannerUrl"].ToString() : null);
                    objEvent.EventCategoryId = (dr["EventCategoryId"] != DBNull.Value ?Convert.ToInt64(dr["EventCategoryId"].ToString()) : 0);
                    objEvent.MemberCount = (dr["MemberCount"] != DBNull.Value ? Convert.ToInt32(dr["MemberCount"]) : 0);
                    objEvent.Location = (dr["Location"] != DBNull.Value ? dr["Location"].ToString() : null);
                    objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objEvent.StateName = (dr["StateName"] != DBNull.Value ? dr["StateName"].ToString() : null);
                    objEvent.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : null);
                    objEvent.EventDetails = (dr["EventDetails"] != DBNull.Value ? dr["EventDetails"].ToString() : null);
                    objEvent.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objEvent.IsRegistration = (dr["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(dr["IsRegistration"]) : false);
                    objEvent.EventCategory = (dr["EventCategory"] != DBNull.Value ? dr["EventCategory"].ToString() : null);
                    objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
                    objEvent.RId = Convert.ToInt64(dr["RId"]);

                    lstEvents.Add(objEvent);
                }
            }
            return lstEvents;
        }

        public List<WATS.Entities.Events> GetEventsList(string Type, ref int status)
        {
            List<WATS.Entities.Events> lstEvents = new List<Entities.Events>();
            DataTable dt = _Events.GetEventsList(Type, ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Events objEvent = new WATS.Entities.Events();

                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);
                    objEvent.StartDate = (dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]) : DateTime.MinValue);
                    objEvent.EndDate = (dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]) : DateTime.MinValue);
                    objEvent.RegistrationStartDate = (dr["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationStartDate"]) : DateTime.MinValue);
                    objEvent.RegistrationEndDate = (dr["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationEndDate"]) : DateTime.MinValue);
                    objEvent.BannerUrl = (dr["BannerUrl"] != DBNull.Value ? dr["BannerUrl"].ToString() : null);
                    objEvent.EventCategoryId = (dr["EventCategoryId"] != DBNull.Value ? Convert.ToInt32(dr["EventCategoryId"]) : 0);
                    objEvent.MemberCount = (dr["MemberCount"] != DBNull.Value ? Convert.ToInt32(dr["MemberCount"]) : 0);
                    objEvent.Location = (dr["Location"] != DBNull.Value ? dr["Location"].ToString() : null);
                    objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objEvent.StateName = (dr["StateName"] != DBNull.Value ? dr["StateName"].ToString() : null);
                    objEvent.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : null);
                    objEvent.EventDetails = (dr["EventDetails"] != DBNull.Value ? dr["EventDetails"].ToString() : null);
                    objEvent.IsRegistration = (dr["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(dr["IsRegistration"].ToString()) : false);
                    objEvent.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objEvent.EventCategory = (dr["EventCategory"] != DBNull.Value ? dr["EventCategory"].ToString() : null);
                    objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    objEvent.IsChild = (dr["IsChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsChild"].ToString()) : false);
                    objEvent.ChildAmount = (dr["ChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["ChildAmount"]) : 0);
                    objEvent.NonChildAmount = (dr["NonChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonChildAmount"]) : 0);
                    objEvent.IsAdult = (dr["IsAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsAdult"].ToString()) : false);
                    objEvent.AdultAmount = (dr["AdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["AdultAmount"]) : 0);
                    objEvent.NonAdultAmount = (dr["NonAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonAdultAmount"]) : 0);
                    objEvent.IsCouple = (dr["IsCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsCouple"].ToString()) : false);
                    objEvent.CoupleAmount = (dr["CoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["CoupleAmount"]) : 0);
                    objEvent.NonCoupleAmount = (dr["NonCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonCoupleAmount"]) : 0);
                    objEvent.IsFamily = (dr["IsFamily"] != DBNull.Value ? Convert.ToBoolean(dr["IsFamily"].ToString()) : false);
                    objEvent.FamilyAmount = (dr["FamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["FamilyAmount"]) : 0);
                    objEvent.NonFamilyAmount = (dr["NonFamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonFamilyAmount"]) : 0);
                    objEvent.IsVIP = (dr["IsVIP"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIP"].ToString()) : false);
                    objEvent.VIPAmount = (dr["VIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPAmount"]) : 0);
                    objEvent.NonVIPAmount = (dr["NonVIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPAmount"]) : 0);
                    objEvent.IsVIPChild = (dr["IsVIPChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPChild"].ToString()) : false);
                    objEvent.VIPChildAmount = (dr["VIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPChildAmount"]) : 0);
                    objEvent.NonVIPChildAmount = (dr["NonVIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPChildAmount"]) : 0);
                    objEvent.IsVIPSingleAdult = (dr["IsVIPSingleAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPSingleAdult"].ToString()) : false);
                    objEvent.VIPSingleAdultAmount = (dr["VIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPSingleAdultAmount"]) : 0);
                    objEvent.NonVIPSingleAdultAmount = (dr["NonVIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPSingleAdultAmount"]) : 0);
                    objEvent.IsVIPCouple = (dr["IsVIPCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPCouple"].ToString()) : false);
                    objEvent.VIPCoupleAmount = (dr["VIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPCoupleAmount"]) : 0);
                    objEvent.NonVIPCoupleAmount = (dr["NonVIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPCoupleAmount"]) : 0);

                    lstEvents.Add(objEvent);
                }

            }
            return lstEvents;
        }

        public List<WATS.Entities.Events> GetAllEventsList(string Type, ref int status)
        {
            List<WATS.Entities.Events> lstEvents = new List<Entities.Events>();
            DataTable dt = _Events.GetEventsList(Type, ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Events objEvent = new WATS.Entities.Events();

                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);
                    objEvent.StartDate = (dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]) : DateTime.MinValue);
                    objEvent.EndDate = (dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]) : DateTime.MinValue);
                    objEvent.RegistrationStartDate = (dr["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationStartDate"]) : DateTime.MinValue);
                    objEvent.RegistrationEndDate = (dr["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationEndDate"]) : DateTime.MinValue);
                    objEvent.BannerUrl = (dr["BannerUrl"] != DBNull.Value ? dr["BannerUrl"].ToString() : null);
                    objEvent.EventCategoryId = (dr["EventCategoryId"] != DBNull.Value ? Convert.ToInt32(dr["EventCategoryId"]) : 0);
                    objEvent.MemberCount = (dr["MemberCount"] != DBNull.Value ? Convert.ToInt32(dr["MemberCount"]) : 0);
                    objEvent.Location = (dr["Location"] != DBNull.Value ? dr["Location"].ToString() : null);
                    objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objEvent.StateName = (dr["StateName"] != DBNull.Value ? dr["StateName"].ToString() : null);
                    objEvent.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : null);
                    objEvent.EventDetails = (dr["EventDetails"] != DBNull.Value ? dr["EventDetails"].ToString() : null);
                    objEvent.IsRegistration = (dr["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(dr["IsRegistration"].ToString()) : false);
                    objEvent.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objEvent.EventCategory = (dr["EventCategory"] != DBNull.Value ? dr["EventCategory"].ToString() : null);
                    objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    objEvent.IsChild = (dr["IsChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsChild"].ToString()) : false);
                    objEvent.ChildAmount = (dr["ChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["ChildAmount"]) : 0);
                    objEvent.NonChildAmount = (dr["NonChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonChildAmount"]) : 0);
                    objEvent.IsAdult = (dr["IsAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsAdult"].ToString()) : false);
                    objEvent.AdultAmount = (dr["AdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["AdultAmount"]) : 0);
                    objEvent.NonAdultAmount = (dr["NonAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonAdultAmount"]) : 0);
                    objEvent.IsCouple = (dr["IsCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsCouple"].ToString()) : false);
                    objEvent.CoupleAmount = (dr["CoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["CoupleAmount"]) : 0);
                    objEvent.NonCoupleAmount = (dr["NonCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonCoupleAmount"]) : 0);
                    objEvent.IsFamily = (dr["IsFamily"] != DBNull.Value ? Convert.ToBoolean(dr["IsFamily"].ToString()) : false);
                    objEvent.FamilyAmount = (dr["FamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["FamilyAmount"]) : 0);
                    objEvent.NonFamilyAmount = (dr["NonFamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonFamilyAmount"]) : 0);
                    objEvent.IsVIP = (dr["IsVIP"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIP"].ToString()) : false);
                    objEvent.VIPAmount = (dr["VIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPAmount"]) : 0);
                    objEvent.NonVIPAmount = (dr["NonVIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPAmount"]) : 0);
                    objEvent.IsVIPChild = (dr["IsVIPChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPChild"].ToString()) : false);
                    objEvent.VIPChildAmount = (dr["VIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPChildAmount"]) : 0);
                    objEvent.NonVIPChildAmount = (dr["NonVIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPChildAmount"]) : 0);
                    objEvent.IsVIPSingleAdult = (dr["IsVIPSingleAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPSingleAdult"].ToString()) : false);
                    objEvent.VIPSingleAdultAmount = (dr["VIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPSingleAdultAmount"]) : 0);
                    objEvent.NonVIPSingleAdultAmount = (dr["NonVIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPSingleAdultAmount"]) : 0);
                    objEvent.IsVIPCouple = (dr["IsVIPCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPCouple"].ToString()) : false);
                    objEvent.VIPCoupleAmount = (dr["VIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPCoupleAmount"]) : 0);
                    objEvent.NonVIPCoupleAmount = (dr["NonVIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPCoupleAmount"]) : 0);

                    lstEvents.Add(objEvent);
                }

            }
            return lstEvents;
        }

        public List<WATS.Entities.Events> SGetEventsList(ref int status)
        {
            List<WATS.Entities.Events> lstEvents = new List<Entities.Events>();
            DataTable dt = _Events.SponsorsGetEventsList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Events objEvent = new WATS.Entities.Events();

                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);
                    

                    lstEvents.Add(objEvent);
                }

            }
            return lstEvents;
        }

        public Int64 UpdateEventStatus(Int64 EventId)
        {
            Int64 _status = 0;
            _status = _Events.UpdateEventStatus(EventId);
            return _status;
        } 

        #region EventUserInfo

        public Int64 DeleteEventUserInfoById(Int64 EventUserInfoId)
        {
            Int64 _status = 0;
            _status = _Events.DeleteEventUserInfoById(EventUserInfoId);
            return _status;
        }

        public Entities.EventUserInfo GetEventUserInfoById(Int64 EventUserInfoGetById, ref int status)
        {
            DataTable dt = _Events.GetEventUserInfoById(EventUserInfoGetById, ref status);
            Entities.EventUserInfo objEventUserInfo = new Entities.EventUserInfo();

            if (dt.Rows.Count == 1)
            {

                objEventUserInfo.EventId = Convert.ToInt64(dt.Rows[0]["EventId"]);
                objEventUserInfo.EventName = dt.Rows[0]["EventName"].ToString();
                objEventUserInfo.EventUserInfoId = Convert.ToInt64(dt.Rows[0]["EventUserInfoId"]);
                objEventUserInfo.LastName = dt.Rows[0]["LastName"].ToString();
                objEventUserInfo.EventCategoryId = Convert.ToInt64(dt.Rows[0]["EventCategoryId"]);
                objEventUserInfo.EventCategory = dt.Rows[0]["EventCategory"].ToString();
                objEventUserInfo.FirstName = dt.Rows[0]["FirstName"].ToString();
                objEventUserInfo.Email = dt.Rows[0]["Email"].ToString();
                objEventUserInfo.Gender = (dt.Rows[0]["Gender"] != DBNull.Value ? dt.Rows[0]["Gender"].ToString() : null);
                objEventUserInfo.Address = (dt.Rows[0]["Address"] != DBNull.Value ? dt.Rows[0]["Address"].ToString() : null);
                objEventUserInfo.City = (dt.Rows[0]["City"] != DBNull.Value ? dt.Rows[0]["City"].ToString() : null);
                objEventUserInfo.State = (dt.Rows[0]["State"] != DBNull.Value ? dt.Rows[0]["State"].ToString() : null);
                objEventUserInfo.Mobile = (dt.Rows[0]["Mobile"] != DBNull.Value ? dt.Rows[0]["Mobile"].ToString() : null);
                objEventUserInfo.ItemName = dt.Rows[0]["ItemName"].ToString();
                objEventUserInfo.ItemCategory = dt.Rows[0]["ItemCategory"].ToString();
                objEventUserInfo.ItemDescription = dt.Rows[0]["ItemDescription"].ToString();
                objEventUserInfo.ItemDuration = (dt.Rows[0]["ItemDuration"] != DBNull.Value ?Convert.ToInt32(dt.Rows[0]["ItemDuration"].ToString()) : 0);
                objEventUserInfo.IsApproved =Convert.ToBoolean(dt.Rows[0]["IsApproved"]);
                objEventUserInfo.DocumentUrl = (dt.Rows[0]["DocumentUrl"] != DBNull.Value ? dt.Rows[0]["DocumentUrl"].ToString() : null);
                objEventUserInfo.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                objEventUserInfo.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"]);
            }

            return objEventUserInfo;
        }

        public Entities.EventUserInfo GetEventUserInfoFullDetailsById(Int64 EventUserInfoGetById, Int64 EventId, ref Entities.Events objEvent, ref List<Entities.EventRegistrationCounts> lstEventRegistrationCounts, ref List<Entities.EventsTickets> lstEventsTickets, ref int status)
        {
            DataSet ds = _Events.GetEventUserInfoFullDetailsById(EventUserInfoGetById, EventId, ref status);
            Entities.EventUserInfo objEventUserInfo = new Entities.EventUserInfo();
            List<Entities.EventParticipants> lstEventParticipants = new List<Entities.EventParticipants>();

            if (ds.Tables[0].Rows.Count == 1)
            {
                objEventUserInfo.EventId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventId"]);
                objEventUserInfo.EventName = ds.Tables[0].Rows[0]["EventName"].ToString();
                objEventUserInfo.EventUserInfoId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventUserInfoId"]);
                objEventUserInfo.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                objEventUserInfo.EventCategoryId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventCategoryId"]);
                objEventUserInfo.EventCategory = ds.Tables[0].Rows[0]["EventCategory"].ToString();
                objEventUserInfo.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                objEventUserInfo.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                objEventUserInfo.Gender = (ds.Tables[0].Rows[0]["Gender"] != DBNull.Value ? ds.Tables[0].Rows[0]["Gender"].ToString() : null);
                objEventUserInfo.Address = (ds.Tables[0].Rows[0]["Address"] != DBNull.Value ? ds.Tables[0].Rows[0]["Address"].ToString() : null);
                objEventUserInfo.City = (ds.Tables[0].Rows[0]["City"] != DBNull.Value ? ds.Tables[0].Rows[0]["City"].ToString() : null);
                objEventUserInfo.State = (ds.Tables[0].Rows[0]["State"] != DBNull.Value ? ds.Tables[0].Rows[0]["State"].ToString() : null);
                objEventUserInfo.Mobile = (ds.Tables[0].Rows[0]["Mobile"] != DBNull.Value ? ds.Tables[0].Rows[0]["Mobile"].ToString() : null);
                objEventUserInfo.ItemName = ds.Tables[0].Rows[0]["ItemName"].ToString();
                objEventUserInfo.ItemCategory = ds.Tables[0].Rows[0]["ItemCategory"].ToString();
                objEventUserInfo.ItemDescription = ds.Tables[0].Rows[0]["ItemDescription"].ToString(); 
                objEventUserInfo.ItemDuration = (ds.Tables[0].Rows[0]["ItemDuration"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[0]["ItemDuration"].ToString()) : 0);
                objEventUserInfo.IsApproved = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsApproved"]);
                objEventUserInfo.DocumentUrl = (ds.Tables[0].Rows[0]["DocumentUrl"] != DBNull.Value ? ds.Tables[0].Rows[0]["DocumentUrl"].ToString() : null);
                objEventUserInfo.UpdatedBy = ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
                objEventUserInfo.UpdatedTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedTime"]);
                //  objEventUserInfo.TicketTypesWithCount = (ds.Tables[0].Rows[0]["TicketTypesWithCount"] != DBNull.Value ? ds.Tables[0].Rows[0]["TicketTypesWithCount"].ToString() : null);
                // objEventUserInfo.TotalAmount = (ds.Tables[0].Rows[0]["TotalAmount"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[0].Rows[0]["TotalAmount"].ToString()) : 0);
                //  objEventUserInfo.AmountPaid = (ds.Tables[0].Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[0].Rows[0]["AmountPaid"].ToString()) : 0);

            }

            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    Entities.EventParticipants objEventParticipants = new Entities.EventParticipants();

                    objEventParticipants.EventParticipantId = Convert.ToInt64(dr["EventParticipantId"]);
                    objEventParticipants.EventId = Convert.ToInt64(dr["EventId"]);
                    objEventParticipants.FirstName = dr["FirstName"].ToString();
                    objEventParticipants.LastName = dr["LastName"].ToString();
                    objEventParticipants.Email = dr["Email"].ToString();
                    objEventParticipants.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
                    objEventParticipants.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
                    objEventParticipants.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objEventParticipants.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    lstEventParticipants.Add(objEventParticipants);
                }

            }

            if (ds.Tables[2].Rows.Count == 1)
            {
                objEventUserInfo.objEventOrderDetails.IsApproved = (ds.Tables[2].Rows[0]["IsApproved"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[2].Rows[0]["IsApproved"].ToString()) : false);
                objEventUserInfo.objEventOrderDetails.EventUserInfoId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventUserInfoId"]);
                objEventUserInfo.objEventOrderDetails.ApprovedDate = (ds.Tables[2].Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[2].Rows[0]["ApprovedDate"].ToString()) : DateTime.MinValue);
                objEventUserInfo.objEventOrderDetails.PaymentMethod = (ds.Tables[2].Rows[0]["PaymentMethod"] != DBNull.Value ? ds.Tables[2].Rows[0]["PaymentMethod"].ToString() : null);
                objEventUserInfo.objEventOrderDetails.PaymentMethodId = (ds.Tables[2].Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[2].Rows[0]["PaymentMethodId"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.PaymentStatus = (ds.Tables[2].Rows[0]["PaymentStatus"] != DBNull.Value ? ds.Tables[2].Rows[0]["PaymentStatus"].ToString() : null);
                objEventUserInfo.objEventOrderDetails.PaymentStatusId = (ds.Tables[2].Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[2].Rows[0]["PaymentStatusId"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.TransactionId = (ds.Tables[2].Rows[0]["TransactionId"] != DBNull.Value ? ds.Tables[2].Rows[0]["TransactionId"].ToString() : null);
                objEventUserInfo.objEventOrderDetails.AmountPaid = (ds.Tables[2].Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[2].Rows[0]["AmountPaid"]) : 0);
                objEventUserInfo.objEventOrderDetails.PaymentDate = (ds.Tables[2].Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[2].Rows[0]["PaymentDate"].ToString()) : DateTime.MinValue);
                objEventUserInfo.objEventOrderDetails.UpdatedBy = ds.Tables[2].Rows[0]["UpdatedBy"].ToString();
                objEventUserInfo.objEventOrderDetails.UpdatedTime = Convert.ToDateTime(ds.Tables[2].Rows[0]["UpdatedTime"]);
            }

            objEventUserInfo.lstEventParticipant = lstEventParticipants;

            if (ds.Tables[3].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[3].Rows)
                {
                    WATS.Entities.EventRegistrationCounts objEventRegistrationCounts = new WATS.Entities.EventRegistrationCounts();
                    objEventRegistrationCounts.EventRegistrationTypeId = Convert.ToInt64(dr["EventRegistrationTypeId"].ToString());
                    objEventRegistrationCounts.EventId = Convert.ToInt64(dr["EventId"].ToString());
                    objEventRegistrationCounts.RegistrationTitle = dr["RegistrationTitle"].ToString();
                    objEventRegistrationCounts.Count = (dr["Count"] != DBNull.Value ? Convert.ToInt64(dr["Count"].ToString()) : 0);
                    objEventRegistrationCounts.Amount = (dr["Amount"] != DBNull.Value ? Convert.ToDecimal(dr["Amount"].ToString()) : 0);
                    
                    lstEventRegistrationCounts.Add(objEventRegistrationCounts);
                }
            }

            //if (ds.Tables[4].Rows.Count != 0)
            //{
            //    foreach (DataRow dr in ds.Tables[4].Rows)
            //    {
            //        NATSWorld.Entities.EventsTickets objEventsTickets = new NATSWorld.Entities.EventsTickets();
            //        objEventsTickets.Barcode = Convert.ToInt64(dr["Barcode"]);
            //        objEventsTickets.Count = (dr["Count"] != DBNull.Value ? Convert.ToInt32(dr["Count"].ToString()) : 0);
            //        objEventsTickets.Amount = Convert.ToDecimal(dr["Amount"].ToString());
            //        objEventsTickets.Field1 = dr["Field1"].ToString();
            //        objEventsTickets.RegistrationTitle = dr["RegistrationTitle"].ToString();

            //        lstEventsTickets.Add(objEventsTickets);
            //    }
            //}

            //if (ds.Tables[5].Rows.Count == 1)
            //{
            //    objEvent.EventId = Convert.ToInt64(ds.Tables[5].Rows[0]["EventId"]);
            //    objEvent.BannerUrl = (ds.Tables[5].Rows[0]["BannerUrl"] != DBNull.Value ? ds.Tables[5].Rows[0]["BannerUrl"].ToString() : null);
            //    objEvent.City = (ds.Tables[5].Rows[0]["City"] != DBNull.Value ? ds.Tables[5].Rows[0]["City"].ToString() : null);
            //    objEvent.ContactEmail = (ds.Tables[5].Rows[0]["ContactEmail"] != DBNull.Value ? ds.Tables[5].Rows[0]["ContactEmail"].ToString() : null);
            //    objEvent.EndDate = (ds.Tables[5].Rows[0]["EndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[5].Rows[0]["EndDate"]) : DateTime.MinValue);
            //    objEvent.EventCategoryId = (ds.Tables[5].Rows[0]["EventCategoryId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[5].Rows[0]["EventCategoryId"]) : 0);
            //    objEvent.EventCategory = (ds.Tables[5].Rows[0]["EventCategory"] != DBNull.Value ? ds.Tables[5].Rows[0]["EventCategory"].ToString() : null);
            //    objEvent.EventDetails = (ds.Tables[5].Rows[0]["EventDetails"] != DBNull.Value ? ds.Tables[5].Rows[0]["EventDetails"].ToString() : null);
            //    objEvent.EventName = ds.Tables[5].Rows[0]["EventName"].ToString();
            //    objEvent.IsRegistration = (ds.Tables[5].Rows[0]["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[5].Rows[0]["IsRegistration"]) : false);
            //    objEvent.IsCulturalRegistration = (ds.Tables[5].Rows[0]["IsCulturalRegistration"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[5].Rows[0]["IsCulturalRegistration"]) : false);
            //    objEvent.Location = (ds.Tables[5].Rows[0]["Location"] != DBNull.Value ? ds.Tables[5].Rows[0]["Location"].ToString() : null);
            //    objEvent.MemberCount = (ds.Tables[5].Rows[0]["MemberCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[5].Rows[0]["MemberCount"]) : 0);
            //    objEvent.RegistrationEndDate = (ds.Tables[5].Rows[0]["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[5].Rows[0]["RegistrationEndDate"]) : DateTime.MinValue);
            //    objEvent.RegistrationStartDate = (ds.Tables[5].Rows[0]["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[5].Rows[0]["RegistrationStartDate"]) : DateTime.MinValue);
            //    objEvent.StartDate = (ds.Tables[5].Rows[0]["StartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[5].Rows[0]["StartDate"]) : DateTime.MinValue);
            //    objEvent.StateName = (ds.Tables[5].Rows[0]["StateName"] != DBNull.Value ? ds.Tables[5].Rows[0]["StateName"].ToString() : null);
            //    objEvent.ZipCode = (ds.Tables[5].Rows[0]["ZipCode"] != DBNull.Value ? ds.Tables[5].Rows[0]["ZipCode"].ToString() : null);
            //    objEvent.TopLine = (ds.Tables[5].Rows[0]["TopLine"] != DBNull.Value ? ds.Tables[5].Rows[0]["TopLine"].ToString() : null);
            //    objEvent.PageTitle = (ds.Tables[5].Rows[0]["PageTitle"] != DBNull.Value ? ds.Tables[5].Rows[0]["PageTitle"].ToString() : null);
            //    objEvent.MetaKeywords = (ds.Tables[5].Rows[0]["MetaKeywords"] != DBNull.Value ? ds.Tables[5].Rows[0]["MetaKeywords"].ToString() : null);
            //    objEvent.MetaDescription = (ds.Tables[5].Rows[0]["MetaDescription"] != DBNull.Value ? ds.Tables[5].Rows[0]["MetaDescription"].ToString() : null);
            //    objEvent.UpdatedTime = Convert.ToDateTime(ds.Tables[5].Rows[0]["UpdatedTime"]);
            //}

            return objEventUserInfo;
        }

        public Entities.EventUserInfo GetEventUserInfoFullDetailsById(Int64 EventUserInfoGetById, ref int status)
        {
            DataSet ds = _Events.GetEventUserInfoFullDetailsById(EventUserInfoGetById, ref status);
            Entities.EventUserInfo objEventUserInfo = new Entities.EventUserInfo();
            List<Entities.EventParticipants> lstEventParticipants = new List<Entities.EventParticipants>();

            if (ds.Tables[0].Rows.Count == 1)
            {
                objEventUserInfo.EventId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventId"]);
                objEventUserInfo.EventName = ds.Tables[0].Rows[0]["EventName"].ToString();
                objEventUserInfo.EventUserInfoId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventUserInfoId"]);
                objEventUserInfo.LastName = ds.Tables[0].Rows[0]["LastName"].ToString();
                objEventUserInfo.EventCategoryId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventCategoryId"]);
                objEventUserInfo.EventCategory = ds.Tables[0].Rows[0]["EventCategory"].ToString();
                objEventUserInfo.FirstName = ds.Tables[0].Rows[0]["FirstName"].ToString();
                objEventUserInfo.Email = ds.Tables[0].Rows[0]["Email"].ToString();
                objEventUserInfo.Gender = (ds.Tables[0].Rows[0]["Gender"] != DBNull.Value ? ds.Tables[0].Rows[0]["Gender"].ToString() : null);
                objEventUserInfo.Address = (ds.Tables[0].Rows[0]["Address"] != DBNull.Value ? ds.Tables[0].Rows[0]["Address"].ToString() : null);
                objEventUserInfo.City = (ds.Tables[0].Rows[0]["City"] != DBNull.Value ? ds.Tables[0].Rows[0]["City"].ToString() : null);
                objEventUserInfo.State = (ds.Tables[0].Rows[0]["State"] != DBNull.Value ? ds.Tables[0].Rows[0]["State"].ToString() : null);
                objEventUserInfo.Mobile = (ds.Tables[0].Rows[0]["Mobile"] != DBNull.Value ? ds.Tables[0].Rows[0]["Mobile"].ToString() : null);
                objEventUserInfo.ItemName = ds.Tables[0].Rows[0]["ItemName"].ToString();
                objEventUserInfo.ItemCategory = ds.Tables[0].Rows[0]["ItemCategory"].ToString();
                objEventUserInfo.ItemDescription = ds.Tables[0].Rows[0]["ItemDescription"].ToString();
                objEventUserInfo.ItemDuration = (ds.Tables[0].Rows[0]["ItemDuration"] != DBNull.Value ?Convert.ToInt32(ds.Tables[0].Rows[0]["ItemDuration"].ToString()) : 0);
                objEventUserInfo.IsApproved = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsApproved"]);
                objEventUserInfo.DocumentUrl = (ds.Tables[0].Rows[0]["DocumentUrl"] != DBNull.Value ? ds.Tables[0].Rows[0]["DocumentUrl"].ToString() : null);
                objEventUserInfo.UpdatedBy = ds.Tables[0].Rows[0]["UpdatedBy"].ToString();
                objEventUserInfo.UpdatedTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedTime"]);
            }

            if (ds.Tables[1].Rows.Count != 0 )
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    Entities.EventParticipants objEventParticipants = new Entities.EventParticipants();

                    objEventParticipants.EventParticipantId = Convert.ToInt64(dr["EventParticipantId"]);
                    objEventParticipants.EventId = Convert.ToInt64(dr["EventId"]);
                    objEventParticipants.FirstName = dr["FirstName"].ToString();
                    objEventParticipants.LastName = dr["LastName"].ToString();
                    objEventParticipants.Email = dr["Email"].ToString();
                    objEventParticipants.Age = (dr["Age"] != DBNull.Value ? dr["Age"].ToString() : null);
                    objEventParticipants.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
                    objEventParticipants.IsApproved =Convert.ToBoolean(dr["IsApproved"]);
                    objEventParticipants.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    lstEventParticipants.Add(objEventParticipants);
                }

            }

            if (ds.Tables[2].Rows.Count == 1)
            {
                objEventUserInfo.objEventOrderDetails.EventOrderId = Convert.ToInt64(ds.Tables[2].Rows[0]["EventOrderId"]);
                objEventUserInfo.objEventOrderDetails.IsApproved = (ds.Tables[2].Rows[0]["IsApproved"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[2].Rows[0]["IsApproved"].ToString()) : false);
                objEventUserInfo.objEventOrderDetails.EventUserInfoId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventUserInfoId"]);
                objEventUserInfo.objEventOrderDetails.ApprovedDate = (ds.Tables[2].Rows[0]["ApprovedDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[2].Rows[0]["ApprovedDate"].ToString()) : DateTime.MinValue);
                objEventUserInfo.objEventOrderDetails.PaymentMethod = (ds.Tables[2].Rows[0]["PaymentMethod"] != DBNull.Value ? ds.Tables[2].Rows[0]["PaymentMethod"].ToString() : null);
                objEventUserInfo.objEventOrderDetails.PaymentMethodId = (ds.Tables[2].Rows[0]["PaymentMethodId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[2].Rows[0]["PaymentMethodId"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.PaymentStatus = (ds.Tables[2].Rows[0]["PaymentStatus"] != DBNull.Value ? ds.Tables[2].Rows[0]["PaymentStatus"].ToString() : null);
                objEventUserInfo.objEventOrderDetails.PaymentStatusId = (ds.Tables[2].Rows[0]["PaymentStatusId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[2].Rows[0]["PaymentStatusId"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.TransactionId = (ds.Tables[2].Rows[0]["TransactionId"] != DBNull.Value ? ds.Tables[2].Rows[0]["TransactionId"].ToString() : null);
                objEventUserInfo.objEventOrderDetails.AmountPaid = (ds.Tables[2].Rows[0]["AmountPaid"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[2].Rows[0]["AmountPaid"]) : 0);
                objEventUserInfo.objEventOrderDetails.PaymentDate = (ds.Tables[2].Rows[0]["PaymentDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[2].Rows[0]["PaymentDate"].ToString()) : DateTime.MinValue);
                objEventUserInfo.objEventOrderDetails.UpdatedBy = ds.Tables[2].Rows[0]["UpdatedBy"].ToString();
                objEventUserInfo.objEventOrderDetails.UpdatedTime = Convert.ToDateTime(ds.Tables[2].Rows[0]["UpdatedTime"]);
                objEventUserInfo.objEventOrderDetails.ChildCount = (ds.Tables[2].Rows[0]["ChildCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["ChildCount"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.AdultCount = (ds.Tables[2].Rows[0]["AdultCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["AdultCount"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.FamilyCount = (ds.Tables[2].Rows[0]["FamilyCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["FamilyCount"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.CoupleCount = (ds.Tables[2].Rows[0]["CoupleCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["CoupleCount"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.VIPCount = (ds.Tables[2].Rows[0]["VIPCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["VIPCount"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.VIPSingleAdultCount = (ds.Tables[2].Rows[0]["VIPSingleAdultCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["VIPSingleAdultCount"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.VIPCoupleCount = (ds.Tables[2].Rows[0]["VIPCoupleCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["VIPCoupleCount"].ToString()) : 0);
                objEventUserInfo.objEventOrderDetails.VIPChildCount = (ds.Tables[2].Rows[0]["VIPChildCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[2].Rows[0]["VIPChildCount"].ToString()) : 0);
            }

            objEventUserInfo.lstEventParticipant = lstEventParticipants;

            return objEventUserInfo;
        }

        public List<WATS.Entities.EventUserInfo> GetEventUserInfoListByVariable(Int64 EventId, string Type, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.EventUserInfo> lstEventUserInfo = new List<WATS.Entities.EventUserInfo>();
            DataTable dt = _Events.GetEventUserInfoListByVariable(EventId, Type, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Events.GetEventUserInfoListByVariable(EventId, Type, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.EventUserInfo objEvent = new WATS.Entities.EventUserInfo();

                    objEvent.RId = Convert.ToInt64(dr["Rid"]);
                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventUserInfoId = Convert.ToInt64(dr["EventUserInfoId"]);
                    objEvent.EventName = dr["EventName"].ToString();
                    objEvent.LastName = dr["LastName"].ToString();
                    objEvent.EventCategory = dr["EventCategory"].ToString();
                    objEvent.FirstName = dr["FirstName"].ToString();
                    objEvent.Email = dr["Email"].ToString();
                    objEvent.Gender = (dr["Gender"] != DBNull.Value ? dr["Gender"].ToString() : null);
                    objEvent.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
                    objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objEvent.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
                    objEvent.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
                    objEvent.ItemName = dr["ItemName"].ToString();
                    objEvent.ItemCategory = dr["ItemCategory"].ToString();
                    objEvent.ItemDescription = dr["ItemDescription"].ToString();
                    objEvent.ItemDuration = (dr["ItemDuration"] != DBNull.Value ?Convert.ToInt32(dr["ItemDuration"].ToString()) : 0);
                    objEvent.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objEvent.DocumentUrl = (dr["DocumentUrl"] != DBNull.Value ? dr["DocumentUrl"].ToString() : null);
                    objEvent.UpdatedBy = dr["UpdatedBy"].ToString();
                    objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
                    objEvent.InsertedTime = (dr["InsertedTime"] != DBNull.Value ?  Convert.ToDateTime(dr["InsertedTime"].ToString()) : DateTime.MinValue);
                    objEvent.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
                    objEvent.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    lstEventUserInfo.Add(objEvent);
                }
            }
            return lstEventUserInfo;
        }

        //public List<WATS.Entities.EventUserInfo> ExportToEventUserInfoList(Int64 EventId, string Search, string Sort)
        //{
        //    List<WATS.Entities.EventUserInfo> lstEventUserInfo = new List<WATS.Entities.EventUserInfo>();
        //    DataTable dt = _Events.ExportToEventUserInfoList(EventId, Search, Sort);
        //    if (dt.Rows.Count != 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            WATS.Entities.EventUserInfo objEvent = new WATS.Entities.EventUserInfo();

        //            objEvent.EventId = Convert.ToInt64(dr["EventId"]);
        //            objEvent.EventUserInfoId = Convert.ToInt64(dr["EventUserInfoId"]);
        //            objEvent.EventName = dr["EventName"].ToString();
        //            objEvent.LastName = dr["LastName"].ToString();
        //            objEvent.EventCategory = dr["EventCategory"].ToString();
        //            objEvent.FirstName = dr["FirstName"].ToString();
        //            objEvent.Email = dr["Email"].ToString();
        //            objEvent.Gender = (dr["Gender"] != DBNull.Value ? dr["Gender"].ToString() : null);
        //            objEvent.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
        //            objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
        //            objEvent.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
        //            objEvent.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
        //            objEvent.ItemName = dr["ItemName"].ToString();
        //            objEvent.ItemCategory = dr["ItemCategory"].ToString();
        //            objEvent.ItemDescription = dr["ItemDescription"].ToString();
        //            objEvent.ItemDuration = (dr["ItemDuration"] != DBNull.Value ? Convert.ToInt32(dr["ItemDuration"].ToString()) : 0);
        //            objEvent.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
        //            objEvent.DocumentUrl = (dr["DocumentUrl"] != DBNull.Value ? dr["DocumentUrl"].ToString() : null);
        //            objEvent.UpdatedBy = dr["UpdatedBy"].ToString();
        //            objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
        //            objEvent.InsertedTime = (dr["InsertedTime"] != DBNull.Value ? Convert.ToDateTime(dr["InsertedTime"].ToString()) : DateTime.MinValue);
        //            objEvent.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
        //            objEvent.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
        //            lstEventUserInfo.Add(objEvent);
        //        }
        //    }
        //    return lstEventUserInfo;
        //}

        public Int64 UpdateEventUserInfoStatus(Int64 EventUserInfoGetById)
        {
            Int64 _status = 0;
            _status = _Events.UpdateEventUserInfoStatus(EventUserInfoGetById);
            return _status;
        }

        #endregion

        #region EventParticipants

        public Int64 DeleteEventParticipantsById(Int64 EventParticipantId)
        {
            Int64 _status = 0;
            _status = _Events.DeleteEventParticipantsById(EventParticipantId);
            return _status;
        }


        public List<WATS.Entities.Events> GetAllEventsList(ref int status)
        {
            List<WATS.Entities.Events> lstEvents = new List<Entities.Events>();
            DataTable dt = _Events.GetAllEventsList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Events objEvent = new WATS.Entities.Events();

                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);
                    objEvent.StartDate = (dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]) : DateTime.MinValue);
                    objEvent.EndDate = (dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]) : DateTime.MinValue);
                    objEvent.RegistrationStartDate = (dr["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationStartDate"]) : DateTime.MinValue);
                    objEvent.RegistrationEndDate = (dr["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationEndDate"]) : DateTime.MinValue);
                    objEvent.BannerUrl = (dr["BannerUrl"] != DBNull.Value ? dr["BannerUrl"].ToString() : null);
                    objEvent.EventCategoryId = (dr["EventCategoryId"] != DBNull.Value ? Convert.ToInt32(dr["EventCategoryId"]) : 0);
                    objEvent.MemberCount = (dr["MemberCount"] != DBNull.Value ? Convert.ToInt32(dr["MemberCount"]) : 0);
                    objEvent.Location = (dr["Location"] != DBNull.Value ? dr["Location"].ToString() : null);
                    objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objEvent.StateName = (dr["StateName"] != DBNull.Value ? dr["StateName"].ToString() : null);
                    objEvent.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : null);
                    objEvent.EventDetails = (dr["EventDetails"] != DBNull.Value ? dr["EventDetails"].ToString() : null);
                    objEvent.IsRegistration = (dr["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(dr["IsRegistration"].ToString()) : false);
                    objEvent.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    objEvent.EventCategory = (dr["EventCategory"] != DBNull.Value ? dr["EventCategory"].ToString() : null);
                    objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    objEvent.IsChild = (dr["IsChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsChild"].ToString()) : false);
                    objEvent.ChildAmount = (dr["ChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["ChildAmount"]) : 0);
                    objEvent.NonChildAmount = (dr["NonChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonChildAmount"]) : 0);
                    objEvent.IsAdult = (dr["IsAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsAdult"].ToString()) : false);
                    objEvent.AdultAmount = (dr["AdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["AdultAmount"]) : 0);
                    objEvent.NonAdultAmount = (dr["NonAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonAdultAmount"]) : 0);
                    objEvent.IsCouple = (dr["IsCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsCouple"].ToString()) : false);
                    objEvent.CoupleAmount = (dr["CoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["CoupleAmount"]) : 0);
                    objEvent.NonCoupleAmount = (dr["NonCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonCoupleAmount"]) : 0);
                    objEvent.IsFamily = (dr["IsFamily"] != DBNull.Value ? Convert.ToBoolean(dr["IsFamily"].ToString()) : false);
                    objEvent.FamilyAmount = (dr["FamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["FamilyAmount"]) : 0);
                    objEvent.NonFamilyAmount = (dr["NonFamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonFamilyAmount"]) : 0);
                    objEvent.IsVIP = (dr["IsVIP"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIP"].ToString()) : false);
                    objEvent.VIPAmount = (dr["VIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPAmount"]) : 0);
                    objEvent.NonVIPAmount = (dr["NonVIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPAmount"]) : 0);
                    objEvent.IsVIPChild = (dr["IsVIPChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPChild"].ToString()) : false);
                    objEvent.VIPChildAmount = (dr["VIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPChildAmount"]) : 0);
                    objEvent.NonVIPChildAmount = (dr["NonVIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPChildAmount"]) : 0);
                    objEvent.IsVIPSingleAdult = (dr["IsVIPSingleAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPSingleAdult"].ToString()) : false);
                    objEvent.VIPSingleAdultAmount = (dr["VIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPSingleAdultAmount"]) : 0);
                    objEvent.NonVIPSingleAdultAmount = (dr["NonVIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPSingleAdultAmount"]) : 0);
                    objEvent.IsVIPCouple = (dr["IsVIPCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPCouple"].ToString()) : false);
                    objEvent.VIPCoupleAmount = (dr["VIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPCoupleAmount"]) : 0);
                    objEvent.NonVIPCoupleAmount = (dr["NonVIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPCoupleAmount"]) : 0);
                    objEvent.EventParticipantsCount = (dr["EventParticipantsCount"] != DBNull.Value ? Convert.ToInt64(dr["EventParticipantsCount"]) : 0);

                    objEvent.TopLine = (dr["TopLine"] != DBNull.Value ? dr["TopLine"].ToString() : null);

                    lstEvents.Add(objEvent);
                }

            }
            return lstEvents;
        }

        #endregion

        #region EventRegistrationTypes

        public Int64 DeleteEventRegistrationTypes(Int64 EventRegistrationTypeId)
        {
            Int64 _status = 0;
            _status = _Events.DeleteEventRegistrationTypes(EventRegistrationTypeId);

            return _status;
        }

        public List<WATS.Entities.EventRegistrationTypes> GetEventRegistrationTypesList(Int64 EventId, ref int Total)
        {
            List<WATS.Entities.EventRegistrationTypes> lstEventRegistrationTypes = new List<WATS.Entities.EventRegistrationTypes>();
            DataTable dt = _Events.GetEventRegistrationTypesList(EventId, ref Total);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.EventRegistrationTypes objEvent = new WATS.Entities.EventRegistrationTypes();

                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventRegistrationTypeId = Convert.ToInt64(dr["EventRegistrationTypeId"]);
                    objEvent.RegistrationTitle = dr["RegistrationTitle"].ToString();
                    objEvent.RegCount = (dr["RegCount"] != DBNull.Value ? Convert.ToInt64(dr["RegCount"].ToString()) : 0);
                    objEvent.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"].ToString()) : 0);
                    objEvent.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objEvent.MemberAmount = (dr["MemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["MemberAmount"].ToString()) : 0);
                    objEvent.NonMemberAmount = (dr["NonMemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["NonMemberAmount"].ToString()) : 0);
                    lstEventRegistrationTypes.Add(objEvent);
                }

            }
            return lstEventRegistrationTypes;
        }

        public Int64 UpdateEventRegistrationTypesStatus(Int64 EventRegistrationTypeId)
        {
            Int64 _status = 0;
            _status = _Events.UpdateEventRegistrationTypesStatus(EventRegistrationTypeId);
            return _status;
        }

        public Int64 UpdateEventRegistrationTypesDisplayOrder(int OrderNo, Int64 EventRegistrationTypeId)
        {
            Int64 _status = 0;
            _status = _Events.UpdateEventRegistrationTypesDisplayOrder(OrderNo, EventRegistrationTypeId);
            return _status;
        }

        public Int64 InsertRegistrationTypes(Entities.EventRegistrationTypes objRegistrationTypes)
        {
            Int64 _status = 0;
            if (objRegistrationTypes != null)
            {
                _status = _Events.InsertRegistrationTypes(objRegistrationTypes);
            }
            return _status;
        }

        public List<WATS.Entities.Events> GetEventsByCategory(Int64 RegistrationCategoryId, ref int status)
        {
            List<WATS.Entities.Events> lstEvents = new List<WATS.Entities.Events>();
            DataTable dt = _Events.GetEventsByCategory(RegistrationCategoryId, ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Events objlstEvents = new WATS.Entities.Events();


                    objlstEvents.EventId = (dr["EventId"] != DBNull.Value ? Convert.ToInt64(dr["EventId"]) : 0);
                    objlstEvents.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);


                    lstEvents.Add(objlstEvents);
                }

            }
            return lstEvents;
        }

        #endregion


        #region EventCompetitions

        public Entities.Events FEGetEventByCategoryId(Int64 EventId, Int64 RegistrationCategoryId, string EventName, ref List<Entities.EventRegistrationTypes> lstEventRegistrationTypes, ref int status)
        {
            DataSet ds = _Events.FEGetEventByCategoryId(EventId, RegistrationCategoryId, EventName, ref status);
            Entities.Events objEvent = new Entities.Events();

            if (ds.Tables[0].Rows.Count == 1)
            {
                objEvent.EventId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventId"]);
                objEvent.BannerUrl = (ds.Tables[0].Rows[0]["BannerUrl"] != DBNull.Value ? ds.Tables[0].Rows[0]["BannerUrl"].ToString() : null);
                objEvent.City = (ds.Tables[0].Rows[0]["City"] != DBNull.Value ? ds.Tables[0].Rows[0]["City"].ToString() : null);
                objEvent.ContactEmail = (ds.Tables[0].Rows[0]["ContactEmail"] != DBNull.Value ? ds.Tables[0].Rows[0]["ContactEmail"].ToString() : null);
                objEvent.EndDate = (ds.Tables[0].Rows[0]["EndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["EndDate"]) : DateTime.MinValue);
                objEvent.EventCategoryId = (ds.Tables[0].Rows[0]["EventCategoryId"] != DBNull.Value ? Convert.ToInt64(ds.Tables[0].Rows[0]["EventCategoryId"]) : 0);
                objEvent.EventCategory = (ds.Tables[0].Rows[0]["EventCategory"] != DBNull.Value ? ds.Tables[0].Rows[0]["EventCategory"].ToString() : null);
                objEvent.EventDetails = (ds.Tables[0].Rows[0]["EventDetails"] != DBNull.Value ? ds.Tables[0].Rows[0]["EventDetails"].ToString() : null);
                objEvent.EventName = ds.Tables[0].Rows[0]["EventName"].ToString();
                objEvent.IsRegistration = (ds.Tables[0].Rows[0]["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRegistration"]) : false); 
                objEvent.Location = (ds.Tables[0].Rows[0]["Location"] != DBNull.Value ? ds.Tables[0].Rows[0]["Location"].ToString() : null);
                objEvent.MemberCount = (ds.Tables[0].Rows[0]["MemberCount"] != DBNull.Value ? Convert.ToInt32(ds.Tables[0].Rows[0]["MemberCount"]) : 0);
                objEvent.RegistrationEndDate = (ds.Tables[0].Rows[0]["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationEndDate"]) : DateTime.MinValue);
                objEvent.RegistrationStartDate = (ds.Tables[0].Rows[0]["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["RegistrationStartDate"]) : DateTime.MinValue);
                objEvent.StartDate = (ds.Tables[0].Rows[0]["StartDate"] != DBNull.Value ? Convert.ToDateTime(ds.Tables[0].Rows[0]["StartDate"]) : DateTime.MinValue);
                objEvent.StateName = (ds.Tables[0].Rows[0]["StateName"] != DBNull.Value ? ds.Tables[0].Rows[0]["StateName"].ToString() : null);
                objEvent.ZipCode = (ds.Tables[0].Rows[0]["ZipCode"] != DBNull.Value ? ds.Tables[0].Rows[0]["ZipCode"].ToString() : null);
                objEvent.TopLine = (ds.Tables[0].Rows[0]["TopLine"] != DBNull.Value ? ds.Tables[0].Rows[0]["TopLine"].ToString() : null);
                objEvent.PageTitle = (ds.Tables[0].Rows[0]["PageTitle"] != DBNull.Value ? ds.Tables[0].Rows[0]["PageTitle"].ToString() : null);
                objEvent.MetaKeywords = (ds.Tables[0].Rows[0]["MetaKeywords"] != DBNull.Value ? ds.Tables[0].Rows[0]["MetaKeywords"].ToString() : null);
                objEvent.MetaDescription = (ds.Tables[0].Rows[0]["MetaDescription"] != DBNull.Value ? ds.Tables[0].Rows[0]["MetaDescription"].ToString() : null);
                objEvent.UpdatedTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpdatedTime"]);
                //objEvent.IsFood = (ds.Tables[0].Rows[0]["IsFood"] != DBNull.Value ? Convert.ToBoolean(ds.Tables[0].Rows[0]["IsFood"]) : false);
                objEvent.MemberAmount = (ds.Tables[0].Rows[0]["MemberAmount"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[0].Rows[0]["MemberAmount"].ToString()) : 0);
                objEvent.NAmount = (ds.Tables[0].Rows[0]["NAmount"] != DBNull.Value ? Convert.ToDecimal(ds.Tables[0].Rows[0]["NAmount"].ToString()) : 0);
                objEvent.CategoryName = (ds.Tables[0].Rows[0]["CategoryName"] != DBNull.Value ? ds.Tables[0].Rows[0]["CategoryName"].ToString() : null);
            }

            if (ds.Tables[1].Rows.Count != 0)
            {
                foreach (DataRow dr in ds.Tables[1].Rows)
                {
                    WATS.Entities.EventRegistrationTypes objEventRegistrationTypes = new WATS.Entities.EventRegistrationTypes();
                    objEventRegistrationTypes.EventRegistrationTypeId = Convert.ToInt64(dr["EventRegistrationTypeId"].ToString());
                    objEventRegistrationTypes.EventId = Convert.ToInt64(dr["EventId"].ToString());
                    objEventRegistrationTypes.RegistrationTitle = dr["RegistrationTitle"].ToString();
                    objEventRegistrationTypes.RegCount = (dr["RegCount"] != DBNull.Value ? Convert.ToInt64(dr["RegCount"].ToString()) : 0);
                    objEventRegistrationTypes.OrderNo = (dr["OrderNo"] != DBNull.Value ? Convert.ToInt32(dr["OrderNo"].ToString()) : 0);
                    objEventRegistrationTypes.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                    objEventRegistrationTypes.MemberAmount = (dr["MemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["MemberAmount"].ToString()) : 0);
                    objEventRegistrationTypes.NonMemberAmount = (dr["NonMemberAmount"] != DBNull.Value ? Convert.ToDecimal(dr["NonMemberAmount"].ToString()) : 0);

                    lstEventRegistrationTypes.Add(objEventRegistrationTypes);
                }
            }

            return objEvent;
        }

        #endregion

        #region Registrations

        public List<WATS.Entities.EventUserInfo> RegistrationEventUserInfoGetListByVariable(Int64 EventId, string Type, string Search, string Sort, int PageNo, int Items, ref int Total)
        {
            List<WATS.Entities.EventUserInfo> lstEventUserInfo = new List<WATS.Entities.EventUserInfo>();
            DataTable dt = _Events.RegistrationEventUserInfoGetListByVariable(EventId, Type, Search, Sort, PageNo, Items, ref Total);
            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Events.RegistrationEventUserInfoGetListByVariable(EventId, Type, Search, Sort, PageNo - 1, Items, ref Total);
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.EventUserInfo objEvent = new WATS.Entities.EventUserInfo();

                    objEvent.RId = Convert.ToInt64(dr["Rid"]);
                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventUserInfoId = Convert.ToInt64(dr["EventUserInfoId"]);
                    objEvent.EventName = dr["EventName"].ToString();
                    objEvent.LastName = dr["LastName"].ToString();
                    objEvent.EventCategory = dr["EventCategory"].ToString();
                    objEvent.FirstName = dr["FirstName"].ToString();
                    objEvent.Email = dr["Email"].ToString();
                    objEvent.Gender = (dr["Gender"] != DBNull.Value ? dr["Gender"].ToString() : null);
                    objEvent.Address = (dr["Address"] != DBNull.Value ? dr["Address"].ToString() : null);
                    objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    objEvent.State = (dr["State"] != DBNull.Value ? dr["State"].ToString() : null);
                    objEvent.Mobile = (dr["Mobile"] != DBNull.Value ? dr["Mobile"].ToString() : null);
                    objEvent.ItemName = dr["ItemName"].ToString();
                    objEvent.ItemCategory = dr["ItemCategory"].ToString();
                    objEvent.ItemDescription = dr["ItemDescription"].ToString();
                    objEvent.ItemDuration = (dr["ItemDuration"] != DBNull.Value ? Convert.ToInt32(dr["ItemDuration"].ToString()) : 0);
                    objEvent.IsApproved = Convert.ToBoolean(dr["IsApproved"]);
                    objEvent.DocumentUrl = (dr["DocumentUrl"] != DBNull.Value ? dr["DocumentUrl"].ToString() : null);
                    objEvent.UpdatedBy = dr["UpdatedBy"].ToString();
                    objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);
                    objEvent.InsertedTime = (dr["InsertedTime"] != DBNull.Value ? Convert.ToDateTime(dr["InsertedTime"].ToString()) : DateTime.MinValue);
                    objEvent.PaymentMethod = (dr["PaymentMethod"] != DBNull.Value ? dr["PaymentMethod"].ToString() : null);
                    objEvent.PaymentStatus = (dr["PaymentStatus"] != DBNull.Value ? dr["PaymentStatus"].ToString() : null);
                    lstEventUserInfo.Add(objEvent);
                }
            }
            return lstEventUserInfo;
        }

        public List<WATS.Entities.Events> UpcomingEventsList(ref int status)
        {
            List<WATS.Entities.Events> lstEvents = new List<Entities.Events>();
            DataTable dt = _Events.UpcomingEventsList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    WATS.Entities.Events objEvent = new WATS.Entities.Events();

                    objEvent.EventId = Convert.ToInt64(dr["EventId"]);
                    objEvent.EventName = (dr["EventName"] != DBNull.Value ? dr["EventName"].ToString() : null);
                    //objEvent.StartDate = (dr["StartDate"] != DBNull.Value ? Convert.ToDateTime(dr["StartDate"]) : DateTime.MinValue);
                    //objEvent.EndDate = (dr["EndDate"] != DBNull.Value ? Convert.ToDateTime(dr["EndDate"]) : DateTime.MinValue);
                    //objEvent.RegistrationStartDate = (dr["RegistrationStartDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationStartDate"]) : DateTime.MinValue);
                    //objEvent.RegistrationEndDate = (dr["RegistrationEndDate"] != DBNull.Value ? Convert.ToDateTime(dr["RegistrationEndDate"]) : DateTime.MinValue);
                    //objEvent.BannerUrl = (dr["BannerUrl"] != DBNull.Value ? dr["BannerUrl"].ToString() : null);
                    //objEvent.EventCategoryId = (dr["EventCategoryId"] != DBNull.Value ? Convert.ToInt32(dr["EventCategoryId"]) : 0);
                    //objEvent.MemberCount = (dr["MemberCount"] != DBNull.Value ? Convert.ToInt32(dr["MemberCount"]) : 0);
                    //objEvent.Location = (dr["Location"] != DBNull.Value ? dr["Location"].ToString() : null);
                    //objEvent.City = (dr["City"] != DBNull.Value ? dr["City"].ToString() : null);
                    //objEvent.StateName = (dr["StateName"] != DBNull.Value ? dr["StateName"].ToString() : null);
                    //objEvent.ZipCode = (dr["ZipCode"] != DBNull.Value ? dr["ZipCode"].ToString() : null);
                    //objEvent.EventDetails = (dr["EventDetails"] != DBNull.Value ? dr["EventDetails"].ToString() : null);
                    //objEvent.IsRegistration = (dr["IsRegistration"] != DBNull.Value ? Convert.ToBoolean(dr["IsRegistration"].ToString()) : false);
                    //objEvent.ContactEmail = (dr["ContactEmail"] != DBNull.Value ? dr["ContactEmail"].ToString() : null);
                    //objEvent.EventCategory = (dr["EventCategory"] != DBNull.Value ? dr["EventCategory"].ToString() : null);
                    //objEvent.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"]);

                    //objEvent.IsChild = (dr["IsChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsChild"].ToString()) : false);
                    //objEvent.ChildAmount = (dr["ChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["ChildAmount"]) : 0);
                    //objEvent.NonChildAmount = (dr["NonChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonChildAmount"]) : 0);
                    //objEvent.IsAdult = (dr["IsAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsAdult"].ToString()) : false);
                    //objEvent.AdultAmount = (dr["AdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["AdultAmount"]) : 0);
                    //objEvent.NonAdultAmount = (dr["NonAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonAdultAmount"]) : 0);
                    //objEvent.IsCouple = (dr["IsCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsCouple"].ToString()) : false);
                    //objEvent.CoupleAmount = (dr["CoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["CoupleAmount"]) : 0);
                    //objEvent.NonCoupleAmount = (dr["NonCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonCoupleAmount"]) : 0);
                    //objEvent.IsFamily = (dr["IsFamily"] != DBNull.Value ? Convert.ToBoolean(dr["IsFamily"].ToString()) : false);
                    //objEvent.FamilyAmount = (dr["FamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["FamilyAmount"]) : 0);
                    //objEvent.NonFamilyAmount = (dr["NonFamilyAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonFamilyAmount"]) : 0);
                    //objEvent.IsVIP = (dr["IsVIP"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIP"].ToString()) : false);
                    //objEvent.VIPAmount = (dr["VIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPAmount"]) : 0);
                    //objEvent.NonVIPAmount = (dr["NonVIPAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPAmount"]) : 0);
                    //objEvent.IsVIPChild = (dr["IsVIPChild"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPChild"].ToString()) : false);
                    //objEvent.VIPChildAmount = (dr["VIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPChildAmount"]) : 0);
                    //objEvent.NonVIPChildAmount = (dr["NonVIPChildAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPChildAmount"]) : 0);
                    //objEvent.IsVIPSingleAdult = (dr["IsVIPSingleAdult"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPSingleAdult"].ToString()) : false);
                    //objEvent.VIPSingleAdultAmount = (dr["VIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPSingleAdultAmount"]) : 0);
                    //objEvent.NonVIPSingleAdultAmount = (dr["NonVIPSingleAdultAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPSingleAdultAmount"]) : 0);
                    //objEvent.IsVIPCouple = (dr["IsVIPCouple"] != DBNull.Value ? Convert.ToBoolean(dr["IsVIPCouple"].ToString()) : false);
                    //objEvent.VIPCoupleAmount = (dr["VIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["VIPCoupleAmount"]) : 0);
                    //objEvent.NonVIPCoupleAmount = (dr["NonVIPCoupleAmount"] != DBNull.Value ? Convert.ToInt64(dr["NonVIPCoupleAmount"]) : 0);

                    lstEvents.Add(objEvent);
                }

            }
            return lstEvents;
        }

        #endregion
    }
}
