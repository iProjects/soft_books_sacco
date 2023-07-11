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
    public partial class GuaranteeProductsListForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public GuaranteeProductsListForm(string Conn)
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
                AddGuaranteeProductForm angpf = new AddGuaranteeProductForm(connection) { Owner = this };
                angpf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void GuaranteeProductsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewGuaranteeProducts.AutoGenerateColumns = false;
                this.dataGridViewGuaranteeProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //bindingSourceGuaranteeProducts.DataSource = rep.GetGuaranteeProductsList();
                dataGridViewGuaranteeProducts.DataSource = bindingSourceGuaranteeProducts;
                groupBox1.Text = bindingSourceGuaranteeProducts.Count.ToString();
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
                bindingSourceGuaranteeProducts.DataSource = null;
                //set the datasource to a method
                //bindingSourceGuaranteeProducts.DataSource = rep.GetGuaranteeProductsList();
                groupBox1.Text = bindingSourceGuaranteeProducts.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewGuaranteeProducts.Rows)
                {
                    dataGridViewGuaranteeProducts.Rows[dataGridViewGuaranteeProducts.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewGuaranteeProducts.Rows.Count - 1;
                    bindingSourceGuaranteeProducts.Position = nRowIndex;
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
                if (dataGridViewGuaranteeProducts.SelectedRows.Count != 0)
                {
                    //DAL.gl_Guarantee guarantee = (DAL.gl_Guarantee)bindingSourceGuaranteeProducts.Current;
                    //EditGuaranteeProductForm egpf = new EditGuaranteeProductForm(guarantee, connection) { Owner = this };
                    //egpf.Text = guarantee.Description.ToUpper().Trim();
                    //egpf.ShowDialog();
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
                if (dataGridViewGuaranteeProducts.SelectedRows.Count != 0)
                {
                    //DAL.gl_Guarantee guarantee = (DAL.gl_Guarantee)bindingSourceGuaranteeProducts.Current;
                    //EditGuaranteeProductForm egpf = new EditGuaranteeProductForm(guarantee, connection) { Owner = this };
                    //egpf.Text = guarantee.Description.ToUpper().Trim();
                    //egpf.DisableControls();
                    //egpf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewGuaranteeProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewGuaranteeProducts.SelectedRows.Count != 0)
                {
                    //DAL.gl_Guarantee guarantee = (DAL.gl_Guarantee)bindingSourceGuaranteeProducts.Current;
                    //EditGuaranteeProductForm egpf = new EditGuaranteeProductForm(guarantee, connection) { Owner = this };
                    //egpf.Text = guarantee.Description.ToUpper().Trim();
                    //egpf.ShowDialog();
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
                if (dataGridViewGuaranteeProducts.SelectedRows.Count != 0)
                {

                    //DAL.gl_Guarantee guarantee = (DAL.gl_Guarantee)bindingSourceGuaranteeProducts.Current;
                    //if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Guarantee\n" + guarantee.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    //{
                    //    rep.DeleteGuaranteeProduct(guarantee);
                    //    RefreshGrid();

                    //}
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