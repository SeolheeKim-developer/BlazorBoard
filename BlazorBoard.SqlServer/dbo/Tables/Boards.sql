CREATE TABLE [dbo].[Boards] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (25) NOT NULL,
    [BrothId] INT           NOT NULL,
    CONSTRAINT [PK_Boards] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Boards_Broths_BrothId] FOREIGN KEY ([BrothId]) REFERENCES [dbo].[Broths] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Boards_BrothId]
    ON [dbo].[Boards]([BrothId] ASC);

