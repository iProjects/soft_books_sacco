using System; 
using System.Collections.Generic; 
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing; 
using System.Drawing.Imaging;
using System.Linq; 
using System.Windows.Forms;
using CommonLib; 
using DAL;

namespace AdminstratorModule.Views
{
    public partial class ExportTransactionsForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int _user;
        SBSystem _system;
        //delegate
        public delegate void ExportAccounting_TransactionsSelectHandler(object sender, ExportAccounting_TransactionsSelectEventArgs e);
        //event
        public event ExportAccounting_TransactionsSelectHandler OnExportAccounting_TransactionSelected;
        #endregion "Private Fields"

        #region "Constructor"
        public ExportTransactionsForm(SBSystem system, int user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _user = user;

            _system = system;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void ExportTransactionsForm_Load(object sender, EventArgs e)
        {
            try
            {

                var DisplayType = new BindingList<KeyValuePair<string, string>>();
                DisplayType.Add(new KeyValuePair<string, string>("Unicode", "Unicode"));
                DisplayType.Add(new KeyValuePair<string, string>("ANSI", "ANSI"));
                DisplayType.Add(new KeyValuePair<string, string>("ANSI(RU)", "ANSI(RU)"));
                cboOptions.DataSource = DisplayType;
                cboOptions.ValueMember = "Key";
                cboOptions.DisplayMember = "Value";

                var _storedprocsquery = from br in SQLHelper.GetStoredProcedures(_system)
                                        where br.Name.Contains("ExportAccounting_Transaction")
                                        select br;
                List<StoredProceduresModel> _storedprocs = _storedprocsquery.ToList();
                cboExportProcedure.DataSource = _storedprocs;
                cboExportProcedure.ValueMember = "storedprocedureid";
                cboExportProcedure.DisplayMember = "Name";
                cboExportProcedure.SelectedIndex = -1;

                txtSeparator.Text = ";";

                dtpStartDate.Value = DateTime.Now;
                dtpEndDate.Value = dtpStartDate.Value.AddMonths(1);

                var _accountingclosurequery = from rts in rep.GetNonDeletedAccountingClosures()
                                              select rts;
                bindingSourceExportTransactions.DataSource = _accountingclosurequery.ToList();
                dataGridViewExportTransactions.AutoGenerateColumns = false;
                this.dataGridViewExportTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExportTransactions.DataSource = bindingSourceExportTransactions;
                groupBox1.Text = bindingSourceExportTransactions.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnPrepareExports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (cboExportProcedure.SelectedIndex != -1)
            {
                try
                {
                    DateTime _startDate = dtpStartDate.Value;
                    DateTime _endDate = dtpEndDate.Value;

                    StoredProceduresModel sp = (StoredProceduresModel)cboExportProcedure.SelectedItem;
                    switch (sp.Name)
                    {
                        case "ExportAccounting_Transactions_Det":
                            var _ExportAccounting_Transactions_Detquery = from gp in rep.GetExportAccounting_Transactions_Det()
                                                                          select gp;
                            BindGridToExportAccounting_Transactions_Det(_ExportAccounting_Transactions_Detquery);
                            break;
                        case "ExportAccounting_Transactions":
                            var _ExportAccounting_Transactionsquery = from gp in rep.GetExportAccounting_Transactions()
                                                                      select gp;
                            BindGridToExportAccounting_Transactions(_ExportAccounting_Transactionsquery);
                            break;
                        case "ExportAccounting_Transaction_with_dates":
                            var _startdate = new SqlParameter { ParameterName = "begin_date", Value = dtpStartDate.Value, SqlDbType = SqlDbType.DateTime };
                            var _enddate = new SqlParameter { ParameterName = "end_date", Value = dtpEndDate.Value, SqlDbType = SqlDbType.DateTime };


                            var _ExportAccounting_Transaction_with_datesquery = from gp in rep.GetExportAccounting_Transaction_with_dates(_startDate, _endDate)
                                                                                select gp;
                            BindGridToExportAccounting_Transaction_with_dates(_ExportAccounting_Transaction_with_datesquery);
                            break;
                        case "ExportAccounting_Transactions_Q":
                            var _ExportAccounting_Transactions_Qquery = from gp in rep.GetExportAccounting_Transactions_Q()
                                                                        select gp;
                            BindGridToExportAccounting_Transactions_Q(_ExportAccounting_Transactions_Qquery);
                            break;
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void BindGridToExportAccounting_Transactions_Det(IEnumerable<ExportAccounting_Transactions_DetModel> model)
        {
            try
            {
                bindingSourceExportTransactions.DataSource = null;
                dataGridViewExportTransactions.Columns.Clear();

                DataTable dataTable = this.ConvertExportAccounting_Transactions_DetToDataTable(model);

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
                    DataGridViewCell dataGridViewCell = new DataGridViewTextBoxCell();
                    dataGridViewColumn.DataPropertyName = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.HeaderText = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.CellTemplate = dataGridViewCell;
                    dataGridViewColumn.Name = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.ReadOnly = true;
                    dataGridViewColumn.MinimumWidth = 5;
                    dataGridViewExportTransactions.Columns.Add(dataGridViewColumn);
                }

                this.dataGridViewExportTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                // Set the DataSource for the binding
                bindingSourceExportTransactions.DataSource = dataTable;
                // Prevent unwanted columns autogeneration
                dataGridViewExportTransactions.AutoGenerateColumns = false;
                // Provide the binding to the DataGridView
                dataGridViewExportTransactions.DataSource = bindingSourceExportTransactions;
                groupBox1.Text = bindingSourceExportTransactions.Count.ToString();

                DataGridViewColumn chkdataGridViewColumn = new DataGridViewColumn();
                DataGridViewCell chkdataGridViewCell = new DataGridViewCheckBoxCell();
                chkdataGridViewColumn.DataPropertyName = "SelectAll";
                chkdataGridViewColumn.HeaderText = "";
                chkdataGridViewColumn.CellTemplate = chkdataGridViewCell;
                chkdataGridViewColumn.Name = "SelectAll";
                chkdataGridViewColumn.ReadOnly = false;
                chkdataGridViewColumn.Width = 40;
                chkdataGridViewColumn.MinimumWidth = 5; 
                dataGridViewExportTransactions.Columns.Insert(0, chkdataGridViewColumn);

                BindListViewToExportAccounting_TransactionsDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void BindGridToExportAccounting_Transactions(IEnumerable<ExportAccounting_TransactionsModel> model)
        {
            try
            {
                bindingSourceExportTransactions.DataSource = null;
                dataGridViewExportTransactions.Columns.Clear();

                DataTable dataTable = this.ConvertExportAccounting_TransactionsToDataTable(model);

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
                    DataGridViewCell dataGridViewCell = new DataGridViewTextBoxCell();
                    dataGridViewColumn.DataPropertyName = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.HeaderText = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.CellTemplate = dataGridViewCell;
                    dataGridViewColumn.Name = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.ReadOnly = true;
                    dataGridViewExportTransactions.Columns.Add(dataGridViewColumn);
                }

                this.dataGridViewExportTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                // Set the DataSource for the binding
                bindingSourceExportTransactions.DataSource = dataTable;
                // Prevent unwanted columns autogeneration
                dataGridViewExportTransactions.AutoGenerateColumns = false;
                // Provide the binding to the DataGridView
                dataGridViewExportTransactions.DataSource = bindingSourceExportTransactions;
                groupBox1.Text = bindingSourceExportTransactions.Count.ToString();

                DataGridViewColumn chkdataGridViewColumn = new DataGridViewColumn();
                DataGridViewCell chkdataGridViewCell = new DataGridViewCheckBoxCell();
                chkdataGridViewColumn.DataPropertyName = "SelectAll";
                chkdataGridViewColumn.HeaderText = "";
                chkdataGridViewColumn.CellTemplate = chkdataGridViewCell;
                chkdataGridViewColumn.Name = "SelectAll";
                chkdataGridViewColumn.ReadOnly = false;
                chkdataGridViewColumn.Width = 40;
                chkdataGridViewColumn.MinimumWidth = 5;
                dataGridViewExportTransactions.Columns.Insert(0, chkdataGridViewColumn);

                BindListViewToExportAccounting_TransactionsDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void BindGridToExportAccounting_Transaction_with_dates(IEnumerable<ExportAccounting_Transaction_with_datesModel> model)
        {
            try
            {
                bindingSourceExportTransactions.DataSource = null;
                dataGridViewExportTransactions.Columns.Clear();

                DataTable dataTable = this.ConvertExportAccounting_Transaction_with_datesToDataTable(model);

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
                    DataGridViewCell dataGridViewCell = new DataGridViewTextBoxCell();
                    dataGridViewColumn.DataPropertyName = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.HeaderText = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.CellTemplate = dataGridViewCell;
                    dataGridViewColumn.Name = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.ReadOnly = true;
                    dataGridViewExportTransactions.Columns.Add(dataGridViewColumn);
                }

                this.dataGridViewExportTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                // Set the DataSource for the binding
                bindingSourceExportTransactions.DataSource = dataTable;
                // Prevent unwanted columns autogeneration
                dataGridViewExportTransactions.AutoGenerateColumns = false;
                // Provide the binding to the DataGridView
                dataGridViewExportTransactions.DataSource = bindingSourceExportTransactions;
                groupBox1.Text = bindingSourceExportTransactions.Count.ToString();

                DataGridViewColumn chkdataGridViewColumn = new DataGridViewColumn();
                DataGridViewCell chkdataGridViewCell = new DataGridViewCheckBoxCell();
                chkdataGridViewColumn.DataPropertyName = "SelectAll";
                chkdataGridViewColumn.HeaderText = "";
                chkdataGridViewColumn.CellTemplate = chkdataGridViewCell;
                chkdataGridViewColumn.Name = "SelectAll";
                chkdataGridViewColumn.ReadOnly = false;
                chkdataGridViewColumn.Width = 40;
                chkdataGridViewColumn.MinimumWidth = 5;
                dataGridViewExportTransactions.Columns.Insert(0, chkdataGridViewColumn);

                BindListViewToExportAccounting_TransactionsDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void BindGridToExportAccounting_Transactions_Q(IEnumerable<ExportAccounting_Transactions_QModel> model)
        {
            try
            {
                bindingSourceExportTransactions.DataSource = null;
                dataGridViewExportTransactions.Columns.Clear();

                DataTable dataTable = this.ConvertExportAccounting_Transactions_QToDataTable(model);

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    DataGridViewColumn dataGridViewColumn = new DataGridViewColumn();
                    DataGridViewCell dataGridViewCell = new DataGridViewTextBoxCell();
                    dataGridViewColumn.DataPropertyName = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.HeaderText = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.CellTemplate = dataGridViewCell;
                    dataGridViewColumn.Name = dataTable.Columns[i].ColumnName;
                    dataGridViewColumn.ReadOnly = true;
                    dataGridViewExportTransactions.Columns.Add(dataGridViewColumn);
                }

                this.dataGridViewExportTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                // Set the DataSource for the binding
                bindingSourceExportTransactions.DataSource = dataTable;
                // Prevent unwanted columns autogeneration
                dataGridViewExportTransactions.AutoGenerateColumns = false;
                // Provide the binding to the DataGridView
                dataGridViewExportTransactions.DataSource = bindingSourceExportTransactions;
                groupBox1.Text = bindingSourceExportTransactions.Count.ToString();

                DataGridViewColumn chkdataGridViewColumn = new DataGridViewColumn();
                DataGridViewCell chkdataGridViewCell = new DataGridViewCheckBoxCell();
                chkdataGridViewColumn.DataPropertyName = "SelectAll";
                chkdataGridViewColumn.HeaderText = "";
                chkdataGridViewColumn.CellTemplate = chkdataGridViewCell;
                chkdataGridViewColumn.Name = "SelectAll";
                chkdataGridViewColumn.ReadOnly = false;
                chkdataGridViewColumn.Width = 40;
                chkdataGridViewColumn.MinimumWidth = 5;
                dataGridViewExportTransactions.Columns.Insert(0, chkdataGridViewColumn);

                BindListViewToExportAccounting_TransactionsDataTable(dataTable);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private DataTable ConvertExportAccounting_Transactions_DetToDataTable(IEnumerable<ExportAccounting_Transactions_DetModel> model)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("TRNS", typeof(string));
            dt.Columns.Add("TRNSID", typeof(string));
            dt.Columns.Add("TRNSTYPE", typeof(string));
            dt.Columns.Add("DATE", typeof(string));
            dt.Columns.Add("ACCNT", typeof(string));
            dt.Columns.Add("CLASS", typeof(string));
            dt.Columns.Add("NAME", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));
            dt.Columns.Add("DOCNUM", typeof(string));
            dt.Columns.Add("MEMO", typeof(string));

            int _rowid = 1;
            foreach (var item in model)
            {
                dt.Rows.Add(_rowid.ToString(), item.TRNS, item.TRNSID, item.TRNSTYPE, item.DATE, item.ACCNT, item.CLASS, item.NAME, item.AMOUNT, item.DOCNUM, item.MEMO);
                _rowid++;
            }

            return dt;
        }
        private DataTable ConvertExportAccounting_TransactionsToDataTable(IEnumerable<ExportAccounting_TransactionsModel> model)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("elementary_id", typeof(int));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("event_code", typeof(string));
            dt.Columns.Add("contract_code", typeof(string));
            dt.Columns.Add("amount", typeof(decimal));
            dt.Columns.Add("fundingLine", typeof(string));
            dt.Columns.Add("currency_name", typeof(string));
            dt.Columns.Add("currency_id", typeof(int));
            dt.Columns.Add("exchange_rate", typeof(double));
            dt.Columns.Add("debit_local_account_number", typeof(string));
            dt.Columns.Add("credit_local_account_number", typeof(string));

            int _rowid = 1;
            foreach (var item in model)
            {
                dt.Rows.Add(_rowid.ToString(), item.elementary_id, item.type, item.date, item.event_code, item.contract_code, item.amount, item.fundingLine, item.currency_name, item.currency_id, item.exchange_rate, item.debit_local_account_number, item.credit_local_account_number);
                _rowid++;
            }

            return dt;
        }
        private DataTable ConvertExportAccounting_Transaction_with_datesToDataTable(IEnumerable<ExportAccounting_Transaction_with_datesModel> model)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("elementary_id", typeof(int));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("date", typeof(DateTime));
            dt.Columns.Add("event_code", typeof(string));
            dt.Columns.Add("contract_code", typeof(string));
            dt.Columns.Add("amount", typeof(decimal));
            dt.Columns.Add("fundingLine", typeof(string));
            dt.Columns.Add("currency_name", typeof(string));
            dt.Columns.Add("currency_id", typeof(int));
            dt.Columns.Add("exchange_rate", typeof(double));
            dt.Columns.Add("debit_local_account_number", typeof(string));
            dt.Columns.Add("credit_local_account_number", typeof(string));

            int _rowid = 1;
            foreach (var item in model)
            {
                dt.Rows.Add(_rowid.ToString(), item.elementary_id, item.type, item.date, item.event_code, item.contract_code, item.amount, item.fundingLine, item.currency_name, item.currency_id, item.exchange_rate, item.debit_local_account_number, item.credit_local_account_number);
                _rowid++;
            }

            return dt;
        }
        private DataTable ConvertExportAccounting_Transactions_QToDataTable(IEnumerable<ExportAccounting_Transactions_QModel> model)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("No", typeof(string));
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Loan", typeof(string));
            dt.Columns.Add("TRNS", typeof(string));
            dt.Columns.Add("TRNSTYPE", typeof(string));
            dt.Columns.Add("DATE", typeof(string));
            dt.Columns.Add("ACCNT", typeof(string));
            dt.Columns.Add("NAME", typeof(string));
            dt.Columns.Add("AMOUNT", typeof(string));

            int _rowid = 1;
            foreach (var item in model)
            {
                dt.Rows.Add(_rowid.ToString(), item.ID, item.Loan, item.TRNS, item.TRNSTYPE, item.DATE, item.ACCNT, item.NAME, item.AMOUNT);
                _rowid++;
            }

            return dt;
        }
        private void dataGridViewExportTransactions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int _total = dataGridViewExportTransactions.RowCount;
                progressBarExports.Minimum = 0;
                progressBarExports.Maximum = dataGridViewExportTransactions.RowCount;

                for (int i = 0; i < dataGridViewExportTransactions.RowCount; i++)
                {
                    dataGridViewExportTransactions.Rows[i].DataGridView[0, i].Value = true;
                    //OnExportAccounting_TransactionSelected(this, new ExportAccounting_TransactionsSelectEventArgs(i));
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeSelectAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                progressBarExports.Minimum = 0;
                progressBarExports.Maximum = dataGridViewExportTransactions.RowCount;

                for (int i = 0; i < dataGridViewExportTransactions.RowCount; i++)
                {
                    dataGridViewExportTransactions.Rows[i].DataGridView[0, i].Value = false;
                    //OnExportAccounting_TransactionSelected(this, new ExportAccounting_TransactionsSelectEventArgs(i)); 
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void BindListViewToExportAccounting_TransactionsDataTable(DataTable dataTable)
        {
            try
            {
                listViewResults.View = View.Details;
                listViewResults.GridLines = false;
                listViewResults.FullRowSelect = true;
                listViewResults.MultiSelect = false;
                listViewResults.HideSelection = false;
                // Width of -2 indicates auto-size.
                listViewResults.Columns.Add("", -2, HorizontalAlignment.Left);
                listViewResults.Items.Clear();

                ImageList photoList = new ImageList();
                photoList.TransparentColor = Color.Blue;
                photoList.ColorDepth = ColorDepth.Depth32Bit;
                photoList.ImageSize = new Size(10, 10);
                photoList.Images.Add(Image.FromFile("Resources/greenmage.jpg"));
                listViewResults.SmallImageList = photoList;

                for (int i = 1; i < dataTable.Columns.Count - 1; i++)
                {
                    listViewResults.Items.Add(new ListViewItem(new string[]
                       {
                           dataTable.Columns[i].ColumnName
                       }));
                }
                foreach (ListViewItem item in listViewResults.Items)
                {
                    item.ImageIndex = 0;
                    item.Checked = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void listViewResults_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                foreach (ListViewItem item in listViewResults.Items)
                {
                    //if (item.Checked == true)
                    //{
                    //    ListViewItem.ListViewSubItem _tuitionfees = item.SubItems[1];
                    //}
                    //if (item.Checked == true)
                    //{
                    //    ListViewItem.ListViewSubItem _tuitionfees = item.SubItems[1];
                    //} 
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ExportAccounting_Transactions_Selected(object sender, ExportAccounting_TransactionsSelectEventArgs e)
        {
            try
            {
                progressBarExports.Value = e._Counter;
                SetProgress(e._Counter);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetProgress(Object obj)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewExportTransactions_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewExportTransactions_Validated(object sender, EventArgs e)
        {
            try
            {
                int checkedrows = 0;
                string _rowchecked = string.Empty;

                foreach (DataGridViewRow row in dataGridViewExportTransactions.Rows)
                {
                    if (row.Cells["SelectAll"].Value != null)
                    {
                        _rowchecked = (string)row.Cells["SelectAll"].Value;
                        if (_rowchecked == "True")
                        {
                            checkedrows++;
                        }
                    }
                }
                lblCheckedRowsCounter.Text = checkedrows.ToString() + "  selected out of :  " + dataGridViewExportTransactions.Rows.Count;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }  
        private void btnRunExports_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
 #endregion "Private Methods"




    }
















    public class ExportAccounting_TransactionsSelectEventArgs : System.EventArgs
    {
        // add local member variables to hold text 
        private int _counter;

        // class constructor
        public ExportAccounting_TransactionsSelectEventArgs(int counter)
        {
            this._counter = counter;
        }

        // Properties - Viewable by each listener 
        public int _Counter
        {
            get
            {
                return _counter;
            }
        }
    }











}