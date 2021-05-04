CREATE TABLE [dbo].[Utilisateur]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[Pseudo] NCHAR(10) NOT NULL,
    [Nom] VARCHAR(80) NOT NULL, 
    [Prenom] VARCHAR(80) NOT NULL, 
    [Email] VARCHAR(MAX) NOT NULL, 
    [Mdp] VARCHAR(80) NOT NULL, 
    [DateCreation] TIMESTAMP NOT NULL, 
    [Avatar] VARCHAR(MAX) NULL, 
    [Actif] INT NOT NULL DEFAULT 0,
    [Admin] INT NOT NULL DEFAULT 0
)

CREATE TABLE [dbo].[Canal]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Theme] VARCHAR(80) NOT NULL, 
    [Description] VARCHAR(MAX) NULL, 
    [DateCreation] TIMESTAMP NOT NULL, 
    [Actif] INT NOT NULL DEFAULT 0,
    [IdUtilisateur] INT NULL
)

CREATE TABLE [dbo].[Publication]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Publication] VARCHAR(80) NOT NULL, 
    [DateCreation] TIMESTAMP NOT NULL, 
    [Actif] INT NOT NULL DEFAULT 0,
    [IdUtilisateur] INT NULL,
    [IdCanal] INT NULL
)