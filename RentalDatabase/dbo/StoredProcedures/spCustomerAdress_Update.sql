CREATE PROCEDURE [dbo].[spCustomerAdress_Update]
	@id int,
	@customerId int,
	@state varchar(50),
	@city varchar(50),
	@adress varchar(160)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.CustomerAdress
	SET CustomerId = @customerId, [State] = @state, City = @city, Adress = @adress
	WHERE Id = @id;
END