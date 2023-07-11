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
    public partial class AddCurrencyForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

         #region "Constructor"
        public AddCurrencyForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);
        }
        #endregion "Constructor"

        #region "Validation"
        private bool IsCurrencyValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtCurrencyName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCurrencyName, "Currency Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCurrencyCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCurrencyCode, "Currency Code cannot be null!");
                return false;
            } 
            return noerror;
        }
        #endregion "Validation" 

        #region "Private Methods" 
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (IsCurrencyValid())
                {
                    CurrencyModel currency = new CurrencyModel();
                    currency.name = Utils.ConvertFirstLetterToUpper(txtCurrencyName.Text);
                    currency.code = Utils.ConvertFirstLetterToUpper(txtCurrencyCode.Text);
                    currency.use_cents = chkUseCents.Checked;
                    currency.is_swapped = chkIsSwapped.Checked;
                    currency.is_pivot = chkIsPivot.Checked;

                    if (db.Currencies.Any(i => i.name == currency.name && i.code == currency.code))
                    {
                        MessageBox.Show("Currency with Name " + currency.name + " Exists!", "SB Sacco", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Currencies.Any(i => i.name == currency.name && i.code == currency.code))
                    {
                        rep.AddNewCurrency(currency);

                        CurrenciesForm f = (CurrenciesForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void AddCurrencyForm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"
        
    }
}
