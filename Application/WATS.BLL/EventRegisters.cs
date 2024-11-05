using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.BLL
{
    public class EventRegisters
    {
        DAL.EventRegisters _eventregisters = new DAL.EventRegisters();

        #region Methods

        public Int64 InsertEventReigisters(Entities.EventRegisters objEventRegisters, ref Int64 EventRegisterId)
        {
            Int64 _status = 0;
            if (objEventRegisters != null)
            {
                _status = _eventregisters.InsertEventReigisters(objEventRegisters, ref EventRegisterId);
            }
            return _status;
        }

        public Int64 InsertEventReigisterAnswers(Entities.RegisterAnswer objRegisterAnswer)
        {
            Int64 _status = 0;
            if (objRegisterAnswer != null)
            {
                _status = _eventregisters.InsertEventReigisterAnswers(objRegisterAnswer);
            }
            return _status;
        }

        public Int64 BulkInsertEventReigisterAnswers(string AnswersXml)
        {
            Int64 _status = 0;
            if (AnswersXml != null && AnswersXml.Trim() != "")
            {
                _status = _eventregisters.BulkInsertEventReigisterAnswers(AnswersXml);
            }
            return _status;
        }

        public Int64 BulkInsertEventMembers(string MembersXml)
        {
            Int64 _status = 0;
            if (MembersXml != null && MembersXml.Trim() != "")
            {
                _status = _eventregisters.BulkInsertEventMembers(MembersXml);
            }
            return _status;
        }

        #endregion
    }
}
