USE [MathDB]
GO


----------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------
-- questions
USE [MathDB]
GO

ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [FK_Questions_Topics_TopicId]
GO

ALTER TABLE [dbo].[Questions] DROP CONSTRAINT [DF__Questions__Topic__5AEE82B9]
GO

/****** Object:  Table [dbo].[Questions]    Script Date: 22-May-23 00:19:58  ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Questions]') AND type in (N'U'))
DROP TABLE [dbo].[Questions]
GO

/****** Object:  Table [dbo].[Questions]    Script Date: 22-May-23 00:19:58  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Questions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[TopicId] [int] NOT NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Questions] ADD  DEFAULT ((0)) FOR [TopicId]
GO

ALTER TABLE [dbo].[Questions]  WITH CHECK ADD  CONSTRAINT [FK_Questions_Topics_TopicId] FOREIGN KEY([TopicId])
REFERENCES [dbo].[Topics] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Questions] CHECK CONSTRAINT [FK_Questions_Topics_TopicId]
GO

----------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------
-- answers 

ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [FK_Answers_Questions_QuestionId]
GO

ALTER TABLE [dbo].[Answers] DROP CONSTRAINT [DF__Answers__Questio__5BE2A6F2]
GO

/****** Object:  Table [dbo].[Answers]    Script Date: 22-May-23 00:16:18  ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Answers]') AND type in (N'U'))
DROP TABLE [dbo].[Answers]
GO

/****** Object:  Table [dbo].[Answers]    Script Date: 22-May-23 00:16:18  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Answers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
	[IsCorrect] [bit] NOT NULL,
	[QuestionId] [int] NOT NULL,
 CONSTRAINT [PK_Answers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Answers] ADD  DEFAULT ((0)) FOR [QuestionId]
GO

ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions_QuestionId]
GO


----------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------
-- topic
USE [MathDB]
GO

/****** Object:  Table [dbo].[Topics]    Script Date: 22-May-23 00:21:10  ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Topics]') AND type in (N'U'))
DROP TABLE [dbo].[Topics]
GO

/****** Object:  Table [dbo].[Topics]    Script Date: 22-May-23 00:21:10  ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Topics](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NULL,
 CONSTRAINT [PK_Topics] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


