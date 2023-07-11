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
    public partial class AddFundingLineForm : Form
    {

        #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddFundingLineForm(string Conn)
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

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsFundingLineValid())
            {
                try
                {
                    FundingLineModel _fundingline = new FundingLineModel();
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        _fundingline.purpose = Utils.ConvertFirstLetterToUpper(txtName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtCode.Text))
                    {
                        _fundingline.name = Utils.ConvertFirstLetterToUpper(txtCode.Text);
                    }
                    if (cboCurrency.SelectedIndex != -1)
                    {
                        _fundingline.currency_id = (int)cboCurrency.SelectedValue;
                    }
                    _fundingline.begin_date = dtpBeginDate.Value;
                    _fundingline.end_date = dtpEndDate.Value;

                    rep.AddNewFundingLine(_fundingline);

                    FundingLinesListForm f = (FundingLinesListForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }


        #region "Validation"
        private bool IsFundingLineValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCode, "Code cannot be null!");
                return false;
            }
            if (cboCurrency.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCurrency, "Select Currency!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"

        private void AddFundingLineForm_Load(object sender, EventArgs e)
        {
            try
            {
                var currenciesquery = from cr in rep.GetCurrenciesList()
                                      select cr;
                List<CurrencyModel> currencies = currenciesquery.ToList();
                cboCurrency.DataSource = currencies;
                cboCurrency.ValueMember = "currencyid";
                cboCurrency.DisplayMember = "name";
                cboCurrency.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        #endregion "Private Methods"


    }
}
