CREATE TABLE [dbo].[inventory] (
    [batch]          INT           IDENTITY (1, 1) NOT NULL,
    [quantity]       CHAR (10)     NULL,
    [expirationDate] DATE          NULL,
    [plantingTime]   CHAR (10)     NULL,
    [category]       VARCHAR (50)  NULL,
    [seedType]       VARCHAR (50)  NULL,
    [seedName]       NVARCHAR (50) NULL,
    CONSTRAINT [PK_inventory] PRIMARY KEY CLUSTERED ([batch] ASC)
);

