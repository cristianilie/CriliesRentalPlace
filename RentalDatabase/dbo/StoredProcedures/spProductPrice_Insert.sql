CREATE PROCEDURE [dbo].[spProductPrice_Insert]
	@productId int,
	@pricePerDay money,
	@vat decimal
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.ProductPrice(ProductId,PricePerDay,VAT)
	VALUES (@productId, @pricePerDay, @vat);
	SELECT CAST(SCOPE_IDENTITY() as int);
END
