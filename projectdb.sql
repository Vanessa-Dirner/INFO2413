
create database project;

use project;

CREATE TABLE inventory (
    batch CHAR(6) NOT NULL,
    aquirydate DATE NOT NULL,
    expirationdate DATE NOT NULL ,
    quantity VARCHAR(5) NOT NULL ,
    seedtype CHAR(15) NOT NULL,
    seedname CHAR(20) NOT NULL ,
    plantingtime CHAR(10) NOT NULL ,
    PRIMARY KEY (batch)
);

 insert into inventory (batch, aquirydate, expirationdate, quantity, seedtype, seedname, plantingtime)
  values ('B0011', '2021-01-14', '2023-01-14'  ,'05000'  , 'Harvested', 'Sunflower', 'Spring' ),
         ('B0012', '2020-07-22', '2022-07-22'  ,'10000'  , 'Bought', 'Tomato', 'Spring'),
         ('B0013', '2022-01-10', '2024-01-10'  ,'05000'  , 'Bought', 'Apple', 'Spring'),
         ('B0014', '2021-12-23', '2023-12-23'  ,'05000'  , 'Harvested', 'Grape', 'Spring'),
         ('B0015', '2020-04-20', '2022-04-20'  ,'05000'  , 'Harvested', 'Blueberry', 'Winter'),
         ('B0021', '2018-01-10', '2020-01-10'  ,'10000'  , 'Harvested','Pear', 'Summer' ),
         ('B0054', '2017-09-12', '2019-07-22'  ,'01843'  , 'Sunflower', 'Titan', 'Winter'),
         ('B0572', '2019-01-01', '2021-01-10'  ,'24052'  , 'Bought', 'Celery', 'Winter'),
         ('B0300', '2020-01-05', '2021-01-01'  ,'05921'  , 'Bought', 'Lemon', 'Summer'),
         ('B0401', '2021-02-03', '2024-09-09'  ,'68032'  , 'Harvested','Grape', 'Autumn');


CREATE TABLE planted (
    batch CHAR(6) NOT NULL,
    dateplanted DATE NOT NULL,
    quantity VARCHAR(5) NOT NULL ,
    seedtype CHAR(15) NOT NULL,
    seedname CHAR(20) NOT NULL ,
    plantedby CHAR(30) NOT NULL,
    PRIMARY KEY (batch, dateplanted, plantedby)
);

 insert into planted (batch, dateplanted, quantity, seedtype, seedname, plantedby)
  values ('B0011', '2023-01-14'  ,'05000'  , 'Harvested', 'Sunflower', 'YasMan' ),
         ('B0012', '2022-07-22'  ,'10000'  , 'Bought', 'Tomato', 'GleCar'),
         ('B0013', '2024-01-10'  ,'05000'  , 'Bought', 'Apple', 'YasMan'),
         ('B0014', '2023-12-23'  ,'05000'  , 'Harvested', 'Grape', 'YasMan'),
         ('B0015', '2022-04-20'  ,'05000'  , 'Harvested', 'Blueberry', 'YasMan'),
         ('B0021', '2020-01-10'  ,'10000'  , 'Harvested','Pear', 'YasMan' ),
         ('B0054', '2019-07-22'  ,'01843'  , 'Sunflower', 'Titan', 'YasMan'),
         ('B0572', '2021-01-10'  ,'24052'  , 'Bought', 'Celery', 'GleCar'),
         ('B0300', '2022-01-01'  ,'05921'  , 'Bought', 'Lemon', 'GleCar'),
         ('B0401', '2018-09-09'  ,'68032'  , 'Harvested','Grape', 'GleCar');


CREATE TABLE waste (
    wasteid CHAR(5) NOT NULL, 
  	batch CHAR(5) NOT NULL,
    expirationdate DATE NOT NULL ,
    quantity VARCHAR(5) NOT NULL ,
    seedtype CHAR(15) NOT NULL,
    seedname CHAR(20) NOT NULL,
    PRIMARY KEY (wasteid)
    );
 
  insert into waste (wasteid, batch, expirationdate, quantity, seedtype, seedname)
  values ('w001', 'B0001', '2020-01-10'  ,'00125' , 'Harvested' , 'Pear'),
         ('w002','B0002', '2019-07-22'  ,'00608' ,'Harvested' , 'Rhubarb'),
         ('w003','B0003', '2021-01-10'  ,'00005' ,'Harvested' , 'Celery'),
         ('w004','B0004', '2022-01-01'  ,'00473', 'Bought' , 'Lemon'),
         ('w005', 'B0005', '2018-09-09'  ,'00201', 'Bought'  , 'Lemon'); 



CREATE TABLE staff (
    userid CHAR(6) NOT NULL,
    fName VARCHAR(10) NOT NULL ,
    lName VARCHAR(10) NOT NULL ,
    jobrole VARCHAR(15) NOT NULL ,
    email CHAR(35),
    isactive BIT,
    startsate DATE,
    enddate DATE,
    username VARCHAR(50),
    passkey CHAR(14) NOT NULL,
    PRIMARY KEY (userid)
);

  insert into staff (userid, fName, lName, jobrole, email, isactive, startsate, enddate, username, passkey)
  values ('ID001', 'Rocco', 'Briggs', 'Employee', 'RBriggs@ptfarm.com', 'true', '2012-04-09', NULL, 'RocBri', 'sample' ),
         ('ID002', 'Yasin', 'Mann', 'Gardener', 'YMann@ptfarm.com', 'true', '2015-12-03', NULL, 'YasMan', 'sample'),
         ('ID003', 'Glen', 'Carson', 'Gardener', 'GCarson@ptfarm.com', 'false', '2016-07-02', '2017-07-02', 'GleCar', 'sample'),
         ('ID004', 'Oliver', 'Castillo', 'Administrator', 'OCastillo@ptfarm.com', 'true', '2020-06-06', '', 'OliCas', 'sample'),
         ('ID005', 'Keice', 'Lin', 'Employee', 'KLin@ptfarm.com', 'true', '2010-05-17', NULL, 'KeiLin', 'sample');


 
  drop table staff;

  drop database project;