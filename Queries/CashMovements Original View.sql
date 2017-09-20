SELECT        D.PoolCategory, D.BalancePool, B.Name AS Account, CONVERT(DATE, A.PostedOrIssue) AS PostedOrIssue, CONVERT(DATE, A.AvailOrPaid) AS AvailOrPaid, 
                         CONVERT(DATE, A.EffectiveDate) AS EffectiveDate, DATEDIFF(DAY, A.PostedOrIssue, CONVERT(DATE, GETDATE() - 1)) AS Aging, C.Name AS DCIP, A.Currency, 
                         CONVERT(DECIMAL(18, 2), A.Amount) AS Amount, 
						 CONVERT(DECIMAL(18, 2), A.EqAmount) AS AmountUSD, 
						 A.Name1 AS Description, A.UserText1, A.UserText2, 
                         A.ImageUrl AS ISIN, A.CPCS, A.SerialNumber, A.CustAcctNum, A.ImageCode
FROM            [USMRTPWSQLP01\WSQLP01].FRONTIER.dbo.Item AS A WITH (NOLOCK) LEFT OUTER JOIN
                         [USMRTPWSQLP01\WSQLP01].FRONTIER.dbo.Account AS B WITH (NOLOCK) ON A.AccountId = B.Id LEFT OUTER JOIN
                         [USMRTPWSQLP01\WSQLP01].FRONTIER.dbo.ItemTypes AS C WITH (NOLOCK) ON A.DCIP = C.Id LEFT OUTER JOIN
                         dbo.[Frontier.Accounts.Cash.Filter] AS D WITH (NOLOCK) ON B.Name = D.Account
WHERE        (A.PostedOrIssue < CONVERT(DATE, GETDATE())) AND (D.PoolCategory IS NOT NULL) AND (A.ItemState <> 4115) AND (A.MatchId = - 1) AND (A.CompanyId = 2)