﻿CREATE TABLE [dbo].[Customer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY default NEWID(),
	[TenantId] UNIQUEIDENTIFIER NOT NULL,
	[Name] VARCHAR(100) NOT NULL,
	[Email] VARCHAR(100) NOT NULL,
	[Phone] VARCHAR(20) NOT NULL,
	[Address] NVARCHAR(MAX) NULL CHECK(ISJSON(Address) = 1),
	[IsActive] BIT NULL,
	[IsDeleted] BIT NULL,
	[CreatedBy] UNIQUEIDENTIFIER NOT NULL,
	[CreatedDate] DATETIMEOFFSET NOT NULL,
	[ModifiedBy] UNIQUEIDENTIFIER NOT NULL,
	[ModifiedDate] DATETIMEOFFSET NOT NULL,
	CONSTRAINT [FK_Customer_Tenant_TenantId] FOREIGN KEY ([TenantId]) REFERENCES [dbo].[Tenant] ([Id]) ON DELETE CASCADE
)

GO
CREATE NONCLUSTERED INDEX [TenentIndex]
    ON [dbo].[Customer]([TenantId]);


GO
CREATE UNIQUE NONCLUSTERED INDEX [NameIndex]
    ON [dbo].[Customer]([Name] ASC) WHERE ([Name] IS NOT NULL);