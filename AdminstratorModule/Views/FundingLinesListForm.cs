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
    public partial class FundingLinesListForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int _user;
        #endregion "Private Fields"

        #region "Constructor"
        public FundingLinesListForm(int user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
             
            _user = user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddFundingLineForm aflf = new AddFundingLineForm(connection) { Owner = this };
                aflf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void FundingLinesListForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<CurrencyModel> currencies = rep.GetCurrenciesList();
                DataGridViewComboBoxColumn colCboxCurrency = new DataGridViewComboBoxColumn();
                colCboxCurrency.HeaderText = "Currency";
                colCboxCurrency.Name = "cbCurrency";
                colCboxCurrency.DataSource = currencies;
                // The display member is the name column in the column datasource  
                colCboxCurrency.DisplayMember = "name";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxCurrency.DataPropertyName = "currency_id";
                // The value member is the primary key of the parent table  
                colCboxCurrency.ValueMember = "currencyid";
                colCboxCurrency.MaxDropDownItems = 10;
                colCboxCurrency.Width = 100;
                colCboxCurrency.DisplayIndex = 5;
                colCboxCurrency.MinimumWidth = 5;
                colCboxCurrency.FlatStyle = FlatStyle.Flat;
                colCboxCurrency.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxCurrency.ReadOnly = true;
                colCboxCurrency.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                if (!this.dataGridViewFundingLines.Columns.Contains("cbCurrency"))
                {
                    dataGridViewFundingLines.Columns.Add(colCboxCurrency);
                }

                var fundinglinesquery = from fl in rep.GetFundingLinesList()
                                        where fl.deleted == false
                                        select fl;
                List<FundingLineModel> fundinglines = fundinglinesquery.ToList();
                dataGridViewFundingLines.AutoGenerateColumns = false;
                this.dataGridViewFundingLines.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceFundingLines.DataSource = fundinglines;
                dataGridViewFundingLines.DataSource = bindingSourceFundingLines;
                groupBox3.Text = bindingSourceFundingLines.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceFundingLines.DataSource = null;
                //set the datasource to a method
                var fundinglinesquery = from fl in rep.GetFundingLinesList()
                                        where fl.deleted == false
                                        select fl;
                List<FundingLineModel> fundinglines = fundinglinesquery.ToList();
                bindingSourceFundingLines.DataSource = fundinglines;
                groupBox3.Text = bindingSourceFundingLines.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewFundingLines.Rows)
                {
                    dataGridViewFundingLines.Rows[dataGridViewFundingLines.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewFundingLines.Rows.Count - 1;
                    bindingSourceFundingLines.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFundingLines.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FundingLineModel fundingline = (DAL.FundingLineModel)bindingSourceFundingLines.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Funding Line\n" + fundingline.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteFundingLine(fundingline);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewFundingLines_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewFundingLines.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FundingLineModel fundinglines = (DAL.FundingLineModel)bindingSourceFundingLines.Current;

                    EditFundingLineForm epf = new EditFundingLineForm(fundinglines, _user, connection) { Owner = this };
                    epf.Text = fundinglines.name.ToUpper().Trim();
                    epf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFundingLines.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FundingLineModel fundinglines = (DAL.FundingLineModel)bindingSourceFundingLines.Current;
                    EditFundingLineForm epf = new EditFundingLineForm(fundinglines, _user, connection) { Owner = this };
                    epf.Text = fundinglines.name.ToUpper().Trim();
                    epf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFundingLines.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FundingLineModel fundinglines = (DAL.FundingLineModel)bindingSourceFundingLines.Current;
                    EditFundingLineForm epf = new EditFundingLineForm(fundinglines, _user, connection) { Owner = this };
                    epf.Text = fundinglines.name.ToUpper().Trim();
                    epf.DisableControls();
                    epf.ShowDialog();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #endregion "Private Methods"





    }
}
