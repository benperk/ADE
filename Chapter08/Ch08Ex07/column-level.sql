--master--
CREATE LOGIN brainjammer WITH PASSWORD = 'csh@rpgu1tar'

--SQLPool--
CREATE USER brainjammer FROM LOGIN brainjammer WITH DEFAULT_SCHEMA = dbo
EXEC sp_addrolemember 'db_datareader', 'brainjammer'

DENY SELECT ON dbo.SUBJECTS TO brainjammer

GRANT SELECT ON SUBJECTS 
 (ID, FIRSTNAME, LASTNAME, EMAIL, COUNTRY, CREATE_DATE) TO brainjammer

--using brainjammer identity SQL--
SELECT * FROM [dbo].[SUBJECTS]
