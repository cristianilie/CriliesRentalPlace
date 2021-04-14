CREATE PROCEDURE [dbo].[spProduct_GetAvailableProducts]
	 @startDate datetime2(7),
	 @endDate datetime2(7)
AS
BEGIN
	SET NOCOUNT ON

	 	select p.Id as ProductId, p.Name, p.Description, ps.PricePerDay, ps.VAT, p.ImagePath
	from dbo.Product p
	inner join dbo.ProductPrice ps on ps.ProductId = p.Id
	where ps.ProductId = p.Id and p.IsActive = 1 and
	p.Id not in (
		select r.ProductId from dbo.Rental r
		where r.StartDate BETWEEN @startDate and @endDate
		OR r.EndDate BETWEEN @startDate and @endDate);
END
