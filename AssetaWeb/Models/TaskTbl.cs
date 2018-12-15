using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class TaskTbl
    {
        public long TaskId { get; set; }
        public long? AssetGroupId { get; set; }
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
        public string TaskDetail { get; set; }
        public string TaskType { get; set; }
        public int? TimeEstimate { get; set; }
        public DateTime? CreatedAtTask { get; set; }
        public DateTime? ModifyAtTask { get; set; }
    }
}
