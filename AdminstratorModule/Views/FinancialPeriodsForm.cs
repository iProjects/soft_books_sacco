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
    public partial class FinancialPeriodsForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public FinancialPeriodsForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void FinancialPeriodsForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewFiscalYears.AutoGenerateColumns = false;
                this.dataGridViewFiscalYears.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceFiscalYears.DataSource = rep.GetAllFiscalYears();
                dataGridViewFiscalYears.DataSource = bindingSourceFiscalYears;
                groupBox2.Text = bindingSourceFiscalYears.Count.ToString();
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
                bindingSourceFiscalYears.DataSource = null;
                //set the datasource to a method
                bindingSourceFiscalYears.DataSource = rep.GetAllFiscalYears();
                groupBox2.Text = bindingSourceFiscalYears.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewFiscalYears.Rows)
                {
                    dataGridViewFiscalYears.Rows[dataGridViewFiscalYears.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewFiscalYears.Rows.Count - 1;
                    bindingSourceFiscalYears.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCreate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ManageFinancialPeriodsForm mfpf = new ManageFinancialPeriodsForm("create", connection) { Owner = this };
                mfpf.DisableControls();
                mfpf.CreatePeriod();
                mfpf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnOpen_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFiscalYears.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FiscalYearModel _fiscalyr = (DAL.FiscalYearModel)bindingSourceFiscalYears.Current;
                    ManageFinancialPeriodsForm mfpf = new ManageFinancialPeriodsForm(_fiscalyr, "open", connection) { Owner = this };
                    mfpf.DisableControls();
                    mfpf.OpenPeriod();
                    mfpf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClosePeriod_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFiscalYears.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FiscalYearModel _fiscalyr = (DAL.FiscalYearModel)bindingSourceFiscalYears.Current;
                    ManageFinancialPeriodsForm mfpf = new ManageFinancialPeriodsForm(_fiscalyr, "close", connection) { Owner = this };
                    mfpf.DisableControls();
                    mfpf.ClosePeriod();
                    mfpf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewFiscalYears.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.FiscalYearModel _fiscalyr = (DAL.FiscalYearModel)bindingSourceFiscalYears.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Fiscal Year\n" + _fiscalyr.name.ToUpper().ToString().Trim(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteFiscalYear(_fiscalyr);
                        RefreshGrid();
                    }
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
