
namespace Repository
{
    using Dapper;
    using DTO;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;

    public class MachineRepository : IMachineRepository
    {
        public string connectionString = "Server=localhost,1401;Database=DBMONITORS;User Id=monitor;Password=Q!W@e3r4;";

     


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



        public int Insert(ClientDTO machine = null)
        {
            int result = 0;


            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        result = connection.Execute(@"INSERT Machines (ds_name, dt_datehours)
                                    VALUES (@MachineName, @DateHours)", machine, transaction);
                        transaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        // roll the transaction back
                        transaction.Rollback();
                        throw new Exception("There was a network problem, please contact your it support. "
                            + " - " + ex.Message.ToString());
                    }
                }
                return result;

            }

        }



        public IList<Machine> SelectTop10Machines()
        {

            IList<Machine> machines = new List<Machine>();

            using (var connection = new SqlConnection(connectionString))
            {
                machines = connection.Query<Machine>(@"SELECT  TOP 10
                 (CASE WHEN (CAST(DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) AS DECIMAL(6, 1)) > 0 )
                  THEN (CAST(DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) AS DECIMAL(6, 1))) ELSE 0 END) AS TMP,
                   ms.ds_name
                    FROM Machines  ms, Machines m 
                WHERE ms.ds_name = m.ds_name 
                ORDER BY TMP DESC ) MA").ToList();

            }

            return machines;
        }

        public IList<Programs> SelectTop10Programs()
        {

            IList<Programs> machines = new List<Programs>();

            using (var connection = new SqlConnection(connectionString))
            {
                machines = connection.Query<Programs>(@"SELECT TOP 10 (p.ds_name) program_name,
                 SUM(CASE WHEN (pr.ds_name = p.ds_name) THEN 1 ELSE 0 END) program_counter 
                WHERE pr.ds_name = p.ds_name
                 GROUP BY p.ds_name
                ORDER BY program_counter DESC").ToList();

            }

            return machines;
        }


        public IList<KPIs> SelectKPIs()
        {

            IList<KPIs> kpis = new List<KPIs>();

            using (var connection = new SqlConnection(connectionString))
            {
                kpis = connection.Query<KPIs>(@" SELECT *   
                FROM (SELECT (m.ds_name) machine_name,    
                    SUM(CASE WHEN ((DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) > 0) AND (DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) = 1 )) THEN 1 ELSE 0 END) machines_ok, -- Time limit
                    SUM(CASE WHEN ((DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) > 1) AND CAST((DATEDIFF(SECOND,m.dt_datehours,ms.dt_datehours))/60  AS DECIMAL(6, 1)) < 1.5)  THEN 1 ELSE 0 END) machines_alert, -- Time limit
                    SUM(CASE WHEN (CAST((DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours))/60  AS DECIMAL(6, 1)) > 1.5)  THEN 1 ELSE 0 END) machines_offline        
                FROM Machines m,Machines ms  WHERE ms.ds_name = m.ds_name
                GROUP BY m.ds_name) AS Machines").ToList();
            }

            return kpis;
        }




    }

}



