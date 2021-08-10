CREATE TABLE [dbo].[Categories] (
    [idCategory]   INT          NOT NULL,
    [CategoryName] VARCHAR (20) NULL,
    [idState]      INT          NULL,
    PRIMARY KEY CLUSTERED ([idCategory] ASC),
    FOREIGN KEY ([idState]) REFERENCES [dbo].[State] ([idState])
);

