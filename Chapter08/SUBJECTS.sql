--DROP TABLE dbo.SUBJECTS
--GO
CREATE TABLE [dbo].[SUBJECTS] (
    [ID] 	        INT	    	    NOT NULL IDENTITY(1,1),
    [FIRSTNAME]		NVARCHAR (50)	NOT NULL,
    [LASTNAME]		NVARCHAR (50)	NOT NULL,
    [BIRTHDATE]		DATETIME  	    NOT NULL,
    [USERNAME] 		NVARCHAR (50)	NOT NULL,
    [EMAIL] 		NVARCHAR (50)	NOT NULL,
    [ZIPCODE] 		INT	    	    NOT NULL,
    [COUNTRY]  		NVARCHAR (50)	NOT NULL,
    [CREATE_DATE]   DATETIME  	    NOT NULL
)
WITH
(
    DISTRIBUTION = HASH (CREATE_DATE),
    CLUSTERED COLUMNSTORE INDEX
)
GO
INSERT INTO [dbo].[SUBJECTS] SELECT 'BENJAMIN', 'PERKINS', '19880730 08:00:00 AM', 'CSHARPGUITAR', 'benjamin@csharpguitar.net', 70000, 'USA', CAST(GETDATE() AS DATE)
INSERT INTO [dbo].[SUBJECTS] SELECT 'RUAL', 'PERKINS', '19180730 08:00:00 AM', 'DANCEMEISTER', 'rual@csharpguitar.net', 70001, 'USA', CAST(GETDATE() AS DATE)
GO 
SELECT * FROM [dbo].[SUBJECTS]
GO
