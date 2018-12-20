using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class SupplierTbl
    {
        public long SupplierId { get; set; }
        public string SupplierCode { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string ProductData { get; set; }
        public DateTime? CreatedAtSupplier { get; set; }
        public DateTime? ModifyAtSupplier { get; set; }

        public virtual ICollection<SparepartTbl> Spareparts { get; set; }
    }
}
