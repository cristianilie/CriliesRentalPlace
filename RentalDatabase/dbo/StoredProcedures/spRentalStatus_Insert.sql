CREATE PROCEDURE [dbo].[spRentalStatus_Insert]
	@isInCustomerCustody bit,
	@paymentFinished bit
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.RentalStatus(IsInCustomerCustody,PaymentFinished)
	VALUES (@isInCustomerCustody, @paymentFinished);
	SELECT CAST(SCOPE_IDENTITY() as int);
END
