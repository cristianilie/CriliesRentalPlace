CREATE PROCEDURE [dbo].[spCustomer_Update]
	@id int,
	@firstName varchar(50),
	@lastName varchar(50),
	@email varchar(150),
	@phone varchar(50)
AS
	begin
		set nocount on;

		UPDATE dbo.Customer
		SET FirstName = @firstName, LastName = @lastName, Email = @email, Phone = @phone
		WHERE Id = @id; 
	end