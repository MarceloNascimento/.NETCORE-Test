using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Machine
    {
        public Machine()
        {
            Programs = new HashSet<Program>();
        }

        public int IdMachine { get; set; }
        public string DsName { get; set; }
        public DateTime? DtDatehours { get; set; }

        public virtual ICollection<Program> Programs { get; set; }
    }
}