CREATE PROCEDURE [dbo].[spCategory_Insert]
	@title varchar(50)
AS
BEGIN
	SET NOCOUNT ON

	INSERT INTO dbo.Category(Title)
	VALUES (@title);
END