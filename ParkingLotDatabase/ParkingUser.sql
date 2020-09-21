CREATE TABLE ParkingUser
(
  ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(50),
  LastName varchar(50),
  EmailID varchar(50),
  DriverCategory varchar(50),
  Username varchar(50),
  Password varchar(50),
  VehicalNumber  varchar(50),
  VehicalBrand  varchar(50),
  ParkingType  varchar(50),
  CreateDate varchar(50),
  ModifiedDate varchar(50)
);
select * from ParkingUser