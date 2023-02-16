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

CREATE TABLE [Antropometricos] (
    [idPatientAnthropometricData] int NOT NULL IDENTITY,
    [height] real NOT NULL,
    [weight] real NOT NULL,
    [idUserModifiedBy] int NOT NULL,
    [createdOn] datetime2 NULL,
    [modifiedOn] datetime2 NULL,
    CONSTRAINT [PK_Antropometricos] PRIMARY KEY ([idPatientAnthropometricData])
);
GO

CREATE TABLE [Consultas] (
    [idEvent] int NOT NULL IDENTITY,
    [idUser] int NOT NULL,
    [idPatienteFile] int NOT NULL,
    [idUserModifiedBy] int NOT NULL,
    [createdOn] datetime2 NULL,
    [modifiedOn] datetime2 NULL,
    CONSTRAINT [PK_Consultas] PRIMARY KEY ([idEvent])
);
GO

CREATE TABLE [Habito] (
    [idPatientBowelHabit] int NOT NULL IDENTITY,
    [description] nvarchar(max) NULL,
    [idUserModifiedBy] int NOT NULL,
    [createdOn] datetime2 NULL,
    [modifiedOn] datetime2 NULL,
    CONSTRAINT [PK_Habito] PRIMARY KEY ([idPatientBowelHabit])
);
GO

CREATE TABLE [Motivo] (
    [idPatientReasonOfVisit] int NOT NULL IDENTITY,
    [reason] nvarchar(max) NULL,
    [idUserModifiedBy] int NOT NULL,
    [createdOn] datetime2 NULL,
    [modifiedOn] datetime2 NULL,
    CONSTRAINT [PK_Motivo] PRIMARY KEY ([idPatientReasonOfVisit])
);
GO

CREATE TABLE [Nota] (
    [idPatientCheckupNote] int NOT NULL IDENTITY,
    [comments] nvarchar(max) NULL,
    [idUserModifiedBy] int NOT NULL,
    [createdOn] datetime2 NULL,
    [modifiedOn] datetime2 NULL,
    CONSTRAINT [PK_Nota] PRIMARY KEY ([idPatientCheckupNote])
);
GO

CREATE TABLE [Padecimiento] (
    [idPatientSuffering] int NOT NULL IDENTITY,
    [suffering] nvarchar(max) NULL,
    [idUserModifiedBy] int NOT NULL,
    [createdOn] datetime2 NULL,
    [modifiedOn] datetime2 NULL,
    CONSTRAINT [PK_Padecimiento] PRIMARY KEY ([idPatientSuffering])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230216055706_Create Consult table', N'7.0.3');
GO

COMMIT;
GO

