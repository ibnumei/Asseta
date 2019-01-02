using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class ScheduleMaintenanceTbl
    {
        public long ScheduleMainId { get; set; }
        public long? AssetId { get; set; }
        public string MaintenanceId { get; set; }
        public string MaintenanceDesc { get; set; }
        public long? SiteId { get; set; }
        public DateTime? LastMaintenance { get; set; }
        public DateTime? NextMaintenance { get; set; }
        public string CreateBy { get; set; }
        public string LastEditedBy { get; set; }
        public long? PeriodId { get; set; }
        public long? SparepartId { get; set; }
        public decimal? Quantity { get; set; }
        public long? TaskId { get; set; }
        public string TaskDetail { get; set; }
        public int? EstimatedTime { get; set; }
        public long? TechnicianId { get; set; }
        public string Schedule { get; set; }
        public string AssetName { get; set; }

        public virtual AssetTbl ASSETS { get; set; }
      //  public virtual MaentenanceTbl MaentenanceTbl { get; set; }
        public virtual SiteMasterTbl SITES { get; set; }
        public virtual PeriodTbl PERIODS { get; set; }
        public virtual SparepartTbl SPAREPARTS { get; set; }
        public virtual TaskTbl TASKS { get; set; }
        public virtual TechnicianTbl TECHNICIANS { get; set; }
    }
}
