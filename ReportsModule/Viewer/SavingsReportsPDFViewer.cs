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
    public partial class SavingsReportsPDFViewer : Form
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
        public SavingsReportsPDFViewer(int user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished SavingsReportsPDFViewer initialization", TAG));

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

        private void SavingsReportsPDFViewer_Load(object sender, EventArgs e)
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

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished SavingsReportsPDFViewer load", TAG));
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
                //this.clientsToolStripMenuItem.Enabled = false;
                //this.clientAndLoanStatisticsToolStripMenuItem.Enabled = false;
                //this.clientInformationToolStripMenuItem.Enabled = false;
                //this.clientsAndShareOfWomenToolStripMenuItem.Enabled = false;
                //this.statisticsPerGenderToolStripMenuItem.Enabled = false;
                //this.dormantCustomersToolStripMenuItem.Enabled = false;
                //this.guarantorsToolStripMenuItem.Enabled = false;
                //this.oLBPerClientToolStripMenuItem.Enabled = false;
                //this.badClientsToolStripMenuItem.Enabled = false;
                //this.loan1ToolStripMenuItem.Enabled = false;
                //this.abadonedAndRefusedLoansToolStripMenuItem.Enabled = false;
                //this.anticipatedTotallyRepaidLoansToolStripMenuItem.Enabled = false;
                //this.activeLoansToolStripMenuItem.Enabled = false;
                //this.closedContractsToolStripMenuItem.Enabled = false;
                //this.collateralReportsToolStripMenuItem.Enabled = false;
                //this.collectionSheetToolStripMenuItem.Enabled = false;
                //this.loanCompulsorySavingsToolStripMenuItem.Enabled = false;
                //this.creditCommitteeToolStripMenuItem.Enabled = false;
                //this.creditLifeInsuranceToolStripMenuItem.Enabled = false;
                //this.disbursementsToolStripMenuItem.Enabled = false;
                //this.disbursementsAndReimbursementsToolStripMenuItem.Enabled = false;
                //this.disbursementOfTranchesToolStripMenuItem.Enabled = false;
                //this.disbursementsPerActivityToolStripMenuItem.Enabled = false;
                //this.dropOutReportToolStripMenuItem.Enabled = false;
                //this.exchangeRateGainLossToolStripMenuItem.Enabled = false;
                //this.loanCycleToolStripMenuItem.Enabled = false;
                //this.loanLossProvisionToolStripMenuItem.Enabled = false;
                //this.loanOfficersDisbursementsAndReimbursementsToolStripMenuItem.Enabled = false;
                //this.loanOfficersOLBAndPaRToolStripMenuItem.Enabled = false;
                //this.loanRenewalHelperToolStripMenuItem.Enabled = false;
                //this.loansDisbursedToolStripMenuItem.Enabled = false;
                //this.notDisbursedLoansToolStripMenuItem.Enabled = false;
                //this.loan2ToolStripMenuItem.Enabled = false;
                //this.oLBAndLLPPerLoanToolStripMenuItem.Enabled = false;
                //this.oLBPerCollateralToolStripMenuItem.Enabled = false;
                //this.pARAnalysisToolStripMenuItem.Enabled = false;
                //this.performingLoansToolStripMenuItem.Enabled = false;
                //this.reassignedLoansToolStripMenuItem.Enabled = false;
                //this.repaymentsToolStripMenuItem.Enabled = false;
                //this.resheduledLoansToolStripMenuItem.Enabled = false;
                //this.residualMaturityToolStripMenuItem.Enabled = false;
                //this.writtenOffLoansToolStripMenuItem.Enabled = false;
                //this.writtenOffPenaltiesToolStripMenuItem.Enabled = false;
                //this.savingsToolStripMenuItem.Enabled = false;
                //this.activeSavingsToolStripMenuItem.Enabled = false;
                //this.compulsorySavingsToolStripMenuItem.Enabled = false;
                //this.savingsContractsToolStripMenuItem.Enabled = false;
                //this.accountingToolStripMenuItem.Enabled = false;
                //this.cashBookToolStripMenuItem.Enabled = false;
                //this.generalAccountingToolStripMenuItem.Enabled = false;
                //this.generalLedgerToolStripMenuItem.Enabled = false;
                //this.trialBalanceToolStripMenuItem.Enabled = false;
                //this.consolidatedToolStripMenuItem.Enabled = false;
                //this.evolutionOfDisbursementToolStripMenuItem.Enabled = false;
                //this.evolutionOfOLBToolStripMenuItem.Enabled = false;
                //this.evolutionOfRepaymentsToolStripMenuItem.Enabled = false;
                //this.evolutionOfPARToolStripMenuItem.Enabled = false;
                //this.evolutionOfTotalNoOfClientsToolStripMenuItem.Enabled = false;
                //this.evolutionOfTotalNoOfContractsToolStripMenuItem.Enabled = false;
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
        #endregion "Private Methods"
         
    }
}
