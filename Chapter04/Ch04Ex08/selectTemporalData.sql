--Temporal Tables
SELECT * FROM [brainwaves].[DimMODE]
SELECT * FROM [brainwaves].[DimSCENARIO]
SELECT * FROM [brainwaves].[DimELECTRODE]
SELECT * FROM [brainwaves].[DimFREQUENCY]
SELECT * FROM [brainwaves].[DimSESSION]
--History Tables
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_2002106173] --DimMODE
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_2050106344] --DimSCENARIO
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_2098106515] --DimELECTRODE
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_2146106686] --DimFREQUENCY
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_46623209]   --DimSESSION
