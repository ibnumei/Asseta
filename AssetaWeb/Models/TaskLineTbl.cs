using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class TaskLineTbl
    {
        public long Id { get; set; }
        public string TaskCode { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
    }
}
