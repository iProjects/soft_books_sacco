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
    public partial class AddFundingLineEventForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        FundingLineModel _fundingline;
        int _user;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public AddFundingLineEventForm(DAL.FundingLineModel fundingline, int user, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (fundingline == null)
                throw new ArgumentNullException("FundingLine");
            _fundingline = fundingline;

            if (user == null)
                throw new ArgumentNullException("user");
            _user = user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        } 
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsFundingLineEventValid())
            {
                try
                {
                    FundingLineEvent _fundinglineevent = new FundingLineEvent();
                    if (!string.IsNullOrEmpty(txtCode.Text))
                    {
                        _fundinglineevent.code = txtCode.Text;
                    }
                    _fundinglineevent.creation_date = dtpDate.Value;
                    decimal flAmount;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && decimal.TryParse(txtAmount.Text, out flAmount))
                    {
                        _fundinglineevent.amount = flAmount;
                    }
                    if (cboDirection.SelectedIndex != -1)
                    {
                        _fundinglineevent.direction = (short)cboDirection.SelectedValue;
                    }
                    _fundinglineevent.fundingline_id = _fundingline.fundinglineid;
                    if (_fundinglineevent.direction != null)
                    {
                        _fundinglineevent.type = GetFundingLineEventType(_fundinglineevent.direction);
                    }
                    _fundinglineevent.user_id = rep.GetUserId(_user);
                    _fundinglineevent.deleted = false;

                    if (!db.FundingLineEvents.Any(i => i.fundingline_id == _fundinglineevent.fundingline_id && i.code == _fundinglineevent.code))
                    {
                        db.FundingLineEvents.AddObject(_fundinglineevent);
                        db.SaveChanges();
                    }

                    EditFundingLineForm f = (EditFundingLineForm)this.Owner;
                    f.RefreshGrid();
                    f.ComputeAmountTotal();
                    this.Close(); 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        } 
        #region "Validation"
        private bool IsFundingLineEventValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCode, "Code cannot be null!");
                return false;
            }
            if (cboDirection.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboDirection, "Select Direction!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount cannot be null!");
                return false;
            } 
            return noerror;
        }
        #endregion "Validation"

        private short GetFundingLineEventType(int dir)
        {
            try
            {
                return 0;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private void AddFundingLineEvent_Load(object sender, EventArgs e)
        {
            try
            {
                var directions = new BindingList<KeyValuePair<short, string>>();
                directions.Add(new KeyValuePair<short, string>(1, "Credit"));
                directions.Add(new KeyValuePair<short, string>(2, "Debit"));
                cboDirection.DataSource = directions;
                cboDirection.ValueMember = "Key";
                cboDirection.DisplayMember = "Value";
                cboDirection.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAddExchangeRate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ExchangeRatesForm erf = new ExchangeRatesForm(_fundingline, connection) { Owner = this };
                erf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {
                     
                }
                e.Handled = true;
            }
        }
        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
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