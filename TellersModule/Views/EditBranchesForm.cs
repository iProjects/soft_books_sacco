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
    public partial class EditBranchesForm : Form
    {
        #region "Private Fields"
        SBSaccoDBEntities db;
        Repository rep;
        string connection;
        BranchModel _branch;
        #endregion "Private Fields"

         #region "Constructor"
        public EditBranchesForm(BranchModel branch, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (branch == null)
                throw new ArgumentNullException("Branch");
            _branch = branch;
        }
        #endregion "Constructor"

        private void EditBranchesForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void InitializeControls()
        {
            try
            {
                if (_branch.name != null)
                {
                    txtName.Text = _branch.name;
                }
                if (_branch.code != null)
                {
                    txtCode.Text = _branch.code;
                }
                if (_branch.description != null)
                {
                    txtDescription.Text = _branch.description;
                }
                if (_branch.address != null)
                {
                    txtAddress.Text = _branch.address;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             errorProvider1.Clear();
             if (IsBranchValid())
             {
                 try
                 {
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

                     rep.UpdateBranch(_branch);

                     BranchesForm br = (BranchesForm)this.Owner;
                     br.RefreshGrid();
                     this.Close();
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
