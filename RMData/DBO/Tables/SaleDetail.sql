CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[SaleID] INT NOT NULL,
	[ProductID] INT NOT NULL,
	[Quantity] INT NOT NULL Default 1,
	[PurchasePrice] MONEY NOT NULL,
	[Tax] MONEY NOT NULL Default 0
)
