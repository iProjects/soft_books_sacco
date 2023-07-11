using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class EditFundingLineForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        FundingLineModel _fundingline;
        int _user;
        #endregion "Private Fields"

        #region "Constructor"
        public EditFundingLineForm(DAL.FundingLineModel fundinglines, int user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (fundinglines == null)
                throw new ArgumentNullException("FundingLine");
            _fundingline = fundinglines;

            if (user == null)
                throw new ArgumentNullException("user");
            _user = user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsFundingLineValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _fundingline.purpose = Utils.ConvertFirstLetterToUpper(txtName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtCode.Text))
                    {
                        _fundingline.name = Utils.ConvertFirstLetterToUpper(txtCode.Text);
                    }
                    if (cboCurrency.SelectedIndex != -1)
                    {
                        _fundingline.currency_id = int.Parse(cboCurrency.SelectedValue.ToString());
                    }
                    _fundingline.begin_date = dtpBeginDate.Value;
                    _fundingline.end_date = dtpEndDate.Value; 

                    rep.UpdateFundingLine(_fundingline);

                    FundingLinesListForm f = (FundingLinesListForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsFundingLineValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCode, "Code cannot be null!");
                return false;
            }
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCurrency, "Select Currency!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"

        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceFundingLineEvents.DataSource = null;
                //set the datasource to a method
                bindingSourceFundingLineEvents.DataSource = rep.GetFundingLineEventsList(_fundingline.fundinglineid);
                groupBox2.Text = bindingSourceFundingLineEvents.Count.ToString();

                ComputeAmountTotal();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void EditFundingLineForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<FundingLineEventModel> fundinglineEvents = rep.GetFundingLineEventsList(_fundingline.fundinglineid);

                dataGridViewFundingLineEvents.AutoGenerateColumns = false;
                this.dataGridViewFundingLineEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceFundingLineEvents.DataSource = fundinglineEvents;
                dataGridViewFundingLineEvents.DataSource = bindingSourceFundingLineEvents;
                groupBox2.Text = bindingSourceFundingLineEvents.Count.ToString();

                ComputeAmountTotal();

                var currenciesquery = from cr in rep.GetCurrenciesList()
                                      select cr;
                List<CurrencyModel> currencies = currenciesquery.ToList();
                cboCurrency.DataSource = currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;

                InitializeControls();

                InitializeGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            } 
        }
        private void InitializeControls()
        {

            try
            {
                if (_fundingline.purpose != null)
                {
                    txtName.Text = _fundingline.purpose.Trim();
                }
                if (_fundingline.name != null)
                {
                    txtCode.Text = _fundingline.name.Trim();
                }
                if (_fundingline.currency_id != null)
                {
                    cboCurrency.SelectedValue = _fundingline.currency_id;
                }
                if (_fundingline.begin_date != null)
                {
                    dtpBeginDate.Value = _fundingline.begin_date;
                }
                if (_fundingline.end_date != null)
                {
                    dtpEndDate.Value = _fundingline.end_date;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void InitializeGrid()
        {

            try
            {
                dataGridViewFundingLineEvents.Columns[0].Name = "Column1FundingLineCode";
                dataGridViewFundingLineEvents.Columns[1].Name = "Column2CreationDate";
                dataGridViewFundingLineEvents.Columns[2].Name = "Column3Amount";
                dataGridViewFundingLineEvents.Columns[3].Name = "Column4Direction";
                dataGridViewFundingLineEvents.Columns[4].Name = "Column5Type";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        public void DisableControls()
        {
            txtCode.Enabled = false;
            txtName.Enabled = false;
            cboCurrency.Enabled = false;
            dtpBeginDate.Enabled = false;
            dtpEndDate.Enabled = false;
            txtInitialAmount.Enabled = false;
            txtRealReminder.Enabled = false;
            txtAnticipatedReminder.Enabled = false;
            dataGridViewFundingLineEvents.Enabled = false;
            btnAddFundingEvent.Enabled = false;
            btnDeleteFundingEvent.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;

        }
        private void btnAddFundingEvent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddFundingLineEventForm afle = new AddFundingLineEventForm(_fundingline, _user, connection) { Owner = this };
                afle.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDeleteFundingEvent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFundingLineEvents.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FundingLineEventModel fundinglineevent = (DAL.FundingLineEventModel)bindingSourceFundingLineEvents.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Funding Line Event \n" + fundinglineevent.code.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteFundingLineEvent(fundinglineevent); 
                        RefreshGrid();
                        ComputeAmountTotal();
                    }

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewFundingLineEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ComputeAmountTotal();
        }
        public void ComputeAmountTotal()
        {
            try
            {
                decimal _total_amount = 0;
                decimal rowAmount = 0;
                foreach (DataGridViewRow row in dataGridViewFundingLineEvents.Rows)
                {
                    decimal workhrs = 0;
                    if (row.Cells["Column3Amount"].Value != null)
                    {
                        workhrs = (decimal)row.Cells["Column3Amount"].Value;
                    }
                    rowAmount = workhrs;
                    _total_amount += rowAmount;
                }

                txtInitialAmount.Text = _total_amount.ToString();
                txtRealReminder.Text = _total_amount.ToString();
                txtAnticipatedReminder.Text = _total_amount.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"



    }
}