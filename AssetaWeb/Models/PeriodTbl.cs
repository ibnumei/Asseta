using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class PeriodTbl
    {
        public long PeriodId { get; set; }
        public string PeriodType { get; set; }
        public int? Days { get; set; }
        public DateTime? CreatedAtPeriod { get; set; }
        public DateTime? ModifyAtPeriod { get; set; }


        public virtual ICollection<ScheduleMaintenanceTbl> ScheduleMaintenanceTbls { get; set; }
    }
}
