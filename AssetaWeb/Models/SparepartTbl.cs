using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class SparepartTbl
    {
        public long SparepartId { get; set; }
        public long? SupplierId { get; set; }
        public long? SiteId { get; set; }
        public string SparepartCode { get; set; }
        public string SparepartDesc { get; set; }
        public long? Qty { get; set; }
        public string UoM { get; set; }
        public long? SafetyStock { get; set; }
        public DateTime? CreatedAtSupp { get; set; }
        public DateTime? ModifyAtSupp { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }

        public virtual SupplierTbl Supplier { get; set; }
        public virtual SiteMasterTbl SiteMaster { get; set; }
    }
}
