using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IClientRepository
    {
        ClientDTO dto { get; set; }
        void InstalledsPrograms();
        void MachineName();
        void TimerInformations();

    }
}
