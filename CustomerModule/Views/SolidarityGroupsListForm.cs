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
    public partial class SolidarityGroupsListForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        int user;
        #endregion "Private Fields"

        #region "Constructor"
        public SolidarityGroupsListForm(int _user, string Conn)
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
        private void btnAddNewSolidarityGroup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddSolidarityGroupForm ansgf = new AddSolidarityGroupForm(connection) { Owner = this };
                ansgf.ShowDialog();
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
                bindingSourceSolidarityGroup.DataSource = null;
                //set the datasource to a method
                //bindingSourceSolidarityGroup.DataSource = rep.GetSolidarityGroupsList();
                groupBox1.Text = bindingSourceSolidarityGroup.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewSolidarityGroup.Rows)
                {
                    dataGridViewSolidarityGroup.Rows[dataGridViewSolidarityGroup.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewSolidarityGroup.Rows.Count - 1;
                    bindingSourceSolidarityGroup.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SolidarityGroupsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewSolidarityGroup.AutoGenerateColumns = false;
                this.dataGridViewSolidarityGroup.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                //bindingSourceSolidarityGroup.DataSource = rep.GetSolidarityGroupsList();
                dataGridViewSolidarityGroup.DataSource = bindingSourceSolidarityGroup;
                groupBox1.Text = bindingSourceSolidarityGroup.Count.ToString();
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
                if (dataGridViewSolidarityGroup.SelectedRows.Count != 0)
                {
                //    DAL.gl_SolidarityGroup solidaritygroup = (DAL.gl_SolidarityGroup)bindingSourceSolidarityGroup.Current;
                //    EditSolidarityGroupForm epf = new EditSolidarityGroupForm(solidaritygroup, _user, connection) { Owner = this };
                //    epf.Text = solidaritygroup.Description.ToUpper().Trim();
                //    epf.ShowDialog();
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
                if (dataGridViewSolidarityGroup.SelectedRows.Count != 0)
                {
                    //DAL.gl_SolidarityGroup solidaritygroup = (DAL.gl_SolidarityGroup)bindingSourceSolidarityGroup.Current;
                    //EditSolidarityGroupForm epf = new EditSolidarityGroupForm(solidaritygroup, _user, connection) { Owner = this };
                    //epf.Text = solidaritygroup.Description.ToUpper().Trim();
                    //epf.DisableControls();
                    //epf.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSolidarityGroup_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewSolidarityGroup.SelectedRows.Count != 0)
                {
                    //DAL.gl_SolidarityGroup solidaritygroup = (DAL.gl_SolidarityGroup)bindingSourceSolidarityGroup.Current;
                    //EditSolidarityGroupForm epf = new EditSolidarityGroupForm(solidaritygroup, _user, connection) { Owner = this };
                    //epf.Text = solidaritygroup.Description.ToUpper().Trim();
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
