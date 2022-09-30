USE [BAMTS_DB]
GO
/****** Object:  StoredProcedure [dbo].[P_Get_T_EMPLOYEE_ALL]    Script Date: 2022/05/18 15:28:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[P_Get_T_EMPLOYEE_ALL]
AS
BEGIN
declare @Message			nvarchar(1024)
begin try
	select
		 EMP_ID
		,EMP_NAME
		,BIRTH_DATE
		,JOINED_DATE
		,USED_PAID_HOLIDAY
		,GENDER
		,CELLPHONE_NO
		,CELLPHONE_MAIL_ADDRESS
		,PC_MAIL_ADDRESS
		,PC_MAIL_PASSWORD
		,NOTE
	from 
		T_EMPLOYEE

end try
begin catch
	set @Message = N'ApplicationError:[P_Get_T_EMPLOYEE_ALL]にてエラーが発生しました。[' + STR(ERROR_NUMBER()) + ']:' + ERROR_MESSAGE() + ' <' + ERROR_PROCEDURE() + '>(Line:' + STR(ERROR_LINE()) + ')'
	EXEC xp_logevent 90001, @Message, error 
end catch
select @Message as RESULT_MESSAGE

END

