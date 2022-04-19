--DROP TABLE [brainwaves].[FactREADING]
--DROP PROCEDURE [brainwaves].[uspCreateAndPopualteFactReading]

CREATE PROCEDURE brainwaves.uspCreateAndPopualteFactReading
AS 
    CREATE TABLE [brainwaves].[FactREADING]
    WITH
    (
    CLUSTERED COLUMNSTORE INDEX,
    DISTRIBUTION = HASH ([FREQUENCY])
    )
    AS
    SELECT  TOP (10) se.SESSION_DATETIME, r.READING_DATETIME, 
            s.SCENARIO, e.ELECTRODE, f.FREQUENCY, r.[VALUE]
    FROM    [brainwaves].[DimSESSION] se, [brainwaves].[TmpREADING] r, 
            [brainwaves].[DimSCENARIO] s, [brainwaves].[DimELECTRODE] e, 
            [brainwaves].[DimFREQUENCY] f
    WHERE   r.SESSION_ID = se.SESSION_ID AND se.SCENARIO_ID = s.SCENARIO_ID 
            AND r.ELECTRODE_ID = e.ELECTRODE_ID AND r.FREQUENCY_ID = f.FREQUENCY_ID;
GO
