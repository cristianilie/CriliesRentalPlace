CREATE PROCEDURE [dbo].[spRental_Insert]
	@customerId int,
	@productId int,
	@rentedQuantity int,
	@startDate datetime2(7),
	@endDate datetime2(7),
	@totalPrice money,
	@rentalStatusId int
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Rental(CustomerId,ProductId,RentedQuantity,StartDate,EndDate,TotalPrice, RentalStatusId)
	VALUES (@customerId, @productId, @rentedQuantity, @startDate, @endDate, @totalPrice, @rentalStatusId);
	SELECT CAST(SCOPE_IDENTITY() as int);
END
