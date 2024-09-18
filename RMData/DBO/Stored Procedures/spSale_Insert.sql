CREATE PROCEDURE [dbo].[spSale_Insert]
	@Id INT OUTPUT,
	@CashierId Nvarchar(128),
	@SaleDate Datetime2,
	@subTotal money,
	@Tax money,
	@Total money
	
AS
BEGIN
	SET NOCOUNT ON;

	insert into dbo.Sale(CashierId, SaleDate, subTotal, Tax, Total)
	values(@CashierId, @SaleDate, @subTotal, @Tax, @Total);

	select @Id = @@IDENTITY;
end	