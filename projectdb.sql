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

 insert into inventory (batch, expirationdate, quantity, seedtype, seedname, plantingtime)
  values ('B0011', '2023-01-14'  ,'05000'  , 'Sunflower', 'Titan', 'Spring' ),
         ('B0012', '2022-07-22'  ,'10000'  , 'Tomato', 'Power Pops', 'Spring'),
         ('B0013', '2024-01-10'  ,'05000'  , 'Apple', 'Captain Kidd', 'Spring'),
         ('B0014', '2023-12-23'  ,'05000'  , 'Grape', 'Moon Drops', 'Spring'),
         ('B0015', '2022-04-20'  ,'05000'  , 'Blueberry', 'Top Hat', 'Winter');

CREATE TABLE waste (
	batch CHAR(4) NOT NULL,
    expirationdate DATE NOT NULL ,
    quantity VARCHAR(5) NOT NULL ,
    seedtype CHAR(15) NOT NULL,
    seedname CHAR(20) NOT NULL
    PRIMARY KEY (batch)
);
 
  insert into waste (batch, expirationdate, quantity, seedtype, seedname)
  values ('B0001', '2020-01-10'  ,'00125'  , 'Pear', 'Bosc', 'Winter' ),
         ('B0002', '2019-07-22'  ,'00608'  , 'Rhubarb', 'KangaRhu', 'Spring'),
         ('B0003', '2021-01-10'  ,'00005'  , 'Celery', 'Conquistador', 'Winter'),
         ('B0004', '2022-01-01'  ,'00473'  , 'Lemon', 'Eureka', 'Spring'),
         ('B0005', '2018-09-09'  ,'00201'  , 'Lemon', 'Baboon', 'Spring');

CREATE TABLE vendor (
    batch CHAR(4) NOT NULL,
    expirationdate DATE NOT NULL ,
    vendorname CHAR(4) NOT NULL,
    seedtype VARCHAR(25) NOT NULL ,
    seedname VARCHAR(20) NOT NULL ,
    quantityavailable CHAR(7) NOT NULL ,
    PRIMARY KEY (batch, vendorname)
);


  insert into vendor (batch, expirationdate, vendorname, seedtype, seedname, quantityavailable)
  values ('B0021', '2020-01-10'. 'West Coast Seeds' , 'Pear', 'Bosc', 'Winter' ),
         ('B0054' '2019-07-22', 'Canada Seed Company' , 'Sunflower', 'Titan', 'Spring'),
         ('B0572', '2021-01-10', 'Farm Direct Seeds' , 'Celery', 'Conquistador', 'Winter'),
         ('B0300', '2022-01-01' ,'Tropico' , 'Lemon', 'Eureka', 'Spring'),
         ('B0401', '2018-09-09', 'Tropico'  , 'Grape', 'Moon Drops', 'Spring');



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

  insert into staff (userid, fName, lName, jobrole, email, isactive, startsate, enddate, username, passkey)
  values ('ID001',  'Rocco', 'Briggs', 'Employee', 'RoccoBriggs@ptfarm.com', 'true', '2012-04-09', '', 'RocBri', 'sample' ),
         ('ID002',  'Yasin', 'Mann', 'Gardener', 'YasinMann@ptfarm.com', 'true', '2015-12-03', '', 'YasMan', 'sample')
         ('ID003', 'Glen', 'Carson', 'Gardener', 'GlenCarson@ptfarm.com', 'false', '2016-07-02', '2017-07-02', 'GleCar', ''),
         ('ID004', 'Oliver', 'Castillo', 'Administrator', 'OliverCastillo@ptfarm.com', 'true', '2020-06-06', '', 'OliCas', 'sample'),
         ('ID005', 'Keice', 'Lin', 'Employee', 'KeiceLin@ptfarm.com', 'true', '2010-05-17', '', 'KeiLin', 'sample');


-- -----Some useful commands about tables------
  SHOW tables;
 
  describe vendor;
  describe staff;
    describe waste;
  describe inventory;
 
  show create table vendor;
 
  -- ------------------Fill the Tables------------------
 
 


 drop database project;