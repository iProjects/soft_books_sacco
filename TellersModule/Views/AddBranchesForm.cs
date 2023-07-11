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
    public partial class AddBranchesForm : Form
    {
        #region "Private Fields"
        SBSaccoDBEntities db;
        Repository rep;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddBranchesForm(string Conn)
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

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsBranchValid())
            {
                try
                {
                    Branch _branch = new Branch();
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _branch.name = Utils.ConvertFirstLetterToUpper(txtName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtCode.Text))
                    {
                        _branch.code = Utils.ConvertFirstLetterToUpper(txtCode.Text);
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _branch.description = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    }
                    if (!string.IsNullOrEmpty(txtAddress.Text))
                    {
                        _branch.address = Utils.ConvertFirstLetterToUpper(txtAddress.Text);
                    }
                    _branch.deleted = false;

                    if (db.Branches.Any(i => i.code == _branch.code))
                    {
                        MessageBox.Show("Branch Code Exist!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } 
                    if (!db.Branches.Any(i => i.code == _branch.code))
                    {
                        db.Branches.AddObject(_branch);
                        db.SaveChanges();

                        BranchesForm br = (BranchesForm)this.Owner;
                        br.RefreshGrid();
                        this.Close();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #region "Validation"
        private bool IsBranchValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCode, "Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAddress, "Address cannot be null!");
                return false;
            } 
            return noerror;
        }
        #endregion "Validation"





    }
}
