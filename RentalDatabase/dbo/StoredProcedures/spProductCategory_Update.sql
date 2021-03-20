CREATE PROCEDURE [dbo].[spProductCategory_Update]
	@id int,
	@productId int,
	@categoryId int
AS
	begin
		set nocount on;

		UPDATE dbo.ProductCategory
		SET ProductId = @productId, CategoryId = @categoryId
		WHERE Id = @id; 
	end
