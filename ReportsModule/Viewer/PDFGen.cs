using System; 
using System.Collections.Generic; 
using System.Diagnostics;
using System.IO; 
using CommonLib; 
using DAL; 
//--- Add the following to make itext work
using iTextSharp.text;
using iTextSharp.text.pdf;
using ReportsModule.ViewModels;
using ReportsModule.Views.PDF; 

namespace ReportsModule.Viewer
{
    public class PDFGen
    {

        #region "Properties"
        private bool bRet = false;
        private string resourcePath;
        private string sMsg = "";
        string connection;
        Repository rep;
        SBSaccoDBEntities db;
        public string Message
        {
            get { return sMsg; }
            set { sMsg = value; }
        }
        public bool Success
        {
            get { return bRet; }
            set { bRet = value; }
        }
        event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        string TAG;
        #endregion "Properties"

        #region "Constructor"
        public PDFGen()
        {

        }
        public PDFGen(string ResourcePath, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            resourcePath = ResourcePath;

        }
        #endregion "Constructor"

        #region "Helper methods"
        /// <summary>
        /// Safely attempts to insert an image file into the document
        /// </summary>
        /// <param name="document">iTextSharp Document in which it needs to be inserted</param>
        /// <param name="sFilename">the name of the file to be inserted</param>
        /// <returns>false if failed to do so</returns>
        private bool DoInsertImageFile(Document document, string sFilename, bool bInsertMsg)
        {
            bool bRet = false;

            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";
                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                }

                Image img = null;
                if (File.Exists(sFilename))
                {
                    this.DoGetImageFile(sFilename, out img);
                }

                if (img != null)
                {
                    document.Add(img);
                    bRet = true;
                }
                else
                {
                    if (bInsertMsg)
                        document.Add(new Paragraph(sFilename + " not found"));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return bRet;
        }
        public Image DoGetImageFile(string sFilename)
        {
            bool bRet = false;
            Image img = null;

            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";
                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                }

                if (File.Exists(sFilename))
                {
                    img = Image.GetInstance(sFilename);
                }

                bRet = (img != null);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return img;
        }
        private bool DoGetImageFile(string sFilename, out Image img)
        {
            bool bRet = false;
            img = null;

            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";
                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                }

                if (File.Exists(sFilename))
                {
                    img = Image.GetInstance(sFilename);
                }

