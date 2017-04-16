USE [Department]
GO
/****** Object:  Table [dbo].[Library_Book]    Script Date: 2017/4/16 下午 12:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Library_Book](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[BookLanguage] [varchar](20) NOT NULL,
	[bookName] [nvarchar](80) NOT NULL,
	[BookType] [varchar](20) NOT NULL,
	[create_time] [datetime] NULL CONSTRAINT [DF_Library_Book_create_time]  DEFAULT (getdate()),
	[summary] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_dbo.Library_Book] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Library_BookImgae]    Script Date: 2017/4/16 下午 12:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Library_BookImgae](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[Image_Date] [datetime] NULL CONSTRAINT [DF_Library_BookImgae_Image_Date]  DEFAULT (getdate()),
	[Image_Path] [nvarchar](80) NULL,
 CONSTRAINT [PK_dbo.Library_BookImgae] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Library_UserInfo]    Script Date: 2017/4/16 下午 12:14:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Library_UserInfo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[LastPassWord] [varchar](120) NULL,
	[Lib_password] [varchar](120) NOT NULL,
	[Lib_username] [varchar](25) NOT NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_dbo.Library_UserInfo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Library_Book] ON 

INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (10, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:46:05.603' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (11, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:46:05.820' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (12, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:46:06.087' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (13, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:46:06.387' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (14, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:46:06.590' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (15, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:46:06.787' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (16, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:46:07.040' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (17, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:19.340' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (18, N'chinese', N'test', N'information', NULL, N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (19, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:19.707' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (20, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:19.867' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (21, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:20.030' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (22, N'chinese', N'testdadasdas', N'information', NULL, N'dasdadasda')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (23, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:20.350' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (24, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:20.510' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (25, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:20.670' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (26, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:20.827' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (27, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:20.987' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (28, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:21.147' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (29, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:21.303' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (30, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:21.467' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (31, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:21.627' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (32, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:21.790' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (33, N'chinese', N'test', N'information', NULL, N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (34, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:22.107' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (35, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:22.263' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (36, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:22.423' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (37, N'chinese', N'test', N'information', NULL, N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (38, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:22.747' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (39, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:22.907' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (40, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:23.080' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (42, N'chinese', N'test', N'information', CAST(N'2017-02-24 10:59:23.983' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (43, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:30.207' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (44, N'english', N'test', N'information', NULL, N'你好啊')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (45, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:30.670' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (46, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:30.827' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (47, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:30.983' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (48, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:31.140' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (49, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:31.300' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (50, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:31.470' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (51, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:31.630' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (52, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:31.790' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (53, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:31.950' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (54, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:32.107' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (55, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:32.263' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (56, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:32.423' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (57, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:32.580' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (58, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:32.737' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (59, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:32.893' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (60, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:33.050' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (61, N'english', N'test', N'information', CAST(N'2017-02-24 10:59:33.207' AS DateTime), N'test')
INSERT [dbo].[Library_Book] ([id], [BookLanguage], [bookName], [BookType], [create_time], [summary]) VALUES (1064, N'chinese', N'fsdfs', N'language', CAST(N'2017-03-09 13:31:41.860' AS DateTime), N'fsdfs')
SET IDENTITY_INSERT [dbo].[Library_Book] OFF
SET IDENTITY_INSERT [dbo].[Library_BookImgae] ON 

INSERT [dbo].[Library_BookImgae] ([Id], [BookId], [Image_Date], [Image_Path]) VALUES (7, 22, NULL, N'13031332s0h4.png')
SET IDENTITY_INSERT [dbo].[Library_BookImgae] OFF
SET IDENTITY_INSERT [dbo].[Library_UserInfo] ON 

INSERT [dbo].[Library_UserInfo] ([id], [LastPassWord], [Lib_password], [Lib_username], [ModifyDate]) VALUES (1, NULL, N'Lqcd21zj7uZRl1NHYy2GYGfab0z4zA4FDFiKhEvWdNp9ORtZuTAy3UdoqHs0sNymaErTW1F/iOATyLutXA8z9g==', N'abcd123', NULL)
INSERT [dbo].[Library_UserInfo] ([id], [LastPassWord], [Lib_password], [Lib_username], [ModifyDate]) VALUES (2, NULL, N'ATGOv3y+shGhm4iwUT572v04UhnOlgO1eQgG8heM2Knkt62ZpqdwLykyV8b8GtG39QyHAQhI4CK3qXjv34kZLA==', N'hello', NULL)
INSERT [dbo].[Library_UserInfo] ([id], [LastPassWord], [Lib_password], [Lib_username], [ModifyDate]) VALUES (3, NULL, N'tRoW/did2Jzo1fDRIUaZQmMXdkFYQliHGgOBrhS6ehwip1ArYngVqh7z+nAMj/BaN4xZDCbv8dT+QiPqhsgMbg==', N'aa123', NULL)
INSERT [dbo].[Library_UserInfo] ([id], [LastPassWord], [Lib_password], [Lib_username], [ModifyDate]) VALUES (4, NULL, N'tRoW/did2Jzo1fDRIUaZQmMXdkFYQliHGgOBrhS6ehwip1ArYngVqh7z+nAMj/BaN4xZDCbv8dT+QiPqhsgMbg==', N'aa1233', NULL)
INSERT [dbo].[Library_UserInfo] ([id], [LastPassWord], [Lib_password], [Lib_username], [ModifyDate]) VALUES (5, NULL, N'tRoW/did2Jzo1fDRIUaZQmMXdkFYQliHGgOBrhS6ehwip1ArYngVqh7z+nAMj/BaN4xZDCbv8dT+QiPqhsgMbg==', N'aa12345', NULL)
INSERT [dbo].[Library_UserInfo] ([id], [LastPassWord], [Lib_password], [Lib_username], [ModifyDate]) VALUES (1002, NULL, N'Lqcd21zj7uZRl1NHYy2GYGfab0z4zA4FDFiKhEvWdNp9ORtZuTAy3UdoqHs0sNymaErTW1F/iOATyLutXA8z9g==', N'aa123456', NULL)
SET IDENTITY_INSERT [dbo].[Library_UserInfo] OFF
ALTER TABLE [dbo].[Library_BookImgae]  WITH NOCHECK ADD  CONSTRAINT [FK_Library_BookImgae_Library_Book] FOREIGN KEY([BookId])
REFERENCES [dbo].[Library_Book] ([id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[Library_BookImgae] NOCHECK CONSTRAINT [FK_Library_BookImgae_Library_Book]
GO
