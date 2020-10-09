USE [ParkingLot]
GO
/****** Object:  StoredProcedure [dbo].[spUpdateemployeedetails]    Script Date: 5/29/2020 11:19:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ruchika
-- Create date: 14/5/2020
-- Description:	Store procedure for employee Register
-- =============================================CREATE PROCEDURE SP_EmpLoyee_Update
CREATE PROCEDURE spUpdateParkingdetails
@ParkingID int,
@ParkingStatus varchar(50),
@ExitTime varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE VehicleParking SET ParkingStatus=@ParkingStatus,ExitTime=@ExitTime
		WHERE ParkingID = @ParkingID
END