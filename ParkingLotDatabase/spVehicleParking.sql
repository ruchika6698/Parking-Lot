USE [ParkingLot]
GO
/****** Object:  StoredProcedure [dbo].[spParkingUserRegister]    Script Date: 9/22/2020 10:51:23 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ruchika
-- Create date: 23/9/2020
-- Description:	Store procedure for Parking Vehicle Register
-- =============================================
CREATE PROCEDURE spVehicleParking
@VehicleOwnerName varchar(50),
@VehicleOwnerAddress varchar(50),
@VehicleNumber varchar(50),
@VehicalBrand varchar(50),
@VehicalColor varchar(50),
@ParkingSlot varchar(50),
@ParkingUserCategory varchar(50),
@ParkingStatus varchar(50),
@EntryTime varchar(50),
@ExitTime varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 

	INSERT INTO VehicleParking(VehicleOwnerName,VehicleOwnerAddress,VehicleNumber,VehicalBrand,VehicalColor,ParkingSlot,ParkingUserCategory,ParkingStatus,EntryTime,ExitTime)
		VALUES(@VehicleOwnerName,@VehicleOwnerAddress,@VehicleNumber,@VehicalBrand,@VehicalColor,@ParkingSlot,@ParkingUserCategory,@ParkingStatus,@EntryTime,@ExitTime);
END
