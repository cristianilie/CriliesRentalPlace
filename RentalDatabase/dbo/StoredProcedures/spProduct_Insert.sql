CREATE PROCEDURE [dbo].[spProduct_Insert]
	@name varchar(150),
	@description varchar(2000),
	@isActive bit,
	@imagePath  varchar(300)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Product([Name],[Description], IsActive, ImagePath)
	VALUES (@name, @description, @isActive, @imagePath);
	SELECT CAST(SCOPE_IDENTITY() as int);
END
