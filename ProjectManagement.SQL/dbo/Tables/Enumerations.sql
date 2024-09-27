CREATE TABLE [dbo].[Enumerations]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY default NEWID(),
	[TenantId] UNIQUEIDENTIFIER NOT NULL,
	[Group] VARCHAR(100) NOT NULL,
	[Code] VARCHAR(100) NOT NULL,
	[Description] VARCHAR(100) NOT NULL,
	[IsDeleted] BIT NULL,
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
	[CreatedDate] DATETIMEOFFSET NOT NULL,
	[ModifiedBy] UNIQUEIDENTIFIER NOT NULL,
	[ModifiedDate] DATETIMEOFFSET NOT NULL,
	CONSTRAINT [FK_Enumerations_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([Id]) ON DELETE CASCADE
)

GO
CREATE NONCLUSTERED INDEX [TenentIndex]
    ON [dbo].[Enumerations]([TenantId]);


GO
CREATE NONCLUSTERED INDEX [CodeIndex]
    ON [dbo].[Enumerations]([Code])
INCLUDE ([Group],[Description]);