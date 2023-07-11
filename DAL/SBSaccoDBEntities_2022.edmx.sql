
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 11/15/2022 13:10:01
-- Generated from EDMX file: D:\wakxpx\csharp\visualstudio\2010\SBSacco\DAL\SBSaccoDBEntities.edmx
-- --------------------------------------------------

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccountingRules_ChartOfAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountingRules_ChartOfAccounts1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts1];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountingRules_EventAttributes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventAttributes];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountingRules_EventTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvancedFields_AdvancedFieldsEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvancedFields] DROP CONSTRAINT [FK_AdvancedFields_AdvancedFieldsEntities];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvancedFields_AdvancedFieldsTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvancedFields] DROP CONSTRAINT [FK_AdvancedFields_AdvancedFieldsTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvancedFieldsCollections_AdvancedFields]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvancedFieldsCollections] DROP CONSTRAINT [FK_AdvancedFieldsCollections_AdvancedFields];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvancedFieldsValues_AdvancedFields]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvancedFieldsValues] DROP CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFields];
GO
IF OBJECT_ID(N'[dbo].[FK_AdvancedFieldsValues_AdvancedFieldsLinkEntities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvancedFieldsValues] DROP CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFieldsLinkEntities];
GO
IF OBJECT_ID(N'[dbo].[FK_AllowedRoleActions_ActionItems]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedRoleActions] DROP CONSTRAINT [FK_AllowedRoleActions_ActionItems];
GO
IF OBJECT_ID(N'[dbo].[FK_AllowedRoleActions_AllowedRoleActions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedRoleActions] DROP CONSTRAINT [FK_AllowedRoleActions_AllowedRoleActions];
GO
IF OBJECT_ID(N'[dbo].[FK_AllowedRoleActions_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedRoleActions] DROP CONSTRAINT [FK_AllowedRoleActions_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_AllowedRoleMenus_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedRoleMenus] DROP CONSTRAINT [FK_AllowedRoleMenus_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_AmountCycles_Cycles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AmountCycles] DROP CONSTRAINT [FK_AmountCycles_Cycles];
GO
IF OBJECT_ID(N'[dbo].[FK_ChartOfAccounts_AccountsCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ChartOfAccounts] DROP CONSTRAINT [FK_ChartOfAccounts_AccountsCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_City_Districts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK_City_Districts];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_ClientBranchHistory_Branches]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[ClientBranchHistory] DROP CONSTRAINT [FK_ClientBranchHistory_Branches];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_ClientBranchHistory_Tiers]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[ClientBranchHistory] DROP CONSTRAINT [FK_ClientBranchHistory_Tiers];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_ClientBranchHistory_Users]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[ClientBranchHistory] DROP CONSTRAINT [FK_ClientBranchHistory_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_CollateralProperties_CollateralProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollateralProperties] DROP CONSTRAINT [FK_CollateralProperties_CollateralProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_CollateralProperties_CollateralPropertyTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollateralProperties] DROP CONSTRAINT [FK_CollateralProperties_CollateralPropertyTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_CollateralPropertyCollections_CollateralProperties]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollateralPropertyCollections] DROP CONSTRAINT [FK_CollateralPropertyCollections_CollateralProperties];
GO
IF OBJECT_ID(N'[dbo].[FK_CollateralPropertyValues_CollateralProperties]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollateralPropertyValues] DROP CONSTRAINT [FK_CollateralPropertyValues_CollateralProperties];
GO
IF OBJECT_ID(N'[dbo].[FK_CollateralPropertyValues_CollateralsLinkContracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollateralPropertyValues] DROP CONSTRAINT [FK_CollateralPropertyValues_CollateralsLinkContracts];
GO
IF OBJECT_ID(N'[dbo].[FK_CollateralsLinkContracts_Contracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollateralsLinkContracts] DROP CONSTRAINT [FK_CollateralsLinkContracts_Contracts];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_AccountingRules]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_AccountingRules];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_DomainOfApplications]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_DomainOfApplications];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_Packages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_Packages];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractAccountingRules_SavingProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_SavingProducts];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_ContractAssignHistory_Contracts]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[ContractAssignHistory] DROP CONSTRAINT [FK_ContractAssignHistory_Contracts];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_ContractAssignHistory_Users]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[ContractAssignHistory] DROP CONSTRAINT [FK_ContractAssignHistory_Users];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_ContractAssignHistory_Users1]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[ContractAssignHistory] DROP CONSTRAINT [FK_ContractAssignHistory_Users1];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractEvents_Contracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_Contracts];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractEvents_LoanInterestAccruingEvents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_LoanInterestAccruingEvents];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractEvents_Tellers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_Tellers];
GO
IF OBJECT_ID(N'[dbo].[FK_ContractEvents_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Contracts_EconomicActivities]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_Contracts_EconomicActivities];
GO
IF OBJECT_ID(N'[dbo].[FK_Contracts_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_Contracts_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_Contracts_Villages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_Contracts_Villages];
GO
IF OBJECT_ID(N'[dbo].[FK_CorporatePersonBelonging_Corporates]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CorporatePersonBelonging] DROP CONSTRAINT [FK_CorporatePersonBelonging_Corporates];
GO
IF OBJECT_ID(N'[dbo].[FK_CorporatePersonBelonging_Persons]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CorporatePersonBelonging] DROP CONSTRAINT [FK_CorporatePersonBelonging_Persons];
GO
IF OBJECT_ID(N'[dbo].[FK_Corporates_DomainOfApplications]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Corporates] DROP CONSTRAINT [FK_Corporates_DomainOfApplications];
GO
IF OBJECT_ID(N'[dbo].[FK_Credit_Contracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Contracts];
GO
IF OBJECT_ID(N'[dbo].[FK_Credit_InstallmentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_InstallmentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Credit_Packages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Packages];
GO
IF OBJECT_ID(N'[dbo].[FK_Credit_Temp_FundingLines]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Temp_FundingLines];
GO
IF OBJECT_ID(N'[dbo].[FK_Credit_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_CreditEntryFees_Credit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CreditEntryFees] DROP CONSTRAINT [FK_CreditEntryFees_Credit];
GO
IF OBJECT_ID(N'[dbo].[FK_Districts_Provinces]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Districts] DROP CONSTRAINT [FK_Districts_Provinces];
GO
IF OBJECT_ID(N'[dbo].[FK_DomainOfApplications_DomainOfApplications]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EconomicActivities] DROP CONSTRAINT [FK_DomainOfApplications_DomainOfApplications];
GO
IF OBJECT_ID(N'[dbo].[FK_EntryFees_Packages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EntryFees] DROP CONSTRAINT [FK_EntryFees_Packages];
GO
IF OBJECT_ID(N'[dbo].[FK_EventAttributes_EventTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventAttributes] DROP CONSTRAINT [FK_EventAttributes_EventTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_ExoticInstallments_Exotics]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ExoticInstallments] DROP CONSTRAINT [FK_ExoticInstallments_Exotics];
GO
IF OBJECT_ID(N'[dbo].[FK_FundingLineAccountingRules_AccountingRules]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_AccountingRules];
GO
IF OBJECT_ID(N'[dbo].[FK_FundingLineAccountingRules_FundingLine]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_FundingLine];
GO
IF OBJECT_ID(N'[dbo].[FK_FundingLineEvents_FundingLines]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FundingLineEvents] DROP CONSTRAINT [FK_FundingLineEvents_FundingLines];
GO
IF OBJECT_ID(N'[dbo].[FK_FundingLines_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FundingLines] DROP CONSTRAINT [FK_FundingLines_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_Groups_Tiers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_Groups_Tiers];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_InstallmentHistory_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[InstallmentHistory] DROP CONSTRAINT [FK_InstallmentHistory_ContractEvents];
GO
IF OBJECT_ID(N'[dbo].[FK_Installments_Credit]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Installments] DROP CONSTRAINT [FK_Installments_Credit];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_LinkBranchesPaymentMethods_PaymentMethods]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[LinkBranchesPaymentMethods] DROP CONSTRAINT [FK_LinkBranchesPaymentMethods_PaymentMethods];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_LinkGuarantorCredit_Contracts]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[LinkGuarantorCredit] DROP CONSTRAINT [FK_LinkGuarantorCredit_Contracts];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_LinkGuarantorCredit_Tiers]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[LinkGuarantorCredit] DROP CONSTRAINT [FK_LinkGuarantorCredit_Tiers];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_LinkPackagesExotics_Exotics]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[LinkPackagesExotics] DROP CONSTRAINT [FK_LinkPackagesExotics_Exotics];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_LinkPackagesExotics_Packages]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[LinkPackagesExotics] DROP CONSTRAINT [FK_LinkPackagesExotics_Packages];
GO
IF OBJECT_ID(N'[dbo].[FK_LoanAccountingMovements_ChartOfAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_LoanAccountingMovements_ChartOfAccounts1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts1];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_LoanDisbursmentEvents_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[LoanDisbursmentEvents] DROP CONSTRAINT [FK_LoanDisbursmentEvents_ContractEvents];
GO
IF OBJECT_ID(N'[dbo].[FK_LoansLinkSavingsBook_Contracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoansLinkSavingsBook] DROP CONSTRAINT [FK_LoansLinkSavingsBook_Contracts];
GO
IF OBJECT_ID(N'[dbo].[FK_LoansLinkSavingsBook_SavingContracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoansLinkSavingsBook] DROP CONSTRAINT [FK_LoansLinkSavingsBook_SavingContracts];
GO
IF OBJECT_ID(N'[dbo].[FK_ManualAccountingMovements_ChartOfAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_ManualAccountingMovements_ChartOfAccounts1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts1];
GO
IF OBJECT_ID(N'[dbo].[FK_OverdueEvents_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OverdueEvents] DROP CONSTRAINT [FK_OverdueEvents_ContractEvents];
GO
IF OBJECT_ID(N'[dbo].[FK_Packages_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Packages] DROP CONSTRAINT [FK_Packages_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_Packages_Cycles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Packages] DROP CONSTRAINT [FK_Packages_Cycles];
GO
IF OBJECT_ID(N'[dbo].[FK_Packages_InstallmentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Packages] DROP CONSTRAINT [FK_Packages_InstallmentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonGroupBelonging_Persons1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonGroupBelonging] DROP CONSTRAINT [FK_PersonGroupBelonging_Persons1];
GO
IF OBJECT_ID(N'[dbo].[FK_PersonGroupCorrespondance_Groups]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PersonGroupBelonging] DROP CONSTRAINT [FK_PersonGroupCorrespondance_Groups];
GO
IF OBJECT_ID(N'[dbo].[FK_Persons_DomainOfApplications]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_Persons_DomainOfApplications];
GO
IF OBJECT_ID(N'[dbo].[FK_Persons_Tiers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_Persons_Tiers];
GO
IF OBJECT_ID(N'[dbo].[FK_Projects_Tiers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_Projects_Tiers];
GO
IF OBJECT_ID(N'[dbo].[FK_ProvisionEvents_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProvisionEvents] DROP CONSTRAINT [FK_ProvisionEvents_ContractEvents];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_RepaymentEvents_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[RepaymentEvents] DROP CONSTRAINT [FK_RepaymentEvents_ContractEvents];
GO
IF OBJECT_ID(N'[dbo].[FK_ReschedulingOfALoanEvents_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ReschedulingOfALoanEvents] DROP CONSTRAINT [FK_ReschedulingOfALoanEvents_ContractEvents];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingBookContract_SavingContracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingBookContracts] DROP CONSTRAINT [FK_SavingBookContract_SavingContracts];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingBookProducts_SavingProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingBookProducts] DROP CONSTRAINT [FK_SavingBookProducts_SavingProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingContracts_Tiers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingContracts] DROP CONSTRAINT [FK_SavingContracts_Tiers];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingContracts_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingContracts] DROP CONSTRAINT [FK_SavingContracts_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingDepositContract_SavingContracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingDepositContracts] DROP CONSTRAINT [FK_SavingDepositContract_SavingContracts];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingEvents_SavingContracts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingEvents] DROP CONSTRAINT [FK_SavingEvents_SavingContracts];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingEvents_Tellers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingEvents] DROP CONSTRAINT [FK_SavingEvents_Tellers];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingEvents_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingEvents] DROP CONSTRAINT [FK_SavingEvents_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingProducts_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingProducts] DROP CONSTRAINT [FK_SavingProducts_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_Savings_SavingProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingContracts] DROP CONSTRAINT [FK_Savings_SavingProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingsAccountingMovements_ChartOfAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_SavingsAccountingMovements_ChartOfAccounts1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts1];
GO
IF OBJECT_ID(N'[dbo].[FK_Settings_SettingsGroup]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Settings] DROP CONSTRAINT [FK_Settings_SettingsGroup];
GO
IF OBJECT_ID(N'[dbo].[FK_StandardBookings_ChartOfAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_StandardBookings_ChartOfAccounts1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts1];
GO
IF OBJECT_ID(N'[dbo].[FK_TellerEvents_Tellers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TellerEvents] DROP CONSTRAINT [FK_TellerEvents_Tellers];
GO
IF OBJECT_ID(N'[dbo].[FK_TellerEvents_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TellerEvents] DROP CONSTRAINT [FK_TellerEvents_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Tellers_Branches]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tellers] DROP CONSTRAINT [FK_Tellers_Branches];
GO
IF OBJECT_ID(N'[dbo].[FK_Tellers_ChartOfAccounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tellers] DROP CONSTRAINT [FK_Tellers_ChartOfAccounts];
GO
IF OBJECT_ID(N'[dbo].[FK_Tellers_Currencies]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tellers] DROP CONSTRAINT [FK_Tellers_Currencies];
GO
IF OBJECT_ID(N'[dbo].[FK_TermDepositProducts_InstallmentTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TermDepositProducts] DROP CONSTRAINT [FK_TermDepositProducts_InstallmentTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_TermDepositProducts_SavingProducts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TermDepositProducts] DROP CONSTRAINT [FK_TermDepositProducts_SavingProducts];
GO
IF OBJECT_ID(N'[dbo].[FK_TrancheEvents_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TrancheEvents] DROP CONSTRAINT [FK_TrancheEvents_ContractEvents];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_UserRole_Roles]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[UserRole] DROP CONSTRAINT [FK_UserRole_Roles];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_UserRole_Users]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[UserRole] DROP CONSTRAINT [FK_UserRole_Users];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_UsersBranches_Users]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[UsersBranches] DROP CONSTRAINT [FK_UsersBranches_Users];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[FK_UsersSubordinates_Users]', 'F') IS NOT NULL
    ALTER TABLE [SBSaccoDBModelStoreContainer].[UsersSubordinates] DROP CONSTRAINT [FK_UsersSubordinates_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_Villages_Users]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Villages] DROP CONSTRAINT [FK_Villages_Users];
GO
IF OBJECT_ID(N'[dbo].[FK_VillagesAttendance_Villages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VillagesAttendance] DROP CONSTRAINT [FK_VillagesAttendance_Villages];
GO
IF OBJECT_ID(N'[dbo].[FK_VillagesPersons_Villages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[VillagesPersons] DROP CONSTRAINT [FK_VillagesPersons_Villages];
GO
IF OBJECT_ID(N'[dbo].[FK_WriteOffEvents_ContractEvents]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WriteOffEvents] DROP CONSTRAINT [FK_WriteOffEvents_ContractEvents];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountingClosure]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountingClosure];
GO
IF OBJECT_ID(N'[dbo].[AccountingRules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountingRules];
GO
IF OBJECT_ID(N'[dbo].[AccountsCategory]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountsCategory];
GO
IF OBJECT_ID(N'[dbo].[ActionItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActionItems];
GO
IF OBJECT_ID(N'[dbo].[AdvancedFields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvancedFields];
GO
IF OBJECT_ID(N'[dbo].[AdvancedFieldsCollections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvancedFieldsCollections];
GO
IF OBJECT_ID(N'[dbo].[AdvancedFieldsEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvancedFieldsEntities];
GO
IF OBJECT_ID(N'[dbo].[AdvancedFieldsLinkEntities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvancedFieldsLinkEntities];
GO
IF OBJECT_ID(N'[dbo].[AdvancedFieldsTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvancedFieldsTypes];
GO
IF OBJECT_ID(N'[dbo].[AdvancedFieldsValues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvancedFieldsValues];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[AlertSettings]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[AlertSettings];
GO
IF OBJECT_ID(N'[dbo].[AllowedRoleActions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AllowedRoleActions];
GO
IF OBJECT_ID(N'[dbo].[AllowedRoleMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AllowedRoleMenus];
GO
IF OBJECT_ID(N'[dbo].[AmountCycles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AmountCycles];
GO
IF OBJECT_ID(N'[dbo].[Branches]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Branches];
GO
IF OBJECT_ID(N'[dbo].[ChartOfAccounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ChartOfAccounts];
GO
IF OBJECT_ID(N'[dbo].[City]', 'U') IS NOT NULL
    DROP TABLE [dbo].[City];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[ClientBranchHistory]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[ClientBranchHistory];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[ClientTypes]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[ClientTypes];
GO
IF OBJECT_ID(N'[dbo].[CollateralProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollateralProducts];
GO
IF OBJECT_ID(N'[dbo].[CollateralProperties]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollateralProperties];
GO
IF OBJECT_ID(N'[dbo].[CollateralPropertyCollections]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollateralPropertyCollections];
GO
IF OBJECT_ID(N'[dbo].[CollateralPropertyTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollateralPropertyTypes];
GO
IF OBJECT_ID(N'[dbo].[CollateralPropertyValues]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollateralPropertyValues];
GO
IF OBJECT_ID(N'[dbo].[CollateralsLinkContracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollateralsLinkContracts];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[ConsolidatedData]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[ConsolidatedData];
GO
IF OBJECT_ID(N'[dbo].[ContractAccountingRules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractAccountingRules];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[ContractAssignHistory]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[ContractAssignHistory];
GO
IF OBJECT_ID(N'[dbo].[ContractEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ContractEvents];
GO
IF OBJECT_ID(N'[dbo].[Contracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contracts];
GO
IF OBJECT_ID(N'[dbo].[CorporatePersonBelonging]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CorporatePersonBelonging];
GO
IF OBJECT_ID(N'[dbo].[Corporates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Corporates];
GO
IF OBJECT_ID(N'[dbo].[Credit]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Credit];
GO
IF OBJECT_ID(N'[dbo].[CreditEntryFees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CreditEntryFees];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[CreditInsuranceEvents]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[CreditInsuranceEvents];
GO
IF OBJECT_ID(N'[dbo].[Currencies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Currencies];
GO
IF OBJECT_ID(N'[dbo].[CycleObjects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CycleObjects];
GO
IF OBJECT_ID(N'[dbo].[CycleParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CycleParameters];
GO
IF OBJECT_ID(N'[dbo].[Cycles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cycles];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Districts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Districts];
GO
IF OBJECT_ID(N'[dbo].[EconomicActivities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EconomicActivities];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[EconomicActivityLoanHistory]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[EconomicActivityLoanHistory];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Employers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employers];
GO
IF OBJECT_ID(N'[dbo].[EntryFees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EntryFees];
GO
IF OBJECT_ID(N'[dbo].[EventAttributes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventAttributes];
GO
IF OBJECT_ID(N'[dbo].[EventTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventTypes];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[ExchangeRates]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[ExchangeRates];
GO
IF OBJECT_ID(N'[dbo].[ExoticInstallments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExoticInstallments];
GO
IF OBJECT_ID(N'[dbo].[Exotics]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exotics];
GO
IF OBJECT_ID(N'[dbo].[FiscalYear]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FiscalYear];
GO
IF OBJECT_ID(N'[dbo].[FundingLineAccountingRules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FundingLineAccountingRules];
GO
IF OBJECT_ID(N'[dbo].[FundingLineEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FundingLineEvents];
GO
IF OBJECT_ID(N'[dbo].[FundingLines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FundingLines];
GO
IF OBJECT_ID(N'[dbo].[GeneralParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GeneralParameters];
GO
IF OBJECT_ID(N'[dbo].[Groups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Groups];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[InstallmentHistory]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[InstallmentHistory];
GO
IF OBJECT_ID(N'[dbo].[Installments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Installments];
GO
IF OBJECT_ID(N'[dbo].[InstallmentTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InstallmentTypes];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[LinkBranchesPaymentMethods]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[LinkBranchesPaymentMethods];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[LinkGuarantorCredit]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[LinkGuarantorCredit];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[LinkPackagesExotics]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[LinkPackagesExotics];
GO
IF OBJECT_ID(N'[dbo].[LoanAccountingMovements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoanAccountingMovements];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[LoanDisbursmentEvents]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[LoanDisbursmentEvents];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[LoanEntryFeeEvents]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[LoanEntryFeeEvents];
GO
IF OBJECT_ID(N'[dbo].[LoanInterestAccruingEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoanInterestAccruingEvents];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[LoanScale]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[LoanScale];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[LoanShareAmounts]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[LoanShareAmounts];
GO
IF OBJECT_ID(N'[dbo].[LoansLinkSavingsBook]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoansLinkSavingsBook];
GO
IF OBJECT_ID(N'[dbo].[ManualAccountingMovements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManualAccountingMovements];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[MenuItems]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[MenuItems];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Monitoring]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Monitoring];
GO
IF OBJECT_ID(N'[dbo].[OverdueEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OverdueEvents];
GO
IF OBJECT_ID(N'[dbo].[Packages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Packages];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[PackagesClientTypes]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[PackagesClientTypes];
GO
IF OBJECT_ID(N'[dbo].[PaymentMethods]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PaymentMethods];
GO
IF OBJECT_ID(N'[dbo].[PersonGroupBelonging]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PersonGroupBelonging];
GO
IF OBJECT_ID(N'[dbo].[Persons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Persons];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[PersonsPhotos]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[PersonsPhotos];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[Provinces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Provinces];
GO
IF OBJECT_ID(N'[dbo].[ProvisionEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProvisionEvents];
GO
IF OBJECT_ID(N'[dbo].[ProvisioningRules]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProvisioningRules];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[PublicHolidays]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[PublicHolidays];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Questionnaire]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Questionnaire];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Rep_Active_Loans_Data]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Rep_Active_Loans_Data];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Rep_Disbursements_Data]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Rep_Disbursements_Data];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Rep_OLB_and_LLP_Data]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Rep_OLB_and_LLP_Data];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Rep_Par_Analysis_Data]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Rep_Par_Analysis_Data];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Rep_Repayments_Data]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Rep_Repayments_Data];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Rep_Rescheduled_Loans_Data]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Rep_Rescheduled_Loans_Data];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[RepaymentEvents]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[RepaymentEvents];
GO
IF OBJECT_ID(N'[dbo].[ReschedulingOfALoanEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ReschedulingOfALoanEvents];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[SavingBookContracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingBookContracts];
GO
IF OBJECT_ID(N'[dbo].[SavingBookProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingBookProducts];
GO
IF OBJECT_ID(N'[dbo].[SavingContracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingContracts];
GO
IF OBJECT_ID(N'[dbo].[SavingDepositContracts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingDepositContracts];
GO
IF OBJECT_ID(N'[dbo].[SavingEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingEvents];
GO
IF OBJECT_ID(N'[dbo].[SavingProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingProducts];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[SavingProductsClientTypes]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[SavingProductsClientTypes];
GO
IF OBJECT_ID(N'[dbo].[SavingsAccountingMovements]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SavingsAccountingMovements];
GO
IF OBJECT_ID(N'[dbo].[Settings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Settings];
GO
IF OBJECT_ID(N'[dbo].[SettingsGroup]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SettingsGroup];
GO
IF OBJECT_ID(N'[dbo].[SmsMessageStore]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SmsMessageStore];
GO
IF OBJECT_ID(N'[dbo].[spAllowedReportsRolesMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spAllowedReportsRolesMenus];
GO
IF OBJECT_ID(N'[dbo].[spAllowedRoleMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spAllowedRoleMenus];
GO
IF OBJECT_ID(N'[dbo].[spAllowedRoleMenusweb]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spAllowedRoleMenusweb];
GO
IF OBJECT_ID(N'[dbo].[spMenuItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spMenuItems];
GO
IF OBJECT_ID(N'[dbo].[spMenus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spMenus];
GO
IF OBJECT_ID(N'[dbo].[spReportsMenuItems]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spReportsMenuItems];
GO
IF OBJECT_ID(N'[dbo].[spRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spRoles];
GO
IF OBJECT_ID(N'[dbo].[spUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spUsers];
GO
IF OBJECT_ID(N'[dbo].[spUsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[spUsersInRoles];
GO
IF OBJECT_ID(N'[dbo].[StandardBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StandardBookings];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Statuses]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Statuses];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[TechnicalParameters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TechnicalParameters];
GO
IF OBJECT_ID(N'[dbo].[TechParams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TechParams];
GO
IF OBJECT_ID(N'[dbo].[TellerEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TellerEvents];
GO
IF OBJECT_ID(N'[dbo].[Tellers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tellers];
GO
IF OBJECT_ID(N'[dbo].[TermDepositProducts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TermDepositProducts];
GO
IF OBJECT_ID(N'[dbo].[Tiers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tiers];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[TraceUserLogs]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[TraceUserLogs];
GO
IF OBJECT_ID(N'[dbo].[TrancheEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrancheEvents];
GO
IF OBJECT_ID(N'[dbo].[TransactionsAuthorizations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TransactionsAuthorizations];
GO
IF OBJECT_ID(N'[dbo].[UserProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserProfile];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[UserRole]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[UserRole];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[UsersBranches]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[UsersBranches];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[UsersSubordinates]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[UsersSubordinates];
GO
IF OBJECT_ID(N'[dbo].[Villages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Villages];
GO
IF OBJECT_ID(N'[dbo].[VillagesAttendance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VillagesAttendance];
GO
IF OBJECT_ID(N'[dbo].[VillagesPersons]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VillagesPersons];
GO
IF OBJECT_ID(N'[dbo].[webpages_Membership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Membership];
GO
IF OBJECT_ID(N'[dbo].[webpages_OAuthMembership]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_OAuthMembership];
GO
IF OBJECT_ID(N'[dbo].[webpages_Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_Roles];
GO
IF OBJECT_ID(N'[dbo].[webpages_UsersInRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[webpages_UsersInRoles];
GO
IF OBJECT_ID(N'[dbo].[WriteOffEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WriteOffEvents];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[Clients]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[Clients];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[View_1]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[View_1];
GO
IF OBJECT_ID(N'[SBSaccoDBModelStoreContainer].[vwExportTransactions]', 'U') IS NOT NULL
    DROP TABLE [SBSaccoDBModelStoreContainer].[vwExportTransactions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountingClosures'
CREATE TABLE [dbo].[AccountingClosures] (
    [id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [date_of_closure] datetime  NOT NULL,
    [count_of_transactions] int  NOT NULL,
    [is_deleted] bit  NULL
);
GO

-- Creating table 'AccountingRules'
CREATE TABLE [dbo].[AccountingRules] (
    [id] int IDENTITY(1,1) NOT NULL,
    [rule_type] char(1)  NOT NULL,
    [deleted] bit  NOT NULL,
    [booking_direction] smallint  NOT NULL,
    [event_type] nvarchar(4)  NOT NULL,
    [event_attribute_id] int  NOT NULL,
    [debit_account_number_id] int  NOT NULL,
    [credit_account_number_id] int  NOT NULL,
    [order] int  NOT NULL,
    [description] nvarchar(256)  NULL
);
GO

-- Creating table 'AccountsCategories'
CREATE TABLE [dbo].[AccountsCategories] (
    [id] smallint IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'ActionItems'
CREATE TABLE [dbo].[ActionItems] (
    [id] int IDENTITY(1,1) NOT NULL,
    [class_name] nvarchar(50)  NOT NULL,
    [method_name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AdvancedFields'
CREATE TABLE [dbo].[AdvancedFields] (
    [id] int IDENTITY(1,1) NOT NULL,
    [entity_id] int  NOT NULL,
    [type_id] int  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [desc] nvarchar(1000)  NOT NULL,
    [is_mandatory] bit  NOT NULL,
    [is_unique] bit  NOT NULL
);
GO

-- Creating table 'AdvancedFieldsCollections'
CREATE TABLE [dbo].[AdvancedFieldsCollections] (
    [id] int IDENTITY(1,1) NOT NULL,
    [field_id] int  NOT NULL,
    [value] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'AdvancedFieldsEntities'
CREATE TABLE [dbo].[AdvancedFieldsEntities] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AdvancedFieldsLinkEntities'
CREATE TABLE [dbo].[AdvancedFieldsLinkEntities] (
    [id] int IDENTITY(1,1) NOT NULL,
    [link_type] char(1)  NOT NULL,
    [link_id] int  NOT NULL
);
GO

-- Creating table 'AdvancedFieldsTypes'
CREATE TABLE [dbo].[AdvancedFieldsTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'AdvancedFieldsValues'
CREATE TABLE [dbo].[AdvancedFieldsValues] (
    [id] int IDENTITY(1,1) NOT NULL,
    [entity_field_id] int  NOT NULL,
    [field_id] int  NOT NULL,
    [value] nvarchar(300)  NULL
);
GO

-- Creating table 'AlertSettings'
CREATE TABLE [dbo].[AlertSettings] (
    [parameter] nvarchar(20)  NOT NULL,
    [value] nvarchar(5)  NOT NULL
);
GO

-- Creating table 'AllowedRoleActions'
CREATE TABLE [dbo].[AllowedRoleActions] (
    [action_item_id] int  NOT NULL,
    [role_id] int  NOT NULL,
    [allowed] bit  NOT NULL
);
GO

-- Creating table 'AllowedRoleMenus'
CREATE TABLE [dbo].[AllowedRoleMenus] (
    [menu_item_id] int  NOT NULL,
    [role_id] int  NOT NULL,
    [allowed] bit  NOT NULL
);
GO

-- Creating table 'AmountCycles'
CREATE TABLE [dbo].[AmountCycles] (
    [cycle_id] int  NOT NULL,
    [number] int  NOT NULL,
    [amount_min] decimal(19,4)  NOT NULL,
    [amount_max] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Branches'
CREATE TABLE [dbo].[Branches] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NULL,
    [deleted] bit  NOT NULL,
    [code] nvarchar(20)  NULL,
    [address] nvarchar(255)  NULL,
    [description] nvarchar(255)  NULL
);
GO

-- Creating table 'ChartOfAccounts'
CREATE TABLE [dbo].[ChartOfAccounts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [account_number] nvarchar(50)  NOT NULL,
    [label] nvarchar(200)  NOT NULL,
    [debit_plus] bit  NOT NULL,
    [type_code] varchar(60)  NOT NULL,
    [account_category_id] smallint  NOT NULL,
    [type] bit  NOT NULL,
    [parent_account_id] int  NULL,
    [lft] int  NOT NULL,
    [rgt] int  NOT NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [name] nvarchar(100)  NOT NULL,
    [district_id] int  NOT NULL,
    [deleted] bit  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'ClientBranchHistories'
CREATE TABLE [dbo].[ClientBranchHistories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [date_changed] datetime  NULL,
    [branch_from_id] int  NOT NULL,
    [branch_to_id] int  NOT NULL,
    [client_id] int  NOT NULL,
    [user_id] int  NOT NULL
);
GO

-- Creating table 'ClientTypes'
CREATE TABLE [dbo].[ClientTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [type_name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'CollateralProducts'
CREATE TABLE [dbo].[CollateralProducts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [desc] nvarchar(1000)  NOT NULL,
    [deleted] bit  NOT NULL
);
GO

-- Creating table 'CollateralProperties'
CREATE TABLE [dbo].[CollateralProperties] (
    [id] int IDENTITY(1,1) NOT NULL,
    [product_id] int  NOT NULL,
    [type_id] int  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [desc] nvarchar(1000)  NOT NULL
);
GO

-- Creating table 'CollateralPropertyCollections'
CREATE TABLE [dbo].[CollateralPropertyCollections] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [property_id] int  NOT NULL,
    [value] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'CollateralPropertyTypes'
CREATE TABLE [dbo].[CollateralPropertyTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(30)  NOT NULL
);
GO

-- Creating table 'CollateralPropertyValues'
CREATE TABLE [dbo].[CollateralPropertyValues] (
    [id] int IDENTITY(1,1) NOT NULL,
    [contract_collateral_id] int  NOT NULL,
    [property_id] int  NOT NULL,
    [value] nvarchar(1000)  NULL
);
GO

-- Creating table 'CollateralsLinkContracts'
CREATE TABLE [dbo].[CollateralsLinkContracts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [contract_id] int  NOT NULL
);
GO

-- Creating table 'ConsolidatedDatas'
CREATE TABLE [dbo].[ConsolidatedDatas] (
    [branch] nvarchar(20)  NOT NULL,
    [date] datetime  NOT NULL,
    [olb] decimal(19,4)  NULL,
    [par] decimal(19,4)  NULL,
    [number_of_clients] int  NULL,
    [number_of_contracts] int  NULL,
    [disbursements_amount] decimal(19,4)  NULL,
    [disbursements_fees] decimal(19,4)  NULL,
    [repayments_principal] decimal(19,4)  NULL,
    [repayments_interest] decimal(19,4)  NULL,
    [repayments_commissions] decimal(19,4)  NULL,
    [repayments_penalties] decimal(19,4)  NULL
);
GO

-- Creating table 'ContractAccountingRules'
CREATE TABLE [dbo].[ContractAccountingRules] (
    [id] int  NOT NULL,
    [product_type] smallint  NOT NULL,
    [loan_product_id] int  NULL,
    [savings_product_id] int  NULL,
    [client_type] char(1)  NOT NULL,
    [activity_id] int  NULL,
    [currency_id] int  NULL
);
GO

-- Creating table 'ContractAssignHistories'
CREATE TABLE [dbo].[ContractAssignHistories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [DateChanged] datetime  NOT NULL,
    [loanofficerFrom_id] int  NOT NULL,
    [loanofficerTo_id] int  NOT NULL,
    [contract_id] int  NOT NULL
);
GO

-- Creating table 'ContractEvents'
CREATE TABLE [dbo].[ContractEvents] (
    [id] int IDENTITY(1,1) NOT NULL,
    [event_type] nvarchar(4)  NOT NULL,
    [contract_id] int  NOT NULL,
    [event_date] datetime  NOT NULL,
    [user_id] int  NOT NULL,
    [is_deleted] bit  NOT NULL,
    [entry_date] datetime  NULL,
    [is_exported] bit  NOT NULL,
    [comment] nvarchar(4000)  NULL,
    [teller_id] int  NULL,
    [parent_id] int  NULL,
    [cancel_date] datetime  NULL,
    [payment_method_id] int  NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [contract_code] nvarchar(255)  NOT NULL,
    [branch_code] varchar(50)  NOT NULL,
    [creation_date] datetime  NOT NULL,
    [start_date] datetime  NOT NULL,
    [close_date] datetime  NOT NULL,
    [closed] bit  NOT NULL,
    [project_id] int  NOT NULL,
    [status] smallint  NOT NULL,
    [credit_commitee_date] datetime  NULL,
    [credit_commitee_comment] nvarchar(4000)  NULL,
    [credit_commitee_code] nvarchar(100)  NULL,
    [align_disbursed_date] datetime  NULL,
    [loan_purpose] nvarchar(4000)  NULL,
    [comments] nvarchar(4000)  NULL,
    [nsg_id] int  NULL,
    [activity_id] int  NOT NULL,
    [first_installment_date] datetime  NOT NULL
);
GO

-- Creating table 'CorporatePersonBelongings'
CREATE TABLE [dbo].[CorporatePersonBelongings] (
    [corporate_id] int  NOT NULL,
    [person_id] int  NOT NULL,
    [position] nvarchar(50)  NULL
);
GO

-- Creating table 'Corporates'
CREATE TABLE [dbo].[Corporates] (
    [id] int  NOT NULL,
    [name] nvarchar(max)  NOT NULL,
    [deleted] bit  NOT NULL,
    [sigle] nvarchar(50)  NULL,
    [small_name] nvarchar(50)  NULL,
    [volunteer_count] int  NULL,
    [agrement_date] datetime  NULL,
    [agrement_solidarity] bit  NULL,
    [employee_count] int  NULL,
    [siret] nvarchar(50)  NULL,
    [activity_id] int  NULL,
    [date_create] datetime  NULL,
    [fiscal_status] nvarchar(50)  NULL,
    [registre] nvarchar(50)  NULL,
    [legalForm] nvarchar(50)  NULL,
    [insertionType] nvarchar(50)  NULL,
    [loan_officer_id] int  NULL
);
GO

-- Creating table 'Credits'
CREATE TABLE [dbo].[Credits] (
    [id] int  NOT NULL,
    [package_id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [interest_rate] decimal(16,12)  NOT NULL,
    [installment_type] int  NOT NULL,
    [nb_of_installment] int  NOT NULL,
    [anticipated_total_repayment_penalties] float  NOT NULL,
    [disbursed] bit  NOT NULL,
    [loanofficer_id] int  NOT NULL,
    [grace_period] int  NULL,
    [written_off] bit  NOT NULL,
    [rescheduled] bit  NOT NULL,
    [bad_loan] bit  NOT NULL,
    [non_repayment_penalties_based_on_overdue_principal] float  NOT NULL,
    [non_repayment_penalties_based_on_initial_amount] float  NOT NULL,
    [non_repayment_penalties_based_on_olb] float  NOT NULL,
    [non_repayment_penalties_based_on_overdue_interest] float  NOT NULL,
    [fundingLine_id] int  NOT NULL,
    [synchronize] bit  NOT NULL,
    [interest] decimal(19,4)  NOT NULL,
    [grace_period_of_latefees] int  NOT NULL,
    [anticipated_partial_repayment_penalties] float  NULL,
    [number_of_drawings_loc] int  NULL,
    [amount_under_loc] decimal(19,4)  NULL,
    [maturity_loc] int  NULL,
    [anticipated_partial_repayment_base] smallint  NOT NULL,
    [anticipated_total_repayment_base] smallint  NOT NULL,
    [schedule_changed] bit  NOT NULL,
    [amount_min] decimal(19,4)  NULL,
    [amount_max] decimal(19,4)  NULL,
    [ir_min] decimal(16,12)  NULL,
    [ir_max] decimal(16,12)  NULL,
    [nmb_of_inst_min] int  NULL,
    [nmb_of_inst_max] int  NULL,
    [loan_cycle] int  NULL,
    [insurance] decimal(18,2)  NOT NULL,
    [exotic_id] int  NULL
);
GO

-- Creating table 'CreditEntryFees'
CREATE TABLE [dbo].[CreditEntryFees] (
    [id] int IDENTITY(1,1) NOT NULL,
    [credit_id] int  NOT NULL,
    [entry_fee_id] int  NOT NULL,
    [fee_value] decimal(18,4)  NOT NULL
);
GO

-- Creating table 'CreditInsuranceEvents'
CREATE TABLE [dbo].[CreditInsuranceEvents] (
    [id] int  NOT NULL,
    [commission] decimal(18,2)  NOT NULL,
    [principal] decimal(18,2)  NOT NULL
);
GO

-- Creating table 'Currencies'
CREATE TABLE [dbo].[Currencies] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [is_pivot] bit  NOT NULL,
    [code] nvarchar(20)  NOT NULL,
    [is_swapped] bit  NOT NULL,
    [use_cents] bit  NOT NULL
);
GO

-- Creating table 'CycleObjects'
CREATE TABLE [dbo].[CycleObjects] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'CycleParameters'
CREATE TABLE [dbo].[CycleParameters] (
    [id] int IDENTITY(1,1) NOT NULL,
    [loan_cycle] int  NOT NULL,
    [min] decimal(19,4)  NOT NULL,
    [max] decimal(19,4)  NOT NULL,
    [cycle_object_id] int  NOT NULL,
    [cycle_id] int  NOT NULL
);
GO

-- Creating table 'Cycles'
CREATE TABLE [dbo].[Cycles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(2)  NULL,
    [Description] nvarchar(50)  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'Districts'
CREATE TABLE [dbo].[Districts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [province_id] int  NOT NULL,
    [deleted] bit  NOT NULL
);
GO

-- Creating table 'EconomicActivities'
CREATE TABLE [dbo].[EconomicActivities] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [parent_id] int  NULL,
    [deleted] bit  NOT NULL
);
GO

-- Creating table 'EconomicActivityLoanHistories'
CREATE TABLE [dbo].[EconomicActivityLoanHistories] (
    [contract_id] int  NOT NULL,
    [person_id] int  NOT NULL,
    [group_id] int  NULL,
    [economic_activity_id] int  NOT NULL,
    [deleted] bit  NOT NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [EmpNo] nvarchar(250)  NULL,
    [Surname] nvarchar(250)  NULL,
    [OtherNames] nvarchar(250)  NULL,
    [Email] nvarchar(250)  NULL,
    [DoB] datetime  NULL,
    [MaritalStatus] nvarchar(1)  NULL,
    [Gender] nvarchar(1)  NULL,
    [Photo] nvarchar(max)  NULL,
    [DoE] datetime  NULL,
    [BasicComputation] nvarchar(1)  NULL,
    [BasicPay] decimal(19,4)  NULL,
    [PersonalRelief] decimal(19,4)  NULL,
    [MortgageRelief] decimal(19,4)  NULL,
    [InsuranceRelief] decimal(19,4)  NULL,
    [NSSFNo] nvarchar(250)  NULL,
    [NHIFNo] nvarchar(250)  NULL,
    [IDNo] nvarchar(250)  NULL,
    [PINNo] nvarchar(250)  NULL,
    [DepartmentId] int  NULL,
    [EmployerId] int  NOT NULL,
    [PayPoint] nvarchar(250)  NULL,
    [EmpGroup] nvarchar(250)  NULL,
    [EmpSacco] nvarchar(250)  NULL,
    [PrevEmployer] nvarchar(250)  NULL,
    [DateLeft] datetime  NULL,
    [PaymentMode] nvarchar(250)  NULL,
    [TelephoneNo] nvarchar(250)  NULL,
    [ChequeNo] nvarchar(250)  NULL,
    [BankCode] nvarchar(250)  NULL,
    [BankAccount] nvarchar(250)  NULL,
    [LeaveBalance] nvarchar(250)  NULL,
    [IsActive] bit  NULL,
    [CreatedBy] nvarchar(250)  NULL,
    [CreatedOn] datetime  NULL,
    [IsDeleted] bit  NULL,
    [SystemId] nvarchar(250)  NULL
);
GO

-- Creating table 'Employers'
CREATE TABLE [dbo].[Employers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(250)  NULL,
    [Address1] nvarchar(250)  NULL,
    [Address2] nvarchar(250)  NULL,
    [Telephone] nvarchar(250)  NULL,
    [Email] nvarchar(250)  NULL,
    [Logo] nvarchar(250)  NULL,
    [Slogan] nvarchar(250)  NULL,
    [AuthorizedSignatory] nvarchar(250)  NULL,
    [IsActive] bit  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'EntryFees'
CREATE TABLE [dbo].[EntryFees] (
    [id] int IDENTITY(1,1) NOT NULL,
    [id_product] int  NOT NULL,
    [name_of_fee] nvarchar(100)  NOT NULL,
    [min] decimal(18,4)  NULL,
    [max] decimal(18,4)  NULL,
    [value] decimal(18,4)  NULL,
    [rate] bit  NULL,
    [is_deleted] bit  NOT NULL,
    [fee_index] int  NOT NULL,
    [cycle_id] int  NULL
);
GO

-- Creating table 'EventAttributes'
CREATE TABLE [dbo].[EventAttributes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [event_type] nvarchar(4)  NOT NULL,
    [name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'EventTypes'
CREATE TABLE [dbo].[EventTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [event_type] nvarchar(4)  NOT NULL,
    [description] nvarchar(50)  NOT NULL,
    [sort_order] int  NULL,
    [accounting] bit  NULL
);
GO

-- Creating table 'ExchangeRates'
CREATE TABLE [dbo].[ExchangeRates] (
    [exchange_date] datetime  NOT NULL,
    [exchange_rate] float  NOT NULL,
    [currency_id] int  NOT NULL
);
GO

-- Creating table 'ExoticInstallments'
CREATE TABLE [dbo].[ExoticInstallments] (
    [number] int  NOT NULL,
    [exotic_id] int  NOT NULL,
    [principal_coeff] decimal(11,10)  NOT NULL,
    [interest_coeff] decimal(11,10)  NOT NULL
);
GO

-- Creating table 'Exotics'
CREATE TABLE [dbo].[Exotics] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'FiscalYears'
CREATE TABLE [dbo].[FiscalYears] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NULL,
    [open_date] datetime  NULL,
    [close_date] datetime  NULL
);
GO

-- Creating table 'FundingLineAccountingRules'
CREATE TABLE [dbo].[FundingLineAccountingRules] (
    [id] int  NOT NULL,
    [funding_line_id] int  NULL
);
GO

-- Creating table 'FundingLineEvents'
CREATE TABLE [dbo].[FundingLineEvents] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(200)  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [direction] smallint  NOT NULL,
    [fundingline_id] int  NOT NULL,
    [deleted] bit  NOT NULL,
    [creation_date] datetime  NOT NULL,
    [type] smallint  NOT NULL,
    [user_id] int  NULL,
    [contract_event_id] int  NULL
);
GO

-- Creating table 'FundingLines'
CREATE TABLE [dbo].[FundingLines] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [begin_date] datetime  NOT NULL,
    [end_date] datetime  NOT NULL,
    [amount] decimal(18,0)  NOT NULL,
    [purpose] nvarchar(50)  NOT NULL,
    [deleted] bit  NOT NULL,
    [currency_id] int  NOT NULL
);
GO

-- Creating table 'GeneralParameters'
CREATE TABLE [dbo].[GeneralParameters] (
    [key] varchar(50)  NOT NULL,
    [value] nvarchar(200)  NULL
);
GO

-- Creating table 'Groups'
CREATE TABLE [dbo].[Groups] (
    [id] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [establishment_date] datetime  NULL,
    [meeting_day] int  NULL,
    [loan_officer_id] int  NULL
);
GO

-- Creating table 'InstallmentHistories'
CREATE TABLE [dbo].[InstallmentHistories] (
    [id] int IDENTITY(1,1) NOT NULL,
    [contract_id] int  NOT NULL,
    [event_id] int  NOT NULL,
    [number] int  NOT NULL,
    [expected_date] datetime  NOT NULL,
    [capital_repayment] decimal(19,4)  NOT NULL,
    [interest_repayment] decimal(19,4)  NOT NULL,
    [paid_interest] decimal(19,4)  NOT NULL,
    [paid_capital] decimal(19,4)  NOT NULL,
    [paid_fees] decimal(19,4)  NOT NULL,
    [fees_unpaid] decimal(19,4)  NOT NULL,
    [paid_date] datetime  NULL,
    [delete_date] datetime  NULL,
    [comment] nvarchar(50)  NULL,
    [pending] bit  NOT NULL,
    [start_date] datetime  NOT NULL,
    [olb] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Installments'
CREATE TABLE [dbo].[Installments] (
    [expected_date] datetime  NOT NULL,
    [interest_repayment] decimal(19,4)  NOT NULL,
    [capital_repayment] decimal(19,4)  NOT NULL,
    [contract_id] int  NOT NULL,
    [number] int  NOT NULL,
    [paid_interest] decimal(19,4)  NOT NULL,
    [paid_capital] decimal(19,4)  NOT NULL,
    [fees_unpaid] decimal(19,4)  NOT NULL,
    [paid_date] datetime  NULL,
    [paid_fees] decimal(19,4)  NOT NULL,
    [comment] nvarchar(50)  NULL,
    [pending] bit  NOT NULL,
    [start_date] datetime  NOT NULL,
    [olb] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'InstallmentTypes'
CREATE TABLE [dbo].[InstallmentTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [nb_of_days] int  NOT NULL,
    [nb_of_months] int  NOT NULL
);
GO

-- Creating table 'LinkBranchesPaymentMethods'
CREATE TABLE [dbo].[LinkBranchesPaymentMethods] (
    [id] int IDENTITY(1,1) NOT NULL,
    [branch_id] int  NOT NULL,
    [payment_method_id] int  NOT NULL,
    [deleted] bit  NOT NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'LinkGuarantorCredits'
CREATE TABLE [dbo].[LinkGuarantorCredits] (
    [tiers_id] int  NOT NULL,
    [contract_id] int  NOT NULL,
    [guarantee_amount] decimal(19,4)  NOT NULL,
    [guarantee_desc] nvarchar(100)  NULL
);
GO

-- Creating table 'LinkPackagesExotics'
CREATE TABLE [dbo].[LinkPackagesExotics] (
    [id] int IDENTITY(1,1) NOT NULL,
    [package_id] int  NOT NULL,
    [exotic_id] int  NOT NULL
);
GO

-- Creating table 'LoanAccountingMovements'
CREATE TABLE [dbo].[LoanAccountingMovements] (
    [id] int IDENTITY(1,1) NOT NULL,
    [contract_id] int  NOT NULL,
    [debit_account_number_id] int  NOT NULL,
    [credit_account_number_id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [event_id] int  NOT NULL,
    [transaction_date] datetime  NOT NULL,
    [export_date] datetime  NULL,
    [is_exported] bit  NOT NULL,
    [currency_id] int  NOT NULL,
    [exchange_rate] float  NOT NULL,
    [rule_id] int  NULL,
    [branch_id] int  NOT NULL,
    [closure_id] int  NULL,
    [fiscal_year_id] int  NULL,
    [booking_type] int  NOT NULL
);
GO

-- Creating table 'LoanDisbursmentEvents'
CREATE TABLE [dbo].[LoanDisbursmentEvents] (
    [id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [fees] decimal(19,4)  NOT NULL,
    [interest] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'LoanEntryFeeEvents'
CREATE TABLE [dbo].[LoanEntryFeeEvents] (
    [id] int  NOT NULL,
    [fee] decimal(19,4)  NOT NULL,
    [disbursement_event_id] int  NOT NULL
);
GO

-- Creating table 'LoanInterestAccruingEvents'
CREATE TABLE [dbo].[LoanInterestAccruingEvents] (
    [id] int  NOT NULL,
    [interest_prepayment] decimal(19,4)  NOT NULL,
    [accrued_interest] decimal(19,4)  NOT NULL,
    [rescheduled] bit  NOT NULL,
    [installment_number] int  NOT NULL
);
GO

-- Creating table 'LoanScales'
CREATE TABLE [dbo].[LoanScales] (
    [id] int  NOT NULL,
    [ScaleMin] int  NULL,
    [ScaleMax] int  NULL
);
GO

-- Creating table 'LoanShareAmounts'
CREATE TABLE [dbo].[LoanShareAmounts] (
    [person_id] int  NOT NULL,
    [group_id] int  NOT NULL,
    [contract_id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [event_id] int  NULL,
    [payment_date] datetime  NULL
);
GO

-- Creating table 'LoansLinkSavingsBooks'
CREATE TABLE [dbo].[LoansLinkSavingsBooks] (
    [id] int IDENTITY(1,1) NOT NULL,
    [loan_id] int  NULL,
    [savings_id] int  NULL,
    [loan_percentage] int  NULL
);
GO

-- Creating table 'ManualAccountingMovements'
CREATE TABLE [dbo].[ManualAccountingMovements] (
    [id] int IDENTITY(1,1) NOT NULL,
    [debit_account_number_id] int  NOT NULL,
    [credit_account_number_id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [transaction_date] datetime  NOT NULL,
    [export_date] datetime  NULL,
    [is_exported] bit  NOT NULL,
    [currency_id] int  NOT NULL,
    [exchange_rate] float  NOT NULL,
    [description] nvarchar(500)  NULL,
    [user_id] int  NOT NULL,
    [event_id] int  NULL,
    [branch_id] int  NOT NULL,
    [closure_id] int  NULL,
    [fiscal_year_id] int  NULL
);
GO

-- Creating table 'MenuItems'
CREATE TABLE [dbo].[MenuItems] (
    [id] int IDENTITY(1,1) NOT NULL,
    [component_name] nvarchar(100)  NOT NULL,
    [type] int  NOT NULL
);
GO

-- Creating table 'Monitorings'
CREATE TABLE [dbo].[Monitorings] (
    [id] int IDENTITY(1,1) NOT NULL,
    [object_id] int  NOT NULL,
    [date] datetime  NULL,
    [purpose] nvarchar(255)  NULL,
    [monitor] nvarchar(255)  NULL,
    [comment] nvarchar(4000)  NULL,
    [type] bit  NOT NULL
);
GO

-- Creating table 'OverdueEvents'
CREATE TABLE [dbo].[OverdueEvents] (
    [id] int  NOT NULL,
    [olb] decimal(19,4)  NOT NULL,
    [overdue_days] int  NOT NULL,
    [overdue_principal] decimal(19,4)  NULL
);
GO

-- Creating table 'Packages'
CREATE TABLE [dbo].[Packages] (
    [id] int IDENTITY(1,1) NOT NULL,
    [deleted] bit  NOT NULL,
    [code] nvarchar(50)  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [client_type] char(1)  NULL,
    [amount] decimal(19,4)  NULL,
    [amount_min] decimal(19,4)  NULL,
    [amount_max] decimal(19,4)  NULL,
    [interest_rate] decimal(16,12)  NULL,
    [interest_rate_min] decimal(16,12)  NULL,
    [interest_rate_max] decimal(16,12)  NULL,
    [installment_type] int  NOT NULL,
    [grace_period] int  NULL,
    [grace_period_min] int  NULL,
    [grace_period_max] int  NULL,
    [number_of_installments] int  NULL,
    [number_of_installments_min] int  NULL,
    [number_of_installments_max] int  NULL,
    [anticipated_total_repayment_penalties] float  NULL,
    [anticipated_total_repayment_penalties_min] float  NULL,
    [anticipated_total_repayment_penalties_max] float  NULL,
    [loan_type] smallint  NOT NULL,
    [keep_expected_installment] bit  NOT NULL,
    [charge_interest_within_grace_period] bit  NOT NULL,
    [cycle_id] int  NULL,
    [non_repayment_penalties_based_on_overdue_interest] float  NULL,
    [non_repayment_penalties_based_on_initial_amount] float  NULL,
    [non_repayment_penalties_based_on_olb] float  NULL,
    [non_repayment_penalties_based_on_overdue_principal] float  NULL,
    [non_repayment_penalties_based_on_overdue_interest_min] float  NULL,
    [non_repayment_penalties_based_on_initial_amount_min] float  NULL,
    [non_repayment_penalties_based_on_olb_min] float  NULL,
    [non_repayment_penalties_based_on_overdue_principal_min] float  NULL,
    [non_repayment_penalties_based_on_overdue_interest_max] float  NULL,
    [non_repayment_penalties_based_on_initial_amount_max] float  NULL,
    [non_repayment_penalties_based_on_olb_max] float  NULL,
    [non_repayment_penalties_based_on_overdue_principal_max] float  NULL,
    [fundingLine_id] int  NULL,
    [currency_id] int  NOT NULL,
    [rounding_type] smallint  NOT NULL,
    [grace_period_of_latefees] int  NOT NULL,
    [anticipated_partial_repayment_penalties] float  NULL,
    [anticipated_partial_repayment_penalties_min] float  NULL,
    [anticipated_partial_repayment_penalties_max] float  NULL,
    [anticipated_partial_repayment_base] smallint  NOT NULL,
    [anticipated_total_repayment_base] smallint  NOT NULL,
    [number_of_drawings_loc] int  NULL,
    [amount_under_loc] decimal(19,4)  NULL,
    [amount_under_loc_min] decimal(19,4)  NULL,
    [amount_under_loc_max] decimal(19,4)  NULL,
    [maturity_loc] int  NULL,
    [maturity_loc_min] int  NULL,
    [maturity_loc_max] int  NULL,
    [activated_loc] bit  NOT NULL,
    [allow_flexible_schedule] bit  NOT NULL,
    [use_guarantor_collateral] bit  NOT NULL,
    [set_separate_guarantor_collateral] bit  NOT NULL,
    [percentage_total_guarantor_collateral] int  NOT NULL,
    [percentage_separate_guarantor] int  NOT NULL,
    [percentage_separate_collateral] int  NOT NULL,
    [use_compulsory_savings] bit  NOT NULL,
    [compulsory_amount] int  NULL,
    [compulsory_amount_min] int  NULL,
    [compulsory_amount_max] int  NULL,
    [insurance_min] decimal(18,2)  NOT NULL,
    [insurance_max] decimal(18,2)  NOT NULL,
    [use_entry_fees_cycles] bit  NOT NULL,
    [is_balloon] bit  NOT NULL
);
GO

-- Creating table 'PackagesClientTypes'
CREATE TABLE [dbo].[PackagesClientTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [client_type_id] int  NOT NULL,
    [package_id] int  NOT NULL
);
GO

-- Creating table 'PaymentMethods'
CREATE TABLE [dbo].[PaymentMethods] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL,
    [description] nvarchar(250)  NULL,
    [is_active_for_loans] bit  NOT NULL,
    [is_pending_for_loans] bit  NOT NULL,
    [is_active_for_savings] bit  NOT NULL,
    [is_pending_for_savings] bit  NOT NULL,
    [account_id] int  NULL,
    [is_deleted] bit  NOT NULL
);
GO

-- Creating table 'PersonGroupBelongings'
CREATE TABLE [dbo].[PersonGroupBelongings] (
    [person_id] int  NOT NULL,
    [group_id] int  NOT NULL,
    [is_leader] bit  NOT NULL,
    [currently_in] bit  NOT NULL,
    [joined_date] datetime  NOT NULL,
    [left_date] datetime  NULL
);
GO

-- Creating table 'Persons'
CREATE TABLE [dbo].[Persons] (
    [id] int  NOT NULL,
    [first_name] nvarchar(100)  NOT NULL,
    [sex] char(1)  NOT NULL,
    [identification_data] nvarchar(200)  NOT NULL,
    [last_name] nvarchar(100)  NOT NULL,
    [birth_date] datetime  NULL,
    [household_head] bit  NOT NULL,
    [nb_of_dependents] int  NULL,
    [nb_of_children] int  NULL,
    [children_basic_education] int  NULL,
    [livestock_number] int  NULL,
    [livestock_type] nvarchar(100)  NULL,
    [landplot_size] float  NULL,
    [home_size] float  NULL,
    [home_time_living_in] int  NULL,
    [capital_other_equipments] nvarchar(500)  NULL,
    [activity_id] int  NULL,
    [experience] int  NULL,
    [nb_of_people] int  NULL,
    [monthly_income] decimal(19,4)  NULL,
    [monthly_expenditure] decimal(19,4)  NULL,
    [comments] nvarchar(500)  NULL,
    [image_path] nvarchar(500)  NULL,
    [father_name] nvarchar(200)  NULL,
    [birth_place] nvarchar(50)  NULL,
    [nationality] nvarchar(50)  NULL,
    [study_level] nvarchar(50)  NULL,
    [SS] nvarchar(50)  NULL,
    [CAF] nvarchar(50)  NULL,
    [housing_situation] nvarchar(50)  NULL,
    [bank_situation] nvarchar(50)  NULL,
    [handicapped] bit  NOT NULL,
    [professional_experience] nvarchar(50)  NULL,
    [professional_situation] nvarchar(50)  NULL,
    [first_contact] datetime  NULL,
    [family_situation] nvarchar(50)  NULL,
    [mother_name] nvarchar(200)  NULL,
    [povertylevel_childreneducation] int  NOT NULL,
    [povertylevel_economiceducation] int  NOT NULL,
    [povertylevel_socialparticipation] int  NOT NULL,
    [povertylevel_healthsituation] int  NOT NULL,
    [unemployment_months] int  NULL,
    [first_appointment] datetime  NULL,
    [loan_officer_id] int  NULL
);
GO

-- Creating table 'PersonsPhotos'
CREATE TABLE [dbo].[PersonsPhotos] (
    [id] int IDENTITY(1,1) NOT NULL,
    [person_id] int  NOT NULL,
    [picture_id] int  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [id] int IDENTITY(1,1) NOT NULL,
    [tiers_id] int  NOT NULL,
    [status] smallint  NOT NULL,
    [name] nvarchar(255)  NOT NULL,
    [code] nvarchar(255)  NOT NULL,
    [aim] nvarchar(255)  NOT NULL,
    [begin_date] datetime  NOT NULL,
    [abilities] nvarchar(255)  NULL,
    [experience] nvarchar(255)  NULL,
    [market] nvarchar(255)  NULL,
    [concurrence] nvarchar(255)  NULL,
    [purpose] nvarchar(255)  NULL,
    [corporate_name] nvarchar(255)  NULL,
    [corporate_juridicStatus] nvarchar(255)  NULL,
    [corporate_FiscalStatus] nvarchar(255)  NULL,
    [corporate_siret] nvarchar(255)  NULL,
    [corporate_CA] decimal(19,4)  NULL,
    [corporate_nbOfJobs] int  NULL,
    [corporate_financialPlanType] nvarchar(255)  NULL,
    [corporateFinancialPlanAmount] decimal(19,4)  NULL,
    [corporate_financialPlanTotalAmount] decimal(19,4)  NULL,
    [address] nvarchar(255)  NULL,
    [city] nvarchar(255)  NULL,
    [zipCode] nvarchar(255)  NULL,
    [district_id] int  NULL,
    [home_phone] nvarchar(255)  NULL,
    [personalPhone] nvarchar(255)  NULL,
    [Email] nvarchar(255)  NULL,
    [hometype] nvarchar(255)  NULL,
    [corporate_registre] nvarchar(255)  NULL
);
GO

-- Creating table 'Provinces'
CREATE TABLE [dbo].[Provinces] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [deleted] bit  NOT NULL
);
GO

-- Creating table 'ProvisionEvents'
CREATE TABLE [dbo].[ProvisionEvents] (
    [id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [rate] float  NOT NULL,
    [overdue_days] int  NOT NULL
);
GO

-- Creating table 'ProvisioningRules'
CREATE TABLE [dbo].[ProvisioningRules] (
    [id] int  NOT NULL,
    [number_of_days_min] int  NOT NULL,
    [number_of_days_max] int  NOT NULL,
    [provisioning_value] float  NOT NULL
);
GO

-- Creating table 'PublicHolidays'
CREATE TABLE [dbo].[PublicHolidays] (
    [date] datetime  NOT NULL,
    [name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Questionnaires'
CREATE TABLE [dbo].[Questionnaires] (
    [Name] nvarchar(256)  NULL,
    [Country] nvarchar(50)  NULL,
    [Email] nvarchar(100)  NULL,
    [PositionInCompony] nvarchar(100)  NULL,
    [OtherMessages] nvarchar(4000)  NULL,
    [GrossPortfolio] nvarchar(50)  NULL,
    [NumberOfClients] nvarchar(50)  NULL,
    [PersonName] nvarchar(200)  NULL,
    [Phone] nvarchar(200)  NULL,
    [Skype] nvarchar(200)  NULL,
    [PurposeOfUsage] nvarchar(200)  NULL,
    [is_sent] bit  NOT NULL
);
GO

-- Creating table 'Rep_Active_Loans_Data'
CREATE TABLE [dbo].[Rep_Active_Loans_Data] (
    [id] int  NOT NULL,
    [branch_name] nvarchar(50)  NULL,
    [load_date] datetime  NULL,
    [break_down] nvarchar(150)  NULL,
    [break_down_type] nvarchar(20)  NULL,
    [contracts] int  NULL,
    [individual] int  NULL,
    [group] int  NULL,
    [corporate] int  NULL,
    [clients] int  NULL,
    [in_groups] int  NULL,
    [projects] int  NULL,
    [olb] decimal(19,4)  NULL,
    [break_down_id] int  NULL
);
GO

-- Creating table 'Rep_Disbursements_Data'
CREATE TABLE [dbo].[Rep_Disbursements_Data] (
    [id] int  NOT NULL,
    [branch_name] nvarchar(50)  NULL,
    [load_date] datetime  NULL,
    [contract_code] nvarchar(255)  NULL,
    [district] nvarchar(255)  NULL,
    [loan_product] nvarchar(255)  NULL,
    [client_name] nvarchar(255)  NULL,
    [loan_cycle] int  NULL,
    [loan_officer] nvarchar(255)  NULL,
    [disbursement_date] datetime  NULL,
    [amount] decimal(19,4)  NULL,
    [interest] decimal(19,4)  NULL,
    [fees] decimal(19,4)  NULL
);
GO

-- Creating table 'Rep_OLB_and_LLP_Data'
CREATE TABLE [dbo].[Rep_OLB_and_LLP_Data] (
    [id] int  NOT NULL,
    [branch_name] nvarchar(50)  NULL,
    [load_date] datetime  NULL,
    [contract_code] nvarchar(255)  NULL,
    [olb] decimal(19,4)  NULL,
    [interest] decimal(19,4)  NULL,
    [late_days] int  NULL,
    [client_name] nvarchar(255)  NULL,
    [loan_officer_name] nvarchar(255)  NULL,
    [product_name] nvarchar(255)  NULL,
    [district_name] nvarchar(255)  NULL,
    [start_date] datetime  NULL,
    [close_date] datetime  NULL,
    [range_from] int  NULL,
    [range_to] int  NULL,
    [llp_rate] int  NULL,
    [llp] decimal(19,4)  NULL,
    [rescheduled] bit  NULL
);
GO

-- Creating table 'Rep_Par_Analysis_Data'
CREATE TABLE [dbo].[Rep_Par_Analysis_Data] (
    [id] int  NOT NULL,
    [branch_name] nvarchar(50)  NULL,
    [load_date] datetime  NULL,
    [break_down] nvarchar(150)  NULL,
    [break_down_type] varchar(20)  NULL,
    [olb] decimal(19,4)  NULL,
    [par] decimal(19,4)  NULL,
    [contracts] int  NULL,
    [clients] int  NULL,
    [all_contracts] int  NULL,
    [all_clients] int  NULL,
    [par_30] decimal(19,4)  NULL,
    [contracts_30] int  NULL,
    [clients_30] int  NULL,
    [par_1_30] decimal(19,4)  NULL,
    [contracts_1_30] int  NULL,
    [clients_1_30] int  NULL,
    [par_31_60] decimal(19,4)  NULL,
    [contracts_31_60] int  NULL,
    [clients_31_60] int  NULL,
    [par_61_90] decimal(19,4)  NULL,
    [contracts_61_90] int  NULL,
    [clients_61_90] int  NULL,
    [par_91_180] decimal(19,4)  NULL,
    [contracts_91_180] int  NULL,
    [clients_91_180] int  NULL,
    [par_181_365] decimal(19,4)  NULL,
    [contracts_181_365] int  NULL,
    [clients_181_365] int  NULL,
    [par_365] decimal(19,4)  NULL,
    [contracts_365] int  NULL,
    [clients_365] int  NULL,
    [break_down_id] int  NULL
);
GO

-- Creating table 'Rep_Repayments_Data'
CREATE TABLE [dbo].[Rep_Repayments_Data] (
    [id] int  NOT NULL,
    [branch_name] nvarchar(50)  NULL,
    [load_date] datetime  NULL,
    [event_id] int  NULL,
    [contract_code] nvarchar(255)  NULL,
    [client_name] nvarchar(255)  NULL,
    [district_name] nvarchar(255)  NULL,
    [loan_officer_name] nvarchar(255)  NULL,
    [loan_product_name] nvarchar(255)  NULL,
    [early_fee] decimal(19,4)  NULL,
    [late_fee] decimal(19,4)  NULL,
    [principal] decimal(19,4)  NULL,
    [interest] decimal(19,4)  NULL,
    [total] decimal(19,4)  NULL,
    [written_off] bit  NULL
);
GO

-- Creating table 'Rep_Rescheduled_Loans_Data'
CREATE TABLE [dbo].[Rep_Rescheduled_Loans_Data] (
    [id] int  NOT NULL,
    [branch_name] nvarchar(50)  NULL,
    [load_date] datetime  NULL,
    [loan_officer] nvarchar(255)  NULL,
    [client_name] nvarchar(255)  NULL,
    [contract_code] nvarchar(255)  NULL,
    [package_name] nvarchar(255)  NULL,
    [loan_amount] decimal(19,4)  NULL,
    [amount_rescheduled] decimal(19,4)  NULL,
    [maturity] int  NULL,
    [reschedule_date] datetime  NULL,
    [olb] decimal(19,4)  NULL
);
GO

-- Creating table 'RepaymentEvents'
CREATE TABLE [dbo].[RepaymentEvents] (
    [id] int  NOT NULL,
    [past_due_days] int  NOT NULL,
    [principal] decimal(19,4)  NOT NULL,
    [interests] decimal(19,4)  NOT NULL,
    [installment_number] int  NOT NULL,
    [commissions] decimal(19,4)  NOT NULL,
    [penalties] decimal(19,4)  NOT NULL,
    [calculated_penalties] decimal(19,4)  NOT NULL,
    [written_off_penalties] decimal(19,4)  NOT NULL,
    [unpaid_penalties] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'ReschedulingOfALoanEvents'
CREATE TABLE [dbo].[ReschedulingOfALoanEvents] (
    [id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [interest] decimal(19,4)  NOT NULL,
    [nb_of_maturity] int  NOT NULL,
    [date_offset] int  NOT NULL,
    [grace_period] int  NOT NULL,
    [charge_interest_during_shift] bit  NOT NULL,
    [charge_interest_during_grace_period] bit  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [id] int IDENTITY(1,1) NOT NULL,
    [code] nvarchar(256)  NOT NULL,
    [deleted] bit  NOT NULL,
    [description] nvarchar(2048)  NULL,
    [role_of_loan] bit  NULL,
    [role_of_saving] bit  NULL,
    [role_of_teller] bit  NULL
);
GO

-- Creating table 'SavingBookContracts'
CREATE TABLE [dbo].[SavingBookContracts] (
    [id] int  NOT NULL,
    [flat_withdraw_fees] decimal(19,4)  NULL,
    [rate_withdraw_fees] float  NULL,
    [flat_transfer_fees] decimal(19,4)  NULL,
    [rate_transfer_fees] float  NULL,
    [flat_deposit_fees] decimal(19,4)  NULL,
    [flat_close_fees] decimal(19,4)  NULL,
    [flat_management_fees] decimal(19,4)  NULL,
    [flat_overdraft_fees] decimal(19,4)  NULL,
    [in_overdraft] bit  NOT NULL,
    [rate_agio_fees] float  NULL,
    [cheque_deposit_fees] decimal(19,4)  NULL,
    [flat_reopen_fees] decimal(19,4)  NULL,
    [flat_ibt_fee] decimal(19,4)  NULL,
    [rate_ibt_fee] float  NULL,
    [use_term_deposit] bit  NOT NULL,
    [term_deposit_period] int  NOT NULL,
    [term_deposit_period_min] int  NULL,
    [term_deposit_period_max] int  NULL,
    [transfer_account] nvarchar(50)  NULL,
    [rollover] int  NULL,
    [next_maturity] datetime  NULL
);
GO

-- Creating table 'SavingBookProducts'
CREATE TABLE [dbo].[SavingBookProducts] (
    [id] int  NOT NULL,
    [interest_base] smallint  NOT NULL,
    [interest_frequency] smallint  NOT NULL,
    [calcul_amount_base] smallint  NULL,
    [withdraw_fees_type] smallint  NOT NULL,
    [flat_withdraw_fees_min] decimal(19,4)  NULL,
    [flat_withdraw_fees_max] decimal(19,4)  NULL,
    [flat_withdraw_fees] decimal(19,4)  NULL,
    [rate_withdraw_fees_min] float  NULL,
    [rate_withdraw_fees_max] float  NULL,
    [rate_withdraw_fees] float  NULL,
    [transfer_fees_type] smallint  NOT NULL,
    [flat_transfer_fees_min] decimal(19,4)  NULL,
    [flat_transfer_fees_max] decimal(19,4)  NULL,
    [flat_transfer_fees] decimal(19,4)  NULL,
    [rate_transfer_fees_min] float  NULL,
    [rate_transfer_fees_max] float  NULL,
    [rate_transfer_fees] float  NULL,
    [deposit_fees] decimal(19,4)  NULL,
    [deposit_fees_max] decimal(19,4)  NULL,
    [deposit_fees_min] decimal(19,4)  NULL,
    [close_fees] decimal(19,4)  NULL,
    [close_fees_max] decimal(19,4)  NULL,
    [close_fees_min] decimal(19,4)  NULL,
    [management_fees] decimal(19,4)  NULL,
    [management_fees_max] decimal(19,4)  NULL,
    [management_fees_min] decimal(19,4)  NULL,
    [management_fees_freq] int  NOT NULL,
    [overdraft_fees] decimal(19,4)  NULL,
    [overdraft_fees_max] decimal(19,4)  NULL,
    [overdraft_fees_min] decimal(19,4)  NULL,
    [agio_fees] float  NULL,
    [agio_fees_max] float  NULL,
    [agio_fees_min] float  NULL,
    [agio_fees_freq] int  NOT NULL,
    [cheque_deposit_min] decimal(19,4)  NULL,
    [cheque_deposit_max] decimal(19,4)  NULL,
    [cheque_deposit_fees] decimal(19,4)  NULL,
    [cheque_deposit_fees_min] decimal(19,4)  NULL,
    [cheque_deposit_fees_max] decimal(19,4)  NULL,
    [reopen_fees] decimal(19,4)  NULL,
    [reopen_fees_min] decimal(19,4)  NULL,
    [reopen_fees_max] decimal(19,4)  NULL,
    [is_ibt_fee_flat] bit  NOT NULL,
    [ibt_fee_min] decimal(19,4)  NULL,
    [ibt_fee_max] decimal(19,4)  NULL,
    [ibt_fee] decimal(19,4)  NULL,
    [use_term_deposit] bit  NOT NULL,
    [term_deposit_period_min] int  NULL,
    [term_deposit_period_max] int  NULL,
    [posting_frequency] int  NULL
);
GO

-- Creating table 'SavingContracts'
CREATE TABLE [dbo].[SavingContracts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [product_id] int  NOT NULL,
    [user_id] int  NOT NULL,
    [code] nvarchar(50)  NOT NULL,
    [tiers_id] int  NOT NULL,
    [creation_date] datetime  NOT NULL,
    [interest_rate] float  NOT NULL,
    [status] smallint  NOT NULL,
    [closed_date] datetime  NULL,
    [savings_officer_id] int  NOT NULL,
    [initial_amount] decimal(19,4)  NOT NULL,
    [entry_fees] decimal(19,4)  NOT NULL,
    [nsg_id] int  NULL
);
GO

-- Creating table 'SavingDepositContracts'
CREATE TABLE [dbo].[SavingDepositContracts] (
    [id] int  NOT NULL,
    [number_periods] int  NOT NULL,
    [rollover] smallint  NOT NULL,
    [transfer_account] nvarchar(50)  NULL,
    [withdrawal_fees] float  NOT NULL,
    [next_maturity] datetime  NULL
);
GO

-- Creating table 'SavingEvents'
CREATE TABLE [dbo].[SavingEvents] (
    [id] int IDENTITY(1,1) NOT NULL,
    [user_id] int  NOT NULL,
    [contract_id] int  NOT NULL,
    [code] char(4)  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [description] nvarchar(200)  NULL,
    [deleted] bit  NOT NULL,
    [creation_date] datetime  NOT NULL,
    [cancelable] bit  NOT NULL,
    [is_fired] bit  NOT NULL,
    [related_contract_code] nvarchar(50)  NULL,
    [fees] decimal(19,4)  NULL,
    [is_exported] bit  NOT NULL,
    [savings_method] smallint  NULL,
    [pending] bit  NOT NULL,
    [pending_event_id] int  NULL,
    [teller_id] int  NULL,
    [loan_event_id] int  NULL,
    [cancel_date] datetime  NULL
);
GO

-- Creating table 'SavingProducts'
CREATE TABLE [dbo].[SavingProducts] (
    [id] int IDENTITY(1,1) NOT NULL,
    [deleted] bit  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [client_type] char(1)  NULL,
    [initial_amount_min] decimal(19,4)  NULL,
    [initial_amount_max] decimal(19,4)  NULL,
    [balance_min] decimal(19,4)  NULL,
    [balance_max] decimal(19,4)  NULL,
    [withdraw_min] decimal(19,4)  NULL,
    [withdraw_max] decimal(19,4)  NULL,
    [deposit_min] decimal(19,4)  NULL,
    [deposit_max] decimal(19,4)  NULL,
    [interest_rate] float  NULL,
    [interest_rate_min] float  NULL,
    [interest_rate_max] float  NULL,
    [currency_id] int  NOT NULL,
    [entry_fees_min] decimal(19,4)  NULL,
    [entry_fees_max] decimal(19,4)  NULL,
    [entry_fees] decimal(19,4)  NULL,
    [product_type] char(1)  NOT NULL,
    [code] nvarchar(50)  NOT NULL,
    [transfer_min] decimal(19,4)  NOT NULL,
    [transfer_max] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'SavingProductsClientTypes'
CREATE TABLE [dbo].[SavingProductsClientTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [saving_product_id] int  NOT NULL,
    [client_type_id] int  NOT NULL
);
GO

-- Creating table 'SavingsAccountingMovements'
CREATE TABLE [dbo].[SavingsAccountingMovements] (
    [id] int IDENTITY(1,1) NOT NULL,
    [contract_id] int  NOT NULL,
    [debit_account_number_id] int  NOT NULL,
    [credit_account_number_id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [event_id] int  NOT NULL,
    [transaction_date] datetime  NOT NULL,
    [export_date] datetime  NULL,
    [is_exported] bit  NOT NULL,
    [currency_id] int  NOT NULL,
    [exchange_rate] float  NOT NULL,
    [rule_id] int  NULL,
    [branch_id] int  NOT NULL,
    [closure_id] int  NULL,
    [fiscal_year_id] int  NULL
);
GO

-- Creating table 'Settings'
CREATE TABLE [dbo].[Settings] (
    [SSKey] nvarchar(50)  NOT NULL,
    [SSValue] nvarchar(max)  NOT NULL,
    [SSValueType] nvarchar(50)  NOT NULL,
    [Description] nvarchar(50)  NOT NULL,
    [SGroup] int  NOT NULL,
    [SSSystem] bit  NOT NULL
);
GO

-- Creating table 'SettingsGroups'
CREATE TABLE [dbo].[SettingsGroups] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [GroupName] nvarchar(50)  NULL,
    [Parent] int  NULL
);
GO

-- Creating table 'SmsMessageStores'
CREATE TABLE [dbo].[SmsMessageStores] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserDataText] nvarchar(max)  NULL,
    [OriginatingAddress] nvarchar(max)  NULL,
    [SCTimestamp] nvarchar(max)  NULL,
    [MessageStatus] nvarchar(max)  NULL,
    [Storage] nvarchar(max)  NULL,
    [SmscAddressType] nvarchar(max)  NULL,
    [SmscAddress] nvarchar(max)  NULL,
    [OriginatingAddressType] nvarchar(max)  NULL,
    [MessageType] nvarchar(max)  NULL,
    [MessageIndex] nvarchar(max)  NULL,
    [MessageBody] nvarchar(max)  NULL,
    [Status] nvarchar(max)  NULL,
    [Processed] bit  NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'spAllowedReportsRolesMenus'
CREATE TABLE [dbo].[spAllowedReportsRolesMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [MenuItemId] int  NOT NULL,
    [Allowed] bit  NOT NULL
);
GO

-- Creating table 'spAllowedRoleMenus'
CREATE TABLE [dbo].[spAllowedRoleMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [MenuItemId] int  NOT NULL,
    [Allowed] bit  NOT NULL
);
GO

-- Creating table 'spAllowedRoleMenuswebs'
CREATE TABLE [dbo].[spAllowedRoleMenuswebs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NULL,
    [MenuItemId] int  NULL,
    [Allowed] bit  NULL
);
GO

-- Creating table 'spMenuItems'
CREATE TABLE [dbo].[spMenuItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [mnuName] nvarchar(100)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'spMenus'
CREATE TABLE [dbo].[spMenus] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [mnuName] nvarchar(100)  NULL,
    [Description] nvarchar(100)  NULL
);
GO

-- Creating table 'spReportsMenuItems'
CREATE TABLE [dbo].[spReportsMenuItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [mnuName] nvarchar(100)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'spRoles'
CREATE TABLE [dbo].[spRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ShortCode] nvarchar(50)  NOT NULL,
    [Description] nvarchar(100)  NOT NULL,
    [IsDeleted] bit  NOT NULL
);
GO

-- Creating table 'spUsers'
CREATE TABLE [dbo].[spUsers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] int  NOT NULL,
    [UserName] nvarchar(250)  NOT NULL,
    [Password] nvarchar(250)  NOT NULL,
    [Status] nvarchar(1)  NOT NULL,
    [Locked] bit  NOT NULL,
    [IsDeleted] bit  NOT NULL,
    [SystemId] nvarchar(250)  NOT NULL,
    [Surname] nvarchar(200)  NULL,
    [OtherNames] nvarchar(200)  NULL,
    [NationalID] nvarchar(200)  NULL,
    [DateOfBirth] datetime  NULL,
    [Gender] nvarchar(50)  NULL,
    [Telephone] nvarchar(200)  NULL,
    [Email] nvarchar(200)  NULL,
    [DateJoined] datetime  NULL,
    [InformBy] nvarchar(200)  NULL,
    [Photo] nvarchar(max)  NULL
);
GO

-- Creating table 'spUsersInRoles'
CREATE TABLE [dbo].[spUsersInRoles] (
    [UserId] int  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- Creating table 'StandardBookings'
CREATE TABLE [dbo].[StandardBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(128)  NULL,
    [debit_account_id] int  NOT NULL,
    [credit_account_id] int  NOT NULL
);
GO

-- Creating table 'Statuses'
CREATE TABLE [dbo].[Statuses] (
    [id] int IDENTITY(1,1) NOT NULL,
    [status_name] nvarchar(50)  NULL
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

-- Creating table 'TechnicalParameters'
CREATE TABLE [dbo].[TechnicalParameters] (
    [name] nvarchar(100)  NOT NULL,
    [value] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'TechParams'
CREATE TABLE [dbo].[TechParams] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [strtdt] datetime  NULL,
    [edc] int  NULL
);
GO

-- Creating table 'TellerEvents'
CREATE TABLE [dbo].[TellerEvents] (
    [id] int IDENTITY(1,1) NOT NULL,
    [teller_id] int  NOT NULL,
    [event_code] nchar(4)  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [date] datetime  NOT NULL,
    [is_exported] bit  NOT NULL,
    [description] nvarchar(100)  NULL,
    [user_id] int  NOT NULL
);
GO

-- Creating table 'Tellers'
CREATE TABLE [dbo].[Tellers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [desc] nvarchar(100)  NULL,
    [account_id] int  NOT NULL,
    [deleted] bit  NOT NULL,
    [branch_id] int  NOT NULL,
    [currency_id] int  NOT NULL,
    [user_id] int  NOT NULL,
    [amount_min] decimal(19,4)  NULL,
    [amount_max] decimal(19,4)  NULL,
    [deposit_amount_min] decimal(19,4)  NULL,
    [deposit_amount_max] decimal(19,4)  NULL,
    [withdrawal_amount_min] decimal(19,4)  NULL,
    [withdrawal_amount_max] decimal(19,4)  NULL,
    [cash_in_min] decimal(19,4)  NULL,
    [cash_in_max] decimal(19,4)  NULL,
    [cash_out_min] decimal(19,4)  NULL,
    [cash_out_max] decimal(19,4)  NULL,
    [balance_min] decimal(19,4)  NULL,
    [balance_max] decimal(19,4)  NULL
);
GO

-- Creating table 'TermDepositProducts'
CREATE TABLE [dbo].[TermDepositProducts] (
    [id] int  NOT NULL,
    [installment_types_id] int  NOT NULL,
    [number_period] int  NULL,
    [number_period_min] int  NULL,
    [number_period_max] int  NULL,
    [interest_frequency] smallint  NOT NULL,
    [withdrawal_fees_type] smallint  NOT NULL,
    [withdrawal_fees_min] float  NULL,
    [withdrawal_fees_max] float  NULL,
    [withdrawal_fees] float  NULL
);
GO

-- Creating table 'Tiers'
CREATE TABLE [dbo].[Tiers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [client_type_code] char(1)  NOT NULL,
    [scoring] float  NULL,
    [loan_cycle] int  NOT NULL,
    [active] bit  NOT NULL,
    [other_org_name] nvarchar(100)  NULL,
    [other_org_amount] decimal(19,4)  NULL,
    [other_org_debts] decimal(19,4)  NULL,
    [district_id] int  NOT NULL,
    [city] nvarchar(50)  NULL,
    [address] nvarchar(500)  NULL,
    [secondary_district_id] int  NULL,
    [secondary_city] nvarchar(50)  NULL,
    [secondary_address] nvarchar(500)  NULL,
    [cash_input_voucher_number] int  NULL,
    [cash_output_voucher_number] int  NULL,
    [creation_date] datetime  NULL,
    [home_phone] varchar(50)  NULL,
    [personal_phone] varchar(50)  NULL,
    [secondary_home_phone] varchar(50)  NULL,
    [secondary_personal_phone] varchar(50)  NULL,
    [e_mail] nvarchar(50)  NULL,
    [secondary_e_mail] nvarchar(50)  NULL,
    [status] smallint  NOT NULL,
    [other_org_comment] nvarchar(500)  NULL,
    [sponsor1] nvarchar(50)  NULL,
    [sponsor1_comment] nvarchar(100)  NULL,
    [sponsor2] nvarchar(50)  NULL,
    [sponsor2_comment] nvarchar(100)  NULL,
    [follow_up_comment] nvarchar(500)  NULL,
    [home_type] nvarchar(50)  NULL,
    [secondary_homeType] nvarchar(50)  NULL,
    [zipCode] nvarchar(50)  NULL,
    [secondary_zipCode] nvarchar(50)  NULL,
    [branch_id] int  NOT NULL
);
GO

-- Creating table 'TraceUserLogs'
CREATE TABLE [dbo].[TraceUserLogs] (
    [id] int IDENTITY(1,1) NOT NULL,
    [event_code] nvarchar(10)  NULL,
    [event_date] datetime  NULL,
    [user_id] int  NULL,
    [event_description] nvarchar(max)  NULL
);
GO

-- Creating table 'TrancheEvents'
CREATE TABLE [dbo].[TrancheEvents] (
    [id] int  NOT NULL,
    [amount] decimal(19,4)  NOT NULL,
    [maturity] int  NOT NULL,
    [start_date] datetime  NOT NULL,
    [interest_rate] decimal(19,4)  NOT NULL,
    [started_from_installment] int  NULL,
    [applied_new_interest] bit  NOT NULL
);
GO

-- Creating table 'TransactionsAuthorizations'
CREATE TABLE [dbo].[TransactionsAuthorizations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserRoleId] int  NOT NULL,
    [TransactionTypeId] int  NOT NULL,
    [IsDeleted] bit  NULL
);
GO

-- Creating table 'UserProfiles'
CREATE TABLE [dbo].[UserProfiles] (
    [UserId] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [role_id] int  NOT NULL,
    [user_id] int  NOT NULL,
    [date_role_set] datetime  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [deleted] bit  NOT NULL,
    [user_name] nvarchar(50)  NOT NULL,
    [user_pass] nvarchar(50)  NOT NULL,
    [role_code] nvarchar(256)  NOT NULL,
    [first_name] nvarchar(200)  NULL,
    [last_name] nvarchar(200)  NULL,
    [mail] nvarchar(100)  NOT NULL,
    [sex] nchar(1)  NOT NULL,
    [phone] nvarchar(50)  NULL
);
GO

-- Creating table 'UsersBranches'
CREATE TABLE [dbo].[UsersBranches] (
    [user_id] int  NOT NULL,
    [branch_id] int  NOT NULL
);
GO

-- Creating table 'UsersSubordinates'
CREATE TABLE [dbo].[UsersSubordinates] (
    [user_id] int  NOT NULL,
    [subordinate_id] int  NOT NULL
);
GO

-- Creating table 'Villages'
CREATE TABLE [dbo].[Villages] (
    [id] int  NOT NULL,
    [name] nvarchar(50)  NOT NULL,
    [establishment_date] datetime  NOT NULL,
    [loan_officer] int  NOT NULL,
    [meeting_day] int  NULL
);
GO

-- Creating table 'VillagesAttendances'
CREATE TABLE [dbo].[VillagesAttendances] (
    [id] int IDENTITY(1,1) NOT NULL,
    [village_id] int  NOT NULL,
    [person_id] int  NOT NULL,
    [date] datetime  NOT NULL,
    [attended] bit  NOT NULL,
    [comment] nvarchar(1000)  NULL,
    [loan_id] int  NOT NULL
);
GO

-- Creating table 'VillagesPersons'
CREATE TABLE [dbo].[VillagesPersons] (
    [village_id] int  NOT NULL,
    [person_id] int  NOT NULL,
    [joined_date] datetime  NOT NULL,
    [left_date] datetime  NULL,
    [is_leader] bit  NOT NULL,
    [currently_in] bit  NOT NULL,
    [id] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'webpages_Membership'
CREATE TABLE [dbo].[webpages_Membership] (
    [UserId] int  NOT NULL,
    [CreateDate] datetime  NULL,
    [ConfirmationToken] nvarchar(128)  NULL,
    [IsConfirmed] bit  NULL,
    [LastPasswordFailureDate] datetime  NULL,
    [PasswordFailuresSinceLastSuccess] int  NOT NULL,
    [Password] nvarchar(128)  NOT NULL,
    [PasswordChangedDate] datetime  NULL,
    [PasswordSalt] nvarchar(128)  NOT NULL,
    [PasswordVerificationToken] nvarchar(128)  NULL,
    [PasswordVerificationTokenExpirationDate] datetime  NULL
);
GO

-- Creating table 'webpages_OAuthMembership'
CREATE TABLE [dbo].[webpages_OAuthMembership] (
    [Provider] nvarchar(30)  NOT NULL,
    [ProviderUserId] nvarchar(100)  NOT NULL,
    [UserId] int  NOT NULL
);
GO

-- Creating table 'webpages_Roles'
CREATE TABLE [dbo].[webpages_Roles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'webpages_UsersInRoles'
CREATE TABLE [dbo].[webpages_UsersInRoles] (
    [UserId] int  NOT NULL,
    [RoleId] int  NOT NULL
);
GO

-- Creating table 'WriteOffEvents'
CREATE TABLE [dbo].[WriteOffEvents] (
    [id] int  NOT NULL,
    [olb] decimal(19,4)  NOT NULL,
    [accrued_interests] decimal(19,4)  NOT NULL,
    [accrued_penalties] decimal(19,4)  NOT NULL,
    [past_due_days] int  NOT NULL,
    [overdue_principal] decimal(19,4)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [id] int  NOT NULL,
    [code] varchar(1)  NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'View_1'
CREATE TABLE [dbo].[View_1] (
    [transaction_date] datetime  NOT NULL
);
GO

-- Creating table 'vwExportTransactions'
CREATE TABLE [dbo].[vwExportTransactions] (
    [txn_date] varchar(20)  NULL,
    [elementary_id] int  NOT NULL,
    [contract_type] varchar(4)  NOT NULL,
    [contract_code] nvarchar(255)  NULL,
    [amount] varchar(20)  NULL,
    [funding_line] nvarchar(50)  NULL,
    [client_name] nvarchar(202)  NULL,
    [account] nvarchar(200)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'AccountingClosures'
ALTER TABLE [dbo].[AccountingClosures]
ADD CONSTRAINT [PK_AccountingClosures]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AccountingRules'
ALTER TABLE [dbo].[AccountingRules]
ADD CONSTRAINT [PK_AccountingRules]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AccountsCategories'
ALTER TABLE [dbo].[AccountsCategories]
ADD CONSTRAINT [PK_AccountsCategories]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ActionItems'
ALTER TABLE [dbo].[ActionItems]
ADD CONSTRAINT [PK_ActionItems]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AdvancedFields'
ALTER TABLE [dbo].[AdvancedFields]
ADD CONSTRAINT [PK_AdvancedFields]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AdvancedFieldsCollections'
ALTER TABLE [dbo].[AdvancedFieldsCollections]
ADD CONSTRAINT [PK_AdvancedFieldsCollections]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AdvancedFieldsEntities'
ALTER TABLE [dbo].[AdvancedFieldsEntities]
ADD CONSTRAINT [PK_AdvancedFieldsEntities]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AdvancedFieldsLinkEntities'
ALTER TABLE [dbo].[AdvancedFieldsLinkEntities]
ADD CONSTRAINT [PK_AdvancedFieldsLinkEntities]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AdvancedFieldsTypes'
ALTER TABLE [dbo].[AdvancedFieldsTypes]
ADD CONSTRAINT [PK_AdvancedFieldsTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AdvancedFieldsValues'
ALTER TABLE [dbo].[AdvancedFieldsValues]
ADD CONSTRAINT [PK_AdvancedFieldsValues]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [parameter], [value] in table 'AlertSettings'
ALTER TABLE [dbo].[AlertSettings]
ADD CONSTRAINT [PK_AlertSettings]
    PRIMARY KEY CLUSTERED ([parameter], [value] ASC);
GO

-- Creating primary key on [action_item_id], [role_id] in table 'AllowedRoleActions'
ALTER TABLE [dbo].[AllowedRoleActions]
ADD CONSTRAINT [PK_AllowedRoleActions]
    PRIMARY KEY CLUSTERED ([action_item_id], [role_id] ASC);
GO

-- Creating primary key on [menu_item_id], [role_id] in table 'AllowedRoleMenus'
ALTER TABLE [dbo].[AllowedRoleMenus]
ADD CONSTRAINT [PK_AllowedRoleMenus]
    PRIMARY KEY CLUSTERED ([menu_item_id], [role_id] ASC);
GO

-- Creating primary key on [cycle_id], [number] in table 'AmountCycles'
ALTER TABLE [dbo].[AmountCycles]
ADD CONSTRAINT [PK_AmountCycles]
    PRIMARY KEY CLUSTERED ([cycle_id], [number] ASC);
GO

-- Creating primary key on [id] in table 'Branches'
ALTER TABLE [dbo].[Branches]
ADD CONSTRAINT [PK_Branches]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ChartOfAccounts'
ALTER TABLE [dbo].[ChartOfAccounts]
ADD CONSTRAINT [PK_ChartOfAccounts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [branch_from_id], [branch_to_id], [client_id], [user_id] in table 'ClientBranchHistories'
ALTER TABLE [dbo].[ClientBranchHistories]
ADD CONSTRAINT [PK_ClientBranchHistories]
    PRIMARY KEY CLUSTERED ([id], [branch_from_id], [branch_to_id], [client_id], [user_id] ASC);
GO

-- Creating primary key on [id], [type_name] in table 'ClientTypes'
ALTER TABLE [dbo].[ClientTypes]
ADD CONSTRAINT [PK_ClientTypes]
    PRIMARY KEY CLUSTERED ([id], [type_name] ASC);
GO

-- Creating primary key on [id] in table 'CollateralProducts'
ALTER TABLE [dbo].[CollateralProducts]
ADD CONSTRAINT [PK_CollateralProducts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CollateralProperties'
ALTER TABLE [dbo].[CollateralProperties]
ADD CONSTRAINT [PK_CollateralProperties]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'CollateralPropertyCollections'
ALTER TABLE [dbo].[CollateralPropertyCollections]
ADD CONSTRAINT [PK_CollateralPropertyCollections]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'CollateralPropertyTypes'
ALTER TABLE [dbo].[CollateralPropertyTypes]
ADD CONSTRAINT [PK_CollateralPropertyTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CollateralPropertyValues'
ALTER TABLE [dbo].[CollateralPropertyValues]
ADD CONSTRAINT [PK_CollateralPropertyValues]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CollateralsLinkContracts'
ALTER TABLE [dbo].[CollateralsLinkContracts]
ADD CONSTRAINT [PK_CollateralsLinkContracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [branch], [date] in table 'ConsolidatedDatas'
ALTER TABLE [dbo].[ConsolidatedDatas]
ADD CONSTRAINT [PK_ConsolidatedDatas]
    PRIMARY KEY CLUSTERED ([branch], [date] ASC);
GO

-- Creating primary key on [id] in table 'ContractAccountingRules'
ALTER TABLE [dbo].[ContractAccountingRules]
ADD CONSTRAINT [PK_ContractAccountingRules]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [DateChanged], [loanofficerFrom_id], [loanofficerTo_id], [contract_id] in table 'ContractAssignHistories'
ALTER TABLE [dbo].[ContractAssignHistories]
ADD CONSTRAINT [PK_ContractAssignHistories]
    PRIMARY KEY CLUSTERED ([id], [DateChanged], [loanofficerFrom_id], [loanofficerTo_id], [contract_id] ASC);
GO

-- Creating primary key on [id] in table 'ContractEvents'
ALTER TABLE [dbo].[ContractEvents]
ADD CONSTRAINT [PK_ContractEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [corporate_id], [person_id] in table 'CorporatePersonBelongings'
ALTER TABLE [dbo].[CorporatePersonBelongings]
ADD CONSTRAINT [PK_CorporatePersonBelongings]
    PRIMARY KEY CLUSTERED ([corporate_id], [person_id] ASC);
GO

-- Creating primary key on [id] in table 'Corporates'
ALTER TABLE [dbo].[Corporates]
ADD CONSTRAINT [PK_Corporates]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [PK_Credits]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CreditEntryFees'
ALTER TABLE [dbo].[CreditEntryFees]
ADD CONSTRAINT [PK_CreditEntryFees]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [commission], [principal] in table 'CreditInsuranceEvents'
ALTER TABLE [dbo].[CreditInsuranceEvents]
ADD CONSTRAINT [PK_CreditInsuranceEvents]
    PRIMARY KEY CLUSTERED ([id], [commission], [principal] ASC);
GO

-- Creating primary key on [id] in table 'Currencies'
ALTER TABLE [dbo].[Currencies]
ADD CONSTRAINT [PK_Currencies]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CycleObjects'
ALTER TABLE [dbo].[CycleObjects]
ADD CONSTRAINT [PK_CycleObjects]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'CycleParameters'
ALTER TABLE [dbo].[CycleParameters]
ADD CONSTRAINT [PK_CycleParameters]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Cycles'
ALTER TABLE [dbo].[Cycles]
ADD CONSTRAINT [PK_Cycles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [PK_Districts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'EconomicActivities'
ALTER TABLE [dbo].[EconomicActivities]
ADD CONSTRAINT [PK_EconomicActivities]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [contract_id], [person_id], [economic_activity_id], [deleted] in table 'EconomicActivityLoanHistories'
ALTER TABLE [dbo].[EconomicActivityLoanHistories]
ADD CONSTRAINT [PK_EconomicActivityLoanHistories]
    PRIMARY KEY CLUSTERED ([contract_id], [person_id], [economic_activity_id], [deleted] ASC);
GO

-- Creating primary key on [Id] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Employers'
ALTER TABLE [dbo].[Employers]
ADD CONSTRAINT [PK_Employers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'EntryFees'
ALTER TABLE [dbo].[EntryFees]
ADD CONSTRAINT [PK_EntryFees]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'EventAttributes'
ALTER TABLE [dbo].[EventAttributes]
ADD CONSTRAINT [PK_EventAttributes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [event_type] in table 'EventTypes'
ALTER TABLE [dbo].[EventTypes]
ADD CONSTRAINT [PK_EventTypes]
    PRIMARY KEY CLUSTERED ([event_type] ASC);
GO

-- Creating primary key on [exchange_date], [exchange_rate], [currency_id] in table 'ExchangeRates'
ALTER TABLE [dbo].[ExchangeRates]
ADD CONSTRAINT [PK_ExchangeRates]
    PRIMARY KEY CLUSTERED ([exchange_date], [exchange_rate], [currency_id] ASC);
GO

-- Creating primary key on [number], [exotic_id] in table 'ExoticInstallments'
ALTER TABLE [dbo].[ExoticInstallments]
ADD CONSTRAINT [PK_ExoticInstallments]
    PRIMARY KEY CLUSTERED ([number], [exotic_id] ASC);
GO

-- Creating primary key on [id] in table 'Exotics'
ALTER TABLE [dbo].[Exotics]
ADD CONSTRAINT [PK_Exotics]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'FiscalYears'
ALTER TABLE [dbo].[FiscalYears]
ADD CONSTRAINT [PK_FiscalYears]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'FundingLineAccountingRules'
ALTER TABLE [dbo].[FundingLineAccountingRules]
ADD CONSTRAINT [PK_FundingLineAccountingRules]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'FundingLineEvents'
ALTER TABLE [dbo].[FundingLineEvents]
ADD CONSTRAINT [PK_FundingLineEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'FundingLines'
ALTER TABLE [dbo].[FundingLines]
ADD CONSTRAINT [PK_FundingLines]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [key] in table 'GeneralParameters'
ALTER TABLE [dbo].[GeneralParameters]
ADD CONSTRAINT [PK_GeneralParameters]
    PRIMARY KEY CLUSTERED ([key] ASC);
GO

-- Creating primary key on [id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [PK_Groups]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [contract_id], [event_id], [number], [expected_date], [capital_repayment], [interest_repayment], [paid_interest], [paid_capital], [paid_fees], [fees_unpaid], [pending], [start_date], [olb] in table 'InstallmentHistories'
ALTER TABLE [dbo].[InstallmentHistories]
ADD CONSTRAINT [PK_InstallmentHistories]
    PRIMARY KEY CLUSTERED ([id], [contract_id], [event_id], [number], [expected_date], [capital_repayment], [interest_repayment], [paid_interest], [paid_capital], [paid_fees], [fees_unpaid], [pending], [start_date], [olb] ASC);
GO

-- Creating primary key on [contract_id], [number] in table 'Installments'
ALTER TABLE [dbo].[Installments]
ADD CONSTRAINT [PK_Installments]
    PRIMARY KEY CLUSTERED ([contract_id], [number] ASC);
GO

-- Creating primary key on [id] in table 'InstallmentTypes'
ALTER TABLE [dbo].[InstallmentTypes]
ADD CONSTRAINT [PK_InstallmentTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [branch_id], [payment_method_id], [deleted] in table 'LinkBranchesPaymentMethods'
ALTER TABLE [dbo].[LinkBranchesPaymentMethods]
ADD CONSTRAINT [PK_LinkBranchesPaymentMethods]
    PRIMARY KEY CLUSTERED ([id], [branch_id], [payment_method_id], [deleted] ASC);
GO

-- Creating primary key on [tiers_id], [contract_id], [guarantee_amount] in table 'LinkGuarantorCredits'
ALTER TABLE [dbo].[LinkGuarantorCredits]
ADD CONSTRAINT [PK_LinkGuarantorCredits]
    PRIMARY KEY CLUSTERED ([tiers_id], [contract_id], [guarantee_amount] ASC);
GO

-- Creating primary key on [id], [package_id], [exotic_id] in table 'LinkPackagesExotics'
ALTER TABLE [dbo].[LinkPackagesExotics]
ADD CONSTRAINT [PK_LinkPackagesExotics]
    PRIMARY KEY CLUSTERED ([id], [package_id], [exotic_id] ASC);
GO

-- Creating primary key on [id] in table 'LoanAccountingMovements'
ALTER TABLE [dbo].[LoanAccountingMovements]
ADD CONSTRAINT [PK_LoanAccountingMovements]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [amount], [fees], [interest] in table 'LoanDisbursmentEvents'
ALTER TABLE [dbo].[LoanDisbursmentEvents]
ADD CONSTRAINT [PK_LoanDisbursmentEvents]
    PRIMARY KEY CLUSTERED ([id], [amount], [fees], [interest] ASC);
GO

-- Creating primary key on [id], [fee], [disbursement_event_id] in table 'LoanEntryFeeEvents'
ALTER TABLE [dbo].[LoanEntryFeeEvents]
ADD CONSTRAINT [PK_LoanEntryFeeEvents]
    PRIMARY KEY CLUSTERED ([id], [fee], [disbursement_event_id] ASC);
GO

-- Creating primary key on [id] in table 'LoanInterestAccruingEvents'
ALTER TABLE [dbo].[LoanInterestAccruingEvents]
ADD CONSTRAINT [PK_LoanInterestAccruingEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'LoanScales'
ALTER TABLE [dbo].[LoanScales]
ADD CONSTRAINT [PK_LoanScales]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [person_id], [group_id], [contract_id], [amount] in table 'LoanShareAmounts'
ALTER TABLE [dbo].[LoanShareAmounts]
ADD CONSTRAINT [PK_LoanShareAmounts]
    PRIMARY KEY CLUSTERED ([person_id], [group_id], [contract_id], [amount] ASC);
GO

-- Creating primary key on [id] in table 'LoansLinkSavingsBooks'
ALTER TABLE [dbo].[LoansLinkSavingsBooks]
ADD CONSTRAINT [PK_LoansLinkSavingsBooks]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ManualAccountingMovements'
ALTER TABLE [dbo].[ManualAccountingMovements]
ADD CONSTRAINT [PK_ManualAccountingMovements]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [component_name], [type] in table 'MenuItems'
ALTER TABLE [dbo].[MenuItems]
ADD CONSTRAINT [PK_MenuItems]
    PRIMARY KEY CLUSTERED ([id], [component_name], [type] ASC);
GO

-- Creating primary key on [id], [object_id], [type] in table 'Monitorings'
ALTER TABLE [dbo].[Monitorings]
ADD CONSTRAINT [PK_Monitorings]
    PRIMARY KEY CLUSTERED ([id], [object_id], [type] ASC);
GO

-- Creating primary key on [id] in table 'OverdueEvents'
ALTER TABLE [dbo].[OverdueEvents]
ADD CONSTRAINT [PK_OverdueEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [PK_Packages]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [client_type_id], [package_id] in table 'PackagesClientTypes'
ALTER TABLE [dbo].[PackagesClientTypes]
ADD CONSTRAINT [PK_PackagesClientTypes]
    PRIMARY KEY CLUSTERED ([id], [client_type_id], [package_id] ASC);
GO

-- Creating primary key on [id] in table 'PaymentMethods'
ALTER TABLE [dbo].[PaymentMethods]
ADD CONSTRAINT [PK_PaymentMethods]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [person_id], [group_id] in table 'PersonGroupBelongings'
ALTER TABLE [dbo].[PersonGroupBelongings]
ADD CONSTRAINT [PK_PersonGroupBelongings]
    PRIMARY KEY CLUSTERED ([person_id], [group_id] ASC);
GO

-- Creating primary key on [id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [PK_Persons]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [person_id], [picture_id] in table 'PersonsPhotos'
ALTER TABLE [dbo].[PersonsPhotos]
ADD CONSTRAINT [PK_PersonsPhotos]
    PRIMARY KEY CLUSTERED ([id], [person_id], [picture_id] ASC);
GO

-- Creating primary key on [id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Provinces'
ALTER TABLE [dbo].[Provinces]
ADD CONSTRAINT [PK_Provinces]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ProvisionEvents'
ALTER TABLE [dbo].[ProvisionEvents]
ADD CONSTRAINT [PK_ProvisionEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ProvisioningRules'
ALTER TABLE [dbo].[ProvisioningRules]
ADD CONSTRAINT [PK_ProvisioningRules]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [date], [name] in table 'PublicHolidays'
ALTER TABLE [dbo].[PublicHolidays]
ADD CONSTRAINT [PK_PublicHolidays]
    PRIMARY KEY CLUSTERED ([date], [name] ASC);
GO

-- Creating primary key on [is_sent] in table 'Questionnaires'
ALTER TABLE [dbo].[Questionnaires]
ADD CONSTRAINT [PK_Questionnaires]
    PRIMARY KEY CLUSTERED ([is_sent] ASC);
GO

-- Creating primary key on [id] in table 'Rep_Active_Loans_Data'
ALTER TABLE [dbo].[Rep_Active_Loans_Data]
ADD CONSTRAINT [PK_Rep_Active_Loans_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rep_Disbursements_Data'
ALTER TABLE [dbo].[Rep_Disbursements_Data]
ADD CONSTRAINT [PK_Rep_Disbursements_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rep_OLB_and_LLP_Data'
ALTER TABLE [dbo].[Rep_OLB_and_LLP_Data]
ADD CONSTRAINT [PK_Rep_OLB_and_LLP_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rep_Par_Analysis_Data'
ALTER TABLE [dbo].[Rep_Par_Analysis_Data]
ADD CONSTRAINT [PK_Rep_Par_Analysis_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rep_Repayments_Data'
ALTER TABLE [dbo].[Rep_Repayments_Data]
ADD CONSTRAINT [PK_Rep_Repayments_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Rep_Rescheduled_Loans_Data'
ALTER TABLE [dbo].[Rep_Rescheduled_Loans_Data]
ADD CONSTRAINT [PK_Rep_Rescheduled_Loans_Data]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [past_due_days], [principal], [interests], [installment_number], [commissions], [penalties], [calculated_penalties], [written_off_penalties], [unpaid_penalties] in table 'RepaymentEvents'
ALTER TABLE [dbo].[RepaymentEvents]
ADD CONSTRAINT [PK_RepaymentEvents]
    PRIMARY KEY CLUSTERED ([id], [past_due_days], [principal], [interests], [installment_number], [commissions], [penalties], [calculated_penalties], [written_off_penalties], [unpaid_penalties] ASC);
GO

-- Creating primary key on [id] in table 'ReschedulingOfALoanEvents'
ALTER TABLE [dbo].[ReschedulingOfALoanEvents]
ADD CONSTRAINT [PK_ReschedulingOfALoanEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SavingBookContracts'
ALTER TABLE [dbo].[SavingBookContracts]
ADD CONSTRAINT [PK_SavingBookContracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SavingBookProducts'
ALTER TABLE [dbo].[SavingBookProducts]
ADD CONSTRAINT [PK_SavingBookProducts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SavingContracts'
ALTER TABLE [dbo].[SavingContracts]
ADD CONSTRAINT [PK_SavingContracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SavingDepositContracts'
ALTER TABLE [dbo].[SavingDepositContracts]
ADD CONSTRAINT [PK_SavingDepositContracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SavingEvents'
ALTER TABLE [dbo].[SavingEvents]
ADD CONSTRAINT [PK_SavingEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'SavingProducts'
ALTER TABLE [dbo].[SavingProducts]
ADD CONSTRAINT [PK_SavingProducts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [saving_product_id], [client_type_id] in table 'SavingProductsClientTypes'
ALTER TABLE [dbo].[SavingProductsClientTypes]
ADD CONSTRAINT [PK_SavingProductsClientTypes]
    PRIMARY KEY CLUSTERED ([id], [saving_product_id], [client_type_id] ASC);
GO

-- Creating primary key on [id] in table 'SavingsAccountingMovements'
ALTER TABLE [dbo].[SavingsAccountingMovements]
ADD CONSTRAINT [PK_SavingsAccountingMovements]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [SSKey] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [PK_Settings]
    PRIMARY KEY CLUSTERED ([SSKey] ASC);
GO

-- Creating primary key on [Id] in table 'SettingsGroups'
ALTER TABLE [dbo].[SettingsGroups]
ADD CONSTRAINT [PK_SettingsGroups]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SmsMessageStores'
ALTER TABLE [dbo].[SmsMessageStores]
ADD CONSTRAINT [PK_SmsMessageStores]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spAllowedReportsRolesMenus'
ALTER TABLE [dbo].[spAllowedReportsRolesMenus]
ADD CONSTRAINT [PK_spAllowedReportsRolesMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spAllowedRoleMenus'
ALTER TABLE [dbo].[spAllowedRoleMenus]
ADD CONSTRAINT [PK_spAllowedRoleMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spAllowedRoleMenuswebs'
ALTER TABLE [dbo].[spAllowedRoleMenuswebs]
ADD CONSTRAINT [PK_spAllowedRoleMenuswebs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spMenuItems'
ALTER TABLE [dbo].[spMenuItems]
ADD CONSTRAINT [PK_spMenuItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spMenus'
ALTER TABLE [dbo].[spMenus]
ADD CONSTRAINT [PK_spMenus]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spReportsMenuItems'
ALTER TABLE [dbo].[spReportsMenuItems]
ADD CONSTRAINT [PK_spReportsMenuItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spRoles'
ALTER TABLE [dbo].[spRoles]
ADD CONSTRAINT [PK_spRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'spUsers'
ALTER TABLE [dbo].[spUsers]
ADD CONSTRAINT [PK_spUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'spUsersInRoles'
ALTER TABLE [dbo].[spUsersInRoles]
ADD CONSTRAINT [PK_spUsersInRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- Creating primary key on [Id] in table 'StandardBookings'
ALTER TABLE [dbo].[StandardBookings]
ADD CONSTRAINT [PK_StandardBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'Statuses'
ALTER TABLE [dbo].[Statuses]
ADD CONSTRAINT [PK_Statuses]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [name] in table 'TechnicalParameters'
ALTER TABLE [dbo].[TechnicalParameters]
ADD CONSTRAINT [PK_TechnicalParameters]
    PRIMARY KEY CLUSTERED ([name] ASC);
GO

-- Creating primary key on [Id] in table 'TechParams'
ALTER TABLE [dbo].[TechParams]
ADD CONSTRAINT [PK_TechParams]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [id] in table 'TellerEvents'
ALTER TABLE [dbo].[TellerEvents]
ADD CONSTRAINT [PK_TellerEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tellers'
ALTER TABLE [dbo].[Tellers]
ADD CONSTRAINT [PK_Tellers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TermDepositProducts'
ALTER TABLE [dbo].[TermDepositProducts]
ADD CONSTRAINT [PK_TermDepositProducts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Tiers'
ALTER TABLE [dbo].[Tiers]
ADD CONSTRAINT [PK_Tiers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TraceUserLogs'
ALTER TABLE [dbo].[TraceUserLogs]
ADD CONSTRAINT [PK_TraceUserLogs]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TrancheEvents'
ALTER TABLE [dbo].[TrancheEvents]
ADD CONSTRAINT [PK_TrancheEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [Id] in table 'TransactionsAuthorizations'
ALTER TABLE [dbo].[TransactionsAuthorizations]
ADD CONSTRAINT [PK_TransactionsAuthorizations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId] in table 'UserProfiles'
ALTER TABLE [dbo].[UserProfiles]
ADD CONSTRAINT [PK_UserProfiles]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [role_id], [user_id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([role_id], [user_id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [user_id], [branch_id] in table 'UsersBranches'
ALTER TABLE [dbo].[UsersBranches]
ADD CONSTRAINT [PK_UsersBranches]
    PRIMARY KEY CLUSTERED ([user_id], [branch_id] ASC);
GO

-- Creating primary key on [user_id], [subordinate_id] in table 'UsersSubordinates'
ALTER TABLE [dbo].[UsersSubordinates]
ADD CONSTRAINT [PK_UsersSubordinates]
    PRIMARY KEY CLUSTERED ([user_id], [subordinate_id] ASC);
GO

-- Creating primary key on [id] in table 'Villages'
ALTER TABLE [dbo].[Villages]
ADD CONSTRAINT [PK_Villages]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'VillagesAttendances'
ALTER TABLE [dbo].[VillagesAttendances]
ADD CONSTRAINT [PK_VillagesAttendances]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [village_id], [person_id] in table 'VillagesPersons'
ALTER TABLE [dbo].[VillagesPersons]
ADD CONSTRAINT [PK_VillagesPersons]
    PRIMARY KEY CLUSTERED ([village_id], [person_id] ASC);
GO

-- Creating primary key on [UserId] in table 'webpages_Membership'
ALTER TABLE [dbo].[webpages_Membership]
ADD CONSTRAINT [PK_webpages_Membership]
    PRIMARY KEY CLUSTERED ([UserId] ASC);
GO

-- Creating primary key on [Provider], [ProviderUserId] in table 'webpages_OAuthMembership'
ALTER TABLE [dbo].[webpages_OAuthMembership]
ADD CONSTRAINT [PK_webpages_OAuthMembership]
    PRIMARY KEY CLUSTERED ([Provider], [ProviderUserId] ASC);
GO

-- Creating primary key on [RoleId] in table 'webpages_Roles'
ALTER TABLE [dbo].[webpages_Roles]
ADD CONSTRAINT [PK_webpages_Roles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserId], [RoleId] in table 'webpages_UsersInRoles'
ALTER TABLE [dbo].[webpages_UsersInRoles]
ADD CONSTRAINT [PK_webpages_UsersInRoles]
    PRIMARY KEY CLUSTERED ([UserId], [RoleId] ASC);
GO

-- Creating primary key on [id] in table 'WriteOffEvents'
ALTER TABLE [dbo].[WriteOffEvents]
ADD CONSTRAINT [PK_WriteOffEvents]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [code], [name] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([id], [code], [name] ASC);
GO

-- Creating primary key on [transaction_date] in table 'View_1'
ALTER TABLE [dbo].[View_1]
ADD CONSTRAINT [PK_View_1]
    PRIMARY KEY CLUSTERED ([transaction_date] ASC);
GO

-- Creating primary key on [elementary_id], [contract_type], [account] in table 'vwExportTransactions'
ALTER TABLE [dbo].[vwExportTransactions]
ADD CONSTRAINT [PK_vwExportTransactions]
    PRIMARY KEY CLUSTERED ([elementary_id], [contract_type], [account] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [debit_account_number_id] in table 'AccountingRules'
ALTER TABLE [dbo].[AccountingRules]
ADD CONSTRAINT [FK_AccountingRules_ChartOfAccounts]
    FOREIGN KEY ([debit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountingRules_ChartOfAccounts'
CREATE INDEX [IX_FK_AccountingRules_ChartOfAccounts]
ON [dbo].[AccountingRules]
    ([debit_account_number_id]);
GO

-- Creating foreign key on [credit_account_number_id] in table 'AccountingRules'
ALTER TABLE [dbo].[AccountingRules]
ADD CONSTRAINT [FK_AccountingRules_ChartOfAccounts1]
    FOREIGN KEY ([credit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountingRules_ChartOfAccounts1'
CREATE INDEX [IX_FK_AccountingRules_ChartOfAccounts1]
ON [dbo].[AccountingRules]
    ([credit_account_number_id]);
GO

-- Creating foreign key on [event_attribute_id] in table 'AccountingRules'
ALTER TABLE [dbo].[AccountingRules]
ADD CONSTRAINT [FK_AccountingRules_EventAttributes]
    FOREIGN KEY ([event_attribute_id])
    REFERENCES [dbo].[EventAttributes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountingRules_EventAttributes'
CREATE INDEX [IX_FK_AccountingRules_EventAttributes]
ON [dbo].[AccountingRules]
    ([event_attribute_id]);
GO

-- Creating foreign key on [event_type] in table 'AccountingRules'
ALTER TABLE [dbo].[AccountingRules]
ADD CONSTRAINT [FK_AccountingRules_EventTypes]
    FOREIGN KEY ([event_type])
    REFERENCES [dbo].[EventTypes]
        ([event_type])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountingRules_EventTypes'
CREATE INDEX [IX_FK_AccountingRules_EventTypes]
ON [dbo].[AccountingRules]
    ([event_type]);
GO

-- Creating foreign key on [id] in table 'ContractAccountingRules'
ALTER TABLE [dbo].[ContractAccountingRules]
ADD CONSTRAINT [FK_ContractAccountingRules_AccountingRules]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[AccountingRules]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'FundingLineAccountingRules'
ALTER TABLE [dbo].[FundingLineAccountingRules]
ADD CONSTRAINT [FK_FundingLineAccountingRules_AccountingRules]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[AccountingRules]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [account_category_id] in table 'ChartOfAccounts'
ALTER TABLE [dbo].[ChartOfAccounts]
ADD CONSTRAINT [FK_ChartOfAccounts_AccountsCategory]
    FOREIGN KEY ([account_category_id])
    REFERENCES [dbo].[AccountsCategories]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ChartOfAccounts_AccountsCategory'
CREATE INDEX [IX_FK_ChartOfAccounts_AccountsCategory]
ON [dbo].[ChartOfAccounts]
    ([account_category_id]);
GO

-- Creating foreign key on [action_item_id] in table 'AllowedRoleActions'
ALTER TABLE [dbo].[AllowedRoleActions]
ADD CONSTRAINT [FK_AllowedRoleActions_ActionItems]
    FOREIGN KEY ([action_item_id])
    REFERENCES [dbo].[ActionItems]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [entity_id] in table 'AdvancedFields'
ALTER TABLE [dbo].[AdvancedFields]
ADD CONSTRAINT [FK_AdvancedFields_AdvancedFieldsEntities]
    FOREIGN KEY ([entity_id])
    REFERENCES [dbo].[AdvancedFieldsEntities]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvancedFields_AdvancedFieldsEntities'
CREATE INDEX [IX_FK_AdvancedFields_AdvancedFieldsEntities]
ON [dbo].[AdvancedFields]
    ([entity_id]);
GO

-- Creating foreign key on [type_id] in table 'AdvancedFields'
ALTER TABLE [dbo].[AdvancedFields]
ADD CONSTRAINT [FK_AdvancedFields_AdvancedFieldsTypes]
    FOREIGN KEY ([type_id])
    REFERENCES [dbo].[AdvancedFieldsTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvancedFields_AdvancedFieldsTypes'
CREATE INDEX [IX_FK_AdvancedFields_AdvancedFieldsTypes]
ON [dbo].[AdvancedFields]
    ([type_id]);
GO

-- Creating foreign key on [field_id] in table 'AdvancedFieldsCollections'
ALTER TABLE [dbo].[AdvancedFieldsCollections]
ADD CONSTRAINT [FK_AdvancedFieldsCollections_AdvancedFields]
    FOREIGN KEY ([field_id])
    REFERENCES [dbo].[AdvancedFields]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvancedFieldsCollections_AdvancedFields'
CREATE INDEX [IX_FK_AdvancedFieldsCollections_AdvancedFields]
ON [dbo].[AdvancedFieldsCollections]
    ([field_id]);
GO

-- Creating foreign key on [field_id] in table 'AdvancedFieldsValues'
ALTER TABLE [dbo].[AdvancedFieldsValues]
ADD CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFields]
    FOREIGN KEY ([field_id])
    REFERENCES [dbo].[AdvancedFields]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvancedFieldsValues_AdvancedFields'
CREATE INDEX [IX_FK_AdvancedFieldsValues_AdvancedFields]
ON [dbo].[AdvancedFieldsValues]
    ([field_id]);
GO

-- Creating foreign key on [entity_field_id] in table 'AdvancedFieldsValues'
ALTER TABLE [dbo].[AdvancedFieldsValues]
ADD CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFieldsLinkEntities]
    FOREIGN KEY ([entity_field_id])
    REFERENCES [dbo].[AdvancedFieldsLinkEntities]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvancedFieldsValues_AdvancedFieldsLinkEntities'
CREATE INDEX [IX_FK_AdvancedFieldsValues_AdvancedFieldsLinkEntities]
ON [dbo].[AdvancedFieldsValues]
    ([entity_field_id]);
GO

-- Creating foreign key on [action_item_id], [role_id] in table 'AllowedRoleActions'
ALTER TABLE [dbo].[AllowedRoleActions]
ADD CONSTRAINT [FK_AllowedRoleActions_AllowedRoleActions]
    FOREIGN KEY ([action_item_id], [role_id])
    REFERENCES [dbo].[AllowedRoleActions]
        ([action_item_id], [role_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [role_id] in table 'AllowedRoleActions'
ALTER TABLE [dbo].[AllowedRoleActions]
ADD CONSTRAINT [FK_AllowedRoleActions_Roles]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[Roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AllowedRoleActions_Roles'
CREATE INDEX [IX_FK_AllowedRoleActions_Roles]
ON [dbo].[AllowedRoleActions]
    ([role_id]);
GO

-- Creating foreign key on [role_id] in table 'AllowedRoleMenus'
ALTER TABLE [dbo].[AllowedRoleMenus]
ADD CONSTRAINT [FK_AllowedRoleMenus_Roles]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[Roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AllowedRoleMenus_Roles'
CREATE INDEX [IX_FK_AllowedRoleMenus_Roles]
ON [dbo].[AllowedRoleMenus]
    ([role_id]);
GO

-- Creating foreign key on [cycle_id] in table 'AmountCycles'
ALTER TABLE [dbo].[AmountCycles]
ADD CONSTRAINT [FK_AmountCycles_Cycles]
    FOREIGN KEY ([cycle_id])
    REFERENCES [dbo].[Cycles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [branch_from_id] in table 'ClientBranchHistories'
ALTER TABLE [dbo].[ClientBranchHistories]
ADD CONSTRAINT [FK_ClientBranchHistory_Branches]
    FOREIGN KEY ([branch_from_id])
    REFERENCES [dbo].[Branches]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientBranchHistory_Branches'
CREATE INDEX [IX_FK_ClientBranchHistory_Branches]
ON [dbo].[ClientBranchHistories]
    ([branch_from_id]);
GO

-- Creating foreign key on [branch_id] in table 'Tellers'
ALTER TABLE [dbo].[Tellers]
ADD CONSTRAINT [FK_Tellers_Branches]
    FOREIGN KEY ([branch_id])
    REFERENCES [dbo].[Branches]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tellers_Branches'
CREATE INDEX [IX_FK_Tellers_Branches]
ON [dbo].[Tellers]
    ([branch_id]);
GO

-- Creating foreign key on [debit_account_number_id] in table 'LoanAccountingMovements'
ALTER TABLE [dbo].[LoanAccountingMovements]
ADD CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts]
    FOREIGN KEY ([debit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LoanAccountingMovements_ChartOfAccounts'
CREATE INDEX [IX_FK_LoanAccountingMovements_ChartOfAccounts]
ON [dbo].[LoanAccountingMovements]
    ([debit_account_number_id]);
GO

-- Creating foreign key on [credit_account_number_id] in table 'LoanAccountingMovements'
ALTER TABLE [dbo].[LoanAccountingMovements]
ADD CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts1]
    FOREIGN KEY ([credit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LoanAccountingMovements_ChartOfAccounts1'
CREATE INDEX [IX_FK_LoanAccountingMovements_ChartOfAccounts1]
ON [dbo].[LoanAccountingMovements]
    ([credit_account_number_id]);
GO

-- Creating foreign key on [debit_account_number_id] in table 'ManualAccountingMovements'
ALTER TABLE [dbo].[ManualAccountingMovements]
ADD CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts]
    FOREIGN KEY ([debit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManualAccountingMovements_ChartOfAccounts'
CREATE INDEX [IX_FK_ManualAccountingMovements_ChartOfAccounts]
ON [dbo].[ManualAccountingMovements]
    ([debit_account_number_id]);
GO

-- Creating foreign key on [credit_account_number_id] in table 'ManualAccountingMovements'
ALTER TABLE [dbo].[ManualAccountingMovements]
ADD CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts1]
    FOREIGN KEY ([credit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ManualAccountingMovements_ChartOfAccounts1'
CREATE INDEX [IX_FK_ManualAccountingMovements_ChartOfAccounts1]
ON [dbo].[ManualAccountingMovements]
    ([credit_account_number_id]);
GO

-- Creating foreign key on [debit_account_number_id] in table 'SavingsAccountingMovements'
ALTER TABLE [dbo].[SavingsAccountingMovements]
ADD CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts]
    FOREIGN KEY ([debit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingsAccountingMovements_ChartOfAccounts'
CREATE INDEX [IX_FK_SavingsAccountingMovements_ChartOfAccounts]
ON [dbo].[SavingsAccountingMovements]
    ([debit_account_number_id]);
GO

-- Creating foreign key on [credit_account_number_id] in table 'SavingsAccountingMovements'
ALTER TABLE [dbo].[SavingsAccountingMovements]
ADD CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts1]
    FOREIGN KEY ([credit_account_number_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingsAccountingMovements_ChartOfAccounts1'
CREATE INDEX [IX_FK_SavingsAccountingMovements_ChartOfAccounts1]
ON [dbo].[SavingsAccountingMovements]
    ([credit_account_number_id]);
GO

-- Creating foreign key on [debit_account_id] in table 'StandardBookings'
ALTER TABLE [dbo].[StandardBookings]
ADD CONSTRAINT [FK_StandardBookings_ChartOfAccounts]
    FOREIGN KEY ([debit_account_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StandardBookings_ChartOfAccounts'
CREATE INDEX [IX_FK_StandardBookings_ChartOfAccounts]
ON [dbo].[StandardBookings]
    ([debit_account_id]);
GO

-- Creating foreign key on [credit_account_id] in table 'StandardBookings'
ALTER TABLE [dbo].[StandardBookings]
ADD CONSTRAINT [FK_StandardBookings_ChartOfAccounts1]
    FOREIGN KEY ([credit_account_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_StandardBookings_ChartOfAccounts1'
CREATE INDEX [IX_FK_StandardBookings_ChartOfAccounts1]
ON [dbo].[StandardBookings]
    ([credit_account_id]);
GO

-- Creating foreign key on [account_id] in table 'Tellers'
ALTER TABLE [dbo].[Tellers]
ADD CONSTRAINT [FK_Tellers_ChartOfAccounts]
    FOREIGN KEY ([account_id])
    REFERENCES [dbo].[ChartOfAccounts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tellers_ChartOfAccounts'
CREATE INDEX [IX_FK_Tellers_ChartOfAccounts]
ON [dbo].[Tellers]
    ([account_id]);
GO

-- Creating foreign key on [district_id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [FK_City_Districts]
    FOREIGN KEY ([district_id])
    REFERENCES [dbo].[Districts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_City_Districts'
CREATE INDEX [IX_FK_City_Districts]
ON [dbo].[Cities]
    ([district_id]);
GO

-- Creating foreign key on [client_id] in table 'ClientBranchHistories'
ALTER TABLE [dbo].[ClientBranchHistories]
ADD CONSTRAINT [FK_ClientBranchHistory_Tiers]
    FOREIGN KEY ([client_id])
    REFERENCES [dbo].[Tiers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientBranchHistory_Tiers'
CREATE INDEX [IX_FK_ClientBranchHistory_Tiers]
ON [dbo].[ClientBranchHistories]
    ([client_id]);
GO

-- Creating foreign key on [user_id] in table 'ClientBranchHistories'
ALTER TABLE [dbo].[ClientBranchHistories]
ADD CONSTRAINT [FK_ClientBranchHistory_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientBranchHistory_Users'
CREATE INDEX [IX_FK_ClientBranchHistory_Users]
ON [dbo].[ClientBranchHistories]
    ([user_id]);
GO

-- Creating foreign key on [product_id] in table 'CollateralProperties'
ALTER TABLE [dbo].[CollateralProperties]
ADD CONSTRAINT [FK_CollateralProperties_CollateralProducts]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[CollateralProducts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollateralProperties_CollateralProducts'
CREATE INDEX [IX_FK_CollateralProperties_CollateralProducts]
ON [dbo].[CollateralProperties]
    ([product_id]);
GO

-- Creating foreign key on [type_id] in table 'CollateralProperties'
ALTER TABLE [dbo].[CollateralProperties]
ADD CONSTRAINT [FK_CollateralProperties_CollateralPropertyTypes]
    FOREIGN KEY ([type_id])
    REFERENCES [dbo].[CollateralPropertyTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollateralProperties_CollateralPropertyTypes'
CREATE INDEX [IX_FK_CollateralProperties_CollateralPropertyTypes]
ON [dbo].[CollateralProperties]
    ([type_id]);
GO

-- Creating foreign key on [property_id] in table 'CollateralPropertyCollections'
ALTER TABLE [dbo].[CollateralPropertyCollections]
ADD CONSTRAINT [FK_CollateralPropertyCollections_CollateralProperties]
    FOREIGN KEY ([property_id])
    REFERENCES [dbo].[CollateralProperties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollateralPropertyCollections_CollateralProperties'
CREATE INDEX [IX_FK_CollateralPropertyCollections_CollateralProperties]
ON [dbo].[CollateralPropertyCollections]
    ([property_id]);
GO

-- Creating foreign key on [property_id] in table 'CollateralPropertyValues'
ALTER TABLE [dbo].[CollateralPropertyValues]
ADD CONSTRAINT [FK_CollateralPropertyValues_CollateralProperties]
    FOREIGN KEY ([property_id])
    REFERENCES [dbo].[CollateralProperties]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollateralPropertyValues_CollateralProperties'
CREATE INDEX [IX_FK_CollateralPropertyValues_CollateralProperties]
ON [dbo].[CollateralPropertyValues]
    ([property_id]);
GO

-- Creating foreign key on [contract_collateral_id] in table 'CollateralPropertyValues'
ALTER TABLE [dbo].[CollateralPropertyValues]
ADD CONSTRAINT [FK_CollateralPropertyValues_CollateralsLinkContracts]
    FOREIGN KEY ([contract_collateral_id])
    REFERENCES [dbo].[CollateralsLinkContracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollateralPropertyValues_CollateralsLinkContracts'
CREATE INDEX [IX_FK_CollateralPropertyValues_CollateralsLinkContracts]
ON [dbo].[CollateralPropertyValues]
    ([contract_collateral_id]);
GO

-- Creating foreign key on [contract_id] in table 'CollateralsLinkContracts'
ALTER TABLE [dbo].[CollateralsLinkContracts]
ADD CONSTRAINT [FK_CollateralsLinkContracts_Contracts]
    FOREIGN KEY ([contract_id])
    REFERENCES [dbo].[Contracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CollateralsLinkContracts_Contracts'
CREATE INDEX [IX_FK_CollateralsLinkContracts_Contracts]
ON [dbo].[CollateralsLinkContracts]
    ([contract_id]);
GO

-- Creating foreign key on [activity_id] in table 'ContractAccountingRules'
ALTER TABLE [dbo].[ContractAccountingRules]
ADD CONSTRAINT [FK_ContractAccountingRules_DomainOfApplications]
    FOREIGN KEY ([activity_id])
    REFERENCES [dbo].[EconomicActivities]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractAccountingRules_DomainOfApplications'
CREATE INDEX [IX_FK_ContractAccountingRules_DomainOfApplications]
ON [dbo].[ContractAccountingRules]
    ([activity_id]);
GO

-- Creating foreign key on [loan_product_id] in table 'ContractAccountingRules'
ALTER TABLE [dbo].[ContractAccountingRules]
ADD CONSTRAINT [FK_ContractAccountingRules_Packages]
    FOREIGN KEY ([loan_product_id])
    REFERENCES [dbo].[Packages]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractAccountingRules_Packages'
CREATE INDEX [IX_FK_ContractAccountingRules_Packages]
ON [dbo].[ContractAccountingRules]
    ([loan_product_id]);
GO

-- Creating foreign key on [savings_product_id] in table 'ContractAccountingRules'
ALTER TABLE [dbo].[ContractAccountingRules]
ADD CONSTRAINT [FK_ContractAccountingRules_SavingProducts]
    FOREIGN KEY ([savings_product_id])
    REFERENCES [dbo].[SavingProducts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractAccountingRules_SavingProducts'
CREATE INDEX [IX_FK_ContractAccountingRules_SavingProducts]
ON [dbo].[ContractAccountingRules]
    ([savings_product_id]);
GO

-- Creating foreign key on [contract_id] in table 'ContractAssignHistories'
ALTER TABLE [dbo].[ContractAssignHistories]
ADD CONSTRAINT [FK_ContractAssignHistory_Contracts]
    FOREIGN KEY ([contract_id])
    REFERENCES [dbo].[Contracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractAssignHistory_Contracts'
CREATE INDEX [IX_FK_ContractAssignHistory_Contracts]
ON [dbo].[ContractAssignHistories]
    ([contract_id]);
GO

-- Creating foreign key on [loanofficerFrom_id] in table 'ContractAssignHistories'
ALTER TABLE [dbo].[ContractAssignHistories]
ADD CONSTRAINT [FK_ContractAssignHistory_Users]
    FOREIGN KEY ([loanofficerFrom_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractAssignHistory_Users'
CREATE INDEX [IX_FK_ContractAssignHistory_Users]
ON [dbo].[ContractAssignHistories]
    ([loanofficerFrom_id]);
GO

-- Creating foreign key on [loanofficerTo_id] in table 'ContractAssignHistories'
ALTER TABLE [dbo].[ContractAssignHistories]
ADD CONSTRAINT [FK_ContractAssignHistory_Users1]
    FOREIGN KEY ([loanofficerTo_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractAssignHistory_Users1'
CREATE INDEX [IX_FK_ContractAssignHistory_Users1]
ON [dbo].[ContractAssignHistories]
    ([loanofficerTo_id]);
GO

-- Creating foreign key on [contract_id] in table 'ContractEvents'
ALTER TABLE [dbo].[ContractEvents]
ADD CONSTRAINT [FK_ContractEvents_Contracts]
    FOREIGN KEY ([contract_id])
    REFERENCES [dbo].[Contracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractEvents_Contracts'
CREATE INDEX [IX_FK_ContractEvents_Contracts]
ON [dbo].[ContractEvents]
    ([contract_id]);
GO

-- Creating foreign key on [id] in table 'ContractEvents'
ALTER TABLE [dbo].[ContractEvents]
ADD CONSTRAINT [FK_ContractEvents_LoanInterestAccruingEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[LoanInterestAccruingEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [teller_id] in table 'ContractEvents'
ALTER TABLE [dbo].[ContractEvents]
ADD CONSTRAINT [FK_ContractEvents_Tellers]
    FOREIGN KEY ([teller_id])
    REFERENCES [dbo].[Tellers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractEvents_Tellers'
CREATE INDEX [IX_FK_ContractEvents_Tellers]
ON [dbo].[ContractEvents]
    ([teller_id]);
GO

-- Creating foreign key on [user_id] in table 'ContractEvents'
ALTER TABLE [dbo].[ContractEvents]
ADD CONSTRAINT [FK_ContractEvents_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ContractEvents_Users'
CREATE INDEX [IX_FK_ContractEvents_Users]
ON [dbo].[ContractEvents]
    ([user_id]);
GO

-- Creating foreign key on [event_id] in table 'InstallmentHistories'
ALTER TABLE [dbo].[InstallmentHistories]
ADD CONSTRAINT [FK_InstallmentHistory_ContractEvents]
    FOREIGN KEY ([event_id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InstallmentHistory_ContractEvents'
CREATE INDEX [IX_FK_InstallmentHistory_ContractEvents]
ON [dbo].[InstallmentHistories]
    ([event_id]);
GO

-- Creating foreign key on [id] in table 'LoanDisbursmentEvents'
ALTER TABLE [dbo].[LoanDisbursmentEvents]
ADD CONSTRAINT [FK_LoanDisbursmentEvents_ContractEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'OverdueEvents'
ALTER TABLE [dbo].[OverdueEvents]
ADD CONSTRAINT [FK_OverdueEvents_ContractEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'ProvisionEvents'
ALTER TABLE [dbo].[ProvisionEvents]
ADD CONSTRAINT [FK_ProvisionEvents_ContractEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'RepaymentEvents'
ALTER TABLE [dbo].[RepaymentEvents]
ADD CONSTRAINT [FK_RepaymentEvents_ContractEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'ReschedulingOfALoanEvents'
ALTER TABLE [dbo].[ReschedulingOfALoanEvents]
ADD CONSTRAINT [FK_ReschedulingOfALoanEvents_ContractEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'TrancheEvents'
ALTER TABLE [dbo].[TrancheEvents]
ADD CONSTRAINT [FK_TrancheEvents_ContractEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'WriteOffEvents'
ALTER TABLE [dbo].[WriteOffEvents]
ADD CONSTRAINT [FK_WriteOffEvents_ContractEvents]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[ContractEvents]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [activity_id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_Contracts_EconomicActivities]
    FOREIGN KEY ([activity_id])
    REFERENCES [dbo].[EconomicActivities]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Contracts_EconomicActivities'
CREATE INDEX [IX_FK_Contracts_EconomicActivities]
ON [dbo].[Contracts]
    ([activity_id]);
GO

-- Creating foreign key on [project_id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_Contracts_Projects]
    FOREIGN KEY ([project_id])
    REFERENCES [dbo].[Projects]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Contracts_Projects'
CREATE INDEX [IX_FK_Contracts_Projects]
ON [dbo].[Contracts]
    ([project_id]);
GO

-- Creating foreign key on [nsg_id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [FK_Contracts_Villages]
    FOREIGN KEY ([nsg_id])
    REFERENCES [dbo].[Villages]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Contracts_Villages'
CREATE INDEX [IX_FK_Contracts_Villages]
ON [dbo].[Contracts]
    ([nsg_id]);
GO

-- Creating foreign key on [id] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_Credit_Contracts]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Contracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [contract_id] in table 'LinkGuarantorCredits'
ALTER TABLE [dbo].[LinkGuarantorCredits]
ADD CONSTRAINT [FK_LinkGuarantorCredit_Contracts]
    FOREIGN KEY ([contract_id])
    REFERENCES [dbo].[Contracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LinkGuarantorCredit_Contracts'
CREATE INDEX [IX_FK_LinkGuarantorCredit_Contracts]
ON [dbo].[LinkGuarantorCredits]
    ([contract_id]);
GO

-- Creating foreign key on [loan_id] in table 'LoansLinkSavingsBooks'
ALTER TABLE [dbo].[LoansLinkSavingsBooks]
ADD CONSTRAINT [FK_LoansLinkSavingsBook_Contracts]
    FOREIGN KEY ([loan_id])
    REFERENCES [dbo].[Contracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LoansLinkSavingsBook_Contracts'
CREATE INDEX [IX_FK_LoansLinkSavingsBook_Contracts]
ON [dbo].[LoansLinkSavingsBooks]
    ([loan_id]);
GO

-- Creating foreign key on [corporate_id] in table 'CorporatePersonBelongings'
ALTER TABLE [dbo].[CorporatePersonBelongings]
ADD CONSTRAINT [FK_CorporatePersonBelonging_Corporates]
    FOREIGN KEY ([corporate_id])
    REFERENCES [dbo].[Corporates]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [person_id] in table 'CorporatePersonBelongings'
ALTER TABLE [dbo].[CorporatePersonBelongings]
ADD CONSTRAINT [FK_CorporatePersonBelonging_Persons]
    FOREIGN KEY ([person_id])
    REFERENCES [dbo].[Persons]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CorporatePersonBelonging_Persons'
CREATE INDEX [IX_FK_CorporatePersonBelonging_Persons]
ON [dbo].[CorporatePersonBelongings]
    ([person_id]);
GO

-- Creating foreign key on [activity_id] in table 'Corporates'
ALTER TABLE [dbo].[Corporates]
ADD CONSTRAINT [FK_Corporates_DomainOfApplications]
    FOREIGN KEY ([activity_id])
    REFERENCES [dbo].[EconomicActivities]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Corporates_DomainOfApplications'
CREATE INDEX [IX_FK_Corporates_DomainOfApplications]
ON [dbo].[Corporates]
    ([activity_id]);
GO

-- Creating foreign key on [installment_type] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_Credit_InstallmentTypes]
    FOREIGN KEY ([installment_type])
    REFERENCES [dbo].[InstallmentTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Credit_InstallmentTypes'
CREATE INDEX [IX_FK_Credit_InstallmentTypes]
ON [dbo].[Credits]
    ([installment_type]);
GO

-- Creating foreign key on [package_id] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_Credit_Packages]
    FOREIGN KEY ([package_id])
    REFERENCES [dbo].[Packages]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Credit_Packages'
CREATE INDEX [IX_FK_Credit_Packages]
ON [dbo].[Credits]
    ([package_id]);
GO

-- Creating foreign key on [fundingLine_id] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_Credit_Temp_FundingLines]
    FOREIGN KEY ([fundingLine_id])
    REFERENCES [dbo].[FundingLines]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Credit_Temp_FundingLines'
CREATE INDEX [IX_FK_Credit_Temp_FundingLines]
ON [dbo].[Credits]
    ([fundingLine_id]);
GO

-- Creating foreign key on [loanofficer_id] in table 'Credits'
ALTER TABLE [dbo].[Credits]
ADD CONSTRAINT [FK_Credit_Users]
    FOREIGN KEY ([loanofficer_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Credit_Users'
CREATE INDEX [IX_FK_Credit_Users]
ON [dbo].[Credits]
    ([loanofficer_id]);
GO

-- Creating foreign key on [credit_id] in table 'CreditEntryFees'
ALTER TABLE [dbo].[CreditEntryFees]
ADD CONSTRAINT [FK_CreditEntryFees_Credit]
    FOREIGN KEY ([credit_id])
    REFERENCES [dbo].[Credits]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CreditEntryFees_Credit'
CREATE INDEX [IX_FK_CreditEntryFees_Credit]
ON [dbo].[CreditEntryFees]
    ([credit_id]);
GO

-- Creating foreign key on [contract_id] in table 'Installments'
ALTER TABLE [dbo].[Installments]
ADD CONSTRAINT [FK_Installments_Credit]
    FOREIGN KEY ([contract_id])
    REFERENCES [dbo].[Credits]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [currency_id] in table 'FundingLines'
ALTER TABLE [dbo].[FundingLines]
ADD CONSTRAINT [FK_FundingLines_Currencies]
    FOREIGN KEY ([currency_id])
    REFERENCES [dbo].[Currencies]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FundingLines_Currencies'
CREATE INDEX [IX_FK_FundingLines_Currencies]
ON [dbo].[FundingLines]
    ([currency_id]);
GO

-- Creating foreign key on [currency_id] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [FK_Packages_Currencies]
    FOREIGN KEY ([currency_id])
    REFERENCES [dbo].[Currencies]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Packages_Currencies'
CREATE INDEX [IX_FK_Packages_Currencies]
ON [dbo].[Packages]
    ([currency_id]);
GO

-- Creating foreign key on [currency_id] in table 'SavingProducts'
ALTER TABLE [dbo].[SavingProducts]
ADD CONSTRAINT [FK_SavingProducts_Currencies]
    FOREIGN KEY ([currency_id])
    REFERENCES [dbo].[Currencies]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingProducts_Currencies'
CREATE INDEX [IX_FK_SavingProducts_Currencies]
ON [dbo].[SavingProducts]
    ([currency_id]);
GO

-- Creating foreign key on [currency_id] in table 'Tellers'
ALTER TABLE [dbo].[Tellers]
ADD CONSTRAINT [FK_Tellers_Currencies]
    FOREIGN KEY ([currency_id])
    REFERENCES [dbo].[Currencies]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Tellers_Currencies'
CREATE INDEX [IX_FK_Tellers_Currencies]
ON [dbo].[Tellers]
    ([currency_id]);
GO

-- Creating foreign key on [cycle_id] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [FK_Packages_Cycles]
    FOREIGN KEY ([cycle_id])
    REFERENCES [dbo].[Cycles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Packages_Cycles'
CREATE INDEX [IX_FK_Packages_Cycles]
ON [dbo].[Packages]
    ([cycle_id]);
GO

-- Creating foreign key on [province_id] in table 'Districts'
ALTER TABLE [dbo].[Districts]
ADD CONSTRAINT [FK_Districts_Provinces]
    FOREIGN KEY ([province_id])
    REFERENCES [dbo].[Provinces]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Districts_Provinces'
CREATE INDEX [IX_FK_Districts_Provinces]
ON [dbo].[Districts]
    ([province_id]);
GO

-- Creating foreign key on [parent_id] in table 'EconomicActivities'
ALTER TABLE [dbo].[EconomicActivities]
ADD CONSTRAINT [FK_DomainOfApplications_DomainOfApplications]
    FOREIGN KEY ([parent_id])
    REFERENCES [dbo].[EconomicActivities]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DomainOfApplications_DomainOfApplications'
CREATE INDEX [IX_FK_DomainOfApplications_DomainOfApplications]
ON [dbo].[EconomicActivities]
    ([parent_id]);
GO

-- Creating foreign key on [activity_id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_Persons_DomainOfApplications]
    FOREIGN KEY ([activity_id])
    REFERENCES [dbo].[EconomicActivities]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Persons_DomainOfApplications'
CREATE INDEX [IX_FK_Persons_DomainOfApplications]
ON [dbo].[Persons]
    ([activity_id]);
GO

-- Creating foreign key on [id_product] in table 'EntryFees'
ALTER TABLE [dbo].[EntryFees]
ADD CONSTRAINT [FK_EntryFees_Packages]
    FOREIGN KEY ([id_product])
    REFERENCES [dbo].[Packages]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EntryFees_Packages'
CREATE INDEX [IX_FK_EntryFees_Packages]
ON [dbo].[EntryFees]
    ([id_product]);
GO

-- Creating foreign key on [event_type] in table 'EventAttributes'
ALTER TABLE [dbo].[EventAttributes]
ADD CONSTRAINT [FK_EventAttributes_EventTypes]
    FOREIGN KEY ([event_type])
    REFERENCES [dbo].[EventTypes]
        ([event_type])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EventAttributes_EventTypes'
CREATE INDEX [IX_FK_EventAttributes_EventTypes]
ON [dbo].[EventAttributes]
    ([event_type]);
GO

-- Creating foreign key on [exotic_id] in table 'ExoticInstallments'
ALTER TABLE [dbo].[ExoticInstallments]
ADD CONSTRAINT [FK_ExoticInstallments_Exotics]
    FOREIGN KEY ([exotic_id])
    REFERENCES [dbo].[Exotics]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ExoticInstallments_Exotics'
CREATE INDEX [IX_FK_ExoticInstallments_Exotics]
ON [dbo].[ExoticInstallments]
    ([exotic_id]);
GO

-- Creating foreign key on [exotic_id] in table 'LinkPackagesExotics'
ALTER TABLE [dbo].[LinkPackagesExotics]
ADD CONSTRAINT [FK_LinkPackagesExotics_Exotics]
    FOREIGN KEY ([exotic_id])
    REFERENCES [dbo].[Exotics]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LinkPackagesExotics_Exotics'
CREATE INDEX [IX_FK_LinkPackagesExotics_Exotics]
ON [dbo].[LinkPackagesExotics]
    ([exotic_id]);
GO

-- Creating foreign key on [funding_line_id] in table 'FundingLineAccountingRules'
ALTER TABLE [dbo].[FundingLineAccountingRules]
ADD CONSTRAINT [FK_FundingLineAccountingRules_FundingLine]
    FOREIGN KEY ([funding_line_id])
    REFERENCES [dbo].[FundingLines]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FundingLineAccountingRules_FundingLine'
CREATE INDEX [IX_FK_FundingLineAccountingRules_FundingLine]
ON [dbo].[FundingLineAccountingRules]
    ([funding_line_id]);
GO

-- Creating foreign key on [fundingline_id] in table 'FundingLineEvents'
ALTER TABLE [dbo].[FundingLineEvents]
ADD CONSTRAINT [FK_FundingLineEvents_FundingLines]
    FOREIGN KEY ([fundingline_id])
    REFERENCES [dbo].[FundingLines]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FundingLineEvents_FundingLines'
CREATE INDEX [IX_FK_FundingLineEvents_FundingLines]
ON [dbo].[FundingLineEvents]
    ([fundingline_id]);
GO

-- Creating foreign key on [id] in table 'Groups'
ALTER TABLE [dbo].[Groups]
ADD CONSTRAINT [FK_Groups_Tiers]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Tiers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [group_id] in table 'PersonGroupBelongings'
ALTER TABLE [dbo].[PersonGroupBelongings]
ADD CONSTRAINT [FK_PersonGroupCorrespondance_Groups]
    FOREIGN KEY ([group_id])
    REFERENCES [dbo].[Groups]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonGroupCorrespondance_Groups'
CREATE INDEX [IX_FK_PersonGroupCorrespondance_Groups]
ON [dbo].[PersonGroupBelongings]
    ([group_id]);
GO

-- Creating foreign key on [installment_type] in table 'Packages'
ALTER TABLE [dbo].[Packages]
ADD CONSTRAINT [FK_Packages_InstallmentTypes]
    FOREIGN KEY ([installment_type])
    REFERENCES [dbo].[InstallmentTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Packages_InstallmentTypes'
CREATE INDEX [IX_FK_Packages_InstallmentTypes]
ON [dbo].[Packages]
    ([installment_type]);
GO

-- Creating foreign key on [installment_types_id] in table 'TermDepositProducts'
ALTER TABLE [dbo].[TermDepositProducts]
ADD CONSTRAINT [FK_TermDepositProducts_InstallmentTypes]
    FOREIGN KEY ([installment_types_id])
    REFERENCES [dbo].[InstallmentTypes]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TermDepositProducts_InstallmentTypes'
CREATE INDEX [IX_FK_TermDepositProducts_InstallmentTypes]
ON [dbo].[TermDepositProducts]
    ([installment_types_id]);
GO

-- Creating foreign key on [payment_method_id] in table 'LinkBranchesPaymentMethods'
ALTER TABLE [dbo].[LinkBranchesPaymentMethods]
ADD CONSTRAINT [FK_LinkBranchesPaymentMethods_PaymentMethods]
    FOREIGN KEY ([payment_method_id])
    REFERENCES [dbo].[PaymentMethods]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LinkBranchesPaymentMethods_PaymentMethods'
CREATE INDEX [IX_FK_LinkBranchesPaymentMethods_PaymentMethods]
ON [dbo].[LinkBranchesPaymentMethods]
    ([payment_method_id]);
GO

-- Creating foreign key on [tiers_id] in table 'LinkGuarantorCredits'
ALTER TABLE [dbo].[LinkGuarantorCredits]
ADD CONSTRAINT [FK_LinkGuarantorCredit_Tiers]
    FOREIGN KEY ([tiers_id])
    REFERENCES [dbo].[Tiers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [package_id] in table 'LinkPackagesExotics'
ALTER TABLE [dbo].[LinkPackagesExotics]
ADD CONSTRAINT [FK_LinkPackagesExotics_Packages]
    FOREIGN KEY ([package_id])
    REFERENCES [dbo].[Packages]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LinkPackagesExotics_Packages'
CREATE INDEX [IX_FK_LinkPackagesExotics_Packages]
ON [dbo].[LinkPackagesExotics]
    ([package_id]);
GO

-- Creating foreign key on [savings_id] in table 'LoansLinkSavingsBooks'
ALTER TABLE [dbo].[LoansLinkSavingsBooks]
ADD CONSTRAINT [FK_LoansLinkSavingsBook_SavingContracts]
    FOREIGN KEY ([savings_id])
    REFERENCES [dbo].[SavingContracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_LoansLinkSavingsBook_SavingContracts'
CREATE INDEX [IX_FK_LoansLinkSavingsBook_SavingContracts]
ON [dbo].[LoansLinkSavingsBooks]
    ([savings_id]);
GO

-- Creating foreign key on [person_id] in table 'PersonGroupBelongings'
ALTER TABLE [dbo].[PersonGroupBelongings]
ADD CONSTRAINT [FK_PersonGroupBelonging_Persons1]
    FOREIGN KEY ([person_id])
    REFERENCES [dbo].[Persons]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'Persons'
ALTER TABLE [dbo].[Persons]
ADD CONSTRAINT [FK_Persons_Tiers]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[Tiers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tiers_id] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Projects_Tiers]
    FOREIGN KEY ([tiers_id])
    REFERENCES [dbo].[Tiers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Projects_Tiers'
CREATE INDEX [IX_FK_Projects_Tiers]
ON [dbo].[Projects]
    ([tiers_id]);
GO

-- Creating foreign key on [role_id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_Roles]
    FOREIGN KEY ([role_id])
    REFERENCES [dbo].[Roles]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'SavingBookContracts'
ALTER TABLE [dbo].[SavingBookContracts]
ADD CONSTRAINT [FK_SavingBookContract_SavingContracts]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[SavingContracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [id] in table 'SavingBookProducts'
ALTER TABLE [dbo].[SavingBookProducts]
ADD CONSTRAINT [FK_SavingBookProducts_SavingProducts]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[SavingProducts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [tiers_id] in table 'SavingContracts'
ALTER TABLE [dbo].[SavingContracts]
ADD CONSTRAINT [FK_SavingContracts_Tiers]
    FOREIGN KEY ([tiers_id])
    REFERENCES [dbo].[Tiers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingContracts_Tiers'
CREATE INDEX [IX_FK_SavingContracts_Tiers]
ON [dbo].[SavingContracts]
    ([tiers_id]);
GO

-- Creating foreign key on [user_id] in table 'SavingContracts'
ALTER TABLE [dbo].[SavingContracts]
ADD CONSTRAINT [FK_SavingContracts_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingContracts_Users'
CREATE INDEX [IX_FK_SavingContracts_Users]
ON [dbo].[SavingContracts]
    ([user_id]);
GO

-- Creating foreign key on [id] in table 'SavingDepositContracts'
ALTER TABLE [dbo].[SavingDepositContracts]
ADD CONSTRAINT [FK_SavingDepositContract_SavingContracts]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[SavingContracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [contract_id] in table 'SavingEvents'
ALTER TABLE [dbo].[SavingEvents]
ADD CONSTRAINT [FK_SavingEvents_SavingContracts]
    FOREIGN KEY ([contract_id])
    REFERENCES [dbo].[SavingContracts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingEvents_SavingContracts'
CREATE INDEX [IX_FK_SavingEvents_SavingContracts]
ON [dbo].[SavingEvents]
    ([contract_id]);
GO

-- Creating foreign key on [product_id] in table 'SavingContracts'
ALTER TABLE [dbo].[SavingContracts]
ADD CONSTRAINT [FK_Savings_SavingProducts]
    FOREIGN KEY ([product_id])
    REFERENCES [dbo].[SavingProducts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Savings_SavingProducts'
CREATE INDEX [IX_FK_Savings_SavingProducts]
ON [dbo].[SavingContracts]
    ([product_id]);
GO

-- Creating foreign key on [teller_id] in table 'SavingEvents'
ALTER TABLE [dbo].[SavingEvents]
ADD CONSTRAINT [FK_SavingEvents_Tellers]
    FOREIGN KEY ([teller_id])
    REFERENCES [dbo].[Tellers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingEvents_Tellers'
CREATE INDEX [IX_FK_SavingEvents_Tellers]
ON [dbo].[SavingEvents]
    ([teller_id]);
GO

-- Creating foreign key on [user_id] in table 'SavingEvents'
ALTER TABLE [dbo].[SavingEvents]
ADD CONSTRAINT [FK_SavingEvents_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SavingEvents_Users'
CREATE INDEX [IX_FK_SavingEvents_Users]
ON [dbo].[SavingEvents]
    ([user_id]);
GO

-- Creating foreign key on [id] in table 'TermDepositProducts'
ALTER TABLE [dbo].[TermDepositProducts]
ADD CONSTRAINT [FK_TermDepositProducts_SavingProducts]
    FOREIGN KEY ([id])
    REFERENCES [dbo].[SavingProducts]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SGroup] in table 'Settings'
ALTER TABLE [dbo].[Settings]
ADD CONSTRAINT [FK_Settings_SettingsGroup]
    FOREIGN KEY ([SGroup])
    REFERENCES [dbo].[SettingsGroups]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Settings_SettingsGroup'
CREATE INDEX [IX_FK_Settings_SettingsGroup]
ON [dbo].[Settings]
    ([SGroup]);
GO

-- Creating foreign key on [teller_id] in table 'TellerEvents'
ALTER TABLE [dbo].[TellerEvents]
ADD CONSTRAINT [FK_TellerEvents_Tellers]
    FOREIGN KEY ([teller_id])
    REFERENCES [dbo].[Tellers]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TellerEvents_Tellers'
CREATE INDEX [IX_FK_TellerEvents_Tellers]
ON [dbo].[TellerEvents]
    ([teller_id]);
GO

-- Creating foreign key on [user_id] in table 'TellerEvents'
ALTER TABLE [dbo].[TellerEvents]
ADD CONSTRAINT [FK_TellerEvents_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_TellerEvents_Users'
CREATE INDEX [IX_FK_TellerEvents_Users]
ON [dbo].[TellerEvents]
    ([user_id]);
GO

-- Creating foreign key on [user_id] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserRole_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UserRole_Users'
CREATE INDEX [IX_FK_UserRole_Users]
ON [dbo].[UserRoles]
    ([user_id]);
GO

-- Creating foreign key on [user_id] in table 'UsersBranches'
ALTER TABLE [dbo].[UsersBranches]
ADD CONSTRAINT [FK_UsersBranches_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [user_id] in table 'UsersSubordinates'
ALTER TABLE [dbo].[UsersSubordinates]
ADD CONSTRAINT [FK_UsersSubordinates_Users]
    FOREIGN KEY ([user_id])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [loan_officer] in table 'Villages'
ALTER TABLE [dbo].[Villages]
ADD CONSTRAINT [FK_Villages_Users]
    FOREIGN KEY ([loan_officer])
    REFERENCES [dbo].[Users]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Villages_Users'
CREATE INDEX [IX_FK_Villages_Users]
ON [dbo].[Villages]
    ([loan_officer]);
GO

-- Creating foreign key on [village_id] in table 'VillagesAttendances'
ALTER TABLE [dbo].[VillagesAttendances]
ADD CONSTRAINT [FK_VillagesAttendance_Villages]
    FOREIGN KEY ([village_id])
    REFERENCES [dbo].[Villages]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_VillagesAttendance_Villages'
CREATE INDEX [IX_FK_VillagesAttendance_Villages]
ON [dbo].[VillagesAttendances]
    ([village_id]);
GO

-- Creating foreign key on [village_id] in table 'VillagesPersons'
ALTER TABLE [dbo].[VillagesPersons]
ADD CONSTRAINT [FK_VillagesPersons_Villages]
    FOREIGN KEY ([village_id])
    REFERENCES [dbo].[Villages]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------