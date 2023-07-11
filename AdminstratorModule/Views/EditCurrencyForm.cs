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
    public partial class EditCurrencyForm : Form
    {
       
        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        DAL.CurrencyModel _cur;
        #endregion "Private Fields"

         #region "Constructor"
        public EditCurrencyForm(DAL.CurrencyModel cur, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSaccoDBEntities(connection);

            if (cur == null)
                throw new ArgumentNullException("gl_Currencies");
            _cur = cur;

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

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (IsCurrencyValid())
                {
                    _cur.name = Utils.ConvertFirstLetterToUpper(txtCurrencyName.Text.Trim());
                    _cur.code = Utils.ConvertFirstLetterToUpper(txtCurrencyCode.Text.Trim());
                    _cur.use_cents = chkUseCents.Checked;
                    _cur.is_swapped = chkIsSwapped.Checked;
                    _cur.is_pivot = chkIsPivot.Checked;

                    rep.UpdateCurrency(_cur);

                    CurrenciesForm f = (CurrenciesForm)this.Owner;
                    f.RefreshGrid();
                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void EditCurrencyForm_Load(object sender, EventArgs e)
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
                if (_cur.name != null)
                {
                    txtCurrencyName.Text = _cur.name.Trim();
                }
                if (_cur.code != null)
                {
                    txtCurrencyCode.Text = _cur.code.Trim();
                }
                if (_cur.use_cents != null)
                {
                    chkUseCents.Checked = _cur.use_cents;
                }
                if (_cur.is_swapped != null)
                {
                    chkIsSwapped.Checked = _cur.is_swapped;
                }
                if (_cur.is_pivot != null)
                {
                    chkIsPivot.Checked = _cur.is_pivot;
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);

            }
        }
        #endregion "Private Methods"
       

        
    }
}
