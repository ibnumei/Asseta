﻿using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class AssetGroupTbl
    {
        public long AssetGroupId { get; set; }
        public string AssetGroupCode { get; set; }
        public string AssetGroupName { get; set; }
        public DateTime? CreatedAtAssetGroup { get; set; }
        public DateTime? ModifyAtAssetGroup { get; set; }

        public virtual ICollection<AssetTbl> ASSET { get; set; }
        public virtual ICollection<TaskTbl> Tasks { get; set; }
    }
}
