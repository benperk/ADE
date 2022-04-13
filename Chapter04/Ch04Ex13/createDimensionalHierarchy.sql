CREATE SCHEMA dimensional
CREATE TABLE [dimensional].[MODE] (
  [MODE_ID] 	INT			NOT NULL,
  [MODE]		NVARCHAR (50)	NOT NULL
)
WITH
(
  CLUSTERED COLUMNSTORE INDEX,
  DISTRIBUTION = REPLICATE
)
GO
ALTER TABLE [dimensional].[MODE] ADD CONSTRAINT PK_MODE_MODE_ID PRIMARY KEY NONCLUSTERED (MODE_ID) NOT ENFORCED
GO
CREATE TABLE [dimensional].[ELECTRODE] (
  [ELECTRODE_ID] 	INT			NOT NULL,
  [ELECTRODE]	NVARCHAR (50)	NOT NULL,
  [LOCATION]	NVARCHAR (50)	NOT NULL,
  [MODE_ID] 		INT		NOT NULL
)
WITH
(
  CLUSTERED COLUMNSTORE INDEX,
  DISTRIBUTION = REPLICATE
)
GO
ALTER TABLE [dimensional].[ELECTRODE] ADD CONSTRAINT PK_ELECTRODE_ELECTRODE_ID_MODE_ID PRIMARY KEY NONCLUSTERED (ELECTRODE_ID, MODE_ID) NOT ENFORCED
GO
CREATE TABLE [dimensional].[FREQUENCY]
(
  [FREQUENCY_ID] 	INT			NOT NULL,
  [FREQUENCY]	NVARCHAR (50) 	NOT NULL,
  [ACTIVITY]	NVARCHAR (100)	NOT NULL,
  [ELECTRODE_ID] 	INT		NOT NULL
)
WITH
(
  CLUSTERED COLUMNSTORE INDEX,
  DISTRIBUTION = REPLICATE
)
GO
ALTER TABLE [dimensional].[FREQUENCY] ADD CONSTRAINT PK_FREQUENCY_FREQUENCY_ID_ELECTRODE_ID PRIMARY KEY NONCLUSTERED (FREQUENCY_ID, ELECTRODE_ID) NOT ENFORCED

------INSERT MODE DATA------
INSERT INTO [dimensional].[MODE] ([MODE_ID], [MODE]) VALUES (1, 'EEG')
INSERT INTO [dimensional].[MODE] ([MODE_ID], [MODE]) VALUES (2, 'POW')
------INSERT ELECTRODE DATA------
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (1, 'AF3', 'Front Left', 1)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (2, 'AF4', 'Front Right', 1)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (3, 'T7', 'Ear Left', 1)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (4, 'T8', 'Ear Right', 1)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (5, 'Pz', 'Center Back', 1)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (6, 'AF3', 'Front Left', 2)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (7, 'AF4', 'Front Right', 2)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (8, 'T7', 'Ear Left', 2)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (9, 'T8', 'Ear Right', 2)
INSERT INTO [dimensional].[ELECTRODE] ([ELECTRODE_ID], [ELECTRODE], [LOCATION], [MODE_ID]) VALUES (10, 'Pz', 'Center Back', 2)
------INSERT FREQUENCY DATA------
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (1, 'THETA', 'Creativity', 1)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (2, 'ALPHA', 'Relaxation', 1)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (3, 'BETA_L', 'Problem Solving', 1)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (4, 'BETA_H', 'Concentration', 1)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (5, 'GAMMA', 'Learning', 1)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (6, 'THETA', 'Creativity', 2)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (7, 'ALPHA', 'Relaxation', 2)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (8, 'BETA_L', 'Problem Solving', 2)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (9, 'BETA_H', 'Concentration', 2)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (10, 'GAMMA', 'Learning', 2)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (11, 'THETA', 'Creativity', 3)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (12, 'ALPHA', 'Relaxation', 3)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (13, 'BETA_L', 'Problem Solving', 3)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (14, 'BETA_H', 'Concentration', 3)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (15, 'GAMMA', 'Learning', 3)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (16, 'THETA', 'Creativity', 4)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (17, 'ALPHA', 'Relaxation', 4)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (18, 'BETA_L', 'Problem Solving', 4)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (19, 'BETA_H', 'Concentration', 4)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (20, 'GAMMA', 'Learning', 4)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (21, 'THETA', 'Creativity', 5)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (22, 'ALPHA', 'Relaxation', 5)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (23, 'BETA_L', 'Problem Solving', 5)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (24, 'BETA_H', 'Concentration', 5)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (25, 'GAMMA', 'Learning', 5)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (26, 'THETA', 'Creativity', 6)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (27, 'ALPHA', 'Relaxation', 6)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (28, 'BETA_L', 'Problem Solving', 6)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (29, 'BETA_H', 'Concentration', 6)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (30, 'GAMMA', 'Learning', 6)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (31, 'THETA', 'Creativity', 7)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (32, 'ALPHA', 'Relaxation', 7)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (33, 'BETA_L', 'Problem Solving', 7)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (34, 'BETA_H', 'Concentration', 7)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (35, 'GAMMA', 'Learning', 7)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (36, 'THETA', 'Creativity', 8)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (37, 'ALPHA', 'Relaxation', 8)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (38, 'BETA_L', 'Problem Solving', 8)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (39, 'BETA_H', 'Concentration', 8)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (40, 'GAMMA', 'Learning', 8)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (41, 'THETA', 'Creativity', 9)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (42, 'ALPHA', 'Relaxation', 9)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (43, 'BETA_L', 'Problem Solving', 9)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (44, 'BETA_H', 'Concentration', 9)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (45, 'GAMMA', 'Learning', 9)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (46, 'THETA', 'Creativity', 10)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (47, 'ALPHA', 'Relaxation', 10)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (48, 'BETA_L', 'Problem Solving', 10)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (49, 'BETA_H', 'Concentration', 10)
INSERT INTO [dimensional].[FREQUENCY] ([FREQUENCY_ID], [FREQUENCY], [ACTIVITY], [ELECTRODE_ID]) VALUES (50, 'GAMMA', 'Learning', 10)
