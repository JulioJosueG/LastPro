CREATE TABLE [dbo].[Articles] (
    [ArticleId]   INT           NOT NULL,
    [idAuthor]    INT           NULL,
    [Title]       VARCHAR (20)  NULL,
    [content]     VARCHAR (MAX) NULL,
    [PublishedAt] DATETIME      NULL,
    [imageAt]     VARCHAR (MAX) NULL,
    [CountryCode] VARCHAR (2)   NULL,
    [CategoryId]  INT           NULL,
    [IdSource]    INT           NULL,
    [idState]     INT           NULL,
    PRIMARY KEY CLUSTERED ([ArticleId] ASC),
    FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([idCategory]),
    FOREIGN KEY ([CountryCode]) REFERENCES [dbo].[Countries] ([code]),
    FOREIGN KEY ([idAuthor]) REFERENCES [dbo].[authors] ([idAuthor]),
    FOREIGN KEY ([IdSource]) REFERENCES [dbo].[Sources] ([idSource]),
    FOREIGN KEY ([idState]) REFERENCES [dbo].[State] ([idState])
);

