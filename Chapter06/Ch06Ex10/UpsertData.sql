INSERT INTO [dbo].[READING] ([SESSION_ID], [ELECTRODE_ID], [FREQUENCY_ID], [READING_DATETIME], [COUNT], [VALUE]) VALUES (1, 1, 1, '20220710 04:37:35.394 PM', 5, 22.454)
INSERT INTO [dbo].[READING] ([SESSION_ID], [ELECTRODE_ID], [FREQUENCY_ID], [READING_DATETIME], [COUNT], [VALUE]) VALUES (1, 1, 2, '20220710 04:37:35.394 PM', 6, 4.849)
UPDATE [dbo].[READING] SET VALUE = 4.4254 WHERE READING_ID = 1 --44.254
UPDATE [dbo].[READING] SET VALUE = 15.440 WHERE READING_ID = 9 --1.544

SELECT * FROM  [dbo].[READING] 
WHERE [READING_ID] = 1 OR [READING_ID] = 9 OR [READING_ID] = '20220710 04:37:35.394 PM' OR [READING_ID] = '20220710 04:37:35.437 PM'
