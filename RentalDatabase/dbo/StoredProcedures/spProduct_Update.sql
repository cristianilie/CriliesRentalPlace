CREATE PROCEDURE [dbo].[spProduct_Update]
	@id int,
	@name varchar(150),
	@description varchar(2000),
	@isActive bit,
	@imagePath  varchar(300)
AS
	begin
		set nocount on;

		UPDATE dbo.Product
		SET [Name] = @name, [Description] = @description, IsActive = @isActive, ImagePath = @imagePath
		WHERE Id = @id; 
	end