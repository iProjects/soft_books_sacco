/****** Object:  ForeignKey [FK_Settings_SettingsGroup]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[core_Settings]'))
ALTER TABLE [dbo].[core_Settings] DROP CONSTRAINT [FK_Settings_SettingsGroup]
GO
/****** Object:  ForeignKey [FK_Accounts_Coa]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts] DROP CONSTRAINT [FK_Accounts_Coa]
GO
/****** Object:  ForeignKey [FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycleProperties]'))
ALTER TABLE [dbo].[gl_AdvancedParametersLoanCycleProperties] DROP CONSTRAINT [FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]
GO
/****** Object:  ForeignKey [FK_BankBranch_Banks]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_BankBranch]'))
ALTER TABLE [dbo].[gl_BankBranch] DROP CONSTRAINT [FK_BankBranch_Banks]
GO
/****** Object:  ForeignKey [FK_gl_CollateralPropertyDetails_gl_Collateral]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyDetails_gl_Collateral]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CollateralProperty]'))
ALTER TABLE [dbo].[gl_CollateralProperty] DROP CONSTRAINT [FK_gl_CollateralPropertyDetails_gl_Collateral]
GO
/****** Object:  ForeignKey [FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CollateralPropertyCollectionItems]'))
ALTER TABLE [dbo].[gl_CollateralPropertyCollectionItems] DROP CONSTRAINT [FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]
GO
/****** Object:  ForeignKey [FK_CustomerAccounts_Customers]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAccounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]'))
ALTER TABLE [dbo].[gl_CustomerAccounts] DROP CONSTRAINT [FK_CustomerAccounts_Customers]
GO
/****** Object:  ForeignKey [FK_TransactionTypes_Trasactions]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransactionTypes_Trasactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]'))
ALTER TABLE [dbo].[gl_TransactionTypes] DROP CONSTRAINT [FK_TransactionTypes_Trasactions]
GO
/****** Object:  ForeignKey [FK_sec_Rights_sec_Roles]    Script Date: 04/23/2013 08:40:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Rights_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Rights]'))
ALTER TABLE [dbo].[sec_Rights] DROP CONSTRAINT [FK_sec_Rights_sec_Roles]
GO
/****** Object:  ForeignKey [FK_sec_Users_sec_Roles]    Script Date: 04/23/2013 08:40:44 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Users_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Users]'))
ALTER TABLE [dbo].[sec_Users] DROP CONSTRAINT [FK_sec_Users_sec_Roles]
GO
/****** Object:  Table [dbo].[gl_CollateralPropertyCollectionItems]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CollateralPropertyCollectionItems]') AND type in (N'U'))
DROP TABLE [dbo].[gl_CollateralPropertyCollectionItems]
GO
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 04/23/2013 08:40:44 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwBankBranches]'))
DROP VIEW [dbo].[vwBankBranches]
GO
/****** Object:  Table [dbo].[sec_Users]    Script Date: 04/23/2013 08:40:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Users]') AND type in (N'U'))
DROP TABLE [dbo].[sec_Users]
GO
/****** Object:  Table [dbo].[gl_TransactionTypes]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]') AND type in (N'U'))
DROP TABLE [dbo].[gl_TransactionTypes]
GO
/****** Object:  Table [dbo].[sec_Rights]    Script Date: 04/23/2013 08:40:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Rights]') AND type in (N'U'))
DROP TABLE [dbo].[sec_Rights]
GO
/****** Object:  Table [dbo].[gl_CollateralProperty]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CollateralProperty]') AND type in (N'U'))
DROP TABLE [dbo].[gl_CollateralProperty]
GO
/****** Object:  Table [dbo].[core_Settings]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_Settings]') AND type in (N'U'))
DROP TABLE [dbo].[core_Settings]
GO
/****** Object:  Table [dbo].[gl_Accounts]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Accounts]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Accounts]
GO
/****** Object:  Table [dbo].[gl_AdvancedParametersLoanCycleProperties]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycleProperties]') AND type in (N'U'))
DROP TABLE [dbo].[gl_AdvancedParametersLoanCycleProperties]
GO
/****** Object:  Table [dbo].[gl_BankBranch]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_BankBranch]') AND type in (N'U'))
DROP TABLE [dbo].[gl_BankBranch]
GO
/****** Object:  Table [dbo].[gl_CustomerAccounts]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]') AND type in (N'U'))
DROP TABLE [dbo].[gl_CustomerAccounts]
GO
/****** Object:  Table [dbo].[gl_Customers]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Customers]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Customers]
GO
/****** Object:  Table [dbo].[gl_CycleObjects]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CycleObjects]') AND type in (N'U'))
DROP TABLE [dbo].[gl_CycleObjects]
GO
/****** Object:  Table [dbo].[gl_CycleParameters]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CycleParameters]') AND type in (N'U'))
DROP TABLE [dbo].[gl_CycleParameters]
GO
/****** Object:  Table [dbo].[gl_Cycles]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Cycles]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Cycles]
GO
/****** Object:  Table [dbo].[gl_Documents]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Documents]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Documents]
GO
/****** Object:  Table [dbo].[gl_EconomicActivity]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_EconomicActivity]') AND type in (N'U'))
DROP TABLE [dbo].[gl_EconomicActivity]
GO
/****** Object:  Table [dbo].[gl_EntryFees]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_EntryFees]') AND type in (N'U'))
DROP TABLE [dbo].[gl_EntryFees]
GO
/****** Object:  Table [dbo].[gl_ExchangeRates]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_ExchangeRates]') AND type in (N'U'))
DROP TABLE [dbo].[gl_ExchangeRates]
GO
/****** Object:  Table [dbo].[gl_FundingLineEvents]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_FundingLineEvents]') AND type in (N'U'))
DROP TABLE [dbo].[gl_FundingLineEvents]
GO
/****** Object:  Table [dbo].[gl_FundingLines]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_FundingLines]') AND type in (N'U'))
DROP TABLE [dbo].[gl_FundingLines]
GO
/****** Object:  Table [dbo].[gl_Guarantee]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Guarantee]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Guarantee]
GO
/****** Object:  Table [dbo].[gl_InstallmentTypes]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_InstallmentTypes]') AND type in (N'U'))
DROP TABLE [dbo].[gl_InstallmentTypes]
GO
/****** Object:  Table [dbo].[gl_Loans]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Loans]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Loans]
GO
/****** Object:  Table [dbo].[gl_NonSolidarityGroup]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_NonSolidarityGroup]') AND type in (N'U'))
DROP TABLE [dbo].[gl_NonSolidarityGroup]
GO
/****** Object:  Table [dbo].[gl_Person]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Person]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Person]
GO
/****** Object:  Table [dbo].[gl_Savings]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Savings]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Savings]
GO
/****** Object:  Table [dbo].[gl_SBServer]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_SBServer]') AND type in (N'U'))
DROP TABLE [dbo].[gl_SBServer]
GO
/****** Object:  Table [dbo].[gl_SolidarityGroup]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_SolidarityGroup]') AND type in (N'U'))
DROP TABLE [dbo].[gl_SolidarityGroup]
GO
/****** Object:  Table [dbo].[gl_StandardBookings]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_StandardBookings]') AND type in (N'U'))
DROP TABLE [dbo].[gl_StandardBookings]
GO
/****** Object:  Table [dbo].[gl_Banks]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Banks]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Banks]
GO
/****** Object:  Table [dbo].[gl_Coa]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Coa]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Coa]
GO
/****** Object:  Table [dbo].[gl_Collateral]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Collateral]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Collateral]
GO
/****** Object:  Table [dbo].[gl_AdvancedParametersLoanCycle]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycle]') AND type in (N'U'))
DROP TABLE [dbo].[gl_AdvancedParametersLoanCycle]
GO
/****** Object:  Table [dbo].[core_SettingsGroup]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_SettingsGroup]') AND type in (N'U'))
DROP TABLE [dbo].[core_SettingsGroup]
GO
/****** Object:  Table [dbo].[gl_Corporate]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Corporate]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Corporate]
GO
/****** Object:  Table [dbo].[gl_Currencies]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Currencies]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Currencies]
GO
/****** Object:  Table [dbo].[sec_Roles]    Script Date: 04/23/2013 08:40:44 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Roles]') AND type in (N'U'))
DROP TABLE [dbo].[sec_Roles]
GO
/****** Object:  Table [dbo].[gl_Trasactions]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Trasactions]') AND type in (N'U'))
DROP TABLE [dbo].[gl_Trasactions]
GO
/****** Object:  Table [dbo].[Commands]    Script Date: 04/23/2013 08:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
DROP TABLE [dbo].[Commands]
GO
/****** Object:  Table [dbo].[Commands]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Commands]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Commands](
	[CommanId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AssemblyPath] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Class] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Method] [nvarchar](300) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Commands] PRIMARY KEY CLUSTERED 
(
	[CommanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Trasactions]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Trasactions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Trasactions](
	[TransactionId] [int] IDENTITY(1,1) NOT NULL,
	[TrasactionType] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[TransRef] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ContraRef] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Amount] [decimal](19, 4) NOT NULL,
	[Narrative1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Narrative2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UserId] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Authorizer] [varchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StatementFlag] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostDate] [datetime] NOT NULL,
	[ValueDate] [datetime] NOT NULL,
	[RecDate] [datetime] NOT NULL,
 CONSTRAINT [PK_gl_Trasactions] PRIMARY KEY CLUSTERED 
(
	[TransactionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[sec_Roles]    Script Date: 04/23/2013 08:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Roles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sec_Roles](
	[RoleId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[RoleDescription] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_sec_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'4', N'9')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'8', N'5')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'A', N'ADMINISTRATOR')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'ADMIN', N'ADMINISTRATOR')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'c', N'3')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'd', N'2')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'e', N'1')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'f', N'6')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'g', N'7')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'h', N'8')
INSERT [dbo].[sec_Roles] ([RoleId], [RoleDescription]) VALUES (N'i', N'4')
/****** Object:  Table [dbo].[gl_Currencies]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Currencies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Currencies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CurrencyName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CurrencyCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UseCents] [bit] NULL,
 CONSTRAINT [PK_gl_Currencies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_Currencies] ON
INSERT [dbo].[gl_Currencies] ([Id], [CurrencyName], [CurrencyCode], [UseCents]) VALUES (1, N'Kenya Shilling ', N'Kshs', 1)
SET IDENTITY_INSERT [dbo].[gl_Currencies] OFF
/****** Object:  Table [dbo].[gl_Corporate]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Corporate]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Corporate](
	[CorporateID] [int] IDENTITY(1,1) NOT NULL,
	[CorporateName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreationDate] [datetime] NULL,
	[ShortName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorporateCycle] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorporateBranch] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorporatePhoto] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cProvince] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cDistrict] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cCity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cZipCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cHomeType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cBusinessPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactPosition] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContactPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CompanyIDNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AgreementDate] [datetime] NULL,
	[CorporateEconomicActivity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LegalForm] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InsertionType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NumberofEmployees] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NumberofVolunteers] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FiscalStatus] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Affiliation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectId] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProjectCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NoofContracts] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorporateFirstContactDate] [datetime] NULL,
	[CorporateSourceofKnowHow] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorporateSponsor] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Comment] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TypeofCompany] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocumentName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocumentFile] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocumentUser] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocumentDate] [datetime] NULL,
	[DocumentComment] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_Corporate] PRIMARY KEY CLUSTERED 
(
	[CorporateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[core_SettingsGroup]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_SettingsGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[core_SettingsGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parent] [int] NOT NULL,
 CONSTRAINT [PK_core_SettingsGroup] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[core_SettingsGroup] ON
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (1, N'Setttings', 0)
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (2, N'Statutory Computations', 1)
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (3, N'General', 1)
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (4, N'NSSF', 6)
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (5, N'PAYE', 2)
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (6, N'Pension', 2)
INSERT [dbo].[core_SettingsGroup] ([Id], [GroupName], [Parent]) VALUES (7, N'Security', 1)
SET IDENTITY_INSERT [dbo].[core_SettingsGroup] OFF
/****** Object:  Table [dbo].[gl_AdvancedParametersLoanCycle]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycle]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_AdvancedParametersLoanCycle](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoanCycleName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanId] [int] NULL,
 CONSTRAINT [PK_gl_AdvancedParametersLoanCycle] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Collateral]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Collateral]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Collateral](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[cProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cProductDescription] [nvarchar](550) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cPropertyName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cPropertyDescription] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cPropertyType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[cCollectionItemName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_Collateral] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_Collateral] ON
INSERT [dbo].[gl_Collateral] ([Id], [cProductName], [cProductDescription], [cPropertyName], [cPropertyDescription], [cPropertyType], [cCollectionItemName]) VALUES (1, N'324242', N'4242424', N'424', N'4242424', N'Collection', N'22')
INSERT [dbo].[gl_Collateral] ([Id], [cProductName], [cProductDescription], [cPropertyName], [cPropertyDescription], [cPropertyType], [cCollectionItemName]) VALUES (2, N'34234234', N'2342423', N'324324', N'423424', N'String', N'15541')
SET IDENTITY_INSERT [dbo].[gl_Collateral] OFF
/****** Object:  Table [dbo].[gl_Coa]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Coa]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Coa](
	[Id] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [nchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Level] [int] NOT NULL,
	[Parent] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Rorder] [int] NOT NULL,
 CONSTRAINT [PK_gl_Coa] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Banks]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Banks]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Banks](
	[BankCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BankName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Banks] PRIMARY KEY CLUSTERED 
(
	[BankCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'02', N'Standard Chartered Bank 111')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'03', N'Barclays Bank of Kenya Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'05', N'Bank of India')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'06', N'Bank of Baroda (Kenya) Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'07', N'Commercial Bank of Africa Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'08', N'Habib Bank Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'09', N'Central Bank of Kenya')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'10', N'Prime Bank Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'11', N'Co-operative Bank Of Kenya')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'111', N'111111111111')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'14', N'Oriental Commercial Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'17', N'Habib Bank')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'18', N'Middle East Bank')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'19', N'Bank of Africa Kenya Ltd.')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'20', N' Dubai Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'222', N'zzzzzzzzzzzz')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'23', N'Consolidated Bank of Kenya')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'25', N' Credit Bank Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'26', N'Trans-National Bank Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'30', N'Chase Bank')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'31', N'Cfc Stanbic Bank ')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'35', N' African BankingCorporation Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'39', N'Imperial Bank Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'41', N'NIC Bank Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'42', N' Giro Commercial')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'43', N'Ecobank Kenya Limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'49', N'Equatorial Commercial Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'50', N'Paramount Universal Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'51', N'Jamii Bora Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'53', N'Fina Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'54', N'Victoria Commercial Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'55', N'Guardian Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'57', N'I & M Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'59', N'Development Bank of Kenya Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'60', N'Fidelity Commercial Bank Ltd.')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'63', N'Diamond Trust Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'66', N'K-Rep Bank limited')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'68', N'Equity Bank ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'70', N'Family Bank ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'72', N'Gulf African Bank')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'74', N'First Community Bank Ltd')
INSERT [dbo].[gl_Banks] ([BankCode], [BankName]) VALUES (N'76', N'UBA Kenya Bank')
/****** Object:  Table [dbo].[gl_StandardBookings]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_StandardBookings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_StandardBookings](
	[ID] [int] NOT NULL,
	[Name] [varchar](128) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DebitAccountID] [int] NOT NULL,
	[CreditAccountID] [int] NOT NULL,
 CONSTRAINT [PK_gl_StandardBookings] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_SolidarityGroup]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_SolidarityGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_SolidarityGroup](
	[SolidarityGroupID] [int] IDENTITY(1,1) NOT NULL,
	[sGroupName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMeetingDate] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sSetMeetingDate] [bit] NULL,
	[sDateofEstablishment] [datetime] NULL,
	[sGroupOfficer] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBranch] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sPhoto] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeProvince] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeDistrict] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeCity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeZipCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomePhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeCellPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sHomeEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessProvince] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessDistrict] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessCity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessZipCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessHomeType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessCellPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sBusinessEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_SolidarityGroup] PRIMARY KEY CLUSTERED 
(
	[SolidarityGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_SBServer]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_SBServer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_SBServer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Server_Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[User_Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Pass_Word] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Logged_Time] [datetime] NOT NULL,
	[Is_Default] [bit] NOT NULL,
 CONSTRAINT [PK_gl_SBServer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_SBServer] ON
INSERT [dbo].[gl_SBServer] ([Id], [Server_Name], [User_Name], [Pass_Word], [Logged_Time], [Is_Default]) VALUES (1, N'SAPSERVER\SQLEXPRESS', N'sa', N'sa', CAST(0x0000A1650174DE32 AS DateTime), 1)
INSERT [dbo].[gl_SBServer] ([Id], [Server_Name], [User_Name], [Pass_Word], [Logged_Time], [Is_Default]) VALUES (2, N'LUCYCOMP\SQLEXPRESS', N'sa', N'sa', CAST(0x0000A16A00AE38CE AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[gl_SBServer] OFF
/****** Object:  Table [dbo].[gl_Savings]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Savings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Savings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[sProductName] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sProductAllClientType] [bit] NULL,
	[sProductNonSolidarityGroupClientType] [bit] NULL,
	[sProductSolidarityGroupClientType] [bit] NULL,
	[sProductIndividualClientType] [bit] NULL,
	[sProductCorporateClientType] [bit] NULL,
	[sProductCurrency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinInitialAmount] [decimal](19, 4) NULL,
	[sMaxInitialAmount] [decimal](19, 4) NULL,
	[sMinBalance] [decimal](19, 4) NULL,
	[sMaxBalance] [decimal](19, 4) NULL,
	[sMinInterestRate] [int] NULL,
	[sMaxInterestRate] [int] NULL,
	[sValueInterestRate] [int] NULL,
	[sAccrualFrequency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sPostingFrequency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sCalculateAmountBasedon] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sTransactionIn] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinCashDepositAmount] [decimal](19, 4) NULL,
	[sMaxCashDepositAmount] [decimal](19, 4) NULL,
	[sCashDepositFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinCashDepositFeesAmount] [decimal](19, 4) NULL,
	[sMaxCashDepositFeesAmount] [decimal](19, 4) NULL,
	[sValueCashDepositFeesAmount] [decimal](19, 4) NULL,
	[sMinWithDrawAmount] [decimal](19, 4) NULL,
	[sMaxWithDrawAmount] [decimal](19, 4) NULL,
	[sWithDrawFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinWithDrawFees] [decimal](19, 4) NULL,
	[sMaxWithDrawFees] [decimal](19, 4) NULL,
	[sValueWithDrawFees] [decimal](19, 4) NULL,
	[sMinTransferAmount] [decimal](19, 4) NULL,
	[sMaxTransferAmount] [decimal](19, 4) NULL,
	[sTransferFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinTransferFees] [decimal](19, 4) NULL,
	[sMaxTransferFees] [decimal](19, 4) NULL,
	[sValueTransferFees] [decimal](19, 4) NULL,
	[sTransferType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sEntryFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinEntryFees] [decimal](19, 4) NULL,
	[sMaxEntryFees] [decimal](19, 4) NULL,
	[sValueEntryFees] [decimal](19, 4) NULL,
	[sReopenFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinReopenFees] [decimal](19, 4) NULL,
	[sMaxReopenFees] [decimal](19, 4) NULL,
	[sValueReopenFees] [decimal](19, 4) NULL,
	[sCloseFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinCloseFees] [decimal](19, 4) NULL,
	[sMaxCloseFees] [decimal](19, 4) NULL,
	[sValueCloseFees] [decimal](19, 4) NULL,
	[sManagementFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinManagementFees] [decimal](19, 4) NULL,
	[sMaxManagementFees] [decimal](19, 4) NULL,
	[sValueManagementFees] [decimal](19, 4) NULL,
	[sManagementFeesPostingFrequency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sFixedOverDraftFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinFixedOverDraftFees] [decimal](19, 4) NULL,
	[sMaxFixedOverDraftFees] [decimal](19, 4) NULL,
	[sValueFixedOverDraftFees] [decimal](19, 4) NULL,
	[sAgioFeesType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sMinAgioFees] [decimal](19, 4) NULL,
	[sMaxAgioFees] [decimal](19, 4) NULL,
	[sValueAgioFees] [decimal](19, 4) NULL,
	[sAgioPostingFrequency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[sUseTermDeposit] [bit] NULL,
	[sMinTermDepositNoofPeriods] [int] NULL,
	[sMaxTermDepositNoofPeriods] [int] NULL,
	[sTermDepositPostingFrequency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_Savings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_Savings] ON
INSERT [dbo].[gl_Savings] ([Id], [sProductName], [sProductCode], [sProductAllClientType], [sProductNonSolidarityGroupClientType], [sProductSolidarityGroupClientType], [sProductIndividualClientType], [sProductCorporateClientType], [sProductCurrency], [sMinInitialAmount], [sMaxInitialAmount], [sMinBalance], [sMaxBalance], [sMinInterestRate], [sMaxInterestRate], [sValueInterestRate], [sAccrualFrequency], [sPostingFrequency], [sCalculateAmountBasedon], [sTransactionIn], [sMinCashDepositAmount], [sMaxCashDepositAmount], [sCashDepositFeesType], [sMinCashDepositFeesAmount], [sMaxCashDepositFeesAmount], [sValueCashDepositFeesAmount], [sMinWithDrawAmount], [sMaxWithDrawAmount], [sWithDrawFeesType], [sMinWithDrawFees], [sMaxWithDrawFees], [sValueWithDrawFees], [sMinTransferAmount], [sMaxTransferAmount], [sTransferFeesType], [sMinTransferFees], [sMaxTransferFees], [sValueTransferFees], [sTransferType], [sEntryFeesType], [sMinEntryFees], [sMaxEntryFees], [sValueEntryFees], [sReopenFeesType], [sMinReopenFees], [sMaxReopenFees], [sValueReopenFees], [sCloseFeesType], [sMinCloseFees], [sMaxCloseFees], [sValueCloseFees], [sManagementFeesType], [sMinManagementFees], [sMaxManagementFees], [sValueManagementFees], [sManagementFeesPostingFrequency], [sFixedOverDraftFeesType], [sMinFixedOverDraftFees], [sMaxFixedOverDraftFees], [sValueFixedOverDraftFees], [sAgioFeesType], [sMinAgioFees], [sMaxAgioFees], [sValueAgioFees], [sAgioPostingFrequency], [sUseTermDeposit], [sMinTermDepositNoofPeriods], [sMaxTermDepositNoofPeriods], [sTermDepositPostingFrequency]) VALUES (1, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[gl_Savings] ([Id], [sProductName], [sProductCode], [sProductAllClientType], [sProductNonSolidarityGroupClientType], [sProductSolidarityGroupClientType], [sProductIndividualClientType], [sProductCorporateClientType], [sProductCurrency], [sMinInitialAmount], [sMaxInitialAmount], [sMinBalance], [sMaxBalance], [sMinInterestRate], [sMaxInterestRate], [sValueInterestRate], [sAccrualFrequency], [sPostingFrequency], [sCalculateAmountBasedon], [sTransactionIn], [sMinCashDepositAmount], [sMaxCashDepositAmount], [sCashDepositFeesType], [sMinCashDepositFeesAmount], [sMaxCashDepositFeesAmount], [sValueCashDepositFeesAmount], [sMinWithDrawAmount], [sMaxWithDrawAmount], [sWithDrawFeesType], [sMinWithDrawFees], [sMaxWithDrawFees], [sValueWithDrawFees], [sMinTransferAmount], [sMaxTransferAmount], [sTransferFeesType], [sMinTransferFees], [sMaxTransferFees], [sValueTransferFees], [sTransferType], [sEntryFeesType], [sMinEntryFees], [sMaxEntryFees], [sValueEntryFees], [sReopenFeesType], [sMinReopenFees], [sMaxReopenFees], [sValueReopenFees], [sCloseFeesType], [sMinCloseFees], [sMaxCloseFees], [sValueCloseFees], [sManagementFeesType], [sMinManagementFees], [sMaxManagementFees], [sValueManagementFees], [sManagementFeesPostingFrequency], [sFixedOverDraftFeesType], [sMinFixedOverDraftFees], [sMaxFixedOverDraftFees], [sValueFixedOverDraftFees], [sAgioFeesType], [sMinAgioFees], [sMaxAgioFees], [sValueAgioFees], [sAgioPostingFrequency], [sUseTermDeposit], [sMinTermDepositNoofPeriods], [sMaxTermDepositNoofPeriods], [sTermDepositPostingFrequency]) VALUES (2, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[gl_Savings] OFF
/****** Object:  Table [dbo].[gl_Person]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Person]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Person](
	[PersonID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DateofBirth] [datetime] NULL,
	[Gender] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IDNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PersonEconomicActivity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanCycle] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HeadofHouseHold] [bit] NULL,
	[PlaceofBirth] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FatherName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CitizenShip] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBranch] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pPhoto] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeProvince] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeDistrict] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeCity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeZipCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeHomeType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomePhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeCellPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pHomeEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessProvince] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessDistrict] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessCity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessZipCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessHomeType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessCellPhone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[pBusinessEmail] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PersonalBankAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PersonalBankName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BusinessBankAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BusinessBankName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FinancialStatusBankName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MonthlyHouseHoldIncome] [decimal](19, 4) NULL,
	[MonthlyHouseHoldExpenditure] [decimal](19, 4) NULL,
	[MonthlyDisposalIncome] [decimal](19, 4) NULL,
	[IsBadClient] [bit] NULL,
	[BadClientComment] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OtherMicrofinanceLoansName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OtherMicrofinanceLoansAmount] [decimal](19, 4) NULL,
	[OtherMicrofinanceLoansDebts] [decimal](19, 4) NULL,
	[OtherMicrofinanceLoansComment] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProfessionalSituation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProfessionalExperience] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StudyLevel] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HousingSituation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FamilySituation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PublicBenefits] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NoofDependents] [int] NULL,
	[SocialSecurityNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MonthsofUnemployment] [int] NULL,
	[ChildrenEducation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EconomicEducation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SocialParticipation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HealthSituation] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[YearsofExperienceinBusiness] [int] NULL,
	[NoofPeopleinthisActivity] [int] NULL,
	[OwnHouse] [bit] NULL,
	[LandPlot] [bit] NULL,
	[Livestock] [bit] NULL,
	[Equipments] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MemberofGroupName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GroupType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EstablishmentDate] [datetime] NULL,
	[JoinedDate] [datetime] NULL,
	[LeftDate] [datetime] NULL,
	[PersonFirstContactDate] [datetime] NULL,
	[DateofFirstAppointment] [datetime] NULL,
	[PersonSourceofKnowHow] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PersonSponsor] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FollowupComment] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_Person] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_Person] ON
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (1, N'ewrer', N'werewr', CAST(0x0000A16400CF8D52 AS DateTime), N'M', N'werwr', N'', N'werw', 1, N'werwer', N'ewrer', N'wrwerwe', N'35002', N'C:\Projects\SPPayroll\SPPayroll\winSPPayroll\Resources\colormage.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (2, N'retr', N'tetret', CAST(0x0000A1A2011B7C83 AS DateTime), N'M', N'565', NULL, N'65', 1, N'565', N'retr', N'56', N'35000', N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\WinSchool\Resources\Students.bmp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (3, N'retr', N'tetret', CAST(0x0000A1A2011B7C83 AS DateTime), N'M', N'565', NULL, N'65', 1, N'565', N'retr', N'56', N'35000', N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\WinSchool\Resources\Students.bmp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (4, N'retr', N'tetret', CAST(0x0000A1A2011B7C83 AS DateTime), N'M', N'565', NULL, N'65', 1, N'565', N'retr', N'56', N'35000', N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\WinSchool\Resources\Students.bmp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (5, N'retr', N'tetret', CAST(0x0000A1A2011B7C83 AS DateTime), N'M', N'565', NULL, N'65', 1, N'565', N'retr', N'56', N'35000', N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\WinSchool\Resources\Students.bmp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (6, N'retr', N'tetret', CAST(0x0000A1A2011B7C83 AS DateTime), N'M', N'565', NULL, N'65', 1, N'565', N'retr', N'56', N'35000', N'D:\DEV\Working\Kevin\Projects\SBSchool\SBSchool\WinSchool\Resources\Students.bmp', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (7, N'ghjhgj', N'jgjghjgh', CAST(0x0000964B00F15AC4 AS DateTime), N'M', N'ghjgjghj', NULL, N'ghjgjgh', 0, N'ghjgjgh', N'ghjhgj', N'ghjghjgh', N'35000', N'C:\Projects\SBPayroll\SPPayroll\winSPPayroll\Resources\colormage.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000964B00F15AA6 AS DateTime), CAST(0x0000964B00F15AA6 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (8, N'ghjhgj', N'jgjghjgh', CAST(0x0000964B00F15AC4 AS DateTime), N'M', N'ghjgjghj', NULL, N'ghjgjgh', 0, N'ghjgjgh', N'ghjhgj', N'ghjghjgh', N'35000', N'C:\Projects\SBPayroll\SPPayroll\winSPPayroll\Resources\colormage.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000964B00F15AA6 AS DateTime), CAST(0x0000964B00F15AA6 AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[gl_Person] ([PersonID], [FirstName], [LastName], [DateofBirth], [Gender], [IDNo], [PersonEconomicActivity], [LoanCycle], [HeadofHouseHold], [PlaceofBirth], [FatherName], [CitizenShip], [pBranch], [pPhoto], [pHomeProvince], [pHomeDistrict], [pHomeCity], [pHomeAddress], [pHomeZipCode], [pHomeHomeType], [pHomePhone], [pHomeCellPhone], [pHomeEmail], [pBusinessProvince], [pBusinessDistrict], [pBusinessCity], [pBusinessAddress], [pBusinessZipCode], [pBusinessHomeType], [pBusinessPhone], [pBusinessCellPhone], [pBusinessEmail], [PersonalBankAddress], [PersonalBankName], [BusinessBankAddress], [BusinessBankName], [FinancialStatusBankName], [MonthlyHouseHoldIncome], [MonthlyHouseHoldExpenditure], [MonthlyDisposalIncome], [IsBadClient], [BadClientComment], [OtherMicrofinanceLoansName], [OtherMicrofinanceLoansAmount], [OtherMicrofinanceLoansDebts], [OtherMicrofinanceLoansComment], [ProfessionalSituation], [ProfessionalExperience], [StudyLevel], [HousingSituation], [FamilySituation], [PublicBenefits], [NoofDependents], [SocialSecurityNo], [MonthsofUnemployment], [ChildrenEducation], [EconomicEducation], [SocialParticipation], [HealthSituation], [YearsofExperienceinBusiness], [NoofPeopleinthisActivity], [OwnHouse], [LandPlot], [Livestock], [Equipments], [MemberofGroupName], [GroupType], [EstablishmentDate], [JoinedDate], [LeftDate], [PersonFirstContactDate], [DateofFirstAppointment], [PersonSourceofKnowHow], [PersonSponsor], [FollowupComment]) VALUES (9, N'ghjhgj', N'jgjghjgh', CAST(0x0000964B00F15AC4 AS DateTime), N'M', N'ghjgjghj', NULL, N'ghjgjgh', 0, N'ghjgjgh', N'ghjhgj', N'ghjghjgh', N'35000', N'C:\Projects\SBPayroll\SPPayroll\winSPPayroll\Resources\colormage.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, CAST(0x0000964B00F15AA6 AS DateTime), CAST(0x0000964B00F15AA6 AS DateTime), NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[gl_Person] OFF
/****** Object:  Table [dbo].[gl_NonSolidarityGroup]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_NonSolidarityGroup]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_NonSolidarityGroup](
	[NonSolidarityGroupID] [int] IDENTITY(1,1) NOT NULL,
	[nGroupName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nDateofEstablishment] [datetime] NULL,
	[nGroupOfficer] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nMeetingDate] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nSetMeetingDate] [bit] NULL,
	[nBranch] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nPhoto] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nProvince] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nDistrict] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nCity] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[nZipCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_NonSolidarityGroup] PRIMARY KEY CLUSTERED 
(
	[NonSolidarityGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Loans]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Loans]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Loans](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[lProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lProductCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lInstallmentType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lProductAllClientType] [bit] NULL,
	[lProductNonSolidarityGroupClientType] [bit] NULL,
	[lProductSolidarityGroupClientType] [bit] NULL,
	[lProductIndividualClientType] [bit] NULL,
	[lProductCorporateClientType] [bit] NULL,
	[lRoundingType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lProductFundingLine] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lProductCurrency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lInterestRateType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lChargeInterestOverGracePeriod] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lMinGracePeriod] [int] NULL,
	[lMaxGracePeriod] [int] NULL,
	[lValueGracePeriod] [int] NULL,
	[lMinAmount] [decimal](19, 4) NULL,
	[lMaxAmount] [decimal](19, 4) NULL,
	[lValueAmount] [decimal](19, 4) NULL,
	[lMinInterestRate] [int] NULL,
	[lMaxInterestRate] [int] NULL,
	[lValueInterestRate] [int] NULL,
	[lMinNumberofInstallments] [int] NULL,
	[lMaxNumberofInstallments] [int] NULL,
	[lValueNumberofInstallments] [int] NULL,
	[lUseLoanCycleAdvancedParameters] [bit] NULL,
	[lLoanCycleAdvancedParameters] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lAdvancedParametersCycleObject] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lUseLoanCycleEntryFees] [bit] NULL,
	[lLoanCycleEntryFees] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lMinLateFeesonTotalLoanAmount] [int] NULL,
	[lMaxLateFeesonTotalLoanAmount] [int] NULL,
	[lValueLateFeesonTotalLoanAmount] [int] NULL,
	[lMinLateFeesonOLB] [int] NULL,
	[lMaxLateFeesonOLB] [int] NULL,
	[lValueLateFeesonOLB] [int] NULL,
	[lMinLateFeesonOverduePrincipal] [int] NULL,
	[lMaxLateFeesonOverduePrincipal] [int] NULL,
	[lValueLateFeesonOverduePrincipal] [int] NULL,
	[lMinLateFeesonOverdueInterest] [int] NULL,
	[lMaxLateFeesonOverdueInterest] [int] NULL,
	[lValueLateFeesonOverdueInterest] [int] NULL,
	[lGracePeriodofLateFees] [int] NULL,
	[lMinATRFees] [int] NULL,
	[lMaxATRFees] [int] NULL,
	[lValueATRFees] [int] NULL,
	[lBaseforATRFees] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lMinAPRFees] [int] NULL,
	[lMaxAPRFees] [int] NULL,
	[lValueAPRFees] [int] NULL,
	[lBaseforAPRFees] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lUseExoticInstallments] [bit] NULL,
	[lExoticInstallment] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lAllowFlexibleSchedule] [bit] NULL,
	[lFakePackage] [bit] NULL,
	[lUseLineofCredit] [bit] NULL,
	[lNoofDrawingsunderLOC] [int] NULL,
	[lMinAmountunderLOC] [decimal](19, 4) NULL,
	[lMaxAmountunderLOC] [decimal](19, 4) NULL,
	[lValueAmountunderLOC] [decimal](19, 4) NULL,
	[lMinTrancheMaturity] [int] NULL,
	[lMaxTrancheMaturity] [int] NULL,
	[lValueTrancheMaturity] [int] NULL,
	[lUseGuarantorsandCollaterals] [bit] NULL,
	[lMinPercentageofGuarantorsandCollaterals] [int] NULL,
	[lSetSeparateValuesforGuarantorsandCollaterals] [bit] NULL,
	[lMinPercentageforGuarantors] [int] NULL,
	[lMinPercentageforCollaterals] [int] NULL,
	[lUseCompulsorySavings] [bit] NULL,
	[lCompulsorySavingsAmountType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[lMinCompulsorySavingsAmount] [decimal](19, 4) NULL,
	[lMaxCompulsorySavingsAmount] [decimal](19, 4) NULL,
	[lValueCompulsorySavingsAmount] [decimal](19, 4) NULL,
	[lMinCreditInsurance] [decimal](19, 4) NULL,
	[lMaxCreditInsurance] [decimal](19, 4) NULL,
 CONSTRAINT [PK_gl_Loans] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_InstallmentTypes]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_InstallmentTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_InstallmentTypes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[InstallmentName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NumberofMonths] [int] NULL,
	[NumberofDays] [int] NULL,
 CONSTRAINT [PK_gl_InstallmentTypes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Guarantee]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Guarantee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Guarantee](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[gProductName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gProductAllClientType] [bit] NULL,
	[gProductGroupClientType] [bit] NULL,
	[gProductIndividualClientType] [bit] NULL,
	[gProductCorporateClientType] [bit] NULL,
	[gProductFundingLine] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gProductCurrency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[gMinAmounttobeGuaranteed] [decimal](19, 4) NULL,
	[gMaxAmounttobeGuaranteed] [decimal](19, 4) NULL,
	[gValueAmounttobeGuaranteed] [decimal](19, 4) NULL,
	[gMinGuaranteeAmount] [decimal](19, 4) NULL,
	[gMaxGuaranteeAmount] [decimal](19, 4) NULL,
	[gValueGuaranteeAmount] [decimal](19, 4) NULL,
	[gMinFeePercentage] [int] NULL,
	[gMaxFeePercentage] [int] NULL,
	[gValueFeePercentage] [int] NULL,
 CONSTRAINT [PK_gl_Guarantee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_Guarantee] ON
INSERT [dbo].[gl_Guarantee] ([Id], [gProductName], [gProductAllClientType], [gProductGroupClientType], [gProductIndividualClientType], [gProductCorporateClientType], [gProductFundingLine], [gProductCurrency], [gMinAmounttobeGuaranteed], [gMaxAmounttobeGuaranteed], [gValueAmounttobeGuaranteed], [gMinGuaranteeAmount], [gMaxGuaranteeAmount], [gValueGuaranteeAmount], [gMinFeePercentage], [gMaxFeePercentage], [gValueFeePercentage]) VALUES (1, N'12432155', 1, 1, 1, 1, N'IMF', N'Kshs', CAST(77.0000 AS Decimal(19, 4)), CAST(77.0000 AS Decimal(19, 4)), CAST(77.0000 AS Decimal(19, 4)), CAST(77.0000 AS Decimal(19, 4)), CAST(77.0000 AS Decimal(19, 4)), CAST(77.0000 AS Decimal(19, 4)), 77, 77, 77)
INSERT [dbo].[gl_Guarantee] ([Id], [gProductName], [gProductAllClientType], [gProductGroupClientType], [gProductIndividualClientType], [gProductCorporateClientType], [gProductFundingLine], [gProductCurrency], [gMinAmounttobeGuaranteed], [gMaxAmounttobeGuaranteed], [gValueAmounttobeGuaranteed], [gMinGuaranteeAmount], [gMaxGuaranteeAmount], [gValueGuaranteeAmount], [gMinFeePercentage], [gMaxFeePercentage], [gValueFeePercentage]) VALUES (2, N'444', 1, 1, 1, 1, N'IMF', N'Kshs', CAST(56546.0000 AS Decimal(19, 4)), CAST(4564.0000 AS Decimal(19, 4)), CAST(4645.0000 AS Decimal(19, 4)), CAST(6464.0000 AS Decimal(19, 4)), CAST(6464.0000 AS Decimal(19, 4)), CAST(646.0000 AS Decimal(19, 4)), 4564, 4564, 464)
SET IDENTITY_INSERT [dbo].[gl_Guarantee] OFF
/****** Object:  Table [dbo].[gl_FundingLines]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_FundingLines]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_FundingLines](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FundingLineCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Currency] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BeginDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[InitialAmount] [decimal](19, 4) NULL,
	[RealReminder] [decimal](19, 4) NULL,
	[AnticipatedReminder] [decimal](19, 4) NULL,
 CONSTRAINT [PK_gl_FundingLines] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_FundingLines] ON
INSERT [dbo].[gl_FundingLines] ([Id], [Name], [FundingLineCode], [Currency], [BeginDate], [EndDate], [InitialAmount], [RealReminder], [AnticipatedReminder]) VALUES (1, N'International Monetary Fund', N'IMF', N'Kshs', CAST(0x0000A159013F038C AS DateTime), CAST(0x0000DDE9013F02CC AS DateTime), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)))
INSERT [dbo].[gl_FundingLines] ([Id], [Name], [FundingLineCode], [Currency], [BeginDate], [EndDate], [InitialAmount], [RealReminder], [AnticipatedReminder]) VALUES (2, N'World Bank', N'WB', N'1', CAST(0x0000A1BF01241124 AS DateTime), CAST(0x0000A1AB01241124 AS DateTime), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)), CAST(0.0000 AS Decimal(19, 4)))
SET IDENTITY_INSERT [dbo].[gl_FundingLines] OFF
/****** Object:  Table [dbo].[gl_FundingLineEvents]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_FundingLineEvents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_FundingLineEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FundingLineId] [int] NULL,
	[FundingLineEventCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreationDate] [datetime] NULL,
	[Amount] [decimal](19, 4) NULL,
	[Direction] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Type] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_FundingLineEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_ExchangeRates]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_ExchangeRates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_ExchangeRates](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Exchange_Rate] [float] NULL,
	[CurrencyId] [int] NULL,
	[ExchangeDate] [datetime] NULL,
 CONSTRAINT [PK_ExchangeRates] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_EntryFees]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_EntryFees]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_EntryFees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoanProductId] [int] NULL,
	[NameofEntryFee] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[MinEntryFees] [decimal](19, 4) NULL,
	[MaxEntryFees] [decimal](19, 4) NULL,
	[ValueEntryFees] [decimal](19, 4) NULL,
	[RateEntryFees] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[FeeIndex] [int] NULL,
	[CycleId] [int] NULL,
 CONSTRAINT [PK_gl_EntryFees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_EconomicActivity]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_EconomicActivity]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_EconomicActivity](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ActivityName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Parent_Id] [int] NULL,
 CONSTRAINT [PK_gl_EconomicActivity] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Documents]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Documents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Documents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerObject] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocFileName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocFilePath] [nvarchar](1000) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DocFileSize] [float] NULL,
	[DocFileType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[dUser] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Comment] [nvarchar](550) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[UploadDate] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_Documents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
SET IDENTITY_INSERT [dbo].[gl_Documents] ON
INSERT [dbo].[gl_Documents] ([Id], [OwnerObject], [DocName], [DocFileName], [DocFilePath], [DocFileSize], [DocFileType], [dUser], [Comment], [UploadDate]) VALUES (1, N'listViewLoanDetailsDocument', N'fffffffffffffffffffffffffffffffffff', N'Doc2.docx', N'C:\Users\Administrator\Documents\Doc2.docx', 1052782, N'.docx', N'sys', N'vffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffffff', N'15-Monday-April-2013')
SET IDENTITY_INSERT [dbo].[gl_Documents] OFF
/****** Object:  Table [dbo].[gl_Cycles]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Cycles]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Cycles](
	[CycleId] [int] IDENTITY(1,1) NOT NULL,
	[CycleName] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_Cycles] PRIMARY KEY CLUSTERED 
(
	[CycleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_CycleParameters]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CycleParameters]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_CycleParameters](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoanCycle] [int] NULL,
	[CycleObjectId] [int] NULL,
	[CycleId] [int] NULL,
	[Min] [decimal](19, 4) NULL,
	[Max] [decimal](19, 4) NULL,
 CONSTRAINT [PK_gl_CycleParameters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_CycleObjects]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CycleObjects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_CycleObjects](
	[CycleObjectId] [int] IDENTITY(1,1) NOT NULL,
	[CycleObjectName] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_CycleObjects] PRIMARY KEY CLUSTERED 
(
	[CycleObjectId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_Customers]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[NationalID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BusinessLicenseNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DrivingLicenseNo] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TaxID] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PIN] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShortName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[FirstName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecondName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ThirdName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Surname] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AlternativesName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PostalAddress] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StreetAddress1A] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StreetAddress1B] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[StreetAddress1C] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[streetAddress1D] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[City1] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Province] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Country] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[District] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Postalcode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Address] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CountryCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AreaCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TelephoneType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Phone] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmailType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Telex] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Customertype1] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerType2] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerType3] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SICTypeCode] [int] NULL,
	[OtherTypeCodes] [int] NULL,
	[Branch] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProductUsageReason] [varchar](850) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CampaignResponse] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorporateCycle] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerReferral] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrimaryAccountOfficer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SecondaryAccountOfficer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OfficerReferral] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OtherAccountOfficers] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[SwiftSwift] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CHCode1] [int] NULL,
	[CHCode2] [int] NULL,
	[CHCode3] [int] NULL,
	[CorrespondenceType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CorrespondenceHold] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AddressToUse] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Salutation] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IntraSaccoingIndicator] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IntrasaccoingPassword] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[IntraSaccoingPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InternetSaccoing] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InternetPasser] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[InternetPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ATMNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ATMPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HomeSaccoing] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PhoneSaccoingPin] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OtherDeliveryData] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[TypeOfEmployment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Employer] [int] NULL,
	[EmployerAddress] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[YearsEmployed] [int] NULL,
	[AnnualSalary] [decimal](19, 4) NULL,
	[Title] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OccupationDate] [datetime] NULL,
	[EmploymentStatus] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OccupationType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ForeignID] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Citizenship] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NetWorth] [decimal](19, 4) NULL,
	[Gender] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EducationLevel] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CertificationDate] [datetime] NULL,
	[BirthDay] [datetime] NULL,
	[Spouse] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[NumberofDependants] [int] NULL,
	[Ages] [datetime] NULL,
	[AgeGroup] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[HousingOwnershipType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[YearsInHome] [int] NULL,
	[OutstandingMortgage] [decimal](18, 0) NULL,
	[Language] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Religion] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DeathNotificationDate] [datetime] NULL,
	[DeathDay] [datetime] NULL,
	[CompanyLicense] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AnnualSales] [decimal](18, 0) NULL,
	[SignatoryRestriction] [decimal](18, 0) NULL,
	[IncorporationDate] [datetime] NULL,
	[NumberofEmployees] [int] NULL,
	[Relationships] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreditRating] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GeographicArea] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DebtLevelSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DebtLevelDate] [datetime] NULL,
	[BusinessAgeSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BusinessAgeDate] [datetime] NULL,
	[RevenueSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[RevenueSegmentDate] [datetime] NULL,
	[EmployeeCountSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EmployeeCountSegmDate] [datetime] NULL,
	[GrowthRateSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GrowthRateSegmentDate] [datetime] NULL,
	[CapitalizationSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CapitalizationSegmentDate] [datetime] NULL,
	[ProfitabilitySegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ProfitabilitySegmentDate] [datetime] NULL,
	[LifeCycleStatus] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[EstablishDate] [datetime] NULL,
	[DissolvedDate] [datetime] NULL,
	[DebtClassSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CustomerGradeSegment] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LongTermDebtToFinanceRatio] [int] NULL,
	[DebtToEquityRatio] [int] NULL,
	[AssetTurnOver] [decimal](19, 4) NULL,
	[PriceRatio] [int] NULL,
	[EarnPerShare] [decimal](19, 4) NULL,
	[ReturnOnEquity] [decimal](19, 4) NULL,
	[ReturnOnNetTotalAssets] [decimal](19, 4) NULL,
	[ReturnOnTotalAssets] [decimal](19, 4) NULL,
	[ReturnOnCapitalEmployed] [decimal](19, 4) NULL,
	[AnnualSaleRevenue] [decimal](19, 4) NULL,
	[AnnualPreTaxProfit] [decimal](19, 4) NULL,
	[CapitalandReserves] [decimal](19, 4) NULL,
	[TotalBorrowing] [decimal](19, 4) NULL,
	[CurrentAssets] [decimal](19, 4) NULL,
	[FixedAssets] [decimal](19, 4) NULL,
	[DepositAccountNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Count] [int] NULL,
	[Amount] [decimal](19, 4) NULL,
	[InterestYTD] [decimal](19, 4) NULL,
	[JointOwnership] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DepositHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LineAmount] [decimal](19, 4) NULL,
	[BalanceOutstanding] [decimal](19, 4) NULL,
	[InterestRate] [int] NULL,
	[CreditAvailable] [decimal](19, 4) NULL,
	[CreditCardInterestYTD] [decimal](19, 4) NULL,
	[LateFees] [decimal](19, 4) NULL,
	[DueDate] [datetime] NULL,
	[CreditInfo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CredidcardHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanAccNo] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[OriginalLoan] [decimal](19, 4) NULL,
	[PrincipalAmount] [decimal](19, 4) NULL,
	[AnnualYield] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccruedInterest] [decimal](19, 4) NULL,
	[CurrentBalance] [decimal](19, 4) NULL,
	[PayOffAmount] [decimal](19, 4) NULL,
	[LoanAccountHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrincipalPaid] [decimal](19, 4) NULL,
	[InterestPaid] [decimal](19, 4) NULL,
	[CostofFunds] [decimal](19, 4) NULL,
	[SourceofFunds] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_Customers] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_CustomerAccounts]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_CustomerAccounts](
	[CustomerId] [int] NOT NULL,
	[AccountId] [int] NOT NULL,
	[Mandate] [nchar](10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_CustomerAccounts] PRIMARY KEY CLUSTERED 
(
	[CustomerId] ASC,
	[AccountId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[gl_BankBranch]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_BankBranch]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_BankBranch](
	[BankSortCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BranchCode] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Bank] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BranchName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_BankBranch] PRIMARY KEY CLUSTERED 
(
	[BankSortCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02006', N'006', N'02', N'Kenyatta111555555')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02007', N'007', N'02', N'Kimathi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02009', N'009', N'02', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02010', N'010', N'02', N'Nanyuki')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02011', N'011', N'02', N'Nyeribbbbbbbbbbbb5555555')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02012', N'012', N'02', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02015', N'015', N'02', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02016', N'016', N'02', N'Machakos')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02017', N'017', N'02', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02019', N'019', N'02', N'Harambee')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02020', N'020', N'02', N'Kiambu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02053', N'053', N'02', N'Industrial Area ')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02054', N'054', N'02', N'Kakamega88888888888888888')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02060', N'060', N'02', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02063', N'063', N'02', N'Haile Selassie444444444444444')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02064', N'064', N'02', N'Koinange Street3333333333333333')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02071', N'071', N'02', N'Yaya Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02072', N'072', N'02', N'Ruaraka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02074', N'074', N'02', N'Langata')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02075', N'075', N'02', N'Makupa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02076', N'076', N'02', N'Karen')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02077', N'077', N'02', N'Muthaiga')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02078', N'078', N'02', N'Customer Service Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02079', N'079', N'02', N'Customer Service Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02080', N'080', N'02', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02081', N'081', N'02', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02082', N'082', N'02', N'Uper Hill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02083', N'083', N'02', N'Mombasa-Nyali')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'02084', N'084', N'02', N'Chiromo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03002', N'002', N'03', N'Kapsabet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03003', N'003', N'03', N'Eldoret Std & Prestige')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03004', N'004', N'03', N'Embu Std & Prestige')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03005', N'005', N'03', N'Murang''a')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03006', N'006', N'03', N'Kapenguria')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03007', N'007', N'03', N'Kericho')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03008', N'008', N'03', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03009', N'009', N'03', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03010', N'010', N'03', N'South C')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03011', N'011', N'03', N'Limuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03012', N'012', N'03', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03013', N'013', N'03', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03014', N'014', N'03', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03015', N'015', N'03', N'Kitui')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03016', N'016', N'03', N'Nkrumah Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03017', N'017', N'03', N'Garissa ')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03018', N'018', N'03', N'Nyamira')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03019', N'019', N'03', N'Kilifi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03020', N'020', N'03', N'Waiyaki Way')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03023', N'023', N'03', N'Gilgil')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03024', N'024', N'03', N'Githurai')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03027', N'027', N'03', N'Nakuru East')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03028', N'028', N'03', N'Buruburu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03029', N'029', N'03', N'Bomet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03030', N'030', N'03', N'Nyeri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03031', N'031', N'03', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03032', N'032', N'03', N'Port Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03033', N'033', N'03', N'Gikomba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03034', N'034', N'03', N'Kawangware')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03035', N'035', N'03', N'Mbale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03036', N'036', N'03', N'Plaza Premier Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03037', N'037', N'03', N'River Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03038', N'038', N'03', N'Upper River Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03039', N'039', N'03', N'Mumias')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03040', N'040', N'03', N'Machakos')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03042', N'042', N'03', N'Isiolo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03043', N'043', N'03', N'Ngong')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03044', N'044', N'03', N'Maua')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03045', N'045', N'03', N'Hurlingham')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03046', N'046', N'03', N'Makupa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03047', N'047', N'03', N'Development Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03049', N'049', N'03', N'Lavington')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03050', N'050', N'03', N'Eastleigh II')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03051', N'051', N'03', N'Homa Bay')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03052', N'052', N'03', N'Rongai')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03053', N'053', N'03', N'Othaya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03054', N'054', N'03', N'Voi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03055', N'055', N'03', N'Muthaiga')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03057', N'057', N'03', N'Githunguri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03058', N'058', N'03', N'Webuye')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03060', N'060', N'03', N'Chuka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03061', N'061', N'03', N'Nakumatt Westgate')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03062', N'062', N'03', N'Kabarnet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03063', N'063', N'03', N'Kerugoya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03064', N'064', N'03', N'Taveta')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03065', N'065', N'03', N'Karen Std&Prestige')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03066', N'066', N'03', N'Wundanyi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03067', N'067', N'03', N'Ruaraka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03069', N'069', N'03', N'Wote')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03070', N'070', N'03', N'Enterprise prestige centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03071', N'071', N'03', N'Nakumatt Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03072', N'072', N'03', N'Juja')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03073', N'073', N'03', N'ABC Prestige')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03074', N'074', N'03', N'Kikuyu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03075', N'075', N'03', N'Moi Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03077', N'077', N'03', N'Plaza Business Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03078', N'078', N'03', N'Kiriaini')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03079', N'079', N'03', N'Avon Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03080', N'080', N'03', N'Migori')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03082', N'082', N'03', N'Haile Selassie')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03083', N'083', N'03', N'University of Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03086', N'086', N'03', N'Nairobi west')
GO
print 'Processed 100 total records'
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03087', N'087', N'03', N'Parkland Highbridge')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03088', N'088', N'03', N'Busia')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03089', N'089', N'03', N'Pangani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03093', N'093', N'03', N'Kariobangi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03094', N'094', N'03', N'QueensWay')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'03095', N'095', N'03', N'Nakumatt Ebakasi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05000', N'000', N'05', N'Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05001', N'001', N'05', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05002', N'002', N'05', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'05003', N'003', N'05', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06000', N'000', N'06', N'Nairobi Main')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06002', N'002', N'06', N'Digo rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06004', N'004', N'06', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06005', N'005', N'06', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06006', N'006', N'06', N'Sarit Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06007', N'007', N'06', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06008', N'008', N'06', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'06009', N'009', N'06', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07000', N'000', N'07', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07001', N'001', N'07', N'Upper Hill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07002', N'002', N'07', N'Wabera')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07003', N'003', N'07', N'Mama Ngina Br/Hilton Agency')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07004', N'004', N'07', N'Westlands Br/ILRI Agency')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07005', N'005', N'07', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07006', N'006', N'07', N'Mamlaka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07007', N'007', N'07', N'Village Mkt Br/US Emb/Icraf Ag')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07008', N'008', N'07', N'Cargo Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07009', N'009', N'07', N'Park Side')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07016', N'016', N'07', N'Galleria')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07017', N'017', N'07', N'Junction')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07020', N'020', N'07', N'Moi Avenue Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07021', N'021', N'07', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07022', N'022', N'07', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07023', N'023', N'07', N'Bamburi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07024', N'024', N'07', N'Diani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07025', N'025', N'07', N'Changamwe')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07026', N'026', N'07', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'07027', N'027', N'07', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'08046', N'046', N'08', N'Mobasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'08047', N'047', N'08', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'08048', N'048', N'08', N'Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09000', N'000', N'09', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09001', N'001', N'09', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09002', N'002', N'09', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09003', N'003', N'09', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'09004', N'004', N'09', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10000', N'000', N'10', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10001', N'001', N'10', N'Kenindia')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10002', N'002', N'10', N'Biashara')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10003', N'003', N'10', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10004', N'004', N'10', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10005', N'005', N'10', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10006', N'006', N'10', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10007', N'007', N'10', N'Parklands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10008', N'008', N'10', N'Riverside Drive')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10009', N'009', N'10', N'Card centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10010', N'010', N'10', N'Hurlingham')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10011', N'011', N'10', N'Capital Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10012', N'012', N'10', N'Nyali')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10014', N'014', N'10', N'Kamukunji')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'10015', N'015', N'10', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11000', N'000', N'11', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11002', N'002', N'11', N'Co-op Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11003', N'003', N'11', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11004', N'004', N'11', N'Nkrumah Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11005', N'005', N'11', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11006', N'006', N'11', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11007', N'007', N'11', N'Industrial Are')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11008', N'008', N'11', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11009', N'009', N'11', N'Machakos')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11010', N'010', N'11', N'Nyeri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11011', N'011', N'11', N'Ukulima')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11012', N'012', N'11', N'Chuka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11013', N'013', N'11', N'Wakulima Market')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11014', N'014', N'11', N'Moi Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11015', N'015', N'11', N'Naivasha')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11017', N'017', N'11', N'Nyahururu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11018', N'018', N'11', N'Chuka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11019', N'019', N'11', N'Wakulima Market')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11020', N'020', N'11', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11021', N'021', N'11', N'Kiambu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11022', N'022', N'11', N'Homabay')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11023', N'023', N'11', N'Embu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11024', N'024', N'11', N'Kericho')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11025', N'025', N'11', N'Bungoma')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11026', N'026', N'11', N'Muranga')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11027', N'027', N'11', N'Kayole')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11028', N'028', N'11', N'Karatina')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11029', N'029', N'11', N'Ukunda')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11030', N'030', N'11', N'Mtwapa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11031', N'031', N'11', N'University way')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11032', N'032', N'11', N'BuruBuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11033', N'033', N'11', N'AthiRiver')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11034', N'034', N'11', N'Mumias')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11035', N'035', N'11', N'Stima Plaza')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11036', N'036', N'11', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11037', N'037', N'11', N'Upper Hill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11038', N'038', N'11', N'Ongata Rongai')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11039', N'039', N'11', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11040', N'040', N'11', N'Nacico Plaza')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11041', N'041', N'11', N'Kariobangi')
GO
print 'Processed 200 total records'
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11042', N'042', N'11', N'Kawangware')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11043', N'043', N'11', N'Makutano')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11044', N'044', N'11', N'Parliament Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11045', N'045', N'11', N'Kimathi Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11046', N'046', N'11', N'Kitale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11047', N'047', N'11', N'Githurai Agency')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11048', N'048', N'11', N'Maua')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11049', N'049', N'11', N'City Hall')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11050', N'050', N'11', N'Digo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11051', N'051', N'11', N'Nairobi Business Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11052', N'052', N'11', N'Kakamega')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11053', N'053', N'11', N'Migori')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11055', N'055', N'11', N'Nkubu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11056', N'056', N'11', N'Enterprise Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11057', N'057', N'11', N'Busia')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11058', N'058', N'11', N'Siaya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11059', N'059', N'11', N'Voi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11060', N'060', N'11', N'Mariakani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11061', N'061', N'11', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11062', N'062', N'11', N'Zimmerman')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11063', N'063', N'11', N'Nakuru East')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11064', N'064', N'11', N'Kitengela')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11065', N'065', N'11', N'Aga Khan Walk')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11066', N'066', N'11', N'Narok')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11067', N'067', N'11', N'Kitui')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11068', N'068', N'11', N'Nanyuki')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11069', N'069', N'11', N'Embakasi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11070', N'070', N'11', N'Kibera')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11071', N'071', N'11', N'Siakago')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11072', N'072', N'11', N'Kapsabet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11073', N'073', N'11', N'Mbita')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11074', N'074', N'11', N'Kangemi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11075', N'075', N'11', N'Dandora')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11077', N'077', N'11', N'Tala')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11078', N'078', N'11', N'Gikomba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11079', N'079', N'11', N'River Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11080', N'080', N'11', N'Nyamira')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11081', N'081', N'11', N'Garissa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11082', N'082', N'11', N'Bomet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11083', N'083', N'11', N'Keroka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11084', N'084', N'11', N'Gilgil')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11085', N'085', N'11', N'Tom Mboya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11086', N'086', N'11', N'Likoni')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11088', N'088', N'11', N'Mwingi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11089', N'089', N'11', N'Mwingi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11090', N'090', N'11', N'Webuye')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11100', N'100', N'11', N'Ndhiwa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'11102', N'102', N'11', N'Isiolo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14000', N'000', N'14', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14004', N'004', N'14', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14005', N'005', N'14', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14006', N'006', N'14', N'Kitale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'14007', N'007', N'14', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'17000', N'000', N'17', N'Main Branch')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'17001', N'001', N'17', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'17002', N'002', N'17', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18000', N'000', N'18', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18002', N'002', N'18', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18003', N'003', N'18', N'Milimani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'18004', N'004', N'18', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19000', N'000', N'19', N'Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19001', N'001', N'19', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19002', N'002', N'19', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19003', N'003', N'19', N'Uhuru Highway')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19004', N'004', N'19', N'River Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19006', N'006', N'19', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19007', N'007', N'19', N'Ruaraka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19008', N'008', N'19', N'Monrovia Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19009', N'009', N'19', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19010', N'010', N'19', N'Ngong Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19011', N'011', N'19', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19012', N'012', N'19', N'Embakasi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19013', N'013', N'19', N'Kericho')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19014', N'014', N'19', N'Changamwe')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19015', N'015', N'19', N'Bungoma')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19017', N'017', N'19', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'19018', N'018', N'19', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20001', N'001', N'20', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20002', N'002', N'20', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20003', N'003', N'20', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'20004', N'004', N'20', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23000', N'000', N'23', N'Harambee Avenue Harambee Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23001', N'001', N'23', N'Murang''a')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23002', N'002', N'23', N'Embu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23003', N'003', N'23', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23004', N'004', N'23', N'Koinange Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23005', N'005', N'23', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23006', N'006', N'23', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23007', N'007', N'23', N'Nyeri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23009', N'009', N'23', N'Maua')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23010', N'010', N'23', N'Isiolo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23011', N'011', N'23', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23013', N'013', N'23', N'Umoja')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23014', N'014', N'23', N'River Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23015', N'015', N'23', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'23016', N'016', N'23', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25000', N'000', N'25', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25001', N'001', N'25', N'Koinange Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25002', N'002', N'25', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25003', N'003', N'25', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25004', N'004', N'25', N'Kisii')
GO
print 'Processed 300 total records'
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25005', N'005', N'25', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'25006', N'006', N'25', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26001', N'001', N'26', N'Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26002', N'002', N'26', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26003', N'003', N'26', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26005', N'005', N'26', N'MIA')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26006', N'006', N'26', N'JKIA')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26007', N'007', N'26', N'Kirinyaga')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26008', N'008', N'26', N'Kabarak')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26009', N'009', N'26', N'Olenguruone')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26010', N'010', N'26', N'Kericho')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26011', N'011', N'26', N'Nandi Hills')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26012', N'012', N'26', N'EPZ')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26013', N'013', N'26', N'Sheikh Karume')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'26014', N'014', N'26', N'Kabarnet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30000', N'000', N'30', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30001', N'001', N'30', N'City Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30003', N'003', N'30', N'Village Market')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30004', N'004', N'30', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30005', N'005', N'30', N'Hurlingham')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30006', N'006', N'30', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30007', N'007', N'30', N'Parklands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30008', N'008', N'30', N'Riverside Mews')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30009', N'009', N'30', N'Iman Banking Centre Riverside Mews')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30010', N'010', N'30', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30011', N'011', N'30', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30012', N'012', N'30', N'Donholm')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30014', N'014', N'30', N'Ngara Mini Branch Peace Towers')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30015', N'015', N'30', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'30016', N'016', N'30', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31000', N'000', N'31', N'Clearing Centre,Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31002', N'002', N'31', N'Kenyatta Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31003', N'003', N'31', N'Digo Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31004', N'004', N'31', N'Waiyaki Way')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31005', N'005', N'31', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31006', N'006', N'31', N'Harambee Avenue Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31007', N'007', N'31', N'Chiromo Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31008', N'008', N'31', N'International House')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31009', N'009', N'31', N'Nkrumah')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31010', N'010', N'31', N'Upper Hill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31011', N'011', N'31', N'Naivasha')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31012', N'012', N'31', N'Westgate')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31013', N'013', N'31', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31014', N'014', N'31', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31015', N'015', N'31', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31016', N'016', N'31', N'Nyerere')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31017', N'017', N'31', N'Nanyuki')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31018', N'018', N'31', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31020', N'020', N'31', N'Gikomba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31021', N'021', N'31', N'Ruaraka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31022', N'022', N'31', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31023', N'023', N'31', N'Karen')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31024', N'024', N'31', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'31999', N'999', N'31', N'Central Processing CfC Centre,HeadOffice')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35000', N'000', N'35', N'Koinange Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35001', N'001', N'35', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35002', N'002', N'35', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35004', N'004', N'35', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35005', N'005', N'35', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35006', N'006', N'35', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35007', N'007', N'35', N'Libra House')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'35008', N'008', N'35', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39001', N'001', N'39', N'IPS')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39002', N'002', N'39', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39003', N'003', N'39', N'Upper Hill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39004', N'004', N'39', N'Parklands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39006', N'006', N'39', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39007', N'007', N'39', N'Watamu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39008', N'008', N'39', N'Diani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39009', N'009', N'39', N'Kilifi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39010', N'010', N'39', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39011', N'011', N'39', N'Karen')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39012', N'012', N'39', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39014', N'014', N'39', N'Changamwe')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39015', N'015', N'39', N'Riverside')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39016', N'016', N'39', N'Likoni')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'39018', N'018', N'39', N'Village Market')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41000', N'000', N'41', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41101', N'101', N'41', N'City Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41102', N'102', N'41', N'NIC Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41103', N'103', N'41', N'Harbor Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41105', N'105', N'41', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41106', N'106', N'41', N'Junction')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41107', N'107', N'41', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41108', N'108', N'41', N'Nyali')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41109', N'109', N'41', N'Nkurumah Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41111', N'111', N'41', N'Prestige')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41112', N'112', N'41', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41113', N'113', N'41', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41114', N'114', N'41', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41115', N'115', N'41', N'Galleria (Bomas)')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41116', N'116', N'41', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41117', N'117', N'41', N'Village Market')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'41118', N'118', N'41', N'Mombasa Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42001', N'001', N'42', N'Banda Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42004', N'004', N'42', N'Kimathi Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42005', N'005', N'42', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42006', N'006', N'42', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'42007', N'007', N'42', N'Parklands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43000', N'000', N'43', N'Ecobank Towers')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43002', N'002', N'43', N'Mombasa')
GO
print 'Processed 400 total records'
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43003', N'003', N'43', N'Plaza 2000')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43004', N'004', N'43', N'Westminister')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43005', N'005', N'43', N'Chambers')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43007', N'007', N'43', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43008', N'008', N'43', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43009', N'009', N'43', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43010', N'010', N'43', N'Kitale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43011', N'011', N'43', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43012', N'012', N'43', N'Karatina')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43013', N'013', N'43', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43014', N'014', N'43', N'United Mall')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43015', N'015', N'43', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43016', N'016', N'43', N'Jomo Kenyatta Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43017', N'017', N'43', N'Nyeri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43018', N'018', N'43', N'Busia')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43019', N'019', N'43', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43020', N'020', N'43', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43021', N'021', N'43', N'Gikomba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43023', N'023', N'43', N'Valley Arcade')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'43100', N'100', N'43', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49000', N'000', N'49', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49001', N'001', N'49', N'Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49002', N'002', N'49', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49003', N'003', N'49', N'Westlands The Mall The Mall')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49005', N'005', N'49', N'Chester')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49007', N'007', N'49', N'Waiyaki Way')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49008', N'008', N'49', N'Kakamega')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49009', N'009', N'49', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49011', N'011', N'49', N'Nyali')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49012', N'012', N'49', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'49013', N'013', N'49', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50000', N'000', N'50', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50001', N'001', N'50', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50002', N'002', N'50', N'Parklands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'50003', N'003', N'50', N'Koinange Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'5004', N'004', N'50', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'51000', N'000', N'51', N'Koinange Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53001', N'001', N'53', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53002', N'002', N'53', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53003', N'003', N'53', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53004', N'004', N'53', N'Lavington')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53005', N'005', N'53', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53006', N'006', N'53', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53007', N'007', N'53', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53008', N'008', N'53', N'Muthaiga')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53010', N'010', N'53', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53011', N'011', N'53', N'Gikomba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53012', N'012', N'53', N'Ngong Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'53013', N'013', N'53', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'54001', N'001', N'54', N'Nairobi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'54002', N'002', N'54', N'Riverside Drive')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55001', N'001', N'55', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55002', N'002', N'55', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55004', N'004', N'55', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55005', N'005', N'55', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55006', N'006', N'55', N'Main Branch')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'55007', N'007', N'55', N'Mombasa Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57000', N'000', N'57', N'Kenyatta Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57001', N'001', N'57', N'2nd Ngong Avenue I & M Bank House')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57002', N'002', N'57', N'Sarit Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57003', N'003', N'57', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57004', N'004', N'57', N'Biashara')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57005', N'005', N'57', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57007', N'007', N'57', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57008', N'008', N'57', N'Karen')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57009', N'009', N'57', N'Panari Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57010', N'010', N'57', N'Parklands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57011', N'011', N'57', N'Wilson Airport')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57012', N'012', N'57', N'Ongata Rongai')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57013', N'013', N'57', N'South C Shopping South C')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57014', N'014', N'57', N'Nyali Cinemax')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57015', N'015', N'57', N'Langata Link')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57016', N'016', N'57', N'Lavington')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57018', N'018', N'57', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'57098', N'098', N'57', N'Card Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'59001', N'001', N'59', N'Loita Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'59002', N'002', N'59', N'Ngong Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60000', N'000', N'60', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60001', N'001', N'60', N'City Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60002', N'002', N'60', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60003', N'003', N'60', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60004', N'004', N'60', N'Diani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'60006', N'006', N'60', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63000', N'000', N'63', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63001', N'001', N'63', N'Nation Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63002', N'002', N'63', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63003', N'003', N'63', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63005', N'005', N'63', N'Parklands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63006', N'006', N'63', N'Westgate')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63008', N'008', N'63', N'Mombasa Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63009', N'009', N'63', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63011', N'011', N'63', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63012', N'012', N'63', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63013', N'013', N'63', N'OTC')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63014', N'014', N'63', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63015', N'015', N'63', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63016', N'016', N'63', N'Changamwe')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63017', N'017', N'63', N'T-Mall')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63018', N'018', N'63', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63019', N'019', N'63', N'Village Market')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63020', N'020', N'63', N'Diani')
GO
print 'Processed 500 total records'
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63021', N'021', N'63', N'Bungoma')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63023', N'023', N'63', N'Prestige')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63024', N'024', N'63', N'Buru Buru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63025', N'025', N'63', N'Kitengela')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63026', N'026', N'63', N'Jomo Kenyatta')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63027', N'027', N'63', N'Kakamega')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63028', N'028', N'63', N'Kericho')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63029', N'029', N'63', N'Upper Hill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63030', N'030', N'63', N'Wabera Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63031', N'031', N'63', N'Karen')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63032', N'032', N'63', N'Voi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63034', N'034', N'63', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63035', N'035', N'63', N'Diamond Plaza')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63036', N'036', N'63', N'Cross Roads')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'63050', N'050', N'63', N'Tom Mboya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66000', N'000', N'66', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66001', N'001', N'66', N'Naivasha Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66002', N'002', N'66', N'Moi Avenue -Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66003', N'003', N'66', N'Kenyatta Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66004', N'004', N'66', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66005', N'005', N'66', N'Nyeri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66007', N'007', N'66', N'Embu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66008', N'008', N'66', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66009', N'009', N'66', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66010', N'010', N'66', N'Kericho')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66011', N'011', N'66', N'Kangemi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66012', N'012', N'66', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66013', N'013', N'66', N'Kerugoya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66014', N'014', N'66', N'Kenyatta Mkt')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66015', N'015', N'66', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66016', N'016', N'66', N'Chuka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66017', N'017', N'66', N'Kitui')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66018', N'018', N'66', N'Machakos')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66019', N'019', N'66', N'Nanyuki')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66021', N'021', N'66', N'Emali')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66022', N'022', N'66', N'Naivasha')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66023', N'023', N'66', N'Nyahururu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66024', N'024', N'66', N'Isiolo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66025', N'025', N'66', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66026', N'026', N'66', N'Kitale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66027', N'027', N'66', N'Kibwezi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66028', N'028', N'66', N'Bungoma')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66031', N'031', N'66', N'Mtwapa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66033', N'033', N'66', N'Moi Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66034', N'034', N'66', N'Mwea')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66035', N'035', N'66', N'Kengeleni')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'66036', N'036', N'66', N'Kilimani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68000', N'000', N'68', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68001', N'001', N'68', N'Corporate')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68002', N'002', N'68', N'Fourways')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68003', N'003', N'68', N'Kangema')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68004', N'004', N'68', N'Karatina')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68006', N'006', N'68', N'Muraradia')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68007', N'007', N'68', N'Kangari')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68008', N'008', N'68', N'Othaya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68009', N'009', N'68', N'Thika Plaza')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68010', N'010', N'68', N'Kerugoya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68011', N'011', N'68', N'Nyeri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68012', N'012', N'68', N'Tom Mboya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68013', N'013', N'68', N'Nakuru Gatehouse Gate Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68014', N'014', N'68', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68015', N'015', N'68', N'Mama Ngina')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68017', N'017', N'68', N'Community')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68018', N'018', N'68', N'Community Corporate')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68019', N'019', N'68', N'Embu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68020', N'020', N'68', N'Naivasha')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68021', N'021', N'68', N'Chuka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68022', N'022', N'68', N'Murang''a')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68023', N'023', N'68', N'Molo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68024', N'024', N'68', N'Harambee')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68025', N'025', N'68', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68026', N'026', N'68', N'Kimathi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68027', N'027', N'68', N'Nanyuki')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68029', N'029', N'68', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68030', N'030', N'68', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68031', N'031', N'68', N'Nakuru Kenyatta Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68032', N'032', N'68', N'Kariobangi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68033', N'033', N'68', N'Kitale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68034', N'034', N'68', N'Thika Kenyatta Highway')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68035', N'035', N'68', N'Knut Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68036', N'036', N'68', N'Narok')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68037', N'037', N'68', N'Nkubu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68038', N'038', N'68', N'Mwea')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68040', N'040', N'68', N'Maua')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68041', N'041', N'68', N'Isiolo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68042', N'042', N'68', N'Kagio')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68043', N'043', N'68', N'Gikomba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68044', N'044', N'68', N'Ukunda')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68045', N'045', N'68', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68046', N'046', N'68', N'Mombasa Digo Rd Digo Rd')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68047', N'047', N'68', N'Moi Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68048', N'048', N'68', N'Bungoma')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68049', N'049', N'68', N'Kapsabet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68050', N'050', N'68', N'Kakamega')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68052', N'052', N'68', N'Nyamira')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68053', N'053', N'68', N'Litein')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68055', N'055', N'68', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68056', N'056', N'68', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68057', N'057', N'68', N'Kikuyu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68058', N'058', N'68', N'Garissa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68059', N'059', N'68', N'Mwingi')
GO
print 'Processed 600 total records'
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68060', N'060', N'68', N'Machakos')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68061', N'061', N'68', N'Ongata Rongai')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68062', N'062', N'68', N'Ol-Kalou')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68064', N'064', N'68', N'Kiambu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68065', N'065', N'68', N'Kayole')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68066', N'066', N'68', N'Gatundu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68067', N'067', N'68', N'Wote')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68068', N'068', N'68', N'Mumias')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68069', N'069', N'68', N'Limuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68070', N'070', N'68', N'Kitengela')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68071', N'071', N'68', N'Githurai')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68072', N'072', N'68', N'Kitui')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68073', N'073', N'68', N'Ngong')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68074', N'074', N'68', N'Loitoktok')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68076', N'076', N'68', N'Mbita')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68077', N'077', N'68', N'Gilgil')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68078', N'078', N'68', N'Busia')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68079', N'079', N'68', N'Voi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68080', N'080', N'68', N'Enterprise Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68081', N'081', N'68', N'Equity Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68082', N'082', N'68', N'Donholm')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68083', N'083', N'68', N'Mukurwe-ini')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68084', N'084', N'68', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68085', N'085', N'68', N'Namanga')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68088', N'088', N'68', N'OTC')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68089', N'089', N'68', N'Kenol')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68090', N'090', N'68', N'Tala')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68091', N'091', N'68', N'Ngara')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68092', N'092', N'68', N'Nandi Hills')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68093', N'093', N'68', N'Githunguri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68094', N'094', N'68', N'Tea Room')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68095', N'095', N'68', N'Buru Buru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68096', N'096', N'68', N'Mbale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68097', N'097', N'68', N'Siaya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68098', N'098', N'68', N'Homa Bay')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68099', N'099', N'68', N'Lodwar')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68100', N'100', N'68', N'Mandera')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68101', N'101', N'68', N'Marsabit')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68102', N'102', N'68', N'Moyale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68103', N'103', N'68', N'Wajir')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68104', N'104', N'68', N'Meru Makutano')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68105', N'105', N'68', N'Malaba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68106', N'106', N'68', N'Kilifi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68107', N'107', N'68', N'Kapenguria')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68108', N'108', N'68', N'Mombasa Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68110', N'110', N'68', N'Maralal')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68111', N'111', N'68', N'Kimende')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68112', N'112', N'68', N'Luanda')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68113', N'113', N'68', N'KU')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68114', N'114', N'68', N'Kengeleni')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68115', N'115', N'68', N'Nyeri Kimathi Way EK Wachira Bldg')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68116', N'116', N'68', N'Migori')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68117', N'117', N'68', N'Kibera')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68118', N'118', N'68', N'Kasarani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68119', N'119', N'68', N'Mtwapa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68120', N'120', N'68', N'Changamwe')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68122', N'122', N'68', N'Bomet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68123', N'123', N'68', N'Kilgoris')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68124', N'124', N'68', N'Keroka')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68125', N'125', N'68', N'Karen')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68126', N'126', N'68', N'Kisumu Angawa Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68127', N'127', N'68', N'Mpeketoni')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68128', N'128', N'68', N'Nairobi West')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68129', N'129', N'68', N'Kenyatta Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68130', N'130', N'68', N'City Hall')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'68131', N'131', N'68', N'Eldama Ravine')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70000', N'000', N'70', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70001', N'001', N'70', N'Kiambu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70002', N'002', N'70', N'Githunguri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70003', N'003', N'70', N'Sonalux')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70004', N'004', N'70', N'Gatundu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70005', N'005', N'70', N'Thika')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70006', N'006', N'70', N'Murang''a')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70007', N'007', N'70', N'kangari')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70008', N'008', N'70', N'Kiria-ini')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70009', N'009', N'70', N'Kangema')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70011', N'011', N'70', N'Othaya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70014', N'014', N'70', N'Cargen Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70018', N'018', N'70', N'Nakuru Finance')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70019', N'019', N'70', N'Nakuru Njoro Hse')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70021', N'021', N'70', N'Dagoreti')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70023', N'023', N'70', N'Nyahururu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70024', N'024', N'70', N'Ruiru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70025', N'025', N'70', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70026', N'026', N'70', N'Nyamira')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70027', N'027', N'70', N'Kisii')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70031', N'031', N'70', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70033', N'033', N'70', N'Donholm')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70035', N'035', N'70', N'Fourways Retail')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70038', N'038', N'70', N'KTDA Plaza')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70041', N'041', N'70', N'Kariobangi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70042', N'042', N'70', N'Gikomba Area 42')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70043', N'043', N'70', N'Gikomba')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70045', N'045', N'70', N'Githurai')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70046', N'046', N'70', N'Kilimani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70047', N'047', N'70', N'Limuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70049', N'049', N'70', N'Kagwe')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70051', N'051', N'70', N'Banana')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70053', N'053', N'70', N'Naivasha')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70055', N'055', N'70', N'Nyeri')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70057', N'057', N'70', N'Kerugoya')
GO
print 'Processed 700 total records'
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70058', N'058', N'70', N'Tom Mboya')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70059', N'059', N'70', N'River Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70061', N'061', N'70', N'Kayole')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70062', N'062', N'70', N'Nkubu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70063', N'063', N'70', N'Meru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70065', N'065', N'70', N'KTDA Corporate')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70069', N'069', N'70', N'Kitui')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70071', N'071', N'70', N'Kitengela')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70072', N'072', N'70', N'Kitui')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70073', N'073', N'70', N'Machakos')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70075', N'075', N'70', N'Embu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70077', N'077', N'70', N'Bungoma')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70078', N'078', N'70', N'Kakamega')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70079', N'079', N'70', N'Busia')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70083', N'083', N'70', N'Molo')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70085', N'085', N'70', N'Eldoret')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70095', N'095', N'70', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70096', N'096', N'70', N'Kenyatta Avenue,Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'70097', N'097', N'70', N'Kapsabet')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72000', N'000', N'72', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72001', N'001', N'72', N'Central Clearing Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72002', N'002', N'72', N'Upperhill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72003', N'003', N'72', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72004', N'004', N'72', N'Kenyatta Avenue')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72005', N'005', N'72', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72007', N'007', N'72', N'Lamu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72008', N'008', N'72', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72009', N'009', N'72', N'Muthaiga')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'72010', N'010', N'72', N'Bondeni')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74001', N'001', N'74', N'Wabera Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74002', N'002', N'74', N'Eastleigh')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74003', N'003', N'74', N'Mombasa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74004', N'004', N'74', N'Garissa')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74005', N'005', N'74', N'Eastleigh II')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74006', N'006', N'74', N'Malindi')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74007', N'007', N'74', N'Kisumu')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74008', N'008', N'74', N'Kimathi Street')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74009', N'009', N'74', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74010', N'010', N'74', N'South C')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74011', N'011', N'74', N'Industrial Area')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74012', N'012', N'74', N'Masalani')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74013', N'013', N'74', N'Habaswein')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74014', N'014', N'74', N'Wajir')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74015', N'015', N'74', N'Moyale')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74016', N'016', N'74', N'Nakuru')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74017', N'017', N'74', N'Mombasa 11')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'74999', N'999', N'74', N'Head Office/Clearing Centre')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76001', N'001', N'76', N'Westlands')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76002', N'002', N'76', N'Enterprise Road')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76003', N'003', N'76', N'Upper Hill')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'76099', N'099', N'76', N'Head Office')
INSERT [dbo].[gl_BankBranch] ([BankSortCode], [BranchCode], [Bank], [BranchName]) VALUES (N'95000', N'000', N'59', N'Head Office')
/****** Object:  Table [dbo].[gl_AdvancedParametersLoanCycleProperties]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycleProperties]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_AdvancedParametersLoanCycleProperties](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdvancedParametersLoanCycleId] [int] NULL,
	[CycleId] [int] NULL,
	[MinAmount] [decimal](19, 4) NULL,
	[MaxAmount] [decimal](19, 4) NULL,
 CONSTRAINT [PK_gl_AdvancedParametersLoanCycleProperties] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycleProperties]') AND name = N'IX_FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle')
CREATE NONCLUSTERED INDEX [IX_FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle] ON [dbo].[gl_AdvancedParametersLoanCycleProperties] 
(
	[AdvancedParametersLoanCycleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[gl_Accounts]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_Accounts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_Accounts](
	[AccountID] [int] NOT NULL,
	[COA] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[AccountType] [int] NULL,
	[AccountName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountingPeriod] [datetime] NULL,
	[DateofEntry] [datetime] NULL,
	[TimeofEntry] [datetime] NULL,
	[Authorizer] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[GLNumber] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ClearedBalance] [decimal](19, 4) NULL,
	[BookBalance] [decimal](19, 4) NULL,
	[AccruedInterest] [decimal](19, 4) NULL,
	[InterestYTD] [decimal](19, 4) NULL,
	[JointOwnership] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[AccountHistory] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LoanAccountNumber] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PrincipalAmount] [decimal](18, 0) NULL,
	[Annualyield] [decimal](18, 0) NULL,
	[CurrentBalance] [decimal](18, 0) NULL,
	[PayoffAmount] [decimal](18, 0) NULL,
	[Costoffunds] [decimal](18, 0) NULL,
 CONSTRAINT [PK_gl_Accounts] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[COA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[gl_Accounts]') AND name = N'IX_FK_Accounts_Coa')
CREATE NONCLUSTERED INDEX [IX_FK_Accounts_Coa] ON [dbo].[gl_Accounts] 
(
	[COA] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[core_Settings]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[core_Settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[core_Settings](
	[SSKey] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SSValue] [varchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SSValueType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Description] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[SGroup] [int] NOT NULL,
	[SSSystem] [bit] NOT NULL,
 CONSTRAINT [PK_core_Settings] PRIMARY KEY CLUSTERED 
(
	[SSKey] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[core_Settings]') AND name = N'IX_FK_Settings_SettingsGroup')
CREATE NONCLUSTERED INDEX [IX_FK_Settings_SettingsGroup] ON [dbo].[core_Settings] 
(
	[SGroup] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
INSERT [dbo].[core_Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MAXTRIES', N'3', N'N', N'Maximum password retries', 7, 0)
INSERT [dbo].[core_Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'MINAGE', N'18', N'N', N'Minimum employement age', 3, 0)
INSERT [dbo].[core_Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'PWDSIZE', N'5', N'N', N'Password size', 7, 0)
INSERT [dbo].[core_Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'REPORTPATH', N'C:\Program Files\Software Providers\Soft Books iSacco\Reports', N'S', N'Report Output Path', 3, 0)
INSERT [dbo].[core_Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'RESOURCEPATH', N'C:\Program Files\Software Providers\Soft Books iSacco\Resources', N'S', N'Resource Path', 3, 0)
INSERT [dbo].[core_Settings] ([SSKey], [SSValue], [SSValueType], [Description], [SGroup], [SSSystem]) VALUES (N'SBSYSTEMPATH', N'C:\Program Files\Software Providers\Soft Books iSacco\', N'S', N'Systems  file Path', 3, 0)
/****** Object:  Table [dbo].[gl_CollateralProperty]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CollateralProperty]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_CollateralProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CollateralId] [int] NULL,
	[PropertyName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PropertyDescription] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PropertyType] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PropertyValue] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_CollateralProperty] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[gl_CollateralProperty]') AND name = N'IX_FK_gl_CollateralPropertyDetails_gl_Collateral')
CREATE NONCLUSTERED INDEX [IX_FK_gl_CollateralPropertyDetails_gl_Collateral] ON [dbo].[gl_CollateralProperty] 
(
	[CollateralId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[sec_Rights]    Script Date: 04/23/2013 08:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Rights]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sec_Rights](
	[RightId] [int] IDENTITY(1,1) NOT NULL,
	[Role] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Object] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[ObjectType] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Parent] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CanView] [bit] NULL,
	[CanRead] [bit] NULL,
	[CanDelete] [bit] NULL,
	[CanExecute] [bit] NULL,
 CONSTRAINT [PK_sec_Rights] PRIMARY KEY CLUSTERED 
(
	[RightId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sec_Rights]') AND name = N'IX_FK_sec_Rights_sec_Roles')
CREATE NONCLUSTERED INDEX [IX_FK_sec_Rights_sec_Roles] ON [dbo].[sec_Rights] 
(
	[Role] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  Table [dbo].[gl_TransactionTypes]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_TransactionTypes](
	[TransactionTypeId] [int] NOT NULL,
	[DebitCredit] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ShortCode] [nvarchar](5) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Description] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultAmount] [decimal](19, 4) NULL,
	[DefaultCrAccount] [int] NULL,
	[DefaultDrAccount] [int] NULL,
	[DefaultDrNarrative] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[DefaultCrNarrative] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_TransactionTypes] PRIMARY KEY CLUSTERED 
(
	[TransactionTypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
/****** Object:  Table [dbo].[sec_Users]    Script Date: 04/23/2013 08:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sec_Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[sec_Users](
	[UserName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[FirstName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[LastName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Password] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ConfirmPassword] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Email] [nvarchar](100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Role] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Gender] [nchar](1) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Locked] [bit] NULL,
 CONSTRAINT [PK_sec_Users] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[sec_Users]') AND name = N'IX_FK_sec_Users_sec_Roles')
CREATE NONCLUSTERED INDEX [IX_FK_sec_Users_sec_Roles] ON [dbo].[sec_Users] 
(
	[Role] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
INSERT [dbo].[sec_Users] ([UserName], [FirstName], [LastName], [Password], [ConfirmPassword], [Email], [Role], [Gender], [Locked]) VALUES (N'ddffggg', N'daniel', N'kanshizzo', N'12345', N'12345     ', N'dankan@yahoo.com ', N'4', N'F', 0)
INSERT [dbo].[sec_Users] ([UserName], [FirstName], [LastName], [Password], [ConfirmPassword], [Email], [Role], [Gender], [Locked]) VALUES (N'esy', N'esther', N'wambui', N'123', N'123', N'essy@yahoo.com', N'8', N'F', 0)
INSERT [dbo].[sec_Users] ([UserName], [FirstName], [LastName], [Password], [ConfirmPassword], [Email], [Role], [Gender], [Locked]) VALUES (N'grace', N'grace', N'wambua', N'12345', N'12345     ', N'grcemu@gmail.com  ', N'4', N'F', 0)
INSERT [dbo].[sec_Users] ([UserName], [FirstName], [LastName], [Password], [ConfirmPassword], [Email], [Role], [Gender], [Locked]) VALUES (N'james', N'james', N'jomino', N'321', N'321', N'jame@gmail.com', N'4', N'F', 0)
INSERT [dbo].[sec_Users] ([UserName], [FirstName], [LastName], [Password], [ConfirmPassword], [Email], [Role], [Gender], [Locked]) VALUES (N'joj', N'joan      ', N'wanjiku', N'jojo', N'jojo      ', N'jojowan@gmail.com', N'8', N'F', 0)
INSERT [dbo].[sec_Users] ([UserName], [FirstName], [LastName], [Password], [ConfirmPassword], [Email], [Role], [Gender], [Locked]) VALUES (N'sys', N'sys', N'System Administrator', N'sys', N'sys', N'grcemu@gmail.com  ', N'ADMIN', N'M', 0)
/****** Object:  View [dbo].[vwBankBranches]    Script Date: 04/23/2013 08:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwBankBranches]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[vwBankBranches]
AS
SELECT     dbo.gl_Banks.BankName + '' - '' + dbo.gl_BankBranch.BranchName AS BankBranchName, dbo.gl_BankBranch.BankSortCode, dbo.gl_Banks.BankName, dbo.gl_BankBranch.Bank, 
                      dbo.gl_BankBranch.BranchCode, dbo.gl_BankBranch.BranchName, dbo.gl_Banks.BankCode
FROM         dbo.gl_BankBranch INNER JOIN
                      dbo.gl_Banks ON dbo.gl_BankBranch.Bank = dbo.gl_Banks.BankCode
'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'vwBankBranches', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[37] 4[4] 2[25] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "gl_BankBranch"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 181
               Right = 189
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "gl_Banks"
            Begin Extent = 
               Top = 6
               Left = 227
               Bottom = 169
               Right = 378
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 4995
         Width = 2535
         Width = 2415
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwBankBranches'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'vwBankBranches', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'vwBankBranches'
GO
/****** Object:  Table [dbo].[gl_CollateralPropertyCollectionItems]    Script Date: 04/23/2013 08:40:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[gl_CollateralPropertyCollectionItems]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[gl_CollateralPropertyCollectionItems](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CollateralPropertyDetailsId] [int] NULL,
	[CollectionItemName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_gl_CollateralPropertyCollectionItems] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
)
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[gl_CollateralPropertyCollectionItems]') AND name = N'IX_FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails')
CREATE NONCLUSTERED INDEX [IX_FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails] ON [dbo].[gl_CollateralPropertyCollectionItems] 
(
	[CollateralPropertyDetailsId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
GO
/****** Object:  ForeignKey [FK_Settings_SettingsGroup]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[core_Settings]'))
ALTER TABLE [dbo].[core_Settings]  WITH CHECK ADD  CONSTRAINT [FK_Settings_SettingsGroup] FOREIGN KEY([SGroup])
REFERENCES [dbo].[core_SettingsGroup] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]') AND parent_object_id = OBJECT_ID(N'[dbo].[core_Settings]'))
ALTER TABLE [dbo].[core_Settings] CHECK CONSTRAINT [FK_Settings_SettingsGroup]
GO
/****** Object:  ForeignKey [FK_Accounts_Coa]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts]  WITH CHECK ADD  CONSTRAINT [FK_Accounts_Coa] FOREIGN KEY([COA])
REFERENCES [dbo].[gl_Coa] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Accounts_Coa]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_Accounts]'))
ALTER TABLE [dbo].[gl_Accounts] CHECK CONSTRAINT [FK_Accounts_Coa]
GO
/****** Object:  ForeignKey [FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycleProperties]'))
ALTER TABLE [dbo].[gl_AdvancedParametersLoanCycleProperties]  WITH CHECK ADD  CONSTRAINT [FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle] FOREIGN KEY([AdvancedParametersLoanCycleId])
REFERENCES [dbo].[gl_AdvancedParametersLoanCycle] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_AdvancedParametersLoanCycleProperties]'))
ALTER TABLE [dbo].[gl_AdvancedParametersLoanCycleProperties] CHECK CONSTRAINT [FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]
GO
/****** Object:  ForeignKey [FK_BankBranch_Banks]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_BankBranch]'))
ALTER TABLE [dbo].[gl_BankBranch]  WITH CHECK ADD  CONSTRAINT [FK_BankBranch_Banks] FOREIGN KEY([Bank])
REFERENCES [dbo].[gl_Banks] ([BankCode])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_BankBranch]'))
ALTER TABLE [dbo].[gl_BankBranch] CHECK CONSTRAINT [FK_BankBranch_Banks]
GO
/****** Object:  ForeignKey [FK_gl_CollateralPropertyDetails_gl_Collateral]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyDetails_gl_Collateral]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CollateralProperty]'))
ALTER TABLE [dbo].[gl_CollateralProperty]  WITH CHECK ADD  CONSTRAINT [FK_gl_CollateralPropertyDetails_gl_Collateral] FOREIGN KEY([CollateralId])
REFERENCES [dbo].[gl_Collateral] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyDetails_gl_Collateral]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CollateralProperty]'))
ALTER TABLE [dbo].[gl_CollateralProperty] CHECK CONSTRAINT [FK_gl_CollateralPropertyDetails_gl_Collateral]
GO
/****** Object:  ForeignKey [FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CollateralPropertyCollectionItems]'))
ALTER TABLE [dbo].[gl_CollateralPropertyCollectionItems]  WITH CHECK ADD  CONSTRAINT [FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails] FOREIGN KEY([CollateralPropertyDetailsId])
REFERENCES [dbo].[gl_CollateralProperty] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CollateralPropertyCollectionItems]'))
ALTER TABLE [dbo].[gl_CollateralPropertyCollectionItems] CHECK CONSTRAINT [FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]
GO
/****** Object:  ForeignKey [FK_CustomerAccounts_Customers]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAccounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]'))
ALTER TABLE [dbo].[gl_CustomerAccounts]  WITH CHECK ADD  CONSTRAINT [FK_CustomerAccounts_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[gl_Customers] ([CustomerID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_CustomerAccounts_Customers]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_CustomerAccounts]'))
ALTER TABLE [dbo].[gl_CustomerAccounts] CHECK CONSTRAINT [FK_CustomerAccounts_Customers]
GO
/****** Object:  ForeignKey [FK_TransactionTypes_Trasactions]    Script Date: 04/23/2013 08:40:43 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransactionTypes_Trasactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]'))
ALTER TABLE [dbo].[gl_TransactionTypes]  WITH CHECK ADD  CONSTRAINT [FK_TransactionTypes_Trasactions] FOREIGN KEY([TransactionTypeId])
REFERENCES [dbo].[gl_Trasactions] ([TransactionId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TransactionTypes_Trasactions]') AND parent_object_id = OBJECT_ID(N'[dbo].[gl_TransactionTypes]'))
ALTER TABLE [dbo].[gl_TransactionTypes] CHECK CONSTRAINT [FK_TransactionTypes_Trasactions]
GO
/****** Object:  ForeignKey [FK_sec_Rights_sec_Roles]    Script Date: 04/23/2013 08:40:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Rights_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Rights]'))
ALTER TABLE [dbo].[sec_Rights]  WITH CHECK ADD  CONSTRAINT [FK_sec_Rights_sec_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[sec_Roles] ([RoleId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Rights_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Rights]'))
ALTER TABLE [dbo].[sec_Rights] CHECK CONSTRAINT [FK_sec_Rights_sec_Roles]
GO
/****** Object:  ForeignKey [FK_sec_Users_sec_Roles]    Script Date: 04/23/2013 08:40:44 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Users_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Users]'))
ALTER TABLE [dbo].[sec_Users]  WITH CHECK ADD  CONSTRAINT [FK_sec_Users_sec_Roles] FOREIGN KEY([Role])
REFERENCES [dbo].[sec_Roles] ([RoleId])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_sec_Users_sec_Roles]') AND parent_object_id = OBJECT_ID(N'[dbo].[sec_Users]'))
ALTER TABLE [dbo].[sec_Users] CHECK CONSTRAINT [FK_sec_Users_sec_Roles]
GO
