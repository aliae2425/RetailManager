CREATE TABLE [dbo].[Product]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[ProductName] NVARCHAR(128) NOT NULL,
	[Description] NVARCHAR(MAX) NOT NULL,

	[RetailPrice] MONEY NOT NULL,
	[StockQuantity] INT NOT NULL DEFAULT 1,
	
	[creationDate] DATETIME2 NOT NULL DEFAULT getutcdate(),
	[lastUpdate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [IsTaxable] BIT NOT NULL DEFAULT 1,

)
