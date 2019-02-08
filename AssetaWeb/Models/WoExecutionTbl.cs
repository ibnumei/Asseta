using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WoExecutionTbl
    {
        public long Id { get; set; }
        public string WorkExeId { get; set; }
        public long? WoId { get; set; }
        public string WoDesc { get; set; }
        public DateTime? Date { get; set; }
        public long? TechnicianId { get; set; }
        public string Status { get; set; }
        public long? SiteId { get; set; }
        public long? MaintenanceId { get; set; }
        public long? RequestId { get; set; }
    }
}
