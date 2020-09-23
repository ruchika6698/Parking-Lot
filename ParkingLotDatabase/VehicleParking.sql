CREATE TABLE VehicleParking
(
  ParkingID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
  VehicleOwnerName varchar(50),
  VehicleOwnerAddress varchar(50),
  VehicleNumber varchar(50),
  VehicalBrand varchar(50),
  VehicalColor varchar(50),
  ParkingSlot  varchar(50),
  ParkingUserCategory varchar(50),
  ParkingStatus varchar(50),
  EntryTime  varchar(50),
  ExitTime  varchar(50)
);
select * from VehicleParking