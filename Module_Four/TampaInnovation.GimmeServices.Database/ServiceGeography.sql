CREATE TABLE [dbo].[ServiceGeography]
(
	[ServiceGeographyId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	[Provider] NVARCHAR(50) NULL,
	[ProviderId] INT NULL,
	[ProviderServiceCodeID] INT NULL,
	[City] NVARCHAR(50) NULL,
	[County] NVARCHAR(50) NULL,
	[State] NVARCHAR(50) NULL,
	[StateName] NVARCHAR(50) NULL,
	[ZipCode] NVARCHAR(50) NULL

)
