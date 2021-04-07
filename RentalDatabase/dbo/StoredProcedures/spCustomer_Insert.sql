CREATE PROCEDURE [dbo].[spCustomer_Insert]
	@firstName varchar(50),
	@lastName varchar(50),
	@email varchar(150),
	@phone varchar(50)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Customer(FirstName,LastName,Email,Phone)
	VALUES (@firstName, @lastName, @email, @phone);
	SELECT CAST(SCOPE_IDENTITY() as int);
END
