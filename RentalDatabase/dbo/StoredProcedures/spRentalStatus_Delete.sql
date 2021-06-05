CREATE PROCEDURE [dbo].[spRentalStatus_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.RentalStatus
		Where Id = @id
	end