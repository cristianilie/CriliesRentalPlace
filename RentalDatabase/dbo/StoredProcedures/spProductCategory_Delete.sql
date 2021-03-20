CREATE PROCEDURE [dbo].[spProductCategory_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.ProductCategory
		Where Id = @id
	end
