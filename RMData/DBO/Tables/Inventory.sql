CREATE TABLE [dbo].[Inventory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProductID] INT NOT NULL,
	[Quantity] INT NOT NULL Default 1,
	[PurchaseDate] DATETIME2 NOT NULL DEFAULT getutcdate(),
)
