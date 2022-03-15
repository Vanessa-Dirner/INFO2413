
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
    wasteid CHAR(5) NOT NULL, 
  	batch CHAR(5) NOT NULL,
    expirationdate DATE NOT NULL ,
    quantity VARCHAR(5) NOT NULL ,
    seedtype CHAR(15) NOT NULL,
    seedname CHAR(20) NOT NULL,
    PRIMARY KEY (wasteid)
    );
 
  insert into waste (wasteid, batch, expirationdate, quantity, seedtype, seedname)
  values ('w001', 'B0001', '2020-01-10'  ,'00125'  , 'Pear', 'Bosc' ),
         ('w002','B0002', '2019-07-22'  ,'00608'  , 'Rhubarb', 'KangaRhu'),
         ('w003','B0003', '2021-01-10'  ,'00005'  , 'Celery', 'Conquistador'),
         ('w004','B0004', '2022-01-01'  ,'00473'  , 'Lemon', 'Eureka'),
         ('w005', 'B0005', '2018-09-09'  ,'00201'  , 'Lemon', 'Baboon');


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
  values ('B0021', '2020-01-10', 'West Coast Seeds' , 'Pear', 'Bosc', '50000' ),
         ('B0054', '2019-07-22', 'Canada Seed Company' , 'Sunflower', 'Titan', '73900'),
         ('B0572', '2021-01-10', 'Farm Direct Seeds' , 'Celery', 'Conquistador', '21204'),
         ('B0300', '2022-01-01' ,'Tropico' , 'Lemon', 'Eureka', '58208'),
         ('B0401', '2018-09-09', 'Tropico'  , 'Grape', 'Moon Drops', '10549');



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
  values ('ID001',  'Rocco', 'Briggs', 'Employee', 'RBriggs@ptfarm.com', 'true', '2012-04-09', NULL, 'RocBri', 'sample' ),
         ('ID002',  'Yasin', 'Mann', 'Gardener', 'YMann@ptfarm.com', 'true', '2015-12-03', NULL, 'YasMan', 'sample'),
         ('ID003', 'Glen', 'Carson', 'Gardener', 'GCarson@ptfarm.com', 'false', '2016-07-02', '2017-07-02', 'GleCar', 'sample'),
         ('ID004', 'Oliver', 'Castillo', 'Administrator', 'OCastillo@ptfarm.com', 'true', '2020-06-06', '', 'OliCas', 'sample'),
         ('ID005', 'Keice', 'Lin', 'Employee', 'KLin@ptfarm.com', 'true', '2010-05-17', NULL, 'KeiLin', 'sample');


 
  drop table staff;

  drop database project;