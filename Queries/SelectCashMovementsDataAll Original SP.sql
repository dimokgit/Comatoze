USE [FrontierReports]
GO
/****** Object:  StoredProcedure [dbo].[SelectCashMovementsDataAll]    Script Date: 9/18/2017 9:00:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==================================================================================================================================
-- Project:		FRONTIER | Cash | Movements
-- **********************************************************************************************************************************
-- Author:		Alan Hale
-- Create Date: 2016-01-14
-- Description:	Selects Cash Movements Data (All)
-- **********************************************************************************************************************************
-- ==================================================================================================================================
ALTER PROCEDURE [dbo].[SelectCashMovementsDataAll]
AS
BEGIN
-- **********************************************************************************************************************************
	SET NOCOUNT ON;

-- ==================================================================================================================================
--	SELECT MOVEMENTS
-- ==================================================================================================================================
	SELECT 
		 [PoolCategory]
		,[BalancePool]
		,[Account]
		,[PostedOrIssue]
		,[AvailOrPaid]
		,[EffectiveDate]
		,[Aging]
		,[DCIP]
		,[Currency]
		,[Amount]
		--,[AmountUSD] disabled in the context of RQ 3484
		,[Description]
		,[UserText1]
		,[UserText2]
		,[ISIN]
		,[CPCS]
		,[SerialNumber]
		,[CustAcctNum]
		,[ImageCode]
	FROM 
		 [FrontierReports].[dbo].[Frontier.Movements.Cash]
	ORDER BY 
		 [PostedOrIssue]
		,[PoolCategory]
		,[BalancePool]
		,[Account]
		,[Aging]
		,[DCIP]
		,[AmountUSD]
		,[Description]
		,[ISIN]
-- ==================================================================================================================================

	SET NOCOUNT OFF;
-- **********************************************************************************************************************************
END
-- ==================================================================================================================================