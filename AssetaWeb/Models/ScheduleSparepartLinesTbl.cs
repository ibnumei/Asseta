using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class ScheduleSparepartLinesTbl
    {
        public long Id { get; set; }
        public long? ScheduleMainId { get; set; }
        public long? SparepartId { get; set; }
        public decimal? Quantity { get; set; }

        public virtual SparepartTbl Sparepart { get; set; }

      //  public virtual ICollection<ScheduleMaintenanceTbl> ScheduleMaintenanceTbls { get; set; }
    }
}
