CREATE TABLE [dbo].[Sources] (
    [idSource]   INT          NOT NULL,
    [SourceName] VARCHAR (20) NULL,
    [idState]    INT          NULL,
    PRIMARY KEY CLUSTERED ([idSource] ASC),
    FOREIGN KEY ([idState]) REFERENCES [dbo].[State] ([idState])
);

