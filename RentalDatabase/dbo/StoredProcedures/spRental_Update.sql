CREATE PROCEDURE [dbo].[spRental_Update]
	@id int,
	@customerId int,
	@productId int,
	@rentedQuantity int,
	@startDate datetime2(7),
	@endDate datetime2(7),
	@totalPrice money
AS
	begin
		set nocount on;

		UPDATE dbo.Rental
		SET CustomerId = @customerId, ProductId = @productId, RentedQuantity = @rentedQuantity, StartDate = @startDate, EndDate = @endDate, TotalPrice = @totalPrice
		WHERE Id = @id; 
	end
