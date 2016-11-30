USE Yourlake;
GO
CREATE PROCEDURE DeleteDataEveryTwentyFourHour
AS
BEGIN
	DELETE FROM dbo.Donnees WHERE DATEDIFF(day,getdate(),timeID) < -1
END
