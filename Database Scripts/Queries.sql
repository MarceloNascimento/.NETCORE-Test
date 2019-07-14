    SELECT m.*,p.ds_name programs FROM Machines m
    LEFT JOIN Programs p ON p.machine_id = m.id_machine
    ORDER BY m.ds_name;


Quantidade de máquinas online (que se comunicaram dentro do espaço
de tempo limite)

 Quantidade de máquinas em alerta (que se comunicaram dentro do
espaço de tempo limite * 1.5)

 Quantidade de máquinas offline (que se comunicaram a mais do que o
espaço de tempo limite * 1.5)

 Tabela com as top 10 máquinas que não se comunicam com o servidor a
mais tempo

 Tabela com as top 10 aplicações com menos ocorrências em máquinas

 
----- Query to Machines KPIs ----------  
   SELECT *   
    FROM 
   (SELECT (m.ds_name) machine_name,    
        SUM(CASE WHEN ( (DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) > 0) AND (DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) = 1 )) THEN 1 ELSE 0 END) machines_ok, -- Time limit
        SUM(CASE WHEN ( (DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) > 1) AND CAST((DATEDIFF(SECOND,m.dt_datehours,ms.dt_datehours))/60  AS DECIMAL(6, 1)) < 1.5)  THEN 1 ELSE 0 END) machines_alert, -- Time limit
        SUM(CASE WHEN ( CAST((DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours))/60  AS DECIMAL(6, 1)) > 1.5)  THEN 1 ELSE 0 END) machines_offline -- Time limit
       
    FROM Machines m,Machines ms
     WHERE ms.ds_name = m.ds_name
   GROUP BY m.ds_name) AS Machines
 
  ------------------   Query top 10 Machines --------------------
SELECT DISTINCT(MA.ds_name),TMP FROM (
SELECT  TOP 10
 (CASE WHEN (CAST(DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) AS DECIMAL(6, 1)) > 0 )
  THEN (CAST(DATEDIFF(MINUTE,m.dt_datehours,ms.dt_datehours) AS DECIMAL(6, 1))) ELSE 0 END) AS TMP,
 ms.ds_name
    FROM Machines  ms, Machines m 
WHERE ms.ds_name = m.ds_name 
ORDER BY TMP DESC ) MA


  ------------------   Query top 10 Programs --------------------
SELECT TOP 10 (p.ds_name) program_name,
 SUM(CASE WHEN (pr.ds_name = p.ds_name) THEN 1 ELSE 0 END) program_counter -- Time limit
   FROM Programs pr, Programs p 
WHERE pr.ds_name = p.ds_name
 GROUP BY p.ds_name
ORDER BY program_counter DESC




