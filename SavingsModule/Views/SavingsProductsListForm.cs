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

namespace SavingsModule.Views
{
    public partial class SavingsProductsListForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public SavingsProductsListForm(string Conn)
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
                AddSavingsProductForm anspf = new AddSavingsProductForm(connection) { Owner = this };
                anspf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SavingsProductsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewSavingsProducts.AutoGenerateColumns = false;
                this.dataGridViewSavingsProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceSavingsProducts.DataSource = rep.GetSavingProductsList().Where(i=>i.deleted == false);
                dataGridViewSavingsProducts.DataSource = bindingSourceSavingsProducts;
                groupBox1.Text = bindingSourceSavingsProducts.Count.ToString();
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
                bindingSourceSavingsProducts.DataSource = null;
                //set the datasource to a method 
                bindingSourceSavingsProducts.DataSource = rep.GetSavingProductsList().Where(i => i.deleted == false);
                groupBox1.Text = bindingSourceSavingsProducts.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewSavingsProducts.Rows)
                {
                    dataGridViewSavingsProducts.Rows[dataGridViewSavingsProducts.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewSavingsProducts.Rows.Count - 1;
                    bindingSourceSavingsProducts.Position = nRowIndex;
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
                if (dataGridViewSavingsProducts.SelectedRows.Count != 0)
                {
                    DAL.SavingProductModel savings = (DAL.SavingProductModel)bindingSourceSavingsProducts.Current;
                    EditSavingsProductForm espf = new EditSavingsProductForm(savings, connection) { Owner = this };
                    espf.Text = savings.name.ToUpper().Trim();
                    espf.ShowDialog();
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
                if (dataGridViewSavingsProducts.SelectedRows.Count != 0)
                {
                    DAL.SavingProductModel savings = (DAL.SavingProductModel)bindingSourceSavingsProducts.Current;
                    EditSavingsProductForm espf = new EditSavingsProductForm(savings, connection) { Owner = this };
                    espf.Text = savings.name.ToUpper().Trim();
                    espf.DisableControls();
                    espf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSavingsProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewSavingsProducts.SelectedRows.Count != 0)
                {
                    DAL.SavingProductModel savings = (DAL.SavingProductModel)bindingSourceSavingsProducts.Current;
                    EditSavingsProductForm espf = new EditSavingsProductForm(savings, connection) { Owner = this };
                    espf.Text = savings.name.ToUpper().Trim();
                    espf.ShowDialog();
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
                if (dataGridViewSavingsProducts.SelectedRows.Count != 0)
                {
                    DAL.SavingProductModel savings = (DAL.SavingProductModel)bindingSourceSavingsProducts.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Savings\n" + savings.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteSavingsProduct(savings);
                        RefreshGrid();

                    }
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
