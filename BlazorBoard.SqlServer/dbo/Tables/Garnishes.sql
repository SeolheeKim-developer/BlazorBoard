CREATE TABLE [dbo].[Garnishes] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (25) NOT NULL,
    [BoardId] INT           NULL,
    CONSTRAINT [PK_Garnishes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Garnishes_Boards_BoardId] FOREIGN KEY ([BoardId]) REFERENCES [dbo].[Boards] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Garnishes_BoardId]
    ON [dbo].[Garnishes]([BoardId] ASC);

