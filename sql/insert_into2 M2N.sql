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
VALUES ('Geometry', null)
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
VALUES ('Geometry', null)
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
-- questions
USE [MathDB]
GO

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+2',1);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2*2',1);



GO
--11
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'��������� ����������',2);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'�������',2);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'������',2);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'����������',2);
--15
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'�������',2);
--

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'³������ ����',2);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'³�������� ���',2);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'³�����',2);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'³������ �� ����� �� �����',2);
--20
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES (N'³������ �� ����� �������',2);


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
--3
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (0, 0, 3);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 3);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 3);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 1, 3);
--4
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 4);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 4);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 4);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (6, 1, 4);
--5
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 5);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 5);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 5);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (7, 1, 5);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 6);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 6);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 6);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (8, 1, 6);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 7);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 7);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 7);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (9, 1, 7);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 8);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 8);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 8);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (10, 1, 8);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 9);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 9);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 9);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (11, 1, 9);
--10
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 10);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 10);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 10);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (12, 1, 10);


GO
--11
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 11);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 11);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 11);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'����������, ��� ������� ������������ ����� ������� ������� ������ ������� ���������.', 1, 11);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 12);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 12);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 12);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'�����, ��� ������� ��������� ����� ����� �� ������ ��� � ������� ������� �� X � ���������� ������ ���������.', 1, 12);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 13);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 13);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 13);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'����������, ��� ���������� �� ��� (��� ���������).', 1, 13);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 14);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 14);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 14);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'��������� ����� ���� �����, ��������� � ����� �������.', 1, 14);
--15
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 15);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 15);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 15);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'���� � ���������� ��������� ����� � �������; ��� Z.', 1, 15);

--16
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 16);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 16);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 16);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'����, �� ������ �� ���� �� �� ����, ��� ���� �� ��� ������ �� �������� �������, � ����� �� ������ �� ����.', 1, 16);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 17);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 17);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 17);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'���� �� ���� ��� ���������� ���� ������� �����..', 1, 17);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 18);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 18);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 18);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'������� �����, �������� ����� �������.', 1, 18);

INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 19);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 19);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 19);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'������� ��������������, ��������� �� ���� ����� �� ���� �����.', 1, 19);
--20
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (1, 0, 20);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (2, 0, 20);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (3, 0, 20);
INSERT INTO [dbo].[Answers] ([Text], [IsCorrect], [QuestionId])
     VALUES (N'������� ����������� ������ �� ���� �������� ������ ����������� ���������.', 1, 20);


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
           (N'������ ���������� � ����� �����������, ������ ���������, ������ �������',1)
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
           (N'Humble Math Area, Perimeter, Volume, & Surface Area: Geometry for Beginners - Workbook with Answer Key Elementary, Middle School, High School Math � Geometry for Kids',2)
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

