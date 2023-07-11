using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace LoansModule.Views
{
    public partial class LoanProductsListForm : Form
    {


        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public LoanProductsListForm(string Conn)
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddLoanProductForm anpf = new AddLoanProductForm(connection) { Owner = this };
                anpf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void LoanProductsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewLoanProducts.AutoGenerateColumns = false;
                this.dataGridViewLoanProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceLoanProducts.DataSource = rep.GetLoanPackagesList();
                dataGridViewLoanProducts.DataSource = bindingSourceLoanProducts;
                groupBox1.Text = bindingSourceLoanProducts.Count.ToString();
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
                bindingSourceLoanProducts.DataSource = null;
                //set the datasource to a method
                bindingSourceLoanProducts.DataSource = rep.GetLoanPackagesList();
                groupBox1.Text = bindingSourceLoanProducts.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewLoanProducts.Rows)
                {
                    dataGridViewLoanProducts.Rows[dataGridViewLoanProducts.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewLoanProducts.Rows.Count - 1;
                    bindingSourceLoanProducts.Position = nRowIndex;
                }
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
                if (dataGridViewLoanProducts.SelectedRows.Count != 0)
                {
                    DAL.LoanPackageModel loan = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    EditLoanProductForm epf = new EditLoanProductForm(loan, connection) { Owner = this };
                    epf.Text = loan.name.ToUpper().Trim();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewLoanProducts.SelectedRows.Count != 0)
                {
                    DAL.LoanPackageModel loan = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    EditLoanProductForm epf = new EditLoanProductForm(loan, connection) { Owner = this };
                    epf.Text = loan.name.ToUpper().Trim();
                    epf.DisableControls();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewLoanProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewLoanProducts.SelectedRows.Count != 0)
                {
                    DAL.LoanPackageModel loan = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    EditLoanProductForm epf = new EditLoanProductForm(loan, connection) { Owner = this };
                    epf.Text = loan.name.ToUpper().Trim();
                    epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewLoanProducts.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.LoanPackageModel c = (DAL.LoanPackageModel)bindingSourceLoanProducts.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Loan\n" + c.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeletePackage(c);
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