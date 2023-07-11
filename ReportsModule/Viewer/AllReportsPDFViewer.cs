using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CommonLib;
using DAL;
//--- Add the following to make this code work
using iTextSharp.text;
using ReportsModule.ViewModelBuilders;
using ReportsModule.ViewModels;

namespace ReportsModule.Viewer
{
    public partial class AllReportsPDFViewer : Form
    {
        #region "Private Fields"
        private string msAppName = "SB Sacco Report.....";
        string current_file_name = "";
        string msFolder = "";
        Repository rep;
        SBSaccoDBEntities db;
        PDFGen pdf_generator;
        string connection;
        int _user;
        int _personid;
        int _branchid;
        string _resourcesPath = null;
        List<notificationdto> _lstnotificationdto = new List<notificationdto>();
        //Event declaration:
        //event for publishing messages to output
        event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        event EventHandler<notificationmessageEventArgs> _notificationmessageEventname_from_parent;
        string TAG;
        #endregion "Private Fields"

        #region "Constructor"
        public AllReportsPDFViewer(int user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            TAG = this.GetType().Name;

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AllReportsPDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF's will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

        }
        public AllReportsPDFViewer(int personid, int branchid, int user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AllReportsPDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF's will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            _personid = personid;

            _branchid = branchid;

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

        }
        #endregion "Constructor"

