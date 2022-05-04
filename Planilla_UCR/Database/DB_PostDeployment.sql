/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
Use: on Remote DB
First run post deployment to fill remote BD tables. then run Blazor app
*/

USE PatatasConSueno

CREATE TABLE [dbo].[Projects]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Project_Name] NCHAR(100) NULL, 
    [Publication] INT NULL, 
    [Group] NCHAR(100) NULL
)


MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(1, 'Project1', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(2, 'Project2', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(3, 'Project3', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(4, 'Project4', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(5, 'Project5', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(6, 'Project6', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(7, 'Project7', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(8, 'Project8', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(9, 'Project9', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);

MERGE INTO [dbo].[Projects] AS TARGET
USING 
(VALUES 
(10, 'Project10', 12, 'PatatasConSueno'))
AS SOURCE ([Id],[Project_Name],[Publication],[Group]) ON TARGET.[Id] = SOURCE.[Id]
WHEN NOT MATCHED BY TARGET THEN
INSERT ([Id],[Project_Name],[Publication],[Group]) VALUES ([Id],[Project_Name],[Publication],[Group]);