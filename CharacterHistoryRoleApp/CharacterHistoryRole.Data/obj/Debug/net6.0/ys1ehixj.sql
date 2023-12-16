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

CREATE TABLE [CharacterBioDetail] (
    [CharacterBioDetailId] uniqueidentifier NOT NULL,
    [ClassRaceId] uniqueidentifier NULL,
    [RaceId] uniqueidentifier NULL,
    [CharacterBioId] uniqueidentifier NOT NULL,
    [Force] int NULL,
    [Destress] int NULL,
    [Intelligence] int NULL,
    [Wisdom] int NULL,
    [Perception] int NULL,
    [Level] int NULL,
    [LifePoints] int NULL,
    [PowerPoints] int NULL,
    CONSTRAINT [PK_CharacterBioDetail] PRIMARY KEY ([CharacterBioDetailId])
);
GO

CREATE TABLE [Group] (
    [GroupId] uniqueidentifier NOT NULL,
    [GroupName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateEdited] datetime2 NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [EditedBy] nvarchar(max) NOT NULL,
    [CurrentTimestamp] rowversion NULL,
    CONSTRAINT [PK_Group] PRIMARY KEY ([GroupId])
);
GO

CREATE TABLE [Permmission] (
    [PermmissionId] int NOT NULL,
    [PermmissionName] nvarchar(max) NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateEdited] datetime2 NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [EditedBy] nvarchar(max) NOT NULL,
    [CurrentTimestamp] rowversion NULL,
    CONSTRAINT [PK_Permmission] PRIMARY KEY ([PermmissionId])
);
GO

CREATE TABLE [Profile] (
    [ProfileId] uniqueidentifier NOT NULL,
    [ProfileName] nvarchar(max) NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    [Active] bit NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateEdited] datetime2 NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [EditedBy] nvarchar(max) NOT NULL,
    [CurrentTimestamp] rowversion NULL,
    CONSTRAINT [PK_Profile] PRIMARY KEY ([ProfileId])
);
GO

CREATE TABLE [User] (
    [UserId] uniqueidentifier NOT NULL,
    [ProfileId] uniqueidentifier NOT NULL,
    [UserName] nvarchar(max) NOT NULL,
    [Password] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [Phone] int NOT NULL,
    [Active] bit NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateEdited] datetime2 NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [EditedBy] nvarchar(max) NOT NULL,
    [CurrentTimestamp] rowversion NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([UserId])
);
GO

