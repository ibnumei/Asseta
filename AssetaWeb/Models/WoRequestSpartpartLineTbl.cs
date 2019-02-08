using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class WoRequestSpartpartLineTbl
    {
        public long Id { get; set; }
        public long? WoRequestId { get; set; }
        public long? SparepartId { get; set; }
        public int? Quantity { get; set; }

        public virtual SparepartTbl Sparepart { get; set; }
    }
}
