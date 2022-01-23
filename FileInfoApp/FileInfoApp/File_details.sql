USE [FileInfo]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[File_details](
	[Id] [int] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[FileName] [nvarchar](50) NULL,
	[CreationTime] [nvarchar](50) NULL,
	[Creator] [nvarchar](50) NULL
) ON [PRIMARY]
GO


