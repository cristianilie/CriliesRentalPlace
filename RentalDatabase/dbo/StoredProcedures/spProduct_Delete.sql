CREATE PROCEDURE [dbo].[spProduct_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.Product
		Where Id = @id
	end