using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WoExeTaskTbl
    {
        public long Id { get; set; }
        public long? WoExeId { get; set; }
        public string TaskCode { get; set; }
        public string Detail { get; set; }
        public string TaskType { get; set; }
        public string TypeGeneral { get; set; }
        public string TypeYesNo { get; set; }
    }
}
