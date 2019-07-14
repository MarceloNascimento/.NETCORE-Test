using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IMachineRepository
    {
        int Insert(ClientDTO machine);
        int Update(ClientDTO client);

    }
}
