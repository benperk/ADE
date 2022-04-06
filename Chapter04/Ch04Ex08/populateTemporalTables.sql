INSERT INTO [brainwaves].[DimMODE] ([MODE]) VALUES ('EEG')
INSERT INTO [brainwaves].[DimMODE] ([MODE]) VALUES ('POW')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('ClassicalMusic')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('FlipChart')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('Meditation')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('MetalMusic')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('PlayingGuitar')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('TikTok')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('WorkMeeting')
INSERT INTO [brainwaves].[DimSCENARIO] ([SCENARIO]) VALUES ('WorkNoEmail')
INSERT INTO [brainwaves].[DimELECTRODE] ([ELECTRODE], [LOCATION]) VALUES ('AF3', 'Front Left')
INSERT INTO [brainwaves].[DimELECTRODE] ([ELECTRODE], [LOCATION]) VALUES ('AF4', 'Front Right')
INSERT INTO [brainwaves].[DimELECTRODE] ([ELECTRODE], [LOCATION]) VALUES ('T7', 'Ear Left')
INSERT INTO [brainwaves].[DimELECTRODE] ([ELECTRODE], [LOCATION]) VALUES ('T8', 'Ear Right')
INSERT INTO [brainwaves].[DimELECTRODE] ([ELECTRODE], [LOCATION]) VALUES ('Pz', 'Center Back')
INSERT INTO [brainwaves].[DimFREQUENCY] ([FREQUENCY], [ACTIVITY]) VALUES ('THETA', 'Creativity')
INSERT INTO [brainwaves].[DimFREQUENCY] ([FREQUENCY], [ACTIVITY]) VALUES ('ALPHA', 'Relaxation')
INSERT INTO [brainwaves].[DimFREQUENCY] ([FREQUENCY], [ACTIVITY]) VALUES ('BETA_L', 'Problem Solving')
INSERT INTO [brainwaves].[DimFREQUENCY] ([FREQUENCY], [ACTIVITY]) VALUES ('BETA_H', 'Concentration')
INSERT INTO [brainwaves].[DimFREQUENCY] ([FREQUENCY], [ACTIVITY]) VALUES ('GAMMA', 'Learning')
INSERT INTO [brainwaves].[DimSESSION] ([SCENARIO_ID], [MODE_ID], [SESSION_DATETIME]) VALUES (6,2, '20210730 08:00:00.000 AM')
INSERT INTO [brainwaves].[DimSESSION] ([SCENARIO_ID], [MODE_ID], [SESSION_DATETIME]) VALUES (1,1, '20210831 09:30:00.000 AM')
INSERT INTO [brainwaves].[DimSESSION] ([SCENARIO_ID], [MODE_ID], [SESSION_DATETIME]) VALUES (5,2, '20210930 09:35:00.000 AM')
