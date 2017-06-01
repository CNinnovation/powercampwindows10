CREATE TABLE [dbo].[Table]
(
	[BookId] INT NULL PRIMARY KEY, 
    [Title] NCHAR(40) NOT NULL, 
    [Author] NCHAR(20) NOT NULL, 
    [Publisher] NCHAR(20) NOT NULL, 
    [Year] INT NOT NULL
)
