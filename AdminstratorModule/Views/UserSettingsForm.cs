using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class UserSettingsForm : Form
    {
        Repository rep;
        SBSaccoDBEntities db;
        string connection;

        public UserSettingsForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void UserSettingsForm_Load(object sender, EventArgs e)
        {
            try
            {
                chkcheckUpdates.Checked = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtConsolidationExportPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = true;
                if (Char.IsLetter(e.KeyChar)) e.Handled = true;
                if (Char.IsNumber(e.KeyChar)) e.Handled = true;
                if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
                if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
                if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
                if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
                if (e.KeyChar == (char)Keys.Back) e.Handled = true;
                if (e.KeyChar == (char)Keys.Space) e.Handled = true;
                if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
                if (e.KeyChar == (char)Keys.Clear) e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtBackupExportPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = true;
                if (Char.IsLetter(e.KeyChar)) e.Handled = true;
                if (Char.IsNumber(e.KeyChar)) e.Handled = true;
                if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
                if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
                if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
                if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
                if (e.KeyChar == (char)Keys.Back) e.Handled = true;
                if (e.KeyChar == (char)Keys.Space) e.Handled = true;
                if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
                if (e.KeyChar == (char)Keys.Clear) e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnBackupExportPath_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnConsolidationExportPath_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }







    }
}