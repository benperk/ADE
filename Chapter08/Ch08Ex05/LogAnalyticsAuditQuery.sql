SQLSecurityAuditEvents
| where Category == 'SQLSecurityAuditEvents'
| where Statement has 'SUBJECTS'
| project EventTime, Statement, Succeeded, AffectedRows, ResponseRows,
          ServerPrincipalName, ClientIp, ApplicationName, AdditionalInformation,
          DataSensitivityInformation, DurationMs, ClientTlsVersion,
          IsServerLevelAudit, IsColumnPermission
| order by EventTime desc
| take 100
