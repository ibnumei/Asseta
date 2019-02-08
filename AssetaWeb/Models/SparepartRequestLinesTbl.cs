using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class SparepartRequestLinesTbl
    {
        public int Id { get; set; }
        public long? WoId { get; set; }
        public long? SprId { get; set; }
        public long? SparepartId { get; set; }
        public string SparepartCode { get; set; }
        public int? Quantity { get; set; }
        public int? Quantity2 { get; set; }

        public virtual SparepartTbl Sparepart { get; set; }
    }
}
