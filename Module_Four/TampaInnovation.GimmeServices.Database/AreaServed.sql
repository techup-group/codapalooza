CREATE TABLE [dbo].[AreaServed]
(
	[AreaServedId] INT NULL,
	[Area] NVARCHAR(50) NULL,
	[ProviderId] INT NULL,
	[ProviderCreating] NVARCHAR(50) NULL,
	[DateAdded] DATETIME NULL,
	[ProviderUpdating] NVARCHAR(50) NULL,
	[DateUpdated] DATETIME NULL
)

GO

CREATE INDEX AreaServedIdx1 ON [AreaServed] (AreaServedId)