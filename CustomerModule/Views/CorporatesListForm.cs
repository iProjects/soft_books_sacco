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

namespace CustomerModule.Views
{
    public partial class CorporatesListForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public CorporatesListForm(int _user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
            user = _user;
        }
        #endregion "Constructor" 

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAddNewCorporate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddCorporateForm ancf = new AddCorporateForm(connection) { Owner = this };
                ancf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void CorporatesListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewCorporates.AutoGenerateColumns = false;
                this.dataGridViewCorporates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //bindingSourceCorporates.DataSource = rep.GetCorporatesList();
                dataGridViewCorporates.DataSource = bindingSourceCorporates;
                groupBox1.Text = bindingSourceCorporates.Count.ToString();
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
                bindingSourceCorporates.DataSource = null;
                //set the datasource to a method
                //bindingSourceCorporates.DataSource = rep.GetCorporatesList();
                groupBox1.Text = bindingSourceCorporates.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewCorporates.Rows)
                {
                    dataGridViewCorporates.Rows[dataGridViewCorporates.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewCorporates.Rows.Count - 1;
                    bindingSourceCorporates.Position = nRowIndex;
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
                if (dataGridViewCorporates.SelectedRows.Count != 0)
                {
                    //DAL.gl_Corporate corporate = (DAL.gl_Corporate)bindingSourceCorporates.Current;
                    //EditCorporateForm ecf = new EditCorporateForm(corporate, _user, connection) { Owner = this };
                    //ecf.Text = corporate.Description.ToUpper().Trim();
                    //ecf.ShowDialog();
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
                if (dataGridViewCorporates.SelectedRows.Count != 0)
                {
                    //DAL.gl_Corporate corporate = (DAL.gl_Corporate)bindingSourceCorporates.Current;
                    //EditCorporateForm ecf = new EditCorporateForm(corporate, _user, connection) { Owner = this };
                    //ecf.Text = corporate.Description.ToUpper().Trim();
                    //ecf.DisableControls();
                    //ecf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewCorporates_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewCorporates.SelectedRows.Count != 0)
                {
                    //DAL.gl_Corporate corporate = (DAL.gl_Corporate)bindingSourceCorporates.Current;
                    //EditCorporateForm ecf = new EditCorporateForm(corporate, _user, connection) { Owner = this };
                    //ecf.Text = corporate.Description.ToUpper().Trim();
                    //ecf.ShowDialog();
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
