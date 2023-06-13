USE [MathDB]
GO

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-- topics
USE [MathDB]
GO

-- math 1
INSERT INTO [dbo].[Topics]([Text])
VALUES(N'Math')
GO

-- algebra 2
INSERT INTO [dbo].[Topics]([Text])
VALUES(N'Algebra')
GO

-- Geometry 3
INSERT INTO [dbo].[Topics]([Text])
VALUES ('Geometry')
GO

--Quadratic equations 4
INSERT INTO [dbo].[Topics]([Text])
VALUES (N'Quadratic equations')
GO

-- Arithmetic 5
INSERT INTO [dbo].[Topics]([Text])
VALUES('Arithmetic');
GO

-- Trigonometry 6
INSERT INTO [dbo].[Topics]([Text])
VALUES('Trigonometry');
GO

-- Geometry_Definitions 7
INSERT INTO [dbo].[Topics]([Text])
VALUES ('Geometry_Definitions')
GO

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-- CHILDREN topics
USE [MathDB]
GO

-- math 1
INSERT INTO [dbo].[ChildrenTopics]([Text])
VALUES(N'Math')
GO

-- algebra 2
INSERT INTO [dbo].[ChildrenTopics]([Text])
VALUES(N'Algebra')
GO

-- Geometry 3
INSERT INTO [dbo].[ChildrenTopics]([Text])
VALUES ('Geometry')
GO

--Quadratic equations 4
INSERT INTO [dbo].[ChildrenTopics]([Text])
VALUES (N'Quadratic equations')
GO

-- Arithmetic 5
INSERT INTO [dbo].[ChildrenTopics]([Text])
VALUES('Arithmetic');
GO

-- Trigonometry 6
INSERT INTO [dbo].[ChildrenTopics]([Text])
VALUES('Trigonometry');
GO

-- Geometry_Definitions 7
INSERT INTO [dbo].[ChildrenTopics]([Text])
VALUES ('Geometry_Definitions')
GO

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
--topic to topic m:n
USE [MathDB]
GO

--parent 1
INSERT INTO [dbo].[ChildrenTopicTopic]([ChildrenTopicsId],[TopicsId])
VALUES(2,1)
GO

INSERT INTO [dbo].[ChildrenTopicTopic]([ChildrenTopicsId],[TopicsId])
VALUES(3,1)
GO

-- parent 2
INSERT INTO [dbo].[ChildrenTopicTopic]([ChildrenTopicsId],[TopicsId])
VALUES(4,2)
GO

INSERT INTO [dbo].[ChildrenTopicTopic]([ChildrenTopicsId],[TopicsId])
VALUES(6,2)
GO

-- parent 3
INSERT INTO [dbo].[ChildrenTopicTopic]([ChildrenTopicsId],[TopicsId])
VALUES(6,3)
GO

-- parent 4
INSERT INTO [dbo].[ChildrenTopicTopic]([ChildrenTopicsId],[TopicsId])
VALUES(5,4)
GO

-- parent 5
-- parent 6
INSERT INTO [dbo].[ChildrenTopicTopic]([ChildrenTopicsId],[TopicsId])
VALUES(7,6)
GO



-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-- questions
USE [MathDB]
GO

-- Arithmetic questions, id 5
-- 1
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+2',5);

-- 2
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2*2',5);

GO


-- Geometry_Definitions  questions, id 7
-- 3
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'Абсолютна координата',7);

-- 4
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'Абсциса',7);



GO

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-- answers

USE [MathDB]
GO

--1
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 1);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 1);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 1);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (4, 1, 1);
--2
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 2);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 2);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 2);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (4, 1, 2);



GO
--3
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 3);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 3);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 3);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'координата, яка визначає розташування точки відносно початку заданої системи координат.', 1, 3);

--4
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 4);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 4);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 4);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'число, яке визна­чає положення деякої точки на площині або у просторі відносно осі X у прямокутній сис­темі координат.', 1, 4);



--http://zno.academia.in.ua/mod/glossary/view.php?id=1063&mode=letter&hook=%D0%90&sortkey=&sortorder=

--
-- books

-- arithmetic books
USE [MathDB]
GO

INSERT INTO [dbo].[Books]
           ([Text]
           ,[TopicId])
     VALUES
           (N'Весела арифметика — Ольга Конобевська, Тамара Маршалова, Наталія Латушко',1)
GO

INSERT INTO [dbo].[Books]
           ([Text]
           ,[TopicId])
     VALUES
           (N'Big Book of Math Practice Problems Addition and Subtraction, Grades 1-3 - Stacy Otillio, Frank Otillio',1)
GO


-- geometry books
USE [MathDB]
GO

INSERT INTO [dbo].[Books]
           ([Text]
           ,[TopicId])
     VALUES
           (N'Humble Math Area, Perimeter, Volume, & Surface Area: Geometry for Beginners - Workbook with Answer Key Elementary, Middle School, High School Math – Geometry for Kids',2)
GO

INSERT INTO [dbo].[Books]
           ([Text]
           ,[TopicId])
     VALUES
           (N'Geometry Seeing, Doing, Understanding - Harold R. Jacobs',2)
GO

-- algebra books


-- Quadratic equations books

INSERT INTO [dbo].[Books]
           ([Text]
           ,[TopicId])
     VALUES
           (N'Summit Math Algebra 1 Book 5: Factoring Polynomials and Solving Quadratic Equations (Guided Discovery Algebra 1 Series - 2nd Edition)',5)
GO

INSERT INTO [dbo].[Books]
           ([Text]
           ,[TopicId])
     VALUES
           (N'Summit Math Algebra 2 Book 3: Quadratic Equations and Parabolas (Guided Discovery Algebra 2 Series - 2nd Edition)',5)
GO


INSERT INTO [dbo].[Books]
           ([Text]
           ,[TopicId])
     VALUES
           (N'Algebra Essentials Practice Workbook with Answers: Linear & Quadratic Equations, Cross Multiplying, and Systems of Equations: Improve Your Math Fluency Series',5)
GO

--
-- questions for quadratic equations

USE [MathDB]
GO

INSERT INTO [dbo].[Questions]
           ([Text]
           ,[TopicId])
     VALUES
           (N'x*x - 10x + 25 = 0. x-?', 5)
GO


INSERT INTO [dbo].[Questions]
           ([Text]
           ,[TopicId])
     VALUES
           (N'x*x - 12x + 36 = 0. x-?', 5)
GO

INSERT INTO [dbo].[Questions]
           ([Text]
           ,[TopicId])
     VALUES
           (N'x*x - 14x + 49 = 0. x-?', 5)
GO



USE [MathDB]
GO

-- answers21
INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (1, 0, 21)
GO

INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (2, 0, 21)
GO


INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (3, 0, 21)
GO


INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (5, 1, 21)
GO

--

-- answers22
INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (1, 0, 22)
GO

INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (2, 0, 22)
GO


INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (3, 0, 22)
GO


INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (6, 1, 22)
GO

-- answers 23
INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (1, 0, 23)
GO

INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (2, 0, 23)
GO


INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (3, 0, 23)
GO


INSERT INTO [dbo].[Answers]
           ([Text]
           ,[IsCorrect]
           ,[QuestionId])
     VALUES
           (7, 1, 23)
GO

