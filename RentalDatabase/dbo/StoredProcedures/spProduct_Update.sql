CREATE PROCEDURE [dbo].[spProduct_Update]
	@id int,
	@name varchar(150),
	@description varchar(2000),
	@isActive bit
AS
	begin
		set nocount on;

		UPDATE dbo.Product
		SET [Name] = @name, [Description] = @description, IsActive = @isActive
		WHERE Id = @id; 
	end