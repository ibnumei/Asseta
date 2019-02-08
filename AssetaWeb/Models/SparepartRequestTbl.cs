using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class SparepartRequestTbl
    {
        public long Id { get; set; }
        public string Availability { get; set; }
        public string SparepartRequestId { get; set; }
        public long? WoId { get; set; }
        public string WoDesc { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public long? SiteId { get; set; }
        public int? Qty { get; set; }
        public string Notes { get; set; }
        public string WorId { get; set; }
    }
}
