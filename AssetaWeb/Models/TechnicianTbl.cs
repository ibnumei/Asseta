using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class TechnicianTbl
    {
        public long TechnicianId { get; set; }
        public string TechnicianName { get; set; }
        public DateTime? CreatedAtTech { get; set; }
        public DateTime? ModifyAtTech { get; set; }

        public virtual ICollection<ScheduleMaintenanceTbl> ScheduleMaintenanceTbls { get; set; }
    }
}
