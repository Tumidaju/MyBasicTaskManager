SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[COLOR] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_CATEGORY] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RANK]    Script Date: 19.01.2019 11:25:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RANK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[COLOR] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_RANKS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[STATUS]    Script Date: 19.01.2019 11:25:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STATUS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[COLOR] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_STATUSES] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TASK]    Script Date: 19.01.2019 11:25:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TASK](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](50) NOT NULL,
	[DESCRIPTION] [nvarchar](255) NOT NULL,
	[CARD_COLOR] [nvarchar](10) NOT NULL,
	[FONT_COLOR] [nvarchar](10) NOT NULL,
	[CREATION_DATE] [datetime2](7) NOT NULL,
	[LAST_EDIT_DATE] [datetime2](7) NULL,
	[COMPLETION_DATE] [datetime2](7) NULL,
	[DEADLINE_DATE] [datetime2](7) NULL,
	[PROGRES] [int] NOT NULL,
	[CATEGORY_ID] [int] NOT NULL,
	[RANK_ID] [int] NOT NULL,
	[STATUS_ID] [int] NOT NULL,
	[USER_ID] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_TASK] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[STATISTICS](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[USER_ID] [nvarchar](128) NOT NULL,
	[CREATED_TASKS] [int] NULL,
	[FINISHED_TASKS] [int] NULL,
	[DELETED_TASKS] [int] NULL,
	[TASKS_WITH_DEADLINE] [int] NULL,
	[TASKS_FINISHED_BEFORE_DEADLINE] [int] NULL,
	[FIRST_TASK_CREATION] [datetime2](7) NULL,
	[LAST_TAKS_CREATION] [datetime2](7) NULL,
 CONSTRAINT [PK_[STATISTICS] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'458552de-cd9b-47ce-b9cb-bb8c08c823ee', N'admin@mbtm.pl', 0, N'ABTbak4Wc4MMLHsMyoYqKNhPMkzJsSEP4SLBKk9BJXEoP9Vo14J584tdH1bdOgylXg==', N'8a129180-2e30-42c6-9603-01eae06330b4', NULL, 0, 0, NULL, 1, 0, N'admin@mbtm.pl')
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'458552de-cd9b-47ce-b9cb-bb8c08c823eb', N'demo@mbtm.pl', 0, N'ABTbak4Wc4MMLHsMyoYqKNhPMkzJsSEP4SLBKk9BJXEoP9Vo14J584tdH1bdOgylXg==', N'8a129180-2e30-42c6-9603-01eae06330b4', NULL, 0, 0, NULL, 1, 0, N'demo@mbtm.pl')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1', N'admin')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'458552de-cd9b-47ce-b9cb-bb8c08c823ee', N'1')
SET IDENTITY_INSERT [dbo].[STATISTICS] ON 
INSERT [dbo].[STATISTICS] ([ID], [USER_ID],[CREATED_TASKS],[FINISHED_TASKS],[DELETED_TASKS],[TASKS_WITH_DEADLINE],[TASKS_FINISHED_BEFORE_DEADLINE],[FIRST_TASK_CREATION],[LAST_TAKS_CREATION]) VALUES (1, N'458552de-cd9b-47ce-b9cb-bb8c08c823ee',1,1,1,1,1,CAST(N'2019-01-15T00:00:00.0000000' AS DateTime2),CAST(N'2019-01-15T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[STATISTICS] ([ID], [USER_ID],[CREATED_TASKS],[FINISHED_TASKS],[DELETED_TASKS],[TASKS_WITH_DEADLINE],[TASKS_FINISHED_BEFORE_DEADLINE],[FIRST_TASK_CREATION],[LAST_TAKS_CREATION]) VALUES (2, N'458552de-cd9b-47ce-b9cb-bb8c08c823eb',29,19,23,12,11,CAST(N'2019-01-24T13:00:45.0156494' AS DateTime2),CAST(N'2019-01-28T13:00:45.0156494' AS DateTime2))
SET IDENTITY_INSERT [dbo].[STATISTICS] OFF
SET IDENTITY_INSERT [dbo].[STATUS] ON 
INSERT [dbo].[STATUS] ([ID], [NAME], [COLOR]) VALUES (1, N'Backlog', N'#15D5E0')
INSERT [dbo].[STATUS] ([ID], [NAME], [COLOR]) VALUES (2, N'To do', N'#F1A532')
INSERT [dbo].[STATUS] ([ID], [NAME], [COLOR]) VALUES (3, N'In progress', N'#F1D41A')
INSERT [dbo].[STATUS] ([ID], [NAME], [COLOR]) VALUES (4, N'Done', N'#57BD16')
SET IDENTITY_INSERT [dbo].[STATUS] OFF
SET IDENTITY_INSERT [dbo].[RANK] ON 
INSERT [dbo].[RANK] ([ID], [NAME], [COLOR]) VALUES (1, N'High Priority', N'#E52000')
INSERT [dbo].[RANK] ([ID], [NAME], [COLOR]) VALUES (2, N'Medium Priority', N'#FFF50B')
INSERT [dbo].[RANK] ([ID], [NAME], [COLOR]) VALUES (3, N'Low Priority', N'#13FF03')
SET IDENTITY_INSERT [dbo].[RANK] OFF
SET IDENTITY_INSERT [dbo].[CATEGORY] ON 
INSERT [dbo].[CATEGORY] ([ID], [NAME], [COLOR]) VALUES (1, N'Primary', N'#BA2EBD')
INSERT [dbo].[CATEGORY] ([ID], [NAME], [COLOR]) VALUES (2, N'Secondary', N'#00BD1C')
SET IDENTITY_INSERT [dbo].[CATEGORY] OFF
SET IDENTITY_INSERT [dbo].[TASK] ON 
INSERT [dbo].[TASK] ([ID], [NAME], [DESCRIPTION], [CARD_COLOR], [FONT_COLOR], [CREATION_DATE], [LAST_EDIT_DATE],[COMPLETION_DATE], [DEADLINE_DATE], [PROGRES], [CATEGORY_ID], [RANK_ID], [STATUS_ID], [USER_ID]) VALUES (1, N'Task1', N'Description1', N'#424234', N'#523424', CAST(N'2019-01-19T00:00:00.0000000' AS DateTime2), NULL, NULL, CAST(N'2019-01-31T00:00:00.0000000' AS DateTime2), 47, 1, 1, 3, N'458552de-cd9b-47ce-b9cb-bb8c08c823eb')
INSERT [dbo].[TASK] ([ID], [NAME], [DESCRIPTION], [CARD_COLOR], [FONT_COLOR], [CREATION_DATE], [LAST_EDIT_DATE],[COMPLETION_DATE], [DEADLINE_DATE], [PROGRES], [CATEGORY_ID], [RANK_ID], [STATUS_ID], [USER_ID]) VALUES (2, N'Task2', N'Description2', N'#bebe00', N'#52c242', CAST(N'2019-01-20T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, 0, 1, 2, 1, N'458552de-cd9b-47ce-b9cb-bb8c08c823eb')
INSERT [dbo].[TASK] ([ID], [NAME], [DESCRIPTION], [CARD_COLOR], [FONT_COLOR], [CREATION_DATE], [LAST_EDIT_DATE],[COMPLETION_DATE], [DEADLINE_DATE], [PROGRES], [CATEGORY_ID], [RANK_ID], [STATUS_ID], [USER_ID]) VALUES (3, N'Task3', N'Description3', N'#aa4524', N'#bebe00', CAST(N'2019-01-21T00:00:00.0000000' AS DateTime2), NULL, NULL, NULL, 0, 1, 3, 1, N'458552de-cd9b-47ce-b9cb-bb8c08c823eb')
INSERT [dbo].[TASK] ([ID], [NAME], [DESCRIPTION], [CARD_COLOR], [FONT_COLOR], [CREATION_DATE], [LAST_EDIT_DATE],[COMPLETION_DATE], [DEADLINE_DATE], [PROGRES], [CATEGORY_ID], [RANK_ID], [STATUS_ID], [USER_ID]) VALUES (4, N'Task4', N'Description4', N'#bebe00', N'#52c242', CAST(N'2019-01-20T13:00:45.0156494' AS DateTime2), NULL, NULL, NULL, 0, 1, 2, 2, N'458552de-cd9b-47ce-b9cb-bb8c08c823eb')
INSERT [dbo].[TASK] ([ID], [NAME], [DESCRIPTION], [CARD_COLOR], [FONT_COLOR], [CREATION_DATE], [LAST_EDIT_DATE],[COMPLETION_DATE], [DEADLINE_DATE], [PROGRES], [CATEGORY_ID], [RANK_ID], [STATUS_ID], [USER_ID]) VALUES (5, N'Task5', N'Description5', N'#52c242', N'#52c242', CAST(N'2019-01-22T13:00:45.0156494' AS DateTime2), NULL, NULL, NULL, 27, 2, 2, 3, N'458552de-cd9b-47ce-b9cb-bb8c08c823eb')
INSERT [dbo].[TASK] ([ID], [NAME], [DESCRIPTION], [CARD_COLOR], [FONT_COLOR], [CREATION_DATE], [LAST_EDIT_DATE],[COMPLETION_DATE], [DEADLINE_DATE], [PROGRES], [CATEGORY_ID], [RANK_ID], [STATUS_ID], [USER_ID]) VALUES (6, N'Task6', N'Description6', N'#bebe00', N'#52c242', CAST(N'2019-01-24T13:00:45.0156494' AS DateTime2), CAST(N'2019-01-27T13:00:45.0156494' AS DateTime2), CAST(N'2019-01-27T13:00:45.0156494' AS DateTime2), CAST(N'2019-01-28T13:00:45.0156494' AS DateTime2), 100, 2, 3, 4, N'458552de-cd9b-47ce-b9cb-bb8c08c823eb')
SET IDENTITY_INSERT [dbo].[TASK] OFF
SET ANSI_PADDING ON
GO
ALTER TABLE [dbo].[STATISTICS]  WITH CHECK ADD  CONSTRAINT [FK_STATISTICS_AspNetUsers] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[STATISTICS] CHECK CONSTRAINT [FK_STATISTICS_AspNetUsers]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_AspNetUsers] FOREIGN KEY([USER_ID])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_AspNetUsers]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_CATEGORY] FOREIGN KEY([CATEGORY_ID])
REFERENCES [dbo].[CATEGORY] ([ID])
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_CATEGORY]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_RANK] FOREIGN KEY([RANK_ID])
REFERENCES [dbo].[RANK] ([ID])
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_RANK]
GO
ALTER TABLE [dbo].[TASK]  WITH CHECK ADD  CONSTRAINT [FK_TASK_STATUS] FOREIGN KEY([STATUS_ID])
REFERENCES [dbo].[STATUS] ([ID])
GO
ALTER TABLE [dbo].[TASK] CHECK CONSTRAINT [FK_TASK_STATUS]
GO
