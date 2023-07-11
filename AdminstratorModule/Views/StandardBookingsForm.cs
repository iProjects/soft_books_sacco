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
    public partial class StandardBookingsForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection; 
        #endregion "Private Fields"

        #region "Constructor"
        public StandardBookingsForm(int _user, string Conn)
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
        private void StandardBookingsForm_Load(object sender, EventArgs e)
        {
            try
            {

                var draccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _drAccounts = draccountsquery.ToList();
                DataGridViewComboBoxColumn colCboxdrAccount = new DataGridViewComboBoxColumn();
                colCboxdrAccount.HeaderText = "Debit Account";
                colCboxdrAccount.Name = "cbdrAccount";
                colCboxdrAccount.DataSource = _drAccounts;
                // The display member is the name column in the column datasource  
                colCboxdrAccount.DisplayMember = "label";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxdrAccount.DataPropertyName = "debit_account_id";
                // The value member is the primary key of the parent table  
                colCboxdrAccount.ValueMember = "accountid";
                colCboxdrAccount.MaxDropDownItems = 10;
                colCboxdrAccount.Width = 200;
                colCboxdrAccount.DisplayIndex = 2;
                colCboxdrAccount.MinimumWidth = 5;
                colCboxdrAccount.FlatStyle = FlatStyle.Flat;
                colCboxdrAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxdrAccount.ReadOnly = true;
                //colCboxRole.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewStandardBookings.Columns.Contains("cbdrAccount"))
                {
                    dataGridViewStandardBookings.Columns.Add(colCboxdrAccount);
                }

                var craccountsquery = from et in rep.GetAccountsList()
                                      select et;
                List<AccountModel> _crAccounts = craccountsquery.ToList();
                DataGridViewComboBoxColumn colCboxcrAccount = new DataGridViewComboBoxColumn();
                colCboxcrAccount.HeaderText = "Credit Account";
                colCboxcrAccount.Name = "cbcrAccount";
                colCboxcrAccount.DataSource = _crAccounts;
                // The display member is the name column in the column datasource  
                colCboxcrAccount.DisplayMember = "label";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxcrAccount.DataPropertyName = "credit_account_id";
                // The value member is the primary key of the parent table  
                colCboxcrAccount.ValueMember = "accountid";
                colCboxcrAccount.MaxDropDownItems = 10;
                colCboxcrAccount.Width = 200;
                colCboxcrAccount.DisplayIndex = 3;
                colCboxcrAccount.MinimumWidth = 5;
                colCboxcrAccount.FlatStyle = FlatStyle.Flat;
                colCboxcrAccount.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxcrAccount.ReadOnly = true;
                colCboxcrAccount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewStandardBookings.Columns.Contains("cbcrAccount"))
                {
                    dataGridViewStandardBookings.Columns.Add(colCboxcrAccount);
                }  

                var _accountingrulesquery = rep.GetAllStandardBookings();
                dataGridViewStandardBookings.AutoGenerateColumns = false;
                this.dataGridViewStandardBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceStandardBookings.DataSource = _accountingrulesquery;
                dataGridViewStandardBookings.DataSource = bindingSourceStandardBookings;
                groupBox1.Text = bindingSourceStandardBookings.Count.ToString();
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
                bindingSourceStandardBookings.DataSource = null;
                var _accountingrulesquery = rep.GetAllStandardBookings(); 
                bindingSourceStandardBookings.DataSource = _accountingrulesquery; 
                groupBox1.Text = bindingSourceStandardBookings.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewStandardBookings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStandardBookings.SelectedRows.Count != 0)
            {
                try
                {
                    StandardBookingsModel standardbooking = (StandardBookingsModel)bindingSourceStandardBookings.Current;
                    Views.EditStandardBookingsForm edu = new EditStandardBookingsForm(standardbooking, connection) { Owner = this };
                    edu.Text = standardbooking.Name;
                    edu.ShowDialog();
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
                AddStandardBookingForm usf = new AddStandardBookingForm(connection) { Owner = this };
                usf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            } 
        } 
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewStandardBookings.SelectedRows.Count != 0)
            {
                try
                {
                    StandardBookingsModel standardbooking = (StandardBookingsModel)bindingSourceStandardBookings.Current;
                    Views.EditStandardBookingsForm eus = new EditStandardBookingsForm(standardbooking, connection) { Owner = this };
                    eus.Text = standardbooking.Name;
                    eus.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            } 
        } 
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                StandardBookingsModel standardbooking = (StandardBookingsModel)bindingSourceStandardBookings.Current;
                if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete Standard Booking\n" + standardbooking.Name, "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    rep.DeleteStandardBooking(standardbooking);
                    RefreshGrid();
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
        #endregion "Private Methods"





    }
}
