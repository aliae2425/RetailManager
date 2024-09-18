CREATE PROCEDURE [dbo].[spSaleDetail_Insert]
	@SaleId INT,
	@ProductId INT,
	@Quantity INT,
	@Price money,
	@Tax money
AS
begin
	SET NOCOUNT ON;

	insert into dbo.SaleDetail(SaleId, ProductId, Quantity, PurchasePrice, Tax)
	values(@SaleId, @ProductId, @Quantity, @Price, @Tax);
end