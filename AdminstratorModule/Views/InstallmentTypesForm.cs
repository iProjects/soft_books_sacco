using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace AdminstratorModule.Views
{
    public partial class InstallmentTypesForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public InstallmentTypesForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsInstallmentTypeValid())
            {
                try
                {
                    switch (btnAdd.Text)
                    {
                        case "Add":
                            InstallmentTypesModel installmenttype = new InstallmentTypesModel();
                            installmenttype.name = Utils.ConvertFirstLetterToUpper(txtName.Text);
                            installmenttype.nb_of_months = int.Parse(txtNoofMonths.Text);
                            installmenttype.nb_of_days = int.Parse(txtNoofDays.Text);

                            if (rep.GetAllInstallmentTypes().Any(i => i.name == installmenttype.name))
                            {
                                MessageBox.Show("Name Exist!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            if (!rep.GetAllInstallmentTypes().Any(i => i.name == installmenttype.name))
                            {
                                rep.AddNewInstallmentType(installmenttype);
                                RefreshGrid();
                                ClearControls();
                            }                            
                            break;
                        case "Update":
                            DAL.InstallmentTypesModel _installmenttype = (DAL.InstallmentTypesModel)bindingSourceInstallmentTypes.Current;
                            _installmenttype.name = Utils.ConvertFirstLetterToUpper(txtName.Text);
                            _installmenttype.nb_of_months = int.Parse(txtNoofMonths.Text);
                            _installmenttype.nb_of_days = int.Parse(txtNoofDays.Text);

                            rep.UpdateInstallmentType(_installmenttype);
                            RefreshGrid();

                            ClearControls();
                            btnAdd.Text = "Add";
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }


        #region "Validation"
        private bool IsInstallmentTypeValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNoofMonths.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoofMonths, "No of Months cannot be null!");
                return false;
            }
            int NoofMonths;
            if (!int.TryParse(txtNoofMonths.Text, out NoofMonths))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoofMonths, "No of Months must be integer!");
                return false;
            }
            if (string.IsNullOrEmpty(txtNoofDays.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoofDays, "No of Days cannot be null!");
                return false;
            }
            int NoofDays;
            if (!int.TryParse(txtNoofDays.Text, out  NoofDays))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtNoofDays, "No of Days must be integer!");
                return false;
            }

            return noerror;
        }
        #endregion "Validation"
        private void txtNoofDays_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtNoofDays_KeyDown(object sender, KeyEventArgs e)
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
        private void txtNoofMonths_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {

                }
                e.Handled = true;
            }
        }
        private void txtNoofMonths_KeyDown(object sender, KeyEventArgs e)
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
        private void InstallmentTypesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var installmentTypesquery = from it in rep.GetAllInstallmentTypes()
                                            select it;
                List<InstallmentTypesModel> InstallmentTypes = installmentTypesquery.ToList();
                bindingSourceInstallmentTypes.DataSource = InstallmentTypes;
                dataGridViewInstallmentTypes.AutoGenerateColumns = false;
                this.dataGridViewInstallmentTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewInstallmentTypes.DataSource = bindingSourceInstallmentTypes;
                groupBox2.Text = bindingSourceInstallmentTypes.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearControls( )
        {
            try
            {
                txtName.Text = string.Empty;
                txtNoofMonths.Text = string.Empty;
                txtNoofDays.Text = string.Empty;
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
                bindingSourceInstallmentTypes.DataSource = null;
                var installmentTypesquery = from it in rep.GetAllInstallmentTypes()
                                            select it;
                List<InstallmentTypesModel> InstallmentTypes = installmentTypesquery.ToList();
                bindingSourceInstallmentTypes.DataSource = InstallmentTypes;
                groupBox2.Text = bindingSourceInstallmentTypes.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewInstallmentTypes.Rows)
                {
                    dataGridViewInstallmentTypes.Rows[dataGridViewInstallmentTypes.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewInstallmentTypes.Rows.Count - 1;
                    bindingSourceInstallmentTypes.Position = nRowIndex;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewInstallmentTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewInstallmentTypes.SelectedRows.Count != 0)
            {
                try
                {
                    errorProvider1.Clear(); //Clear all Error Messages
                    DAL.InstallmentTypesModel c = (DAL.InstallmentTypesModel)bindingSourceInstallmentTypes.Current;
                    txtName.Text = c.name.ToString().Trim();
                    txtNoofMonths.Text = c.nb_of_months.ToString().Trim();
                    txtNoofDays.Text = c.nb_of_days.ToString().Trim();
                    btnAdd.Text = "Update";

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            txtName.Text = string.Empty;
            txtNoofMonths.Text = string.Empty;
            txtNoofDays.Text = string.Empty;
            btnAdd.Text = "Add";
            errorProvider1.Clear();
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewInstallmentTypes.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.InstallmentTypesModel c = (DAL.InstallmentTypesModel)bindingSourceInstallmentTypes.Current;
                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Installment Type\n" + c.name.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteInstallmentType(c);
                        RefreshGrid();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #endregion "Private Methods"




    }
}