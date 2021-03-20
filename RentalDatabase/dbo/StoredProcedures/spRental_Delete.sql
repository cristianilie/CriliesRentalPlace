CREATE PROCEDURE [dbo].[spRental_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.Rental
		Where Id = @id
	end