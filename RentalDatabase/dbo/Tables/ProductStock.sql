CREATE TABLE [dbo].[ProductStock]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [PricePerDay] MONEY NOT NULL, 
    [Stock] INT NOT NULL, 
    [Booked] INT NOT NULL, 
    [Available] INT NOT NULL, 
    [VAT] DECIMAL NULL, 
    CONSTRAINT [FK_ProductStock_ToProductTable] FOREIGN KEY (ProductId) REFERENCES Product(Id)
)
