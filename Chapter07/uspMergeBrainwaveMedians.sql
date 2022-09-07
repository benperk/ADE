CREATE PROC [brainwaves].[uspMergeBrainwaveMedians] AS 
 MERGE INTO [brainwaves].[BrainwaveMedians] target
 USING [brainwaves].[BrainwaveMediansInput] AS i
 ON target.[ReadingDate] = i.[ReadingDate]
 WHEN MATCHED THEN
  UPDATE SET
   target.[medianALPHA] = i.[medianALPHA],
   target.[medianBETA_H] = i.[medianBETA_H],
   target.[medianBETA_L] = i.[medianBETA_L],
   target.[medianGAMMA] = i.[medianGAMMA],
   target.[medianTHETA] = i.[medianTHETA]
 WHEN NOT MATCHED BY target THEN
  INSERT 
   (ReadingDate, medianALPHA, medianBETA_H, medianBETA_L, medianGAMMA, medianTHETA)
  VALUES 
   (i.ReadingDate, i.medianALPHA, i.medianBETA_H, 
    i.medianBETA_L, i.medianGAMMA, i.medianTHETA)
