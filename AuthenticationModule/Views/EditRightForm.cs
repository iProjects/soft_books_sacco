﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AuthenticationModule.Views
{
    public partial class EditRightForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        spAllowedRoleMenu _right; 
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public EditRightForm(spAllowedRoleMenu right , string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("connection");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (right == null)
                throw new ArgumentNullException("right");
            _right = right; 
        }
        #endregion "Constructor"

        #region "Private Methods"

        #endregion "Private Methods"

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsRightValid())
            {
                try
                {
                    if (cboRoles.SelectedIndex != -1)
                    {
                        _right.RoleId = int.Parse(cboRoles.SelectedValue.ToString());
                    }
                    if (cboMenuItem.SelectedIndex != -1)
                    {
                        _right.MenuItemId = int.Parse(cboMenuItem.SelectedValue.ToString());
                    }
                    _right.Allowed = chkAllowed.Checked;

                    rep.UpdateRight(_right);

                    RightsListForm f = (RightsListForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {

                    Utils.ShowError(ex);

                }
            }
        }

        private bool IsRightValid()
        {
            bool noerror = true;
            if (cboRoles.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboRoles, "Select Role!");
                return false;
            }
            if (cboMenuItem.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboMenuItem, "Select Menu Item!");
                return false;
            }
            return noerror;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditRightForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _Rolesquery = from rl in db.spRoles
                                  select rl;
                List<spRole> _Roles = _Rolesquery.ToList();
                cboRoles.DataSource = _Roles;
                cboRoles.ValueMember = "Id";
                cboRoles.DisplayMember = "Description";
                cboRoles.SelectedIndex = -1;

                var _menuItemsquery = (from rl in db.spMenuItems
                                       select rl).OrderBy(i => i.Description);
                List<spMenuItem> _MenuItems = _menuItemsquery.ToList();
                cboMenuItem.DataSource = _MenuItems;
                cboMenuItem.ValueMember = "Id";
                cboMenuItem.DisplayMember = "Description";
                cboMenuItem.SelectedIndex = -1;

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
                if (_right.RoleId != null)
                {
                    cboRoles.SelectedValue = _right.RoleId;
                    cboRoles.Enabled = false;
                }
                if (_right.MenuItemId != null)
                {
                    cboMenuItem.SelectedValue = _right.MenuItemId;
                    cboMenuItem.Enabled = false;
                }
                if (_right.Allowed != null)
                {
                    chkAllowed.Checked = _right.Allowed;
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);

            }
        }



    }
}