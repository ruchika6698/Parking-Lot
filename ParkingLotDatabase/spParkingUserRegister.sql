USE [ParkingLot] 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ruchika
-- Create date: 21/9/2020
-- Description:	Store procedure for Parking User Register
-- =============================================
CREATE PROCEDURE spParkingUserRegister
@FirstName varchar(50),
@LastName varchar(50),
@EmailID varchar(50),
@DriverCategory varchar(50),
@Username varchar(50),
@Password varchar(50),
@VehicalNumber varchar(50),
@VehicalBrand varchar(50),
@ParkingType varchar(50),
@CreateDate varchar(50),
@ModifiedDate varchar(50)
AS
BEGIN
	SET NOCOUNT ON; 

	INSERT INTO ParkingUser(FirstName,LastName,EmailID,DriverCategory,Username,Password,VehicalNumber,VehicalBrand,ParkingType,CreateDate,ModifiedDate)
		VALUES(@FirstName,@LastName,@EmailID,@DriverCategory,@Username,@Password,@VehicalNumber,@VehicalBrand,@ParkingType,@CreateDate,@ModifiedDate);
END
GO
