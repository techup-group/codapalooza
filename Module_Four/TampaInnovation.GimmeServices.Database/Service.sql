CREATE TABLE [dbo].[Service]
(
	[ServiceId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[IsActive] BIT NULL,
	[Name] NVARCHAR(50) NULL,
	[Provider] NVARCHAR(50) NULL,
	[ProviderId] INT NULL,
	[ProviderSpecificServiceId] NVARCHAR(50) NULL,
	[IsThisAMedicaidBillableItem] BIT NULL,
	[RequiresPreAuthorization] BIT NULL,
	[DefaultUnitCost] NVARCHAR(50) NULL,
	[UnitType] NVARCHAR(50) NULL,
	[ProviderCreating] NVARCHAR(50) NULL,
	[DateAdded] DATETIME NULL,
	[ProviderUpdating] NVARCHAR(50) NULL,
	[DateUpdated] DATETIME NULL
)
