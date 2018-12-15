using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class MaentenanceTbl
    {
        public long MaentenanceId { get; set; }
        public long? TechnicianId { get; set; }
        public long? AssetId { get; set; }
        public long? TaskId { get; set; }
        public long? PeriodId { get; set; }
        public string MaentenanceCode { get; set; }
        public string MaentenanceDesc { get; set; }
        public DateTime? LastDate { get; set; }
        public DateTime? NextDate { get; set; }
        public long? SparepartId { get; set; }
        public decimal? CostMaentenance { get; set; }
        public string CreatedBy { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifyAt { get; set; }
    }
}
