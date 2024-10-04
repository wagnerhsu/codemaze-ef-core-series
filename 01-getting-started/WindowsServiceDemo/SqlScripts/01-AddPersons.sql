USE [codemaze-service-demo]
GO
/****** Object:  Table [dbo].[Persons]    Script Date: 2024/10/4 20:35:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Age] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Persons] ON 
GO
INSERT [dbo].[Persons] ([Id], [Name], [Age]) VALUES (1, N'Test', 19)
GO
INSERT [dbo].[Persons] ([Id], [Name], [Age]) VALUES (2, N'Tom', 20)
GO
INSERT [dbo].[Persons] ([Id], [Name], [Age]) VALUES (3, N'Wagner', 50)
GO
SET IDENTITY_INSERT [dbo].[Persons] OFF
GO
