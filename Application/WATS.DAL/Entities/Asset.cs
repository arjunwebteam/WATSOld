using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WATS.Entities
{
    public class Asset
    {

        public Int64 RId { get; set; }

        public Int64 AssetId { get; set; }

        public String AssetName { get; set; }

        public Int32 Quantity { get; set; }

        public string Description { get; set; }

        public string OwnerBy { get; set; }

        public bool IsActive { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

    }
}
