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
    public partial class EditLoanScalesForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        LoanScaleModel _loanscale;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public EditLoanScalesForm(LoanScaleModel loanscale, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _loanscale = loanscale;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsLoanScaleValid())
            {
                try
                {
                    _loanscale.ScaleMin = int.Parse(txtScaleMin.Text);
                    _loanscale.ScaleMax = int.Parse(txtScaleMax.Text);

                    rep.UpdateLoanScale(_loanscale);

                    GeneralSettingsForm f = (GeneralSettingsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsLoanScaleValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtScaleMin.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtScaleMin, "Minimum Scale cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtScaleMax.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtScaleMax, "Maximum Scale cannot be null!");
                return false;
            }
            return noerror;
        }
        private void EditLoanScalesForm_Load(object sender, EventArgs e)
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
                if (_loanscale.ScaleMin != null)
                {
                    txtScaleMin.Text = _loanscale.ScaleMin.ToString();
                }
                if (_loanscale.ScaleMax != null)
                {
                    txtScaleMax.Text = _loanscale.ScaleMax.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtScaleMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtScaleMin_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }
        private void txtScaleMax_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        private void txtScaleMax_KeyDown(object sender, KeyEventArgs e)
        {

        }
        #endregion "Private Methods"

         



    }
}