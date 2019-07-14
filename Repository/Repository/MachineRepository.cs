
namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Text;
    using Dapper;
    using DTO;

    public class MachineRepository : IMachineRepository
    {
        public string connectionString = "Server=localhost,1401;Database=DBMONITORS;User Id=monitor;Password=Q!W@e3r4;";

        public IList<Machine> Select()
        {

            IList<Machine> machines = new List<Machine>();

            using (var connection = new SqlConnection(connectionString))
            {
                machines = connection.Query<Machine>(@"SELECT m.*,p.ds_name programs FROM Machines m
                    LEFT JOIN Programs p ON p.machine_id = m.id_machine
                    ORDER BY m.ds_name;").ToList(); 
               
            }

            return machines;
        }


        public int Insert(ClientDTO machine = null)
        {
            using (var connection = new SqlConnection(connectionString))
            {                
                int result = connection.Execute(@"INSERT Machines (ds_name, dt_datehours)
                                    VALUES (@MachineName, @DateHours)", machine);
                return result;
            }

        }


        public int Update(ClientDTO client)
        {
            if (client.Id > 0)
                using (var conexaoBD = new SqlConnection(connectionString))
                {
                    var sql = @" UPDATE Machines SET ds_name = @MachineName,  dt_datehours = @DateHours
                WHERE id_machine = @Id";
                    int result = conexaoBD.Execute(sql, client);

                    return result;
                }
            else { return 0; }
        }
    }
}
