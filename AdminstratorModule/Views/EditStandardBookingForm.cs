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


namespace AdminstratorModule.Views
{
    public partial class EditStandardBookingForm : Form
    {
        Repository rep;
        DAL.gl_StandardBookings su;

        public EditStandardBookingForm(DAL.gl_StandardBookings stanbook)
        {
            InitializeComponent();
            rep = new Repository();
            su = stanbook;
        }
        public bool IsStandardBookingValid()
        {
            bool noerror = true;
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null");
            };
            
            if (!string.IsNullOrEmpty(cbDebitAccount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbDebitAccount, "Debit Account cannot be null");
            };
            if (!string.IsNullOrEmpty(cbCreditAccount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cbCreditAccount, "Credit Account cannot be null");
            };
            return noerror;
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();

            try
            {
                if (IsStandardBookingValid())
                {
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        su.Name = txtName.Text.ToString();
                    };

                    if (cbDebitAccount.SelectedIndex != -1)
                    {
                        su.DebitAccountID = int.Parse(cbDebitAccount.SelectedValue.ToString());
                    };
                    if (cbCreditAccount.SelectedIndex != -1)
                    {
                        su.CreditAccountID = int.Parse(cbCreditAccount.SelectedValue.ToString());
                    };
                   
                    
                    rep.UpdateStandardBooking(su);
                    StandardBookingsForm ulf = (StandardBookingsForm)this.Owner;
                    ulf.RefreshGrid();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }

        private void EditStandardBookingForm_Load(object sender, EventArgs e)
        {

            try
            {
                List<gl_Accounts> acnt = rep.GetAllAccounts();
                cbDebitAccount.ValueMember = "AccountID";
                cbDebitAccount.DisplayMember = "AccountName";
                cbDebitAccount.DataSource = acnt;
                

                List<gl_Accounts> acn = rep.GetAllAccounts();
                cbCreditAccount.ValueMember = "AccountID";
                cbCreditAccount.DisplayMember = "AccountName";
                cbCreditAccount.DataSource = acn;
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }
        public void InitializeControls()
        {
            try
            {
                
                if (su.Name != null)
                {
                    txtName.Text = su.Name;

                };
                
                if (su.DebitAccountID != null)
                {
                    cbDebitAccount.SelectedValue = su.DebitAccountID;
                }
                if (su.CreditAccountID != null)
                {
                    cbCreditAccount.SelectedValue = su.CreditAccountID;
                }
                
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
        }
    }
}
