CREATE PROCEDURE [dbo].[spSale_Lookup]
	@cashierID INT,
	@SaleDate datetime2
AS
BEGIN
	select Id
	from dbo.Sale
	where CashierID = @cashierID and SaleDate = @SaleDate;
end
