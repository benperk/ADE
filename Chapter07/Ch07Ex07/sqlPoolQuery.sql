SELECT IngestionTime, medianAPLHA, medianBETA_H, medianBETA_L, medianGAMMA, medianTHETA
FROM [brainwaves].[BrainwaveWindowMedians]
WHERE WindowId = '10s Hop'
ORDER BY IngestionTime
