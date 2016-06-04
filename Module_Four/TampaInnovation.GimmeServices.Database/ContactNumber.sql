CREATE TABLE [dbo].[ContactNumber]
(
	[ContactNumberId] INT NOT NULL PRIMARY KEY,
	[IsActive] BIT NULL,
	[Provider] NVARCHAR(50) NULL,
	[ProviderId] INT NULL,
	[Name] NVARCHAR(50) NULL,
	[Number] NVARCHAR(10) NULL,
	[TelephoneAreaCode] NVARCHAR(10) NULL,
	[TelephoneExtension] NVARCHAR(10) NULL,
	[TelephoneLine] NVARCHAR(10) NULL,
	[TelephonePrefix] NVARCHAR(10) NULL,
	[ProviderCreating] NVARCHAR(50) NULL,
	[DateAdded] DATETIME NULL,
	[ProviderUpdating] NVARCHAR(50) NULL,
	[DateUpdated] DATETIME NULL
)
