CREATE PROCEDURE [dbo].[spProductStock_Insert]
	@id int,
	@productId int,
	@pricePerDay money,
	@stock int,
	@booked int,
	@available int,
	@vat decimal
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.ProductStock(ProductId,PricePerDay, Stock, Booked, Available, VAT)
	VALUES (@productId, @pricePerDay, @stock, @booked, @available, @vat);
END
