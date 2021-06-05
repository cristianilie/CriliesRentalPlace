CREATE PROCEDURE [dbo].[spRentalStatus_Update]
	@id int,
	@isInCustomerCustody bit,
	@paymentFinished bit
AS
	begin
		set nocount on;

		UPDATE dbo.RentalStatus
		SET IsInCustomerCustody = @isInCustomerCustody, PaymentFinished = @paymentFinished
		WHERE Id = @id; 
	end
