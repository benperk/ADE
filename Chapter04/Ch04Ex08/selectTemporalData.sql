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
--Temporal / History Tables
SELECT * FROM [brainwaves].[DimSCENARIO]
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_2050106344] --DimSCENARIO
SELECT * FROM [brainwaves].[DimELECTRODE]
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_2098106515] --DimELECTRODE
SELECT * FROM [brainwaves].[DimFREQUENCY]
SELECT * FROM [brainwaves].[MSSQL_TemporalHistoryFor_2146106686] --DimFREQUENCY
--Temporal / History Time Travel
SELECT * FROM [brainwaves].[DimFREQUENCY] FOR SYSTEM_TIME AS OF '2022-04-06 15:58:56'
SELECT * FROM [brainwaves].[DimFREQUENCY] FOR SYSTEM_TIME AS OF '2022-04-06 16:00:00'
