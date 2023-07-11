
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 04/09/2013 08:11:47
-- Generated from EDMX file: D:\DEV\Working\Kevin\Projects\SBISacco\SBSacco\SBSacco\DAL\SBSaccoDBEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SBSaccoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Accounts_Coa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gl_Accounts] DROP CONSTRAINT [FK_Accounts_Coa];
GO
IF OBJECT_ID(N'[dbo].[FK_BankBranch_Banks]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gl_BankBranch] DROP CONSTRAINT [FK_BankBranch_Banks];
GO
IF OBJECT_ID(N'[dbo].[FK_CustomerAccounts_Customers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gl_CustomerAccounts] DROP CONSTRAINT [FK_CustomerAccounts_Customers];
GO
IF OBJECT_ID(N'[dbo].[FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gl_APLoanCycleObjectFields] DROP CONSTRAINT [FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle];
GO
IF OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gl_CollateralPropertyCollectionItems] DROP CONSTRAINT [FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails];
GO
IF OBJECT_ID(N'[dbo].[FK_gl_CollateralPropertyDetails_gl_Collateral]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gl_CollateralProperty] DROP CONSTRAINT [FK_gl_CollateralPropertyDetails_gl_Collateral];
GO
IF OBJECT_ID(N'[dbo].[FK_sec_Rights_sec_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sec_Rights] DROP CONSTRAINT [FK_sec_Rights_sec_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_sec_Users_sec_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[sec_Users] DROP CONSTRAINT [FK_sec_Users_sec_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[core_Settings] DROP CONSTRAINT [FK_Settings_SettingsGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_TransactionTypes_Trasactions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[gl_TransactionTypes] DROP CONSTRAINT [FK_TransactionTypes_Trasactions];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Commands]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Commands];
GO
IF OBJECT_ID(N'[dbo].[core_Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[core_Settings];
GO
IF OBJECT_ID(N'[dbo].[core_SettingsGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[core_SettingsGroup];
GO
IF OBJECT_ID(N'[dbo].[gl_Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Accounts];
GO
IF OBJECT_ID(N'[dbo].[gl_APLoanCycle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_APLoanCycle];
GO
IF OBJECT_ID(N'[dbo].[gl_APLoanCycleObjectFields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_APLoanCycleObjectFields];
GO
IF OBJECT_ID(N'[dbo].[gl_BankBranch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_BankBranch];
GO
IF OBJECT_ID(N'[dbo].[gl_Banks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Banks];
GO
IF OBJECT_ID(N'[dbo].[gl_Coa]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Coa];
GO
IF OBJECT_ID(N'[dbo].[CollateralProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollateralProduct];
GO
IF OBJECT_ID(N'[dbo].[gl_CollateralProperty]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_CollateralProperty];
GO
IF OBJECT_ID(N'[dbo].[gl_CollateralPropertyCollectionItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_CollateralPropertyCollectionItems];
GO
IF OBJECT_ID(N'[dbo].[gl_Corporate]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Corporate];
GO
IF OBJECT_ID(N'[dbo].[gl_Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Currencies];
GO
IF OBJECT_ID(N'[dbo].[gl_CustomerAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_CustomerAccounts];
GO
IF OBJECT_ID(N'[dbo].[gl_Customers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Customers];
GO
IF OBJECT_ID(N'[dbo].[gl_APLoanCycleObjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_APLoanCycleObjects];
GO
IF OBJECT_ID(N'[dbo].[gl_CycleParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_CycleParameters];
GO
IF OBJECT_ID(N'[dbo].[gl_Cycles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Cycles];
GO
IF OBJECT_ID(N'[dbo].[gl_Documents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Documents];
GO
IF OBJECT_ID(N'[dbo].[DomainOfApplication]', 'U') IS NOT NULL
    DROP TABLE [dbo].[DomainOfApplication];
GO
IF OBJECT_ID(N'[dbo].[gl_EntryFees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_EntryFees];
GO
IF OBJECT_ID(N'[dbo].[gl_ExchangeRates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_ExchangeRates];
GO
IF OBJECT_ID(N'[dbo].[gl_FundingLineEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_FundingLineEvents];
GO
IF OBJECT_ID(N'[dbo].[FundingLine]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FundingLine];
GO
IF OBJECT_ID(N'[dbo].[gl_Guarantee]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Guarantee];
GO
IF OBJECT_ID(N'[dbo].[gl_InstallmentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_InstallmentTypes];
GO
IF OBJECT_ID(N'[dbo].[Package]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Package];
GO
IF OBJECT_ID(N'[dbo].[gl_NonSolidarityGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_NonSolidarityGroup];
GO
IF OBJECT_ID(N'[dbo].[Person]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Person];
GO
IF OBJECT_ID(N'[dbo].[SavingProduct]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingProduct];
GO
IF OBJECT_ID(N'[dbo].[gl_SBServer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_SBServer];
GO
IF OBJECT_ID(N'[dbo].[gl_SolidarityGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_SolidarityGroup];
GO
IF OBJECT_ID(N'[dbo].[StandardBooking]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StandardBooking];
GO
IF OBJECT_ID(N'[dbo].[gl_TransactionTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_TransactionTypes];
GO
IF OBJECT_ID(N'[dbo].[gl_Trasactions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[gl_Trasactions];
GO
IF OBJECT_ID(N'[dbo].[sec_Rights]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sec_Rights];
GO
IF OBJECT_ID(N'[dbo].[sec_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sec_Roles];
GO
IF OBJECT_ID(N'[dbo].[sec_Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sec_Users];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[vwBankBranches]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[vwBankBranches];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Commands'
CREATE TABLE [dbo].[Commands] (
    [CommanId] nvarchar(50)  NOT NULL,
    [AssemblyPath] nvarchar(300)  NULL,
    [Class] nvarchar(50)  NULL,
    [Method] nvarchar(300)  NULL
);
GO

-- Creating table 'core_Settings'
CREATE TABLE [dbo].[core_Settings] (
    [SSKey] varchar(20)  NOT NULL,
    [SSValue] varchar(max)  NOT NULL,
    [SSValueType] varchar(50)  NOT NULL,
    [Description] varchar(50)  NOT NULL,
    [SGroup] int  NOT NULL,
    [SSSystem] bit  NOT NULL
);
GO

-- Creating table 'core_SettingsGroup'
CREATE TABLE [dbo].[core_SettingsGroup] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupName] varchar(50)  NOT NULL,
    [Parent] int  NOT NULL
);
GO

-- Creating table 'gl_Accounts'
CREATE TABLE [dbo].[gl_Accounts] (
    [AccountID] int  NOT NULL,
    [COA] nvarchar(20)  NOT NULL,
    [AccountType] int  NULL,
    [AccountName] varchar(50)  NULL,
    [AccountingPeriod] datetime  NULL,
    [DateofEntry] datetime  NULL,
    [TimeofEntry] datetime  NULL,
    [Authorizer] varchar(50)  NULL,
    [GLNumber] varchar(50)  NULL,
    [ClearedBalance] decimal(19,4)  NULL,
    [BookBalance] decimal(19,4)  NULL,
    [AccruedInterest] decimal(19,4)  NULL,
    [InterestYTD] decimal(19,4)  NULL,
    [JointOwnership] varchar(50)  NULL,
    [AccountHistory] varchar(50)  NULL,
    [LoanType] varchar(50)  NULL,
    [LoanAccountNumber] varchar(50)  NULL,
    [PrincipalAmount] decimal(18,0)  NULL,
    [Annualyield] decimal(18,0)  NULL,
    [CurrentBalance] decimal(18,0)  NULL,
    [PayoffAmount] decimal(18,0)  NULL,
    [Costoffunds] decimal(18,0)  NULL
);
GO

-- Creating table 'gl_APLoanCycle'
CREATE TABLE [dbo].[gl_APLoanCycle] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoanCycleName] nvarchar(50)  NULL,
    [LoanId] int  NULL
);
GO

-- Creating table 'gl_APLoanCycleObjectFields'
CREATE TABLE [dbo].[gl_APLoanCycleObjectFields] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdvancedParametersLoanCycleId] int  NULL,
    [CycleId] int  NULL,
    [MinAmount] decimal(19,4)  NULL,
    [MaxAmount] decimal(19,4)  NULL
);
GO

-- Creating table 'gl_BankBranch'
CREATE TABLE [dbo].[gl_BankBranch] (
    [BankSortCode] nvarchar(50)  NOT NULL,
    [BranchCode] nvarchar(50)  NOT NULL,
    [Bank] nvarchar(50)  NOT NULL,
    [BranchName] varchar(50)  NOT NULL
);
GO

-- Creating table 'gl_Banks'
CREATE TABLE [dbo].[gl_Banks] (
    [BankCode] nvarchar(50)  NOT NULL,
    [BankName] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'gl_Coa'
CREATE TABLE [dbo].[gl_Coa] (
    [Id] nvarchar(20)  NOT NULL,
    [Description] nchar(30)  NOT NULL,
    [Level] int  NOT NULL,
    [Parent] nvarchar(20)  NOT NULL,
    [Rorder] int  NOT NULL
);
GO

-- Creating table 'CollateralProduct'
CREATE TABLE [dbo].[CollateralProduct] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [cProductName] nvarchar(50)  NULL,
    [cProductDescription] nvarchar(550)  NULL,
    [cPropertyName] nvarchar(50)  NULL,
    [cPropertyDescription] nvarchar(50)  NULL,
    [cPropertyType] nvarchar(50)  NULL,
    [cCollectionItemName] nvarchar(50)  NULL
);
GO

-- Creating table 'gl_CollateralProperty'
CREATE TABLE [dbo].[gl_CollateralProperty] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CollateralId] int  NULL,
    [PropertyName] nvarchar(50)  NULL,
    [PropertyDescription] nvarchar(50)  NULL,
    [PropertyType] nvarchar(50)  NULL,
    [PropertyValue] nvarchar(50)  NULL
);
GO

-- Creating table 'gl_CollateralPropertyCollectionItems'
CREATE TABLE [dbo].[gl_CollateralPropertyCollectionItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CollateralPropertyDetailsId] int  NULL,
    [CollectionItemName] nvarchar(50)  NULL
);
GO

-- Creating table 'gl_Corporate'
CREATE TABLE [dbo].[gl_Corporate] (
    [CorporateID] int IDENTITY(1,1) NOT NULL,
    [CorporateName] nvarchar(50)  NULL,
    [CreationDate] datetime  NULL,
    [ShortName] nvarchar(50)  NULL,
    [CorporateCycle] nvarchar(50)  NULL,
    [CorporateBranch] nvarchar(100)  NULL,
    [CorporatePhoto] nvarchar(500)  NULL,
    [cProvince] nvarchar(50)  NULL,
    [cDistrict] nvarchar(50)  NULL,
    [cCity] nvarchar(50)  NULL,
    [cAddress] nvarchar(50)  NULL,
    [cZipCode] nvarchar(50)  NULL,
    [cHomeType] nvarchar(50)  NULL,
    [cBusinessPhone] nvarchar(50)  NULL,
    [cEmail] nvarchar(50)  NULL,
    [ContactName] nvarchar(50)  NULL,
    [ContactPosition] nvarchar(50)  NULL,
    [ContactPhone] nvarchar(50)  NULL,
    [CompanyIDNo] nvarchar(50)  NULL,
    [AgreementDate] datetime  NULL,
    [CorporateEconomicActivity] nvarchar(50)  NULL,
    [LegalForm] nvarchar(50)  NULL,
    [InsertionType] nvarchar(50)  NULL,
    [NumberofEmployees] nvarchar(50)  NULL,
    [NumberofVolunteers] nvarchar(50)  NULL,
    [FiscalStatus] nvarchar(50)  NULL,
    [Affiliation] nvarchar(50)  NULL,
    [ProjectId] nvarchar(50)  NULL,
    [ProjectName] nvarchar(50)  NULL,
    [ProjectCode] nvarchar(50)  NULL,
    [NoofContracts] nvarchar(50)  NULL,
    [CorporateFirstContactDate] datetime  NULL,
    [CorporateSourceofKnowHow] nvarchar(50)  NULL,
    [CorporateSponsor] nvarchar(50)  NULL,
    [Comment] nvarchar(50)  NULL,
    [TypeofCompany] nvarchar(50)  NULL,
    [DocumentName] nvarchar(50)  NULL,
    [DocumentFile] nvarchar(50)  NULL,
    [DocumentUser] nvarchar(50)  NULL,
    [DocumentDate] datetime  NULL,
    [DocumentComment] nvarchar(50)  NULL
);
GO

-- Creating table 'gl_Currencies'
CREATE TABLE [dbo].[gl_Currencies] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CurrencyName] nvarchar(50)  NULL,
    [CurrencyCode] nvarchar(50)  NULL,
    [UseCents] bit  NULL
);
GO

-- Creating table 'gl_CustomerAccounts'
CREATE TABLE [dbo].[gl_CustomerAccounts] (
    [CustomerId] int  NOT NULL,
    [AccountId] int  NOT NULL,
    [Mandate] nchar(10)  NULL
);
GO

-- Creating table 'gl_Customers'
CREATE TABLE [dbo].[gl_Customers] (
    [CustomerID] int IDENTITY(1,1) NOT NULL,
    [NationalID] nvarchar(50)  NULL,
    [BusinessLicenseNo] nvarchar(50)  NULL,
    [DrivingLicenseNo] nvarchar(50)  NULL,
    [TaxID] nvarchar(50)  NULL,
    [PIN] nvarchar(50)  NULL,
    [ShortName] nvarchar(50)  NULL,
    [FirstName] nvarchar(50)  NULL,
    [SecondName] nvarchar(50)  NULL,
    [ThirdName] nvarchar(50)  NULL,
    [Surname] nvarchar(50)  NULL,
    [AlternativesName] nvarchar(50)  NULL,
    [PostalAddress] nvarchar(50)  NULL,
    [StreetAddress1A] nvarchar(50)  NULL,
    [StreetAddress1B] nvarchar(50)  NULL,
    [StreetAddress1C] nvarchar(50)  NULL,
    [streetAddress1D] nvarchar(50)  NULL,
    [City1] nvarchar(50)  NULL,
    [Province] nvarchar(50)  NULL,
    [Country] nvarchar(50)  NULL,
    [District] nvarchar(50)  NULL,
    [Postalcode] nvarchar(50)  NULL,
    [Address] nvarchar(50)  NULL,
    [CountryCode] nvarchar(50)  NULL,
    [AreaCode] nvarchar(50)  NULL,
    [TelephoneType] nvarchar(50)  NULL,
    [Phone] nvarchar(50)  NULL,
    [Email] nvarchar(50)  NULL,
    [EmailType] nvarchar(50)  NULL,
    [Telex] varchar(50)  NULL,
    [Customertype1] varchar(50)  NULL,
    [CustomerType2] varchar(50)  NULL,
    [CustomerType3] varchar(50)  NULL,
    [SICTypeCode] int  NULL,
    [OtherTypeCodes] int  NULL,
    [Branch] varchar(50)  NULL,
    [ProductUsageReason] varchar(850)  NULL,
    [CampaignResponse] varchar(50)  NULL,
    [CorporateCycle] varchar(50)  NULL,
    [CustomerReferral] varchar(50)  NULL,
    [PrimaryAccountOfficer] varchar(50)  NULL,
    [SecondaryAccountOfficer] varchar(50)  NULL,
    [OfficerReferral] varchar(50)  NULL,
    [OtherAccountOfficers] varchar(50)  NULL,
    [SwiftSwift] varchar(50)  NULL,
    [CHCode1] int  NULL,
    [CHCode2] int  NULL,
    [CHCode3] int  NULL,
    [CorrespondenceType] varchar(50)  NULL,
    [CorrespondenceHold] varchar(50)  NULL,
    [AddressToUse] varchar(50)  NULL,
    [Salutation] varchar(50)  NULL,
    [IntraSaccoingIndicator] varchar(50)  NULL,
    [IntrasaccoingPassword] varchar(50)  NULL,
    [IntraSaccoingPin] varchar(50)  NULL,
    [InternetSaccoing] varchar(50)  NULL,
    [InternetPasser] varchar(50)  NULL,
    [InternetPin] varchar(50)  NULL,
    [ATMNo] varchar(50)  NULL,
    [ATMPin] varchar(50)  NULL,
    [HomeSaccoing] varchar(50)  NULL,
    [PhoneSaccoingPin] varchar(50)  NULL,
    [OtherDeliveryData] varchar(50)  NULL,
    [TypeOfEmployment] varchar(50)  NULL,
    [Employer] int  NULL,
    [EmployerAddress] varchar(50)  NULL,
    [YearsEmployed] int  NULL,
    [AnnualSalary] decimal(19,4)  NULL,
    [Title] varchar(50)  NULL,
    [OccupationDate] datetime  NULL,
    [EmploymentStatus] varchar(50)  NULL,
    [OccupationType] varchar(50)  NULL,
    [ForeignID] varchar(50)  NULL,
    [Citizenship] varchar(50)  NULL,
    [NetWorth] decimal(19,4)  NULL,
    [Gender] varchar(50)  NULL,
    [EducationLevel] varchar(50)  NULL,
    [CertificationDate] datetime  NULL,
    [BirthDay] datetime  NULL,
    [Spouse] varchar(50)  NULL,
    [NumberofDependants] int  NULL,
    [Ages] datetime  NULL,
    [AgeGroup] varchar(50)  NULL,
    [HousingOwnershipType] varchar(50)  NULL,
    [YearsInHome] int  NULL,
    [OutstandingMortgage] decimal(18,0)  NULL,
    [Language] varchar(50)  NULL,
    [Religion] varchar(50)  NULL,
    [DeathNotificationDate] datetime  NULL,
    [DeathDay] datetime  NULL,
    [CompanyLicense] varchar(50)  NULL,
    [AnnualSales] decimal(18,0)  NULL,
    [SignatoryRestriction] decimal(18,0)  NULL,
    [IncorporationDate] datetime  NULL,
    [NumberofEmployees] int  NULL,
    [Relationships] varchar(50)  NULL,
    [CreditRating] varchar(50)  NULL,
    [GeographicArea] varchar(50)  NULL,
    [DebtLevelSegment] varchar(50)  NULL,
    [DebtLevelDate] datetime  NULL,
    [BusinessAgeSegment] varchar(50)  NULL,
    [BusinessAgeDate] datetime  NULL,
    [RevenueSegment] varchar(50)  NULL,
    [RevenueSegmentDate] datetime  NULL,
    [EmployeeCountSegment] varchar(50)  NULL,
    [EmployeeCountSegmDate] datetime  NULL,
    [GrowthRateSegment] varchar(50)  NULL,
    [GrowthRateSegmentDate] datetime  NULL,
    [CapitalizationSegment] varchar(50)  NULL,
    [CapitalizationSegmentDate] datetime  NULL,
    [ProfitabilitySegment] varchar(50)  NULL,
    [ProfitabilitySegmentDate] datetime  NULL,
    [LifeCycleStatus] varchar(50)  NULL,
    [EstablishDate] datetime  NULL,
    [DissolvedDate] datetime  NULL,
    [DebtClassSegment] varchar(50)  NULL,
    [CustomerGradeSegment] varchar(50)  NULL,
    [LongTermDebtToFinanceRatio] int  NULL,
    [DebtToEquityRatio] int  NULL,
    [AssetTurnOver] decimal(19,4)  NULL,
    [PriceRatio] int  NULL,
    [EarnPerShare] decimal(19,4)  NULL,
    [ReturnOnEquity] decimal(19,4)  NULL,
    [ReturnOnNetTotalAssets] decimal(19,4)  NULL,
    [ReturnOnTotalAssets] decimal(19,4)  NULL,
    [ReturnOnCapitalEmployed] decimal(19,4)  NULL,
    [AnnualSaleRevenue] decimal(19,4)  NULL,
    [AnnualPreTaxProfit] decimal(19,4)  NULL,
    [CapitalandReserves] decimal(19,4)  NULL,
    [TotalBorrowing] decimal(19,4)  NULL,
    [CurrentAssets] decimal(19,4)  NULL,
    [FixedAssets] decimal(19,4)  NULL,
    [DepositAccountNo] varchar(50)  NULL,
    [Count] int  NULL,
    [Amount] decimal(19,4)  NULL,
    [InterestYTD] decimal(19,4)  NULL,
    [JointOwnership] varchar(50)  NULL,
    [DepositHistory] varchar(50)  NULL,
    [LineAmount] decimal(19,4)  NULL,
    [BalanceOutstanding] decimal(19,4)  NULL,
    [InterestRate] int  NULL,
    [CreditAvailable] decimal(19,4)  NULL,
    [CreditCardInterestYTD] decimal(19,4)  NULL,
    [LateFees] decimal(19,4)  NULL,
    [DueDate] datetime  NULL,
    [CreditInfo] varchar(50)  NULL,
    [CredidcardHistory] varchar(50)  NULL,
    [LoanAccNo] varchar(50)  NULL,
    [OriginalLoan] decimal(19,4)  NULL,
    [PrincipalAmount] decimal(19,4)  NULL,
    [AnnualYield] varchar(50)  NULL,
    [AccruedInterest] decimal(19,4)  NULL,
    [CurrentBalance] decimal(19,4)  NULL,
    [PayOffAmount] decimal(19,4)  NULL,
    [LoanAccountHistory] varchar(50)  NULL,
    [PrincipalPaid] decimal(19,4)  NULL,
    [InterestPaid] decimal(19,4)  NULL,
    [CostofFunds] decimal(19,4)  NULL,
    [SourceofFunds] varchar(50)  NULL
);
GO

-- Creating table 'gl_APLoanCycleObjects'
CREATE TABLE [dbo].[gl_APLoanCycleObjects] (
    [CycleObjectId] int IDENTITY(1,1) NOT NULL,
    [CycleObjectName] nvarchar(150)  NULL
);
GO

-- Creating table 'gl_CycleParameters'
CREATE TABLE [dbo].[gl_CycleParameters] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoanCycle] int  NULL,
    [CycleObjectId] int  NULL,
    [CycleId] int  NULL,
    [Min] decimal(19,4)  NULL,
    [Max] decimal(19,4)  NULL
);
GO

-- Creating table 'gl_Cycles'
CREATE TABLE [dbo].[gl_Cycles] (
    [CycleId] int IDENTITY(1,1) NOT NULL,
    [CycleName] nvarchar(200)  NULL
);
GO

-- Creating table 'gl_Documents'
CREATE TABLE [dbo].[gl_Documents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [OwnerObject] nvarchar(50)  NULL,
    [DocName] nvarchar(50)  NULL,
    [DocFileName] nvarchar(50)  NULL,
    [DocFilePath] nvarchar(1000)  NULL,
    [DocFileSize] float  NULL,
    [DocFileType] nvarchar(50)  NULL,
    [dUser] nvarchar(50)  NULL,
    [Comment] nvarchar(550)  NULL,
    [UploadDate] nvarchar(50)  NULL
);
GO

-- Creating table 'DomainOfApplication'
CREATE TABLE [dbo].[DomainOfApplication] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ActivityName] nvarchar(50)  NULL,
    [Parent_Id] int  NULL
);
GO

-- Creating table 'gl_EntryFees'
CREATE TABLE [dbo].[gl_EntryFees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LoanProductId] int  NULL,
    [NameofEntryFee] nvarchar(150)  NULL,
    [MinEntryFees] decimal(19,4)  NULL,
    [MaxEntryFees] decimal(19,4)  NULL,
    [ValueEntryFees] decimal(19,4)  NULL,
    [RateEntryFees] bit  NULL,
    [IsDeleted] bit  NULL,
    [FeeIndex] int  NULL,
    [CycleId] int  NULL
);
GO

-- Creating table 'gl_ExchangeRates'
CREATE TABLE [dbo].[gl_ExchangeRates] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Exchange_Rate] float  NULL,
    [CurrencyId] int  NULL,
    [ExchangeDate] datetime  NULL
);
GO

-- Creating table 'gl_FundingLineEvents'
CREATE TABLE [dbo].[gl_FundingLineEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FundingLineId] int  NULL,
    [FundingLineEventCode] nvarchar(50)  NULL,
    [CreationDate] datetime  NULL,
    [Amount] decimal(19,4)  NULL,
    [Direction] nvarchar(50)  NULL,
    [Type] nvarchar(50)  NULL
);
GO

-- Creating table 'FundingLine'
CREATE TABLE [dbo].[FundingLine] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [FundingLineCode] nvarchar(50)  NULL,
    [Currency] nvarchar(50)  NULL,
    [BeginDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [InitialAmount] decimal(19,4)  NULL,
    [RealReminder] decimal(19,4)  NULL,
    [AnticipatedReminder] decimal(19,4)  NULL
);
GO

-- Creating table 'gl_Guarantee'
CREATE TABLE [dbo].[gl_Guarantee] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [gProductName] nvarchar(50)  NULL,
    [gProductAllClientType] bit  NULL,
    [gProductGroupClientType] bit  NULL,
    [gProductIndividualClientType] bit  NULL,
    [gProductCorporateClientType] bit  NULL,
    [gProductFundingLine] nvarchar(50)  NULL,
    [gProductCurrency] nvarchar(50)  NULL,
    [gMinAmounttobeGuaranteed] decimal(19,4)  NULL,
    [gMaxAmounttobeGuaranteed] decimal(19,4)  NULL,
    [gValueAmounttobeGuaranteed] decimal(19,4)  NULL,
    [gMinGuaranteeAmount] decimal(19,4)  NULL,
    [gMaxGuaranteeAmount] decimal(19,4)  NULL,
    [gValueGuaranteeAmount] decimal(19,4)  NULL,
    [gMinFeePercentage] int  NULL,
    [gMaxFeePercentage] int  NULL,
    [gValueFeePercentage] int  NULL
);
GO

-- Creating table 'gl_InstallmentTypes'
CREATE TABLE [dbo].[gl_InstallmentTypes] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [InstallmentName] varchar(50)  NULL,
    [NumberofMonths] int  NULL,
    [NumberofDays] int  NULL
);
GO

-- Creating table 'Package'
CREATE TABLE [dbo].[Package] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [lProductName] nvarchar(50)  NULL,
    [lProductCode] nvarchar(50)  NULL,
    [lInstallmentType] nvarchar(50)  NULL,
    [lProductAllClientType] bit  NULL,
    [lProductNonSolidarityGroupClientType] bit  NULL,
    [lProductSolidarityGroupClientType] bit  NULL,
    [lProductIndividualClientType] bit  NULL,
    [lProductCorporateClientType] bit  NULL,
    [lRoundingType] nvarchar(50)  NULL,
    [lProductFundingLine] nvarchar(50)  NULL,
    [lProductCurrency] nvarchar(50)  NULL,
    [lInterestRateType] nvarchar(50)  NULL,
    [lChargeInterestOverGracePeriod] nvarchar(50)  NULL,
    [lMinGracePeriod] int  NULL,
    [lMaxGracePeriod] int  NULL,
    [lValueGracePeriod] int  NULL,
    [lMinAmount] decimal(19,4)  NULL,
    [lMaxAmount] decimal(19,4)  NULL,
    [lValueAmount] decimal(19,4)  NULL,
    [lMinInterestRate] int  NULL,
    [lMaxInterestRate] int  NULL,
    [lValueInterestRate] int  NULL,
    [lMinNumberofInstallments] int  NULL,
    [lMaxNumberofInstallments] int  NULL,
    [lValueNumberofInstallments] int  NULL,
    [lUseLoanCycleAdvancedParameters] bit  NULL,
    [lLoanCycleAdvancedParameters] nvarchar(50)  NULL,
    [lAdvancedParametersCycleObject] nvarchar(50)  NULL,
    [lUseLoanCycleEntryFees] bit  NULL,
    [lLoanCycleEntryFees] nvarchar(50)  NULL,
    [lMinLateFeesonTotalLoanAmount] int  NULL,
    [lMaxLateFeesonTotalLoanAmount] int  NULL,
    [lValueLateFeesonTotalLoanAmount] int  NULL,
    [lMinLateFeesonOLB] int  NULL,
    [lMaxLateFeesonOLB] int  NULL,
    [lValueLateFeesonOLB] int  NULL,
    [lMinLateFeesonOverduePrincipal] int  NULL,
    [lMaxLateFeesonOverduePrincipal] int  NULL,
    [lValueLateFeesonOverduePrincipal] int  NULL,
    [lMinLateFeesonOverdueInterest] int  NULL,
    [lMaxLateFeesonOverdueInterest] int  NULL,
    [lValueLateFeesonOverdueInterest] int  NULL,
    [lGracePeriodofLateFees] int  NULL,
    [lMinATRFees] int  NULL,
    [lMaxATRFees] int  NULL,
    [lValueATRFees] int  NULL,
    [lBaseforATRFees] nvarchar(50)  NULL,
    [lMinAPRFees] int  NULL,
    [lMaxAPRFees] int  NULL,
    [lValueAPRFees] int  NULL,
    [lBaseforAPRFees] nvarchar(50)  NULL,
    [lUseExoticInstallments] bit  NULL,
    [lExoticInstallment] nvarchar(50)  NULL,
    [lAllowFlexibleSchedule] bit  NULL,
    [lFakePackage] bit  NULL,
    [lUseLineofCredit] bit  NULL,
    [lNoofDrawingsunderLOC] int  NULL,
    [lMinAmountunderLOC] decimal(19,4)  NULL,
    [lMaxAmountunderLOC] decimal(19,4)  NULL,
    [lValueAmountunderLOC] decimal(19,4)  NULL,
    [lMinTrancheMaturity] int  NULL,
    [lMaxTrancheMaturity] int  NULL,
    [lValueTrancheMaturity] int  NULL,
    [lUseGuarantorsandCollaterals] bit  NULL,
    [lMinPercentageofGuarantorsandCollaterals] int  NULL,
    [lSetSeparateValuesforGuarantorsandCollaterals] bit  NULL,
    [lMinPercentageforGuarantors] int  NULL,
    [lMinPercentageforCollaterals] int  NULL,
    [lUseCompulsorySavings] bit  NULL,
    [lCompulsorySavingsAmountType] nvarchar(50)  NULL,
    [lMinCompulsorySavingsAmount] decimal(19,4)  NULL,
    [lMaxCompulsorySavingsAmount] decimal(19,4)  NULL,
    [lValueCompulsorySavingsAmount] decimal(19,4)  NULL,
    [lMinCreditInsurance] decimal(19,4)  NULL,
    [lMaxCreditInsurance] decimal(19,4)  NULL
);
GO

-- Creating table 'gl_NonSolidarityGroup'
CREATE TABLE [dbo].[gl_NonSolidarityGroup] (
    [NonSolidarityGroupID] int IDENTITY(1,1) NOT NULL,
    [nGroupName] nvarchar(50)  NULL,
    [nDateofEstablishment] datetime  NULL,
    [nGroupOfficer] nvarchar(50)  NULL,
    [nMeetingDate] nvarchar(50)  NULL,
    [nSetMeetingDate] bit  NULL,
    [nBranch] nvarchar(50)  NULL,
    [nPhoto] nvarchar(500)  NULL,
    [nProvince] nvarchar(50)  NULL,
    [nDistrict] nvarchar(50)  NULL,
    [nCity] nvarchar(50)  NULL,
    [nAddress] nvarchar(50)  NULL,
    [nZipCode] nvarchar(50)  NULL
);
GO

-- Creating table 'Person'
CREATE TABLE [dbo].[Person] (
    [PersonID] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [DateofBirth] datetime  NULL,
    [Gender] nvarchar(50)  NULL,
    [IDNo] nvarchar(50)  NULL,
    [PersonEconomicActivity] nvarchar(50)  NULL,
    [LoanCycle] nvarchar(50)  NULL,
    [HeadofHouseHold] bit  NULL,
    [PlaceofBirth] nvarchar(50)  NULL,
    [FatherName] nvarchar(50)  NULL,
    [CitizenShip] nvarchar(50)  NULL,
    [pBranch] nvarchar(50)  NULL,
    [pPhoto] nvarchar(500)  NULL,
    [pHomeProvince] nvarchar(50)  NULL,
    [pHomeDistrict] nvarchar(50)  NULL,
    [pHomeCity] nvarchar(50)  NULL,
    [pHomeAddress] nvarchar(50)  NULL,
    [pHomeZipCode] nvarchar(50)  NULL,
    [pHomeHomeType] nvarchar(50)  NULL,
    [pHomePhone] nvarchar(50)  NULL,
    [pHomeCellPhone] nvarchar(50)  NULL,
    [pHomeEmail] nvarchar(50)  NULL,
    [pBusinessProvince] nvarchar(50)  NULL,
    [pBusinessDistrict] nvarchar(50)  NULL,
    [pBusinessCity] nvarchar(50)  NULL,
    [pBusinessAddress] nvarchar(50)  NULL,
    [pBusinessZipCode] nvarchar(50)  NULL,
    [pBusinessHomeType] nvarchar(50)  NULL,
    [pBusinessPhone] nvarchar(50)  NULL,
    [pBusinessCellPhone] nvarchar(50)  NULL,
    [pBusinessEmail] nvarchar(50)  NULL,
    [PersonalBankAddress] nvarchar(50)  NULL,
    [PersonalBankName] nvarchar(50)  NULL,
    [BusinessBankAddress] nvarchar(50)  NULL,
    [BusinessBankName] nvarchar(50)  NULL,
    [FinancialStatusBankName] nvarchar(50)  NULL,
    [MonthlyHouseHoldIncome] decimal(19,4)  NULL,
    [MonthlyHouseHoldExpenditure] decimal(19,4)  NULL,
    [MonthlyDisposalIncome] decimal(19,4)  NULL,
    [IsBadClient] bit  NULL,
    [BadClientComment] nvarchar(50)  NULL,
    [OtherMicrofinanceLoansName] nvarchar(50)  NULL,
    [OtherMicrofinanceLoansAmount] decimal(19,4)  NULL,
    [OtherMicrofinanceLoansDebts] decimal(19,4)  NULL,
    [OtherMicrofinanceLoansComment] nvarchar(50)  NULL,
    [ProfessionalSituation] nvarchar(50)  NULL,
    [ProfessionalExperience] nvarchar(50)  NULL,
    [StudyLevel] nvarchar(50)  NULL,
    [HousingSituation] nvarchar(50)  NULL,
    [FamilySituation] nvarchar(50)  NULL,
    [PublicBenefits] nvarchar(50)  NULL,
    [NoofDependents] int  NULL,
    [SocialSecurityNo] nvarchar(50)  NULL,
    [MonthsofUnemployment] int  NULL,
    [ChildrenEducation] nvarchar(50)  NULL,
    [EconomicEducation] nvarchar(50)  NULL,
    [SocialParticipation] nvarchar(50)  NULL,
    [HealthSituation] nvarchar(50)  NULL,
    [YearsofExperienceinBusiness] int  NULL,
    [NoofPeopleinthisActivity] int  NULL,
    [OwnHouse] bit  NULL,
    [LandPlot] bit  NULL,
    [Livestock] bit  NULL,
    [Equipments] nvarchar(50)  NULL,
    [MemberofGroupName] nvarchar(50)  NULL,
    [GroupType] nvarchar(50)  NULL,
    [EstablishmentDate] datetime  NULL,
    [JoinedDate] datetime  NULL,
    [LeftDate] datetime  NULL,
    [PersonFirstContactDate] datetime  NULL,
    [DateofFirstAppointment] datetime  NULL,
    [PersonSourceofKnowHow] nvarchar(50)  NULL,
    [PersonSponsor] nvarchar(50)  NULL,
    [FollowupComment] nvarchar(50)  NULL
);
GO

-- Creating table 'SavingProduct'
CREATE TABLE [dbo].[SavingProduct] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [sProductName] nvarchar(100)  NULL,
    [sProductCode] nvarchar(50)  NULL,
    [sProductAllClientType] bit  NULL,
    [sProductNonSolidarityGroupClientType] bit  NULL,
    [sProductSolidarityGroupClientType] bit  NULL,
    [sProductIndividualClientType] bit  NULL,
    [sProductCorporateClientType] bit  NULL,
    [sProductCurrency] nvarchar(50)  NULL,
    [sMinInitialAmount] decimal(19,4)  NULL,
    [sMaxInitialAmount] decimal(19,4)  NULL,
    [sMinBalance] decimal(19,4)  NULL,
    [sMaxBalance] decimal(19,4)  NULL,
    [sMinInterestRate] int  NULL,
    [sMaxInterestRate] int  NULL,
    [sValueInterestRate] int  NULL,
    [sAccrualFrequency] nvarchar(50)  NULL,
    [sPostingFrequency] nvarchar(50)  NULL,
    [sCalculateAmountBasedon] nvarchar(50)  NULL,
    [sTransactionIn] nvarchar(50)  NULL,
    [sMinCashDepositAmount] decimal(19,4)  NULL,
    [sMaxCashDepositAmount] decimal(19,4)  NULL,
    [sCashDepositFeesType] nvarchar(50)  NULL,
    [sMinCashDepositFeesAmount] decimal(19,4)  NULL,
    [sMaxCashDepositFeesAmount] decimal(19,4)  NULL,
    [sValueCashDepositFeesAmount] decimal(19,4)  NULL,
    [sMinWithDrawAmount] decimal(19,4)  NULL,
    [sMaxWithDrawAmount] decimal(19,4)  NULL,
    [sWithDrawFeesType] nvarchar(50)  NULL,
    [sMinWithDrawFees] decimal(19,4)  NULL,
    [sMaxWithDrawFees] decimal(19,4)  NULL,
    [sValueWithDrawFees] decimal(19,4)  NULL,
    [sMinTransferAmount] decimal(19,4)  NULL,
    [sMaxTransferAmount] decimal(19,4)  NULL,
    [sTransferFeesType] nvarchar(50)  NULL,
    [sMinTransferFees] decimal(19,4)  NULL,
    [sMaxTransferFees] decimal(19,4)  NULL,
    [sValueTransferFees] decimal(19,4)  NULL,
    [sTransferType] nvarchar(50)  NULL,
    [sEntryFeesType] nvarchar(50)  NULL,
    [sMinEntryFees] decimal(19,4)  NULL,
    [sMaxEntryFees] decimal(19,4)  NULL,
    [sValueEntryFees] decimal(19,4)  NULL,
    [sReopenFeesType] nvarchar(50)  NULL,
    [sMinReopenFees] decimal(19,4)  NULL,
    [sMaxReopenFees] decimal(19,4)  NULL,
    [sValueReopenFees] decimal(19,4)  NULL,
    [sCloseFeesType] nvarchar(50)  NULL,
    [sMinCloseFees] decimal(19,4)  NULL,
    [sMaxCloseFees] decimal(19,4)  NULL,
    [sValueCloseFees] decimal(19,4)  NULL,
    [sManagementFeesType] nvarchar(50)  NULL,
    [sMinManagementFees] decimal(19,4)  NULL,
    [sMaxManagementFees] decimal(19,4)  NULL,
    [sValueManagementFees] decimal(19,4)  NULL,
    [sManagementFeesPostingFrequency] nvarchar(50)  NULL,
    [sFixedOverDraftFeesType] nvarchar(50)  NULL,
    [sMinFixedOverDraftFees] decimal(19,4)  NULL,
    [sMaxFixedOverDraftFees] decimal(19,4)  NULL,
    [sValueFixedOverDraftFees] decimal(19,4)  NULL,
    [sAgioFeesType] nvarchar(50)  NULL,
    [sMinAgioFees] decimal(19,4)  NULL,
    [sMaxAgioFees] decimal(19,4)  NULL,
    [sValueAgioFees] decimal(19,4)  NULL,
    [sAgioPostingFrequency] nvarchar(50)  NULL,
    [sUseTermDeposit] bit  NULL,
    [sMinTermDepositNoofPeriods] int  NULL,
    [sMaxTermDepositNoofPeriods] int  NULL,
    [sTermDepositPostingFrequency] nvarchar(50)  NULL
);
GO

-- Creating table 'gl_SBServer'
CREATE TABLE [dbo].[gl_SBServer] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Server_Name] nvarchar(50)  NOT NULL,
    [User_Name] nvarchar(50)  NOT NULL,
    [Pass_Word] nvarchar(50)  NOT NULL,
    [Logged_Time] datetime  NOT NULL,
    [Is_Default] bit  NOT NULL
);
GO

-- Creating table 'gl_SolidarityGroup'
CREATE TABLE [dbo].[gl_SolidarityGroup] (
    [SolidarityGroupID] int IDENTITY(1,1) NOT NULL,
    [sGroupName] nvarchar(50)  NULL,
    [sMeetingDate] nvarchar(50)  NULL,
    [sSetMeetingDate] bit  NULL,
    [sDateofEstablishment] datetime  NULL,
    [sGroupOfficer] nvarchar(50)  NULL,
    [sBranch] nvarchar(50)  NULL,
    [sPhoto] nvarchar(500)  NULL,
    [sHomeProvince] nvarchar(50)  NULL,
    [sHomeDistrict] nvarchar(50)  NULL,
    [sHomeCity] nvarchar(50)  NULL,
    [sHomeAddress] nvarchar(50)  NULL,
    [sHomeZipCode] nvarchar(50)  NULL,
    [sHomeType] nvarchar(50)  NULL,
    [sHomePhone] nvarchar(50)  NULL,
    [sHomeCellPhone] nvarchar(50)  NULL,
    [sHomeEmail] nvarchar(50)  NULL,
    [sBusinessProvince] nvarchar(50)  NULL,
    [sBusinessDistrict] nvarchar(50)  NULL,
    [sBusinessCity] nvarchar(50)  NULL,
    [sBusinessAddress] nvarchar(50)  NULL,
    [sBusinessZipCode] nvarchar(50)  NULL,
    [sBusinessHomeType] nvarchar(50)  NULL,
    [sBusinessPhone] nvarchar(50)  NULL,
    [sBusinessCellPhone] nvarchar(50)  NULL,
    [sBusinessEmail] nvarchar(50)  NULL
);
GO

-- Creating table 'StandardBooking'
CREATE TABLE [dbo].[StandardBooking] (
    [ID] int  NOT NULL,
    [Name] varchar(128)  NULL,
    [DebitAccountID] int  NOT NULL,
    [CreditAccountID] int  NOT NULL
);
GO

-- Creating table 'gl_TransactionTypes'
CREATE TABLE [dbo].[gl_TransactionTypes] (
    [TransactionTypeId] int  NOT NULL,
    [DebitCredit] char(1)  NULL,
    [ShortCode] nvarchar(5)  NULL,
    [Description] nvarchar(50)  NULL,
    [DefaultAmount] decimal(19,4)  NULL,
    [DefaultCrAccount] int  NULL,
    [DefaultDrAccount] int  NULL,
    [DefaultDrNarrative] nvarchar(50)  NULL,
    [DefaultCrNarrative] nvarchar(50)  NULL
);
GO

-- Creating table 'gl_Trasactions'
CREATE TABLE [dbo].[gl_Trasactions] (
    [TransactionId] int IDENTITY(1,1) NOT NULL,
    [TrasactionType] int  NOT NULL,
    [AccountId] int  NOT NULL,
    [TransRef] nvarchar(50)  NOT NULL,
    [ContraRef] nvarchar(50)  NOT NULL,
    [Amount] decimal(19,4)  NOT NULL,
    [Narrative1] varchar(50)  NOT NULL,
    [Narrative2] varchar(50)  NULL,
    [UserId] varchar(10)  NOT NULL,
    [Authorizer] varchar(10)  NULL,
    [StatementFlag] varchar(50)  NULL,
    [PostDate] datetime  NOT NULL,
    [ValueDate] datetime  NOT NULL,
    [RecDate] datetime  NOT NULL
);
GO

-- Creating table 'sec_Rights'
CREATE TABLE [dbo].[sec_Rights] (
    [RightId] int IDENTITY(1,1) NOT NULL,
    [Role] nvarchar(50)  NOT NULL,
    [Object] varchar(50)  NOT NULL,
    [ObjectType] varchar(50)  NOT NULL,
    [Parent] varchar(50)  NULL,
    [CanView] bit  NULL,
    [CanRead] bit  NULL,
    [CanDelete] bit  NULL,
    [CanExecute] bit  NULL
);
GO

-- Creating table 'sec_Roles'
CREATE TABLE [dbo].[sec_Roles] (
    [RoleId] nvarchar(50)  NOT NULL,
    [RoleDescription] nvarchar(50)  NULL
);
GO

-- Creating table 'sec_Users'
CREATE TABLE [dbo].[sec_Users] (
    [UserName] nvarchar(50)  NOT NULL,
    [FirstName] nvarchar(50)  NULL,
    [LastName] nvarchar(50)  NULL,
    [Password] nvarchar(50)  NULL,
    [ConfirmPassword] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [Role] nvarchar(50)  NULL,
    [Gender] nchar(1)  NULL,
    [Locked] bit  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'vwBankBranches'
CREATE TABLE [dbo].[vwBankBranches] (
    [BankBranchName] nvarchar(103)  NOT NULL,
    [BankSortCode] nvarchar(50)  NOT NULL,
    [BankName] nvarchar(50)  NOT NULL,
    [Bank] nvarchar(50)  NOT NULL,
    [BranchCode] nvarchar(50)  NOT NULL,
    [BranchName] varchar(50)  NOT NULL,
    [BankCode] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CommanId] in table 'Commands'
ALTER TABLE [dbo].[Commands]
ADD CONSTRAINT [PK_Commands]
    PRIMARY KEY CLUSTERED ([CommanId] ASC);
GO

-- Creating primary key on [SSKey] in table 'core_Settings'
ALTER TABLE [dbo].[core_Settings]
ADD CONSTRAINT [PK_core_Settings]
    PRIMARY KEY CLUSTERED ([SSKey] ASC);
GO

-- Creating primary key on [Id] in table 'core_SettingsGroup'
ALTER TABLE [dbo].[core_SettingsGroup]
ADD CONSTRAINT [PK_core_SettingsGroup]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AccountID], [COA] in table 'gl_Accounts'
ALTER TABLE [dbo].[gl_Accounts]
ADD CONSTRAINT [PK_gl_Accounts]
    PRIMARY KEY CLUSTERED ([AccountID], [COA] ASC);
GO

-- Creating primary key on [Id] in table 'gl_APLoanCycle'
ALTER TABLE [dbo].[gl_APLoanCycle]
ADD CONSTRAINT [PK_gl_AdvancedParametersLoanCycle]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_APLoanCycleObjectFields'
ALTER TABLE [dbo].[gl_APLoanCycleObjectFields]
ADD CONSTRAINT [PK_gl_AdvancedParametersLoanCycleProperties]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [BankSortCode] in table 'gl_BankBranch'
ALTER TABLE [dbo].[gl_BankBranch]
ADD CONSTRAINT [PK_gl_BankBranch]
    PRIMARY KEY CLUSTERED ([BankSortCode] ASC);
GO

-- Creating primary key on [BankCode] in table 'gl_Banks'
ALTER TABLE [dbo].[gl_Banks]
ADD CONSTRAINT [PK_gl_Banks]
    PRIMARY KEY CLUSTERED ([BankCode] ASC);
GO

-- Creating primary key on [Id] in table 'gl_Coa'
ALTER TABLE [dbo].[gl_Coa]
ADD CONSTRAINT [PK_gl_Coa]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CollateralProduct'
ALTER TABLE [dbo].[CollateralProduct]
ADD CONSTRAINT [PK_gl_Collateral]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_CollateralProperty'
ALTER TABLE [dbo].[gl_CollateralProperty]
ADD CONSTRAINT [PK_gl_CollateralProperty]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_CollateralPropertyCollectionItems'
ALTER TABLE [dbo].[gl_CollateralPropertyCollectionItems]
ADD CONSTRAINT [PK_gl_CollateralPropertyCollectionItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CorporateID] in table 'gl_Corporate'
ALTER TABLE [dbo].[gl_Corporate]
ADD CONSTRAINT [PK_gl_Corporate]
    PRIMARY KEY CLUSTERED ([CorporateID] ASC);
GO

-- Creating primary key on [Id] in table 'gl_Currencies'
ALTER TABLE [dbo].[gl_Currencies]
ADD CONSTRAINT [PK_gl_Currencies]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CustomerId], [AccountId] in table 'gl_CustomerAccounts'
ALTER TABLE [dbo].[gl_CustomerAccounts]
ADD CONSTRAINT [PK_gl_CustomerAccounts]
    PRIMARY KEY CLUSTERED ([CustomerId], [AccountId] ASC);
GO

-- Creating primary key on [CustomerID] in table 'gl_Customers'
ALTER TABLE [dbo].[gl_Customers]
ADD CONSTRAINT [PK_gl_Customers]
    PRIMARY KEY CLUSTERED ([CustomerID] ASC);
GO

-- Creating primary key on [CycleObjectId] in table 'gl_APLoanCycleObjects'
ALTER TABLE [dbo].[gl_APLoanCycleObjects]
ADD CONSTRAINT [PK_gl_CycleObjects]
    PRIMARY KEY CLUSTERED ([CycleObjectId] ASC);
GO

-- Creating primary key on [Id] in table 'gl_CycleParameters'
ALTER TABLE [dbo].[gl_CycleParameters]
ADD CONSTRAINT [PK_gl_CycleParameters]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [CycleId] in table 'gl_Cycles'
ALTER TABLE [dbo].[gl_Cycles]
ADD CONSTRAINT [PK_gl_Cycles]
    PRIMARY KEY CLUSTERED ([CycleId] ASC);
GO

-- Creating primary key on [Id] in table 'gl_Documents'
ALTER TABLE [dbo].[gl_Documents]
ADD CONSTRAINT [PK_gl_Documents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DomainOfApplication'
ALTER TABLE [dbo].[DomainOfApplication]
ADD CONSTRAINT [PK_gl_EconomicActivity]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_EntryFees'
ALTER TABLE [dbo].[gl_EntryFees]
ADD CONSTRAINT [PK_gl_EntryFees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_ExchangeRates'
ALTER TABLE [dbo].[gl_ExchangeRates]
ADD CONSTRAINT [PK_gl_ExchangeRates]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_FundingLineEvents'
ALTER TABLE [dbo].[gl_FundingLineEvents]
ADD CONSTRAINT [PK_gl_FundingLineEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FundingLine'
ALTER TABLE [dbo].[FundingLine]
ADD CONSTRAINT [PK_gl_FundingLines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_Guarantee'
ALTER TABLE [dbo].[gl_Guarantee]
ADD CONSTRAINT [PK_gl_Guarantee]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [ID] in table 'gl_InstallmentTypes'
ALTER TABLE [dbo].[gl_InstallmentTypes]
ADD CONSTRAINT [PK_gl_InstallmentTypes]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Id] in table 'Package'
ALTER TABLE [dbo].[Package]
ADD CONSTRAINT [PK_gl_Loans]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [NonSolidarityGroupID] in table 'gl_NonSolidarityGroup'
ALTER TABLE [dbo].[gl_NonSolidarityGroup]
ADD CONSTRAINT [PK_gl_NonSolidarityGroup]
    PRIMARY KEY CLUSTERED ([NonSolidarityGroupID] ASC);
GO

-- Creating primary key on [PersonID] in table 'Person'
ALTER TABLE [dbo].[Person]
ADD CONSTRAINT [PK_gl_Person]
    PRIMARY KEY CLUSTERED ([PersonID] ASC);
GO

-- Creating primary key on [Id] in table 'SavingProduct'
ALTER TABLE [dbo].[SavingProduct]
ADD CONSTRAINT [PK_gl_Savings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'gl_SBServer'
ALTER TABLE [dbo].[gl_SBServer]
ADD CONSTRAINT [PK_gl_SBServer]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [SolidarityGroupID] in table 'gl_SolidarityGroup'
ALTER TABLE [dbo].[gl_SolidarityGroup]
ADD CONSTRAINT [PK_gl_SolidarityGroup]
    PRIMARY KEY CLUSTERED ([SolidarityGroupID] ASC);
GO

-- Creating primary key on [ID] in table 'StandardBooking'
ALTER TABLE [dbo].[StandardBooking]
ADD CONSTRAINT [PK_gl_StandardBookings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [TransactionTypeId] in table 'gl_TransactionTypes'
ALTER TABLE [dbo].[gl_TransactionTypes]
ADD CONSTRAINT [PK_gl_TransactionTypes]
    PRIMARY KEY CLUSTERED ([TransactionTypeId] ASC);
GO

-- Creating primary key on [TransactionId] in table 'gl_Trasactions'
ALTER TABLE [dbo].[gl_Trasactions]
ADD CONSTRAINT [PK_gl_Trasactions]
    PRIMARY KEY CLUSTERED ([TransactionId] ASC);
GO

-- Creating primary key on [RightId] in table 'sec_Rights'
ALTER TABLE [dbo].[sec_Rights]
ADD CONSTRAINT [PK_sec_Rights]
    PRIMARY KEY CLUSTERED ([RightId] ASC);
GO

-- Creating primary key on [RoleId] in table 'sec_Roles'
ALTER TABLE [dbo].[sec_Roles]
ADD CONSTRAINT [PK_sec_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserName] in table 'sec_Users'
ALTER TABLE [dbo].[sec_Users]
ADD CONSTRAINT [PK_sec_Users]
    PRIMARY KEY CLUSTERED ([UserName] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [BankBranchName], [BankSortCode], [BankName], [Bank], [BranchCode], [BranchName], [BankCode] in table 'vwBankBranches'
ALTER TABLE [dbo].[vwBankBranches]
ADD CONSTRAINT [PK_vwBankBranches]
    PRIMARY KEY CLUSTERED ([BankBranchName], [BankSortCode], [BankName], [Bank], [BranchCode], [BranchName], [BankCode] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SGroup] in table 'core_Settings'
ALTER TABLE [dbo].[core_Settings]
ADD CONSTRAINT [FK_Settings_SettingsGroup]
    FOREIGN KEY ([SGroup])
    REFERENCES [dbo].[core_SettingsGroup]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Settings_SettingsGroup'
CREATE INDEX [IX_FK_Settings_SettingsGroup]
ON [dbo].[core_Settings]
    ([SGroup]);
GO

-- Creating foreign key on [COA] in table 'gl_Accounts'
ALTER TABLE [dbo].[gl_Accounts]
ADD CONSTRAINT [FK_Accounts_Coa]
    FOREIGN KEY ([COA])
    REFERENCES [dbo].[gl_Coa]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Accounts_Coa'
CREATE INDEX [IX_FK_Accounts_Coa]
ON [dbo].[gl_Accounts]
    ([COA]);
GO

-- Creating foreign key on [AdvancedParametersLoanCycleId] in table 'gl_APLoanCycleObjectFields'
ALTER TABLE [dbo].[gl_APLoanCycleObjectFields]
ADD CONSTRAINT [FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]
    FOREIGN KEY ([AdvancedParametersLoanCycleId])
    REFERENCES [dbo].[gl_APLoanCycle]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle'
CREATE INDEX [IX_FK_gl_AdvancedParametersLoanCycleProperties_gl_AdvancedParametersLoanCycle]
ON [dbo].[gl_APLoanCycleObjectFields]
    ([AdvancedParametersLoanCycleId]);
GO

-- Creating foreign key on [Bank] in table 'gl_BankBranch'
ALTER TABLE [dbo].[gl_BankBranch]
ADD CONSTRAINT [FK_BankBranch_Banks]
    FOREIGN KEY ([Bank])
    REFERENCES [dbo].[gl_Banks]
        ([BankCode])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_BankBranch_Banks'
CREATE INDEX [IX_FK_BankBranch_Banks]
ON [dbo].[gl_BankBranch]
    ([Bank]);
GO

-- Creating foreign key on [CollateralId] in table 'gl_CollateralProperty'
ALTER TABLE [dbo].[gl_CollateralProperty]
ADD CONSTRAINT [FK_gl_CollateralPropertyDetails_gl_Collateral]
    FOREIGN KEY ([CollateralId])
    REFERENCES [dbo].[CollateralProduct]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_gl_CollateralPropertyDetails_gl_Collateral'
CREATE INDEX [IX_FK_gl_CollateralPropertyDetails_gl_Collateral]
ON [dbo].[gl_CollateralProperty]
    ([CollateralId]);
GO

-- Creating foreign key on [CollateralPropertyDetailsId] in table 'gl_CollateralPropertyCollectionItems'
ALTER TABLE [dbo].[gl_CollateralPropertyCollectionItems]
ADD CONSTRAINT [FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]
    FOREIGN KEY ([CollateralPropertyDetailsId])
    REFERENCES [dbo].[gl_CollateralProperty]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails'
CREATE INDEX [IX_FK_gl_CollateralPropertyCollectionItems_gl_CollateralPropertyDetails]
ON [dbo].[gl_CollateralPropertyCollectionItems]
    ([CollateralPropertyDetailsId]);
GO

-- Creating foreign key on [CustomerId] in table 'gl_CustomerAccounts'
ALTER TABLE [dbo].[gl_CustomerAccounts]
ADD CONSTRAINT [FK_CustomerAccounts_Customers]
    FOREIGN KEY ([CustomerId])
    REFERENCES [dbo].[gl_Customers]
        ([CustomerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TransactionTypeId] in table 'gl_TransactionTypes'
ALTER TABLE [dbo].[gl_TransactionTypes]
ADD CONSTRAINT [FK_TransactionTypes_Trasactions]
    FOREIGN KEY ([TransactionTypeId])
    REFERENCES [dbo].[gl_Trasactions]
        ([TransactionId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Role] in table 'sec_Rights'
ALTER TABLE [dbo].[sec_Rights]
ADD CONSTRAINT [FK_sec_Rights_sec_Roles]
    FOREIGN KEY ([Role])
    REFERENCES [dbo].[sec_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_sec_Rights_sec_Roles'
CREATE INDEX [IX_FK_sec_Rights_sec_Roles]
ON [dbo].[sec_Rights]
    ([Role]);
GO

-- Creating foreign key on [Role] in table 'sec_Users'
ALTER TABLE [dbo].[sec_Users]
ADD CONSTRAINT [FK_sec_Users_sec_Roles]
    FOREIGN KEY ([Role])
    REFERENCES [dbo].[sec_Roles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_sec_Users_sec_Roles'
CREATE INDEX [IX_FK_sec_Users_sec_Roles]
ON [dbo].[sec_Users]
    ([Role]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------