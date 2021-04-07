CREATE PROCEDURE [dbo].[spProductCategory_Insert]
	@productId int,
	@categoryId int
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.ProductCategory(ProductId,CategoryId)
	VALUES (@productId, @categoryId);
	SELECT CAST(SCOPE_IDENTITY() as int)
END