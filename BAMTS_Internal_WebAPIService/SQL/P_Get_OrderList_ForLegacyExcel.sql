USE [BAMTS_DB]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_OrderList_ForLegacyExcel]    Script Date: 2022/06/15 15:44:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[P_Get_OrderList_ForLegacyExcel]
(
	@ODR_PERIOD		int,
	@ODR_CATEGORY	varchar(8),
	@ODR_MONTH		varchar(2),
	@ODR_SEQ		int,
	@STATUS			int
)
AS
BEGIN
declare @Message			nvarchar(1024)
begin try
	select
		 [STATUS]
		,ODR_PERIOD
		,ODR_CATEGORY
		,ODR_MONTH
		,ODR_SEQ
		,DLV_SUBMIT_DATE
		,DLV_DEADLINE_DATE
		,DLVREP_SUBMIT_DATE
		,CMPREP_ISSUE_DATE
		,CMPREP_DEADLINE_DATE
		,CMPMAIL_ISSUE_DATE
		,CMPMAIL_DEADLINE_DATE
		,CNST_MANAGER_ID
		,CNST_MANAGER_NAME
		,[TYPE] as TYPE
		,REV_ISSUE_DATE
		,REV_NO
		,EST_ISSUE_DATE
		,CUSTOMER_ID
		,CUSTOMER_NAME
		,ODR_NAME
		,CNST_START_DATE
		,CNST_END_DATE
		,OPEN_DATE
		,NOTE
		,ESTREQ_NO_1
		,ESTREQ_NO_2
		,PRODUCT_NO
		,REQ_DATE
		,REQ_NO
		,ODR_DATE
		,ODR_NO
		,ACCEPT_DATE
		,ACCEPT_MONTH
		,PAYMENT_MONTH
		,ANS_NET_PRICE
		,ANS_TAX_PRICE
		,CNST_NET_PRICE
		,CNST_TAX_PRICE
		,STUP_NET_PRICE
		,STUP_TAX_PRICE
		,ASSOCIATE_ID_1
		,ASSOCIATE_NAME_1
		,WORKER_NAME_1
		,NET_PRICE_1
		,TAX_PRICE_1
		,PAYMENT_MONTH_1
		,ASSOCIATE_ID_2
		,ASSOCIATE_NAME_2
		,WORKER_NAME_2
		,NET_PRICE_2
		,TAX_PRICE_2
		,PAYMENT_MONTH_2
		,ASSOCIATE_ID_3
		,ASSOCIATE_NAME_3
		,WORKER_NAME_3
		,NET_PRICE_3
		,TAX_PRICE_3
		,PAYMENT_MONTH_3
	from 
		V_ORDER_LIST_FOR_EXCEL_P1
	where
			(ODR_PERIOD = isnull(@ODR_PERIOD, ODR_PERIOD))
		and (ODR_CATEGORY = isnull(@ODR_CATEGORY, ODR_CATEGORY))
		and (ODR_MONTH = isnull(@ODR_MONTH, ODR_MONTH))
		and (ODR_SEQ = isnull(@ODR_SEQ, ODR_SEQ))
		and ([STATUS] = isnull(@STATUS, [STATUS]))
	order by 
		 ODR_PERIOD
		,ODR_CATEGORY
		,ODR_MONTH
		,ODR_SEQ

end try
begin catch
	set @Message = N'ApplicationError:[P_Get_OrderList_ForLegacyExcel]にてエラーが発生しました。[' + STR(ERROR_NUMBER()) + ']:' + ERROR_MESSAGE() + ' <' + ERROR_PROCEDURE() + '>(Line:' + STR(ERROR_LINE()) + ')'
	EXEC xp_logevent 90001, @Message, error 
end catch
select @Message as RESULT_MESSAGE

END

