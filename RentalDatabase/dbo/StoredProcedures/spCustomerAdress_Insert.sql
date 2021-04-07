CREATE PROCEDURE [dbo].[spCustomerAdress_Insert]
	@id int,
	@customerId int,
	@state varchar(50),
	@city varchar(50),
	@adress varchar(160)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.CustomerAdress(CustomerId,[State],City,Adress)
	VALUES (@customerId, @state, @city, @adress);
	SELECT CAST(SCOPE_IDENTITY() as int);
END