--TOP DOWN
SELECT * FROM [dimensional].[MODE] WHERE [MODE_ID] = 1
SELECT * FROM [dimensional].[MODE] WHERE [MODE_ID] = 2
---------------------
--ELECTRODEs, MODE 1
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 1 AND [MODE_ID] = 1
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 2 AND [MODE_ID] = 1
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 3 AND [MODE_ID] = 1
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 4 AND [MODE_ID] = 1
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 5 AND [MODE_ID] = 1
--ELECTRODEs, MODE 2
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 6 AND [MODE_ID] = 2
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 7 AND [MODE_ID] = 2
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 8 AND [MODE_ID] = 2
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 9 AND [MODE_ID] = 2
SELECT * FROM [dimensional].[ELECTRODE] WHERE [ELECTRODE_ID] = 10 AND [MODE_ID] = 2
--------------------
--FREQUENCYs, ELECTRODE 1
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 1 AND [ELECTRODE_ID] = 1
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 2 AND [ELECTRODE_ID] = 1
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 3 AND [ELECTRODE_ID] = 1
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 4 AND [ELECTRODE_ID] = 1
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 5 AND [ELECTRODE_ID] = 1
--FREQUENCYs, ELECTRODE 2
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 6 AND [ELECTRODE_ID] = 2
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 7 AND [ELECTRODE_ID] = 2
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 8 AND [ELECTRODE_ID] = 2
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 9 AND [ELECTRODE_ID] = 2
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 10 AND [ELECTRODE_ID] = 2
--FREQUENCYs, ELECTRODE 3
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 11 AND [ELECTRODE_ID] = 3
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 12 AND [ELECTRODE_ID] = 3
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 13 AND [ELECTRODE_ID] = 3
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 14 AND [ELECTRODE_ID] = 3
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 15 AND [ELECTRODE_ID] = 3
--FREQUENCYs, ELECTRODE 4
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 16 AND [ELECTRODE_ID] = 4
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 17 AND [ELECTRODE_ID] = 4
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 18 AND [ELECTRODE_ID] = 4
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 19 AND [ELECTRODE_ID] = 4
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 20 AND [ELECTRODE_ID] = 4
--FREQUENCYs, ELECTRODE 5
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 21 AND [ELECTRODE_ID] = 5
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 22 AND [ELECTRODE_ID] = 5
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 23 AND [ELECTRODE_ID] = 5
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 24 AND [ELECTRODE_ID] = 5
SELECT * FROM [dimensional].[FREQUENCY] WHERE [FREQUENCY_ID] = 25 AND [ELECTRODE_ID] = 5
