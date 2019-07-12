using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
   public interface IClientDTO
    {
        string MachineName { get; set; }
        DateTime DateHours { get; set; }
        List<string> ProgramsList { get; set; }
    }
}
