/****** Object:  StoredProcedure [dbo].[SP_CF_Deposit]    Script Date: 01/06/2014 23:34:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [dbo].[SP_CF_Deposit]
(
			
	@Mode varchar(10),
	@Deposit_Id varchar(10),
	@Deposit_UserId uniqueidentifier,
	@Deposit_PackageId varchar(10),
	@Deposit_PackageDetId varchar(10),
	@Deposit_Amount numeric(18,2),
	@Deposit_ModifyDate datetime ,
	@Deposit_Type varchar(50),
	@Deposit_Payname varchar(50),
	@Deposit_SysIp varchar(100),
	@Deposit_CountryName varchar(100),@Deposit_TrnsId varchar(50)
			)
as
if Upper(@Mode)='ADD'
begin

insert into CF_Deposit(Deposit_Id,Deposit_UserId,Deposit_PackageId,Deposit_PackageDetId,Deposit_Amount,Deposit_ModifyDate,Deposit_Type,Deposit_SysIp,Deposit_CountryName,Deposit_TrnsId,Deposit_Payname)values(@Deposit_Id,@Deposit_UserId,@Deposit_PackageId,@Deposit_PackageDetId,@Deposit_Amount,@Deposit_ModifyDate,@Deposit_Type,@Deposit_SysIp,@Deposit_CountryName,@Deposit_TrnsId,@Deposit_Payname)
End