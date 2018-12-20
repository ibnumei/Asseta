using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class SiteMasterTbl
    {
        public long SiteId { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string Address { get; set; }
        public string Company { get; set; }
        public DateTime? CreatedAtSite { get; set; }
        public DateTime? ModifyAtSite { get; set; }


        public virtual ICollection<AssetTbl> ASSET { get; set; }

        public virtual ICollection<EntityTbl> Entities { get; set; }

        public virtual ICollection<SparepartTbl> Spareparts { get; set; }
    }
}
