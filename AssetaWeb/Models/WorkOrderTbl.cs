using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WorkOrderTbl
    {
        public long WoId { get; set; }
        public long? MaentenanceId { get; set; }
        public long? AssetId { get; set; }
        public long? SiteId { get; set; }
        public long? TechId { get; set; }
        public string WoDesc { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Notes { get; set; }
        public DateTime? CreatedAtWo { get; set; }
        public DateTime? ModifyAtWo { get; set; }
    }
}
