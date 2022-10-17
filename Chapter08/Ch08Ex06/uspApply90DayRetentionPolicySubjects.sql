CREATE PROCEDURE dbo.uspApply90DayRetentionPolicySubjects
AS 
    DELETE FROM dbo.SUBJECTS
    WHERE CREATE_DATE > DATEADD(DAY, -90, GETDATE())
GO
