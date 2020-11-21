CREATE TABLE [dbo].[Contact] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [PersonId]      INT            NOT NULL,
    [ContactTypeId] INT            NOT NULL,
    [Number]        NVARCHAR (50)  NOT NULL,
    [Email]         NVARCHAR (250) NULL,
    [IsActive]      BIT            CONSTRAINT [DF_Contact_IsActive] DEFAULT ((1)) NOT NULL,
    [Deleted]       BIT            CONSTRAINT [DF_Contact_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contact_ContactType] FOREIGN KEY ([ContactTypeId]) REFERENCES [dbo].[ContactType] ([Id]),
    CONSTRAINT [FK_Contact_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([Id])
);

