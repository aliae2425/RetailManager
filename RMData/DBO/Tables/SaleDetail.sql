CREATE TABLE [dbo].[SaleDetail]
(
	[Id] INT NOT NULL PRIMARY KEY identity,
	[SaleID] INT NOT NULL,
	[ProductID] INT NOT NULL,
	[Quantity] INT NOT NULL Default 1,
	[PurchasePrice] MONEY NOT NULL,
	[Tax] MONEY NOT NULL Default 0, 
    CONSTRAINT [FK_SaleDetail_ToSale] FOREIGN KEY (SaleID) REFERENCES Sale([ID]), 
    CONSTRAINT [FK_SaleDetail_ToProducts] FOREIGN KEY (ProductID) REFERENCES [Product]([Id])
)