        #region "General Purpose Helpers for this Form"
        //************************************************************
        /// <summary>
        /// Refreshes the window's Caption/Title bar
        /// </summary>
        private void DoUpdateCaption()
        {
            try
            {
                this.Text = this.msAppName;

                if (this.current_file_name.Length == 0)
                {
                    this.Text += "<...no PDF file created...>";
                }
                else
                {
                    FileInfo fi = new FileInfo(get_reports_uri(this.current_file_name));
                    this.Text += @"...\" + fi.Name;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DoPreProcess(object sender, EventArgs e)
        {
            this.lblstatusinfo.Text = string.Empty;
            string msg = "processing report...";
            this.lblstatusinfo.Text = msg;
            this.Text = msg;
        }
        public string pathlookup(string folder)
        {
            try
            {
                string app_dir = Utils.get_application_path();
                var dir = Path.Combine(app_dir, folder);


                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                return dir;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        private void DoPostProcess(object sender, EventArgs e)
        {
            try
            {
                string dir = pathlookup("reports");
                string sRet = Utils.build_file_path(dir, current_file_name);
                int pdfCount = Directory.GetFiles(dir, "*.pdf", SearchOption.TopDirectoryOnly).Length;
                int excelCount = Directory.GetFiles(dir, "*.xls", SearchOption.TopDirectoryOnly).Length;
                int _totalFiles = pdfCount + excelCount;
                this.lblstatusinfo.Text = current_file_name.ToString() + "     [  " + _totalFiles.ToString() + "  ] ";

                copy_to_user_temp();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string get_reports_uri(string sFile)
        {
            string sRet;
            try
            {
                string dir = pathlookup("reports");
                sRet = Utils.build_file_path(dir, sFile);

                //check if directory exists.
                if (!System.IO.Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return sRet;
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
                return "";
            }
        }
        private void SetResourcePath()
        {
            string sRet = string.Empty;
            try
            {
                string dir = pathlookup("resources");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                else
                {
                    sRet = dir;
                }

                this._resourcesPath = sRet;
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
                this._resourcesPath = Utils.build_file_path(msFolder, "resources");
            }
        }
        private void DoShowPDF(string sFilePDF)
        {
            this.DoUpdateCaption();
            this.webBrowser.Navigate(get_reports_uri(sFilePDF));
        }
        private void NavigateToHomePage()
        {
            try
            {
                string help_file = "index.html";

                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string help_path = Path.Combine(base_directory, "help");
                string help_file_path = Path.Combine(help_path, help_file);

                FileInfo fi = new FileInfo(help_file_path);

                if (fi.Exists)
                    this.webBrowser.Navigate(fi.FullName);
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }

        private void copy_to_user_temp()
        {
            try
            {
                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string reports_path = Path.Combine(base_directory, "Reports");

                string temp_path = Path.GetTempPath();

                DirectoryInfo reports_dir_info = new DirectoryInfo(reports_path);
                DirectoryInfo temp_dir_info = new DirectoryInfo(temp_path);

                var files = reports_dir_info.GetFiles();

                foreach (var report_file_info in files)
                {
                    var _temp_file = Path.Combine(temp_path, report_file_info.Name);

                    System.IO.File.Copy(report_file_info.FullName, _temp_file, true);

                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        private bool NotifyMessage(string _Title, string _Text)
        {
            try
            {
                appNotifyIcon.Text = Utils.APP_NAME;
                appNotifyIcon.Icon = new Icon("Resources/Icons/Dollar.ico");
                appNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                appNotifyIcon.BalloonTipTitle = _Title;
                appNotifyIcon.BalloonTipText = _Text;
                appNotifyIcon.Visible = true;
                appNotifyIcon.ShowBalloonTip(900000);

                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        #endregion "General Purpose Helpers for this Form"

        #region "Private Methods"

        private void AllReportsPDFViewer_Load(object sender, EventArgs e)
        {
            try
            {
                NavigateToHomePage();

                var _currenciesquery = from br in rep.GetCurrenciesList()
                                       select br;
                List<CurrencyModel> _Currencies = _currenciesquery.ToList();
                cboCurrency.DataSource = _Currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                //cboCurrency.SelectedIndex = -1;

                var _branchesquery = from br in rep.GetNonDeletedBranches()
                                     select br;
                List<BranchModel> _Branches = _branchesquery.ToList();
                cboBranch.DataSource = _Branches;
                cboBranch.ValueMember = "branchid";
                cboBranch.DisplayMember = "name";
                //cboBranch.SelectedIndex = -1;

                IList<UserModel_dto> loanoficers = rep.GetUsersModelwithRolesList();
                cboUsers.DataSource = loanoficers;
                cboUsers.DisplayMember = "full_name";
                cboUsers.ValueMember = "userid";
                //cboUsers.SelectedIndex = -1;

                IList<UserModel_dto> subordinateloanoficers = rep.GetUsersModelwithRolesList();
                cboSubordinates.DataSource = subordinateloanoficers;
                cboSubordinates.DisplayMember = "full_name";
                cboSubordinates.ValueMember = "userid";
                //cboSubordinates.SelectedIndex = -1; 

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AllReportsPDFViewer load", TAG));
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
            Log.WriteToErrorLogFile_and_EventViewer(ex);
        }
        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            this._notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
            Log.WriteToErrorLogFile_and_EventViewer(ex);
        }

        //Event handler declaration:
        private void notificationmessageHandler(object sender, notificationmessageEventArgs args)
        {
            try
            {
                /* Handler logic */
                notificationdto _notificationdto = new notificationdto();

                DateTime currentDate = DateTime.Now;
                String dateTimenow = currentDate.ToString("dd-MM-yyyy HH:mm:ss tt");

                String _logtext = Environment.NewLine + "[ " + dateTimenow + " ]   " + args.message;

                _notificationdto._notification_message = _logtext;
                _notificationdto._created_datetime = dateTimenow;
                _notificationdto.TAG = args.TAG;

                _lstnotificationdto.Add(_notificationdto);
                Console.WriteLine(args.message);
                _notificationmessageEventname_from_parent.Invoke(this, new notificationmessageEventArgs(args.message, TAG));

                var _lstmsgdto = from msgdto in _lstnotificationdto
                                 orderby msgdto._created_datetime descending
                                 select msgdto._notification_message;

                String[] _logflippedlines = _lstmsgdto.ToArray();

                if (_logflippedlines.Length > 5000)
                {
                    _lstnotificationdto.Clear();
                }

                txtlog.Lines = _logflippedlines;
                txtlog.ScrollToCaret();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Authorize()
        {
            try
            {
                var _dbuserquery = from us in db.spUsers
                                   where us.Id == _user
                                   select us;

                spUser LoggedInUser = _dbuserquery.FirstOrDefault();

                if (LoggedInUser != null)
                {
                    var allowedmenusquery = from arm in db.spAllowedReportsRolesMenus
                                            where arm.RoleId == LoggedInUser.RoleId
                                            select arm;

                    foreach (var armq in allowedmenusquery.ToList())
                    {
                        ToolStripMenuItem mnuitem = menuStrip1.Items.Find(armq.spReportsMenuItem.mnuName, true).OfType<ToolStripMenuItem>().FirstOrDefault();

                        if (mnuitem != null && armq.Allowed == true)
                        {
                            mnuitem.Enabled = true;
                        }

                        ToolStripItem tsbitem = toolStrip1.Items.Find(armq.spReportsMenuItem.mnuName, true).OfType<ToolStripItem>().FirstOrDefault();

                        if (tsbitem != null && armq.Allowed == true)
                        {
                            tsbitem.Enabled = true;
                        }
                    }
                }
                else
                {
                    Utils.ShowError(new Exception("Error retrieving user information."));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DisableAllMenus()
        {
            try
            {
                this.clientsToolStripMenuItem.Enabled = false;
                this.clientAndLoanStatisticsToolStripMenuItem.Enabled = false;
                this.clientInformationToolStripMenuItem.Enabled = false;
                this.clientsAndShareOfWomenToolStripMenuItem.Enabled = false;
                this.statisticsPerGenderToolStripMenuItem.Enabled = false;
                this.dormantCustomersToolStripMenuItem.Enabled = false;
                this.guarantorsToolStripMenuItem.Enabled = false;
                this.oLBPerClientToolStripMenuItem.Enabled = false;
                this.badClientsToolStripMenuItem.Enabled = false;
                this.loan1ToolStripMenuItem.Enabled = false;
                this.abadonedAndRefusedLoansToolStripMenuItem.Enabled = false;
                this.anticipatedTotallyRepaidLoansToolStripMenuItem.Enabled = false;
                this.activeLoansToolStripMenuItem.Enabled = false;
                this.closedContractsToolStripMenuItem.Enabled = false;
                this.collateralReportsToolStripMenuItem.Enabled = false;
                this.collectionSheetToolStripMenuItem.Enabled = false;
                this.loanCompulsorySavingsToolStripMenuItem.Enabled = false;
                this.creditCommitteeToolStripMenuItem.Enabled = false;
                this.creditLifeInsuranceToolStripMenuItem.Enabled = false;
                this.disbursementsToolStripMenuItem.Enabled = false;
                this.disbursementsAndReimbursementsToolStripMenuItem.Enabled = false;
                this.disbursementOfTranchesToolStripMenuItem.Enabled = false;
                this.disbursementsPerActivityToolStripMenuItem.Enabled = false;
                this.dropOutReportToolStripMenuItem.Enabled = false;
                this.exchangeRateGainLossToolStripMenuItem.Enabled = false;
                this.loanCycleToolStripMenuItem.Enabled = false;
                this.loanLossProvisionToolStripMenuItem.Enabled = false;
                this.loanOfficersDisbursementsAndReimbursementsToolStripMenuItem.Enabled = false;
                this.loanOfficersOLBAndPaRToolStripMenuItem.Enabled = false;
                this.loanRenewalHelperToolStripMenuItem.Enabled = false;
                this.loansDisbursedToolStripMenuItem.Enabled = false;
                this.notDisbursedLoansToolStripMenuItem.Enabled = false;
                this.loan2ToolStripMenuItem.Enabled = false;
                this.oLBAndLLPPerLoanToolStripMenuItem.Enabled = false;
                this.oLBPerCollateralToolStripMenuItem.Enabled = false;
                this.pARAnalysisToolStripMenuItem.Enabled = false;
                this.performingLoansToolStripMenuItem.Enabled = false;
                this.reassignedLoansToolStripMenuItem.Enabled = false;
                this.repaymentsToolStripMenuItem.Enabled = false;
                this.resheduledLoansToolStripMenuItem.Enabled = false;
                this.residualMaturityToolStripMenuItem.Enabled = false;
                this.writtenOffLoansToolStripMenuItem.Enabled = false;
                this.writtenOffPenaltiesToolStripMenuItem.Enabled = false;
                this.savingsToolStripMenuItem.Enabled = false;
                this.activeSavingsToolStripMenuItem.Enabled = false;
                this.compulsorySavingsToolStripMenuItem.Enabled = false;
                this.savingsContractsToolStripMenuItem.Enabled = false;
                this.accountingToolStripMenuItem.Enabled = false;
                this.cashBookToolStripMenuItem.Enabled = false;
                this.generalAccountingToolStripMenuItem.Enabled = false;
                this.generalLedgerToolStripMenuItem.Enabled = false;
                this.trialBalanceToolStripMenuItem.Enabled = false;
                this.consolidatedToolStripMenuItem.Enabled = false;
                this.evolutionOfDisbursementToolStripMenuItem.Enabled = false;
                this.evolutionOfOLBToolStripMenuItem.Enabled = false;
                this.evolutionOfRepaymentsToolStripMenuItem.Enabled = false;
                this.evolutionOfPARToolStripMenuItem.Enabled = false;
                this.evolutionOfTotalNoOfClientsToolStripMenuItem.Enabled = false;
                this.evolutionOfTotalNoOfContractsToolStripMenuItem.Enabled = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblstatusinfo_Click(object sender, EventArgs e)
        {
            try
            {
                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string reports_path = Path.Combine(base_directory, "Reports");

                if (Directory.Exists(reports_path))
                {
                    string _filetoSelect = Path.Combine(reports_path, current_file_name);
                    // opens the folder in explorer and selects the displayed file
                    string args = string.Format("/Select, {0}", _filetoSelect);
                    ProcessStartInfo pfi = new ProcessStartInfo("Explorer.exe", args);
                    System.Diagnostics.Process.Start(pfi);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cashBookToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            try
            {
                current_file_name = "Accounting Cash Book" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                AccountingCashBookViewModelBuilder _ModelBuilder = new AccountingCashBookViewModelBuilder(connection);
                AccountingCashBookViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowAccountingCashBook(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void badClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Bad Clients" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                BadClientViewModelBuilder _ModelBuilder = new BadClientViewModelBuilder(connection);
                BadClientViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowBadClients(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void clientAndLoanStatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Clients and Loans Statistics" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ClientsandLoanStatisticsModelBuilder _ModelBuilder = new ClientsandLoanStatisticsModelBuilder(connection);
                ClientandLoanStatisticsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowClientandLoanStatistics(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void clientAndShareOfWomenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "clients And Share Of Women" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ClientandShareofWomenViewModelBuilder _ModelBuilder = new ClientandShareofWomenViewModelBuilder(connection);
                ClientsandShareofWomenViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowClientsandshareofWomen(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dormantCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Dormant Customers" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                DormantCustomersModelBuilder _ModelBuilder = new DormantCustomersModelBuilder(connection);
                DormantCustomersViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowDormantCustomer(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void clientInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Client Information" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ClientInformationViewModelBuilders _ModelBuilder = new ClientInformationViewModelBuilders(_personid, _branchid, connection);
                ClientInformationViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowClientInformation(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void guarantorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Guarantors" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                GuarantorsModelBuilder _ModelBuilder = new GuarantorsModelBuilder(connection);
                GuarantorsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowGuarantors(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void oLBPerClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "OLB Per Client" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                OLBperClientViewModelBuilder _ModelBuilder = new OLBperClientViewModelBuilder(connection);
                OLBperClientViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowOLBperClient(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void statisticsPerGenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Statistics Per Gender" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                StatisticsperGenderViewModelBuilder _ModelBuilder = new StatisticsperGenderViewModelBuilder(connection);
                StatisticsPerGenderViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowStatisticsperGender(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void trialBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Trial Balance" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                TrialBalanceViewModelBuilder _ModelBuilder = new TrialBalanceViewModelBuilder(connection);
                TrialBalanceViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowTrialBalance(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void generalAccountingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "General Accounting" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                GeneralAccountingViewModelBuilder _ModelBuilder = new GeneralAccountingViewModelBuilder(connection);
                GeneralAccountingViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowGeneralAccounting(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "General Ledger" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                GeneralLedgerViewModelBuilder _ModelBuilder = new GeneralLedgerViewModelBuilder(connection);
                GeneralLedgerViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowGeneralLedger(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void evolutionOfDisbursementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Evolution Of Disbursement" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                EvolutionofDisbursementViewModelBuilder _ModelBuilder = new EvolutionofDisbursementViewModelBuilder(connection);
                EvolutionofDisbursementModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowEvolutionofDisbursement(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void evolutionOfOLBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Evolution Of OLB" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                EvolutionOfOLBModelBuilder _ModelBuilder = new EvolutionOfOLBModelBuilder(connection);
                EvolutionOfOLBModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowEvolutionOfOLB(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void evolutionOfPARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Evolution Of PAR" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                EvolutionOfPARModelBuilder _ModelBuilder = new EvolutionOfPARModelBuilder(connection);
                EvolutionOfPARModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowEvolutionOfPAR(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void abadonedAndRefusedLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Abadoned And Refused Loans" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                AbadonedandRefusedLoansViewModelBuilder _ModelBuilder = new AbadonedandRefusedLoansViewModelBuilder(connection);
                AbadonedandRefusedLoansViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowAbadonedandRefusedLoans(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void anticipatedTotallyRepaidLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Anticipated Totally Repaid Loans" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                AnticipatedTotallyRepaidLoansViewModelBuilder _ModelBuilder = new AnticipatedTotallyRepaidLoansViewModelBuilder(connection);
                AnticipatedTotallyRepaidLoansViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowAnticipatedTotallyRepaidLoans(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void activeLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Active Loans Repaid Loans" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ActiveLoansViewModelBuilder _ModelBuilder = new ActiveLoansViewModelBuilder(connection);
                ActiveLoansViewModels _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowActiveLoans(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void evolutionOfRepaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Evolution Of Repayments" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                EvolutionOfRepaymentsModelBuilder _ModelBuilder = new EvolutionOfRepaymentsModelBuilder(connection);
                EvolutionOfRepaymentsModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowEvolutionOfRepayments(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void evolutionOfTotalNoOfClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Evolution Of Total Number Of Clients" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                EvolutionOfTotalNoOfClientsModelBuilder _ModelBuilder = new EvolutionOfTotalNoOfClientsModelBuilder(connection);
                EvolutionOfTotalNoOfClientsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowEvolutionOfTotalNoOfClients(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void evolutionOfTotalNoOfContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Evolution Of Total No Of Contracts" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                EvolutionOfTotalNoOfContractsViewModelBuilder _ModelBuilder = new EvolutionOfTotalNoOfContractsViewModelBuilder(connection);
                EvolutionOfTotalNoOfContractsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowEvolutionOfTotalNoOfContracts(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void closedContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Closed Contracts" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ClosedContractsViewModelBuilder _ModelBuilder = new ClosedContractsViewModelBuilder(connection);
                ClosedContractsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowClosedContracts(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void collateralReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Collateral Reports" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                CollateralReportsViewModelBuilder _ModelBuilder = new CollateralReportsViewModelBuilder(connection);
                CollateralReportsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowCollateralReports(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void collectionSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Collection Sheet" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                CollectionSheetViewModelBuilder _ModelBuilder = new CollectionSheetViewModelBuilder(connection);
                CollectionSheetViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowCollectionSheet(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void creditLifeInsuranceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Credit Life Insurance" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                CreditLifeInsuranceViewModelBuilder _ModelBuilder = new CreditLifeInsuranceViewModelBuilder(connection);
                CreditLifeInsuranceViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowCreditLifeInsurance(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void disbursementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Disbursements" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                DisbursementsViewModelBuilder _ModelBuilder = new DisbursementsViewModelBuilder(connection);
                DisbursementsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowDisbursements(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void disbursementsAndReimbursementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Disbursements And Reimbursements" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                DisbursementsandreimbursementsViewModelBuilder _ModelBuilder = new DisbursementsandreimbursementsViewModelBuilder(connection);
                DisbursementsandreimbursementsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowDisbursementsandReimbursements(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void disbursementOfTranchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Disbursement Of Tranches" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                DisbursementofTranchesViewModelBuilder _ModelBuilder = new DisbursementofTranchesViewModelBuilder(connection);
                DisbursementofTranchesViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowDisbursementofTranches(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void disbursementsPerActivityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Disbursements Per Activity" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                DisbursementsperActivityViewModelBuilder _ModelBuilder = new DisbursementsperActivityViewModelBuilder(connection);
                DisbursementsperActivityViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowDisbursementsperActivity(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void creditCommitteeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Credit Committee" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                CreditCommitteeViewModelBuilder _ModelBuilder
 = new CreditCommitteeViewModelBuilder(connection);
                CreditCommitteeViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowCreditCommittee(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void savingsContractsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Savings Contracts" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                SavingsContractsViewModelBuilder _ModelBuilder = new SavingsContractsViewModelBuilder(connection);
                SavingsContractsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowSavingsContracts(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void activeSavingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Active Savings" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ActiveSavingsViewModelBuilder _ModelBuilder = new ActiveSavingsViewModelBuilder(connection);
                ActiveSavingsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowActiveSavings(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void compulsorySavingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "compulsory Savings" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                CompulsorySavingsViewModelBuilder _ModelBuilder = new CompulsorySavingsViewModelBuilder(connection);
                CompulsorySavingsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowCompulsorySavings(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dropOutReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Drop Out Report" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                DropoutReportViewModelBuilder _ModelBuilder = new DropoutReportViewModelBuilder(connection);
                DropoutReportViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowDropoutReports(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void oLBAndLLPPerLoanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "OLB And LLP Per Loan" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                OLBandLLPperLoanViewModelBuilder _ModelBuilder = new OLBandLLPperLoanViewModelBuilder(connection);
                OLBandLLPperLoanViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showOLBandLLPperLoan(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void oLBPerCollateralToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "oLB Per Collateral" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                OLBperCollateralViewModelBuilder _ModelBuilder = new OLBperCollateralViewModelBuilder(connection);
                OLBperCollateralViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showOLBperCollateral(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loansDisbursedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Loans Disbursed" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                LoansDisbursedViewModelBuilder _ModelBuilder = new LoansDisbursedViewModelBuilder(connection);
                LoansDisbursedViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showLoansDisbursed(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loanRenewalHelperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "loan Renewal Helper" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                LoanRenewalHelperViewModelBuilder _ModelBuilder = new LoanRenewalHelperViewModelBuilder(connection);
                LoanRenewalHelperViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showLoanRenewalHelper(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loanOfficresOLBAndPaRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "loan Officres OLB And PaR" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                LoanOfficerOLBandPaRViewModelBuilder _ModelBuilder = new LoanOfficerOLBandPaRViewModelBuilder(connection);
                LoanOfficersOLBandPaRViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showLoanOfficerOLBandPaR(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loanOfficersDisbursementsAndReimbursementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "loan Officers Disbursements And Reimbursements" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                LoanOfficersDisbursementsandReimbursementsViewModelBuilder _ModelBuilder = new LoanOfficersDisbursementsandReimbursementsViewModelBuilder(connection);
                LoanOfficerDisbursementsandReimbursementsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showLoanOfficersDisbursementsandReimbursements(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loanLossProvisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "loan Loss Provision" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                LoanLossProvisionViewModelBuilder _ModelBuilder = new LoanLossProvisionViewModelBuilder(connection);
                LoanLossProvisionViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showLoanLossProvision(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void loanCycleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Loan Cycle" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                LoanCycleViewModelBuilder _ModelBuilder = new LoanCycleViewModelBuilder(connection);
                LoanCycleViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showLoanCycle(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void exchangeRateGainLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Exchange Rate Gain or Loss" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ExchangeRateGainLossViewModelBuilder _ModelBuilder = new ExchangeRateGainLossViewModelBuilder(connection);
                ExchangeRateGainorLossViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showExchangeRateGainorLoss(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void pARAnalysisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "pAR Analysis" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                PARAnalysisViewModelBuilder _ModelBuilder = new PARAnalysisViewModelBuilder(connection);
                PARAnalysisViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showPARAnalysisViewModel(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void performingLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Performing Loans" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                PerformingLoansViewModelBuilder _ModelBuilder = new PerformingLoansViewModelBuilder(connection);
                PerformingLoansViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showPerformingLoans(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void reassignedLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Reassigned Loans" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ReassignedLoansViewModelBuilder _ModelBuilder = new ReassignedLoansViewModelBuilder(connection);
                ReassignedLoansViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showReassignedLoans(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void repaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Repayments" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                RepaymentsViewModelBuilder _ModelBuilder = new RepaymentsViewModelBuilder(connection);
                RepaymentsViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showRepayments(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void resheduledLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Resheduled Loans" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ResheduledLoansViewModelBuilder _ModelBuilder = new ResheduledLoansViewModelBuilder(connection);
                ResheduledLoansViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showResheduledLoans(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void residualMaturityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Residual Maturity" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ResidualMaturityViewModelBuilder _ModelBuilder = new ResidualMaturityViewModelBuilder(connection);
                ResidualMaturityViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showResidualMaturity(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void writtenOffLoansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Written Off Loans" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                WrittenOffLoansViewModelBuilder _ModelBuilder = new WrittenOffLoansViewModelBuilder(connection);
                WrittenoffLoansViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showWrittenoffLoans(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void writtenOffPenaltiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                current_file_name = "Written off PenaltiesViewModel" + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                WrittenoffPenaltiesViewModelBuilder _ModelBuilder = new WrittenoffPenaltiesViewModelBuilder(connection);
                WrittenoffPenaltiesViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                this.DoPreProcess(sender, e);

                if (pdf_generator.showWrittenoffPenalties(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selected_user = cboUsers.SelectedValue.ToString();
                Console.WriteLine(selected_user);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboBranch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboSubordinates_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {

        }

        #endregion "Private Methods"





    }
}