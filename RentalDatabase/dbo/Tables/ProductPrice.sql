CREATE TABLE [dbo].[ProductPrice]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [PricePerDay] MONEY NOT NULL, 
    [VAT] DECIMAL NULL, 
    CONSTRAINT [FK_ProductPrice_ToProductTable] FOREIGN KEY (ProductId) REFERENCES Product(Id)
)
