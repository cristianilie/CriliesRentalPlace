CREATE PROCEDURE [dbo].[spProductStock_Update]
	@id int,
	@productId int,
	@pricePerDay money,
	@stock int,
	@booked int,
	@available int,
	@vat decimal,
	@active bit
AS
	begin
		set nocount on;

		UPDATE dbo.ProductStock
		SET ProductId = @productId, PricePerDay = @pricePerDay, Stock = @stock, Booked = @booked, Available = @available, VAT = @vat
		WHERE Id = @id; 
	end