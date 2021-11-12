CREATE TABLE [dbo].[Articles] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (200) NOT NULL,
    [Author]      NVARCHAR (50)  NOT NULL,
    [Content]     NVARCHAR (MAX) NOT NULL,
    [Update_time] DATETIME       NOT NULL,
    [Class]       NVARCHAR (50)  NOT NULL,
    [Abstract]    NVARCHAR (500) NOT NULL,
    [Content_HASH] BINARY(32) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

