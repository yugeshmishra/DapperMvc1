USE [newdb]
GO

DROP TABLE [dbo].[Employees]
GO

CREATE TABLE [dbo].[Employees] (
	[Id] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Name] [varchar](50) NULL,
	[Salary] [int] NULL,
	[Email] [varchar](50) NULL
) ON [PRIMARY]
GO


