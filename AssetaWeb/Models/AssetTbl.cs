using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class AssetTbl
    {
        public long AssetId { get; set; }
        public long? AssetGroupId { get; set; }
        public long? SiteId { get; set; }
        public long? EntityId { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string SerialNumber { get; set; }
        public DateTime? ValidityDate { get; set; }
        public string Location { get; set; }
        public string Valuation { get; set; }
        public DateTime? CreatedAtAsset { get; set; }
        public DateTime? ModifyAtAsset { get; set; }

        public virtual SiteMasterTbl SITE { get; set; }
    }
}
