using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using Infrastructure.Models;

namespace TellersModule.Views
{
    public partial class BranchesForm : Form
    {
        #region "Private Fields"
        SBSaccoDBEntities db;
        Repository rep;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public BranchesForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }
        #endregion "Constructor"


        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void BranchesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _Branchesquery = from br in rep.GetAllBranches()
                                     where br.deleted == false
                                     select br;
                bindingSourceBranches.DataSource = _Branchesquery.ToList();
                groupBox2.Text = bindingSourceBranches.Count.ToString();
                dataGridViewBranches.AutoGenerateColumns = false;
                this.dataGridViewBranches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewBranches.DataSource = bindingSourceBranches;

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
                if (chkIsDeleted.Checked)
                {
                    bindingSourceBranches.DataSource = null;
                    var _Branchesquery = from br in rep.GetAllBranches()
                                         select br;
                    bindingSourceBranches.DataSource = _Branchesquery.ToList();
                    groupBox2.Text = bindingSourceBranches.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewBranches.Rows)
                    {
                        dataGridViewBranches.Rows[dataGridViewBranches.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewBranches.Rows.Count - 1;
                        bindingSourceBranches.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceBranches.DataSource = null;
                    var _Branchesquery = from br in rep.GetAllBranches()
                                         where br.deleted == false
                                         select br;
                    bindingSourceBranches.DataSource = _Branchesquery.ToList();
                    groupBox2.Text = bindingSourceBranches.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewBranches.Rows)
                    {
                        dataGridViewBranches.Rows[dataGridViewBranches.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewBranches.Rows.Count - 1;
                        bindingSourceBranches.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewBranches.SelectedRows.Count != 0)
            {
                try
                {
                    BranchModel branch = (BranchModel)bindingSourceBranches.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Branch\n" + branch.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteBranch(branch); 
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewBranches.SelectedRows.Count != 0)
            {
                try
                {
                    BranchModel branch = (BranchModel)bindingSourceBranches.Current;
                    EditBranchesForm ebf = new EditBranchesForm(branch, connection) { Owner = this };
                    ebf.Text = branch.name.ToString().ToUpper();
                    ebf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                AddBranchesForm abf = new AddBranchesForm(connection) { Owner = this };
                abf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void chkIsDeleted_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkIsDeleted.Checked)
                {
                    bindingSourceBranches.DataSource = null;
                    var _Branchesquery = from br in rep.GetAllBranches()
                                         select br;
                    bindingSourceBranches.DataSource = _Branchesquery.ToList();
                    groupBox2.Text = bindingSourceBranches.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewBranches.Rows)
                    {
                        dataGridViewBranches.Rows[dataGridViewBranches.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewBranches.Rows.Count - 1;
                        bindingSourceBranches.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceBranches.DataSource = null;
                    var _Branchesquery = from br in rep.GetAllBranches()
                                         where br.deleted == false
                                         select br;
                    bindingSourceBranches.DataSource = _Branchesquery.ToList();
                    groupBox2.Text = bindingSourceBranches.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewBranches.Rows)
                    {
                        dataGridViewBranches.Rows[dataGridViewBranches.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewBranches.Rows.Count - 1;
                        bindingSourceBranches.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewBranches_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBranches.SelectedRows.Count != 0)
            {
                try
                {
                    BranchModel branch = (BranchModel)bindingSourceBranches.Current;
                    EditBranchesForm ebf = new EditBranchesForm(branch, connection) { Owner = this };
                    ebf.Text = branch.name.ToString().ToUpper();
                    ebf.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }






    }
}
