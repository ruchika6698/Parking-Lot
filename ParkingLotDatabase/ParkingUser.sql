CREATE TABLE ParkingUser
(
  ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  FirstName varchar(50),
  LastName varchar(50),
  EmailID varchar(50),
  Password varchar(50),
  UserRole varchar(50),
  CreateDate varchar(50)
);
select * from ParkingUser