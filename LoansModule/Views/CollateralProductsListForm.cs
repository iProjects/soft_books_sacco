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
    public partial class CollateralProductsListForm : Form
    { 
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        #endregion "Private Fields"

        #region "Constructor"
        public CollateralProductsListForm(string Conn)
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
                AddCollateralProductForm ancpf = new AddCollateralProductForm(connection) { Owner = this };
                ancpf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void CollateralProductsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewCollateralProducts.AutoGenerateColumns = false;
                this.dataGridViewCollateralProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                var Collateralsquery = from cl in rep.GetNonCollateralProducts()
                                       select cl;
                bindingSourceCollateralProducts.DataSource = Collateralsquery;
                dataGridViewCollateralProducts.DataSource = bindingSourceCollateralProducts;
                groupBox1.Text = bindingSourceCollateralProducts.Count.ToString();
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
                bindingSourceCollateralProducts.DataSource = null;
                //set the datasource to a method
                var Collateralsquery = from cl in rep.GetNonCollateralProducts()
                                       select cl;
                bindingSourceCollateralProducts.DataSource = Collateralsquery;
                groupBox1.Text = bindingSourceCollateralProducts.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewCollateralProducts.Rows)
                {
                    dataGridViewCollateralProducts.Rows[dataGridViewCollateralProducts.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewCollateralProducts.Rows.Count - 1;
                    bindingSourceCollateralProducts.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCollateralProducts.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.CollateralProductsModel collateral = (DAL.CollateralProductsModel)bindingSourceCollateralProducts.Current;
                    EditCollateralProductForm epf = new EditCollateralProductForm(collateral, connection) { Owner = this };
                    epf.Text = collateral.name.ToUpper().Trim();
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
            if (dataGridViewCollateralProducts.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.CollateralProductsModel collateral = (DAL.CollateralProductsModel)bindingSourceCollateralProducts.Current;
                    EditCollateralProductForm epf = new EditCollateralProductForm(collateral, connection) { Owner = this };                    
                    epf.Text = collateral.name.ToUpper().Trim();
                    epf.DisableControls();
                    epf.ShowDialog();
                    
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewCollateralProducts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCollateralProducts.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.CollateralProductsModel collateral = (DAL.CollateralProductsModel)bindingSourceCollateralProducts.Current;
                    EditCollateralProductForm epf = new EditCollateralProductForm(collateral, connection) { Owner = this };
                    epf.Text = collateral.name.ToUpper().Trim();
                    epf.ShowDialog();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewCollateralProducts.SelectedRows.Count != 0)
            {
                try
                {

                    DAL.CollateralProductsModel collateral = (DAL.CollateralProductsModel)bindingSourceCollateralProducts.Current;

                    var _collateralproductpropertiesquery = from br in rep.GetAllCollateralProductProperties(collateral.collateralproductid)
                                               select br;
                    List<CollateralPropertiesModel> _collateralproductproperties = _collateralproductpropertiesquery.ToList();

                    if (_collateralproductproperties.Count > 0)
                    {
                        MessageBox.Show("There is a Property Associated with this Product\nDelete the Property first!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Product\n" + collateral.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteCollateralProduct(collateral);
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

