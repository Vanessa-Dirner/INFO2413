-- ---------Create the Database----------
create database project;

-- -----Select thet database for use-----
use project;

-- ---------Create the tables------------
CREATE TABLE inventory (
    batch CHAR(6) NOT NULL,
    expirationdate DATE NOT NULL ,
    quantity VARCHAR(5) NOT NULL ,
    seedtype CHAR(15) NOT NULL,
    seedname CHAR(20) NOT NULL ,
    plantingtime CHAR(10) NOT NULL ,
    PRIMARY KEY (batch)
);


CREATE TABLE waste (
	batch CHAR(4) NOT NULL,
    seedtype CHAR(10) NOT NULL,
    seedname VARCHAR(15) NOT NULL ,
    quantity VARCHAR(9) NOT NULL ,
    expirationdate DATE NOT NULL ,
    PRIMARY KEY (batch)
);
 

CREATE TABLE vendor (
    batch CHAR(4) NOT NULL,
    expirationdate DATE NOT NULL ,
    vendorname CHAR(4) NOT NULL,
    seedtype VARCHAR(25) NOT NULL ,
    seedname VARCHAR(20) NOT NULL ,
    quantityavailable CHAR(7) NOT NULL ,
    PRIMARY KEY (batch, vendorname)
);


CREATE TABLE staff (
    userid CHAR(6) NOT NULL,
    fName VARCHAR(10) NOT NULL ,
    lName VARCHAR(10) NOT NULL ,
    jobrole VARCHAR(10) NOT NULL ,
    email CHAR(20),
    isactive DATE,
    startsate DATE,
    enddate DATE,
    username VARCHAR(50),
    passkey CHAR(4) NOT NULL,
    PRIMARY KEY (userid)
);


-- -----Some useful commands about tables------
  SHOW tables;
 
  describe vendor;
  describe Staff;
    describe waste;
  describe inventory;
 
  show create table vendor;
 
  -- ------------------Fill the Tables------------------
  insert into inventory (batch, expirationdate, quantity, seedtype, seedname, plantingtime)
  values ('B0001', '2022-01-10'  ,'05000'  , 'Sunflower', 'Titan', 'Spring' ),
         ('B0002', '2021-07-22'  ,'10000'  , 'Tomato', 'Power Pops', 'Spring'),
         ('B0003', '2022-01-10'  ,'05000'  , 'Apple', 'Captain Kidd', 'Spring'),
         ('B0004', '2022-01-10'  ,'05000'  , 'Grape', 'Moon Drops', 'Spring'),
         ('B0005', '2022-01-10'  ,'05000'  , 'Blueberry', 'Top Hat', 'Winter');
 
 

 drop database project;