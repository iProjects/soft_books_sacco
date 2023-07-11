using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace LoansModule.Views
{
    public partial class AddGuaranteeProductForm : Form
    {
         #region "Private Fields"
        Repository rep;
        SBSaccoDBEntities db;
        string connection;
        #endregion "Private Fields"

        #region "Constructor"
        public AddGuaranteeProductForm(string Conn)
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
            if (IsGuaranteeProductValid())
            {
                try
                {

                    //gl_Guarantee guarantee = new gl_Guarantee();

                    //if (!string.IsNullOrEmpty(txtName.Text))
                    //{
                    //    guarantee.Description = Utils.ConvertFirstLetterToUpper(txtName.Text.Trim());
                    //}
                    //guarantee.gProductAllClientType = chkAllClients.Checked;
                    //guarantee.gProductGroupClientType = chkGroupClient.Checked;
                    //guarantee.gProductIndividualClientType = chkIndividualClient.Checked;
                    //guarantee.gProductCorporateClientType = chkCorporateClient.Checked;
                    //if (cboFundingLine.SelectedIndex != -1)
                    //{
                    //    guarantee.FundingLineId = int.Parse(cboFundingLine.SelectedValue.ToString());
                    //}
                    //if (cboCurrency.SelectedIndex != -1)
                    //{
                    //    guarantee.CurrencyId = int.Parse(cboCurrency.SelectedValue.ToString());
                    //}
                    //decimal MinAmounttobeguaranteed;
                    //if (!string.IsNullOrEmpty(txtMinAmounttobeguaranteed.Text) && decimal.TryParse(txtMinAmounttobeguaranteed.Text, out MinAmounttobeguaranteed))
                    //{
                    //    guarantee.gMinAmounttobeGuaranteed = decimal.Parse(txtMinAmounttobeguaranteed.Text);
                    //}
                    //decimal MaxAmounttobeGuaranteed;
                    //if (!string.IsNullOrEmpty(txtMaxAmounttobeguaranteed.Text) && decimal.TryParse(txtMaxAmounttobeguaranteed.Text, out MaxAmounttobeGuaranteed))
                    //{
                    //    guarantee.gMaxAmounttobeGuaranteed = decimal.Parse(txtMaxAmounttobeguaranteed.Text);
                    //} decimal ValueAmounttobeguaranteed;
                    //if (!string.IsNullOrEmpty(txtValueAmounttobeguaranteed.Text) && decimal.TryParse(txtValueAmounttobeguaranteed.Text, out ValueAmounttobeguaranteed))
                    //{
                    //    guarantee.gValueAmounttobeGuaranteed = decimal.Parse(txtValueAmounttobeguaranteed.Text);
                    //} decimal MinGuaranteeAmount;
                    //if (!string.IsNullOrEmpty(txtMinGuaranteeAmount.Text) && decimal.TryParse(txtMinGuaranteeAmount.Text, out MinGuaranteeAmount))
                    //{
                    //    guarantee.gMinGuaranteeAmount = decimal.Parse(txtMinGuaranteeAmount.Text);
                    //} decimal MaxGuaranteeAmount;
                    //if (!string.IsNullOrEmpty(txtMaxGuaranteeAmount.Text) && decimal.TryParse(txtMaxGuaranteeAmount.Text, out MaxGuaranteeAmount))
                    //{
                    //    guarantee.gMaxGuaranteeAmount = decimal.Parse(txtMaxGuaranteeAmount.Text);
                    //} decimal ValueGuaranteeAmount;
                    //if (!string.IsNullOrEmpty(txtValueGuaranteeAmount.Text) && decimal.TryParse(txtValueGuaranteeAmount.Text, out ValueGuaranteeAmount))
                    //{
                    //    guarantee.gValueGuaranteeAmount = decimal.Parse(txtValueGuaranteeAmount.Text);
                    //}
                    //int MinFeePercentage;
                    //if (!string.IsNullOrEmpty(txtMinFeeGuaranteeAmount.Text) && int.TryParse(txtMinFeeGuaranteeAmount.Text, out MinFeePercentage))
                    //{
                    //    guarantee.gMinFeePercentage = int.Parse(txtMinFeeGuaranteeAmount.Text);
                    //}
                    //int MaxFeePercentage;
                    //if (!string.IsNullOrEmpty(txtMaxFeeGuaranteeAmount.Text) && int.TryParse(txtMaxFeeGuaranteeAmount.Text, out MaxFeePercentage))
                    //{
                    //    guarantee.gMaxFeePercentage = int.Parse(txtMaxFeeGuaranteeAmount.Text);
                    //}
                    //int ValueFeePercentage;
                    //if(!string.IsNullOrEmpty(txtValueFeeGuaranteeAmount.Text) && int.TryParse(txtValueFeeGuaranteeAmount.Text, out ValueFeePercentage))
                    //{
                    //    guarantee.gValueFeePercentage = int.Parse(txtValueFeeGuaranteeAmount.Text);
                    //}

                    //if (!db.gl_Guarantee.Any(i => i.Description == guarantee.Description))
                    //{
                    //    db.gl_Guarantee.AddObject(guarantee);
                    //    db.SaveChanges();
                    //} 

                    GuaranteeProductsListForm f = (GuaranteeProductsListForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
 
        private void AddNewGuaranteeProductForm_Load(object sender, EventArgs e)
        {
            try
            {
                //var currenciesquery = from cr in db.gl_Currencies
                //                      select cr;
                //List<gl_Currencies> currencies = currenciesquery.ToList();
                //cboCurrency.DataSource = currencies;
                //cboCurrency.ValueMember = "Id";
                //cboCurrency.DisplayMember = "Description";
                //cboCurrency.SelectedIndex = -1;

                //var fundinglinesquery = from fl in db.FundingLine
                //                        select fl;
                //List<FundingLine> FundingLines = fundinglinesquery.ToList();
                //cboFundingLine.DataSource = FundingLines;
                //cboFundingLine.ValueMember = "Id";
                //cboFundingLine.DisplayMember = "Description";
                //cboFundingLine.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


        #region "Validation"
        private bool IsGuaranteeProductValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name cannot be null!");
                return false;
            }
            

            return noerror;
        }
        #endregion "Validation"

        private void chkAllClients_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllClients.Checked)
            {
                chkIndividualClient.Checked = true;
                chkGroupClient.Checked = true;
                chkCorporateClient.Checked = true;
            }
            else
            {
                chkIndividualClient.Checked = false;
                chkGroupClient.Checked = false;
                chkCorporateClient.Checked = false;
            }

        }

        #endregion "Private Methods"

       
    }
}
