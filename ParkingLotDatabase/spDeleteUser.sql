USE [ParkingLot]
GO
/****** Object:  StoredProcedure [dbo].[spDeleteEmployeeRcord]    Script Date: 5/29/2020 11:13:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Ruchika
-- Create date: 23/9/2020
-- Description:	Store procedure for Delete User
-- =============================================CREATE PROCEDURE SP_DeleteUser
CREATE PROCEDURE spDeleteUser
@ID int
AS 
BEGIN
    DELETE from ParkingUser
    WHERE ID = @ID
END
