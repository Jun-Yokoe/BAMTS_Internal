USE [BAMTS_DB]
GO
/****** Object:  StoredProcedure [dbo].[P_Replace_T_EMPLOYEE_ALL]    Script Date: 2022/05/18 16:14:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[P_Replace_T_EMPLOYEE_ALL]
(
	@recList S_T_EMPLOYEE readonly
)
AS
BEGIN
declare @NowTime					datetime = getdate()
declare @Message					nvarchar(2048) = ''
declare @EMP_ID	varchar(16)
declare @EMP_NAME	nvarchar(64)
declare @BIRTH_DATE	datetime
declare @JOINED_DATE	datetime
declare @USED_PAID_HOLIDAY	int
declare @GENDER	int
declare @CELLPHONE_NO	varchar(32)
declare @CELLPHONE_MAIL_ADDRESS	varchar(64)
declare @PC_MAIL_ADDRESS	varchar(64)
declare @PC_MAIL_PASSWORD	varchar(64)
declare @NOTE	nvarchar(256)
declare curTargets cursor for select EMP_ID,EMP_NAME,BIRTH_DATE,JOINED_DATE,USED_PAID_HOLIDAY,GENDER,CELLPHONE_NO,CELLPHONE_MAIL_ADDRESS,PC_MAIL_ADDRESS,PC_MAIL_PASSWORD,NOTE from @recList
begin try
	delete from T_EMPLOYEE
	open curTargets
	fetch next from curTargets into @EMP_ID,@EMP_NAME,@BIRTH_DATE,@JOINED_DATE,@USED_PAID_HOLIDAY,@GENDER,@CELLPHONE_NO,@CELLPHONE_MAIL_ADDRESS,@PC_MAIL_ADDRESS,@PC_MAIL_PASSWORD,@NOTE
	while (@@fetch_status = 0)
	begin
		insert into T_EMPLOYEE ( EMP_ID, EMP_NAME, BIRTH_DATE, JOINED_DATE, USED_PAID_HOLIDAY, GENDER, CELLPHONE_NO, CELLPHONE_MAIL_ADDRESS, PC_MAIL_ADDRESS, PC_MAIL_PASSWORD, NOTE)
						values (@EMP_ID,@EMP_NAME,@BIRTH_DATE,@JOINED_DATE,@USED_PAID_HOLIDAY,@GENDER,@CELLPHONE_NO,@CELLPHONE_MAIL_ADDRESS,@PC_MAIL_ADDRESS,@PC_MAIL_PASSWORD,@NOTE)
		fetch next from curTargets into @EMP_ID,@EMP_NAME,@BIRTH_DATE,@JOINED_DATE,@USED_PAID_HOLIDAY,@GENDER,@CELLPHONE_NO,@CELLPHONE_MAIL_ADDRESS,@PC_MAIL_ADDRESS,@PC_MAIL_PASSWORD,@NOTE
	end
	close curTargets
	deallocate curTargets
end try
begin catch
	set @Message = N'ApplicationError:[P_Replace_T_EMPLOYEE_ALL]にてエラーが発生しました。[' + STR(ERROR_NUMBER()) + ']:' + ERROR_MESSAGE() + ' <' + ERROR_PROCEDURE() + '>(Line:' + STR(ERROR_LINE()) + ')'
	EXEC xp_logevent 90001, @Message, error 
end catch

select @Message as RESULT_MESSAGE

END

