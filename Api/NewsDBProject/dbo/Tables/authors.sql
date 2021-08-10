CREATE TABLE [dbo].[authors] (
    [idAuthor]  INT          NOT NULL,
    [Name]      VARCHAR (20) NULL,
    [LastName]  VARCHAR (20) NULL,
    [idCountry] VARCHAR (2)  NULL,
    [idState]   INT          NULL,
    PRIMARY KEY CLUSTERED ([idAuthor] ASC),
    FOREIGN KEY ([idCountry]) REFERENCES [dbo].[Countries] ([code]),
    FOREIGN KEY ([idState]) REFERENCES [dbo].[State] ([idState])
);

