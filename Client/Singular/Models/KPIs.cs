using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class KPIs
    {
        
        public string machine_name { get; set; }
        public int machines_ok { get; set; }
        public int machines_alert { get; set; }
        public int machines_offline { get; set; }
        
    }
}
