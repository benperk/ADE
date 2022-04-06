--Modify Tables
UPDATE [brainwaves].[DimSCENARIO] SET SCENARIO = 'Flipboard' WHERE SCENARIO_ID = 2
UPDATE [brainwaves].[DimELECTRODE] SET ELECTRODE = 'AF3i', LOCATION = 'Top Left' WHERE ELECTRODE_ID = 1
UPDATE [brainwaves].[DimFREQUENCY] SET ACTIVITY = 'Creativity, Emotional Connection' WHERE FREQUENCY_ID = 1
UPDATE [brainwaves].[DimFREQUENCY] SET ACTIVITY = 'Concentration, Memory' WHERE FREQUENCY_ID = 4
UPDATE [brainwaves].[DimFREQUENCY] SET ACTIVITY = 'Learning, Perception' WHERE FREQUENCY_ID = 5
