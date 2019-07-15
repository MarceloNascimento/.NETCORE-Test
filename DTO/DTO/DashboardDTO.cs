using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DashboardDTO
    {
        public List<KPIs> Kpis { get; set; }

        public List<Machine> Machines { get; set; }

        public List<Programs> Programs { get; set; }
    }
}
