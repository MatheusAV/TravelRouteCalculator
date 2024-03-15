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

CREATE TABLE [rota] (
    [id] int NOT NULL IDENTITY,
    [origem] nvarchar(100) NOT NULL,
    [destino] nvarchar(100) NOT NULL,
    [custo] DECIMAL(18,2) NOT NULL,
    CONSTRAINT [PK_rota] PRIMARY KEY ([id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240311234858_Init-Project', N'7.0.16');
GO

COMMIT;
GO

