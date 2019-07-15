------------------ DDL Monitors Database -------------------------
Use  DBMONITORS;

-- Create table users
CREATE TABLE Users (
    id_user int IDENTITY(1,1)  NOT NULL,
    ds_fullname varchar(255),
    ds_login varchar(255),
    ds_password varchar(255),
     PRIMARY KEY (id_user), 
);

-- Create table Machines
CREATE TABLE Machines (
    id_machine int IDENTITY(1,1) NOT NULL,
    ds_name varchar(255),
    dt_datehours DateTime,
    PRIMARY KEY (id_machine),     
);

-- Create table MaPrograms from machines
CREATE TABLE Programs (

    id_programs int IDENTITY(1,1) NOT NULL,
    ds_name varchar(255),
    machine_id int NOT NULL,
    PRIMARY KEY (id_programs),
    CONSTRAINT fk_machine_id FOREIGN KEY (machine_id)
    REFERENCES Machines(id_machine)      
);



--------------------------- DML basics running system ------------------------
Delete from Machines;
Delete from Programs;

INSERT Machines (ds_name, dt_datehours)  VALUES ('mac-xpto-172',  CONVERT(datetime, '2019-07-13T22:09:38.544', 126));
INSERT Machines (ds_name, dt_datehours)  VALUES ('mac-xpto-172',  CONVERT(datetime, '2019-07-13T22:08:38.544', 126));

INSERT Machines (ds_name, dt_datehours)  VALUES ('mac-xpto-173',  CONVERT(datetime, '2019-07-13T22:09:38.544', 126));
INSERT Machines (ds_name, dt_datehours)  VALUES ('mac-xpto-173',  CONVERT(datetime, '2019-07-13T22:08:38.544', 126));

INSERT Machines (ds_name, dt_datehours)  VALUES ('mac-xpto-172',  CONVERT(datetime, '2019-07-13T22:09:38.544', 126));
INSERT Machines (ds_name, dt_datehours)  VALUES ('mac-xpto-172',  CONVERT(datetime, '2019-07-13T22:08:38.544', 126));

INSERT Machines (ds_name, dt_datehours)  VALUES ('xyz-22-rbt',  CONVERT(datetime, '2019-07-14T13:57:39.953', 126));

INSERT Programs (ds_name, machine_id)  VALUES ('7 zip', 1);
INSERT Programs (ds_name, machine_id)  VALUES ('7 zip', 2);
INSERT Programs (ds_name, machine_id)  VALUES ('7 zip', 3);
INSERT Programs (ds_name, machine_id)  VALUES ('win rar', 4);
INSERT Programs (ds_name, machine_id)  VALUES ('oracle client', 4);


INSERT Users (ds_fullname, ds_login,ds_password)  VALUES ('Sr. Godofredo Vacario', 'Admin', HashBytes('MD5', 'Test'));