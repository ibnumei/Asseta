using System;
using System.Collections.Generic;

namespace AssetaWeb.Models
{
    public partial class LoginTbl
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
