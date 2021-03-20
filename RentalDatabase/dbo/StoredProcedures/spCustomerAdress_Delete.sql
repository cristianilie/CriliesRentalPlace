CREATE PROCEDURE [dbo].[spCustomerAdress_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.CustomerAdress
		Where Id = @id
	end

