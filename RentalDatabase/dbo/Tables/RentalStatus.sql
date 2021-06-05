CREATE TABLE [dbo].[RentalStatus]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [IsInCustomerCustody] BIT NOT NULL, 
    [PaymentFinished] BIT NOT NULL
)
