CREATE PROCEDURE [dbo].[spCategory_Delete]
	@id int
AS
	begin
	set nocount on;
		Delete from dbo.Category
		Where Id = @id
	end
