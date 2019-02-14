using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetaWeb.Models
{
    public class WoExeAndWoExeTask
    {
        public WoExecutionTbl WoExecution { get; set; }
        public List<WoExeTaskTbl> WoExeTask { get; set; }
        public WoExeTaskTbl noListWoTask { get; set; }
    }
}
