--SELECT        
SELECT  
SM.LastDate, 
SM.SecurityNumber + '-' + SM.Suffix SecurityCode, 
NULLIF (SM.SecurityName, '') SecurityName, 
NULLIF (SM.SecurityType, 0) SecurityType, 
NULLIF (SM.IBLCProfile, 0) IBLCProfile, 
NULLIF (SM.ISIN, '') ISIN, 
CAST(IIF(A3.Code IS NULL, 0, 1) AS bit) IsAAA
FROM            
olympic.AAA AS A3 RIGHT OUTER JOIN
olympic.[SecurityMasterRaw:FDBVAL] AS SM ON A3.Suffix = SM.Suffix AND A3.Code = SM.SecurityNumber;

--update [olympic].[vIsAAA]
set [olympic].[vIsAAA].IsAAA = 0 where [olympic].[vIsAAA].SecurityCode = '0000066'