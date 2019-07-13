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

