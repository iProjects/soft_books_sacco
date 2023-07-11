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
    public partial class NonSolidarityGroupsListForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public NonSolidarityGroupsListForm(int _user, string Conn)
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
        private void btnAddNewNonSolidarityGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddNonSolidarityGroupForm annsgf = new AddNonSolidarityGroupForm(connection) { Owner = this };
                annsgf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void NonSolidarityGroupsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewNonSolidarityGroup.AutoGenerateColumns = false;
                this.dataGridViewNonSolidarityGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //bindingSourceNonSolidarityGroup.DataSource = rep.GetNonSolidarityGroupsList();
                dataGridViewNonSolidarityGroup.DataSource = bindingSourceNonSolidarityGroup;
                groupBox1.Text = bindingSourceNonSolidarityGroup.Count.ToString();
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
                bindingSourceNonSolidarityGroup.DataSource = null;
                //set the datasource to a method
                //bindingSourceNonSolidarityGroup.DataSource = rep.GetNonSolidarityGroupsList();
                groupBox1.Text = bindingSourceNonSolidarityGroup.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewNonSolidarityGroup.Rows)
                {
                    dataGridViewNonSolidarityGroup.Rows[dataGridViewNonSolidarityGroup.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewNonSolidarityGroup.Rows.Count - 1;
                    bindingSourceNonSolidarityGroup.Position = nRowIndex;
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
                if (dataGridViewNonSolidarityGroup.SelectedRows.Count != 0)
                {
                    //DAL.gl_NonSolidarityGroup nonsolidaritygroup = (DAL.gl_NonSolidarityGroup)bindingSourceNonSolidarityGroup.Current;
                    //EditNonSolidarityGroupForm epf = new EditNonSolidarityGroupForm(nonsolidaritygroup, _user, connection) { Owner = this };
                    //epf.Text = nonsolidaritygroup.Description.ToUpper().Trim();
                    //epf.ShowDialog();
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
                if (dataGridViewNonSolidarityGroup.SelectedRows.Count != 0)
                {
                    //DAL.gl_NonSolidarityGroup nonsolidaritygroup = (DAL.gl_NonSolidarityGroup)bindingSourceNonSolidarityGroup.Current;
                    //EditNonSolidarityGroupForm epf = new EditNonSolidarityGroupForm(nonsolidaritygroup, _user, connection) { Owner = this };
                    //epf.Text = nonsolidaritygroup.Description.ToUpper().Trim();
                    //epf.DisableControls();
                    //epf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewNonSolidarityGroup_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewNonSolidarityGroup.SelectedRows.Count != 0)
                {
                    //DAL.gl_NonSolidarityGroup nonsolidaritygroup = (DAL.gl_NonSolidarityGroup)bindingSourceNonSolidarityGroup.Current;
                    //EditNonSolidarityGroupForm epf = new EditNonSolidarityGroupForm(nonsolidaritygroup, _user, connection) { Owner = this };
                    //epf.Text = nonsolidaritygroup.Description.ToUpper().Trim();
                    //epf.ShowDialog();
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