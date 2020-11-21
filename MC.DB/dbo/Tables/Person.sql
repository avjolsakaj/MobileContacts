CREATE TABLE [dbo].[Person] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]  NVARCHAR (250) NOT NULL,
    [LastName]   NVARCHAR (250) NOT NULL,
    [MiddleName] NVARCHAR (250) NULL,
    [IsActive]   BIT            CONSTRAINT [DF_Person_IsActive] DEFAULT ((1)) NOT NULL,
    [Deleted]    BIT            CONSTRAINT [DF_Person_Deleted] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC)
);

