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
    public partial class EditProvisioningRulesForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        ProvisioningRuleModel _provisioningrule;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public EditProvisioningRulesForm(ProvisioningRuleModel provisioningrule, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            _provisioningrule = provisioningrule;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (IsProvisioningRuleValid())
            {
                try
                {
                    _provisioningrule.number_of_days_min = int.Parse(txtnumber_of_days_min.Text);
                    _provisioningrule.number_of_days_max = int.Parse(txtnumber_of_days_max.Text);
                    _provisioningrule.provisioning_value = float.Parse(txtprovisioning_value.Text);
                    
                    rep.UpdateProvisioningRule(_provisioningrule);

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
        public bool IsProvisioningRuleValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtnumber_of_days_min.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtnumber_of_days_min, "Minimun number of days cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtnumber_of_days_max.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtnumber_of_days_max, "Maximun number of days cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtprovisioning_value.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtprovisioning_value, "Provisioning Value cannot be null!");
                return false;
            }
            return noerror;
        }
        private void EditProvisioningRulesForm_Load(object sender, EventArgs e)
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
                if (_provisioningrule.number_of_days_min != null)
                {
                    txtnumber_of_days_min.Text = _provisioningrule.number_of_days_min.ToString();
                }
                if (_provisioningrule.number_of_days_max != null)
                {
                    txtnumber_of_days_max.Text = _provisioningrule.number_of_days_max.ToString();
                }
                if (_provisioningrule.provisioning_value != null)
                {
                    txtprovisioning_value.Text = _provisioningrule.provisioning_value.ToString();
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
        private void txtnumber_of_days_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtnumber_of_days_min_KeyDown(object sender, KeyEventArgs e)
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
        private void txtnumber_of_days_max_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtnumber_of_days_max_KeyDown(object sender, KeyEventArgs e)
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
        private void txtprovisioning_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtprovisioning_value_KeyDown(object sender, KeyEventArgs e)
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
        #endregion "Private Methods"





    }
}