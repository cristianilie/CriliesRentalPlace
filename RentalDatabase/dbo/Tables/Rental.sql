CREATE TABLE [dbo].[Rental]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [ProductId] INT NOT NULL, 
    [RentedQuantity] INT NOT NULL DEFAULT 1, 
    [StartDate] DATETIME2 NOT NULL, 
    [EndDate] DATETIME2 NOT NULL, 
    [TotalPrice] MONEY NOT NULL, 
    [RentalStatusId] INT NULL, 
    CONSTRAINT [FK_Rental_ToCustomerTable] FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
    CONSTRAINT [FK_Rental_ToProductTable] FOREIGN KEY (ProductId) REFERENCES Product(Id), 
    CONSTRAINT [FK_Rental_To_RentalStatus] FOREIGN KEY (RentalStatusId) REFERENCES RentalStatus(Id)
)
