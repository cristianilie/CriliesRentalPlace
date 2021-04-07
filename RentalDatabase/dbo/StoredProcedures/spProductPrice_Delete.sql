CREATE PROCEDURE [dbo].[spProductPrice_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.ProductPrice
		Where Id = @id
	end