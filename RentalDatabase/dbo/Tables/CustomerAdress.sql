CREATE TABLE [dbo].[CustomerAdress]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CustomerId] INT NOT NULL, 
    [State] VARCHAR(50) NOT NULL, 
    [City] VARCHAR(50) NOT NULL, 
    [Adress] VARCHAR(160) NOT NULL, 
    CONSTRAINT [FK_CustomerAdress_ToCustomerTable] FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
)
