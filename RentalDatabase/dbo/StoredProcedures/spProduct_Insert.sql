CREATE PROCEDURE [dbo].[spProduct_Insert]
	@name varchar(150),
	@description varchar(2000)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Product([Name],[Description])
	VALUES (@name, @description);
END
