using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WoExceTbl
    {
        public long WoExeId { get; set; }
        public long? WoId { get; set; }
        public long? TechId { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
