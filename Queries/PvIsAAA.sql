SELECT        
SM.CUSIP, SM.Name, 
SM.StructuredProductIndicator, 
SM.IsStructuredProduct, 
IIF(A3.CUSIP IS NULL, 0, 1) IsAAA
FROM            
pershing.AAA AS A3 RIGHT OUTER JOIN
pershing.[SecurityMaster:ISCA] AS SM 
ON A3.CUSIP = SM.CUSIP