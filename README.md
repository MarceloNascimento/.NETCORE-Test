# .NETCORE-Test installation instructions
# @Author Marcelo Rocha


Please to install this solution will need to create the database in sql server 2017 as name  DBMONITORS
CREATE DATABASE DBMONITORS;
and next step run script sql in path Singular\Database Scripts\DDL.sql 

Pay attention in to fk in the end of this project, will be need match table Program with Machines

After these step will be need to generate instaltion for windows service ( Client and processer );
The next step will be need configure the webAPI adrress url in two files:
- DashboardServices ( line 24 in webApp )
- App.Config from ClientWinService ( line 4)

To conclude these test only will be need to running.

Obs.: These solution login to go production enviroment will recommend JWT or Owin tokens to grant claims for pages.
These project was developing only for knowlodges, not for commercial, to contract me i recommend a conversation after see these.

contact: marcelo.analistadesistemas@gmail.com


