CREATE TABLE [brainwaves].[BrainwaveWindowMedians] (
  [WindowId]  		NVARCHAR (100) NOT NULL,
  [IngestionTime]	DATETIME       NOT NULL,
  [medianAPLHA]		DECIMAL(20,3)  NOT NULL,
  [medianBETA_H]	DECIMAL(20,3)  NOT NULL,
  [medianBETA_L]	DECIMAL(20,3)  NOT NULL,
  [medianGAMMA]		DECIMAL(20,3)  NOT NULL,
  [medianTHETA]		DECIMAL(20,3)  NOT NULL  
)
