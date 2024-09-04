CREATE PROCEDURE [dbo].[SpProduct_GetAll]
AS
begin
	set nocount on;

	select Id, ProductName, [Description], RetailPrice, StockQuantity, IsTaxable
	from [dbo].[Product]
	order by [ProductName];
end	
