USE [MathDB]
GO

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-- topics

INSERT INTO [dbo].[Topics] ([Text])
VALUES ('Arithmetic');

INSERT INTO [dbo].[Topics] ([Text])
VALUES ('Geometry')

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

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2/2',1);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+4',1);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+5',1);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+6',1);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+7',1);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+8',1);

INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+9',1);
--10
INSERT INTO [dbo].[Questions]([Text], [TopicId])
     VALUES ('2+10',1);


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


--
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

