SELECT
	r.[name] AS [Role], m.[name] AS [Member], m.Create_date AS [Created Date]	,
  m.modify_Date AS [Modified Date]
FROM
	sys.database_role_members rm
	JOIN sys.database_principals AS r 
       ON rm.[role_principal_id] = r.[principal_id]
	JOIN sys.database_principals AS m 
       ON rm.[member_principal_id] = m.[principal_id]
WHERE
	r.[type_desc] = 'DATABASE_ROLE'
