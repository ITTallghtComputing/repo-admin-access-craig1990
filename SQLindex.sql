ALTER TABLE dbo.School2
ALTER COLUMN RollNumber VARCHAR(20) NULL;

CREATE UNIQUE NONCLUSTERED INDEX [mIndex] ON [dbo].[School2]([RollNumber] ASC) WITH (IGNORE_DUP_KEY = ON);

EXEC sp_helpindex 'dbo.School2'
GO

