using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class RegisterFields
    {
        DAL.RegisterFields _register = new DAL.RegisterFields();

        #region Method

        public Int64 DeleteRegisterFields(Int64 RegisterFieldsId)
        {
            Int64 _status = 0;
            if (RegisterFieldsId != 0)
            {
                _status = _register.DeleteRegisterFields(RegisterFieldsId);
            }
            return _status;
        }

        public Int64 DeleteRegisterOption(Int64 RegisterOptionId)
        {
            Int64 _status = 0;
            if (RegisterOptionId != 0)
            {
                _status = _register.DeleteRegisterOptions(RegisterOptionId);
            }
            return _status;
        }

        public Int64 InsertRegisterFields(Entities.RegisterFields objRegisterFields)
        {
            Int64 _status = 0;
            if (objRegisterFields != null)
            {
                _status = _register.InsertRegisterFields(objRegisterFields);
            }
            return _status;
        }

        #endregion

        #region Entity

        public Entities.RegisterFields GetRegisterFieldsById(Int64 RegisterFieldsId, ref int status)
        {
            DataSet ds = _register.GetRegisterFieldsById(RegisterFieldsId, ref status);

            Entities.RegisterFields objRegisterField = new Entities.RegisterFields();
            if (ds.Tables.Count == 2)
            {
                if (ds.Tables[0].Rows.Count == 1)
                {
                    objRegisterField.RegisterFieldId = Convert.ToInt64(ds.Tables[0].Rows[0]["RegisterFieldId"]);
                    objRegisterField.EventId = Convert.ToInt64(ds.Tables[0].Rows[0]["EventId"]);
                    objRegisterField.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    objRegisterField.HelpText = ds.Tables[0].Rows[0]["HelpText"].ToString();
                    objRegisterField.QuestionType = ds.Tables[0].Rows[0]["QuestionType"].ToString();
                    objRegisterField.DisplayOrder = Convert.ToInt32(ds.Tables[0].Rows[0]["DisplayOrder"]);
                    objRegisterField.IsRequired = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsRequired"]);
                    objRegisterField.ValidationType = ds.Tables[0].Rows[0]["ValidationType"].ToString();
                    objRegisterField.UpdatedBy = ds.Tables[0].Rows[0]["UpdatedBy"].ToString();

                    if (ds.Tables[1].Rows.Count != 0)
                    {
                        foreach (DataRow dr in ds.Tables[1].Rows)
                        {
                            Entities.RegisterOptions objRegisterOptions = new Entities.RegisterOptions();
                            if (Convert.ToInt64(dr["RegisterFieldId"]) == objRegisterField.RegisterFieldId)
                            {
                                objRegisterOptions.RegisterOptionId = Convert.ToInt64(dr["RegisterOptionId"]);
                                objRegisterOptions.RegisterFieldId = Convert.ToInt64(dr["RegisterFieldId"]);
                                objRegisterOptions.QOption = dr["Name"].ToString();

                                objRegisterField.lstRegisterOptions.Add(objRegisterOptions);
                            }
                        }
                    }                 
                }
            }
            return objRegisterField;
        }

        public List<Entities.RegisterFields> GetRegisterFieldsList(Int64 EventId, ref int status)
        {
            DataSet ds = _register.GetRegisterFieldsList(EventId, ref status);

            List<Entities.RegisterFields> lstRegisterFields = new List<Entities.RegisterFields>();
            if (ds.Tables.Count == 2)
            {
                if (ds.Tables[0].Rows.Count != 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Entities.RegisterFields objRegisterField = new Entities.RegisterFields();
                        objRegisterField.RegisterFieldId = Convert.ToInt64(dr["RegisterFieldId"]);
                        objRegisterField.EventId = Convert.ToInt64(dr["EventId"]);
                        objRegisterField.Name = dr["Name"].ToString();
                        objRegisterField.HelpText = dr["HelpText"].ToString();
                        objRegisterField.QuestionType = dr["QuestionType"].ToString();
                        objRegisterField.DisplayOrder = Convert.ToInt32(dr["DisplayOrder"]);
                        objRegisterField.IsRequired = Convert.ToBoolean(dr["IsRequired"]);
                        objRegisterField.ValidationType = dr["ValidationType"].ToString();
                        objRegisterField.UpdatedBy = dr["UpdatedBy"].ToString();

                        if (ds.Tables[1].Rows.Count != 0)
                        {
                            foreach (DataRow dr2 in ds.Tables[1].Rows)
                            {
                                Entities.RegisterOptions objRegisterOptions = new Entities.RegisterOptions();
                                if (Convert.ToInt64(dr2["RegisterFieldId"]) == objRegisterField.RegisterFieldId)
                                {
                                    objRegisterOptions.RegisterOptionId = Convert.ToInt64(dr2["RegisterOptionId"]);
                                    objRegisterOptions.RegisterFieldId = Convert.ToInt64(dr2["RegisterFieldId"]);
                                    objRegisterOptions.QOption = dr2["Name"].ToString();

                                    objRegisterField.lstRegisterOptions.Add(objRegisterOptions);
                                }
                            }
                        }
                        lstRegisterFields.Add(objRegisterField);
                    }
                }
            }
            return lstRegisterFields;
        }

        #endregion
    }
}
