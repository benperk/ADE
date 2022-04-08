CREATE DATABASE BRAINJAMMER
COLLATE Latin1_General_100_BIN2_UTF8

CREATE EXTERNAL DATA SOURCE SampleBrainwavesSource
WITH (LOCATION = 'abfss://brainjammer@csharpguitar.dfs.core.windows.net')

CREATE EXTERNAL FILE FORMAT SampleBrainwavesParquet
WITH  (FORMAT_TYPE = PARQUET) 

CREATE EXTERNAL TABLE SampleBrainwaves
(
 [Timestamp] NVARCHAR(50),
 [AF3theta] NVARCHAR(50),
 [AF3alpha] NVARCHAR(50),
 [AF3betaL] NVARCHAR(50),
 [AF3betaH] NVARCHAR(50),
 [AF3gamma] NVARCHAR(50),
 [T7theta] NVARCHAR(50),
 [T7alpha] NVARCHAR(50),
 [T7betaL] NVARCHAR(50),
 [T7betaH] NVARCHAR(50),
 [T7gamma] NVARCHAR(50),
 [Pztheta] NVARCHAR(50),
 [Pzalpha] NVARCHAR(50),
 [PzbetaL] NVARCHAR(50),
 [PzbetaH] NVARCHAR(50),
 [Pzgamma] NVARCHAR(50),
 [T8theta] NVARCHAR(50),
 [T8alpha] NVARCHAR(50),
 [T8betaL] NVARCHAR(50),
 [T8betaH] NVARCHAR(50),
 [T8gamma] NVARCHAR(50),
 [AF4theta] NVARCHAR(50),
 [AF4alpha] NVARCHAR(50),
 [AF4betaL] NVARCHAR(50),
 [AF4betaH] NVARCHAR(50),
 [AF4gamma] NVARCHAR(50)
)
WITH 
(
 LOCATION = 'EMEA/brainjammer/out/2022/04/03/*/*.parquet/*',
 DATA_SOURCE = SampleBrainwavesSource,
 FILE_FORMAT = SampleBrainwavesParquet
)
