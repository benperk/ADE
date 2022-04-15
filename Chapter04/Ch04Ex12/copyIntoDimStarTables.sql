COPY INTO [brainwaves].[DimMODE]
FROM 'https://csharpguitar.blob.core.windows.net/brainjammer/Tables/MODE.csv'
WITH (
    FILE_TYPE='CSV',
    FIRSTROW = 2
)
GO
COPY INTO [brainwaves].[DimSCENARIO]
FROM 'https://csharpguitar.blob.core.windows.net/brainjammer/Tables/SCENARIO.csv'
WITH (
    FILE_TYPE='CSV',
    FIRSTROW = 2
)
GO
COPY INTO [brainwaves].[DimELECTRODE]
FROM 'https://csharpguitar.blob.core.windows.net/brainjammer/Tables/ELECTRODE.csv'
WITH (
    FILE_TYPE='CSV',
    FIRSTROW = 2
)
GO
COPY INTO [brainwaves].[DimFREQUENCY]
FROM 'https://csharpguitar.blob.core.windows.net/brainjammer/Tables/FREQUENCY.csv'
WITH (
    FILE_TYPE='CSV',
    FIRSTROW = 2
)
GO
COPY INTO [brainwaves].[DimSESSION]
FROM 'https://csharpguitar.blob.core.windows.net/brainjammer/Tables/SESSION.csv'
WITH (
    FILE_TYPE='CSV',
    FIRSTROW = 2
)
GO
