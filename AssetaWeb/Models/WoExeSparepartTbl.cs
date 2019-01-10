using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WoExeSparepartTbl
    {
        public long Id { get; set; }
        public long? WoExeId { get; set; }
        public long? SparepartId { get; set; }
        public string SparepartCode { get; set; }
        public decimal? Quantity { get; set; }
    }
}
