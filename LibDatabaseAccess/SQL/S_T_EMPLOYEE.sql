USE [BAMTS_DB]
GO

/****** Object:  UserDefinedTableType [dbo].[S_T_EMPLOYEE]    Script Date: 2022/05/18 16:11:07 ******/
CREATE TYPE [dbo].[S_T_EMPLOYEE] AS TABLE(
	[EMP_ID] [varchar](16) NULL,
	[EMP_NAME] [nvarchar](64) NULL,
	[BIRTH_DATE] [datetime] NULL,
	[JOINED_DATE] [datetime] NULL,
	[USED_PAID_HOLIDAY] [int] NULL,
	[GENDER] [int] NULL,
	[CELLPHONE_NO] [varchar](32) NULL,
	[CELLPHONE_MAIL_ADDRESS] [varchar](64) NULL,
	[PC_MAIL_ADDRESS] [varchar](64) NULL,
	[PC_MAIL_PASSWORD] [varchar](64) NULL,
	[NOTE] [nvarchar](256) NULL
)
GO


