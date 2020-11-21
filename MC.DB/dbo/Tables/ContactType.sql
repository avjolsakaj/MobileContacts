CREATE TABLE [dbo].[ContactType] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Code]     NVARCHAR (50)  NULL,
    [Value]    NVARCHAR (250) NOT NULL,
    [IsActive] BIT            CONSTRAINT [DF_ContactType_IsActive] DEFAULT ((1)) NOT NULL,
    [Deleted]  BIT            CONSTRAINT [DF_ContactType_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_ContactType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

