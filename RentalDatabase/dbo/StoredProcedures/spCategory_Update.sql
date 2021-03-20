CREATE PROCEDURE [dbo].[spCategory_Update]
	@id int,
	@title varchar(50)
AS
	begin
		set nocount on;

		UPDATE dbo.Category
		SET Title = @title
		WHERE Id = @id; 
	end
