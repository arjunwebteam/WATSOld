using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WATS.Entities
{
    public class RegisterFields
    {
        public Int64 RId { get; set; }
        public Int64 RegisterFieldId { get; set; }
        public Int64 EventId { get; set; }
        public string EventName { get; set; }
        public string Name { get; set; }
        public string HelpText { get; set; }
        public string QuestionType { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsRequired { get; set; }
        public string ValidationType { get; set; }
        public string Options { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }

        public List<RegisterOptions> lstRegisterOptions = new List<RegisterOptions>();
    }
}
