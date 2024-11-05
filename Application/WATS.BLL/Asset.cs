using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.BLL
{
    public class Asset
    {
        DAL.Asset _Asset = new DAL.Asset();

        #region Methods

        public Int64 InsertAsset(Entities.Asset objAsset)                     
        {
            Int64 _status = 0;
            if (objAsset != null)
            {
                _status = _Asset.InsertAsset(objAsset);

            }
            return _status;
        }

        public Int64 DeleteAsset(Int64 AssetId)
        {
            Int64 _status = 0;
            _status = _Asset.DeleteAsset(AssetId);
            return _status;
        }

        public Int64 UpdateAssetStatus(Int64 AssetId)
        {
            Int64 _status = 0;
            _status = _Asset.UpdateAssetStatus(AssetId);
            return _status;
        }

        #endregion

        #region Entities filling

        public List<Entities.Asset> GetAssetList(ref int status)                                   
        {
            List<Entities.Asset> lstAsset = new List<Entities.Asset>();
            DataTable dt = _Asset.GetAssetList(ref status);

            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Asset objlstAsset = new Entities.Asset();

                    objlstAsset.AssetId = Convert.ToInt64(dr["AssetId"].ToString());
                    objlstAsset.AssetName = dr["AssetName"].ToString();
                    objlstAsset.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                    objlstAsset.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : null);
                    objlstAsset.OwnerBy = (dr["OwnerBy"] != DBNull.Value ? dr["OwnerBy"].ToString() : null);
                    objlstAsset.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objlstAsset.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
                    objlstAsset.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                    objlstAsset.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objlstAsset.UpdatedBy = dr["UpdatedBy"].ToString();
                    objlstAsset.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());


                    lstAsset.Add(objlstAsset);         
                }

            }
            return lstAsset;
        }

        public Entities.Asset GetAssetById(Int64 AssetId, ref int status)                                           
        {
            Entities.Asset objAsset = new Entities.Asset();
            DataTable dt = new DataTable();

            if (AssetId != 0)
            {
                dt = _Asset.GetAssetById(AssetId, ref status);                                                     
                if (dt.Rows.Count == 1)
                {
                    objAsset.AssetId = Convert.ToInt64(dt.Rows[0]["AssetId"].ToString());
                    objAsset.AssetName = dt.Rows[0]["AssetName"].ToString();
                    objAsset.Quantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());
                    objAsset.Description = (dt.Rows[0]["Description"] != DBNull.Value ? dt.Rows[0]["Description"].ToString() : null);
                    objAsset.OwnerBy = (dt.Rows[0]["OwnerBy"] != DBNull.Value ? dt.Rows[0]["OwnerBy"].ToString() : null);
                    objAsset.IsActive = Convert.ToBoolean(dt.Rows[0]["IsActive"]);
                    objAsset.Name = (dt.Rows[0]["Name"] != DBNull.Value ? dt.Rows[0]["Name"].ToString() : null);
                    objAsset.Email = (dt.Rows[0]["Email"] != DBNull.Value ? dt.Rows[0]["Email"].ToString() : null);
                    objAsset.PhoneNo = (dt.Rows[0]["PhoneNo"] != DBNull.Value ? dt.Rows[0]["PhoneNo"].ToString() : null);
                    objAsset.UpdatedBy = dt.Rows[0]["UpdatedBy"].ToString();
                    objAsset.UpdatedTime = Convert.ToDateTime(dt.Rows[0]["UpdatedTime"].ToString());

                }
            }
            return objAsset;
        }

        public List<Entities.Asset> GetAssetListByVariable(string Search, string Sort, int PageNo, int Items, ref int Total) 
        {
            List<Entities.Asset> lstAsset = new List<Entities.Asset>();
            DataTable dt = _Asset.GetAssetListByVariable(Search, Sort, PageNo, Items, ref Total); 

            if (dt.Rows.Count == 0 && PageNo != 0)
            {
                dt = _Asset.GetAssetListByVariable(Search, Sort, PageNo, Items, ref Total); 
            }
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Entities.Asset objAsset = new Entities.Asset();
                    objAsset.RId = Convert.ToInt64(dr["RId"].ToString());
                    objAsset.AssetId = Convert.ToInt64(dr["AssetId"].ToString());
                    objAsset.AssetName = dr["AssetName"].ToString();
                    objAsset.Quantity = Convert.ToInt32(dr["Quantity"].ToString());
                    objAsset.Description = (dr["Description"] != DBNull.Value ? dr["Description"].ToString() : null);
                    objAsset.OwnerBy = (dr["OwnerBy"] != DBNull.Value ? dr["OwnerBy"].ToString() : null);
                    objAsset.IsActive = Convert.ToBoolean(dr["IsActive"]);
                    objAsset.Name = (dr["Name"] != DBNull.Value ? dr["Name"].ToString() : null);
                    objAsset.Email = (dr["Email"] != DBNull.Value ? dr["Email"].ToString() : null);
                    objAsset.PhoneNo = (dr["PhoneNo"] != DBNull.Value ? dr["PhoneNo"].ToString() : null);
                    objAsset.UpdatedBy = dr["UpdatedBy"].ToString();
                    objAsset.UpdatedTime = Convert.ToDateTime(dr["UpdatedTime"].ToString());

                    lstAsset.Add(objAsset);
                }
            }
            return lstAsset;
        }

        #endregion
    }
}
