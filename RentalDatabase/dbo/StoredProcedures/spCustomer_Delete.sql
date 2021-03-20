CREATE PROCEDURE [dbo].[spCustomer_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.Customer
		Where Id = @id
	end
