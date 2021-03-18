CREATE TABLE [dbo].[ProductCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ProductId] INT NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_ProductCategory_ToProductTable] FOREIGN KEY (ProductId) REFERENCES Product(Id),
    CONSTRAINT [FK_ProductCategory_ToCategoryTable] FOREIGN KEY (CategoryId) REFERENCES Category(Id)
)
