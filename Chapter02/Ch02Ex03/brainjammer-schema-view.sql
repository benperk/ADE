CREATE SCHEMA views
AUTHORIZATION dbo

CREATE VIEW [views].[PowThetaClassicalMusic] 
AS SELECT RE.READING_DATETIME, RE.[COUNT], RE.[VALUE] 
FROM [SESSION] SE, READING RE 
WHERE SE.MODE_ID = 2 AND SE.SCENARIO_ID = 1 AND RE.FREQUENCY_ID = 1

SELECT COUNT(*) FROM [views].[PowThetaClassicalMusic]
SELECT TOP 10 * FROM [views].[PowThetaClassicalMusic]

CREATE VIEW [views].[PowThetaMeditation]
AS SELECT RE.READING_DATETIME, RE.[COUNT], RE.[VALUE] 
FROM [SESSION] SE, READING RE 
WHERE SE.MODE_ID = 2 AND SE.SCENARIO_ID = 2 AND RE.FREQUENCY_ID = 1

CREATE VIEW [views].[PowThetaMetalMusic] 
AS SELECT RE.READING_DATETIME, RE.[COUNT], RE.[VALUE] 
FROM [SESSION] SE, READING RE 
WHERE SE.MODE_ID = 2 AND SE.SCENARIO_ID = 4 AND RE.FREQUENCY_ID = 1

CREATE VIEW [views].[PowThetaTikTok] 
AS SELECT RE.READING_DATETIME, RE.[COUNT], RE.[VALUE] 
FROM [SESSION] SE, READING RE 
WHERE SE.MODE_ID = 2 AND SE.SCENARIO_ID = 6 AND RE.FREQUENCY_ID = 1

select count(*) from views.PowThetaClassicalMusic
select count(*) from views.PowThetaMeditation
select count(*) from views.PowThetaMetalMusic
select count(*) from views.PowThetaTikTok
