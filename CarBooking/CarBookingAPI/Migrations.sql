IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Cars] (
    [ID] int NOT NULL IDENTITY,
    [Make] nvarchar(max) NOT NULL,
    [Model] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Customers] (
    [ID] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([ID])
);

GO

CREATE TABLE [Bookings] (
    [ID] int NOT NULL IDENTITY,
    [CarID] int NOT NULL,
    [CustomerID] int NOT NULL,
    [Date] datetime2 NOT NULL,
    CONSTRAINT [PK_Bookings] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Bookings_Cars_CarID] FOREIGN KEY ([CarID]) REFERENCES [Cars] ([ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Bookings_Customers_CustomerID] FOREIGN KEY ([CustomerID]) REFERENCES [Customers] ([ID]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Bookings_CarID] ON [Bookings] ([CarID]);

GO

CREATE INDEX [IX_Bookings_CustomerID] ON [Bookings] ([CustomerID]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200119123606_Initial', N'3.1.1');

GO