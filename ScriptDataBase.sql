USE [master]
GO

/****** Object:  Database [BibliotecaNexos]    Script Date: 5/02/2022 4:25:41 p. m. ******/
CREATE DATABASE [BibliotecaNexos]
Go 

USE [BibliotecaNexos]
GO

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

CREATE TABLE [Autores] (
    [Id] int NOT NULL IDENTITY,
    [NombreCompleto] nvarchar(max) NULL,
    [FechaNacimiento] datetime2 NOT NULL,
    [CiudadProcedencia] nvarchar(max) NULL,
    [CorreoElectronico] nvarchar(max) NULL,
    CONSTRAINT [PK_Autores] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Editoriales] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(max) NULL,
    [DireccionCorrespondencia] nvarchar(max) NULL,
    [Telefono] nvarchar(max) NULL,
    [CorreoElectronico] nvarchar(max) NULL,
    [MaximoLibrosRegistrados] nvarchar(max) NULL,
    CONSTRAINT [PK_Editoriales] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Libros] (
    [Id] int NOT NULL IDENTITY,
    [Titulo] nvarchar(max) NULL,
    [Anio] int NOT NULL,
    [Genero] nvarchar(max) NULL,
    [NumeroPaginas] int NOT NULL,
    [EditorialId] int NOT NULL,
    [AutorId] int NOT NULL,
    CONSTRAINT [PK_Libros] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Libros_Autores_AutorId] FOREIGN KEY ([AutorId]) REFERENCES [Autores] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Libros_Editoriales_EditorialId] FOREIGN KEY ([EditorialId]) REFERENCES [Editoriales] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Libros_AutorId] ON [Libros] ([AutorId]);
GO

CREATE INDEX [IX_Libros_EditorialId] ON [Libros] ([EditorialId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220204042208_InitialCreate', N'5.0.13');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Editoriales]') AND [c].[name] = N'MaximoLibrosRegistrados');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Editoriales] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Editoriales] ALTER COLUMN [MaximoLibrosRegistrados] int NOT NULL;
ALTER TABLE [Editoriales] ADD DEFAULT 0 FOR [MaximoLibrosRegistrados];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220205172606_AlterDataTypeMaxLibros', N'5.0.13');
GO

COMMIT;
GO

