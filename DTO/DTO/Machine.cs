
namespace DTO
{
    using System;
    using System.Collections.Generic;

    [Serializable]
    public class Machine
    {
        public int Id { get; set; }
        public string ds_name { get; set; }
        public DateTime dt_datehours { get; set; }
        public List<string> programs { get; set; }
    }
}
