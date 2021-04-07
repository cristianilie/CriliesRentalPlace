CREATE PROCEDURE [dbo].[spProductPrice_Update]
	@id int,
	@productId int,
	@pricePerDay money,
	@vat decimal
AS
	begin
		set nocount on;

		UPDATE dbo.ProductPrice
		SET ProductId = @productId, PricePerDay = @pricePerDay, VAT = @vat
		WHERE Id = @id; 
	end