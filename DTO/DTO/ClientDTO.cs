
namespace DTO
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class ClientDTO : IClientDTO
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public DateTime  DateHours { get; set; }
        public List<string> ProgramsList { get; set; }
    }
}
