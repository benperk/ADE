DECLARE @SK_ID AS VARCHAR(10)
DECLARE @START_DATE AS DATETIME2 = GETDATE()
SELECT @SK_ID = CONCAT('E', COUNT(*) + 1) FROM brainwaves.DimELECTRODE
INSERT INTO [brainwaves].[DimELECTRODE] ([SK_ID], [ELECTRODE], [LOCATION], [START_DATE], [END_DATE], [IS_CURRENT]) 
	VALUES (@SK_ID, 'AF3', 'Front Left', @START_DATE, '9999-12-31 23:59:59', 1)
SELECT @SK_ID = CONCAT('E', COUNT(*) + 1) FROM brainwaves.DimELECTRODE
INSERT INTO [brainwaves].[DimELECTRODE] ([SK_ID], [ELECTRODE], [LOCATION], [START_DATE], [END_DATE], [IS_CURRENT]) 
	VALUES (@SK_ID, 'AF4', 'Front Right', @START_DATE, '9999-12-31 23:59:59', 1)
SELECT @SK_ID = CONCAT('E', COUNT(*) + 1) FROM brainwaves.DimELECTRODE
INSERT INTO [brainwaves].[DimELECTRODE] ([SK_ID], [ELECTRODE], [LOCATION], [START_DATE], [END_DATE], [IS_CURRENT]) 
	VALUES (@SK_ID, 'T7', 'Ear Left', @START_DATE, '9999-12-31 23:59:59', 1)
SELECT @SK_ID = CONCAT('E', COUNT(*) + 1) FROM brainwaves.DimELECTRODE
INSERT INTO [brainwaves].[DimELECTRODE] ([SK_ID], [ELECTRODE], [LOCATION], [START_DATE], [END_DATE], [IS_CURRENT]) 
	VALUES (@SK_ID, 'T8', 'Ear Right', @START_DATE, '9999-12-31 23:59:59', 1)
SELECT @SK_ID = CONCAT('E', COUNT(*) + 1) FROM brainwaves.DimELECTRODE
INSERT INTO [brainwaves].[DimELECTRODE] ([SK_ID], [ELECTRODE], [LOCATION], [START_DATE], [END_DATE], [IS_CURRENT]) 
	VALUES (@SK_ID, 'Pz', 'Center Back', @START_DATE, '9999-12-31 23:59:59', 1)
