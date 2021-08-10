CREATE TABLE [dbo].[Countries] (
    [code]        VARCHAR (2)  NOT NULL,
    [countryName] VARCHAR (20) NULL,
    [idState]     INT          NULL,
    PRIMARY KEY CLUSTERED ([code] ASC),
    FOREIGN KEY ([idState]) REFERENCES [dbo].[State] ([idState])
);

