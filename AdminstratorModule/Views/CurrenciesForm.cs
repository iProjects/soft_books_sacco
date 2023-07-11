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
    public partial class CurrenciesForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public CurrenciesForm(string Conn)
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
        private void CurrenciesForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewCurrencies.AutoGenerateColumns = false;
                this.dataGridViewCurrencies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceCurrencies.DataSource = rep.GetCurrenciesList();
                dataGridViewCurrencies.DataSource = bindingSourceCurrencies;
                groupBox2.Text = bindingSourceCurrencies.Count.ToString();
                if (bindingSourceCurrencies.Count > 0)
                {
                    btnAdd.Enabled=false;
                }
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
                bindingSourceCurrencies.DataSource = null;
                //set the datasource to a method
                bindingSourceCurrencies.DataSource = rep.GetCurrenciesList();
                groupBox2.Text = bindingSourceCurrencies.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewCurrencies.Rows)
                {
                    dataGridViewCurrencies.Rows[dataGridViewCurrencies.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewCurrencies.Rows.Count - 1;
                    bindingSourceCurrencies.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewCurrencies.SelectedRows.Count != 0)
                {

                    DAL.CurrencyModel c = (DAL.CurrencyModel)bindingSourceCurrencies.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Currency\n" + c.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteCurrency(c);
                        RefreshGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddCurrencyForm acf = new AddCurrencyForm(connection) { Owner = this };
                acf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewCurrencies.SelectedRows.Count != 0)
                {

                    DAL.CurrencyModel cur = (DAL.CurrencyModel)bindingSourceCurrencies.Current;
                    EditCurrencyForm ecf = new EditCurrencyForm(cur, connection) { Owner = this };
                    ecf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCurrencies_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewCurrencies.SelectedRows.Count != 0)
                {
                    DAL.CurrencyModel cur = (DAL.CurrencyModel)bindingSourceCurrencies.Current;
                    EditCurrencyForm ecf = new EditCurrencyForm(cur, connection) { Owner = this };
                    ecf.ShowDialog();
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