using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WoRequestTbl
    {
        public long Id { get; set; }
        public string RequestId { get; set; }
        public string RequestDesc { get; set; }
        public long? SiteId { get; set; }
        public long? LocationId { get; set; }
        public long? AssetId { get; set; }
        public string AssetDesc { get; set; }
        public DateTime? Date { get; set; }
        public string Status { get; set; }
    }
}
