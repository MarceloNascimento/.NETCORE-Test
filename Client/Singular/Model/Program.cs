using System;
using System.Collections.Generic;

namespace Model
{
    public partial class Program
    {
        public int IdPrograms { get; set; }
        public string DsName { get; set; }
        public int MachineId { get; set; }

        public virtual Machine Machine { get; set; }
    }
}