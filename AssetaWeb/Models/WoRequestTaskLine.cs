using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WoRequestTaskLine
    {
        public long Id { get; set; }
        public string TaskDetail { get; set; }
        public long? TaskId { get; set; }
        public long? TechnicianId { get; set; }
        public string Kolomtambahan { get; set; }
        public long? WoRequestId { get; set; }
    }
}
