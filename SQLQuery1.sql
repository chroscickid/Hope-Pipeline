SELECT clientLast, clientFirst, dbo.ccr.ccrStatus, dbo.client.clientCode FROM dbo.client INNER JOIN dbo.ccr ON dbo.client.clientCode = dbo.ccr.clientCode
