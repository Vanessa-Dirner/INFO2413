CREATE TABLE [dbo].[staff] (
    [userid]      INT          IDENTITY (1, 1) NOT NULL,
    [firstName]   VARCHAR (50) NULL,
    [lastName]    VARCHAR (50) NULL,
    [jobRole]     VARCHAR (50) NULL,
    [eMail]       VARCHAR (50) NULL,
    [userName]    VARCHAR (50) NULL,
    [passwordKey] VARCHAR (50) NULL,
    CONSTRAINT [PK_staff] PRIMARY KEY CLUSTERED ([userid] ASC)
);