CREATE TABLE [AtributesAbilities] (
    [CharacterBioDetailId] uniqueidentifier NOT NULL,
    [AtributesAbilitiesId] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AtributesAbilities] PRIMARY KEY ([CharacterBioDetailId]),
    CONSTRAINT [FK_Atributies_CharacterBioDetail] FOREIGN KEY ([CharacterBioDetailId]) REFERENCES [CharacterBioDetail] ([CharacterBioDetailId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ClassRace] (
    [ClassRaceId] uniqueidentifier NOT NULL,
    [ClassRaceName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ClassRace] PRIMARY KEY ([ClassRaceId]),
    CONSTRAINT [FK_ClassRace_CharacterBioDetail_ClassRaceId] FOREIGN KEY ([ClassRaceId]) REFERENCES [CharacterBioDetail] ([CharacterBioDetailId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Race] (
    [RaceId] uniqueidentifier NOT NULL,
    [RaceName] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Race] PRIMARY KEY ([RaceId]),
    CONSTRAINT [FK_Race_CharacterBioDetail_RaceId] FOREIGN KEY ([RaceId]) REFERENCES [CharacterBioDetail] ([CharacterBioDetailId]) ON DELETE CASCADE
);
GO

CREATE TABLE [RacialBackground] (
    [RacialBackgroundId] uniqueidentifier NOT NULL,
    [CharacterBioDetailId] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_RacialBackground] PRIMARY KEY ([RacialBackgroundId]),
    CONSTRAINT [FK_RacilBackGroud_CharacterBioDetail] FOREIGN KEY ([CharacterBioDetailId]) REFERENCES [CharacterBioDetail] ([CharacterBioDetailId]) ON DELETE CASCADE
);
GO

CREATE TABLE [CharacterBio] (
    [CharacterBioId] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NOT NULL,
    [GroupId] uniqueidentifier NOT NULL,
    [BioInfo] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [Image] nvarchar(max) NOT NULL,
    [Url] nvarchar(max) NOT NULL,
    [IsPublic] bit NULL,
    [Experience] int NULL,
    [DateCreated] datetime2 NOT NULL,
    [DateEdited] datetime2 NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    [EditedBy] nvarchar(max) NOT NULL,
    [CurrentTimestamp] rowversion NULL,
    CONSTRAINT [PK_Bio_User_Group] PRIMARY KEY ([CharacterBioId]),
    CONSTRAINT [FK_CharacterBio_CharacterBioDetail_CharacterBioId] FOREIGN KEY ([CharacterBioId]) REFERENCES [CharacterBioDetail] ([CharacterBioDetailId]) ON DELETE CASCADE,
    CONSTRAINT [FK_User_Character_Bio] FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ProfilePermmission] (
    [ProfileId] uniqueidentifier NOT NULL,
    [PermmissionId] int NOT NULL,
    CONSTRAINT [PK_ProfilePermmissions] PRIMARY KEY ([ProfileId]),
    CONSTRAINT [FK_ProfilePermmisions_Permmissions] FOREIGN KEY ([PermmissionId]) REFERENCES [Permmission] ([PermmissionId]),
    CONSTRAINT [FK_ProfilePermmissions_Profile] FOREIGN KEY ([ProfileId]) REFERENCES [Profile] ([ProfileId]),
    CONSTRAINT [FK_User_ProfilePermmissions] FOREIGN KEY ([ProfileId]) REFERENCES [User] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [BackPack] (
    [BackPackId] uniqueidentifier NOT NULL,
    [CharacterBioId] uniqueidentifier NOT NULL,
    [Capacity] int NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_BackPack_CharacterBio] PRIMARY KEY ([BackPackId]),
    CONSTRAINT [FK_BackPack_CharacterBio_CharacterBioId] FOREIGN KEY ([CharacterBioId]) REFERENCES [CharacterBio] ([CharacterBioId]) ON DELETE CASCADE
);
GO

CREATE TABLE [UserGroup] (
    [UserId] uniqueidentifier NOT NULL,
    [GroupId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserGroup] PRIMARY KEY ([UserId]),
    CONSTRAINT [FK_UserGroup_CharacterBio] FOREIGN KEY ([GroupId]) REFERENCES [CharacterBio] ([CharacterBioId]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserGroups_Group] FOREIGN KEY ([GroupId]) REFERENCES [Group] ([GroupId]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserGroups_Users] FOREIGN KEY ([UserId]) REFERENCES [User] ([UserId]) ON DELETE CASCADE
);
GO

CREATE TABLE [BackPackItem] (
    [BackPackItemId] uniqueidentifier NOT NULL,
    [BackPackId] uniqueidentifier NOT NULL,
    [Description] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_BackPackItem] PRIMARY KEY ([BackPackItemId]),
    CONSTRAINT [FK_BackPackItem_BackPack] FOREIGN KEY ([BackPackId]) REFERENCES [BackPack] ([BackPackId]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_BackPack_CharacterBioId] ON [BackPack] ([CharacterBioId]);
GO

CREATE INDEX [IX_BackPackItem_BackPackId] ON [BackPackItem] ([BackPackId]);
GO

CREATE INDEX [IX_CharacterBio_UserId] ON [CharacterBio] ([UserId]);
GO

CREATE INDEX [IX_ProfilePermmission_PermmissionId] ON [ProfilePermmission] ([PermmissionId]);
GO

CREATE INDEX [IX_RacialBackground_CharacterBioDetailId] ON [RacialBackground] ([CharacterBioDetailId]);
GO

CREATE INDEX [IX_UserGroup_GroupId] ON [UserGroup] ([GroupId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231210074047_init', N'6.0.25');
GO

COMMIT;
GO

