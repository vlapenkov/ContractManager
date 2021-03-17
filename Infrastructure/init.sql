Build started...
Build succeeded.
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [BillPoints] (
    [Id] int NOT NULL,
    [Name] nvarchar(max) NULL,
    [TnePointId] int NOT NULL,
    CONSTRAINT [PK_BillPoints] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contracts] (
    [Id] int NOT NULL IDENTITY,
    [ContractKind] int NOT NULL,
    [SDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Contracts] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [EnergyLinkObjects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    CONSTRAINT [PK_EnergyLinkObjects] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Organizations] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [OrganizationType] int NOT NULL,
    CONSTRAINT [PK_Organizations] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [BillObjects] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NULL,
    [ContractId] int NOT NULL,
    CONSTRAINT [PK_BillObjects] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_BillObjects_Contracts_ContractId] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [BillSideToBillPoints] (
    [EnergyLinkObjectId] int NOT NULL,
    [BillPointId] int NOT NULL,
    [SDate] datetime2 NOT NULL,
    [EDate] datetime2 NULL,
    [TypeSide] int NOT NULL,
    CONSTRAINT [PK_BillSideToBillPoints] PRIMARY KEY ([EnergyLinkObjectId], [BillPointId], [SDate]),
    CONSTRAINT [FK_BillSideToBillPoints_BillPoints_BillPointId] FOREIGN KEY ([BillPointId]) REFERENCES [BillPoints] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BillSideToBillPoints_EnergyLinkObjects_EnergyLinkObjectId] FOREIGN KEY ([EnergyLinkObjectId]) REFERENCES [EnergyLinkObjects] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [EnergyLinkObjectToBillPoint] (
    [Id] int NOT NULL IDENTITY,
    [EnergyLinkObjectId] int NOT NULL,
    [BillPointId] int NOT NULL,
    [SDate] datetime2 NOT NULL,
    [EDate] datetime2 NULL,
    CONSTRAINT [PK_EnergyLinkObjectToBillPoint] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EnergyLinkObjectToBillPoint_BillPoints_BillPointId] FOREIGN KEY ([BillPointId]) REFERENCES [BillPoints] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_EnergyLinkObjectToBillPoint_EnergyLinkObjects_EnergyLinkObjectId] FOREIGN KEY ([EnergyLinkObjectId]) REFERENCES [EnergyLinkObjects] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ContractParticipants] (
    [Id] int NOT NULL IDENTITY,
    [ParticipantType] int NOT NULL,
    [OrganizationId] int NULL,
    [ContractId] int NOT NULL,
    CONSTRAINT [PK_ContractParticipants] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ContractParticipants_Contracts_ContractId] FOREIGN KEY ([ContractId]) REFERENCES [Contracts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_ContractParticipants_Organizations_OrganizationId] FOREIGN KEY ([OrganizationId]) REFERENCES [Organizations] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [BillObjectToEnergyLinkObjects] (
    [EnergyLinkObjectId] int NOT NULL,
    [BillObjectId] int NOT NULL,
    [SDate] datetime2 NOT NULL,
    [EDate] datetime2 NULL,
    CONSTRAINT [PK_BillObjectToEnergyLinkObjects] PRIMARY KEY ([BillObjectId], [EnergyLinkObjectId], [SDate]),
    CONSTRAINT [FK_BillObjectToEnergyLinkObjects_BillObjects_BillObjectId] FOREIGN KEY ([BillObjectId]) REFERENCES [BillObjects] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_BillObjectToEnergyLinkObjects_EnergyLinkObjects_EnergyLinkObjectId] FOREIGN KEY ([EnergyLinkObjectId]) REFERENCES [EnergyLinkObjects] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [BillParams] (
    [EnergyLinkObjectToBillPointId] int NOT NULL,
    [BillParamType] int NOT NULL,
    [Value] int NOT NULL,
    CONSTRAINT [PK_BillParams] PRIMARY KEY ([EnergyLinkObjectToBillPointId], [BillParamType]),
    CONSTRAINT [FK_BillParams_EnergyLinkObjectToBillPoint_EnergyLinkObjectToBillPointId] FOREIGN KEY ([EnergyLinkObjectToBillPointId]) REFERENCES [EnergyLinkObjectToBillPoint] ([Id]) ON DELETE CASCADE
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TnePointId') AND [object_id] = OBJECT_ID(N'[BillPoints]'))
    SET IDENTITY_INSERT [BillPoints] ON;
INSERT INTO [BillPoints] ([Id], [Name], [TnePointId])
VALUES (1, N'bp1', 1),
(2, N'bp1', 2),
(3, N'bp1', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'TnePointId') AND [object_id] = OBJECT_ID(N'[BillPoints]'))
    SET IDENTITY_INSERT [BillPoints] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'OrganizationType') AND [object_id] = OBJECT_ID(N'[Organizations]'))
    SET IDENTITY_INSERT [Organizations] ON;
INSERT INTO [Organizations] ([Id], [Name], [OrganizationType])
VALUES (1, N'ТНЭ', 1),
(2, N'КТК', 4),
(3, N'Дружба', 4),
(4, N'Рога и копыта', 0),
(5, N'Башкирэнерго', 3);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Name', N'OrganizationType') AND [object_id] = OBJECT_ID(N'[Organizations]'))
    SET IDENTITY_INSERT [Organizations] OFF;
GO

CREATE INDEX [IX_BillObjects_ContractId] ON [BillObjects] ([ContractId]);
GO

CREATE INDEX [IX_BillObjectToEnergyLinkObjects_EnergyLinkObjectId] ON [BillObjectToEnergyLinkObjects] ([EnergyLinkObjectId]);
GO

CREATE INDEX [IX_BillSideToBillPoints_BillPointId] ON [BillSideToBillPoints] ([BillPointId]);
GO

CREATE INDEX [IX_ContractParticipants_ContractId] ON [ContractParticipants] ([ContractId]);
GO

CREATE INDEX [IX_ContractParticipants_OrganizationId] ON [ContractParticipants] ([OrganizationId]);
GO

CREATE INDEX [IX_EnergyLinkObjectToBillPoint_BillPointId] ON [EnergyLinkObjectToBillPoint] ([BillPointId]);
GO

CREATE INDEX [IX_EnergyLinkObjectToBillPoint_EnergyLinkObjectId] ON [EnergyLinkObjectToBillPoint] ([EnergyLinkObjectId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210317065652_init', N'5.0.2');
GO

COMMIT;
GO


