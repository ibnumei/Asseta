using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class EntityTbl
    {
        public long EntityId { get; set; }
        public long? SiteId { get; set; }
        public string EntityCode { get; set; }
        public string EntityName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Pic { get; set; }
        public DateTime? CreatedAtEntity { get; set; }
        public DateTime? ModifyAtEntity { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }

        public virtual ICollection<AssetTbl> ASSET { get; set; }
    }
}
