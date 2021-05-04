DROP TABLE [Utilisateur]
DROP TABLE [Canal]
DROP TABLE [Publication]

CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT IDENTITY NOT NULL, 
	[Pseudo] NCHAR(10) NOT NULL,
    [Nom] VARCHAR(80) NOT NULL, 
    [Prenom] VARCHAR(80) NOT NULL, 
    [Email] VARCHAR(MAX) NOT NULL, 
    [Mdp] VARCHAR(80) NOT NULL, 
    [DateCreation] DATETIME NOT NULL, 
    [Avatar] VARCHAR(MAX) NOT NULL DEFAULT 0, 
    [Actif] INT NOT NULL DEFAULT 0,
    [Admin] INT NOT NULL DEFAULT 0
    PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[Canal]
(
	[Id] INT IDENTITY NOT NULL, 
    [Theme] VARCHAR(80) NOT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [DateCreation] DATETIME NOT NULL, 
    [Actif] INT NOT NULL DEFAULT 0,
    [IdUtilisateur] INT NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
)

CREATE TABLE [dbo].[Publication]
(
	[Id] INT IDENTITY NOT NULL, 
    [Publication] VARCHAR(80) NOT NULL, 
    [DateCreation] DATETIME NOT NULL, 
    [Actif] INT NOT NULL DEFAULT 0,
    [IdUtilisateur] INT NOT NULL,
    [IdCanal] INT NOT NULL
    PRIMARY KEY CLUSTERED ([Id] ASC)
)