                bRet = (img != null);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return bRet;
        }
        private bool DoLocateImageFile(ref string sFilename)
        {
            bool bRet = false; 
            try
            {
                if (File.Exists(sFilename) == false)
                {
                    string sMsg = "Unable to find '" + sFilename + "' in the current folder.\n\n"
                                + "Would you like to locate it?";

                    if (MsgBox.Confirm(sMsg))
                        sFilename = FileDialog.GetFilenameToOpen(FileDialog.FileType.Image);
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

            return bRet = File.Exists(sFilename);
        }
        #endregion "Helper methods"

        #region "public methods"
        public bool ShowAccountingCashBook(AccountingCashBookViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                AccountingCashBookPDFBuilder _PdfBuilder = new AccountingCashBookPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowGeneralAccounting(GeneralAccountingViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                GeneralAccountingPDFBuilder _PdfBuilder = new GeneralAccountingPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowGeneralLedger(GeneralLedgerViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                GeneralLedgerPDFBuilder _PdfBuilder = new GeneralLedgerPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowTrialBalance(TrialBalanceViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                TrialBalancePDFBuilder _PdfBuilder = new TrialBalancePDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowActiveSavings(ActiveSavingsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ActiveSavingsViewModelPDFBuilder _PdfBuilder = new ActiveSavingsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowCompulsorySavings(CompulsorySavingsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                CompulsorySavingsViewModelPDFBuilder _PdfBuilder = new CompulsorySavingsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowSavingsContracts(SavingsContractsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                SavingContractsViewModelPDFBuilder _PdfBuilder = new SavingContractsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowBadClients(BadClientViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                BadClientsViewModelPDFBuilder _PdfBuilder = new BadClientsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClientandLoanStatistics(ClientandLoanStatisticsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClientandLoanStatisticsPDFBuilder _PdfBuilder = new ClientandLoanStatisticsPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClientsandshareofWomen(ClientsandShareofWomenViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClientsandshareofWomenPDFBuilder _PdfBuilder = new ClientsandshareofWomenPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClientInformation(ClientInformationViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClientInformationViewModelPDFBuilder _PdfBuilder = new ClientInformationViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowDormantCustomer(DormantCustomersViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                DormantCustomerPDFBuilder _PdfBuilder = new DormantCustomerPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowGuarantors(GuarantorsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                GuarantorsPDFBuilder _PdfBuilder = new GuarantorsPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowOLBperClient(OLBperClientViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                OLBperClientPDFBuilder _PdfBuilder = new OLBperClientPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowStatisticsperGender(StatisticsPerGenderViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                StatisticsperGenderPDFBuilder _PdfBuilder = new StatisticsperGenderPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowEvolutionofDisbursement(EvolutionofDisbursementModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                EvolutionofDisbursementPDFBuilder _PdfBuilder = new EvolutionofDisbursementPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowEvolutionOfOLB(EvolutionOfOLBModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                EvolutionOfOLBPDFBuilder _PdfBuilder = new EvolutionOfOLBPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowEvolutionOfPAR(EvolutionOfPARModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                EvolutionOfPARPDFBuilder _PdfBuilder = new EvolutionOfPARPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowEvolutionOfRepayments(EvolutionOfRepaymentsModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                EvolutionOfRepaymentsPDFBuilder _PdfBuilder = new EvolutionOfRepaymentsPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowEvolutionOfTotalNoOfClients(EvolutionOfTotalNoOfClientsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                EvolutionOfTotalNoOfClientsPDFBuilder _PdfBuilder = new EvolutionOfTotalNoOfClientsPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowEvolutionOfTotalNoOfContracts(EvolutionOfTotalNoOfContractsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                EvolutionOfTotalNoOfContractsPDFBuilder _PdfBuilder = new EvolutionOfTotalNoOfContractsPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowAbadonedandRefusedLoans(AbadonedandRefusedLoansViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {

                AbadonedandRefusedLoansViewModelPDFBuilder _PdfBuilder = new AbadonedandRefusedLoansViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowActiveLoans(ActiveLoansViewModels _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ActiveLoansViewModelPDFBuilder _PdfBuilder = new ActiveLoansViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowAnticipatedTotallyRepaidLoans(AnticipatedTotallyRepaidLoansViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                AnticipatedTotallyRepaidLoansViewModelPDFBuilder _PdfBuilder = new AnticipatedTotallyRepaidLoansViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowClosedContracts(ClosedContractsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ClosedContractsViewModelPDFBuilder _PdfBuilder = new ClosedContractsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowCollateralReports(CollateralReportsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                CollateralReportsViewModelPDFBuilder _PdfBuilder = new CollateralReportsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowCollectionSheet(CollectionSheetViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                CollectionSheetViewModelPDFBuilder _PdfBuilder = new CollectionSheetViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowCreditCommittee(CreditCommitteeViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                CreditCommitteeViewModelPDFBuilder _PdfBuilder = new CreditCommitteeViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowCreditLifeInsurance(CreditLifeInsuranceViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                CreditLifeInsuranceViewModelPDFBuilder _PdfBuilder = new CreditLifeInsuranceViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowDisbursements(DisbursementsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                DisbursementsViewModelPDFBuilder _PdfBuilder = new DisbursementsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowDisbursementsandReimbursements(DisbursementsandreimbursementsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                DisbursementsandReimbursementsViewModelPDFBuilder _PdfBuilder = new DisbursementsandReimbursementsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowDisbursementofTranches(DisbursementofTranchesViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                DisbursementsofTranchesViewModelPDFBuilder _PdfBuilder = new DisbursementsofTranchesViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowDisbursementsperActivity(DisbursementsperActivityViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                DisbursementsperActivityViewModelPDFBuilder _PdfBuilder = new DisbursementsperActivityViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool ShowDropoutReports(DropoutReportViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                DropoutReportsViewModelPDFBuilder _PdfBuilder = new DropoutReportsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showOLBperCollateral(OLBperCollateralViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                OLBperCollateralViewModelPDFBuilder _PdfBuilder = new OLBperCollateralViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showOLBandLLPperLoan(OLBandLLPperLoanViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                OLBandLLPLoanViewModelPDFBuilder _PdfBuilder = new OLBandLLPLoanViewModelPDFBuilder(_ViewModel, msFilePDF); 
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        public bool showLoansDisbursed(LoansDisbursedViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                LoansDisbursedViewModelPDFBuilder _PdfBuilder = new LoansDisbursedViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showLoanRenewalHelper(LoanRenewalHelperViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                LoanRenewalHelperViewModelPDFBuilder _PdfBuilder = new LoanRenewalHelperViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showLoanOfficerOLBandPaR(LoanOfficersOLBandPaRViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                LoanOfficerOLBandPaRViewModelPDFBuilder _PdfBuilder = new LoanOfficerOLBandPaRViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showLoanOfficersDisbursementsandReimbursements(LoanOfficerDisbursementsandReimbursementsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                LoanOfficersDisbursementsandReimbursementsViewModelPDFBuilder _PdfBuilder = new LoanOfficersDisbursementsandReimbursementsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showLoanLossProvision(LoanLossProvisionViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                LoanLossProvisionViewModelPDFBuilder _PdfBuilder = new LoanLossProvisionViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        } 
        public bool showLoanCycle(LoanCycleViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                LoanCycleViewModelPDFBuilder _PdfBuilder = new LoanCycleViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showExchangeRateGainorLoss(ExchangeRateGainorLossViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ExchangeRateGainorLossViewModelPDFBuilder _PdfBuilder = new ExchangeRateGainorLossViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showPARAnalysisViewModel(PARAnalysisViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                PARAnalysisViewModelPDFBuilder _PdfBuilder = new PARAnalysisViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showPerformingLoans(PerformingLoansViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                PerformingLoansViewModelPDFBuilder _PdfBuilder = new PerformingLoansViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showReassignedLoans(ReassignedLoansViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ReassignedLoansViewModelPDFBuilder _PdfBuilder = new ReassignedLoansViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showRepayments(RepaymentsViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                RepaymentsViewModelPDFBuilder _PdfBuilder = new RepaymentsViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showResheduledLoans(ResheduledLoansViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ResheduledLoansViewModelPDFBuilder _PdfBuilder = new ResheduledLoansViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showResidualMaturity(ResidualMaturityViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                ResidualMaturityViewModelPDFBuilder _PdfBuilder = new ResidualMaturityViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showWrittenoffLoans(WrittenoffLoansViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                WrittenOffLoansPDFBuilder _PdfBuilder = new WrittenOffLoansPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        public bool showWrittenoffPenalties(WrittenoffPenaltiesViewModel _ViewModel, string msFilePDF)
        {
            bRet = false;
            try
            {
                WrittenoffPenaltiesViewModelPDFBuilder _PdfBuilder = new WrittenoffPenaltiesViewModelPDFBuilder(_ViewModel, msFilePDF);
                _PdfBuilder.GetPDF();
                return true;
            }
            catch (Exception ex)
            {
                 Utils.ShowError(ex);
                return false;
            }
        }
        #endregion "public methods"

    }
}